using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace LTmobile.View
{
    public partial class frmConfiguracao : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        ConfigWebService configWebService = new ConfigWebService();

        public frmConfiguracao()
        {
            InitializeComponent();
            LoadTela();
            txbWebService.Focus();
        }

        /// <summary>
        /// Carrega a tela com os valores recuperados das chaves no registro.
        /// </summary>
        private void CarregaTela()
        {
            try
            {
                txbWebService.Text = configWebService.WebServiceCurrent;
                txbUsuario.Text = configWebService.LoginWebService;
                txbSenha.Text = configWebService.SenhaWebService;
                txbIntervalo.Text = configWebService.IntervaloWebService;
                txbQuantidade.Text = configWebService.QuantidadeWebService;
                chkLigarGps.Checked = ConfigWebService.LigarGpsWebService;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar propriedades de configuração:" + ex.Message);
            }
        }

        private void LoadTela()
        {
            try
            {
                configWebService.CreateKey();
                configWebService.SetConfigAtual();
                CarregaTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }  

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txbIntervalo.Text == "")
            {
                MessageBox.Show("Intervalo de tempo deve ser informado.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            else if (txbQuantidade.Text == "")
            {
                MessageBox.Show("Quantidade de Uc deve ser informada.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                try
                {
                    //envia dados de configuração do webservice para as chaves do registro local. 
                    configWebService.SetWebService(txbWebService.Text.Trim(), txbUsuario.Text.Trim(), txbSenha.Text.Trim(),txbIntervalo.Text.Trim(), txbQuantidade.Text.Trim(), chkLigarGps.Checked);

                    //recebe os dados de configuração atual.
                    configWebService.SetConfigAtual();

                    CarregaTela();

                    MessageBox.Show("Configuração realizada!", "Configuração webService");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                } 
            }
        }

        private void mnSair_Click(object sender, EventArgs e)
        {
            
        }

        private void mnConfigurar_Click(object sender, EventArgs e)
        {
            
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfiguracao_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                chkLigarGps.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbWebService.Focus();
            }
            

        }

        private void txbIntervalo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permite digitar apenas números
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
            {
                e.Handled = true;
            }
        }

        private void txbQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permite digitar apenas números
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
            {
                e.Handled = true;
            }
        }

        private void frmConfiguracao_KeyUp(object sender, KeyEventArgs e)
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