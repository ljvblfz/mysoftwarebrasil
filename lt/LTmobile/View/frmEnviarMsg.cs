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
    public partial class frmEnviarMsg : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        public frmEnviarMsg()
        {
            InitializeComponent();
            //Manda foco para campo de assunto
            txbAssunto.Focus();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string strErro = "";

            if (txbAssunto.Text == "")
            {
                strErro = "Assunto deve ser informado.";
            }
            else if (txbMensagem.Text == "")
            {
                strErro = "Mensagem deve ser informada.";
            }
            else
            {

                //Carrega informações do correio
                CorreioEletronico correioEletronico = new CorreioEletronico();
                correioEletronico.ID_MSG = CorreioEletronicoFlow.getIdMensagem();
                correioEletronico.COD_EMPRT = UsuarioFlow.UsuarioCurrent.COD_EMPRT;
                correioEletronico.ASSUNTO = txbAssunto.Text;
                //correioEletronico.COD_EMPR = UsuarioFlow.UsuarioCurrent.COD_LOCAL_TRAB;
                correioEletronico.DESC_MSG = txbMensagem.Text;
                //correioEletronico.DT_LEITURA
                correioEletronico.DT_MSG = DateTime.Now;
                correioEletronico.MATRIC_FUNC = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC;
                correioEletronico.TIPO_MSG = "C";
                correioEletronico.STATUS_REG = "2";
                correioEletronico.STATUS_MSG = "0";

                //Insere mensagem
                try
                {
                    CorreioEletronicoFlow.Insert(correioEletronico);
                    MessageBox.Show("Mensagem salva para envio.", "Enviar Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível salvar mensagem. Ex->" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }

            if (strErro != "")
            {
                MessageBox.Show(strErro, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEnviarMsg_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                txbMensagem.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbAssunto.Focus();
            }


        }

        private void frmEnviarMsg_KeyUp(object sender, KeyEventArgs e)
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