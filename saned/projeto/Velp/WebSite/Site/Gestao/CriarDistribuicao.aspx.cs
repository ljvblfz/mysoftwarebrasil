using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data.Model;
using Data.BFL;
using Data.DAL;
using System.Data;
using System.Collections;
using GDA.Sql;

public partial class Gestao_CriarDistribuicao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["Grupo"]))
        {
            ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('titulo').innerHTML = 'Distribuição do grupo " + Request.QueryString["Grupo"].ToString() + "';", true);
            TextBoxGrupo.Text = Request.QueryString["Grupo"].ToString();
            TextBoxReferencia.Text = Request.QueryString["Referencia"].ToString();
            ObjectDataSource1.SelectParameters["Grupo"].DefaultValue = Request.QueryString["Grupo"].ToString();
            DataTable lista = DistribuicaoFlow.ListaDistribuicao(int.Parse(Request.QueryString["Grupo"]));
            //DataTable lista = new DistribuicaoDAO().RetornaDistribuicao2(int.Parse(Request.QueryString["Grupo"]));
            Session.Add("DistribuicaoTable", lista);
            ListView1.DataSource = lista;
            ListView1.DataBind();
        }
        if (!String.IsNullOrEmpty(Request.QueryString["Liberar"]))
        {
            if (Request.QueryString["Liberar"].ToUpper() != "NÃO ATRIBUIDA" )
                Liberar.Text = "true";
        }

        if (!String.IsNullOrEmpty(Request.QueryString["liberarDistribuicao"]))
        {
            LiberarRota();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        LiberarRota();
        return;

        bool liberado = false;
        if(!String.IsNullOrEmpty(Liberar.Text))
            liberado = bool.Parse(Liberar.Text);
        if (liberado)
        {
            ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Distribuição liberada não pode ser atribuida.');", true);
        }
        else
        {
            List<Distribuicao> listaDistribuicao = new List<Distribuicao>();

            foreach (ListViewItem item in ListView1.Items)
            {
                Distribuicao distribuiçãoAUX = new Distribuicao();
                DropDownList objCodigoAgente = (DropDownList)item.FindControl("DropDownList1");
                Label objRoteiro = (Label)item.FindControl("LabelRota");
                HiddenField hdSituacao = (HiddenField)item.FindControl("hdSituacao");
                
                if (objCodigoAgente.Text.ToString() != "" && objRoteiro.Text.ToString() != "")
                {
                    distribuiçãoAUX.Codigo_Agente = int.Parse(objCodigoAgente.Text.ToString());
                    distribuiçãoAUX.Rota = int.Parse(objRoteiro.Text.ToString());
                    distribuiçãoAUX.Grupo = int.Parse(TextBoxGrupo.Text.ToString());
                    distribuiçãoAUX.Referencia = DateTime.Parse(TextBoxReferencia.Text.ToString());
                    distribuiçãoAUX.Situacao = "B";
                    listaDistribuicao.Add(distribuiçãoAUX);
                }
            }

            if (listaDistribuicao.Count > 0)
            {
                if (listaDistribuicao.Count == ListView1.Items.Count)
                {
                    DistribuicaoFlow.UpdateList(listaDistribuicao);
                    string referencia = (String.IsNullOrEmpty(Request.QueryString["Referencia"]) ? "" : Request.QueryString["Referencia"].ToString());
                    Response.Redirect("~/Gestao/Distribuicao.aspx?Referencia=" + referencia);
                }
                else
                    ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Atribua todas as rotas aos agentes.');", true);
            }
        }
    }

    protected void LiberarRota()
    {
        List<Distribuicao> listaDistribuicao = new List<Distribuicao>();

        foreach (ListViewItem item in ListView1.Items)
        {
            Distribuicao distribuiçãoAUX = new Distribuicao();

            DropDownList objCodigoAgente = (DropDownList)item.FindControl("DropDownList1");
            Label objRoteiro = (Label)item.FindControl("LabelRota");
            HiddenField hdSituacao = (HiddenField)item.FindControl("hdSituacao");
            CheckBox isLiberar = (CheckBox)item.FindControl("CheckBox1");
            if (objCodigoAgente.Text.ToString() != "" && objRoteiro.Text.ToString() != "" && isLiberar.Checked)
            {
                distribuiçãoAUX.Codigo_Agente = int.Parse(objCodigoAgente.Text.ToString());
                distribuiçãoAUX.Rota = int.Parse(objRoteiro.Text.ToString());
                distribuiçãoAUX.Grupo = int.Parse(TextBoxGrupo.Text.ToString());
                distribuiçãoAUX.Referencia = DateTime.Parse(TextBoxReferencia.Text.ToString());
                distribuiçãoAUX.Situacao = "L";
                listaDistribuicao.Add(distribuiçãoAUX);
            }
            try
            {
                DistribuicaoFlow.UpdateList(listaDistribuicao);
                ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Rota atribuida e liberada.');", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //if (distribuicao.Rota == rota)
        //{
        //    string where = String.Format("grupo = {0} AND rota = {1} AND referencia = '{2}'", distribuicao.Grupo, distribuicao.Rota, distribuicao.Referencia);
        //    Query  query = new Query(where);
        //    List<Distribuicao> distribuicaoExistente = new DistribuicaoDAO().Select(query);
        //    try
        //    {
        //        if (distribuicaoExistente.Count > 0)
        //        {
        //            distribuicao.Update();
        //        }
        //        else
        //        {
        //            distribuicao.Insert();
        //        }
        //        ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('titulo').innerHTML = 'Distribuição liberada para carga';", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }

}
