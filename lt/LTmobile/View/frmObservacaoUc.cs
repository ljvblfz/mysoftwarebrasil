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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace LTmobile.View
{
    public partial class frmObservacaoUc : Form
    {

        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        Leitura UC_Atual;

        public frmObservacaoUc(Leitura leitura)
        {
            InitializeComponent();

            UC_Atual = leitura;

            txbObservacao.Focus();

            txbEndereco.Text = leitura.EnderecoComplemento;
            txbMedidorUc.Text = leitura.MedidorTipoMed;            
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txbObservacao.Text != "")
            {
                try
                {
                    mensagemUc mensagem = new mensagemUc();
                    mensagem.ID_MSG = MensagemUcFlow.getIdMensagem();
                    mensagem.COD_EMPRT = UC_Atual.COD_EMPRT;
                    mensagem.COD_LOCAL = UC_Atual.COD_LOCAL;
                    mensagem.MES_ANO_FATUR = UC_Atual.MES_ANO_FATUR;
                    mensagem.NUM_RAZAO = UC_Atual.NUM_RAZAO;
                    mensagem.NUM_UC = UC_Atual.NUM_UC;
                    mensagem.DESC_MSG = txbObservacao.Text;
                    mensagem.FLAG_SENTIDO = "C";
                    mensagem.DT_MSG = DateTime.Now;
                    mensagem.STATUS_REG = "2";
                    mensagem.TIPO_MEDIC = UC_Atual.TIPO_MEDIC;
                    MensagemUcFlow.Insert(mensagem);

                    MessageBox.Show("Observação salva com sucesso.", "Observação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    /*using (frmRotaLeitura rotaLeitura = new frmRotaLeitura())
                    {
                        this.Close();
                        rotaLeitura.ShowDialog();
                    }*/
                    this.Close();
                }
                catch { }

            }
            else
            {
                MessageBox.Show("Observação não informada.", "Observação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmObservacaoUc_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                txbObservacao.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbObservacao.Focus();
            }
            

        }

        private void frmObservacaoUc_KeyUp(object sender, KeyEventArgs e)
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