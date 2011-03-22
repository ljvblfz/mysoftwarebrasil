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
using CommonHelpDesktop;
using SPCadDesktop.Views;
using CommonHelpDesktop.Validator;
using System.Reflection;
using SPCadDesktopData.Data.BFL;


namespace SPCadDesktop.Relatorios
{
    public partial class frmRelIrregularidade : Form
    {
        private List<Cadastro> cadastros;
        public frmRelIrregularidade()
        {
            InitializeComponent();
            cboDistrito.DataSource = SingletonFlow.distritoFlow.getListDistrito();
            cboSituacao.DataSource = SituacaoPesqiosaCombo.getList();
        }

        /// <summary>
        ///  Retorna os dados para o objeto
        /// </summary>
        /// <returns></returns>
        public Irregularidade getCamposUteis()
        {
            Erro.clear();
            Irregularidade objModel = new Irregularidade();
            objModel.dataInicial = TypeDate.isEmptToValue(mtbxDataIni.Text);
            objModel.dataFinal = TypeDate.isEmptToValue(mtbxDataFim.Text);
            objModel.rota = TypeInt.isEmptToValue(tbxRota.Text);
            objModel.distrito = TypeInt.isEmptToValue(cboDistrito.SelectedValue);
            objModel.situacao = TypeInt.isEmptToValue(cboSituacao.SelectedValue);
            objModel.setor = TypeInt.isEmptToValue(tbxSetor);

            if (rbTodas.Checked)
                objModel.irregularidade = "";

            else if (rbSancao.Checked)
                objModel.irregularidade = "";

            else if (rbSubstituicao.Checked)
                objModel.irregularidade = "";

            else if (rbSelecionar.Checked)
                objModel.irregularidade = "";

            return objModel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Muda para a ampulheta
            Cursor.Current = Cursors.WaitCursor;

            Irregularidade objModel = getCamposUteis();
            
            int numParameters = 0, distrito = 0, setor = 0, rota = 0;
            DateTime dtIni = new DateTime();
            DateTime dtFim = new DateTime();
            string reportName = "";
            string modelName = "";
            DateTime.TryParse(mtbxDataIni.Text, out dtIni);
            DateTime.TryParse(mtbxDataFim.Text, out dtFim);

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
            
            List<Cadastro> cads = SingletonFlow.cadastroFlow.GetListCadastroByParam(
                                                                                        distrito
                                                                                        , setor
                                                                                        , rota
                                                                                        , null
                                                                                        , (SituacaoPesqiosaEnum)cboSituacao.SelectedValue
                                                                                        , new string[0]
                                                                                        , ""
                                                                                        , sqlAdd
                                                                                    );

            if (cads.Count == 0)
            {
                MessageBox.Show("Não há dados para os parâmetros informados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            // criando lista de todas ocorrências encontradas nos cadastros filtrados
            string irregularidade = "", irregularidadeAux = "";
            foreach (Cadastro item in cads)
            {
                if (item.VetorOcorrencia.Trim() != "")
                    irregularidade += item.VetorOcorrencia.Trim() + ",";
            }
            if (string.IsNullOrEmpty(irregularidade))
            {
                MessageBox.Show("Não há dados para os parâmetros informados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            irregularidade = irregularidade.Remove(irregularidade.LastIndexOf(","));
            string[] irregSplit = irregularidade.Split(',');
            foreach (string item in irregSplit)
            {
                if (irregularidadeAux.IndexOf(item.PadLeft(2, '0')) < 0)
                    irregularidadeAux += item.PadLeft(2, '0') + ",";
            }
            irregularidade = irregularidadeAux.Remove(irregularidadeAux.LastIndexOf(","));

            string flagIrregularidade = "";
            if (rbSancao.Checked)
                flagIrregularidade = "SANCAO";
            if (rbSubstituicao.Checked)
                flagIrregularidade = "SUBSTITUICAO";
            if (rbSelecionar.Checked)
                irregularidade = textBox1.Text;

            List<Ocorrencia> ocorrenciasSelecionadas = SingletonFlow.ocorrenciaFlow.ListOcorrenciaByVetOcorrencia(irregularidade, flagIrregularidade);

            List<Cadastro> cads2 = new List<Cadastro>();

            foreach (Cadastro item in cads)
            {
                irregSplit = item.VetorOcorrencia.Split(',');
                foreach (string str in irregSplit)
                {
                    if (irregularidade.IndexOf(str.Trim()) >= 0 && str.Trim() != "")
                    {
                        cads2.Add(item);
                        break;
                    }
                }
            }
            // passando o vetor para 2 digitos.
            foreach (Cadastro item in cads2)
            {
                string[] vet = item.VetorOcorrencia.Split(',');
                string verOcor = "";
                for (int i = 0; i < vet.Length; i++)
                {
                    verOcor += int.Parse(vet[i]).ToString("00") + ",";
                }

                item.VetorOcorrencia = verOcor.TrimEnd(',');
            }

            cads = cads2;
            cadastros = cads;

            List<AlteracaoCadastral> alterCads = null;
            try
            {
                cads = cads.Where(c => c.DataVisita >= dtIni && c.DataVisita <= dtFim).ToList();
                alterCads = VerificaAlteracaoCadastralList(cads);
                numParameters = 8;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Objeto report 
            LocalReport report = new LocalReport();

            // thred de subdetalhe
            report.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

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
            param[6].Name = "Irregularidades";
            param[6].Values.Add(irregularidade);

            if (flagIrregularidade.Trim() != "")
            {
                if (flagIrregularidade.Trim() == "SANCAO")
                    flagIrregularidade = " - Passíveis de Sanção";
                if (flagIrregularidade.Trim() == "SUBSTITUICAO")
                    flagIrregularidade = " - Substituição de Hidrômetro";
            }
            param[7] = new ReportParameter();
            param[7].Name = "IrregularidadesTitle";
            param[7].Values.Add(flagIrregularidade);

            //Caminho do relatório
            report.ReportEmbeddedResource = "SPCadDesktop.Relatorios.Reports.relIrregularidades.rdlc";
            reportName = "relIrregularidades";
            modelName = "Cadastro";
            report.Refresh();
            report.DataSources.Add(new ReportDataSource("Ocorrencia", ocorrenciasSelecionadas));

            report.Refresh();
            report.SetParameters(param);

            GeraRelatorio(reportName, report, (sender == btnExcel));

            // Volta para o padrão
            Cursor.Current = Cursors.Default;
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            int codigoOcorr = Int32.Parse(e.Parameters["Irregularidade"].Values[0]);
            List<Cadastro> listaCadastro = new List<Cadastro>();
            if(codigoOcorr != null)
                listaCadastro = new CadastroFlow().getCadastroRelatorio(codigoOcorr.ToString().PadLeft(2, '0'));
            e.DataSources.Add(new ReportDataSource("Cadastro", listaCadastro));
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
            if (cont <= 0)
            {
                alterCad = new AlteracaoCadastral(cad.CodigoDistrito.ToString(), cad.Setor.ToString(), cad.CodigoRota.ToString(), cad.Matricula.ToString(), cad.NumeroPontoServico, informacao, vlrAntigo, vlrNovo);
            }
            else
            {
                alterCad = new AlteracaoCadastral(informacao, vlrAntigo, vlrNovo);
            }
            return alterCad;
        }

        /// <summary>
        ///   Metodo que carrega uma lista de alterção castral
        /// </summary>
        /// <param name="cads">List de Cadastro</param>
        /// <returns>List de AlteracaoCadastral</returns>
        private List<AlteracaoCadastral> VerificaAlteracaoCadastralList(List<Cadastro> cads)
        {
            // Lista de retorno
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


                texto1 = TypeString.isEmptToValue(item.TipoComplemento);
                texto2 = TypeString.isEmptToValue(item.TipoComplementoAlter);
                if (item.TipoComplemento != item.TipoComplementoAlter)
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
                    string condicaoAntiga = "";
                    string condicaoNova = "";

                    // Retorna a condição do imovel Antigo
                    CondicaoImovel condicaoAntigo = SingletonFlow.condicaoImovelFlow.getCondicaoImovel(item.CondicaoImovel);
                    if (condicaoAntigo != null)
                        condicaoAntiga = condicaoAntigo.Descricao;

                    // Retorna a condição do imovel Novo
                    if (item.CondicaoImovelAlter != null)
                    {
                        CondicaoImovel condicaoNovo = SingletonFlow.condicaoImovelFlow.getCondicaoImovel((int)item.CondicaoImovelAlter);
                        if (condicaoNovo != null)
                            condicaoNova = condicaoNovo.Descricao;
                    }

                    ret.Add(CriaAlteracaoCadastral(item, "Condição", condicaoAntiga, condicaoNova, cont));
                    cont++;
                }
                texto1 = TypeString.isEmptToValue(item.FonteAlternativa);
                texto2 = TypeString.isEmptToValue(item.FonteAlternativaAlter); 
                if (texto1 != texto2)
                {
                    string fonteAlternativaAntiga = "";
                    string fonteAlternativaNova = "";

                    FonteAlternativa fonteAlternativa = SingletonFlow.fonteAlternativaFlow.getFonteAlternativa(texto1);
                    if (fonteAlternativa != null)
                        fonteAlternativaAntiga = fonteAlternativa.Descricao;

                    if (texto2 != "")
                        fonteAlternativaNova = SingletonFlow.fonteAlternativaFlow.getFonteAlternativa(item.FonteAlternativaAlter).Descricao;

                    ret.Add(CriaAlteracaoCadastral(item, "Fonte Alternativa", fonteAlternativaAntiga, fonteAlternativaNova, cont));
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
                    string localizacaoAntiga = "";
                    string localizacaoNova = "";
                    LocalizacaoPadrao localizacaoPadrao = null;

                    // Localização padrão Antiga
                    localizacaoPadrao =  SingletonFlow.localizacaoPadraoFlow.getLocalizacaoPadrao(item.LocalizacaoPadrao);
                    if (localizacaoPadrao != null)
                        localizacaoAntiga = localizacaoPadrao.Descricao;

                    // Localização padrão Nova
                    if (item.LocalizacaoPadraoAlter != null)
                    {
                        localizacaoPadrao = SingletonFlow.localizacaoPadraoFlow.getLocalizacaoPadrao((int)item.LocalizacaoPadraoAlter);
                        if (localizacaoPadrao != null)
                            localizacaoNova = localizacaoPadrao.Descricao;
                    }

                    ret.Add(CriaAlteracaoCadastral(item, "Local Padrão", localizacaoAntiga, localizacaoNova, cont));
                    cont++;
                }
                if (item.TipoPadrao != item.TipoPadraoAlter)
                {
                    string tipoPadraoAntigo = "";
                    string tipoPadraoNovo = "";
                    TipoPadrao tipoPadrao = null;

                    // Tipo de padrão antigo
                    tipoPadrao = SingletonFlow.tipoPadraoFlow.getTipoPadrao(item.TipoPadrao);
                    if (tipoPadrao != null)
                        tipoPadraoAntigo = tipoPadrao.Descricao;

                    // Tipo de padrão novo
                    if (item.TipoPadraoAlter != null)
                    {
                        tipoPadrao = SingletonFlow.tipoPadraoFlow.getTipoPadrao((int)item.TipoPadraoAlter);
                        tipoPadraoNovo = tipoPadrao.Descricao;
                    }

                    ret.Add(CriaAlteracaoCadastral(item, "Tipo Padrão", tipoPadraoAntigo, tipoPadraoNovo, cont));
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
                
                if (erx.IsMatch(mtbxDataIni.Text))
                {
                    DateTime data;
                    if (!DateTime.TryParse(mtbxDataIni.Text, out data))
                    {
                        MessageBox.Show("Data inválida", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            List<ItemCombo> lista = SingletonFlow.ocorrenciaFlow.getListOcorrencia();
            using (frmListAuxChecked frm = new frmListAuxChecked(lista, "Consulta Ocorrências"))
            {
                frm.ShowDialog();
                if (frm.Selecao != null)
                {
                    textBox1.Text = "";
                    foreach (ItemCombo item in frm.Selecao)
                    {
                        textBox1.Text += item.Value.ToString() + ",";
                    }
                    textBox1.Text = textBox1.Text.Trim(',');
                }
            }
        }



    }
}
