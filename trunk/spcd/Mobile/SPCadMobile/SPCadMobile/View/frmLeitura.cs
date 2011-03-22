using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPCadMobile.View
{
    public partial class frmLeitura : CustomForm
    {
        public string display { get; set; }

        public frmLeitura()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tbxDisplay.Text = "";
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (tbxDisplay.Text.Length >= 1)
                tbxDisplay.Text = tbxDisplay.Text.Substring(0, tbxDisplay.Text.Length - 1);
        }

        private void btnN0_Click(object sender, EventArgs e)
        {
            if (tbxDisplay.Text.Length <= tbxDisplay.MaxLength)
                tbxDisplay.Text += ((Button)sender).Text;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            display = tbxDisplay.Text;
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            display = string.Empty;
            this.Close();
        }

        private void tbxDisplay_TextChanged(object sender, EventArgs e)
        {
            if ( tbxDisplay.Text.Length == 10)
            {
                tbxDisplay.Text = tbxDisplay.Text.Remove(9, 1);
            }
        }
    }
}

