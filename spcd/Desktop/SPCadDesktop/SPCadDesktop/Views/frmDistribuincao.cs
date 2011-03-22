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
using CommonHelpDesktop;
//using SPCadToPDA;
//using SPCadToPDA.Helper;

namespace SPCadDesktop.Views
{
    public partial class frmDistribuincao : Form
    {
        int? codFunc = null;
        DistribuicaoEnum? distrib = null;

        public frmDistribuincao()
        {
            InitializeComponent();
            cboSituacao.DataSource = SituacaoDistribuicaoCombo.getList();
            cboFuncionario.DataSource = ListFuncionario.getList(true);
            //this.cboFuncionario.SelectedIndexChanged += new System.EventHandler(this.button6_Click);

            cboFuncionarioAdd.DataSource = ListFuncionario.getList(false);
            //this.cboFuncionarioAdd.SelectedIndexChanged += new System.EventHandler(this.button6_Click);
        }

        delegate List<Distribuido> BuscaDelegate();
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
                    bsDistribuidos.DataSource = evt.Result;

                    btnBuscaDistribuicao.Text = "Buscar";

                    btnBuscaDistribuicao.Enabled = true;
                    gbxAtribuicao.Enabled = true;
                    gbxFuncionario.Enabled = true;
                    gbxRota.Enabled = true;
                    gbxSituacao.Enabled = true;

