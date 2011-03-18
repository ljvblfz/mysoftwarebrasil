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
using LTmobileData.Data.Model;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace LTmobile.View
{

    public partial class frmMensagemUc : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        public frmMensagemUc(BindingSource bs)
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;
            //Recebe o número da Uc
            int num_Uc = ((Leitura)bs.Current).NUM_UC;

            //Recupea as mensagens específicas da UC
            List<mensagemUc> lstMensagemUc = MensagemUcFlow.getMensagemUc(num_Uc);

            //CArrega o bind com as mensagens
            bsMensagemUc.DataSource = lstMensagemUc;

            //Altera o indice das mensagens
            lblIndice.Text = Indice();
            Cursor.Current = Cursors.Default;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Verifica se é o ultimo registro
            if ((bsMensagemUc.Position + 1) == bsMensagemUc.Count)
            {
                //Retorna para o primeiro registro
                bsMensagemUc.MoveFirst();
                lblIndice.Text = Indice();
            }
            else
            {
                //Vai para proximo registro
                bsMensagemUc.MoveNext();
                lblIndice.Text = Indice();
            }
        }

        /// <summary>
        /// Recupera o indice damensagem
        /// </summary>
        /// <returns></returns>
        private string Indice()
        {
            return (bsMensagemUc.Position + 1) + "/" + (bsMensagemUc.Count);
        }


        private void mnMenu_Click(object sender, EventArgs e)
        {
            //Fecha a tela.
            this.Close();
        }

        private void frmMensagemUc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 115 || e.KeyValue == 114)
            {
                Thread.Sleep(1000);
                Process P = Process.GetProcessById(Process.GetCurrentProcess().Id);
                SetForegroundWindow(P.MainWindowHandle);
            }
        }
    }
}