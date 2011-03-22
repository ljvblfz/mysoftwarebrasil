using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPCadDesktopData.Data.BFL;
using SPCadDesktopData.Data.Model;
using SPCadDesktopData.Data;

namespace SPCadDesktop.App.ControleUsuario
{
    public partial class frmControleUsuario : Form
    {
        private Funcionario usuario
        {
            get { return usuarioBindingSource.Current as Funcionario; }
        }
        public frmControleUsuario()
        {
            InitializeComponent();
            usuarioBindingSource.DataSource = SingletonFlow.funcionarioFlow.getListFuncionario();

            cboClassificacao.DataSource = TipoFuncionarioCombo.getList();

            SetModoEdicao(false);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SetModoEdicao(!modoEdicao);

            if (!modoEdicao)
            {
                usuarioBindingSource.EndEdit();

                if (usuario.Id == 0)
                {
                    SingletonFlow.funcionarioFlow.Insert(usuario);
                }
                else
                {
                    SingletonFlow.funcionarioFlow.Update(usuario);
                }
                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            SetModoEdicao(false);
            usuarioBindingSource.ResetCurrentItem();

            if ((usuarioBindingSource.Current as Funcionario).Id == 0)
                usuarioBindingSource.RemoveCurrent();

        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            usuarioBindingSource.AddNew();
            cboClassificacao.SelectedIndex = 0;
            SetModoEdicao(true);
        }

        private bool modoEdicao;
        public void SetModoEdicao(bool value)
        {
            modoEdicao = value;
            if (value == true)
                btnSalvar.Text = "Salvar";
            else
                btnSalvar.Text = "Editar";

            txtNome.Enabled = value;
            txtTelefone.Enabled = value;
            txtLogin.Enabled = value;
            txtSenha.Enabled = value;
            cboClassificacao.Enabled = value;
            btnCancelar.Enabled = value;

            grdFuncionarios.Enabled = !value;
            btnAdiciona.Enabled = !value;
        }
    }
}
