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
using Data.DAL;
using System.Data.SqlTypes;
using System.Globalization;

/// <summary>
/// Summary description for Critica
/// </summary>
public partial class Critica_Default : System.Web.UI.Page
{
    #region Variaveis

    /// <summary>
    /// Lista de ligações
    /// </summary>
    protected List<Ligacoes> listaLigacoes;

    /// <summary>
    /// Model ligações
    /// </summary>
    protected Ligacoes ligacoes;

    /// <summary>
    /// Lista de logradouro
    /// </summary>
    protected List<LogradouroIDA> listaLogradouro;

    /// <summary>
    /// Model logradouro
    /// </summary>
    protected LogradouroIDA logradouro;

    /// <summary>
    /// Lista de leitura
    /// </summary>
    protected List<VoltaLeitura> listaVoltaLeitura;

    /// <summary>
    /// Model volta leitura
    /// </summary>
    protected VoltaLeitura voltaLeitura;

    /// <summary>
    /// Lista de historico de consumo
    /// </summary>
    protected List<HistoricoConsumoIDA> listaHistoricoConsumo;

    /// <summary>
    /// Model historico de consumo
    /// </summary>
    protected HistoricoConsumoIDA historicoConsumo;

    /// <summary>
    /// Lista de segunda via
    /// </summary>
    protected List<SegundaViaIDA> listaSegundaVia;

    /// <summary>
    /// Lista de ocorrencia
    /// </summary>
    protected List<OcorrenciaONP> listaOcorrencia;

    /// <summary>
    /// Model Ocorrencia
    /// </summary>
    protected OcorrenciaONP ocorrencia;

    /// <summary>
    /// Model segunda via
    /// </summary>
    protected SegundaViaIDA segundaVia;

    /// <summary>
    ///  Globalization pt-BR
    /// </summary>
    protected static CultureInfo culture = new CultureInfo("pt-BR"); 

    #endregion

