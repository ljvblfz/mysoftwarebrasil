using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeraBase.Model;
using GeraBase.BFL;

namespace GeraBase
{
    public class DataBase
    {
        #region Metodos utilizados na carga

        /*
        * Metodos utilizados na carga
        * 
        */

        /// <summary>
        /// Retorna uma lista de agentes
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<AgenteONP> ListaAgente(int grupo, Identificacao identificacao)
        {
            try
            {
                List<AgenteONP> lst = AgenteFlow.ListaAgente(grupo);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_AGENTE", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_AGENTE", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna as Categorias cadastradas
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<FaturaCategoriaONP> ListaFaturaCategoria(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<FaturaCategoriaONP> lst = FaturaCategoriaFlow.ListaFaturaCategoria(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_FATURA_CATEGORIA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_FATURA_CATEGORIA", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna os avisos de debito
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<AvisoDebito> RetornaAvisoDebito(int grupo, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<AvisoDebito> lst = AvisoDebitoFlow.RetornaAvisoDebito(grupo, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_AVISO_DEBITO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_AVISO_DEBITO", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna uma lista com as faturas
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<FaturaONP> ListaFatura(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao, int pagina)
        {
            try
            {
                List<FaturaONP> lst = FaturaFlow.ListaFatura(grupo, referencia, rotaInicial, rotaFinal, pagina);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_FATURA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_FATURA", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna lista os dados de servico fatura
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<ServicoFaturaONP> ListaServicoFatura(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<ServicoFaturaONP> lst = ServicoFaturaFlow.Lista(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_SERVICO_FATURA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_SERVICO_FATURA", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna lista os dados de fatura serviço
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<FaturaServicoONP> ListaFaturaServico(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<FaturaServicoONP> lst = FaturaServicoFlow.ListaFaturaServico(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "FaturaServicoONP(Model)", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "FaturaServicoONP(Model)", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna lista os dados de fatura taxa
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<FaturaTaxaONP> ListaFaturaTaxa(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<FaturaTaxaONP> lst = FaturaTaxaFlow.ListaFaturaTaxa(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_FATURA_TAXA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_FATURA_TAXA", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna lista grupo
        /// </summary>
        /// <returns></returns>
        public List<GrupoONP> ListaGrupo(Identificacao identificacao)
        {
            try
            {
                List<GrupoONP> lst = GrupoFlow.ListaGrupo();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_GRUPOS", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_GRUPOS", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna lista os dados de Hidrometro
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<HidrometroONP> ListaHidrometro(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<HidrometroONP> lst = HidrometroFlow.ListaHidrometro(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_HIDROMETRO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_HIDROMETRO", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna lista de logradouros
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<LogradouroONP> ListaLogradouro(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<LogradouroONP> lst = LogradouroFlow.ListaLogradouro(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_LOGRADOURO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_LOGRADOURO", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna lista de matricula diadema
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<MatriculaDiademaONP> ListaMatriculaDiadema(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<MatriculaDiademaONP> lst = MatriculaDiademaFlow.ListaMatriculaDiadema(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MATRICULA_DIADEMA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MATRICULA_DIADEMA", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna os dados de referencia pendente
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<ReferenciaPendenteONP> ListaReferenciaPendente(int grupo, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<ReferenciaPendenteONP> lst = ReferenciaPendenteFlow.ListaReferenciaPendente(grupo, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_REFERENCIA_PENDENTE", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_REFERENCIA_PENDENTE", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna uma lista de matricula
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<MatriculaONP> ListaMatricula(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<MatriculaONP> lst = MatriculaFlow.ListaMatricula(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MATRICULA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MATRICULA", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna uma lista de mensagem movimento
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public List<MensagemMovimentoONP> ListaMensagemMovimento(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<MensagemMovimentoONP> lst = MensagemMovimentoFlow.ListaMensagemMovimento(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MENSAGEM_MOVIMENTO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MENSAGEM_MOVIMENTO", ex.Message);
                throw ex;
            }
        }

        
        public List<MovimentoONP> ListaMovimento(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, int agente, Identificacao identificacao, int pagina)
        {
            try
            {
                List<MovimentoONP> lst = MovimentoFlow.ListaMovimento(grupo, referencia, rotaInicial, rotaFinal, agente, pagina);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MOVIMENTO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MOVIMENTO", ex.Message);
                throw ex;
            }
        }

        
        public List<MovimentoCategoriaONP> ListaMovimentoCategoria(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<MovimentoCategoriaONP> lst = MovimentoCategoriaFlow.ListaMovimentoCategoria(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MOVIMENTO_CATEGORIA", null);
                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MOVIMENTO_CATEGORIA", ex.Message);
                throw ex;
            }
        }

        
        public List<MovimentoTaxaONP> ListaMovimentoTaxa(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<MovimentoTaxaONP> lst = MovimentoTaxaFlow.ListaMovimentoTaxa(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MOVIMENTO_TAXA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MOVIMENTO_TAXA", ex.Message);
                throw ex;
            }
        }

        
        public List<QualidadeAguaONP> ListaQualidadeAgua(int grupo, Identificacao identificacao)
        {
            try
            {
                List<QualidadeAguaONP> lst = QualidadeAguaFlow.ListaQualidadeAgua(grupo);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_QUALIDADE_AGUA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_QUALIDADE_AGUA", ex.Message);
                throw ex;
            }
        }

        
        public List<RoteiroONP> ListaRoteiro(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<RoteiroONP> lst = RoteiroFlow.ListaRoteiro(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_ROTEIRO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_ROTEIRO", ex.Message);
                throw ex;
            }
        }

        
        public List<TaxaTarifaFaixaONP> ListaTaxaTarifaFaixa(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<TaxaTarifaFaixaONP> lst = TaxaTarifaFaixaFlow.ListaTaxaTarifaFaixa(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_TAXA_TARIFA_FAIXA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_TAXA_TARIFA_FAIXA", ex.Message);
                throw ex;
            }
        }

        
        public List<TaxaTarifaONP> ListaTaxaTarifa(int grupo, Identificacao identificacao)
        {
            try
            {
                List<TaxaTarifaONP> lst = TaxaTarifaFlow.ListaTaxa(grupo);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_TAXA_TARIFA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_TAXA_TARIFA", ex.Message);
                throw ex;
            }
        }

        
        public List<GrupoFaturaONP> ListaGrupoFatura(int grupo, Identificacao identificacao)
        {
            try
            {
                List<GrupoFaturaONP> lst = GrupoFaturaFlow.ListaGrupoFatura(grupo);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_GRUPO_FATURA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_GRUPO_FATURA", ex.Message);
                throw ex;
            }
        }

        
        public List<MatriculaCargaONP> ListaMatriculaCarga(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<MatriculaCargaONP> lst = MatriculaCargaFlow.ListaMatriculaCarga(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MATRICULAS_CARGA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MATRICULAS_CARGA", ex.Message);
                throw ex;
            }
        }

        
        public List<FaturasAvisoONP> ListaFaturasAviso(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<FaturasAvisoONP> lst = FaturasAvisoFlow.ListaFaturasAviso(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_FATURAS_AVISO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_FATURAS_AVISO", ex.Message);
                throw ex;
            }
        }

        
        public List<HistoricoONP> ListaHistorico(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao)
        {
            try
            {
                List<HistoricoONP> lst = HistoricoFlow.Lista(grupo, referencia, rotaInicial, rotaFinal);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_HISTORICO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_HISTORICO", ex.Message);
                throw ex;
            }
        }

        
        public List<CategoriaONP> ListaCategoria(Identificacao identificacao)
        {
            try
            {
                List<CategoriaONP> lst = CategoriaFlow.ListaCategoria();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ida_categoria", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ida_categoria", ex.Message);
                throw ex;
            }
        }

        
        public List<DescontoDiademaONP> ListaDescontoDiadema(Identificacao identificacao)
        {
            try
            {
                List<DescontoDiademaONP> lst = DescontoDiademaFlow.ListaDescontoDiadema();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_DESCONTO_DIADEMA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_DESCONTO_DIADEMA", ex.Message);
                throw ex;
            }
        }

        
        public List<ImpostoDiademaONP> ListaImpostoDiadema(Identificacao identificacao)
        {
            try
            {
                List<ImpostoDiademaONP> lst = ImpostoDiademaFlow.ListaImpostoDiadema();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_IMPOSTO_DIADEMA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_IMPOSTO_DIADEMA", ex.Message);
                throw ex;
            }
        }

        
        public List<LocalizacaoHidrometroONP> ListaLocalizacaoHidrometro(Identificacao identificacao)
        {
            try
            {
                List<LocalizacaoHidrometroONP> lst = LocalizacaoHidrometroFlow.ListaLocalizacaoHidrometro();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_LOCALIZACAO_HIDROMETRO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_LOCALIZACAO_HIDROMETRO", ex.Message);
                throw ex;
            }
        }

        
        public List<OcorrenciaONP> ListaOcorrencia(Identificacao identificacao)
        {
            try
            {
                List<OcorrenciaONP> lst = OcorrenciaFlow.Lista();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_LOCALIZACAO_HIDROMETRO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_LOCALIZACAO_HIDROMETRO", ex.Message);
                throw ex;
            }
        }

        
        public List<ParametroONP> ListaParametro(Identificacao identificacao)
        {
            try
            {
                List<ParametroONP> lst = ParametroFlow.ListaParametro();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_PARAMETRO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_PARAMETRO", ex.Message);
                throw ex;
            }
        }

        
        public List<ParametroRentencaoONP> ListaParametroRentencao(Identificacao identificacao)
        {
            try
            {
                List<ParametroRentencaoONP> lst = ParametroRentencaoFlow.ListaParametroRentencao();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_PARAMETRO_RETENCAO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_PARAMETRO_RETENCAO", ex.Message);
                throw ex;
            }
        }

        
        public List<TaxaONP> ListaTaxa(Identificacao identificacao)
        {
            try
            {
                List<TaxaONP> lst = TaxaFlow.ListaTaxa();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_TAXA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_TAXA", ex.Message);
                throw ex;
            }
        }

        
        public List<TipoEntregaONP> ListaTipoEntrega(Identificacao identificacao)
        {
            try
            {
                List<TipoEntregaONP> lst = TipoEntregaFlow.ListaTipoEntrega();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_TIPO_ENTREGA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_TIPO_ENTREGA", ex.Message);
                throw ex;
            }
        }

        
        public List<TabelaCargaONP> ListaTabelasCarga(Identificacao identificacao)
        {
            try
            {
                List<TabelaCargaONP> lst = TabelaCargaONPFlow.Lista();
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_TABELAS_CARGA", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_TABELAS_CARGA", ex.Message);
                throw ex;
            }
        }


        public List<UtilizacaoLigacaoONP> ListaUtilizacaoLigacao()
        {
            return UtilizacaoLigacaoFlow.ListaUtilizacaoLigacao();
        }

        #endregion


        //grava log de sincronismo: numero do coletor, id do funcionario, tipo de transferencia de dados(Upload ou Download), nome da tabela. 
        private void SetLogSync(string coletor, long funcionario, string tipoTransfer, string tabela, string obs)
        {
            LogSyncServer log = new LogSyncServer();

            log.Coletor = coletor;
            log.DataSync = DateTime.Now;
            log.Funcionario = funcionario;
            log.TipoTranfer = tipoTransfer;
            log.Tabela = tabela;
            log.Obs = obs;

            LogSyncServerFlow.Insert(log);
        }
    }
}
