using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WS_ltMbileData.Data.Model;
using WS_ltMbileData.Data.BFL;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using System.Security.Authentication;
using WS_ltMbileData.Data.RespostaWS;
using System.IO;


namespace WS_ltMobile
{
    /// <summary>
    /// Summary description for WS_ltMobile
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_ltMobile : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<LeituraWS> getLeituraWS(Autenticantion auth)
        {
            return LeituraFlow.getLeitura(auth.User);
        }

        [WebMethod]
        public void setLeituraConfirmada(string Usuario, string Condicao)
        {
            LeituraFlow.setLeituraConfirmada(Usuario, Condicao);
        }

        [WebMethod]
        public void setMensagemConfirmada(string Condicao)
        {
            MensagemFlow.setMensagemConfirmada(Condicao);
        }

        [WebMethod]
        public void setCorreioEletronicoConfirmado(string Usuario, string Condicao)
        {
            CorreioEletronicoFlow.setCorreioEletronicoConfirmado(Usuario, Condicao);
        }

        [WebMethod]
        public bool AutenticarUsuarioStr(Autenticantion auth)
        {
            return UsuarioFlow.AutenticarUsuario(auth.User, auth.Password);
        }

       /* [WebMethod]
        public bool AutenticarUsuario(Autenticantion auth)
        {
            return UsuarioFlow.AutenticarUsuario(auth.User, auth.Password);
        }*/

        [WebMethod]
        public DateTime getDateDBServer(Autenticantion auth)
        {
            AutenticarUsuario(auth.User, auth.Password);
            return LeituraFlow.GetServerDate();
        }

        [WebMethod]
        public List<CorreioEletronicoWS> getCorreioEletronico(Autenticantion auth)
        {
            return CorreioEletronicoFlow.getCorreioEletronico(auth.User);
        }


        [WebMethod]
        public List<FotoWS> getFoto(Autenticantion auth)
        {
            return FotoFlow.getFoto(auth.User);
        }



        [WebMethod]
        public List<MensagemWS> getMensagem(string Condicao)
        {
            return MensagemFlow.getMensagem(Condicao);
        }


        [WebMethod]
        public List<OcorrenciaWS> getOcorrencia()
        {
            return OcorrenciaFlow.getOcorrencia();
        }


        [WebMethod]
        public List<FuncionariosWS> getFuncionario(Autenticantion auth)
        {
            return UsuarioFlow.getFuncionario(auth.User);
        }

        [WebMethod]
        public List<ErroCorreioEletronicoWS> setCorreioEletronico(CorreioEletronicoWS[] correio)
        {
            List<ErroCorreioEletronicoWS> lstErroCorreioEletronico = new List<ErroCorreioEletronicoWS>();

            foreach (CorreioEletronicoWS c in correio)
            {                

                try
                {
                    CorreioEletronicoFlow.Insert(c);

                }
                catch 
                {
                    ErroCorreioEletronicoWS ErroCorreioEletronico = new ErroCorreioEletronicoWS();
                    ErroCorreioEletronico.ID_MSG = c.ID_MSG;
                    
                    lstErroCorreioEletronico.Add(ErroCorreioEletronico);
                }
            }
            return lstErroCorreioEletronico;
        }


        public System.Drawing.Image byteArrayToImage(byte[] img)
        {
            if (img == null || img.Length == 0)
                return null;

            MemoryStream ms = new MemoryStream(img, 0, img.Length);
            ms.Write(img, 0, img.Length);
            System.Drawing.Image imgImagen = System.Drawing.Image.FromStream(ms, true);
            

            return imgImagen;
        }
        
        [WebMethod]
        public ErroFotoWS setFoto(FotoWS Dadosfoto, byte[] ArquivoFoto)
        {

            ErroFotoWS ErroFoto = new ErroFotoWS();
            
                try
                {
                    byteArrayToImage(ArquivoFoto);

                    //string caminho = System.Configuration.ConfigurationSettings.AppSettings["caminhoUpload"] + "Fotos\\";
                    string caminho = "D:\\LTmobile\\Fotos\\";

                    //Recupera o ultimo identificador válido para foto
                    Dadosfoto.ID_FOTO = FotoFlow.getLastIdFoto();

                    // Busca o nome da foto
                    string fileName = caminho + Dadosfoto.ID_FOTO + ".jpg";

                    //Verifica se existe a pasta de fotos
                    if (!Directory.Exists("D:\\LTmobile"))
                    {
                        //Cria pasta fotos
                        Directory.CreateDirectory("D:\\LTmobile");
                    }

                    //Verifica se existe a pasta de fotos
                    if (!Directory.Exists(caminho))
                    {
                        //Cria pasta fotos
                        Directory.CreateDirectory(caminho);
                    }
                    // Verifica se o arquivo já foi salvo
                    if (!System.IO.File.Exists(fileName))
                    {
                        FileStream fs = File.Open(fileName, FileMode.CreateNew);
                        fs.Write(ArquivoFoto, 0, ArquivoFoto.Length - 1);
                        
                        fs.Flush();
                        fs.Close();
                    }

                    FotoFlow.Insert(Dadosfoto);
                }
                catch (Exception ex)
                {
//                    ErroFotoWS ErroFoto = new ErroFotoWS();
                    ErroFoto.COD_EMPRT = Dadosfoto.COD_EMPRT;
                    ErroFoto.COD_LOCAL = Dadosfoto.COD_LOCAL;
                    ErroFoto.MES_ANO_FATUR = Dadosfoto.MES_ANO_FATUR;
                    ErroFoto.NUM_RAZAO = Dadosfoto.NUM_RAZAO;
                    ErroFoto.NUM_UC = Dadosfoto.NUM_UC;
                    ErroFoto.TIPO_MEDIC = Dadosfoto.TIPO_MEDIC;
                    ErroFoto.NUM_SEQ_FOTO = Dadosfoto.NUM_SEQ_FOTO;
                }

                return ErroFoto;
        }

