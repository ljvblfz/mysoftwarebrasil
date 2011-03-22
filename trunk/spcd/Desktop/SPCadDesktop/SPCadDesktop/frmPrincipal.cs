using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPCadDesktop.Views;
using SPCadDesktop.Relatorios;
using SPCadDesktop.App.ControleUsuario;

namespace SPCadDesktop
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();

            //Pega os dados do banco e exibe no StatusBar
            string connectionString = GDA.GDASettings.DefaultProviderConfiguration.ConnectionString;
            string[] dadosConfig = connectionString.Split(';');
            string[] server = dadosConfig[0].Split('=');
            string[] dataBase = dadosConfig[1].Split('=');
            ldDataBase.Text = "Conectado em : " + server[1] + " - " + dataBase[1];
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pesquisaCadastralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPesquisaCadastral frm = new frmPesquisaCadastral())
            {
                frm.ShowDialog();
            }
        }

        private void distribuiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmDistribuincao frm = new frmDistribuincao())
            {
                frm.ShowDialog();
            }
        }

        private void cadastrosExecutadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRelCadastrosExecutados frm = new frmRelCadastrosExecutados(1))
            {
                frm.ShowDialog();
            }
        }

        private void fonteAlternativaNaoCadastradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRelCadastrosExecutados frm = new frmRelCadastrosExecutados(2))
            {
                frm.ShowDialog();
            }
        }

        private void alteracaoCadastralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRelCadastrosExecutados frm = new frmRelCadastrosExecutados(3))
            {
                frm.ShowDialog();
            }
        }

        private void irregularidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRelIrregularidade frm = new frmRelIrregularidade())
            {
                frm.ShowDialog();
            }
        }

        private void importaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmImportacao frm = new frmImportacao())
            {
                frm.ShowDialog();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmControleUsuario frm = new frmControleUsuario())
            {
                frm.ShowDialog();
            }
        }

    }
}
