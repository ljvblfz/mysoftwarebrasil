using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SPCadMobileDataWeb.Data.Model;
using SPCadMobileDataWeb.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace SPCad_WS
{
    /// <summary>
    /// Summary description for SPCadServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SPCadServices : System.Web.Services.WebService
    {

        #region Download

        [WebMethod]
        public DateTime getDateDBServer(Autenticantion auth)
        {
            return SingletonFlow.funcionarioFlow.GetServerDate();
        }

        [WebMethod]
        public List<Funcionario> GetListFuncionario(Autenticantion auth)
        {
            return SingletonFlow.funcionarioFlow.GetList();
        }

        [WebMethod]
        public List<Ocorrencia> GetListOcorrencia(Autenticantion auth)
        {
            return SingletonFlow.ocorrenciaFlow.GetList();
        }

        [WebMethod]
        public List<RamoAtividade> GetListRamoAtividade(Autenticantion auth)
        {
            return SingletonFlow.ramoAtividadeFlow.GetList();
        }

        [WebMethod]
        public List<CondicaoImovel> GetListCondicaoImovel(Autenticantion auth)
        {
            return SingletonFlow.condicaoImovelFlow.GetList();
        }

        [WebMethod]
        public List<TipoComplemento> GetListTipoComplemento(Autenticantion auth)
        {
            return SingletonFlow.tipoComplementoFlow.GetList();
        }

        [WebMethod]
        public List<LocalizacaoPadrao> GetListLocalizacaoPadrao(Autenticantion auth)
        {
            return SingletonFlow.localizacaoPadraoFlow.GetList();
        }

        [WebMethod]
        public List<TipoPadrao> GetListTipoPadrao(Autenticantion auth)
        {
            return SingletonFlow.tipoPadraoFlow.GetList();
        }

        [WebMethod]
        public List<FonteAlternativa> GetListFonteAlternativa(Autenticantion auth)
        {
            return SingletonFlow.fonteAlternativaFlow.GetList();
        }

        [WebMethod]
        public List<Distrito> GetListDistrito(Autenticantion auth)
        {
            return SingletonFlow.distritoFlow.GetList();
        }

        [WebMethod]
        public List<Rota> GetListRota(Autenticantion auth)
        {
            return SingletonFlow.rotaFlow.GetList();
        }

        [WebMethod]
        public List<Rota> GetListRotaLibQtdCad(Autenticantion auth)
        {
            int codFunc = SingletonFlow.funcionarioFlow.GetFuncionario(auth.User).Id;

            //Retorna rotas liberadas para o funcionario.
            return SingletonFlow.rotaFlow.GetListRotaLibQtdCad(codFunc, auth.parcial);
        }

        [WebMethod]
        public List<Rota> GetListRotaLiberada(Autenticantion auth)
        {
            int codFunc = SingletonFlow.funcionarioFlow.GetFuncionario(auth.User).Id;

            //Retorna rotas liberadas para o funcionario.
            return SingletonFlow.rotaFlow.GetListRotaLiberada(codFunc, auth.parcial);
        }

        [WebMethod]
        public List<Cadastro> GetListCadastro(Autenticantion auth, Rota rotLib)
        {
            int codFunc = SingletonFlow.funcionarioFlow.GetFuncionario(auth.User).Id;
            return SingletonFlow.cadastroFlow.GetList(rotLib.CodigoDistrito, rotLib.Setor, rotLib.CodigoRota, codFunc, auth.parcial);
        }

        [WebMethod]
        public List<HistoricoConsumo> GetListHistoricoConsumo(Autenticantion auth, Rota rotaLib)
        {
            int codFunc = SingletonFlow.funcionarioFlow.GetFuncionario(auth.User).Id;
            return SingletonFlow.historicoConsumoFlow.GetList(codFunc, auth.parcial, rotaLib);
        }

        #endregion Download

        #region Upload

        [WebMethod]
        public List<RespostaWS> SetListHistoricoConsumo(Autenticantion auth, List<HistoricoConsumo> contrib)
        {
            
            List<RespostaWS> saida = new List<RespostaWS>();
            foreach (HistoricoConsumo item in contrib)
            {
                RespostaWS resp = new RespostaWS();
                resp.idRecord = item.Id;
                try
                {
                    SingletonFlow.historicoConsumoFlow.InsertOrUpdate(item);
                }
                catch (Exception ex)
                {
                    resp.errorMsg = ex.Message;
                }
                saida.Add(resp);
            }
            return saida;
        }

        [WebMethod]
        public List<RespostaWS> SetListCadastro(Autenticantion auth, List<Cadastro> contrib)
        {
            List<RespostaWS> saida = new List<RespostaWS>();
            foreach (Cadastro item in contrib)
            {
                RespostaWS resp = new RespostaWS();
                resp.idRecord = item.Id;
                try
                {
                    SingletonFlow.cadastroFlow.InsertOrUpdate(item);
                }
                catch (Exception ex)
                {
                    resp.errorMsg = ex.Message;
                }
                saida.Add(resp);
            }
            return saida;
        }

        [WebMethod]
        public RespostaWS SetListFoto(Autenticantion auth, Foto foto, byte[] file)
        {
            RespostaWS resp = new RespostaWS();

            MemoryStream stream = new MemoryStream(file);

            // Cria a imagem
            Image image = Image.FromStream(stream);
            try
            {
                foto.DtMovimentacao = DateTime.Now;

                SingletonFlow.fotoFlow.InsertOrUpdate(foto);
                resp.aux = foto.nomFoto;

                ImageCodecInfo.GetImageDecoders();

                // Salva a imagem
                //image.Save(HttpContext.Current.Server.MapPath("_upload/JpegEncoder.jpg"));exemplo
                // TODO: Implementar servidor de imagem ou colocar configuração no appconfig
                string fotoPath = System.Configuration.ConfigurationManager.AppSettings.Get(0).ToString();
                image.Save(fotoPath + foto.nomFoto, ImageFormat.Jpeg);               
                
            }
            catch (Exception ex)
            {
                resp.errorMsg = ex.Message;
            }
            finally
            {
                image.Dispose();
                stream.Dispose();
            }

            return resp;
        }

        #endregion Upload

        [WebMethod]
        public void SetSituacaoCargaRota(Rota rota, Autenticantion auth, string situacao)
        {
            

            int codFunc = SingletonFlow.funcionarioFlow.GetFuncionario(auth.User).Id;

            SingletonFlow.distribuicaoFlow.UpdateSitCargaPDA(rota, codFunc, situacao);
        }

        [WebMethod]
        public List<Rota> GetRotasFinalizadas(List<Rota> listRota, Autenticantion auth)
        {
            

            List<Rota> lstRotaFinalizada = new List<Rota>();

            int codFunc = SingletonFlow.funcionarioFlow.GetFuncionario(auth.User).Id;

            foreach (Rota rota in listRota)
            {
                Rota finalizada = SingletonFlow.rotaFlow.GetRotasFinalizadas(rota, codFunc);
                if (finalizada != null)
                {
                    lstRotaFinalizada.Add(finalizada);
                }
            }

            return lstRotaFinalizada;
        }

        private void AutenticarUsuario(string strUsuario, string strSenha)
        {
            if (!SingletonFlow.funcionarioFlow.AutenticarUsuario(strUsuario, strSenha))
            {
                throw new Exception("Login ou senha incorretos");
            }
        }
    }
}
