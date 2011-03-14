using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DeviceProject.referencia;
using DeviceProject.DATA;
using DeviceProject.Util;
using System.Data.SqlServerCe;
using DeviceProject.DATA.dataSaned.Flow;

namespace DeviceProject.Sincronizacao
{

    /// <summary>
    /// Classe responsavel por fazer o insert somente da carga dos dados no PDA
    /// </summary>
    /// <typeparam name="T">Tipo generico</typeparam>
    public class InsertCarga<T> where T :new() 
    {

        /// <summary>
        ///  Construtor
        /// </summary>
        public InsertCarga()
        {
        }

        /// <summary>
        ///  Metodo para inserir os dados na tabela de carga
        /// </summary>
        /// <param name="tabela">nome da tabela</param>
        public void InsereTabelaCarga(string tabela)
        {
            try
            {
                TabelaCargaONP[] tabelaCarga = new TabelaCargaONP[1];
                tabelaCarga[0] = new TabelaCargaONP();
                tabelaCarga[0].nom_tabela = tabela;
                tabelaCarga[0].ind_descarga = "N";
                tabelaCarga[0].ind_carga = "S";
                new GenericDAO<TabelaCargaONP>().Insert(tabelaCarga, "ONP_TABELAS_CARGA",null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Metodo responsavel por fazer o insert generico
        /// </summary>
        /// <param name="tabela">nome da tabela</param>
        /// <param name="dados">array de dados</param>
        /// <param name="chave">campo chave para auto incremento</param>
        public void Gravar(string tabela,T[] dados,string chave)
        {
            try
            {
                // Abre a conecxão com o banco de dados
                GenericDAO<T> obj = new GenericDAO<T>();

                DateTime tempoInicial = DateTime.Now;

                // Insere os dados no banco do ONPLACE
                obj.Insert(dados, tabela, chave);

                ExtensionMethods.GetTimeDataBase(tabela, tempoInicial);

                this.InsereTabelaCarga(tabela);

                // Primeira tabela a ser inserida indica inicio da carga
                if (tabela == "ONP_CATEGORIA")
                {
                    // Seta o STATUS ("MARRETA DO ONPLACE")
                    this.InsereTabelaCarga("STATUS");
                }
            }
            catch (Exception ex)
            {
                LogErroFlow.SetErro(ex, tabela, "I");
                throw ex;
            }

        }

        /// <summary>
        ///  Metodo que recupera os dados de fatura para atulização do campos SEQ_FATURA
        /// </summary>
        /// <param name="quant">quantidade retornada</param>
        /// <returns>rertorna o array de fatura</returns>
        public FaturaONP[] GetFatura(int quant)
        {
            try
            {
                GenericDAO<FaturaONP> ObjFatura = new GenericDAO<FaturaONP>();

                // Retorna os dados atualizados de fatura
                return ObjFatura.SelectFatura(quant);
            }
            catch (Exception ex)
            {
                LogErroFlow.SetErro(ex, "ONP_FATURA", "S");
                throw ex;
            }

        }

        /// <summary>
        ///  Metodo insert exclusivo para inserir o aviso debito
        /// </summary>
        /// <param name="avisoDebito"></param>
        /// <param name="quant">quantidade de registros de fatura</param>
        /// <returns>quantidade de registros de fatura atualizado</returns>
        public int AvisoDebito(AvisoDebito[] avisoDebito, int quant)
        {
            FaturaONP[] fatura = new FaturaONP[0];

            try
            {
                if (avisoDebito.Count() > 0)
                {
                    // Retorna os dados atualizados de fatura
                    fatura = GetFatura(quant);

                    // Insere os dados
                    new GenericDAO<AvisoDebito>().InsertAvisoDebito(avisoDebito, fatura);

                    // Seta a carga
                    this.InsereTabelaCarga("ONP_AVISO_DEBITO");
                }
            }
            catch (Exception ex)
            {
                LogErroFlow.SetErro(ex, "ONP_AVISO_DEBITO", "I");
                throw ex;
            }
            return fatura.Length;
        }

        /// <summary>
        ///  Metodo exclusivo para inserir a fatura categoria
        /// </summary>
        /// <param name="faturaCategoria"> array de dados de fatura categoria</param>
        /// <param name="quant">quantidade de registros de fatura</param>
        /// <returns>quantidade de registros de fatura atualizado</returns>
        public int FaturaCategoria(FaturaCategoriaONP[] faturaCategoria ,int quant)
        {
            FaturaONP[] fatura = new FaturaONP[0];
            try
            {
                if (faturaCategoria.Count() > 0)
                {
                    // Retorna os dados atualizados de fatura (OS DADOS FORAM ALTERADOS EM AVISO DE DEBITO)
                    fatura = GetFatura(quant);

                    // Insere os dados de fatura categoria
                    new GenericDAO<FaturaCategoriaONP>().InsertFaturaCategoria(faturaCategoria, fatura);

                    // Seta a carga
                    this.InsereTabelaCarga("ONP_FATURA_CATEGORIA");
                }
            }
            catch (Exception ex)
            {
                LogErroFlow.SetErro(ex, "ONP_FATURA_CATEGORIA", "I");
                throw ex;
            }
            return fatura.Length;
        }

        /// <summary>
        /// Metodo exclusivo para inserir a fatura aviso
        /// </summary>
        /// <param name="faturaAviso">array de dados de fatura aviso</param>
        /// <param name="quant">quantidade de registros de fatura</param>
        /// <returns>quantidade de registros de fatura atualizados</returns>
        public int FaturaAviso(FaturasAvisoONP[] faturaAviso, int quant)
        {
            FaturaONP[] fatura = new FaturaONP[0];

            try
            {
                if (faturaAviso.Count() > 0)
                {
                    // Retorna os dados atualizados de fatura (OS DADOS FORAM ALTERADOS EM AVISO DE DEBITO)
                    GenericDAO<FaturaONP> ObjFatura = new GenericDAO<FaturaONP>();
                    fatura = GetFatura(quant);

                    // Insere os dados de serviço
                    new GenericDAO<FaturasAvisoONP>().InsertFaturaAviso(faturaAviso, fatura);

                    // Seta a carga
                    this.InsereTabelaCarga("ONP_FATURAS_AVISO");
                }
            }
            catch (Exception ex)
            {
                LogErroFlow.SetErro(ex, "ONP_FATURAS_AVISO", "I");
                throw ex;
            }
            return fatura.Length;
        }

        /// <summary>
        /// Metodo exclusivo para inserir a referencia pendente
        /// </summary>
        /// <param name="faturaAviso">array de dados de referencia pendnete</param>
        /// <param name="quant">quantidade de registros de referencia pendnete</param>
        /// <returns>quantidade de registros de fatura atualizados</returns>
        public int ReferenciaPendente(ReferenciaPendenteONP[] referenciaPendente, int quant)
        {
            FaturaONP[] fatura = new FaturaONP[0];

            try
            {
                if (referenciaPendente.Count() > 0)
                {
                    // Retorna os dados atualizados de fatura (OS DADOS FORAM ALTERADOS EM AVISO DE DEBITO)
                    GenericDAO<FaturaONP> ObjFatura = new GenericDAO<FaturaONP>();
                    fatura = GetFatura(quant);

                    // Insere os dados de serviço
                    new GenericDAO<ReferenciaPendenteONP>().InsertReferenciaPendente(referenciaPendente, fatura);
                    
                    // Seta a carga
                    this.InsereTabelaCarga("ONP_REFERENCIA_PENDENTE");
                }
            }
            catch (Exception ex)
            {
                LogErroFlow.SetErro(ex, "ONP_REFERENCIA_PENDENTE", "I");
                throw ex;
            }
            return fatura.Length;
        }

    }
}
