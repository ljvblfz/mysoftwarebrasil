using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonHelpDesktop;

namespace SPCadDesktop.Views
{
    public partial class frmListAuxPesquisa : Form
    {
        public ItemCombo Item { get; set; }
        private List<ItemCombo> lista;

        public frmListAuxPesquisa(List<ItemCombo> lista, string titulo)
        {
            InitializeComponent();
            this.Text = titulo;
            this.lista = lista;
            bsConsulta.DataSource = lista;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Item = null;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItemCombo item = (ItemCombo)bsConsulta.Current;
            Item = item;
            Close();
        }

        private void tbxBairro_TextChanged(object sender, EventArgs e)
        {
            bsConsulta.DataSource = lista.Where(i => i.Description.ToString().ToUpper().StartsWith(tbxDescricao.Text.ToUpper())).ToList();
        }
    }
}
