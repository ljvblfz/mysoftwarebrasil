using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobileData.Data;
using CommonHelpMobile;

namespace SPCadMobile.View
{
    public partial class frmSelecaoRota : CustomForm
    {


        public frmSelecaoRota()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carrega distrito, setores e rotas
        /// </summary>
        private void carregarTela()
        {
            try
            {
                cbxDistrito.DataSource = SingletonFlow.distritoFlow.getListDistrito();
                if (cbxDistrito.SelectedValue == null) return;

                loadSetor();
                loadRota();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Carrega setores e rotas por distrito.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDistrito_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxDistrito.SelectedValue.ToString() == "S")
                {
                    cbxSetor.DataSource = null;
                    cbxRota.DataSource = null;
                    return;
                }
                loadSetor();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Carrega rotas por setores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSetor_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                loadRota();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Carrega a combo Setor.
        /// </summary>
        private void loadSetor()
        {
            try
            {
                if (cbxDistrito.SelectedValue.ToString() == "S")
                {
                    cbxSetor.DataSource = null;
                    return;
                }

                int distrito = int.Parse(cbxDistrito.SelectedValue.ToString());

                cbxSetor.DataSource = SingletonFlow.rotaFlow.getListSetorByDistrito(distrito);
                cbxSetor.DisplayMember = "Description";
                cbxSetor.ValueMember = "Value";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Carrega a combo Rota.
        /// </summary>
        private void loadRota()
        {
            try
            {
                if (cbxDistrito.SelectedValue.ToString() == "S" || cbxSetor.SelectedValue.ToString() == "S")
                {
                   cbxRota.DataSource = null; 
                    return;
                }

                if (cbxSetor.SelectedValue.ToString() == "S") return;                
                int rota = int.Parse(cbxSetor.SelectedValue.ToString());
                int distrito = int.Parse(cbxDistrito.SelectedValue.ToString());

                cbxRota.DataSource = SingletonFlow.rotaFlow.getListRotaBySetor(rota, distrito);
                cbxRota.DisplayMember = "Description";
                cbxRota.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }        

        /// <summary>
        /// Preenche as combos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSelecaoRota_Load(object sender, EventArgs e)
        {
            carregarTela();
        }

        /// <summary>
        /// Acesso a interface Pesquisa Cadastral.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            int distrito = 0;
            int setor = 0;
            int rota = 0;

            //testa se o distrito foi selecionado.
            if (cbxDistrito.SelectedValue.ToString() == "S")
            {
                MessageBox.Show("Informe o distrito.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            distrito = int.Parse(cbxDistrito.SelectedValue.ToString());

            //testa se o setor foi selecionado.
            if (cbxSetor.SelectedValue.ToString() == "S")
            {
                MessageBox.Show("Informe o setor.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            setor = int.Parse(cbxSetor.SelectedValue.ToString());

            //testa se a rota foi selecionada.
            if (cbxRota.SelectedValue.ToString() == "S")
            {
                MessageBox.Show("Informe a rota.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                rota = int.Parse(cbxRota.SelectedValue.ToString());
                Cursor.Current = Cursors.WaitCursor;
                using (frmPesquisaCadastral pcad = new frmPesquisaCadastral(distrito, setor, rota))
                {
                    this.SuspendLayout();
                    Cursor.Current = Cursors.Default;
                    pcad.ShowDialog();
                    this.ResumeLayout();
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
        /// Sair da interface frmSlecaoRota.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///Acesso a interface Estatística
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mItemEstatistica_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Em desenvolvimento", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);            
        }
    }
}