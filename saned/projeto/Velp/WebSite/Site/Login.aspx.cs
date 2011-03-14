using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Data.BFL;
using System.Web.Configuration;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    /// <summary>
    ///  Construtor da pagina
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Instacia o Objeto de configurações
        InformacoesAmbiente objInfo = (InformacoesAmbiente)ConfigurationManager.GetSection("ConfigAmbiente");

        lbVersao.Text = "Versão :"+objInfo.versao;
        if (!String.IsNullOrEmpty(Request.QueryString["valor"]) && !IsPostBack)
        {
            FormsAuthentication.SignOut();
        }
    }

    /// <summary>
    ///  Autentica o usuario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string usuario = TxtUsuario.Text.ToString();
        string senha = TxtPassword.Text.ToString();
        bool autenticacao = UsuarioIdaFlow.Autenticar(usuario, senha);
        if (autenticacao)
        {
            FormsAuthentication.RedirectFromLoginPage("NomeDoUsuario", true);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                                                                                1,
                                                                                usuario,
                                                                                DateTime.Now,
                                                                                DateTime.Now.AddMinutes(30),
                                                                                true,
                                                                                "ApplicationSpecific data for this user.",
                                                                                FormsAuthentication.FormsCookiePath
                                                                             );
            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }
        else
            ClientScript.RegisterStartupScript(typeof(string), "Alert", "alert('Login e senha incorreta.');", true);

    }
}
