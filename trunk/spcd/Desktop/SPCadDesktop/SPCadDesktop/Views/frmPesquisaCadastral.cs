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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using CommonHelpDesktop;
using System.Xml;

namespace SPCadDesktop.Views
{
    public partial class frmPesquisaCadastral : Form
    {
        int? codFunc = null;
        SituacaoPesqiosaEnum situac = SituacaoPesqiosaEnum.Todos;
        string sqlAdcional = "";
        List<string> logradouros;

        public frmPesquisaCadastral()
        {
            InitializeComponent();
            cboSituacao.DataSource = SituacaoPesqiosaCombo.getList();
            cboCadastrador.DataSource = ListFuncionario.getList(true);

            logradouros = SingletonFlow.cadastroFlow.GetListLogradouros();
            tbxLogradouro.LostFocus += tbxLogradouro_Leave;
            lbxDropLogradouro.LostFocus += tbxLogradouro_Leave;
            
            List<ItemCombo> lItemComboConsultas = LerXMLConsulta("Digitacao");
            cboConsultas.DataSource = lItemComboConsultas;
        }

        delegate List<Cadastro> BuscaDelegate();
        private void EfetuaBusca(BuscaDelegate busca)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += new DoWorkEventHandler(
                (obj, evt) =>
                {
                    evt.Result = busca.Invoke();
                });

            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                (obj, evt) =>
                {
                    bsCadastro.DataSource = evt.Result;


                    btnBuscarGeral.Text = "Buscar";
                    btnBuscarMatricula.Text = "Buscar";

                    btnBuscarGeral.Enabled = true;
                    btnBuscarMatricula.Enabled = true;
                    gbxRota.Enabled = true;
                    gbxMatricula.Enabled = true;
                    gbxSituacao.Enabled = true;
                    gbxDistrito.Enabled = true;
                    gbxLogradouro.Enabled = true;
                    gbxBairro.Enabled = true;

                    //AtualizaGrid(grdDistribuicao);
                });

            btnBuscarGeral.Text = "Buscando...";
            btnBuscarMatricula.Text = "...";

            btnBuscarGeral.Enabled = false;
            btnBuscarMatricula.Enabled = false;
            gbxRota.Enabled = false;
            gbxMatricula.Enabled = false;
            gbxSituacao.Enabled = false;
            gbxDistrito.Enabled = false;
            gbxLogradouro.Enabled = false;
            gbxBairro.Enabled = false;

