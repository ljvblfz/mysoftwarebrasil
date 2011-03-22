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
    public partial class frmListAuxChecked : Form
    {
        public List<ItemCombo> Selecao { get; set; }
        private List<ItemCombo> lista;

        public frmListAuxChecked(List<ItemCombo> lista, string titulo)
        {
            InitializeComponent();
            this.Text = titulo;
            this.lista = lista;
            bsConsulta.DataSource = lista;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Selecao = null;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ItemCombo> itens = new List<ItemCombo>();
            ItemCombo item;
            for (int j = 0; j <= dataGridView1.RowCount - 1; j++)
            {
                DataGridViewCell cell = dataGridView1[0, j];
                if (cell.Value != null && cell.Value.ToString() == "1")
                {
                    item = (ItemCombo)bsConsulta.List[j];
                    itens.Add(item);
                }
            }

            Selecao = (itens.Count > 0) ? itens : null;
            Close();
        }

    }
}
