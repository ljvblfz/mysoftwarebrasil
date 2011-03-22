using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobileData.Data;
using SPCadMobileData.Data.Model;
using System.Linq;

namespace SPCadMobile.View
{
    public partial class frmConsumo : SPCadMobile.View.CustomFormAba
    {
        public string flagConcluido = "";
        public long cadastro;
        public long matricula;

        public frmConsumo(long cad, long matric)
        {
            InitializeComponent();
            this.cadastro = cad;
            this.matricula = matric;

            cbxExpectativaCons.DataSource = ListExpectativaConsumo.getList();

            CarregarTela();

            DisableComponentes();

            tabControl1_SelectedIndexChanged(tabControl1, null);
        }

        public void CarregarTela()
        {
            List<HistoricoConsumo> listaHistorico = SingletonFlow.historicoConsumoFlow.getListHistoricobyCadastro(cadastro, matricula);

            // Adiciona a media de consumo
            if (listaHistorico != null)
                if (listaHistorico.Count > 0)
                {
                    // retorna uma lista com os dados não nulos
                    List<HistoricoConsumo> valor = listaHistorico.FindAll(delegate(HistoricoConsumo item) { return item.VolumeMedido > 0; });

                    if (valor.Count > 0)
                    {
                        // Realiza o calculo da media
                        int media = ((int)listaHistorico.Sum(item => item.VolumeMedido) / valor.Count);
                        tbxMedia.Text = media.ToString();
                    }
                    else
                    {
                       tbxMedia.Text = "0";
                    }
                }
                else
                {
                   tbxMedia.Text = "0";
                }
            else
                tbxMedia.Text = "0";
           
            bsHistoricoConsumo.DataSource = listaHistorico;
            bindingSourceAuxCadConsum.DataSource = SingletonFlow.cadastroFlow.GetConsumCad(cadastro, matricula);
        }

        //bloquea todos os componentes das abas
        private void DisableComponentes()
        {
            bool status = true;

            StatusAbaInfConsumo(status);
        }

        // ativa/desativa componentes de tela da aba imóvel.
        private void StatusAbaInfConsumo(bool status)
        {
            cbxExpectativaCons.Enabled = !status;
            rbIncompatib.Enabled = !status;
            tbxObsNaoConf.ReadOnly = status;

            StatusBotaoEditar(!status);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (menuItem2.Text == "Cancelar")
            {
                bsHistoricoConsumo.ResetItem(0);

                StatusAbaInfConsumo(true);

                return;
            }

            //limpa a lista estatica fonte alternativa;            
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabPages[tabControl1.SelectedIndex].Name == "tabInfConsumo")
            {
                menuItem1.Enabled = true;
            }
            else
            {
                menuItem1.Enabled = false;
            }
        }

        /// <summary>
        /// true para Salvar/Cancelar, false para Editar/Voltar
        /// </summary>
        /// <param name="status"></param>
        private void StatusBotaoEditar(bool status)
        {
            menuItem1.Text = (status) ? "Salvar" : "Editar";
            menuItem2.Text = (status) ? "Cancelar" : "Voltar";
        }

        /// <summary>
        /// Botao editar/salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = (menuItem1.Text == "Salvar") ? true : false;

                if (status && !string.IsNullOrEmpty(tbxObsNaoConf.Text) && radioButtonEx5.Checked == true)
                {
                    MessageBox.Show("É necessário limpar a caixa 'Observação de imcompatibilidade'", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    if (MessageBox.Show("Deseja limpar agora?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        tbxObsNaoConf.Text = null;
                    }
                    else
                    {
                        return;
                    }
                }               

                if (status)
                {
                    Salvar();
                }

                StatusBotaoEditar(!status);
                StatusAbaInfConsumo(status);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        //Salva os dados da interface frmPontoServHidrometro.cs
        private void Salvar()
        {
            try
            {
                bindingSourceAuxCadConsum.EndEdit();

                AuxConsCadast auxCadCons = (AuxConsCadast)bindingSourceAuxCadConsum.Current;

                if (string.IsNullOrEmpty(auxCadCons.ExpectativaConsu))
                {
                    throw new Exception("Necessário informar \"Espectativa de cons\"");
                }

                if (string.IsNullOrEmpty(auxCadCons.Incompatibilidade))
                {
                    throw new Exception("Necessário informar \"Incompatibilidade\"");
                }

                Cursor.Current = Cursors.WaitCursor;
                SingletonFlow.cadastroFlow.UpdateCadConsumo(auxCadCons);

                CarregarTela();

                bsHistoricoConsumo.ResumeBinding();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void rbIncompatib_SelectedValueChanged(object sender, EventArgs e)
        {
            if (menuItem1.Text == "Salvar")
            {
                if (radioButtonEx5.Checked == true)
                {
                    tbxObsNaoConf.ReadOnly = true;
                }
                else
                {
                    tbxObsNaoConf.ReadOnly = false;
                }
            }
        }
    }
}

