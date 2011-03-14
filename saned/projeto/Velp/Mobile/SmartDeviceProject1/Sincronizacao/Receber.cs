using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DeviceProject.Config;
using DeviceProject.referencia;
using DeviceProject.DATA;
using System.Data.SqlServerCe;
using DeviceProject.DATA.dataSaned.Flow;
using DeviceProject.Util;
using System.Reflection;
using System.Globalization;

namespace DeviceProject.Sincronizacao
{
    /// <summary>
    ///  Classe responsavel por receber os dados do webService
    /// </summary>
    public class Receber
    {
        #region Variaveis Locais

        /// <summary>
        /// Objeto de comunicação com web server
        /// </summary>
        public referencia.Service1 _webService = new referencia.Service1();

        /// <summary>
        /// Objeto do SQLCE
        /// </summary>
        public SqlCeCommand cmd;

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
        public DateTime? referencia;

        /// <summary>
        ///  Numero de tentativas para a carga
        /// </summary>
        public int numeroTentativasCarga = 0;

        /// <summary>
        ///  Usuario corrente
        /// </summary>
        public static referencia.Identificacao UserPdaCurrent = new Identificacao();

        /// <summary>
        ///  Variavel para recuperar a quantidade de dados de fatura
        /// </summary>
        public int indiceFatura = 0;

        #endregion

        /// <summary>
        /// Contrutor
        /// </summary>
        public Receber()
        {
            _webService.Url = DeviceProject.Config.ConfiguracaoPDA.CurrentInstance.WebServiceAddress;

            UserPdaCurrent.coletor = ConfiguracaoPDA.GetDeviceID();
            UserPdaCurrent.usuario = (string.IsNullOrEmpty(ConfiguracaoPDA.CurrentInstance.Username)) ? 0 : int.Parse(ConfiguracaoPDA.CurrentInstance.Username);
            GetDistribuicao();
            Limpeza();
        }

        /// <summary>
        ///  Limpa os dados dos banco de dados
        /// </summary>
        public void Limpeza()
        {
            new GenericDAO<Boolean>().LimpaBanco();
            LogSyncFlow.DeleteAll();
        }

