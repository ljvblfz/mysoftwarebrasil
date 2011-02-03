using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BlogSample.Models;

namespace BlogSample.UI
{
    public partial class Gerador : Form
    {
        public Gerador()
        { 
            InitializeComponent();
            BD.getCofig();
            //checkedListBox1.Items.AddRange(BD.getTabelas());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<IDictionary<string, object>> projetoDados = new List<IDictionary<string, object>>();
            string autor = "";
            string projeto = "";
            int total = 0;
            if (textBoxAutor != null)
                autor = textBoxAutor.ToString();
            if (textBoxProjeto != null)
                projeto = textBoxProjeto.ToString();
            total = checkedListBox1.CheckedItems.Count;
            for (int i = 0; i < total; i++)
            {
                string tabela = checkedListBox1.CheckedItems[i].ToString();
                projetoDados = BD.getDados(tabela);
            }
        }
    }
}
