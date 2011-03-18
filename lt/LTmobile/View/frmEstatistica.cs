﻿using System;
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
    public partial class frmEstatistica : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        public frmEstatistica()
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            txbVisitados.Text = LeituraFlow.getQtdUcVisitada().ToString() + " / " + LeituraFlow.getQtdUc().ToString();
            txbRepasse.Text = LeituraFlow.getQtdRepasseRealizado().ToString()+" / "+LeituraFlow.getQtdRepasse().ToString();
            txbImpedimento.Text = LeituraFlow.getQtdImpedimento().ToString();
           // txbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            Cursor.Current = Cursors.Default;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToLongTimeString() != "")
            {
                try
                {
                    txbHora.Text = DateTime.Now.ToLongTimeString();
                    txbTempoDec.Text = (Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")).Subtract(Convert.ToDateTime(UsuarioFlow.HoraLogin.ToString("yyyy/MM/dd HH:mm:ss")))).ToString();
                }
                catch { }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEstatistica_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.F1))
            {
                // Soft Key 1
                // Not handled when menu is present.
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.F2))
            {
                // Soft Key 2
                // Not handled when menu is present.
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D1))
            {
                // 1
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D2))
            {
                // 2
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D3))
            {
                // 3
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D4))
            {
                // 4
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D5))
            {
                // 5
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D6))
            {
                // 6
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D7))
            {
                // 7
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D8))
            {
                // 8
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D9))
            {
                // 9
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.F8))
            {
                // *
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D0))
            {
                // 0
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.F9))
            {
                // #
            }

        }

        private void frmEstatistica_KeyUp(object sender, KeyEventArgs e)
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