    /// <summary>
    /// LOAD DA PAGINA
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Page_Load(object sender, EventArgs e)
    {
        string referenciaString = null;
        List<VoltaLeitura> listaLeitura = new List<VoltaLeitura>();
        DateTime? referencia = null;
        int? grupo = null;
        int? rota = null;

        //
        // TODO: Add constructor logic here
        //
        try
        {
            if (!String.IsNullOrEmpty(Request.QueryString["Grupo"]) && !IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Entrada"]))
                    TextGrupo.Text = Request.QueryString["Grupo"].ToString();
                grupo = int.Parse(Request.QueryString["Grupo"]);
            }

            if (!String.IsNullOrEmpty(Request.QueryString["Rota"]) && !IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Entrada"]))
                    TextRota.Text = Request.QueryString["Rota"].ToString();
                rota = int.Parse(Request.QueryString["Rota"]);
            }

            if (!String.IsNullOrEmpty(Request.QueryString["Referencia"]) && !IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Entrada"]))
                    TextReferencia.Text = Request.QueryString["Referencia"].ToString();
                referenciaString = Request.QueryString["Referencia"];
            }

            if (!String.IsNullOrEmpty(Request.QueryString["CDC"]) && !IsPostBack)
            {
                // Recupera a matricula
                int parametroCDC = int.Parse(Request.QueryString["CDC"]);
                this.CarregaDados(parametroCDC, referenciaString);
                this.RetornaDados(parametroCDC);

            }
            if (!String.IsNullOrEmpty(Request.QueryString["Grupo"]) && String.IsNullOrEmpty(Request.QueryString["Entrada"]) && !IsPostBack)
            {
                if (!String.IsNullOrEmpty(TextReferencia.Text))
                {
                    referencia = DateTime.Parse(TextReferencia.Text);
                }

                List<Critica> listaVoltaLeitura = VoltaLeituraFlow.ListaCritica(null, rota, grupo, referencia);
                if (listaVoltaLeitura.Count > 0)
                {
                    this.CarregaDados(listaVoltaLeitura[0].CDC, referencia.ToString());
                    this.RetornaDados(listaVoltaLeitura[0].CDC);
                }
                else if (listaVoltaLeitura.Count <= 0)
                {
                   ObjectDataSource_ROTA.SelectParameters["Grupo"].DefaultValue = grupo.ToString();
                   DropDownList_GRUPO.SelectedValue = grupo.ToString();

                   if (!String.IsNullOrEmpty(Request.QueryString["Rota"]))
                   {
                       List<Ligacoes> listaCritica = LigacoesFlow.RetornaRotas((int)grupo);
                       int indexRota = listaCritica.FindIndex(delegate(Ligacoes l) { return l.Rota == rota; });
                       if (indexRota > 0)
                          DropDownList_ROTA.SelectedValue = Request.QueryString["Rota"];
                   }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
            ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Ocorreu um erro na aplicação.');", true);
        }
    }

    /// <summary>
    ///  Evento botão primeiro
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Primeiro_Click(object sender, EventArgs e)
    {
        DateTime? referencia = null;
        int? grupo = null;
        int? rota = null;

        try
        {

            if (!String.IsNullOrEmpty(TextGrupo.Text))
            {
                grupo = int.Parse(TextGrupo.Text);
            }

            if (!String.IsNullOrEmpty(TextReferencia.Text))
            {
                referencia = DateTime.Parse(TextReferencia.Text, CultureInfo.GetCultureInfo("pt-br").DateTimeFormat); 
              
                TextReferencia.Text = String.Format("{0:dd/MM/yyyy}", referencia);
            }

            if (!String.IsNullOrEmpty(TextRota.Text))
            {
                rota = int.Parse(TextRota.Text);
            }

            List<Critica> listaVoltaLeitura = VoltaLeituraFlow.ListaCritica(null,null, grupo, referencia);
            if (listaVoltaLeitura.Count > 0)
            {
                this.CarregaDados(listaVoltaLeitura[0].CDC, referencia.ToString());
                this.RetornaDados(listaVoltaLeitura[0].CDC);
            }
        }
        catch (Exception ex)
        {
            throw ex;
            ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Ocorreu um erro na aplicação.\n');", true);
        }
    }

    /// <summary>
    ///  Evento botão anterior
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Anterior_Click(object sender, EventArgs e)
    {
        DateTime? referencia = null;
        int? grupo = null;
        int? rota = null;

        try
        {

            if (!String.IsNullOrEmpty(TextGrupo.Text))
            {
                grupo = int.Parse(TextGrupo.Text);
            }

            if (!String.IsNullOrEmpty(TextReferencia.Text))
            {
                referencia = DateTime.Parse(TextReferencia.Text.ToString());
                TextReferencia.Text = String.Format("{0:dd/MM/yyyy}", referencia);
            }

            if (!String.IsNullOrEmpty(TextRota.Text))
            {
                rota = int.Parse(TextRota.Text);
            }

            List<Critica> listaVoltaLeitura = VoltaLeituraFlow.ListaCritica(null,null, grupo, referencia);
            if (listaVoltaLeitura.Count > 0)
            {
                int indice = listaVoltaLeitura.FindIndex(delegate(Critica l) { return l.CDC == int.Parse(TextCDC.Text.ToString()); });

                if ((indice - 1) >= 0)
                {
                    this.CarregaDados(listaVoltaLeitura[indice - 1].CDC, referencia.ToString());
                    this.RetornaDados(listaVoltaLeitura[indice - 1].CDC);
                }
                else if (indice >= 0)
                {
                    this.CarregaDados(listaVoltaLeitura[indice].CDC, referencia.ToString());
                    this.RetornaDados(listaVoltaLeitura[indice].CDC);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Nenhum dado foi retornado.');", true);
            }
        }catch(Exception ex)
        {
            throw ex; 
            ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Ocorreu um erro na aplicação.');", true);
        }
    }

    /// <summary>
    ///  Evento botão proximo
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Proximo_Click(object sender, EventArgs e) 
    {
        DateTime? referencia = null;
        int? grupo = null;
        int? rota = null;

        try
        {
            
            if (!String.IsNullOrEmpty(TextGrupo.Text))
            {
                grupo = int.Parse(TextGrupo.Text);
            }

            if (!String.IsNullOrEmpty(TextReferencia.Text))
            {
                referencia = DateTime.Parse(TextReferencia.Text.ToString());
            }

            if (!String.IsNullOrEmpty(TextRota.Text))
            {
                rota = int.Parse(TextRota.Text);
            }

            List<Critica> listaVoltaLeitura = VoltaLeituraFlow.ListaCritica(null, rota, grupo, referencia);
            if (listaVoltaLeitura.Count > 0 && listaVoltaLeitura != null)
            {
                int indice = listaVoltaLeitura.FindIndex(delegate(Critica l) { return l.CDC == int.Parse(TextCDC.Text.ToString()); });

                if (indice >= 0 && listaVoltaLeitura.Count() > indice + 1)
                {
                    this.CarregaDados(listaVoltaLeitura[indice + 1].CDC, referencia.ToString());
                    this.RetornaDados(listaVoltaLeitura[indice + 1].CDC);
                }
                else if (listaVoltaLeitura.Count() > indice && indice >= 0)
                {
                    this.CarregaDados(listaVoltaLeitura[indice].CDC, referencia.ToString());
                    this.RetornaDados(listaVoltaLeitura[indice].CDC);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Nenhum dado foi retornado.');", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
            ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Ocorreu um erro na aplicação.');", true);
        }
    }

    /// <summary>
    ///  Evento botão ultimo
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Ultimo_Click(object sender, EventArgs e)
    {
        DateTime? referencia = null;
        int? grupo = null;
        int? rota = null;

        try
        {

            if (!String.IsNullOrEmpty(TextGrupo.Text))
            {
                grupo = int.Parse(TextGrupo.Text);
            }

            if (!String.IsNullOrEmpty(TextReferencia.Text))
            {
                referencia = DateTime.Parse(TextReferencia.Text.ToString());
                TextReferencia.Text = String.Format("{0:dd/MM/yyyy}", referencia);
            }

            if (!String.IsNullOrEmpty(TextRota.Text))
            {
                rota = int.Parse(TextRota.Text);
            }

            List<Critica> listaVoltaLeitura = VoltaLeituraFlow.ListaCritica(null,null, grupo, referencia);

            if (listaVoltaLeitura.Count > 0)
            {
                this.CarregaDados(listaVoltaLeitura[listaVoltaLeitura.Count - 1].CDC, referencia.ToString());
                this.RetornaDados(listaVoltaLeitura[listaVoltaLeitura.Count - 1].CDC);
            }
        }
        catch (Exception ex)
        {
            throw ex;
            ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Ocorreu um erro na aplicação.\n');", true);
        }
    }

    /// <summary>
    ///  Seta os dados na view
    /// </summary>
    /// <param name="parametroCDC"></param>
    protected void RetornaDados(int parametroCDC)
    {
        List<Critica> listaVoltaLeituraAUX = new List<Critica>();
        List<CategoriaONP> listaCategoria = new List<CategoriaONP>();

        // Campo Grupo
        if (ligacoes.Grupo != 0)
            if (DropDownList_GRUPO.Items.FindByValue(ligacoes.Grupo.ToString()) != null)
                DropDownList_GRUPO.SelectedValue = ligacoes.Grupo.ToString();
        
        // Campo Rota
        if (ligacoes.Grupo != 0)
            ObjectDataSource_ROTA.SelectParameters["Grupo"].DefaultValue = ligacoes.Grupo.ToString();

        if (ligacoes.Rota != 0)
            if(DropDownList_ROTA.Items.FindByValue(ligacoes.Rota.ToString()) != null)
                DropDownList_ROTA.SelectedValue = ligacoes.Rota.ToString();

        // Campo CDC
        if (parametroCDC != 0)
            TextCDC.Text = parametroCDC.ToString();
        else
            TextCDC.Text = "";

        // Campo sequencia
        if (ligacoes.Sequencia > 0)
            TextSequencia.Text = ligacoes.Sequencia.ToString();

        // Campo para analize
        if(voltaLeitura.Grupo != 0)
            listaVoltaLeituraAUX = VoltaLeituraFlow.ListaCritica(null,null,voltaLeitura.Grupo, voltaLeitura.Referencia);

        if (listaVoltaLeituraAUX.Count() > 0)
        {
            LabelAnalizeValor1.Text = listaVoltaLeituraAUX.Count.ToString();
        }

        // Campo Fatuar 
        if (voltaLeitura.Flag_Faturado == "S")
            CheckBoxFatuar.Checked = true;

        // Campo Repasse
        if (voltaLeitura.Flag_Repasse == "S")
            CheckBoxRepasse.Checked = true;

        // Grid de matriculas relacionadas
        ObjectDataSource_LIGACOES.SelectParameters["CDC"].DefaultValue = parametroCDC.ToString();

        // Campo Nome
        if (ligacoes.Nome != null)
            TextNome.Text = ligacoes.Nome.ToString();
        else
            TextNome.Text = "";

        // Campo Logradouro
        if (ligacoes.Numero_Imovel != null)
            TextEndereco.Text = logradouro.Nome.ToString() + ", " + ligacoes.Numero_Imovel.ToString();
        else
            TextEndereco.Text = "";

        // Campo Categoria
        listaCategoria = CategoriaFlow.ListaCategoria(ligacoes.Categoria_Imovel);

        if (listaCategoria.Count > 0)
        {
            if (listaCategoria[0].des_categoria != null)
                TextCategoria.Text = listaCategoria[0].des_categoria.ToString();
            else
                TextCategoria.Text = "";
        }

        // Campo Natureza da Ligação
        if (ligacoes.Extend_Natureza_Ligacao != null)
            TextNatureza.Text = ligacoes.Extend_Natureza_Ligacao.ToString();
        else
            TextNatureza.Text = "";

        // Grid Historico de consumo
        ObjectDataSource_HISTORICO.SelectParameters["CDC"].DefaultValue = parametroCDC.ToString();

        // Campo categoria residencial
        if (ligacoes.Eco_Res != null)
            TextRes.Text = ligacoes.Eco_Res.ToString();
        else
            TextRes.Text = "";

        // Campo categoria social
        if (ligacoes.Eco_Soc != null)
            TextSoc.Text = ligacoes.Eco_Soc.ToString();
        else
            TextSoc.Text = "";

        // Campo categoria industrial
        if (ligacoes.Eco_Ind != null)
            TextInd.Text = ligacoes.Eco_Ind.ToString();
        else
            TextInd.Text = "";

        // Campo categoria comercial
        if (ligacoes.Eco_Com != null)
            TextCom.Text = ligacoes.Eco_Com.ToString();
        else
            TextCom.Text = "";

        // Campo categoria publica
        if (ligacoes.Eco_Pub != null)
            TextPub.Text = ligacoes.Eco_Pub.ToString();
        else
            TextPub.Text = "";

        // Campo categoria assistencial
        TextAssist.Text = ""; //ligacoes.Eco_a.ToString(); (VERIFICAR CAMPO)

        // Campo Media
        if (ligacoes.Media != null)
            TextMedia.Text = ligacoes.Media.ToString();
        else
            TextMedia.Text = "";

        if (historicoConsumo != null)
        {
            // Campo Leitura Anterior
            if (historicoConsumo.Leitura > 0)
                TextLeituraAnterior.Text = historicoConsumo.Leitura.ToString();
            else
                TextLeituraAnterior.Text = "";

            // Campo Data
            if (historicoConsumo.Data_Leitura != null)
                //TextData.Text = String.Format("{0:dd/MM/yyyy}", historicoConsumo.Data_Leitura);
                TextData.Text = historicoConsumo.Data_Leitura.ToString("d", culture);
            else
                TextData.Text = "";
        }

        // Campo Hidrometro
        if (ligacoes.Medidor != null)
            TextHidrometro.Text = ligacoes.Medidor.ToString();
        else
            TextHidrometro.Text = "";

        // Campo Quantidade de ponteiros
        if (ligacoes.Qtde_Ponteiros != null)
            TextNumeroPonteiros.Text = ligacoes.Qtde_Ponteiros.ToString();
        else
            TextNumeroPonteiros.Text = "";

        // Campo Status da ligação
        if (ligacoes.Bloqueado != null)
        {
            if (ligacoes.Bloqueado.ToString() == "L")
                TextInstalacao.Text = "Liberada";
            else
                TextInstalacao.Text = "Bloqueada";
        }

        // Campo bloqueado
        if (ligacoes.Data_Bloqueio != null)
            //TextBloqueio.Text = String.Format("{0:dd/MM/yyyy}", ligacoes.Data_Bloqueio);
            TextBloqueio.Text = DateTime.Parse(ligacoes.Data_Bloqueio.ToString()).ToString("d", culture);
        else
            TextBloqueio.Text = "";

        // Campo desbloqueio
        if (ligacoes.Data_DesBloqueio != null)
            //TextDesbloqueio.Text = String.Format("{0:dd/MM/yyyy}", ligacoes.Data_DesBloqueio);
            TextDesbloqueio.Text = DateTime.Parse(ligacoes.Data_DesBloqueio.ToString()).ToString("d", culture);
        else
            TextDesbloqueio.Text = "";

        // Campo dias bloqueio tarifa atual
        if (ligacoes.Dias_Bloqueio_Tarifa_Atual > 0)
            TextAtual.Text = ligacoes.Dias_Bloqueio_Tarifa_Atual.ToString();
        else
            TextAtual.Text = "";

        // Campo dias bloqueio tarifa anterior
        if (ligacoes.Dias_Bloqueio_Tarifa_Ant > 0)
            TextAnterior.Text = ligacoes.Dias_Bloqueio_Tarifa_Ant.ToString();
        else
            TextAnterior.Text = "";

        // Campo data da leitura
        if (voltaLeitura.Data_Leitura != null)
            //TextDataLeitura.Text = String.Format("{0:dd/MM/yyyy}", voltaLeitura.Data_Leitura);
            TextDataLeitura.Text = DateTime.Parse(voltaLeitura.Data_Leitura.ToString()).ToString("d", culture);
        else
            TextDataLeitura.Text = "";

        // Campo dias de consumo
        if (voltaLeitura.Dias_Consumo != null)
            TextDiasConsumo.Text = voltaLeitura.Dias_Consumo.ToString();
        else
            TextDiasConsumo.Text = "";

        // Campo leitura atual
        if (voltaLeitura.Leitura_Real != null)
            TextBoxLeituraAtual.Text = voltaLeitura.Leitura_Real.ToString();
        else
            TextBoxLeituraAtual.Text = "";

        // Campo ocorrencia
        if (voltaLeitura.Ocorrencia != null)
        {
            DropDownList_Anormalidade.SelectedValue = voltaLeitura.Ocorrencia.ToString();
            if (voltaLeitura.Ocorrencia.ToString().Trim() == "" || voltaLeitura.Ocorrencia.ToString().Trim() == "0")
                LabelOcorrencia.Text = "NENHUMA OCORRENCIA";

            if ((voltaLeitura.Ocorrencia.ToString().Trim() == "" || voltaLeitura.Ocorrencia.ToString().Trim() == "0") && voltaLeitura.Ocorrencia2.ToString() != "")
            {
                TextOcorrencia.Text = voltaLeitura.Ocorrencia2.ToString();
                LabelOcorrencia.Text = OcorrenciaFlow.RetornaOcorrencia(voltaLeitura.Ocorrencia2).ToString();
            }
            if (voltaLeitura.Ocorrencia.ToString().Trim() != "" && voltaLeitura.Ocorrencia.ToString().Trim() != "0")
            {
                TextOcorrencia.Text = voltaLeitura.Ocorrencia.ToString();
                LabelOcorrencia.Text = OcorrenciaFlow.RetornaOcorrencia(voltaLeitura.Ocorrencia).ToString();
            }
        }
        else
        {
            DropDownList_Anormalidade.SelectedValue = "0";
        }

        // Campo de referencia
        if (voltaLeitura.Referencia != null)
            //Referencia.Text = String.Format("{0:dd/MM/yyyy}", voltaLeitura.Referencia);
            Referencia.Text = DateTime.Parse(voltaLeitura.Referencia.ToString()).ToString("d", culture);
        else
            Referencia.Text = "";

        // Campo consumo medido
        if (voltaLeitura.Leitura_Real != null)
            if (historicoConsumo.Leitura > 0 && voltaLeitura.Leitura_Real > 0)
                TextConsumoMedido.Text = (voltaLeitura.Leitura_Real - historicoConsumo.Leitura).ToString();
            else
                if (voltaLeitura.Consumo_Ajustado != null)
                    TextConsumoMedido.Text = voltaLeitura.Consumo_Ajustado.ToString();
                else
                    TextConsumoMedido.Text = "";

        // Campo consumo ajustado
        if (voltaLeitura.Consumo_Ajustado != null)
                TextConsumoAjustado.Text = voltaLeitura.Consumo_Ajustado.ToString();
        else
            TextConsumoAjustado.Text = "";

        if (historicoConsumo != null)
        {
            // Campo que informa o percentual entre as medidas
            if (voltaLeitura.Leitura_Real != null)
            {
                float percentualConsumo;
                if (historicoConsumo.Leitura > voltaLeitura.Leitura_Real)
                {
                    percentualConsumo = (float.Parse(voltaLeitura.Leitura_Real.ToString()) / float.Parse(historicoConsumo.Leitura.ToString()));
                    TextBox3.Text = "Redução de consumo de " + String.Format("0{0}", percentualConsumo.ToString("##.###")) + "%";
                }
                if (historicoConsumo.Leitura < voltaLeitura.Leitura_Real)
                {
                    percentualConsumo = (float.Parse(historicoConsumo.Leitura.ToString()) / float.Parse(voltaLeitura.Leitura_Real.ToString()));
                    TextBox3.Text = "Acréscimo de consumo de " + String.Format("0{0}", percentualConsumo.ToString("##.###")) + "%";
                }
            }
        }

        if (voltaLeitura.Flag_Faturado == "S")
            CheckBoxFatuar.Checked = true;
        else
            CheckBoxFatuar.Checked = false;

        if (voltaLeitura.Flag_Repasse == "S")
            CheckBoxRepasse.Checked = true;
        else
            CheckBoxRepasse.Checked = false;
    }

    /// <summary>
    ///  Metodo que alimenta os objetos de retorno
    /// </summary>
    /// <param name="parametroCDC"></param>
    protected void CarregaDados(int parametroCDC, string referenciaString)
    {
        try
        {
            // Retorna os dados de ligações
            listaLigacoes = LigacoesFlow.RetornaLigacoes(parametroCDC);
            if (listaLigacoes.Count > 0)
            {
                ligacoes = listaLigacoes[0];
            }
            else
            {
                ligacoes = new Ligacoes();
            }

            // Retorna os dados de logradouro
            listaLogradouro = LogradouroIDAFlow.ListaLogradouro(listaLigacoes);
            if (listaLogradouro.Count > 0)
            {
                logradouro = listaLogradouro[0];
            }
            else
            {
                logradouro = new LogradouroIDA();
            }

            // Retorna os dados de leitura
            listaVoltaLeitura = VoltaLeituraFlow.Lista(parametroCDC);
            if (listaVoltaLeitura.Count > 0)
            {
                voltaLeitura = listaVoltaLeitura[0];
            }
            else
            {
                voltaLeitura = new VoltaLeitura();
            }

            // Retorna os dados do historico 
            listaHistoricoConsumo = new List<HistoricoConsumoIDA>();

            listaHistoricoConsumo = HistoricoConsumoIDAFlow.Lista(parametroCDC);

            DateTime referenciaAnterior;

            // Verifica se a data foi informada
            if (!String.IsNullOrEmpty(referenciaString))
            {
                // Valida a data informada e a minima para o sql server
                if (DateTime.Parse(referenciaString).Year > 1753)
                {
                    // Retorna a referencia do mes anterior
                    referenciaAnterior = HistoricoConsumoIDAFlow.getReferenciaAnterior(DateTime.Parse(referenciaString), parametroCDC);

                    // Busca dados do historico de consumo
                    listaHistoricoConsumo = listaHistoricoConsumo.FindAll(delegate(HistoricoConsumoIDA H) { return H.Referencia == referenciaAnterior; });

                    if (listaHistoricoConsumo.Count > 0)
                    {
                        historicoConsumo = listaHistoricoConsumo[0];
                    }
                    else
                    {
                        historicoConsumo = new HistoricoConsumoIDA();
                    }
                }
            }
            else
            {
                if (listaHistoricoConsumo.Count > 0)
                {
                    referenciaAnterior = listaHistoricoConsumo[0].Referencia;
                    historicoConsumo = listaHistoricoConsumo[0];
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    ///  Metodo que salva os dados no banco
    /// </summary>
    /// <param name="RadioButton1"></param>
    /// <param name="RadioButton2"></param>
    /// <param name="RadioButton3"></param>
    /// <param name="CDC"></param>
    /// <param name="ocorrencia"></param>
    /// <param name="novaLeitura"></param>
    /// <param name="consumoAjustado"></param>
    /// <param name="dataLeituraString"></param>
    /// <param name="faturado"></param>
    /// <param name="repasse"></param>
    /// <returns></returns>
    //[System.Web.Services.WebMethod] // OBSOLETO METODO SALVAR VIA AJAX (SERVIDOR NÂO DAVA PERMISSAO)
    public static bool Salvar(int CDC, int ocorrencia,string historicoDataLeitura, int leituraAnterior, int leituraAtual, int consumoAjustado, string dataLeituraString, bool faturado, bool repasse)
    {
        CultureInfo cultureEN = new CultureInfo("en-US");
        VoltaLeitura voltaLeitura = new VoltaLeitura();
        int retornoUpdateHistorico = 0;
        bool retorno = false;

        if (CDC > 0)
        {
            try
            {
                // Retorna os dados de leitura
                List<VoltaLeitura> listaVoltaLeitura = VoltaLeituraFlow.Lista(CDC);

                // Retorna os dados de ligações
                List<Ligacoes> listaLigacoes = LigacoesFlow.Lista(CDC);

                // Verifica se existe leitura
                if (listaVoltaLeitura.Count > 0)
                {

                    // Se existe mais de uma leitura
                    if (listaVoltaLeitura.Count > 1)
                    {
                        // Verifica se existe registros duplicados
                        List<VoltaLeitura> listaVoltaLeituraAUX = listaVoltaLeitura.FindAll(delegate(VoltaLeitura voltaleitura) {return (voltaleitura.CDC == listaVoltaLeitura[0].CDC && voltaleitura.Referencia == listaVoltaLeitura[0].Referencia); });
                        
                        // Se existe registro duplicados deleta todos e insere apenas um registro
                        if (listaVoltaLeituraAUX.Count > 1)
                        {
                            VoltaLeituraDAO voltaLeituraDAO = new VoltaLeituraDAO();
                            voltaLeituraDAO.Delete(listaVoltaLeitura[0]);
                            voltaLeituraDAO.Insert(listaVoltaLeitura[0]);
                        }
                    }

                    // Adicioana os dados informados na tela
                    if (ocorrencia > 0)
                        listaVoltaLeitura[0].Ocorrencia = ocorrencia;
                    if (leituraAtual > 0)
                        listaVoltaLeitura[0].Leitura_Real = leituraAtual;
                    if (!String.IsNullOrEmpty(dataLeituraString))
                    {
                        if (System.Globalization.CultureInfo.CurrentCulture.ToString() == "en-US" && System.Globalization.CultureInfo.CurrentUICulture.ToString() == "en-US" && System.Globalization.CultureInfo.InstalledUICulture.ToString() == "en-US")
                        {
                            DateTime dataAUX = DateTime.Parse(dataLeituraString, culture);
                            listaVoltaLeitura[0].Data_Leitura = DateTime.Parse(dataAUX.Month + "/" + dataAUX.Day + "/" + dataAUX.Year, cultureEN);// DATA DA LEITURA PARA EN
                        }
                        else
                            listaVoltaLeitura[0].Data_Leitura = DateTime.Parse(dataLeituraString, culture);// DATA DA LEITURA PARA PT
                    }
                    if (consumoAjustado > 0)
                    listaVoltaLeitura[0].Consumo_Ajustado = consumoAjustado;
                    listaVoltaLeitura[0].Esgoto_Ajustado = consumoAjustado;
                    listaVoltaLeitura[0].Flag_Calculo = "N";
                    listaVoltaLeitura[0].Dias_Consumo = 31; //VALOR FIXO NO ONPLACE

                    if (faturado)
                        listaVoltaLeitura[0].Flag_Faturado = "S";
                    else
                        listaVoltaLeitura[0].Flag_Faturado = "N";

                    if (repasse)
                        listaVoltaLeitura[0].Flag_Repasse = "S";
                    else
                        listaVoltaLeitura[0].Flag_Repasse = "N";

                    retorno = VoltaLeituraFlow.Updater(listaVoltaLeitura);

                    if(leituraAnterior != 0 && retorno != false)
                    {
                        if (!String.IsNullOrEmpty(historicoDataLeitura))
                        {
                            DateTime historicoDataLeituraAUX = DateTime.Parse(historicoDataLeitura);
                            DateTime historicoDataLeituraAUX2 = new DateTime(historicoDataLeituraAUX.Year, historicoDataLeituraAUX.Month, 1);
                            string where = String.Format("CDC = {0} AND Referencia = CONVERT(DATETIME,'{1}',103)", listaVoltaLeitura[0].CDC, historicoDataLeituraAUX2.ToString());
                            List<HistoricoConsumoIDA> listaHistorioco = new HistoricoConsumoIDADAO().Select(where);
                            if (listaHistorioco.Count > 0)
                            {
                                if (listaHistorioco[0].Leitura != leituraAnterior)
                                {
                                    listaHistorioco[0].Leitura = leituraAnterior;
                                    retornoUpdateHistorico = new HistoricoConsumoIDADAO().Update(listaHistorioco[0]);
                                    if (retornoUpdateHistorico < 1)
                                        retorno = false;
                                }
                            }
                        }
                    }
   
                }else{ // Se não existem registros

                    // Adicioana os dados informados na tela
                    voltaLeitura.CDC = CDC;
                    voltaLeitura.Referencia = DateTime.Parse(dataLeituraString);
                    voltaLeitura.Ocorrencia = ocorrencia;
                    voltaLeitura.Leitura_Real = leituraAtual;
                    if (!String.IsNullOrEmpty(dataLeituraString))
                    {
                        if (System.Globalization.CultureInfo.CurrentCulture.ToString() == "en-US" && System.Globalization.CultureInfo.CurrentUICulture.ToString() == "en-US" && System.Globalization.CultureInfo.InstalledUICulture.ToString() == "en-US")
                        {
                            DateTime dataAUX = DateTime.Parse(dataLeituraString, culture);
                            listaVoltaLeitura[0].Data_Leitura = DateTime.Parse(dataAUX.Month + "/" + dataAUX.Day + "/" + dataAUX.Year, cultureEN);// DATA DA LEITURA PARA EN
                        }
                        else
                            listaVoltaLeitura[0].Data_Leitura = DateTime.Parse(dataLeituraString, culture);// DATA DA LEITURA PARA PT
                    }
                    voltaLeitura.Consumo_Ajustado = consumoAjustado;
                    voltaLeitura.Esgoto_Ajustado = consumoAjustado;
                    voltaLeitura.Flag_Calculo = "N";
                    voltaLeitura.Ident_fraude = "";
                    voltaLeitura.Indic_cortado = "";
                    voltaLeitura.Flag_Emissao = "";
                    voltaLeitura.Dias_Consumo = 31; //VALOR FIXO NO ONPLACE
                    voltaLeitura.Ocorrencia = ocorrencia;

                    if (listaLigacoes.Count() > 0)
                    {
                        // Adiciona os dados de leitura
                        voltaLeitura.Grupo = listaLigacoes[0].Grupo;
                        voltaLeitura.Setor = listaLigacoes[0].Setor;
                        voltaLeitura.Rota = listaLigacoes[0].Rota;
                        voltaLeitura.Categoria = listaLigacoes[0].Categoria_Imovel;
                        voltaLeitura.Eco_Com = int.Parse(listaLigacoes[0].Eco_Com.ToString());
                        voltaLeitura.Eco_Ind = int.Parse(listaLigacoes[0].Eco_Ind.ToString());
                        voltaLeitura.Eco_Pub = int.Parse(listaLigacoes[0].Eco_Pub.ToString());
                        voltaLeitura.Eco_Res = int.Parse(listaLigacoes[0].Eco_Res.ToString());
                        voltaLeitura.Eco_Soc = int.Parse(listaLigacoes[0].Eco_Soc.ToString());
                    }

                    if (faturado)
                        voltaLeitura.Flag_Faturado = "S";
                    else
                        voltaLeitura.Flag_Faturado = "N";

                    if (repasse)
                        voltaLeitura.Flag_Repasse = "S";
                    else
                        voltaLeitura.Flag_Repasse = "N";

                    retorno = VoltaLeituraFlow.InsertLeituraBloqueada(voltaLeitura);

                    if (leituraAnterior != 0 && retorno != false)
                    {
                        string where = String.Format("CDC = {0} AND Referencia = CONVERT(DATETIME,'{1}',103) AND Data_Leitura = CONVERT(DATETIME,'{2}',103)", listaVoltaLeitura[0].CDC, listaVoltaLeitura[0].Referencia.ToString(), historicoDataLeitura);
                        List<HistoricoConsumoIDA> listaHistorioco = new HistoricoConsumoIDADAO().Select(where);
                        if (listaHistorioco.Count > 0)
                        {
                            listaHistorioco[0].Leitura = leituraAnterior;
                            retornoUpdateHistorico = new HistoricoConsumoIDADAO().Update(listaHistorioco[0]);
                            if (retornoUpdateHistorico < 1)
                                retorno = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return retorno;
    }
    
    /// <summary>
    ///  Mareta para inverter a lista (INUTILIZADA)
    /// </summary>
    /// <param name="lista"></param>
    /// <returns></returns>
    protected List<Ligacoes> RevertLista(List<Ligacoes> lista)
    {
        List<Ligacoes> listaSaida = new List<Ligacoes>();

        foreach (Ligacoes item in lista)
        {
            listaSaida.Add(item);
        }
        return listaSaida;
    }

    /// <summary>
    /// Salva os dados
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonSalvar_Click(object sender, EventArgs e)
    {
        int CDC = (String.IsNullOrEmpty(TextCDC.Text) ? 0 : int.Parse(TextCDC.Text));
        int ocorrencia = (String.IsNullOrEmpty(DropDownList_Anormalidade.SelectedValue) ? 0 : int.Parse(DropDownList_Anormalidade.SelectedValue));
        string historicoDataLeitura = TextData.Text;
        int leituraAnterior = (String.IsNullOrEmpty(TextLeituraAnterior.Text) ? 0 : int.Parse(TextLeituraAnterior.Text));
        int leituraAtual = (String.IsNullOrEmpty(TextBoxLeituraAtual.Text) ? 0 : int.Parse(TextBoxLeituraAtual.Text));
        int consumoAjustado = (String.IsNullOrEmpty(HiddenFieldConsumoAjustado.Value) ? 0 : int.Parse(HiddenFieldConsumoAjustado.Value));
        string dataLeituraString = TextDataLeitura.Text;
        bool faturado = CheckBoxFatuar.Checked;
        bool repasse = CheckBoxRepasse.Checked;

        bool retorno = Salvar(CDC, ocorrencia, historicoDataLeitura, leituraAnterior, leituraAtual, consumoAjustado, dataLeituraString, faturado, repasse);

        if (retorno)
        {
            ClientScript.RegisterStartupScript(typeof(string), "mensagem", "alert('Dados atualizados.');", true);
        }
    }

    /// <summary>
    ///  Retorna a descriação da ocorrencia (OBSOLETO)
    /// </summary>
    /// <param name="codOcorrencia"></param>
    /// <returns></returns>
    //[System.Web.Services.WebMethod]
    //public static string RetornaOcorrencia(int codOcorrencia)
    //{
    //    return OcorrenciaFlow.RetornaOcorrencia(codOcorrencia);
    //}
}
