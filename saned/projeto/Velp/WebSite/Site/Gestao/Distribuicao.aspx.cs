using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data.BFL;
using Data.Model;
using System.Data;

public partial class Gestao_Distribuicao : System.Web.UI.Page
{
    
    /// <summary>
    ///  Distribuição
    /// </summary>
    protected List<Distribuicao> listaDistribuicao;

    /// <summary>
    ///  Grupo
    /// </summary>
    protected List<GrupoONP> listaGrupo;

    /// <summary>
    ///  LOAD
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && String.IsNullOrEmpty(Request.QueryString["Referencia"]) && String.IsNullOrEmpty(Request.QueryString["Liberar"]))
        {
            listaGrupo = GrupoFlow.ListaGrupoSelect();
            ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('ctl00_ContentPlaceHolder2_referencia').value = ''", true);
        }

        if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["Referencia"]) && String.IsNullOrEmpty(Request.QueryString["Liberar"]))
        {
            DateTime textReferencia = DateTime.Parse(Request.QueryString["Referencia"].ToString());
            List<DistribuicaoGrid> lista = DistribuicaoGridFlow.Lista(textReferencia);
            referencia.Text = String.Format("{0}/{1}", textReferencia.Month, textReferencia.Year);
            Session.Add("DistribuicaoTable", lista);
            ListView1.DataSource = lista;
            ListView1.DataBind();
            ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('ctl00_ContentPlaceHolder2_referencia').value = '" + Request.QueryString["Referencia"].ToString() + "'", true);
        }

        if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["Grupo"]) && !String.IsNullOrEmpty(Request.QueryString["Referencia"]) && !String.IsNullOrEmpty(Request.QueryString["Liberar"]))
        {
            DateTime textReferencia = DateTime.Parse(Request.QueryString["Referencia"].ToString());
            int grupo = int.Parse(Request.QueryString["Grupo"].ToString());

            bool liberado = DistribuicaoFlow.LiberarDistribuicao(grupo, textReferencia);

            if (liberado)
            {
                ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('divMensagem').style.display = 'block'; document.getElementById('mensagem').innerHTML = 'Distribuição liberada para carga.';", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('divMensagem').style.display = 'block'; document.getElementById('mensagem').innerHTML = 'Não é possivel liberar distribuição.';", true);
            }
            referencia.Text = String.Format("{0}/{1}", textReferencia.Month, textReferencia.Year); 
            List<DistribuicaoGrid> lista = DistribuicaoGridFlow.Lista(textReferencia);
            Session.Add("DistribuicaoTable", lista);
            ListView1.DataSource = lista;
            ListView1.DataBind();
            ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('ctl00_ContentPlaceHolder2_referencia').value = '" + Request.QueryString["Referencia"].ToString() + "'", true);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        // Se os valore foram postados
        if (IsPostBack && referencia.Text.ToString() != "")
        {
            //ObjectDataSource1.SelectParameters["referencia"].DefaultValue = referencia.Text.ToString();
            DateTime textReferencia = DateTime.Parse(referencia.Text.ToString());
            List<DistribuicaoGrid> lista = DistribuicaoGridFlow.Lista(textReferencia);
            Session.Add("DistribuicaoTable", lista);
            ListView1.DataSource = lista;
            ListView1.DataBind();
            //ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('ctl00_ContentPlaceHolder2_referencia').value = '" + referencia.Text.ToString() + "'", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('ctl00_ContentPlaceHolder2_referencia').value = '';", true);
            if (referencia.Text.ToString() == "")
            {
                ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('ctl00_ContentPlaceHolder2_LabelErroReferencia').style.display = 'block';", true);
                ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Referencia não informada');", true);
            }
        }
    }
}
