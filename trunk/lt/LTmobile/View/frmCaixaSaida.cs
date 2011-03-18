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
    public partial class frmCaixaSaida : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        public frmCaixaSaida()
        {
            InitializeComponent();
        }

        private void frmCaixaEntrada_Load(object sender, EventArgs e)
        {
            //CArrega mensagens da caixa de saída
            List<CorreioEletronico> lstCaixaSaida = CorreioEletronicoFlow.getCaixaSaida();
            bsCaixaSaida.DataSource = lstCaixaSaida;
            
            
        }


        private void frmCaixaSaida_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
                if (bsCaixaSaida.Count > 0)
                {
                    bsCaixaSaida.MovePrevious();
                }


            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                if (bsCaixaSaida.Count > 0)
                {
                    // Right
                    bsCaixaSaida.MoveNext();

                }
            }
        }

        private void mnExcluir_Click(object sender, EventArgs e)
        {
            if (bsCaixaSaida.Count > 0)
            {
                CorreioEletronicoFlow.DeleteMsg(((CorreioEletronico)bsCaixaSaida.Current).ID_MSG);
                bsCaixaSaida.Remove(bsCaixaSaida.Current);
            }
        }

        private void mnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCaixaSaida_KeyUp(object sender, KeyEventArgs e)
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