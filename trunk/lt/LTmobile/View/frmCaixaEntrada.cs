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
    public partial class frmCaixaEntrada : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        public frmCaixaEntrada()
        {
            InitializeComponent();

            carregarCaixadeSaida();
        }

        public void carregarCaixadeSaida()
        {
            //Carrega as mensagens da caixa de entrada
            List<CorreioEletronico> lstCaixaEntrada = CorreioEletronicoFlow.getCaixaEntrada();
            bsCaixaEntrada.DataSource = lstCaixaEntrada;            
        }


        private void mnVoltar_Click(object sender, EventArgs e)
        {
            //Fecha tela
            this.Close();
        }

        private void mnCaixaSaida_Click(object sender, EventArgs e)
        {
            using (frmCaixaSaida caixadeSaida = new frmCaixaSaida())
            {
                caixadeSaida.ShowDialog();
            }
        }

        private void mnAtualizar_Click(object sender, EventArgs e)
        {
            carregarCaixadeSaida();
        }
        
        private void frmCaixaEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
                if (bsCaixaEntrada.Count > 0)
                {
                    bsCaixaEntrada.MovePrevious();                    
                }


            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                if (bsCaixaEntrada.Count > 0)
                {
                    // Right
                    bsCaixaEntrada.MoveNext();
                    
                }
            }

        }

        private void mnExcluir_Click(object sender, EventArgs e)
        {
            if (bsCaixaEntrada.Count > 0)
            {
                CorreioEletronicoFlow.DeleteMsg(((CorreioEletronico)bsCaixaEntrada.Current).ID_MSG);
                bsCaixaEntrada.Remove(bsCaixaEntrada.Current);
            }
        }

        private void frmCaixaEntrada_KeyUp(object sender, KeyEventArgs e)
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