        [WebMethod]
        public void UpdateLeitura(LeituraWS leitura)
        {
            LeituraFlow.Update(leitura);
        }

        [WebMethod]
        public List<ErroLeituraWS> setLeitura(LeituraWS[] leitura)
        {
            List<ErroLeituraWS> lstErroLeitura = new List<ErroLeituraWS>();
            
            //foreach
            foreach (LeituraWS l in leitura)
            {
                try
                {
                    LeituraFlow.Update(l);

                }
                catch (Exception ex)
                {
                    ErroLeituraWS ErroLeitura = new ErroLeituraWS();
                    ErroLeitura.COD_EMPRT = l.COD_EMPRT;
                    ErroLeitura.COD_LOCAL = l.COD_LOCAL;
                    ErroLeitura.MES_ANO_FATUR = l.MES_ANO_FATUR;
                    ErroLeitura.NUM_RAZAO = l.NUM_RAZAO;
                    ErroLeitura.NUM_UC = l.NUM_UC;
                    ErroLeitura.TIPO_MEDIC = l.TIPO_MEDIC;

                    lstErroLeitura.Add(ErroLeitura);
                }
            }
            return lstErroLeitura;
        }

        [WebMethod]
        public List<ErroLeituraProvisoriaWS> setLeituraPovisoria(LeituraProvisoriaWS[] LeituraProvisoria)
        {

            List<ErroLeituraProvisoriaWS> lstErroLeituraProvisoria = new List<ErroLeituraProvisoriaWS>();

            foreach (LeituraProvisoriaWS LP in LeituraProvisoria)
            {

                try
                {
                    LeituraProvisoriaFlow.Insert(LP);

                }
                catch
                {
                    ErroLeituraProvisoriaWS ErroLeituraProvisoria = new ErroLeituraProvisoriaWS();
                    ErroLeituraProvisoria.COD_EMPRT = LP.COD_EMPRT;
                    ErroLeituraProvisoria.COD_LOCAL = LP.COD_LOCAL;
                    ErroLeituraProvisoria.MES_ANO_FATUR = LP.MES_ANO_FATUR;
                    ErroLeituraProvisoria.NUM_RAZAO = LP.NUM_RAZAO;
                    ErroLeituraProvisoria.NUM_UC_REF = LP.NUM_UC_REF;
                    ErroLeituraProvisoria.TIPO_MEDIC = LP.TIPO_MEDIC;
                    ErroLeituraProvisoria.NUM_MEDIDR = LP.NUM_MEDIDR;

                    lstErroLeituraProvisoria.Add(ErroLeituraProvisoria);
                }
            }
            return lstErroLeituraProvisoria;
        }

        [WebMethod]
        public List<ErroMensagemWS> setMensagem(MensagemWS[] mensagem)
        {
            
            List<ErroMensagemWS> lstErroMensagem = new List<ErroMensagemWS>();

            foreach (MensagemWS M in mensagem)
            {

                try
                {
                    MensagemFlow.Insert(M);

                }
                catch
                {
                    ErroMensagemWS ErroMensagem = new ErroMensagemWS();
                    ErroMensagem.COD_EMPRT = M.COD_EMPRT;
                    ErroMensagem.COD_LOCAL = M.COD_LOCAL;
                    ErroMensagem.MES_ANO_FATUR = M.MES_ANO_FATUR;
                    ErroMensagem.NUM_RAZAO = M.NUM_RAZAO;
                    ErroMensagem.NUM_UC = M.NUM_UC;                    
                    ErroMensagem.ID_MSG = M.ID_MSG;
                    ErroMensagem.TIPO_MEDIC = M.TIPO_MEDIC;

                    lstErroMensagem.Add(ErroMensagem);
                }
            }
            return lstErroMensagem;
        }
        
        private void AutenticarUsuario(string strUsuario, string strSenha)
        {
            if (!UsuarioFlow.AutenticarUsuario(strUsuario, strSenha))
            {
                throw new AuthenticationException("Login ou senha incorretos");
            }
        }
    }


}