                    //AtualizaGrid(grdDistribuicao);
                });

            btnBuscaDistribuicao.Text = "Buscando...";

            btnBuscaDistribuicao.Enabled = false;
            gbxAtribuicao.Enabled = false;
            gbxFuncionario.Enabled = false;
            gbxRota.Enabled = false;
            gbxSituacao.Enabled = false;

            worker.RunWorkerAsync();
        }

        private void AtualizaGrid(DataGridView sender)
        {
            Dictionary<string, int> somatorioStatus = new Dictionary<string, int>();

            foreach (DataGridViewRow row in sender.Rows)
            {
                int ultimaCol = row.Cells.Count - 1;
                IDistribuicao distribuicao = row.DataBoundItem as IDistribuicao;
                if (!string.IsNullOrEmpty(distribuicao.StatusDistribuicaoString))
                {
                    if (!somatorioStatus.Keys.Contains(distribuicao.StatusDistribuicaoString))
                    {
                        somatorioStatus.Add(distribuicao.StatusDistribuicaoString, 0);
                    }

                    somatorioStatus[distribuicao.StatusDistribuicaoString]++;
                }

                if (distribuicao != null && distribuicao.StatusDistribuicaoString != null)
                {
                    switch (distribuicao.StatusDistribuicoes)
                    {
                        case StatusDistribuicoes.ExecutadoTodos:
                            // Cinza
                            row.DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 192);
                            row.Cells[ultimaCol].Style.SelectionBackColor = Color.FromArgb(192, 192, 192);
                            break;
                        case StatusDistribuicoes.NaoExecutado:
                            // Amarelo
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 176);
                            row.Cells[ultimaCol].Style.SelectionBackColor = Color.FromArgb(255, 240, 176);
                            break;
                        case StatusDistribuicoes.ExecutadoParcial:
                            // Salmão
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 204);
                            row.Cells[ultimaCol].Style.SelectionBackColor = Color.FromArgb(255, 204, 204);
                            break;
                        default:
                            // branco
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                            row.Cells[ultimaCol].Style.SelectionBackColor = Color.FromArgb(0, 0, 128);
                            break;
                    }
                    if (distribuicao.Selecao)
                    {
                        // Verde
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 204);
                        row.Cells[ultimaCol].Style.SelectionBackColor = Color.FromArgb(230, 255, 204); ;
                    }
                }

            }
            sender.Refresh();
        }

        private List<Distribuido> BuscaDistribuicao()
        {
            int distrito = 0, setor = 0, rota = 0;

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
                return SingletonFlow.distribuicaoFlow.GetDistribuidoByFiltros(distrito, setor, rota, codFunc, distrib);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return null;
            }

        }

        private BuscaDelegate ultimaBusca;
        private void button6_Click(object sender, EventArgs e)
        {
            codFunc = (int?)cboFuncionario.SelectedValue;
            distrib = (DistribuicaoEnum?)cboSituacao.SelectedValue;

            //int? codFunc = (int)cboFuncionario.SelectedValue;
            //DistribuicaoEnum? distrib = (DistribuicaoEnum)cboSituacao.SelectedValue;

            ultimaBusca = new BuscaDelegate(BuscaDistribuicao);
            EfetuaBusca(ultimaBusca);
        }

        private void bsDistribuidos_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                Distribuido dist = (Distribuido)((BindingSource)sender).Current;
                int distrito = dist.Distrito;
                int setor = dist.Setor;
                int rota = dist.Rota;

                bsDistribuicao.DataSource = SingletonFlow.distribuicaoFlow.GetDistribuicaoByDistritoSetorRota(distrito, setor, rota);
                //controleBotoe();
            }
            catch (Exception)
            {
                bsDistribuicao.Clear();
            }
        }

        private void controleBotoe()
        {
            Distribuicao distribuicao = (Distribuicao)bsDistribuicao.Current;
            Distribuido distribuido = (Distribuido)bsDistribuidos.Current;

            btnAtribuir.Enabled = distribuido != null && distribuido.QtPontoServico > 0 && distribuido.QtExecutado != distribuido.QtPontoServico;
            btnRemover.Enabled = distribuicao != null && (distribuicao.SituacaoCarga == "1" || distribuicao.SituacaoCarga == "2");
            btnFinalizar.Enabled = distribuicao != null && (distribuicao.SituacaoCarga == "3" || distribuicao.SituacaoCarga == "4");
            btnLiberar.Enabled = distribuicao != null && distribuicao.SituacaoCarga == "1";
            btnDesfazer.Enabled = distribuicao != null && distribuicao.SituacaoCarga == "2";
        }

        private void btnAtribuir_Click(object sender, EventArgs e)
        {
            if (bsDistribuidos.Count > 0)
            {
                List<Distribuicao> distribs = (List<Distribuicao>)bsDistribuicao.DataSource;
                if (!distribs.Exists(d => d.CodFuncionario == (int)cboFuncionarioAdd.SelectedValue))
                {
                    Distribuido dist = (Distribuido)bsDistribuidos.Current;
                    Distribuicao distrib = new Distribuicao();
                    distrib.CodFuncionario = (int)cboFuncionarioAdd.SelectedValue;
                    distrib.Distrito = dist.Distrito;
                    distrib.Setor = dist.Setor;
                    distrib.Rota = dist.Rota;
                    distrib.SituacaoCarga = "1";

                    // insert na tabela distribuicao
                    SingletonFlow.distribuicaoFlow.Insert(distrib);
                    bsDistribuidos_PositionChanged(bsDistribuidos, null);
                }
                else
                {
                    MessageBox.Show("Funcionário já está atribuido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            SingletonFlow.distribuicaoFlow.Delete((Distribuicao)bsDistribuicao.Current);
            bsDistribuicao.RemoveCurrent();
            controleBotoe();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Distribuicao distrib = (Distribuicao)bsDistribuicao.Current;
            if (distrib.SituacaoCarga == "3" || distrib.SituacaoCarga == "4")
            {
                distrib.SituacaoCarga = "5";
                SingletonFlow.distribuicaoFlow.Update(distrib);
                bsDistribuidos_PositionChanged(bsDistribuidos, null);
                controleBotoe();
            }
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            Distribuicao distrib = (Distribuicao)bsDistribuicao.Current;
            if (distrib.SituacaoCarga == "1")
            {
                distrib.SituacaoCarga = "2";
                SingletonFlow.distribuicaoFlow.Update(distrib);
                bsDistribuidos_PositionChanged(bsDistribuidos, null);
                controleBotoe();
            }
        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            Distribuicao distrib = (Distribuicao)bsDistribuicao.Current;
            if (distrib.SituacaoCarga == "2")
            {
                distrib.SituacaoCarga = "1";
                SingletonFlow.distribuicaoFlow.Update(distrib);
                bsDistribuidos_PositionChanged(bsDistribuidos, null);
                controleBotoe();
            }
        }

        private void bsDistribuicao_PositionChanged(object sender, EventArgs e)
        {
            controleBotoe();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bsDistribuicao.Count > 0)
            {
                if (((Distribuicao)bsDistribuicao.Current).SituacaoCarga == "2" || ((Distribuicao)bsDistribuicao.Current).SituacaoCarga == "3")
                {

                    if (MessageBox.Show("Deseja Gerar arquivo para PDA, para o pesquisador: " + ((Distribuicao)bsDistribuicao.Current).NomeFuncionario, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        string IdUsuario = ((Distribuicao)bsDistribuicao.Current).CodFuncionario.ToString();
                        string Usuario = ((Distribuicao)bsDistribuicao.Current).NomeFuncionario;
                        string Senha = SingletonFlow.funcionarioFlow.GetFuncionarioById(int.Parse(IdUsuario)).Senha;
                        string Login = SingletonFlow.funcionarioFlow.GetFuncionarioById(int.Parse(IdUsuario)).Login;

                        string parametro = IdUsuario.ToString() + "," + Usuario + "," + Senha + "," + Login;

                        System.Diagnostics.Process.Start("Resources\\SPCadToPDA.exe", parametro);
                    }
                }
                else
                {
                    MessageBox.Show("Para gerar o banco de dados móvel é necessário que a rota esteja liberada ou carregada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Não há nenhum item na lista de distribuição.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        public static string GetLocalPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }
    }


}
