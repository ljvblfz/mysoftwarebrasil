using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobileData.Data;
using SPCadMobileData.Data.Model;
using CommonHelpMobile;
using CopasaMobile.View;

namespace SPCadMobile.View
{
    public partial class frmPesquisaCadastral : CustomForm
    {
        private int setor { get; set; }
        private int rota { get; set; }
        private int distrito { get; set; }

        /// <summary>
        /// desativa/ativa eventos
        /// </summary>
        private int flgLoad { get; set; }


        public frmPesquisaCadastral(int distrito, int setor, int rota)
        {
            InitializeComponent();

            // ATIVA O GPRS
            //CoordenadaGPS.AtivaGPS();

            tbxSetor.Text = setor.ToString();
            tbxRota.Text = rota.ToString();

            this.setor = setor;
            this.rota = rota;
            this.distrito = distrito;

            flgLoad = 1;
        }

        /// <summary>
        /// aciona a interface de impedimento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImpedimento_Click(object sender, EventArgs e)
        {
            int positionBSCad = bindingSourceCadastro.Position;
            int cbxPosition = cbxSit.SelectedIndex;

            try
            {
                // Testa se existe algum item na lista.
                if (bindingSourceCadastro.Count == 0)
                {
                    MessageBox.Show("É necessário escolher um item na lista", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                bindingSourceCadastro.EndEdit();

                // Recupera 
                string temp = ((CadastroAuxiliar)bindingSourceCadastro.Current).VetorOcorrencia;

                // Testa se há ocorrencias. ou impedimento com ocorrencias em branco.
                if (string.IsNullOrEmpty(temp) && ((CadastroAuxiliar)bindingSourceCadastro.Current).StatusExecucao == 2)
                {
                    ((CadastroAuxiliar)bindingSourceCadastro.Current).StatusExecucao = 0;
                    SingletonFlow.cadastroFlow.UpdateStatusExec((CadastroAuxiliar)bindingSourceCadastro.Current,0);
                    cbxSit_TextChanged(cbxSit, null);

                    dataGridListCadastral_CurrentCellChanged(dataGridListCadastral, null);

                    bindingSourceCadastro.Position = positionBSCad;
                    return;
                }

                string[] vetorOcorrc = temp.Split(',');

                // Lista onde será removido as ocorrências de impedimento.
                List<string> lstOcoRemov = vetorOcorrc.ToList<string>();
                string msg = "Deseja remover as ocorrências de impedimento abaixo?\n";

                // Ocorrencias com impedimento a serem removidas.
                List<string> ocoImp = new List<string>();

                List<ItemCombo> lst = SingletonFlow.ocorrenciaFlow.getListOcorrencia();
                
                foreach (string item in vetorOcorrc)
                {
                    if (SingletonFlow.ocorrenciaFlow.CheckOcorrcImp(item))
                    {
                        ItemCombo ocorrencia = lst.Find(p => p.Value.ToString().PadLeft(3,'0') == item);
                        msg += "- " + ocorrencia.Description.ToString() + "\n";                        

                        ocoImp.Add(item);                        
                    }
                }


                if (MessageBox.Show(msg, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    foreach (string item in ocoImp)
                    {
                        lstOcoRemov.RemoveAll(posicao => posicao == item);
                    }

                    SingletonFlow.cadastroFlow.UpdateImpedimento(((CadastroAuxiliar)bindingSourceCadastro.Current).Id, lstOcoRemov);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            cbxSit_TextChanged(cbxSit, null);

            dataGridListCadastral_CurrentCellChanged(dataGridListCadastral, null);
            
            bindingSourceCadastro.Position = positionBSCad;            
        }

        // Sair da interface Pesquisa Cadastral.
        private void menuItem2_Click(object sender, EventArgs e)
        {
            CoordenadaGPS.DesavitaGps();
            this.Close();
        }

        /// <summary>
        /// Botão de menu executar - aciona a interface Execução Pesquisa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (bindingSourceCadastro.Count == 0)//testa se existe algum item na lista.
            {
                MessageBox.Show("É necessário escolher um item na lista", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            int position = bindingSourceCadastro.Position;
            List<CadastroAuxiliar> cad = (List<CadastroAuxiliar>)bindingSourceCadastro.List;

            try
            {
                if (cad.ElementAt(position).StatusExecucao == 1 && MessageBox.Show("Este cadastro já foi executado, deseja prosseguir assim mesmo?", "Atenção",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }
                    Cursor.Current = Cursors.WaitCursor;                    
                    using (frmExecucaoPesquisa exPes = new frmExecucaoPesquisa(cad, position))
                    {
                        this.SuspendLayout();
                        Cursor.Current = Cursors.Default;
                        exPes.ShowDialog();
                        this.ResumeLayout();
                        Cursor.Current = Cursors.WaitCursor;

                        cbxSit_TextChanged(cbxSit, null);
                        dataGridListCadastral_CurrentCellChanged(dataGridListCadastral, null);
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Carrega tela com valores padrões.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPesquisaCadastral_Load(object sender, EventArgs e)
        {
            cbxSit.DataSource = SituacaoCombo.getList();

            try
            {
                bindingSourceCadastro.DataSource = SingletonFlow.cadastroFlow.GetListCadSimples("TD", distrito, setor, rota);

                dataGridListCadastral_CurrentCellChanged(dataGridListCadastral, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            flgLoad = 0;
        }

        /// <summary>
        /// Aplica filtro de pesquisa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (flgLoad == 0)
                {
                    bindingSourceCadastro.DataSource = SingletonFlow.cadastroFlow.GetListCadSimples(cbxSit.SelectedValue.ToString(), distrito, setor, rota);
                }
            }
            catch (Exception ex)
            {
                bindingSourceCadastro.Clear();
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        ///  Sobreescreve o evento de teclado herdado do form CustomForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void TecladoinputPanel_EnabledChanged_1(object sender, EventArgs e)
        {
        }

        private void dataGridListCadastral_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((CadastroAuxiliar)bindingSourceCadastro.Current).StatusExecucao == 2)
            {
                menuItem1.Enabled = false;
                btnImpedimento.Enabled = true;
            }
            else
            {
                menuItem1.Enabled = true;
                btnImpedimento.Enabled = false;
            }
        }
    }
}
