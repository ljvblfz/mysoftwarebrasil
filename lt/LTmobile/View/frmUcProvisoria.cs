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
    public partial class frmUcProvisoria : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Leitura provisória
        /// </summary>
        LeituraProvisoria leituraProvisoria;

        public frmUcProvisoria()
        {
            InitializeComponent();            
        }

        private void frmUcProvisoria_Load(object sender, EventArgs e)
        {
            //Manda o foco para o medidor
            txbMedidor.Focus();
            cmbTipoMedicao.SelectedIndex = 0;
            
        }

        /// <summary>
        /// Insere a leitura provisória
        /// </summary>
        public void InsertorUpdate()
        {
            //Verifica se campos estão vazios
            string strErro = "";

            if (txbMedidor.Text == "")
            { 
                strErro = "Medidor deve ser informado.";
            }
            else if (txbLeitura.Text == "")
            {
                strErro = "Leitura deve ser informada";
            }
            else if (cmbTipoMedicao.Text == "")
            {
                strErro = "Tipo de medição deve ser informada.";
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                //Recupera a ultima UC cadastrada
                List<Leitura> lstUltimaUcReg = LeituraFlow.getUltimaUcReg();
                Cursor.Current = Cursors.Default;

                if (lstUltimaUcReg.Count > 0)
                {
                    leituraProvisoria = new LeituraProvisoria();
                    /* 
                     leituraProvisoria.COD_LOCAL;
                     leituraProvisoria.COMPL_ATUAL1;
                     leituraProvisoria.COMPL_ATUAL2;
                     leituraProvisoria.COMPL_ATUAL3;*/
                    leituraProvisoria.NUM_RAZAO = lstUltimaUcReg[0].NUM_RAZAO;
                    leituraProvisoria.COD_EMPRT = lstUltimaUcReg[0].COD_EMPRT;

                    if (!frmLogin._gps.Opened && ConfigWebService.LigarGpsWebService)
                    {
                        frmLogin._gps.Open();
                    }
                    if (frmLogin._gps.GetPosition().LatitudeValid)
                    {
                        if (frmLogin._gps.Opened)
                        {
                            leituraProvisoria.COORD_X = frmLogin._gps.GetPosition().Latitude.ToString();
                        }
                    }
                    else
                    {
                        leituraProvisoria.COORD_X = "";
                    }

                    if (frmLogin._gps.GetPosition().LongitudeValid)
                    {
                        if (frmLogin._gps.Opened)
                        {
                            leituraProvisoria.COORD_Y = frmLogin._gps.GetPosition().Longitude.ToString();
                        }
                    }
                    else
                    {
                        leituraProvisoria.COORD_Y = "";
                    }
                   

                    leituraProvisoria.MES_ANO_FATUR = lstUltimaUcReg[0].MES_ANO_FATUR;
                    leituraProvisoria.COD_LOCAL = lstUltimaUcReg[0].COD_LOCAL;

                    leituraProvisoria.DATA_VISITA = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                    leituraProvisoria.HORA_VISITA = DateTime.Now.ToString("HHmmss");
                    /*leituraProvisoria.IRREGL_ATUAL1;
                    leituraProvisoria.IRREGL_ATUAL2;
                    leituraProvisoria.IRREGL_ATUAL3;*/
                    leituraProvisoria.LEITUR_VISITA = int.Parse(txbLeitura.Text);
                    leituraProvisoria.MATRIC_FUNC = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC;
                    //leituraProvisoria.MES_ANO_FATUR;
                    leituraProvisoria.NUM_MEDIDR = txbMedidor.Text;
                    leituraProvisoria.NUM_UC_REF = lstUltimaUcReg[0].NUM_UC;
                    leituraProvisoria.OBSERVACAO = txbObservacao.Text;
                    leituraProvisoria.STATUS_REG = "2";
                    leituraProvisoria.TIPO_MEDIC = cmbTipoMedicao.Text;
                    //Insere a uc provisória
                    try
                    {
                        LeituraProvisoriaFlow.Insert(leituraProvisoria);
                        MessageBox.Show("Uc provisória salva com sucesso.", "Uc Provisória", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        using (frmCapturarFoto capturarFoto = new frmCapturarFoto(leituraProvisoria))
                        {
                            capturarFoto.ShowDialog();
                        }
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível salva Uc provisória. Ex: "+ex+"", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    
                    MessageBox.Show("Não existe Uc de referência.", "Uc Provisória", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }

            //Exibe mensagem de erro
            if (strErro != "")
            {
                MessageBox.Show(strErro, "Uc Provisória", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
          
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            InsertorUpdate();

        }

        private void frmUcProvisoria_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                txbObservacao.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbMedidor.Focus();
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

                if (ConfigWebService.FormatoLeitura != "direita")
                {
                    ((TextBox)sender).SelectionStart = selectStart + 1;
                }
                else
                {
                    ((TextBox)sender).SelectionStart = selectStart;
                }
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

                if (ConfigWebService.FormatoLeitura != "direita")
                {
                    ((TextBox)sender).SelectionStart = selectStart + 1;
                }
                else
                {
                    ((TextBox)sender).SelectionStart = selectStart;
                }
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

                if (ConfigWebService.FormatoLeitura != "direita")
                {
                    ((TextBox)sender).SelectionStart = selectStart + 1;
                }
                else
                {
                    ((TextBox)sender).SelectionStart = selectStart;
                }
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

                if (ConfigWebService.FormatoLeitura != "direita")
                {
                    ((TextBox)sender).SelectionStart = selectStart + 1;
                }
                else
                {
                    ((TextBox)sender).SelectionStart = selectStart;
                }
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

                if (ConfigWebService.FormatoLeitura != "direita")
                {
                    ((TextBox)sender).SelectionStart = selectStart + 1;
                }
                else
                {
                    ((TextBox)sender).SelectionStart = selectStart;
                }
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

                if (ConfigWebService.FormatoLeitura != "direita")
                {
                    ((TextBox)sender).SelectionStart = selectStart + 1;
                }
                else
                {
                    ((TextBox)sender).SelectionStart = selectStart;
                }
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

                if (ConfigWebService.FormatoLeitura != "direita")
                {
                    ((TextBox)sender).SelectionStart = selectStart + 1;
                }
                else
                {
                    ((TextBox)sender).SelectionStart = selectStart;
                }
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

                if (ConfigWebService.FormatoLeitura != "direita")
                {
                    ((TextBox)sender).SelectionStart = selectStart + 1;
                }
                else
                {
                    ((TextBox)sender).SelectionStart = selectStart;
                }
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

                if (ConfigWebService.FormatoLeitura != "direita")
                {
                    ((TextBox)sender).SelectionStart = selectStart + 1;
                }
                else
                {
                    ((TextBox)sender).SelectionStart = selectStart;
                }
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

                if (ConfigWebService.FormatoLeitura != "direita")
                {
                    ((TextBox)sender).SelectionStart = selectStart + 1;
                }
                else
                {
                    ((TextBox)sender).SelectionStart = selectStart;
                }
                e.Handled = true;

            }

            //Permite digitar apenas números
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
            {
                e.Handled = true;
            }

        }



        private void TextBox_KeyPressInvertido(object sender, KeyPressEventArgs e)
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

            }else if (e.KeyChar == '1')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "E");

                ((TextBox)sender).SelectionStart = selectStart + 1;

                e.Handled = true;


            }
            else if (e.KeyChar == '2')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "R");

                ((TextBox)sender).SelectionStart = selectStart + 1;

                e.Handled = true;

            }
            else if (e.KeyChar == '3')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "T");

                ((TextBox)sender).SelectionStart = selectStart + 1;

                e.Handled = true;

            }
            else if (e.KeyChar == '4')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "D");

                ((TextBox)sender).SelectionStart = selectStart + 1;

                e.Handled = true;

            }
            else if (e.KeyChar == '5')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "F");

                ((TextBox)sender).SelectionStart = selectStart + 1;

                e.Handled = true;

            }
            else if (e.KeyChar == '6')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "G");

                ((TextBox)sender).SelectionStart = selectStart + 1;

                e.Handled = true;

            }
            else if (e.KeyChar == '7')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "X");

                ((TextBox)sender).SelectionStart = selectStart + 1;

                e.Handled = true;

            }
            else if (e.KeyChar == '8')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "C");

                ((TextBox)sender).SelectionStart = selectStart + 1;

                e.Handled = true;

            }
            else if (e.KeyChar == '9')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, "V");

                ((TextBox)sender).SelectionStart = selectStart + 1;

                e.Handled = true;

            }
            else if (e.KeyChar == '0')
            {
                if (((TextBox)sender).TextLength >= ((TextBox)sender).MaxLength)
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;

                }

                ((TextBox)sender).Text = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, ".");

                ((TextBox)sender).SelectionStart = selectStart + 1;

                e.Handled = true;

            }
            /*

            //Permite digitar apenas números
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')//a segunda expressão habilita a funcionalidade do botão backspace do teclado.
            {
                e.Handled = true;
            }*/

        }

        private void mnCancelar_Click(object sender, EventArgs e)
        {
            if (leituraProvisoria != null)
            {
                if (FotosFlow.ExisteFoto(leituraProvisoria.NUM_UC_REF, leituraProvisoria.MES_ANO_FATUR, "TMP") < 1)
                {
                    MessageBox.Show("Obrigatório registro de foto para Uc´s provisórias.", "Uc Provisória", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    //Fecha tela
                    this.Close();
                }
            }else
            {
                //Fecha tela
                this.Close();
            }
        }

        private void mnOcorrencia_Click(object sender, EventArgs e)
        {
            if (leituraProvisoria == null)
            {
                MessageBox.Show("Uc provisória deve ser cadastrada.", "Uc Provisória", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                using (frmOcorrenciaUc ocorrenciaUc = new frmOcorrenciaUc(leituraProvisoria))
                {
                    ocorrenciaUc.ShowDialog();
                }
            }
        }

        private void mnFotos_Click(object sender, EventArgs e)
        {

            if (leituraProvisoria == null)
            {
                MessageBox.Show("Uc provisória deve ser cadastrada.", "Uc Provisória", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                using (frmCapturarFoto capturaFoto = new frmCapturarFoto(leituraProvisoria))
                {
                    capturaFoto.ShowDialog();
                }
            }
        }

        private void frmUcProvisoria_KeyUp(object sender, KeyEventArgs e)
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