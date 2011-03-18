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
    public partial class frmLogin : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd); 

        public static GFiscMobile.GPS.Gps _gps;

        /// <summary>
        /// Razão atual
        /// </summary>
        public static bool _statusSinc;

        /// <summary>
        /// Razão atual
        /// </summary>
        public static bool StatusSinc { get { return _statusSinc; } set { } }

        public static void setStatusSinc(bool status)
        {
            if (status != null)
            {
                _statusSinc = status;
            }

        }

        public frmLogin()
        {

            setStatusSinc(false);

            InitializeComponent();

            lblVersao.Text = "Versão: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software", true);
            try
            {
                rk = rk.OpenSubKey("LTmobileWebService");
                if (rk != null) rk = rk.OpenSubKey("Parametro");
                if (rk == null) return; //se as chaves existirem o processo continua                
                if (rk.ValueCount == 0) return;

                rk = Registry.LocalMachine.OpenSubKey("Software", true);

                ConfigWebService.LigarGpsWebService = Convert.ToBoolean(rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).GetValue("LIGARGPS").ToString());

                

            }
            catch (NullReferenceException)
            {

            }

            _gps = new GFiscMobile.GPS.Gps(System.Threading.ThreadPriority.BelowNormal, 7000);
            /*
            _gps = new GFiscMobile.GPS.Gps(System.Threading.ThreadPriority.BelowNormal, 7000);
            if (!_gps.Opened && ConfigWebService.LigarGpsWebService)
            {                
                _gps.Open();
            }
            */
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txbUsuario.Focus();

           // new KeyPressEventArgs(Convert.ToChar(229));//.Handled = System.Windows.Forms.Keys.Alt;
            //txbSenha.KeyPress += new KeyPressEventHandler();

            

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //Acesso ao sistema
            Boolean boAcesso = false;

            string strUsuario;
            string strSenha;

            //Mensagem de erro.
            string strMsgErro = null;

            //Verifica se usuário e senha foram informados.
            if (string.IsNullOrEmpty(txbUsuario.Text))
                strMsgErro = "Usuário deve ser informado.";
            else if (string.IsNullOrEmpty(txbSenha.Text))
                strMsgErro = "Senha deve ser informada.";

            //Verifica se existe erro
            if (strMsgErro != null)
            {
                MessageBox.Show(strMsgErro, "Acesso LTmobile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                strUsuario = txbUsuario.Text;
                strSenha = txbSenha.Text;

                UsuarioFlow Usuario = new UsuarioFlow();

                //Autenticar usuário
                Cursor.Current = Cursors.WaitCursor;
                boAcesso = Usuario.AutenticarUsuario(strUsuario, strSenha);
                Cursor.Current = Cursors.Default;

                //Usuário atenticado com sucesso
                if (boAcesso)
                {
                    txbUsuario.Text = string.Empty;
                    txbSenha.Text = string.Empty;

                    boAcesso = false;


                    using (frmFiltrarRota filtrarRota = new frmFiltrarRota())
                    {
                        filtrarRota.ShowDialog();
                    }
                    
                }

                else
                {
                    MessageBox.Show("Usuário não cadastrado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }

            }

        }

        private void mnSair_Click(object sender, EventArgs e)
        {
            //Sai do sistema.
            Close();
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            txbUsuario.Focus();
        }

        private void mnSincronizar_Click(object sender, EventArgs e)
        {
            using (frmSincronizacao sincronizacao = new frmSincronizacao())
            {
                sincronizacao.ShowDialog();
            }
        }

        private void tmHoraAtual_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToLongTimeString() != "")
            {
                try
                {
                    txbHora.Text = DateTime.Now.ToLongTimeString();
//                    txbTempoDec.Text = (Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")).Subtract(Convert.ToDateTime(UsuarioFlow.HoraLogin.ToString("yyyy/MM/dd HH:mm:ss")))).ToString();
                }
                catch { }
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {

            
            //System.Windows.Forms.Keys.Alt;
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                txbSenha.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbUsuario.Focus();
            }

            
        }

        /// <summary>
        /// Limpa o ultimo caracter digitado
        /// </summary>
        public void LimpaCaracter(object sender)
        {
            if (((TextBox)sender).Name == "txbSenha")
            {
                int selectStart = ((TextBox)sender).SelectionStart;
                ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(((TextBox)sender).SelectionStart, 1);
                ((TextBox)sender).SelectionStart = selectStart + 1;
            }
        }

        /// <summary>
        /// Muda letra para número
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int selectStart = ((TextBox)sender).SelectionStart;

            

            if (e.KeyChar == 'e' || e.KeyChar == 'E')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                LimpaCaracter(sender);

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "1");

                ((TextBox)sender).SelectionStart = selectStart + 1;
                e.Handled = true;


            }
            else if (e.KeyChar == 'r' || e.KeyChar == 'R')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                LimpaCaracter(sender);

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "2");

                ((TextBox)sender).SelectionStart = selectStart + 1;
                e.Handled = true;

            }
            else if (e.KeyChar == 't' || e.KeyChar == 'T')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                LimpaCaracter(sender);

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "3");

                ((TextBox)sender).SelectionStart = selectStart + 1;
                e.Handled = true;

            }
            else if (e.KeyChar == 'd' || e.KeyChar == 'D')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                LimpaCaracter(sender);

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "4");

                ((TextBox)sender).SelectionStart = selectStart + 1;
                e.Handled = true;

            }
            else if (e.KeyChar == 'f' || e.KeyChar == 'F')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                LimpaCaracter(sender);

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "5");

                ((TextBox)sender).SelectionStart = selectStart + 1;
                e.Handled = true;

            }
            else if (e.KeyChar == 'g' || e.KeyChar == 'G')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                LimpaCaracter(sender);

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "6");

                ((TextBox)sender).SelectionStart = selectStart + 1;
                e.Handled = true;

            }
            else if (e.KeyChar == 'x' || e.KeyChar == 'X')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                LimpaCaracter(sender);

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "7");

                ((TextBox)sender).SelectionStart = selectStart + 1;
                e.Handled = true;

            }
            else if (e.KeyChar == 'c' || e.KeyChar == 'C')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                LimpaCaracter(sender);

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "8");

                ((TextBox)sender).SelectionStart = selectStart + 1;
                e.Handled = true;

            }
            else if (e.KeyChar == 'v' || e.KeyChar == 'V')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                LimpaCaracter(sender);

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "9");

                ((TextBox)sender).SelectionStart = selectStart + 1;
                e.Handled = true;

            }
            else if (e.KeyChar == '.')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                LimpaCaracter(sender);

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "0");

                ((TextBox)sender).SelectionStart = selectStart + 1;
                e.Handled = true;

            }

            //Permite digitar apenas números
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
            {
                e.Handled = true;
            }

        }

        private void frmLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 115 || e.KeyValue == 114)
            {
                Thread.Sleep(1000);
                Process P = Process.GetProcessById(Process.GetCurrentProcess().Id);
                SetForegroundWindow(P.MainWindowHandle);
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizar objAtualizar = new frmAtualizar();
            objAtualizar.Show();
           // Instalacao();

        }

       
     
    }
}