using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data.BFL;

public partial class Cadastro_AlterarSenha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["Codigo"]))
        {
            TextBoxCodigo.Text = Request.QueryString["Codigo"].ToString();
        }
    }
    protected void ButtonSalvar_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            int codigo = int.Parse(TextBoxCodigo.Text.ToString());
            string SenhaAntiga = TextBoxSenhaAntiga.Text.ToString();
            string SenhaNova = TextBoxSenhaNova.Text.ToString();

            if (UsuarioIdaFlow.AletrarSenha(codigo, SenhaAntiga, SenhaNova))
            {
                ClientScript.RegisterStartupScript(typeof(string), "Alert", "alert('Senha alterada.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "Alert", "alert('Senha incorreta.');", true);
            }
        } 
    }
}
