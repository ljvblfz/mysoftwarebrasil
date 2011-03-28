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
                //syncThread.Start();

                string dataBase = SQLHelper.Instance.Compacta();

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
        int indiceFatura = 0;

        DateTime referenciaAUX = referencia;

        // Nome do arquivo do banco de dados
        string dataBaseName = "OnPlace_"
                                + "_" + this.grupo
                                + "_" + this.rota
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
        pda.usuario = this.agente;
        pda.coletor = "CARGA OFFLINE";

        // Objeto de retorno dos dados
        DataBase bancoMovel = new DataBase();

        // Retorna a lista de this.agentes
        List<GeraBase.Model.AgenteONP> agente = bancoMovel.ListaAgente(this.grupo, pda);

        List<GeraBase.Model.FaturaCategoriaONP> faturaCategoria = bancoMovel.ListaFaturaCategoria(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.AvisoDebito> avisoDebito = bancoMovel.RetornaAvisoDebito(this.grupo, this.rota, this.rota, pda);

        List<GeraBase.Model.FaturaONP> fatura = bancoMovel.ListaFatura(this.grupo, referenciaAUX, this.rota, this.rota, pda,1);

        List<GeraBase.Model.ServicoFaturaONP> servicoFatura = bancoMovel.ListaServicoFatura(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.FaturaTaxaONP> faturaServico = bancoMovel.ListaFaturaTaxa(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.GrupoONP> grupo = bancoMovel.ListaGrupo(pda);

        List<GeraBase.Model.HidrometroONP> hidrometro = bancoMovel.ListaHidrometro(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.LogradouroONP> logradouro = bancoMovel.ListaLogradouro(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.MatriculaDiademaONP> matriculaDiadema = bancoMovel.ListaMatriculaDiadema(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.ReferenciaPendenteONP> referenciaPendente = bancoMovel.ListaReferenciaPendente(this.grupo, this.rota, this.rota, pda);

        List<GeraBase.Model.MatriculaONP> matricula = bancoMovel.ListaMatricula(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.MensagemMovimentoONP> mensagemMovimento = bancoMovel.ListaMensagemMovimento(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.MovimentoONP> movimento = bancoMovel.ListaMovimento(this.grupo, referenciaAUX, this.rota, this.rota,this.agente, pda,1);

        List<GeraBase.Model.MovimentoCategoriaONP> movimentoCategoria = bancoMovel.ListaMovimentoCategoria(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.MovimentoTaxaONP> movimentoTaxa = bancoMovel.ListaMovimentoTaxa(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.QualidadeAguaONP> qualidadeAgua = bancoMovel.ListaQualidadeAgua(this.grupo, pda);

        List<GeraBase.Model.RoteiroONP> roteiro = bancoMovel.ListaRoteiro(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.TaxaTarifaFaixaONP> taxaTarifaFaixa = bancoMovel.ListaTaxaTarifaFaixa(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.TaxaTarifaONP> taxaTarifa = bancoMovel.ListaTaxaTarifa(this.grupo, pda);

        List<GeraBase.Model.GrupoFaturaONP> grupoFatura = bancoMovel.ListaGrupoFatura(this.grupo, pda);

        List<GeraBase.Model.MatriculaCargaONP> matriculaCarga = bancoMovel.ListaMatriculaCarga(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.FaturasAvisoONP> faturaAviso = bancoMovel.ListaFaturasAviso(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.HistoricoONP> historico = bancoMovel.ListaHistorico(this.grupo, referenciaAUX, this.rota, this.rota, pda);

        List<GeraBase.Model.CategoriaONP> categoria = bancoMovel.ListaCategoria(pda);

        List<GeraBase.Model.DescontoDiademaONP> descontoDiadema = bancoMovel.ListaDescontoDiadema(pda);

        List<GeraBase.Model.ImpostoDiademaONP> impostoDiadema = bancoMovel.ListaImpostoDiadema(pda);

        List<GeraBase.Model.LocalizacaoHidrometroONP> localizacaoHidrometro = bancoMovel.ListaLocalizacaoHidrometro(pda);

        List<GeraBase.Model.OcorrenciaONP> ocorrencia = bancoMovel.ListaOcorrencia(pda);

        List<GeraBase.Model.ParametroONP> parametro = bancoMovel.ListaParametro(pda);

        List<GeraBase.Model.ParametroRentencaoONP> parametroRetencao = bancoMovel.ListaParametroRentencao(pda);

        List<GeraBase.Model.TaxaONP> taxa = bancoMovel.ListaTaxa(pda);

        List<GeraBase.Model.TipoEntregaONP> tipoEntrega = bancoMovel.ListaTipoEntrega(pda);

        List<GeraBase.Model.TabelaCargaONP> tabelaCarga = bancoMovel.ListaTabelasCarga(pda);

        List<GeraBase.Model.UtilizacaoLigacaoONP> utilizacaoLigacao = bancoMovel.ListaUtilizacaoLigacao();
        


        GenericDAO<GeraBase.Model.AgenteONP> objAgente = new GenericDAO<GeraBase.Model.AgenteONP>();
        objAgente.LimpaBanco();
        //objthis.agente.Insert(listathis.agente.ToArray(), "ONP_this.agente", null);

        // Insere os dados no banco do PDA
        new InsertCarga<GeraBase.Model.CategoriaONP>().Gravar("ONP_CATEGORIA", categoria, null);

        new InsertCarga<GeraBase.Model.AgenteONP>().Gravar("ONP_AGENTE", agente, null);

        new InsertCarga<GeraBase.Model.GrupoFaturaONP>().Gravar("ONP_GRUPO_FATURA", grupoFatura, null);

        new InsertCarga<GeraBase.Model.MatriculaCargaONP>().Gravar("ONP_MATRICULAS_CARGA", matriculaCarga, null);

        new InsertCarga<GeraBase.Model.MovimentoONP>().Gravar("ONP_MOVIMENTO", movimento, null);

        new InsertCarga<GeraBase.Model.QualidadeAguaONP>().Gravar("ONP_QUALIDADE_AGUA", qualidadeAgua, null);

        new InsertCarga<GeraBase.Model.RoteiroONP>().Gravar("ONP_ROTEIRO", roteiro, null);

        new InsertCarga<GeraBase.Model.FaturaONP>().Gravar("ONP_FATURA", fatura, "seq_fatura");

        int indiceAUX = new InsertCarga<GeraBase.Model.AvisoDebito>().AvisoDebito(avisoDebito.ToArray(), indiceFatura);
        indiceFatura = indiceAUX;

        indiceAUX = new InsertCarga<GeraBase.Model.FaturaCategoriaONP>().FaturaCategoria(faturaCategoria.ToArray(), indiceFatura);
        indiceFatura = indiceAUX;

        indiceAUX = new InsertCarga<GeraBase.Model.FaturasAvisoONP>().FaturaAviso(faturaAviso.ToArray(), indiceFatura);
        indiceFatura = indiceAUX;

        indiceAUX = new InsertCarga<GeraBase.Model.ReferenciaPendenteONP>().ReferenciaPendente(referenciaPendente.ToArray(), indiceFatura);
        indiceFatura = indiceAUX;

        new InsertCarga<GeraBase.Model.HidrometroONP>().Gravar("ONP_HIDROMETRO", hidrometro, null);

        new InsertCarga<GeraBase.Model.HistoricoONP>().Gravar("ONP_HISTORICO", historico, null);

        new InsertCarga<GeraBase.Model.LogradouroONP>().Gravar("ONP_LOGRADOURO", logradouro, null);

        new InsertCarga<GeraBase.Model.MatriculaONP>().Gravar("ONP_MATRICULA", matricula, null);

        new InsertCarga<GeraBase.Model.MovimentoCategoriaONP>().Gravar("ONP_MOVIMENTO_CATEGORIA", movimentoCategoria, null);

        new InsertCarga<GeraBase.Model.MovimentoTaxaONP>().Gravar("ONP_MOVIMENTO_TAXA", movimentoTaxa, null);

        new InsertCarga<GeraBase.Model.MatriculaDiademaONP>().Gravar("ONP_MATRICULA_DIADEMA", matriculaDiadema, null);

        new InsertCarga<GeraBase.Model.MensagemMovimentoONP>().Gravar("ONP_MENSAGEM_MOVIMENTO", mensagemMovimento, "seq_mensagem_movimento");

        new InsertCarga<GeraBase.Model.TaxaTarifaONP>().Gravar("ONP_TAXA_TARIFA", taxaTarifa, null);

        new InsertCarga<GeraBase.Model.TaxaTarifaFaixaONP>().Gravar("ONP_TAXA_TARIFA_FAIXA", taxaTarifaFaixa, null);

        new InsertCarga<GeraBase.Model.ServicoFaturaONP>().Gravar("ONP_SERVICO_FATURA", servicoFatura, null);

        new InsertCarga<GeraBase.Model.UtilizacaoLigacaoONP>().Gravar("ONP_UTILIZACAO_LIGACAO", utilizacaoLigacao, null);

        new InsertCarga<GeraBase.Model.TipoEntregaONP>().Gravar("ONP_TIPO_ENTREGA", tipoEntrega, null);

        new InsertCarga<GeraBase.Model.DescontoDiademaONP>().Gravar("ONP_DESCONTO_DIADEMA", descontoDiadema, null);

        new InsertCarga<GeraBase.Model.ImpostoDiademaONP>().Gravar("ONP_IMPOSTO_DIADEMA", impostoDiadema, null);

        new InsertCarga<GeraBase.Model.LocalizacaoHidrometroONP>().Gravar("ONP_LOCALIZACAO_HIDROMETRO", localizacaoHidrometro, null);

        new InsertCarga<GeraBase.Model.OcorrenciaONP>().Gravar("ONP_OCORRENCIA", ocorrencia, null);

        new InsertCarga<GeraBase.Model.ParametroONP>().Gravar("ONP_PARAMETRO", parametro, null);

        new InsertCarga<GeraBase.Model.ParametroRentencaoONP>().Gravar("ONP_PARAMETRO_RETENCAO", parametroRetencao, null);

        new InsertCarga<GeraBase.Model.TaxaONP>().Gravar("ONP_TAXA", taxa, null);
    }

}
