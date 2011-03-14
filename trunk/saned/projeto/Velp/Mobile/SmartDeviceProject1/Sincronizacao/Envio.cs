using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DeviceProject.referencia;
using DeviceProject.DATA;
using DeviceProject.Util;
using System.Data.SqlServerCe;
using DeviceProject.DATA.dataSaned.Model;
using DeviceProject.DATA.dataSaned.Flow;
using DeviceProject.Config;

namespace DeviceProject.Sincronizacao
{
    /// <summary>
    ///  Classe responsavel por eviar os dados para o web Service
    /// </summary>
    public class Envio
    {
        #region Variaveis Locais

        /// <summary>
        /// Objeto de comunicação com web server
        /// </summary>
        public  referencia.Service1 _webService = new referencia.Service1();

        /// <summary>
        ///  Grupo
        /// </summary>
        public int grupo = 0;

        /// <summary>
        ///  Rota
        /// </summary>
        public int rota = 0;

        /// <summary>
        ///  Referencia
        /// </summary>
        public DateTime referencia = DateTime.Now;

        /// <summary>
        ///  Numero de tentativas para a carga
        /// </summary>
        public int numeroTentativasCarga = 0;

        /// <summary>
        ///  Usuario corrente
        /// </summary>
        public static referencia.Identificacao UserPdaCurrent = new Identificacao();

        #endregion
        
        /// <summary>
        ///  Construtor
        /// </summary>
        public Envio()
        {
            _webService.Url = DeviceProject.Config.ConfiguracaoPDA.CurrentInstance.WebServiceAddress;
            UserPdaCurrent.coletor = ConfiguracaoPDA.GetDeviceID();
            UserPdaCurrent.usuario = (string.IsNullOrEmpty(ConfiguracaoPDA.CurrentInstance.Username)) ? 0 : int.Parse(ConfiguracaoPDA.CurrentInstance.Username);
        }

        /// <summary>
        ///  Metodo generico para consumir o we service
        /// </summary>
        /// <param name="metodo">nome do metodo a ser chamado</param>
        /// <param name="paramtros">array de parametros do metodo</param>
        /// <returns>um objeto de dados retornado do web service</returns>
        public object EnviaDados(string metodo, object[] paramtros)
        {
            object retorno = null;
            numeroTentativasCarga = 0;
        tentativa:
            try
            {
                numeroTentativasCarga++;

                // Conecta ao web server
                retorno = _webService.GetType().GetMethod(metodo).Invoke(_webService, paramtros);
            }
            catch (Exception ex)
            {
                if (numeroTentativasCarga < 3)
                {
                    LogErroFlow.SetErro(ex, metodo, "U");
                    goto tentativa;
                }
                else
                {
                    LogErroFlow.SetErro(ex, metodo, "U");
                    throw ex;
                }
            }
            return retorno;
        }

        /// <summary>
        ///  Envia volta roteiro
        /// </summary>
        public void VoltaRoteiro()
        {
            try
            {
                GenericDAO<VoltaRoteiro> ObjVoltaRoteiro = new GenericDAO<VoltaRoteiro>();

                // Retorna uma lista com todos os dados 
                List<VoltaRoteiro> ListaRoteiros = new List<VoltaRoteiro>();
                ListaRoteiros = ObjVoltaRoteiro.SelectVoltaRoteiro();

                // Verifica se existem dados
                if (ListaRoteiros.Count > 0)
                {
                    // Seta as variaveis que seram usadas no restante do envio
                    grupo = ListaRoteiros[0].Grupo;
                    rota = ListaRoteiros[0].Rota;
                    referencia = ListaRoteiros[0].Referencia;

                    if (this.ValidaCarga(grupo, rota, referencia, "ROTEIRO", ListaRoteiros.Count))
                    {
                        // Envia os dados para o web service
                        object[] parametros = new object[]{ListaRoteiros[0],UserPdaCurrent};
                        EnviaDados("InsertVoltaRoteiro",parametros);
                    }
                }
            }
            catch (Exception exeption)
            {
                throw exeption;
            }
        }

