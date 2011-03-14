using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Data.BFL;
using Data.Model;
using Data.DAL;
using Data.Helper;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace SANEDWebService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod(Description = "Retorna lista dados de movimento categoria")]
        public string testar(int grupo,int rota)
        {
            string result = "";
            try
            {
                new MatriculaDAO().Lista(6, DateTime.Now, 13, 13);
                //result = new MovimentoDAO().Lista2(6, DateTime.Now, 13, 13,1);
                //new GeraBanco().Import();
                //List<MovimentoCategoriaONP> lst = MovimentoCategoriaFlow.ListaMovimentoCategoria(grupo, DateTime.Now, rota, rota);
                //List<MovimentoTaxaONP> lst2 = new MovimentoTaxaDAO().Lista(grupo, DateTime.Now, rota, rota);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        #region Metodos de controle e verificacao

        /*
        * Metodos de controle e verificacao
        * 
        */

        /// <summary>
        /// Testa o banco de dados
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "Testa a conecxao com o banco de dados")]
        public bool teste()
        {
            try
            {
                return Data.Test.Connection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Retorna o tempo de ciclo de sincronização automatica.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [WebMethod(Description = "Retorna do tempo de ciclo de sincronização")]
        public string TimeSyncAutomatic()
        {
            string time = "";
            try
            {
                //Instancio a classe InformacoesAmbiente
                InformacoesAmbiente objInfo = new InformacoesAmbiente();

                //para recuperar os dados da seção ConfigAmbiente que foi criada no Web.Config
                objInfo = (InformacoesAmbiente)ConfigurationManager.GetSection("ConfigAmbiente");
                time = objInfo.intervaloSinc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return time;
        }

        /// <summary>
        ///  Exibe a versão do programa
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "Exibe a versão do programa")]
        public string ExibeVersao()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        ///  Verifica a descarga dos dados
        ///  </summary>
        /// <param name="grupo">grupo</param>
        /// <param name="rota">rota</param>
        /// <param name="referencia">data referencia</param>
        /// <param name="tipo">tipo da validação: 
        ///                     -ROTEIRO
        ///                     -LEITURA
        ///                     -ATENDIMENTO
        /// </param>
        /// <returns>Quatidade de registros</returns>
        [WebMethod(Description = "Verifica a descarga dos dados")]
        public int ValidaCarga(int grupo, int rota, DateTime referencia, string tipo)
        {
            int quantidade = 0;
            referencia = new DateTime(referencia.Year, referencia.Month, 01);
            
            switch (tipo)
            {
                case "LEITURA":
                    {
                        quantidade = VoltaLeituraFlow.VerificaCarga(grupo, rota, referencia);
                        break;
                    }
                case "ROTEIRO":
                    {
                        quantidade = VoltaRoteiroFlow.VerificaCarga(grupo, rota, referencia);
                        break;
                    }
                case "ATENDIMENTO":
                    {
                        quantidade = VoltaLeituraFlow.VerificaCarga(grupo, rota, referencia);
                        break;
                    }
            }
            return quantidade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rota"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>'
        [WebMethod(Description = "Atualiza distribuição para descarga")]
        public void AtualizaDistribuicaoDescarga(int grupo, int usuario, int rota)
        {
            DistribuicaoFlow.AtualizaDistribuicaoDescarga(grupo, usuario, rota);
        }

        /// <summary>
        ///  Atualiza as distribuições
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="usuario"></param>
        /// <param name="rota"></param>
        [WebMethod(Description = "Atualiza distribuição para carga")]
        public void AtualizaDistribuicao(int grupo, int usuario, int rota)
        {
            DistribuicaoFlow.AtualizaDistribuicao(grupo, usuario, rota);
        }

        /// <summary>
        ///  Autenticar o usuario administrador 
        /// </summary>
        /// <param name="usuario">codigo do administrador</param>
        /// <param name="senha">senha do administrador</param>
        /// <returns></returns>
        [WebMethod(Description = "Autentica o usuario")]
        public bool AutenticaUsusario(string login, string senha, Identificacao identificacao)
        {
            bool valido = false;
            try
            {
                //Instancio a classe InformacoesAmbiente
                InformacoesAmbiente objInfo = new InformacoesAmbiente();

                //Faço um Cast(conversão) em meu objeto instanciado e uso o método GetSection
                //para recuperar os dados da seção ConfigAmbiente que foi criada no Web.Config
                objInfo = (InformacoesAmbiente)ConfigurationManager.GetSection("ConfigAmbiente");

                if (objInfo.usuario == login && objInfo.senha == senha)
                {
                    valido = true;

                    if (!ColetorFlow.CheckPdaExist(identificacao.coletor))
                    {
                        ColetorFlow.Insert(new Coletor(identificacao.coletor));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return valido;
        }

        /// <summary>
        ///  Metodo para autenticar agente
        /// </summary>
        /// <param name="login">codigo do agente</param>
        /// <param name="senha">senha do agente</param>
        /// <returns></returns>
        [WebMethod(Description = "Autentica o Agente")]
        public bool AutenticaAgent(string login, string senha)
        {   
            try
            {
                return AgenteFlow.Autenticar(login, senha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  Metodo informativo das configurações de ambiente
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [WebMethod(Description = "Exibe as configurações de ambiente")]
        public string ExibeConfiguracaoAmbiente()
        {
            string config = "";
            try
            {
                //Instancio a classe InformacoesAmbiente
                InformacoesAmbiente objInfo = new InformacoesAmbiente();

                //Faço um Cast(conversão) em meu objeto instanciado e uso o método GetSection
                //para recuperar os dados da seção ConfigAmbiente que foi criada no Web.Config
                objInfo = (InformacoesAmbiente)ConfigurationManager.GetSection("ConfigAmbiente");
                config = "usuario:" + objInfo.usuario + "- senha:" + objInfo.senha + "- intervalo de sincronização:" + objInfo.intervaloSinc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return config;
        }

        #endregion

        #region Metodos utilizados na carga

        /*
        * Metodos utilizados na carga
        * 
        */

        /// <summary>
        ///  Retorna o setor pertencente
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        [WebMethod(Description = "Retorna o setor")]
        public int RetornaSetor(int grupo, int rotaInicial, int rotaFinal)
        {
            return GrupoFlow.RetornaSetor(grupo, rotaInicial, rotaFinal);
        }

        /// <summary>
        /// Retorna o grupo
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [WebMethod(Description = "Retorna o grupo e a rota do agente")]
        public List<Distribuicao> Distribuicao(int idUsuario, string senha, Identificacao identificacao)
        {
            try
            {
                List<Distribuicao> lst = DistribuicaoFlow.RetornaGrupoRota(idUsuario, senha);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_DISTRIBUICAO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "IDA_DISTRIBUICAO", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Retorna uma lista de agentes
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        [WebMethod(Description = "Retorna lista de agentes")]
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
        [WebMethod(Description = "Retorna lista com os dados da categoria")]
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
        [WebMethod(Description = "Retorna lista com os avisos de debito")]
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
        [WebMethod(Description = "Retorna lista os dados de fatura")]
        public List<FaturaONP> ListaFatura(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, Identificacao identificacao,int pagina)
        {
            try
            {
                List<FaturaONP> lst = FaturaFlow.ListaFatura(grupo, referencia, rotaInicial, rotaFinal,pagina);
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
        [WebMethod(Description = "Retorna lista os dados de servico fatura")]
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
        [WebMethod(Description = "Retorna lista os dados de serviço")]
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
        [WebMethod(Description = "Retorna lista os dados de serviço")]
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
        [WebMethod(Description = "Retorna lista grupo")]
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
        [WebMethod(Description = "Retorna lista os dados de Hidrometro")]
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
        [WebMethod(Description = "Retorna lista de logradouros")]
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
        [WebMethod(Description = "Retorna lista de matricula diadema")]
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
        [WebMethod(Description = "Retorna lista de dados de Referencia Pendente")]
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
        [WebMethod(Description = "Retorna lista de matricula")]
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
        [WebMethod(Description = "Retorna lista de mensagem movimento")]
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

        [WebMethod(Description = "Retorna lista dados de movimento")]
        public List<MovimentoONP> ListaMovimento(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, int agente, Identificacao identificacao,int pagina)
        {
            try
            {
                List<MovimentoONP> lst = MovimentoFlow.ListaMovimento(grupo, referencia, rotaInicial, rotaFinal, agente,pagina);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MOVIMENTO", null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_MOVIMENTO", ex.Message);
                throw ex;
            }
        }

        [WebMethod(Description = "Retorna lista dados de movimento categoria")]
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

        [WebMethod(Description = "Retorna lista dados de movimento taxa")]
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

        [WebMethod(Description = "Retorna lista de qualidade da agua")]
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

        [WebMethod(Description = "Retorna lista de roteiros")]
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

        [WebMethod(Description = "Retorna lista as faixas taxas")]
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

        [WebMethod(Description = "Retorna lista as taxas")]
        public List<TaxaTarifaONP> ListaTaxaTarifa(int grupo, Identificacao identificacao)
        {
            try
            {
                List<TaxaTarifaONP> lst = TaxaTarifaFlow.ListaTaxa(grupo);
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_TAXA_TARIFA",null);

                return lst;
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "D", "ONP_TAXA_TARIFA", ex.Message);
                throw ex;
            }
        }

        [WebMethod(Description = "Retorna lista de grupo fatura")]
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

        [WebMethod(Description = "Retorna lista de dados de matricula carga")]
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

        [WebMethod(Description = "Retorna lista de dados de Faturas Aviso")]
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

        [WebMethod(Description = "Retorna lista de dados de Historico")]
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

        [WebMethod(Description = "Retorna lista de dados de Categoria")]
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

        [WebMethod(Description = "Retorna lista de dados de Desconto diadema")]
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

        [WebMethod(Description = "Retorna lista de dados de Imposto diadema")]
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

        [WebMethod(Description = "Retorna lista de dados de Localizacao hidrometro")]
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

        [WebMethod(Description = "Retorna lista de dados de ocorrencia")]
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

        [WebMethod(Description = "Retorna lista de dados de Parametro")]
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

        [WebMethod(Description = "Retorna lista de dados de Parametro retencao")]
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

        [WebMethod(Description = "Retorna lista de dados de taxa")]
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

        [WebMethod(Description = "Retorna lista de dados de tipo entrega")]
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

        [WebMethod(Description = "Retorna lista de dados de tipo entrega")]
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

        #endregion

        #region Metodos utilizados na descarga

        /*
        * Metodos utilizados na descarga
        * 
        */


        /// <summary>
        ///  Insere em volta alteracao
        /// </summary>
        /// <param name="alteracao"></param>
        [WebMethod(Description = "Insere dados em volta alteração")]
        public void InsertVoltaAlteracao(VoltaAlteracao alteracao, Identificacao identificacao)
        {
            try
            {
                VoltaAlteracaoFlow.Insert(alteracao);
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_ALTERACAO", null);
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_ALTERACAO", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Insere em volta leitura
        /// </summary>
        /// <param name="Leitura"></param>
        [WebMethod(Description = "Insere dados em Volta Leitura")]
        public void InsertVoltaLeitura(VoltaLeitura Leitura, Identificacao identificacao)
        {
            try
            {
                VoltaLeituraFlow.Insert(Leitura);
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_LEITURA", null);
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_LEITURA", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Insere em volta leitura
        /// </summary>
        /// <param name="Leitura"></param>
        [WebMethod(Description = "Insere uma lista de dados em Volta Leitura")]
        public void InsertListaVoltaLeitura(VoltaLeitura[] Leitura, Identificacao identificacao)
        {
            try
            {
                List<VoltaLeitura> listaLeitura = new List<VoltaLeitura>(Leitura);
                VoltaLeituraFlow.InsertList(listaLeitura);
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_LEITURA", null);
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_LEITURA", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Insere em volta de log de atendimento
        /// </summary>
        /// <param name="Grupo"></param>
        /// <param name="CDC"></param>
        /// <param name="Tipo"></param>
        /// <param name="Referencia"></param>
        /// <param name="Data_Emissao"></param>
        /// <param name="Operador"></param>
        [WebMethod(Description = "Insere dados em Volta Log Atendimento")]
        public void InsertVoltaLogAtendimento(VoltaLogAtendimento logAtendimento, Identificacao identificacao)
        {
            try
            {
                VoltaLogAtendimentoFlow.Insert(logAtendimento);
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_LOG_ATENDIMENTO", null);
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_LOG_ATENDIMENTO", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Insere dados de novo registro
        /// </summary>
        /// <param name="Grupo"></param>
        /// <param name="Rota"></param>
        /// <param name="Complemento"></param>
        /// <param name="Medidor"></param>
        /// <param name="Nome"></param>
        /// <param name="OBS"></param>
        /// <param name="referencia"></param>
        /// <param name="logradouro"></param>
        /// <param name="numero"></param>
        [WebMethod(Description = "Insere dados em Volta Novo Registro")]
        public void InsertVoltaNovoRegistro(VoltaNovoRegistro novoRegistro, Identificacao identificacao)
        {
            try
            {
                VoltaNovoRegistroFlow.Insert(novoRegistro);
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_NOVO_REGISTRO", null);
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_NOVO_REGISTRO", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Insere dados de volta roteiro
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="Grupo"></param>
        /// <param name="Rota"></param>
        /// <param name="Data_Inicial"></param>
        /// <param name="Data_Final"></param>
        /// <param name="Data_Envio"></param>
        /// <param name="Data_Processamento"></param>
        /// <param name="Aparelho"></param>
        /// <param name="Data_Problema"></param>
        /// <param name="Chuva"></param>
        [WebMethod(Description = "Insere dados em volta roteiro")]
        public void InsertVoltaRoteiro(VoltaRoteiro roteiro, Identificacao identificacao)
        {
            try
            {
                VoltaRoteiroFlow.Insert(roteiro);
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_ROTEIRO", null);
            }
            catch (Exception ex)
            {
                SetLogSync(identificacao.coletor, identificacao.usuario, "U", "VOLTA_ROTEIRO", ex.Message);
                throw ex;
            }
        }

        #endregion

        #region metodos não impleemntados

        /*
         * Metodos adicionais não implementados
         * 
         */
        [WebMethod(Description = "Retorna lista de dados de Utilizacao Ligacão")]
        public List<UtilizacaoLigacaoONP> ListaUtilizacaoLigacao()
        {
            return UtilizacaoLigacaoFlow.ListaUtilizacaoLigacao();
        }

        [WebMethod(Description = "Retorna lista de dados de volta alteração")]
        public List<VoltaAlteracao> ListaVoltaAlteracao()
        {
            return VoltaAlteracaoFlow.Lista();
        }

        [WebMethod(Description = "Retorna lista de dados de Volta Leitura")]
        public List<VoltaLeitura> ListaVoltaLeitura()
        {
            return VoltaLeituraFlow.Lista();
        }

        [WebMethod(Description = "Retorna lista de dados de Volta Log Atendimento")]
        public List<VoltaLogAtendimento> ListaVoltaLogAtendimento()
        {
            return VoltaLogAtendimentoFlow.Lista();
        }

        [WebMethod(Description = "Retorna lista de dados de Volta Novo Registro")]
        public List<VoltaNovoRegistro> ListaVoltaNovoRegistro()
        {
            return VoltaNovoRegistroFlow.Lista();
        }

        [WebMethod(Description = "Retorna lista de dados de volta alteração")]
        public List<VoltaRoteiro> ListaVoltaRoteiro()
        {
            return VoltaRoteiroFlow.Lista();
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