            worker.RunWorkerAsync();
        }

        public static List<ItemCombo> LerXMLConsulta(string modulo)
        {
            List<ItemCombo> lItemCombo = new List<ItemCombo>();

            System.Reflection.Assembly a = System.Reflection.Assembly.GetEntryAssembly();
            string baseDir = System.IO.Path.GetDirectoryName(a.Location);

            string filename = baseDir + @"\ConsultasPersonalizadas.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            foreach (XmlNode digitacao in doc.SelectNodes("/Consulta/ConsutasPersonalizadas/" + modulo))
            {
                lItemCombo.Add(new ItemCombo(null, null));
                foreach (XmlNode digitacaoCh in digitacao.ChildNodes)
                {

                    //if (Convert.ToString(prod.Attributes["valorGerencia"].Value) == aNomeGerencia)
                    if (digitacaoCh.Name == "Filtro")
                    {
                        lItemCombo.Add(new ItemCombo(digitacaoCh.Attributes["value"].Value,
                                                     digitacaoCh.Attributes["label"].Value));
                    }
                }
            }
            return lItemCombo;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private List<Cadastro> BuscaCadastros()
        {
            int distrito = 0, setor = 0, rota = 0;
            string[] lograd = null;
            string bairro = null;

            if (tbxRota.Text != string.Empty)
            {
                if (!int.TryParse(tbxRota.Text, out rota))
                {
                    MessageBox.Show("Rota inválida");
                    return null;
                }
            }
            if (tbxSetor.Text != string.Empty)
            {
                if (!int.TryParse(tbxSetor.Text, out setor))
                {
                    MessageBox.Show("Setor inválido");
                    return null;
                }
            }

            if (tbxDistrito.Text != string.Empty)
            {
                if (!int.TryParse(tbxDistrito.Text, out distrito))
                {
                    MessageBox.Show("Distrito inválido");
                    return null;
                }
            }
            try
            {
                lograd = lbxLogradouro.Items.Cast<string>().ToArray();
                bairro = tbxBairro.Text;
                return SingletonFlow.cadastroFlow.GetListCadastroByParam(distrito, setor, rota, codFunc, situac, lograd, bairro, sqlAdcional);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return null;
            }

        }

        private BuscaDelegate ultimaBusca;
        private void btnBuscarGeral_Click(object sender, EventArgs e)
        {
            codFunc = (int?)cboCadastrador.SelectedValue;
            situac = (SituacaoPesqiosaEnum)cboSituacao.SelectedValue;

            //int? codFunc = (int)cboFuncionario.SelectedValue;
            //DistribuicaoEnum? distrib = (DistribuicaoEnum)cboSituacao.SelectedValue;

            ultimaBusca = new BuscaDelegate(BuscaCadastros);
            EfetuaBusca(ultimaBusca);
        }

        private List<Cadastro> BuscaCadastrosMatriucla()
        {
            try
            {
                return SingletonFlow.cadastroFlow.GetListCadastroByMatricula(tbxMatricula.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return null;
            }
        }

        private void tbxLogradouro_TextChanged(object sender, EventArgs e)
        {
            //List<string> logradourosFiltrado = ;
            lbxDropLogradouro.DataSource = logradouros.Where(s => s.StartsWith(tbxLogradouro.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            lbxDropLogradouro.Visible = lbxDropLogradouro.Items.Count > 0 && tbxLogradouro.Focused;
        }

        private void tbxLogradouro_Leave(object sender, EventArgs e)
        {
            if (!tbxLogradouro.Focused && !lbxDropLogradouro.Focused)
                lbxDropLogradouro.Visible = false;
            if (lbxDropLogradouro.Items.Count > 0)
            {
                tbxLogradouro.Text = (string)lbxDropLogradouro.SelectedItem;
            }
        }

        private void lbxDropLogradouro_Click(object sender, EventArgs e)
        {
            tbxLogradouro.Text = (string)lbxDropLogradouro.SelectedItem;
        }

        private void tbxLogradouro_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down: if (lbxDropLogradouro.SelectedIndex < lbxDropLogradouro.Items.Count - 1) lbxDropLogradouro.SelectedIndex += 1;
                    break;
                case Keys.Up: if (lbxDropLogradouro.SelectedIndex > 0) lbxDropLogradouro.SelectedIndex -= 1;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbxDropLogradouro.Visible || lbxDropLogradouro.Items.Count > 0)
            {
                lbxLogradouro.Items.Add(lbxDropLogradouro.SelectedItem);
                tbxLogradouro.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbxLogradouro.Items.RemoveAt(lbxDropLogradouro.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lbxLogradouro.Items.Clear();
        }

        private void tbxMatricula_TextChanged(object sender, EventArgs e)
        {
            btnBuscarMatricula.Enabled = (tbxMatricula.Text.Trim() != "");
        }

        private void tbxMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\r')
            {
                e.Handled = true;
            }
        }

        private void btnBuscarMatricula_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarMatricula_Click_1(object sender, EventArgs e)
        {
            ultimaBusca = new BuscaDelegate(BuscaCadastrosMatriucla);
            EfetuaBusca(BuscaCadastrosMatriucla);
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            if (bsCadastro.Count > 0)
            {
                bsCadastro.EndEdit();
                using (frmCadastro frm = new frmCadastro(bsCadastro))
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Cancel)
                    {
                        btnBuscarGeral_Click(btnBuscarGeral, null);
                    }
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Excel.XlFixedFormatType paramExportFormat = Excel.XlFixedFormatType.xlTypePDF;
            //Excel.XlFixedFormatQuality paramExportQuality = Excel.XlFixedFormatQuality.xlQualityStandard;

            //bool paramOpenAfterPublish = false;
            //bool paramIncludeDocProps = true;
            //bool paramIgnorePrintAreas = true;
            //object paramFromPage = Type.Missing;
            //object paramToPage = Type.Missing;
            //object paramMissing = Type.Missing;


            //Excel.Application xlApp;
            //Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;
            //object misValue = System.Reflection.Missing.Value;

            //xlApp = new Excel.ApplicationClass();
            //xlWorkBook = xlApp.Workbooks.Add(misValue);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //int i = 0;
            //int j = 0;

            //for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
            //{
            //    DataGridViewHeaderCell cell = dataGridView1.Columns[j].HeaderCell;                
            //    xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;

            //}

            //for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            //{
            //    for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
            //    {
            //        DataGridViewCell cell = dataGridView1[j, i];
            //        xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
            //    }
            //}

            //sfdExportToxcel.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            //sfdExportToxcel.FileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";
            //if (sfdExportToxcel.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        // Open the source workbook.
            //        //xlWorkBook = xlApp.Workbooks.Open(sfdExportToxcel.FileName,
            //        //    paramMissing, paramMissing, paramMissing, paramMissing,
            //        //    paramMissing, paramMissing, paramMissing, paramMissing,
            //        //    paramMissing, paramMissing, paramMissing, paramMissing,
            //        //    paramMissing, paramMissing);

            //        // Save it in the target format.
            //        if (xlWorkBook != null)
            //            xlWorkBook.ExportAsFixedFormat(paramExportFormat,
            //                sfdExportToxcel.FileName, paramExportQuality,
            //                paramIncludeDocProps, paramIgnorePrintAreas, paramFromPage,
            //                paramToPage, paramOpenAfterPublish,
            //                paramMissing);
            //    }
            //    catch (Exception ex)
            //    {
            //        // Respond to the error.
            //    }
            //    finally
            //    {
            //        xlApp.Quit();

            //        releaseObject(xlWorkSheet);
            //        releaseObject(xlWorkBook);
            //        releaseObject(xlApp);
            //    }
            //}

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;

            // Cria linha de cabeçalho.
            for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
            {
                DataGridViewHeaderCell cell = dataGridView1.Columns[j].HeaderCell;
                xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
            }

            // Cria linhas de registros.
            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView1[j, i];
                    xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                }
            }

            sfdExportToxcel.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            sfdExportToxcel.FileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + ".xls";
            if (sfdExportToxcel.ShowDialog() == DialogResult.OK)
            {
                xlWorkBook.SaveAs(sfdExportToxcel.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
            }

            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            codFunc = (int?)cboCadastrador.SelectedValue;
            situac = (SituacaoPesqiosaEnum)cboSituacao.SelectedValue;

            //int? codFunc = (int)cboFuncionario.SelectedValue;
            //DistribuicaoEnum? distrib = (DistribuicaoEnum)cboSituacao.SelectedValue;

            sqlAdcional = (string)cboConsultas.SelectedValue;
            ultimaBusca = new BuscaDelegate(BuscaCadastros);
            EfetuaBusca(ultimaBusca);
        }
    }
}
