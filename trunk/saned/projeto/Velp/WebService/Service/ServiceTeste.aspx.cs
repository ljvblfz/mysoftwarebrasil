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
using Data.Model;
using Data.DAL;
using System.Collections.Generic;

namespace SANEDWebService
{
    public partial class ServiceTeste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Service1 webService = new Service1();
                string versao = webService.ExibeVersao();
                TextBoxVersao.Text = versao;
                string configuracaoAmbiente = webService.ExibeConfiguracaoAmbiente();
                TextBoxAmbiente.Text = configuracaoAmbiente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