        /// <summary>
        ///  Envia volta leitura
        /// </summary>
        public void VoltaLeitura()
        {
            try
            {
                // Busca no banco registros a serem descarregados
                GenericDAO<int> Descarga = new GenericDAO<int>();
                int qtdcargaPDA = Descarga.VerficaCarga();
                
                if (this.ValidaCarga(grupo, rota, referencia, "LEITURA", qtdcargaPDA))
                {
                    GenericDAO<VoltaLeitura> ObjVoltaLeitura = new GenericDAO<VoltaLeitura>();
                    int setor = _webService.RetornaSetor(
                                                            grupo,
                                                            rota,//rota inicial
                                                            rota//rota final
                                                         );

                    // Retorna uma lista com todos os dados 
                    List<VoltaLeitura> ListaVoltaLeitura = new List<VoltaLeitura>();
                    ListaVoltaLeitura = ObjVoltaLeitura.SelectVoltaLeitura(setor);

                    if (ListaVoltaLeitura.Count() > 0)
                    {
                        numeroTentativasCarga = 0;

                        object[] parametros = new object[] { ListaVoltaLeitura.ToArray(), UserPdaCurrent };
                        EnviaDados("InsertListaVoltaLeitura", parametros);

                        // Percorre a lista inserindo os dados no Banco de log de sincronização
                        foreach (VoltaLeitura Leitura in ListaVoltaLeitura)
                        {
                            try
                            {
                                LogSync log = new LogSync();
                                log.Matricula = Leitura.CDC;
                                log.TipoSync = "U";
                                log.DataSync = DateTime.Now;
                                LogSyncFlow.Insert(log);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
            catch (Exception exeption)
            {
                throw exeption;
            }
        }

        /// <summary>
        ///  Envia volta alteração
        /// </summary>
        public void VoltaAlteracao()
        {
            try
            {
                GenericDAO<VoltaAlteracao> ObjVoltaAlteracao = new GenericDAO<VoltaAlteracao>();
                List<VoltaAlteracao> ListaVoltaAlteracao = new List<VoltaAlteracao>();

                // Retorna uma lista com todos os dados 
                ListaVoltaAlteracao = ObjVoltaAlteracao.SelectVoltaAlteracao();

                if (ListaVoltaAlteracao.Count() > 0)
                {

                    foreach (VoltaAlteracao VoltaAlteracao in ListaVoltaAlteracao)
                    {
                        object[] parametros = new object[] { VoltaAlteracao, UserPdaCurrent };
                        EnviaDados("InsertVoltaAlteracao", parametros);
                    }
                }
            }
            catch (Exception exeption)
            {
                throw exeption;
            }
        }

        /// <summary>
        ///  Envia volta novo registro
        /// </summary>
        public void VoltaNovoRegistro()
        {
            try
            {
                GenericDAO<VoltaNovoRegistro> ObjVoltaNovoRegistro = new GenericDAO<VoltaNovoRegistro>();
                List<VoltaNovoRegistro> ListaVoltaNovoRegistro = new List<VoltaNovoRegistro>();

                // Retorna uma lista com todos os dados 
                ListaVoltaNovoRegistro = ObjVoltaNovoRegistro.SelectVoltaNovoRegistro();

                if (ListaVoltaNovoRegistro.Count() > 0)
                {
                    foreach (VoltaNovoRegistro NovoRegistro in ListaVoltaNovoRegistro)
                    {
                        object[] parametro = new object[] { NovoRegistro, UserPdaCurrent };
                        EnviaDados("InsertVoltaNovoRegistro", parametro);
                    }
                }
            }
            catch (Exception exeption)
            {
                throw exeption;
            }
        }

        /// <summary>
        ///  Envia volta log atendimento
        /// </summary>
        public void VoltaLogAtendimento()
        {
            try
            {
                GenericDAO<VoltaLogAtendimento> ObjVoltaLogAtendimento = new GenericDAO<VoltaLogAtendimento>();
                List<VoltaLogAtendimento> ListaVoltaLogAtendimento = new List<VoltaLogAtendimento>();

                // Retorna uma lista com todos os dados 
                ListaVoltaLogAtendimento = ObjVoltaLogAtendimento.SelectVoltaLodAtendimento();

                if (ListaVoltaLogAtendimento.Count() > 0)
                {
                    if (this.ValidaCarga(grupo, rota, referencia, "ATENDIMENTO", ListaVoltaLogAtendimento.Count))
                    {
                        foreach (VoltaLogAtendimento logAtendimento in ListaVoltaLogAtendimento)
                        {
                            object[] parametros = new object[] { logAtendimento, UserPdaCurrent };
                            EnviaDados("InsertVoltaLogAtendimento", parametros);
                        }
                    }
                }
            }
            catch (Exception exeption)
            {
                throw exeption;
            }
        }

        /// <summary>
        /// Atualiza a tabela de distribuição
        /// </summary>
        public void AtualizaDistribuicao()
        {
            object[] parametros = new object[] { grupo, (int)UserPdaCurrent.usuario, rota };
            EnviaDados("AtualizaDistribuicaoDescarga", parametros);
        }

        /// <summary>
        ///  Valida se todos os registros foram descarregados
        ///     Metodo faz uma comparação entre os registro no webService e o PDA
        /// </summary>
        /// <param name="grupo">grupo</param>
        /// <param name="rota">rota</param>
        /// <param name="referencia"></param>
        /// <param name="tipo">tipo da validação: 
        ///                     -ROTEIRO
        ///                     -LEITURA
        ///                     -ATENDIMENTO
        /// </param>
        /// <param name="quantidadePDA">Quatidade retornada do PDA</param>
        /// <returns></returns>
        public bool ValidaCarga(int grupo, int rota, DateTime referencia, string tipo, int quantidadePDA)
        {
            bool valid = false;
            object[] parametros = new object[] { grupo, rota, referencia, tipo };
            int qtdcargaServidor = (int)EnviaDados("ValidaCarga",parametros);
            if (qtdcargaServidor < quantidadePDA)
                valid = true;
            return valid;
        }

    }
}
