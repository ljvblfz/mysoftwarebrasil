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
    public partial class frmLeitura : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Uc atual
        /// </summary>
        Leitura UC_Atual;

        /// <summary>
        /// Leitura atual
        /// </summary>
        string strLeituraAtual;

        public frmLeitura(Leitura UC)
        {
            InitializeComponent();

            //exibe dados da UC selecionada           
            txbEndereco.Text = UC.ENDER_UC + " " + UC.COMPL_ENDER;
            txbMedidorUc.Text = UC.TIPO_MEDIC + "-" + UC.NUM_MEDIDR;
            txbUc.Text = UC.NUM_UC.ToString();

            UC_Atual = UC;

            
            

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txbLeitura.Text == "")
            {
                MessageBox.Show("Leitura deve ser informada.", "Execução Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else if (!ValidaPadraoLeitura())
            {
                if (strLeituraAtual != txbLeitura.Text)
                {
                    MessageBox.Show("Leitura fora do padrão. Redigite a leitura", "Execução de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    strLeituraAtual = txbLeitura.Text;
                    txbLeitura.Text = "";

                }
                else
                {
                    ExecutarLeitura();
                }
            }
            else
            {
                ExecutarLeitura();                
            }
            
        }

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

        public void ExecutarLeitura()
        {
            try
            {
                UC_Atual.DATA_VISITA = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                UC_Atual.HORA_VISITA = DateTime.Now.ToString("HHmmss");
                UC_Atual.LEITUR_VISITA = int.Parse(txbLeitura.Text);
                UC_Atual.ESTADO_SERVC = 1;
                UC_Atual.STATUS_REG = "2";
                UC_Atual.DATA_ATLZ = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                UC_Atual.HORA_ATLZ = DateTime.Now.ToString("HHmmss");
                UC_Atual.MATRIC_FUNC = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC;
                //UC_Atual.USUAR_ATLZ = UsuarioFlow.UsuarioCurrent.NOME_FUNC;
                UC_Atual.USUAR_ATLZ = "Velp";
                UC_Atual.DATA_CALENDARIO = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                /*if (!frmLogin._gps.Opened && ConfigWebService.LigarGpsWebService)
                {
                    frmLogin._gps.Open();
                }*/

                if (UC_Atual.COORD_X == "")
                {
                    if (frmLogin._gps.Opened && frmLogin._gps.GetPosition().LatitudeValid)
                    {
                        UC_Atual.COORD_X = frmLogin._gps.GetPosition().Latitude.ToString();
                    }

                }

                if (UC_Atual.COORD_Y == "")
                {
                    if (frmLogin._gps.Opened && frmLogin._gps.GetPosition().LongitudeValid)
                    {
                        UC_Atual.COORD_Y = frmLogin._gps.GetPosition().Longitude.ToString();

                        if (UC_Atual.COORD_X != "")
                        { frmLogin._gps.Close(); }
                    }

                }


                LeituraFlow.Update(UC_Atual);

                if (txbObservacao.Text != "")
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
                    MensagemUcFlow.Insert(mensagem);

                }

                MessageBox.Show("Leitura salva com sucesso.", "Execução de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                /*using (frmRotaLeitura rotaLeitura = new frmRotaLeitura())
                {
                    this.Close();
                    rotaLeitura.ShowDialog();
                }*/
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar leitura. Ex "+ex+"", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }


        private void frmLeitura_Load(object sender, EventArgs e)
        {
            txbLeitura.Focus();
        }

        private void frmLeitura_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                txbObservacao.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbLeitura.Focus();
            }
                       
        }

        /// <summary>
        /// Valida se leitura está fora dos padões
        /// </summary>
        /// <returns></returns>
        public bool ValidaPadraoLeitura()
        {
            if (txbLeitura.Text != "")
            {
                if ((int.Parse(txbLeitura.Text) > UC_Atual.LEITUR_MAX) || (int.Parse(txbLeitura.Text) < UC_Atual.LEITUR_MIN))
                {
                    return false;
                }
                else
                {
                    return true;

                }
            }
            else
            {
                return false;
            }
        }


        private void mnFotos_Click(object sender, EventArgs e)
        {
            using (frmCapturarFoto capturarFoto = new frmCapturarFoto(UC_Atual))
            {
                capturarFoto.ShowDialog();
            }
        }

        private void mnOcorrencia_Click(object sender, EventArgs e)
        {
            using (frmOcorrenciaUc ocorrenciaUc = new frmOcorrenciaUc(UC_Atual))
            {
                ocorrenciaUc.ShowDialog();
            }
        }

        private void mnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLeitura_KeyUp(object sender, KeyEventArgs e)
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