using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Erro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Exception ex = (Exception)Application["TheException"];
        string url = null;
        if(Request != null)
            if(Request.UrlReferrer != null)
                url = Request.UrlReferrer.OriginalString;
        string msg = "";
        string mensagem = "";

        if (!IsPostBack && ex != null)
        {
            if (ex.InnerException != null)
            {
                mensagem = ex.InnerException.Message;
                msg = ex.InnerException.Message + "<br />" + ex.InnerException.Source + "<br />" + ex.InnerException.StackTrace + "<br /><br />" + ex.InnerException.TargetSite;
            }
            else
            {
                mensagem = ex.Message;
                msg = ex.Message + "<br />" + ex.Source + "<br />" + ex.StackTrace + "<br /><br />" + ex.TargetSite;
            }
            msg += " Url: " + url;

            string messagem = msg + @" 
            Informações complementares :
            CurrentCulture: " + System.Globalization.CultureInfo.CurrentCulture + @"
            CurrentUICulture: " + System.Globalization.CultureInfo.CurrentUICulture + @"
            InstalledUICulture:" + System.Globalization.CultureInfo.InstalledUICulture;

            LabelMenssagem.Text = mensagem;
            LabelDetalhes.Text = msg;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string erro = LabelDetalhes.Text;
        Mail.Send(erro);
        Response.Redirect("~/Default.aspx");
    }
}