        /// <summary>
        /// Carrega os dados da distribuição
        /// </summary>
        private void GetDistribuicao()
        {
            Distribuicao[] distribuicao;
            try
            {
                object[] parametro =  new object[] {
                                                        (String.IsNullOrEmpty(ConfiguracaoPDA.CurrentInstance.Username)? 0 : int.Parse(ConfiguracaoPDA.CurrentInstance.Username))
                                                        ,ConfiguracaoPDA.CurrentInstance.Password
                                                        , UserPdaCurrent 
                                                    };
                
                // Retorna os dados do web service
                distribuicao = (Distribuicao[])RetornaDados("Distribuicao", parametro);

                if (distribuicao.Count() > 0)
                {
                    grupo = distribuicao[0].Grupo;
                    rota = distribuicao[0].Rota;
                    referencia = distribuicao[0].Referencia;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza a tabela de distribuição no web_server macando como enviado
        /// </summary>
        public void AtualizaDistribuicao()
        {
            try
            {
                // Parametros
                object[] parametros = new object[] {grupo, UserPdaCurrent.usuario ,rota };
                
                // Retorna os dados do web service
                RetornaDados("AtualizaDistribuicao", parametros);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        /// <summary>
        ///  Metodo generico para consumir o we service
        /// </summary>
        /// <param name="metodo">nome do metodo a ser chamado</param>
        /// <param name="paramtros">array de parametros do metodo</param>
        /// <returns>um objeto de dados retornado do web service</returns>
        public object RetornaDados(string metodo, object[] paramtros)
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
                    LogErroFlow.SetErro(ex, metodo, "D");
                    goto tentativa;
                }
                else
                {
                    LogErroFlow.SetErro(ex, metodo, "D");
                    throw ex;
                }
            }
            return retorno;
        }

        /// <summary>
        ///  Metodo que retorna os dados atraves de paginação
        /// </summary>
        /// <param name="metodo">Nome do metodo</param>
        /// <param name="paramtros">Parametro recebidos</param>
        /// <returns>Um objeto do web service</returns>
        public object[] RetornaDadosPaginacao(string metodo, object[] paramtros)
        {
            // Declaração
            List<object> listResult = new List<object>();
            object[] arrayResult = null;
            int numeroPagina = 1;

            // Parametros
            List<object> parametros = new List<object>(paramtros);
            parametros.Add(numeroPagina);

            do// Loop da paginação
            {
               
                // Retorna os dados do web service
                arrayResult = (object[])RetornaDados(metodo, parametros.ToArray());
                listResult.AddRange(arrayResult);

                // Proxima pagina
                numeroPagina++;
                parametros[parametros.Count - 1] = numeroPagina;

            } while (arrayResult.Length >= 49);

            // Converter os dados
            return listResult.ToArray();
        }

        /// <summary>
        /// Retorna os dados de categoria
        /// </summary>
        public void Categoria()
        {
            CategoriaONP[] categoria;
            try
            {
                // Parametros
                object[] parametros = new object[] { UserPdaCurrent };
                
                // Retorna os dados do web service
                categoria = (CategoriaONP[])RetornaDados("ListaCategoria", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<CategoriaONP>().Gravar("ONP_CATEGORIA" , categoria,null);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de tipo entrega
        /// </summary>
        public void TipoEntrega()
        {
            TipoEntregaONP[] tipoEntrega;
            try
            {
                // Parametros
                object[] parametros = new object[] { UserPdaCurrent };
                
                // Retorna os dados do web service
                tipoEntrega = (TipoEntregaONP[])RetornaDados("ListaTipoEntrega", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<TipoEntregaONP>().Gravar("ONP_TIPO_ENTREGA", tipoEntrega,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de desconto diadema
        /// </summary>
        public void DescontoDiadema()
        {
            DescontoDiademaONP[] descontoDiadema;
            try
            {
                // Parametros
                object[] parametros = new object[] { UserPdaCurrent };
                
                // Retorna os dados do web service
                descontoDiadema = (DescontoDiademaONP[])RetornaDados("ListaDescontoDiadema", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<DescontoDiademaONP>().Gravar("ONP_DESCONTO_DIADEMA", descontoDiadema,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de imposto diadema
        /// </summary>
        public void ImpostoDiadema()
        {
            ImpostoDiademaONP[] impostoDiadema;
            try
            {
                // Parametros
                object[] parametros = new object[] { UserPdaCurrent };
                
                // Retorna os dados do web service
                impostoDiadema = (ImpostoDiademaONP[])RetornaDados("ListaImpostoDiadema", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<ImpostoDiademaONP>().Gravar("ONP_IMPOSTO_DIADEMA", impostoDiadema,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de localização hidrometro
        /// </summary>
        public void LocalizacaoHidrometro()
        {
            LocalizacaoHidrometroONP[] localizacaoHidrometro;
            try
            {
                // Parametros
                object[] parametros = new object[] { UserPdaCurrent };
                
                // Retorna os dados do web service
                localizacaoHidrometro = (LocalizacaoHidrometroONP[])RetornaDados("ListaLocalizacaoHidrometro", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<LocalizacaoHidrometroONP>().Gravar("ONP_LOCALIZACAO_HIDROMETRO", localizacaoHidrometro, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de ocorrencia
        /// </summary>
        public void Ocorrencia()
        {
            OcorrenciaONP[] ocorrencia;
            try
            {
                // Parametros
                object[] parametros = new object[] { UserPdaCurrent };
                
                // Retorna os dados do web service
                ocorrencia = (OcorrenciaONP[])RetornaDados("ListaOcorrencia", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<OcorrenciaONP>().Gravar("ONP_OCORRENCIA", ocorrencia, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de parametro
        /// </summary>
        public void Parametro() 
        {
            ParametroONP[] parametro;
            try
            {
                // Parametros
                object[] parametros = new object[] { UserPdaCurrent };
                
                // Retorna os dados do web service
                parametro = (ParametroONP[])RetornaDados("ListaParametro", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<ParametroONP>().Gravar("ONP_PARAMETRO", parametro, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de parametro retenção
        /// </summary>
        public void ParametroRetencao()
        {
            ParametroRentencaoONP[] parametroRetencao;
            try
            {
                // Parametros
                object[] parametros = new object[] { UserPdaCurrent };
                
                // Retorna os dados do web service
                parametroRetencao = (ParametroRentencaoONP[])RetornaDados("ListaParametroRentencao", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<ParametroRentencaoONP>().Gravar("ONP_PARAMETRO_RETENCAO", parametroRetencao, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de taxa
        /// </summary>
        public void Taxa()
        {
            TaxaONP[] taxa;
            try
            {
                // Parametros
                object[] parametros = new object[] { UserPdaCurrent };
                
                // Retorna os dados do web service
                taxa = (TaxaONP[])RetornaDados("ListaTaxa", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<TaxaONP>().Gravar("ONP_TAXA", taxa, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de agente
        /// </summary>
        public void Agente()
        {
            AgenteONP[] agentes;
            try
            {
                // Parametros
                object[] parametros = new object[] { grupo, UserPdaCurrent };
                
                // Retorna os dados do web service
                agentes = (AgenteONP[])RetornaDados("ListaAgente", parametros);

                // Percorre todos os agentes
                for (int i = 0; i < agentes.Count(); i++)
                {
                    //Marreta para Inserir uma senha (des_senha é NOT NULL)
                    if (agentes[i].des_senha == null)
                        agentes[i].des_senha = "";
                }

                // Insere os dados no banco do PDA
                new InsertCarga<AgenteONP>().Gravar("ONP_AGENTE", agentes, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de grupo fatura
        /// </summary>
        public void GrupoFatura()
        {
            GrupoFaturaONP[] grupoFatura;
            try
            {
                // Parametros
                object[] parametros = new object[] { grupo, UserPdaCurrent };
                
                // Retorna os dados do web service
                grupoFatura = (GrupoFaturaONP[])RetornaDados("ListaGrupoFatura", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<GrupoFaturaONP>().Gravar("ONP_GRUPO_FATURA", grupoFatura, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de matricula carga
        /// </summary>
        public void MatriculaCarga()
        {
            MatriculaCargaONP[] matriculaCarga;
            try
            {
                // Parametros
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };
                
                // Retorna os dados do web service
                matriculaCarga = (MatriculaCargaONP[])RetornaDados("ListaMatriculaCarga", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<MatriculaCargaONP>().Gravar("ONP_MATRICULAS_CARGA", matriculaCarga, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de movimento
        /// </summary>
        public void Movimento()
        {
            List<MovimentoONP> movimento = new List<MovimentoONP>();
            try
            {
                // Parametros
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent.usuario, UserPdaCurrent };

                // Retorna os dados do web service
                object[] dadosRetornados = RetornaDadosPaginacao("ListaMovimento", parametros);
                movimento = Convert<MovimentoONP>.convertObjectToModel(dadosRetornados);
                               
                // Insere os dados no banco do PDA
                new InsertCarga<MovimentoONP>().Gravar("ONP_MOVIMENTO", movimento.ToArray(), null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de qualizade da agua
        /// </summary>
        public void QualidadeAgua()
        {
            QualidadeAguaONP[] qualidadeAgua;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo,UserPdaCurrent };

                // Retorna os dados do web service
                qualidadeAgua = (QualidadeAguaONP[])RetornaDados("ListaQualidadeAgua", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<QualidadeAguaONP>().Gravar("ONP_QUALIDADE_AGUA", qualidadeAgua, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de roteiro
        /// </summary>
        public void Roteiro()
        {
            RoteiroONP[] roteiro;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo , referencia , rota , rota , UserPdaCurrent };

                // Retorna os dados do web service
                roteiro = (RoteiroONP[])RetornaDados("ListaRoteiro", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<RoteiroONP>().Gravar("ONP_ROTEIRO", roteiro, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de fatura
        /// </summary>
        public void Fatura()
        {
            List<FaturaONP> fatura = new List<FaturaONP>();
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                object[] dadosRetornados = RetornaDadosPaginacao("ListaFatura", parametros);
                fatura = Convert<FaturaONP>.convertObjectToModel(dadosRetornados);

                // Insere os dados no banco do PDA
                new InsertCarga<FaturaONP>().Gravar("ONP_FATURA", fatura.ToArray(), "seq_fatura");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de Aviso Debito
        /// </summary>
        public void AvisoDebito()
        {
            AvisoDebito[] avisoDebito;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                avisoDebito = (AvisoDebito[])RetornaDados("RetornaAvisoDebito", parametros);

                // Insere os dados no banco do PDA
                int indiceAUX = new InsertCarga<AvisoDebito>().AvisoDebito(avisoDebito, indiceFatura);
                indiceFatura = indiceAUX;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de fatura categoria
        /// </summary>
        public void FaturaCategoria()
        {
            FaturaCategoriaONP[] faturaCategoria;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                faturaCategoria = (FaturaCategoriaONP[])RetornaDados("ListaFaturaCategoria", parametros);

                // Insere os dados no banco do PDA
                int indiceAUX = new InsertCarga<FaturaCategoriaONP>().FaturaCategoria(faturaCategoria, indiceFatura);
                indiceFatura = indiceAUX;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de fatura aviso
        /// </summary>
        public void FaturaAviso()
        {
            FaturasAvisoONP[] faturaAviso;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                faturaAviso = (FaturasAvisoONP[])RetornaDados("ListaFaturasAviso", parametros);

                // Insere os dados no banco do PDA
                int indiceAUX = new InsertCarga<FaturasAvisoONP>().FaturaAviso(faturaAviso, indiceFatura);
                indiceFatura = indiceAUX;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de hidrometro
        /// </summary>
        public void Hidrometro()
        {
            HidrometroONP[] hidrometro;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                hidrometro = (HidrometroONP[])RetornaDados("ListaHidrometro", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<HidrometroONP>().Gravar("ONP_HIDROMETRO", hidrometro, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de historico
        /// </summary>
        public void Historico()
        {
            HistoricoONP[] historico;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                historico = (HistoricoONP[])RetornaDados("ListaHistorico", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<HistoricoONP>().Gravar("ONP_HISTORICO", historico, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de logradouro
        /// </summary>
        public void Logradouro()
        {
            LogradouroONP[] logradouro;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                logradouro = (LogradouroONP[])RetornaDados("ListaLogradouro", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<LogradouroONP>().Gravar("ONP_LOGRADOURO", logradouro, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de matricula
        /// </summary>
        public void Matricula()
        {
            MatriculaONP[] matricula;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                matricula = (MatriculaONP[])RetornaDados("ListaMatricula", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<MatriculaONP>().Gravar("ONP_MATRICULA", matricula, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de movimento categoria
        /// </summary>
        public void MovimentoCategoria()
        {
            MovimentoCategoriaONP[] movimentoCategoria;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                movimentoCategoria = (MovimentoCategoriaONP[])RetornaDados("ListaMovimentoCategoria", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<MovimentoCategoriaONP>().Gravar("ONP_MOVIMENTO_CATEGORIA", movimentoCategoria, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de movimento taxa
        /// </summary>
        public void MovimentoTaxa()
        {
            MovimentoTaxaONP[] movimentoTaxa;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                movimentoTaxa = (MovimentoTaxaONP[])RetornaDados("ListaMovimentoTaxa", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<MovimentoTaxaONP>().Gravar("ONP_MOVIMENTO_TAXA", movimentoTaxa, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de matricula diadema
        /// </summary>
        public void MatriculaDiadema()
        {
            MatriculaDiademaONP[] matriculaDiadema;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                matriculaDiadema = (MatriculaDiademaONP[])RetornaDados("ListaMatriculaDiadema", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<MatriculaDiademaONP>().Gravar("ONP_MATRICULA_DIADEMA", matriculaDiadema, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de mensagem movimento
        /// </summary>
        public void MensagemMovimento()
        {
            MensagemMovimentoONP[] mensagemMovimento;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                mensagemMovimento = (MensagemMovimentoONP[])RetornaDados("ListaMensagemMovimento", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<MensagemMovimentoONP>().Gravar("ONP_MENSAGEM_MOVIMENTO", mensagemMovimento, "seq_mensagem_movimento");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de taxa tarifa
        /// </summary>
        public void TaxaTarifa()
        {
            TaxaTarifaONP[] taxaTarifa;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, UserPdaCurrent };

                // Retorna os dados do web service
                taxaTarifa = (TaxaTarifaONP[])RetornaDados("ListaTaxaTarifa", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<TaxaTarifaONP>().Gravar("ONP_TAXA_TARIFA", taxaTarifa, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de referencia pendente
        /// </summary>
        public void ReferenciaPendente()
        {
            ReferenciaPendenteONP[] referenciaPendente;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                referenciaPendente = (ReferenciaPendenteONP[])RetornaDados("ListaReferenciaPendente", parametros);

                // Insere os dados no banco do PDA
                int indiceAUX = new InsertCarga<ReferenciaPendenteONP>().ReferenciaPendente(referenciaPendente, indiceFatura);
                indiceFatura = indiceAUX;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de taxa tarifa faixa
        /// </summary>
        public void TaxaTarifaFaixa()
        {
            TaxaTarifaFaixaONP[] taxaTarifaFaixa;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                taxaTarifaFaixa = (TaxaTarifaFaixaONP[])RetornaDados("ListaTaxaTarifaFaixa", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<TaxaTarifaFaixaONP>().Gravar("ONP_TAXA_TARIFA_FAIXA", taxaTarifaFaixa, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de Serviço fatura
        /// </summary>
        public void ServicoFatura()
        {
            ServicoFaturaONP[] servicoFatura;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { grupo, referencia, rota, rota, UserPdaCurrent };

                // Retorna os dados do web service
                servicoFatura = (ServicoFaturaONP[])RetornaDados("ListaServicoFatura", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<ServicoFaturaONP>().Gravar("ONP_SERVICO_FATURA", servicoFatura, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna os dados de utilização ligação
        /// </summary>
        public void UtilizacaoLigacao()
        {
            UtilizacaoLigacaoONP[] utilizacaoLigacao;
            try
            {
                // Parametros do metodo
                object[] parametros = new object[] { };

                // Retorna os dados do web service
                utilizacaoLigacao = (UtilizacaoLigacaoONP[])RetornaDados("ListaUtilizacaoLigacao", parametros);

                // Insere os dados no banco do PDA
                new InsertCarga<UtilizacaoLigacaoONP>().Gravar("ONP_UTILIZACAO_LIGACAO", utilizacaoLigacao, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
