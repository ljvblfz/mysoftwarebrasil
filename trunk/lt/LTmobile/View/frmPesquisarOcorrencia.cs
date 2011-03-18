using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LTmobileData.Data.Model;
using LTmobileData.Data.BFL;
using LTmobile.View;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace LTmobile.View
{
    public partial class frmPesquisarOcorrencia : Form
    {

        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        public Ocorrencia Oc { get; set; }



        public frmPesquisarOcorrencia()
        {
            InitializeComponent();

            //Carrega todas as ocorrencias
            Cursor.Current = Cursors.WaitCursor;
            List<Ocorrencia> lstOcorrencia = new OcorrenciaFlow().getTodasOcorrencias();
            bsPesqOcorrencia.DataSource = lstOcorrencia;
            grdPesqOcorrencia.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void mnSair_Click(object sender, EventArgs e)
        {
            //Sai da tela
            this.Close();
        }

        private void mnSelecionar_Click(object sender, EventArgs e)
        {
            //Gava os dados selecionados
            Oc = (Ocorrencia)bsPesqOcorrencia.Current;

            //Sai da tela
            this.Close();
        }

        private void frmPesquisarOcorrencia_KeyUp(object sender, KeyEventArgs e)
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