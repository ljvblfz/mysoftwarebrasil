using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.IO;
using System.Management;

/// <summary>
/// Summary description for Mail
/// </summary>
public class Mail
{
    /// <summary>
    /// Metodo de envia um email com a mensagem de erro
    /// </summary>
    /// <param name="erro"></param>
    public static void SendErro(Exception ex,string url)
    {

        string msg = "";
        if (ex.InnerException != null)
            msg = ex.InnerException.Message + "\r\n" + ex.InnerException.Source + "\r\n" + ex.InnerException.StackTrace + "\r\n" + ex.InnerException.TargetSite;
        else
            msg = ex.Message + "\r\n" + ex.Source + "\r\n" + ex.StackTrace + "\r\n" + ex.TargetSite;
            msg += " Url: " + url;

            string messagem = msg + @" 
            Informações complementares :
            CurrentCulture: " + System.Globalization.CultureInfo.CurrentCulture+@"
            CurrentUICulture: "+ System.Globalization.CultureInfo.CurrentUICulture+@"
            InstalledUICulture:" + System.Globalization.CultureInfo.InstalledUICulture;

            Send(messagem);
    }

    /// <summary>
    ///  Metodo que envia informações do servidor por email
    ///  (isso ocorre somente na instalação ou atualização do site)
    /// </summary>
    public static void EnviarInfo()
    {
                    
        try
        {
            bool mensagemInicial = false;
            string pachLocal = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            string nome_arquivo = pachLocal + "Test.txt";
            if (!System.IO.File.Exists(nome_arquivo))
            {
                System.IO.File.Create(nome_arquivo).Close();
                mensagemInicial = true;
            }
            
            if (mensagemInicial)
            {
                string messagem = @" 
                Informações do Servidor:
                CurrentCulture: " + System.Globalization.CultureInfo.CurrentCulture + @"
                CurrentUICulture: " + System.Globalization.CultureInfo.CurrentUICulture + @"
                InstalledUICulture: " + System.Globalization.CultureInfo.InstalledUICulture + @"
                Diretorio da aplicação: " + pachLocal+@"
                
                INFORMAÇÔES SERVIDOR:" + Info();

                Send(messagem);
            }
        }
        catch (Exception exec)
        {
        }
    }

    /// <summary>
    ///  Recupera as informações do sistema
    /// </summary>
    /// <returns></returns>
    public static string Info()
    {
        const string espace = " ";
        const string newLine = @"
";
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");
        string info = "";        
        try
        {
            foreach (ManagementObject share in searcher.Get())
            {

                foreach (PropertyData PC in share.Properties)
                {
                    if (PC.Value != null && PC.Value.ToString() != "")
                    {
                        switch (PC.Value.GetType().ToString())
                        {
                            case "System.String[]":
                                string[] str = (string[])PC.Value;

                                string str2 = "";
                                foreach (string st in str)
                                    str2 += st + " ";

                                info += PC.Name + espace + str2 + newLine;

                                break;
                            case "System.UInt16[]":
                                ushort[] shortData = (ushort[])PC.Value;


                                string tstr2 = "";
                                foreach (ushort st in shortData)
                                    tstr2 += st.ToString() + " ";

                                info += PC.Name + espace + tstr2 + newLine;

                                break;

                            default:
                                info += PC.Name + espace + PC.Value.ToString() + newLine;
                                break;
                        }
                    }
                }
            }
        }
        catch (Exception exp)
        {
        }
        return info;
    }

    /// <summary>
    ///  Metodo de envia um email
    /// </summary>
    /// <param name="messagem"></param>
    public static void Send(string messagem)
    {

        //Define os dados do e-mail
        string emailRemetente = "alexismoura@velp.com.br"; //remetente
        string senha = "548372alexis"; //senha email
        string smtp = "smtp.velp.com.br"; //SMTP
        int porta = 587; //PORTA
        string emailDestinatario = "alexismoura@velp.com.br"; //destino
        string emailComCopia = "alexismoura@velp.com.br"; //com copia
        string assuntoMensagem = "Erro na aplicação SANED WEB RETAGUARDA "; //assunto
        string conteudoMensagem = @"Erro identificado no horario:" + DateTime.Now + @"Descrição do erro :" + messagem;

        try
        {

            // Estancia da Classe de Mensagem
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailComCopia);

            // O Destinario tambem TAMBÉM é VOCE, para que assim o e-mail chegue a sua conta
            mailMessage.To.Add(emailDestinatario);

            // Se houver necessidade vc pode enviar uma copia do e-mail para alguem, como por exemplo
            // para o proprio cliente para que ele fique ciente de o e-mail de contato foi enviado e que
            // logo voce entrara em contato
            //mailMessage.CC.Add("sense@funcoge.org.br");

            // Assunto
            mailMessage.Subject = assuntoMensagem;

            // A mensagem é do tipo HTML(true) ou Texto Puro (false)?  
            mailMessage.IsBodyHtml = false;

            // Corpo da Mensagem, conteudo da variavel criada acima
            mailMessage.Body = conteudoMensagem;
            // ***************************************************************************
            // ***
            // ***                              A T E N C A O
            // ***
            // ***************************************************************************
            // Se voce pode habilitar este trecho para enviar arquivos em anexo.
            // NAO SE ESQUECA DE INCLUIR O OBJETO FileUpload NO DESIGNER DA PAGINA
            // criando um loop pode ser enviado mais de um anexo.
            // Recupera o binario enviado pelo FileUpload  
            //    MemoryStream MS = new MemoryStream(fileAnexo.FileBytes);  
            // Anexa o Stream do arquivo  
            //    Attachment anexo = new Attachment(MS, fileAnexo.FileName);  
            //    mailMessage.Attachments.Add(anexo);  
            // ***************************************************************************

            // Estancia a Classe de Envio; as informações aqui inseridas voce obtem com o provedor
            // onde hospedou seu site
            SmtpClient smtpClient = new SmtpClient(smtp, porta);

            //// Credencial para envio por SMTP Seguro (APENAS QUANDO O SERVIDOR EXIGE AUTENTICAÇÃO)  
            smtpClient.Credentials = new NetworkCredential(emailRemetente, senha);

            // Envia a mensagem  
            smtpClient.Send(mailMessage);
        }
        catch (Exception f)
        {
            // Se houver algum erro informa o usuário

        }
    }
}
