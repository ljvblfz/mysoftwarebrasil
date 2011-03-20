using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Data.BFL;

using System.Web.Security;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;

public partial class Gestao_Acompanhamento : System.Web.UI.Page
{
    /// <summary>
    ///  Globalization pt-BR
    /// </summary>
    protected static CultureInfo culture = new CultureInfo("pt-BR"); 

    protected void Page_Load(object sender, EventArgs e)
    {
        string html = "";
        try
        {
            // Verifica se a requisição e via GET
            if (!IsPostBack && !String.IsNullOrEmpty(Request.QueryString["Referencia"]) && !String.IsNullOrEmpty(Request.QueryString["Grupo"]))
            {
                // Instacia o Objeto de configurações
                InformacoesAmbiente objInfo = Config.Ambiente;

                // Retorna a lista com os dados 
                DataTable lista = DistribuicaoFlow.RetornaAcompanhamento(int.Parse(Request.QueryString["Grupo"]));

                // Gera o codigo HTML da tabela (Este codigo deve ser dinamico para ser atualizado via ajax)
                html = retornaPesquisa(lista);

                // Remove todas as quebra de linha (para que possa passar pelo javaScript)
                string s = html.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");

                // Retorna o dado de grupo
                txtGrupo.Text = Request.QueryString["Grupo"];
                lbGrupo.Text = "Grupo: " + Request.QueryString["Grupo"];

                // Retorna o tempo do cronometro
                lbCronometro.Text = objInfo.tempo;

                // Retorna uma variavel do javaScript
                Page.ClientScript.RegisterClientScriptBlock(typeof(string), "JSVariables", "codigoTabela='" + s + "';", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    ///  Metodo ajax para atualizar os dados da tela
    /// </summary>
    /// <param name="codGrupo"></param>
    /// <returns></returns>
    [System.Web.Services.WebMethod]
    public static string atualizarTela(int codGrupo)
    {
        string html = "";
        for (int i = 0; i < 1000; i++) ;
        DataTable lista = DistribuicaoFlow.RetornaAcompanhamento(codGrupo);
        html = retornaPesquisa(lista);
        return html;
    }

    /// <summary>
    /// Retorna o HTML da tabela
    /// </summary>
    /// <param name="lista"></param>
    /// <returns></returns>
    public static string retornaPesquisa(DataTable lista)
    {
         string html = @"<table id=""tabelaAcompanhamento"" border=""0"" style=""text-align: center;"" class=""gridView"" id=""itemPlace"">
                            <tbody>
                                <tr id=""header"" style=""text-align:center;"">
	                                <th style=""width: 10%;"" id=""thGrupo"">Grupo</th>
	                                <th style=""width: 20%;"" id=""thRota"">Rota</th>
	                                <th style=""width: 20%;"" id=""thDataCarga"">Data Carga</th>
	                                <th style=""width: 20%;"" id=""thDataUltimaDescarga"">Data Ultima Descarga</th>
	                                <th style=""width: 15%;"" id=""qtdMatriculas"">Total Matriculas</th>
	                                <th style=""width: 15%;"" id=""thQtdMatriculasDescarregadas"">Matriculas Descarregadas</th>
	                                <th style=""width: 15%;"" id=""thPercDescarregado"">% Descarregado</th>
                                </tr>";
            for (int i = 0; i < lista.Rows.Count; i++)
            {
                DateTime dataCarga;
                string dataCargaString = String.Empty;
                DateTime dataDescarga;
                string dataDescargaString = String.Empty;

                if (!String.IsNullOrEmpty(lista.Rows[i]["data_carga"].ToString()))
                {
                    dataCarga = DateTime.Parse(lista.Rows[i]["data_carga"].ToString());
                    dataCargaString = dataCarga.ToString("d", culture);
                }
                if (!String.IsNullOrEmpty(lista.Rows[i]["data_ultima_descarga"].ToString()))
                {
                    dataDescarga = DateTime.Parse(lista.Rows[i]["data_ultima_descarga"].ToString());
                    dataDescargaString = dataDescarga.ToString("d", culture);

                }

                
                
                html += @"<tr id=""linha"+i.ToString()+@""">";

                html += @"  <td id=""coluna" + i.ToString() + @"_" + i.ToString() + @""" class=""center"" >";
                html += @"      <span id=""grupo" + i.ToString() + @"_" + i.ToString() + @""">" + lista.Rows[i]["grupo"].ToString() + @"</span>";
                html += @"  </td>";

                html += @"  <td id=""coluna" + i.ToString() + @"_" + (i + 1).ToString() + @""" class=""center"" >";
                html += @"      <span id=""rota" + i.ToString() + @"_" + i.ToString() + @""">" + lista.Rows[i]["Rota"].ToString() + @"</span>";
                html += @"  </td>";

                html += @"  <td id=""coluna" + i.ToString() + @"_" + (i + 1).ToString() + @""" class=""center"" >";
                html += @"      <span id=""data_carga" + i.ToString() + @"_" + i.ToString() + @""">" + dataCargaString + @"</span>";
                html += @"  </td>";

                html += @"  <td id=""coluna" + i.ToString() + @"_" + (i + 1).ToString() + @""" class=""center"" >";
                html += @"      <span id=""data_ultima_descarga" + i.ToString() + @"_" + i.ToString() + @""">" + dataDescargaString + @"</span>";
                html += @"  </td>";

                html += @"  <td id=""coluna" + i.ToString() + @"_" + (i + 1).ToString() + @""" class=""center"" >";
                html += @"      <span id=""qtd_matriculas" + i.ToString() + @"_" + i.ToString() + @""">" + lista.Rows[i]["qtd_matriculas"].ToString() + @"</span>";
                html += @"  </td>";

                html += @"  <td id=""coluna" + i.ToString() + @"_" + (i + 1).ToString() + @""" class=""center"" >";
                html += @"      <span id=""qtd_matriculas_descarregadas" + i.ToString() + @"_" + i.ToString() + @""">" + lista.Rows[i]["qtd_matriculas_descarregadas"].ToString() + @"</span>";
                html += @"  </td>";

                html += @"  <td id=""coluna" + i.ToString() + @"_" + (i + 1).ToString() + @""" class=""center"">";
                html += @"      <span id=""perc_descarregado" + i.ToString() + @"_" + i.ToString() + @""">" + lista.Rows[i]["perc_descarregado"].ToString() + @"</span>";
                html += @"  </td>";

                html += @"  </tr>";
            }
        return html+@"<tbody></table>";
    }

}
