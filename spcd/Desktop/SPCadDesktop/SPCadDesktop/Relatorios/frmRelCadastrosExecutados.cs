using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPCadDesktopData.Data.Model;
using SPCadDesktopData.Data;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using SPCadDesktopData.Data.Model.Relatorio;

namespace SPCadDesktop.Relatorios
{
    public partial class frmRelCadastrosExecutados : Form
    {
        // Tipos de relatorio para este formulario.
        // 1 - Cadastros Executados.
        // 2 - Fonte Alternativa não cadastrada
        // 3 - Alteração cadastral
        private int tipoRelatorio;

        public frmRelCadastrosExecutados(int tipoRelatorio)
        {
            InitializeComponent();
            this.tipoRelatorio = tipoRelatorio;
            cboDistrito.DataSource = SingletonFlow.distritoFlow.getListDistrito();
            cboSituacao.DataSource = SituacaoPesqiosaCombo.getList();
            cboFuncionario.DataSource = ListFuncionario.getList(true);
            mtbxDataIni.Text = DateTime.Now.ToString("dd/MM/yyyy");
            mtbxDataFim.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Altera o titulo do relatorio
            switch(tipoRelatorio)
            {
                case 1:
                {
                    Text = "Relatorio de Cadastros Executados";
                    break;
                }
                case 2:
                {
                    Text = "Relatorio de Fonte Alternativa não cadastrada";
                    break;
                }
                case 3:
                {
                    Text = "Relatorio de Alteração cadastral";
                    break;
                }
                default:
                {
                    Text = "";
                    break;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Muda para a ampulheta
            Cursor.Current = Cursors.WaitCursor;

            int numParameters = 0, distrito = 0, setor = 0, rota = 0;
            DateTime dtIni;
            DateTime dtFim;
            string reportName = "";
            string modelName = "";

            if (!DateTime.TryParse(mtbxDataIni.Text, out dtIni))
            {
                MessageBox.Show("Data inicio inválida");
                return;
            }

            if (!DateTime.TryParse(mtbxDataFim.Text, out dtFim))
            {
                MessageBox.Show("Data final inválida");
                return;
            }

            if (tbxRota.Text != string.Empty)
            {
                if (!int.TryParse(tbxRota.Text, out rota))
                {
                    MessageBox.Show("Rota inválida");
                    return;
                }
            }

            if (tbxRota.Text != string.Empty)
            {
                if (!int.TryParse(tbxRota.Text, out rota))
                {
                    MessageBox.Show("Rota inválida");
                    return;
                }
            }
            if (tbxSetor.Text != string.Empty)
            {
                if (!int.TryParse(tbxSetor.Text, out setor))
                {
                    MessageBox.Show("Setor inválido");
                    return;
                }
            }

            if (cboDistrito.SelectedValue.ToString() != "S")
            {
                if (!int.TryParse(cboDistrito.SelectedValue.ToString(), out distrito))
                {
                    MessageBox.Show("Distrito inválido");
                    return;
                }
            }

            string sqlAdd = "";
            if (((SituacaoPesqiosaEnum)cboSituacao.SelectedValue) == SituacaoPesqiosaEnum.Todos)
                sqlAdd = "((STATUS_EXEC = 1 and (COD_LOTE_EXP <= 0 or COD_LOTE_EXP is null))or COD_LOTE_EXP > 0)";
            if (((SituacaoPesqiosaEnum)cboSituacao.SelectedValue) == SituacaoPesqiosaEnum.Executados)
                sqlAdd = "(STATUS_EXEC = 1 and (COD_LOTE_EXP <= 0 or COD_LOTE_EXP is null))";
            List<Cadastro> cadsAUX = SingletonFlow.cadastroFlow.GetListCadastroByParam(distrito, setor, rota, (int?)cboFuncionario.SelectedValue, (SituacaoPesqiosaEnum)cboSituacao.SelectedValue, new string[0], "", sqlAdd);

            // Filtra remove da lista os items sem fonte alternativa ou os que não possuen fonte
            List<Cadastro> cads = cadsAUX.FindAll(item => item.FonteAlternativa != null || item.FonteAlternativaAlterText.Trim().ToUpper() != "NAO POSSUI FONTE ALTERNATIVA");
            
            List<AlteracaoCadastral> alterCads = null;

            // Verifica se existem dados para geração do relatorio
            if (cads.Count == 0)
            {
                MessageBox.Show("Não há dados para os parâmetros informados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {

                try
                {
                    switch (tipoRelatorio)
                    {
                        case 3:
                            cads = cads.Where(c => c.DataVisita >= dtIni && c.DataVisita <= dtFim).ToList();
                            alterCads = VerificaAlteracaoCadastralList(cads);
                            numParameters = 8;
                            break;
                        case 1:
                            cads = cads.Where(c => c.DataVisita >= dtIni && c.DataVisita <= dtFim).ToList();
                            numParameters = 7;
                            break;
                        case 2:
                            cads = cads.Where(c => c.DataVisita >= dtIni && c.DataVisita <= dtFim && c.FonteAlternativa != c.FonteAlternativaAlter).ToList();
                            numParameters = 7;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //Objeto report 
            LocalReport report = new LocalReport();

            //Objeto parametros 
            ReportParameter[] param = new ReportParameter[numParameters];
            param[0] = new ReportParameter();
            param[0].Name = "DataIni";
            param[0].Values.Add(mtbxDataIni.Text);

            param[1] = new ReportParameter();
            param[1].Name = "DataFim";
            param[1].Values.Add(mtbxDataFim.Text);

            param[2] = new ReportParameter();
            param[2].Name = "Distrito";
            param[2].Values.Add(cboDistrito.SelectedText);

            param[3] = new ReportParameter();
            param[3].Name = "Setor";
            param[3].Values.Add(setor.ToString("00"));

            param[4] = new ReportParameter();
            param[4].Name = "Rota";
            param[4].Values.Add(rota.ToString("00"));

            param[5] = new ReportParameter();
            param[5].Name = "Situacao";
            param[5].Values.Add(cboSituacao.Text);

            param[6] = new ReportParameter();
            param[6].Name = "Cadastrador";
            param[6].Values.Add(cboFuncionario.Text);

            //Caminho do relatório
            switch (tipoRelatorio)
            {
                case 1:
                    report.ReportEmbeddedResource = "SPCadDesktop.Relatorios.Reports.relCadastrosExecutados.rdlc";
                    reportName = "relCadastrosExecutados";
                    modelName = "Cadastro";
                    report.Refresh();
                    report.DataSources.Add(new ReportDataSource(modelName, cads.ToArray()));
                    break;
                case 2:
                    report.ReportEmbeddedResource = "SPCadDesktop.Relatorios.Reports.relFonteAlternativaNaoCadastrada.rdlc";
                    reportName = "relFonteAlternativaNaoCadastrada";
                    modelName = "Cadastro";
                    report.Refresh();
                    report.DataSources.Add(new ReportDataSource(modelName, cads.ToArray()));
                    break;
                case 3:
                    report.ReportEmbeddedResource = "SPCadDesktop.Relatorios.Reports.relAlteracaoCadastral.rdlc";
                    reportName = "relAlteracaoCadastral";
                    modelName = "AlteracaoCadastral";

                    param[7] = new ReportParameter();
                    param[7].Name = "QuantMatricula";
                    param[7].Values.Add(cads.Count.ToString());
                    report.Refresh();

                    report.DataSources.Add(new ReportDataSource(modelName, alterCads.ToArray()));
                    break;
            }

            // Seta os parametros do relatorio
            report.SetParameters(param);

            // Gera o relatorio
            GeraRelatorio(reportName, report, (sender == btnExcel));

            // Volta para o padrão
            Cursor.Current = Cursors.Default;
        }


        private void GeraRelatorio(string nomeRelatorio, LocalReport report, bool excel)
        {
            byte[] bytes;
            report.Refresh();
            Warning[] warnings = null;
            string[] streamids = null;
            string mimeType = null;
            string encoding = null;
            string extension = null;

            //Cria e exibe o relatório em pdf
            try
            {
                FileStream fs = null;
                if (excel)
                {
                    bytes = report.Render("Excel", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                    fs = new FileStream(nomeRelatorio + ".xls", FileMode.Create, FileAccess.ReadWrite);
                }
                else
                {
                    bytes = report.Render("pdf", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                    fs = new FileStream(nomeRelatorio + ".pdf", FileMode.Create, FileAccess.ReadWrite);
                }

                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(bytes);
                bw.Close();

                Process QProc = new Process();
                QProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                QProc.StartInfo.CreateNoWindow = true;

                QProc.StartInfo.FileName = "cmd.exe";
                QProc.StartInfo.Arguments = "/c " + nomeRelatorio + ((excel) ? ".xls" : ".pdf");
                QProc.Start();
                QProc.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private AlteracaoCadastral CriaAlteracaoCadastral(Cadastro cad, string informacao, string vlrAntigo, string vlrNovo, int cont)
        {
            AlteracaoCadastral alterCad;
            //alterCad = new AlteracaoCadastral(cad.CodigoDistrito.ToString(), cad.Setor.ToString(), cad.CodigoRota.ToString(), cad.Matricula.ToString(), cad.NumeroPontoServico, informacao, vlrAntigo, vlrNovo);
            if (cont <= 0)
            {
                alterCad = new AlteracaoCadastral(cad.SiglaDistrito, cad.Setor.ToString(), cad.CodigoRota.ToString(), cad.Matricula.ToString(), cad.NumeroPontoServico, informacao, vlrAntigo, vlrNovo);
            }
            else
            {
                alterCad = new AlteracaoCadastral(informacao, vlrAntigo, vlrNovo);
            }
            return alterCad;
        }

        private List<AlteracaoCadastral> VerificaAlteracaoCadastralList(List<Cadastro> cads)
        {
            List<AlteracaoCadastral> ret = new List<AlteracaoCadastral>();
            int cont, cnn = 0;
            string texto1 = "";
            string texto2 = "";
            foreach (Cadastro item in cads)
            {
                cnn++;
                Console.WriteLine(cnn);
                cont = 0;
                // Faz a validação dos dados redundantes campo a campo.
                if (item.NumeroImovel != item.NumeroImovelAlter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Número do Imóvel", item.NumeroImovel.ToString(), item.NumeroImovelAlter.ToString(), cont));
                    cont++;
                }
                texto1 = (string.IsNullOrEmpty(item.TipoComplemento) ? "" : item.TipoComplemento);
                texto2 = (string.IsNullOrEmpty(item.TipoComplementoAlter) ? "" : item.TipoComplementoAlter);
                if (texto1 != texto2)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Tipo Complemento", texto1, texto2, cont));
                    cont++;
                }
                texto1 = (string.IsNullOrEmpty(item.InformacaoComplementar) ? "" : item.InformacaoComplementar);
                texto2 = (string.IsNullOrEmpty(item.InformacaoComplementarAlter) ? "" : item.InformacaoComplementarAlter);
                if (texto1 != texto2)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Informação Complementar", texto1, texto2, cont));
                    cont++;
                }
                if (item.CondicaoImovel != item.CondicaoImovelAlter)
                {
                    string vlAntigo = SingletonFlow.condicaoImovelFlow.getCondicaoImovel(item.CondicaoImovel).Descricao;
                    string vlNovo = "";
                    if (item.CondicaoImovelAlter != null)
                        vlNovo = SingletonFlow.condicaoImovelFlow.getCondicaoImovel((int)item.CondicaoImovelAlter).Descricao;

                    ret.Add(CriaAlteracaoCadastral(item, "Condição", vlAntigo, vlNovo, cont));
                    cont++;
                }
                texto1 = (string.IsNullOrEmpty(item.FonteAlternativa) ? "" : item.FonteAlternativa);
                texto2 = (string.IsNullOrEmpty(item.FonteAlternativaAlter) ? "" : item.FonteAlternativaAlter);
                if (texto1 != texto2)
                {
                    string vlAntigo = "";
                    if(texto1 != "")
                     vlAntigo= SingletonFlow.fonteAlternativaFlow.getFonteAlternativa(texto1).Descricao;

                    string vlNovo = "";
                    if (texto2 != "")
                        vlNovo = SingletonFlow.fonteAlternativaFlow.getFonteAlternativa(item.FonteAlternativaAlter).Descricao;

                    ret.Add(CriaAlteracaoCadastral(item, "Fonte Alternativa", vlAntigo, vlNovo, cont));
                    cont++;
                }
                texto1 = (string.IsNullOrEmpty(item.SituacaoImovel) ? "" : item.SituacaoImovel);
                texto2 = (string.IsNullOrEmpty(item.SituacaoImovelAlter) ? "" : item.SituacaoImovelAlter);
                if (texto1 != texto2)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Situação Imóvel", texto1, texto2, cont));
                    cont++;
                }
                if (item.QtdeEconomiasResidencial != item.QtdeEconomiasResidencialAlter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Economias Resid.", item.QtdeEconomiasResidencial.ToString(), item.QtdeEconomiasResidencialAlter.ToString(), cont));
                    cont++;
                }
                if (item.QtdeEconomiasComercial != item.QtdeEconomiasComercialAlter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Economias Comerc.", item.QtdeEconomiasComercial.ToString(), item.QtdeEconomiasComercialAlter.ToString(), cont));
                    cont++;
                }
                if (item.QtdeEconomiasIndustrial != item.QtdeEconomiasIndustrialAlter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Economias Indust.", item.QtdeEconomiasIndustrial.ToString(), item.QtdeEconomiasIndustrialAlter.ToString(), cont));
                    cont++;
                }
                if (item.QtdeEconomiasPublica != item.QtdeEconomiasPublicaAlter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Economias Pública", item.QtdeEconomiasPublica.ToString(), item.QtdeEconomiasPublicaAlter.ToString(), cont));
                    cont++;
                }
                if (item.RamoAtividade1 != item.RamoAtividade1Alter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Ramo Atividade 1", item.RamoAtivDescOrig1, item.RamoAtivDesc1, cont));
                    cont++;
                }
                if (item.RamoAtividade2 != item.RamoAtividade2Alter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Ramo Atividade 2", item.RamoAtivDescOrig2, item.RamoAtivDesc2, cont));
                    cont++;
                }
                if (item.RamoAtividade3 != item.RamoAtividade3Alter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Ramo Atividade 3", item.RamoAtivDescOrig3, item.RamoAtivDesc3, cont));
                    cont++;
                }
                if (item.RamoAtividade4 != item.RamoAtividade4Alter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Ramo Atividade 4", item.RamoAtivDescOrig4, item.RamoAtivDesc4, cont));
                    cont++;
                }
                texto1 = (string.IsNullOrEmpty(item.SituacaoPontoServico) ? "" : item.SituacaoPontoServico);
                texto2 = (string.IsNullOrEmpty(item.SituacaoPontoServicoAlter) ? "" : item.SituacaoPontoServicoAlter);
                if (texto1 != texto2)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Situação P.S.", texto1, texto2, cont));
                    cont++;
                }
                if (item.LocalizacaoPadrao != item.LocalizacaoPadraoAlter)
                {
                    string vlAntigo = SingletonFlow.localizacaoPadraoFlow.getLocalizacaoPadrao(item.LocalizacaoPadrao).Descricao;
                    string vlNovo = "";
                    if (item.LocalizacaoPadraoAlter != null)
                        vlNovo = SingletonFlow.localizacaoPadraoFlow.getLocalizacaoPadrao((int)item.LocalizacaoPadraoAlter).Descricao;

                    ret.Add(CriaAlteracaoCadastral(item, "Local Padrão", vlAntigo, vlNovo, cont));
                    cont++;
                }
                if (item.TipoPadrao != item.TipoPadraoAlter)
                {
                    string vlAntigo = SingletonFlow.tipoPadraoFlow.getTipoPadrao(item.TipoPadrao).Descricao;
                    string vlNovo = "";
                    if (item.TipoPadraoAlter != null)
                        vlNovo = SingletonFlow.tipoPadraoFlow.getTipoPadrao((int)item.TipoPadraoAlter).Descricao;

                    ret.Add(CriaAlteracaoCadastral(item, "Tipo Padrão", vlAntigo, vlNovo, cont));
                    cont++;
                }
                if (item.NumeroMedidor != item.NumeroMedidorAlter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Número Medidor", item.NumeroMedidor, item.NumeroMedidorAlter, cont));
                    cont++;
                }
                if (item.QtdeDigitosMedidor != item.QtdeDigitosMedidorAlter)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Qt. Digitos", item.QtdeDigitosMedidor.ToString(), item.QtdeDigitosMedidorAlter.ToString(), cont));
                    cont++;
                }
                texto1 = (string.IsNullOrEmpty(item.ClasseMetrologica) ? "" : item.ClasseMetrologica);
                texto2 = (string.IsNullOrEmpty(item.ClasseMetrologicaAlter) ? "" : item.ClasseMetrologicaAlter);
                if (texto1 != texto2)
                {
                    ret.Add(CriaAlteracaoCadastral(item, "Cl. Metrológica", texto1, texto2, cont));
                    cont++;
                }
            }
            return ret;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }


        private void mtbxDataIni_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105))
            {
                Regex erx = new Regex(@"(../../....)");
                //Regex er = new Regex(@"(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/([12][0-9]{3})");

                if (erx.IsMatch(mtbxDataIni.Text))
                {
                    DateTime data;
                    if (!DateTime.TryParse(mtbxDataIni.Text, out data))
                    {
                        MessageBox.Show("Data inválida", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    //if (!er.IsMatch(mtbxDataIni.Text))
                    //{
                    //    MessageBox.Show("Data inválida", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    //}
                }
            }

        }

        private void mtbxDataIni_Leave(object sender, EventArgs e)
        {

        }
    }
}
