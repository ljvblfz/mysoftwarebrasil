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
using SPCadMobileData.Data.BFL;
using SPCadMobileSync;
using SPCadMobile.View;


namespace SPCadMobile
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            CommonHelpMobile.TaskBarHelper.Hide();
        }

        /// <summary>
        /// Acessa sistema SPCAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mItemEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Se o usuário for autenticado, a interface Seleção rota é exibida.
                if (SingletonFlow.funcionarioFlow.Autenticar(tbxLogin.Text, tbxSenha.Text))
                {
                    using (frmSelecaoRota selecaoRota = new frmSelecaoRota())
                    {
                        Cursor.Current = Cursors.Default;
                        selecaoRota.ShowDialog();
                    }
                }
            }
            catch (LoginException le)
            {
                MessageBox.Show(le.msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (SenhaException se)
            {
                MessageBox.Show(se.msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
        /// Aciona a interface de sincronização.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mItemReceberEnviar_Click(object sender, EventArgs e)
        {
            using (frmSincronizacao sincronizacao = new frmSincronizacao())
            {
                sincronizacao.ShowDialog();
            }
        }

        /// <summary>
        /// Encerra o sistema SPCAD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mItemSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair do sistema SPCad?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CommonHelpMobile.TaskBarHelper.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Recupera data e hora atual e versão do sistema SPCAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblVersao.Text = "Versão " + Versao.NumeroVersao();//recupera a versão do sistema SPCAD.
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");//recupera a data e hora atual.
        }        
    }
}