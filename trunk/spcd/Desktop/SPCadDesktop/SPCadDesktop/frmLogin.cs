using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Reflection;
using SPCadDesktopData.Data.BFL;
using SPCadDesktopData.Data;
using SPCadDesktopData.Data.BFL.CustomException;

namespace SPCadDesktop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.lblVersion.Text = String.Format("Version {0}", AssemblyVersion);
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Se o usuário for autenticado, a interface Seleção rota é exibida.
                if (SingletonFlow.funcionarioFlow.Autenticar(txtUsuario.Text, txtSenha.Text))
                {
                    txtSenha.Clear();
                    using (frmPrincipal frm = new frmPrincipal())
                    {
                        frm.ShowDialog();
                    }
                }
            }
            catch (LoginException le)
            {
                MessageBox.Show(le.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (SenhaException se)
            {
                MessageBox.Show(se.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
