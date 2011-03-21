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
using GeraBase;
using System.Threading;

public partial class Gestao_CriarDistribuicao : System.Web.UI.Page
{
    private int agente;
    private int grupo;
    private int rota;
    private DateTime referencia;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["Grupo"]))
        {
            ClientScript.RegisterStartupScript(typeof(string), "", "document.getElementById('titulo').innerHTML = 'Distribuição do grupo " + Request.QueryString["Grupo"].ToString() + "';", true);
            TextBoxGrupo.Text = Request.QueryString["Grupo"].ToString();
            TextBoxReferencia.Text = Request.QueryString["Referencia"].ToString();
            ObjectDataSource1.SelectParameters["Grupo"].DefaultValue = Request.QueryString["Grupo"].ToString();
            DataTable lista = DistribuicaoFlow.ListaDistribuicao(int.Parse(Request.QueryString["Grupo"]));
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

                agente = (int)distribuiçãoAUX.Codigo_Agente;
                rota = distribuiçãoAUX.Rota;
                grupo = distribuiçãoAUX.Grupo;
                referencia = (DateTime)distribuiçãoAUX.Referencia;

                //thread de sincronismo
                //Thread syncThread = new Thread(new ThreadStart(GeraDataBase));
                GeraDataBase();

             }
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

    public void GeraDataBase()
    {
        int agenteAUX = agente;
        int grupoAUX = grupo;
        int rotaAUX = rota;
        DateTime referenciaAUX = referencia;

        // Nome do arquivo do banco de dados
        string dataBaseName = "OnPlace_"
                                + "_" + grupoAUX
                                + "_" + rotaAUX
                                + "_" + String.Format("{0:dd_MM_yyyy}", referenciaAUX)
                                + ".sdf";

        // Realiza uma copia do arquivo
        SQLHelper.copyFiles(
                                Config.Ambiente.bancoMovel
                                , Config.Ambiente.pastaTemporaria
                                ,dataBaseName
                           );

        // Configura o banco de dados do movel
        GeraBase.Config.conectionString = Config.Ambiente.pastaTemporaria + dataBaseName;

        // Objeto de identificação PDA
        GeraBase.Model.Identificacao pda = new GeraBase.Model.Identificacao();
        pda.usuario = agenteAUX;
        pda.coletor = "CARGA OFFLINE";

        // Objeto de retorno dos dados
        DataBase bancoMovel = new DataBase();

        // Retorna a lista de agentes
        List<GeraBase.Model.AgenteONP> listaAgente = bancoMovel.ListaAgente(grupoAUX, pda);

        List<GeraBase.Model.FaturaCategoriaONP> listaFaturaCategoria = bancoMovel.ListaFaturaCategoria(grupoAUX, referenciaAUX, rotaAUX, rotaAUX, pda);

        List<GeraBase.Model.AvisoDebito> listaAvisoDebito = bancoMovel.RetornaAvisoDebito(grupoAUX, rotaAUX, rotaAUX, pda);

        List<GeraBase.Model.FaturaONP> listaFatura = bancoMovel.ListaFatura(grupoAUX, referenciaAUX, rotaAUX, rotaAUX, pda,1);

        List<GeraBase.Model.ServicoFaturaONP> listaServicoFatura = bancoMovel.ListaServicoFatura(grupoAUX, referenciaAUX, rotaAUX, rotaAUX, pda);

        List<GeraBase.Model.FaturaServicoONP> ListaFaturaServico = bancoMovel.ListaFaturaServico(grupoAUX, referenciaAUX, rotaAUX, rotaAUX, pda);


        GenericDAO<GeraBase.Model.AgenteONP> objAgente = new GenericDAO<GeraBase.Model.AgenteONP>();
        objAgente.LimpaBanco();
        objAgente.Insert(listaAgente.ToArray(), "ONP_AGENTE", null);
    }

}
