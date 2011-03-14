using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.IO;
using Data.BFL;
using Data.Model;

public partial class Relatorio_Critica_Default : System.Web.UI.Page
{
    /// <summary>
    /// contrutor
    /// </summary>
    public void Page_Load(object sender, EventArgs e)
    {
        //if (IsPostBack && DataPager1.StartRowIndex > 0)
        //{
        //    this.Pesquisa();
        //    DataPager1.SetPageProperties(DataPager1.StartRowIndex, 10, true);
        //    DataPager1.DataBind();
        //}
    }

    /// <summary>
    ///  Evento de gerar relatorio
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        // INICIALIZA AS VARIAVEIS

        // Listas de leitura e de volta (com as regras de critica)
        List<Critica> listaCritica = new List<Critica>();

        // HTTP
        HttpContext context = System.Web.HttpContext.Current;

        // instancia do relatorio
        LocalReport report = new LocalReport();

        // Retorna os dados relacionas 
        listaCritica = GetListaCritica();

        if (listaCritica.Count() > 0)
        {
            // Caminho do relatorio
            report.ReportPath = "Relatorio\\Critica\\Relatorio.rdlc";

            // Seta os parametros
            ReportParameter[] param = new ReportParameter[4];
            param[0] = new ReportParameter();
            param[0].Name = "logotipo";
            param[0].Values.Add(Relatorio.GetReportLogo(context));

            param[1] = new ReportParameter();
            param[1].Name = "grupo";
            if (!String.IsNullOrEmpty(grupo.Text))
                param[1].Values.Add(grupo.Text.ToString());
            else
                param[1].Values.Add("Todos");

            param[2] = new ReportParameter();
            param[2].Name = "rota";
            if (!String.IsNullOrEmpty(Rota.Text))
                param[2].Values.Add(Rota.Text.ToString());
            else
                param[2].Values.Add("Todas");


            param[3] = new ReportParameter();
            param[3].Name = "referencia";
            if (!String.IsNullOrEmpty(Rota.Text))
                param[3].Values.Add(String.Format("{0:dd/MM/yyyy}",Referencia.Text.ToString()));
            else
                param[3].Values.Add("Todas");

            report.EnableExternalImages = true;
            report.SetParameters(param);

            // seta os datasorce
            report.DataSources.Add(new ReportDataSource("VoltaLeitura", listaCritica));
            report.DataSources.Add(new ReportDataSource("Ligacoes1", listaCritica));

            // Gera o relatorio
            Relatorio.geraRelatorio(context, "RelatorioCritica", report, "PDF");
        }
        else
        {
            // Se não existe sai da aplicação e retorna a mensagem de erro
            ClientScript.RegisterStartupScript(typeof(string), "Alert", "alert('Não foram encontrados registros.');", true);
            return;
        }
    }

    /// <summary>
    ///  Evento de pesquisa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Pesquisa();
    }

    /// <summary>
    ///  Retorna dados de critica
    /// </summary>
    /// <returns></returns>
    public List<Critica> GetListaCritica()
    {

        // Listas de leitura e de volta (com as regras de critica)
        List<Critica> listaCritica = new List<Critica>();
        
        // Matricula
        int? varCDC = null;

        // Grupo
        int? varGrupo = null;

        // Rota
        int? varRota = null;

        // Referencia
        DateTime? varReferencia = null;

        // HTTP
        HttpContext context = System.Web.HttpContext.Current;

        // instancia do relatorio
        LocalReport report = new LocalReport();

        // Recupera a matricula postada
        if (!String.IsNullOrEmpty(CDC.Text))
            varCDC = int.Parse(CDC.Text.ToString());

        // Recupera o grupo postado
        if (!String.IsNullOrEmpty(grupo.Text))
            varGrupo = int.Parse(grupo.Text.ToString());

        // Recupera a rota postado
        if (!String.IsNullOrEmpty(Rota.Text))
            varRota = int.Parse(Rota.Text.ToString());

        // Recupera a referencia
        if (!String.IsNullOrEmpty(Referencia.Text.ToString()))
            varReferencia = DateTime.Parse(Referencia.Text.ToString());

        // Retorna os dados relacionas 
        listaCritica = VoltaLeituraFlow.ListaCritica(varCDC, varRota, varGrupo, varReferencia);

        return listaCritica;
    }

    /// <summary>
    ///  Metodo que realiza a pesquisa dos dados
    /// </summary>
    public void Pesquisa()
    {
        // INICIALIZA AS VARIAVEIS

        // Listas de leitura e de volta (com as regras de critica)
        List<Critica> listaCritica = new List<Critica>();

        // HTTP
        HttpContext context = System.Web.HttpContext.Current;

        // instancia do relatorio
        LocalReport report = new LocalReport();

        // Retorna os dados relacionas 
        listaCritica = GetListaCritica();

        if (listaCritica.Count() > 0)
        {
            Session.Add("DistribuicaoTable", listaCritica);
            ListView1.DataSource = listaCritica;
            ListView1.DataBind();
        }
        else
        {
            // Se não existe sai da aplicação e retorna a mensagem de erro
            ClientScript.RegisterStartupScript(typeof(string), "Alert", "alert('Não foram encontrados registros.');", true);
            return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IPageableItemContainer
    {
        event EventHandler<PageEventArgs> TotalRowCountAvailable;
        void SetPageProperties(int startRowIndex, int maximumRows,bool databind);
        int MaximumRows { get; }
        int StartRowIndex { get; }
    }


}
