using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LTmobileData.Data.BFL;
using LTmobile.View;
using GFiscMobile.GPS;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;


namespace LTmobile
{
    public partial class frmAtualizar : Form
    {

        public frmAtualizar()
        {
            InitializeComponent();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                lblHeder.Text = "Atualizando versão.";
                lblHeder.Refresh();
                Cursor.Current = Cursors.WaitCursor;
                labelProgresso.Text = "Baixando o arquivo...";
                labelProgresso.Refresh();
                AtualizaVersao.Atualizar();
                Cursor.Current = Cursors.Default;
                this.Close();
                this.Close();
                System.Diagnostics.Process.Start(Program.GetLocalPath() + "\\Resources\\" + AtualizaVersao.aplicativo, "-a");
            }
            catch (Exception ex)
            {
                labelProgresso.Text = "falha na atualização:\n"+ex.Message + ex.InnerException + ex.StackTrace;
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}