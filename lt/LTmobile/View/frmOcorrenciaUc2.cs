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
    public partial class frmOcorrenciaUc2 : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Lista de ocorrencias
        /// </summary>
        List<Ocorrencia> lstOcorrencia;

        /// <summary>
        /// Uc atual
        /// </summary>
        Leitura UC_Atual;

        LeituraProvisoria UC_AtualProvisoria;
        /// <summary>
        /// Tipo da Uc P-provisória, C-Comun
        /// </summary>
        string tipoUc;

        public frmOcorrenciaUc2(Leitura UC)
        {
            InitializeComponent();

            tipoUc = "C";
            //exibe dados da UC selecionada           
            //Carrega os campos da telas
            txbEndereco.Text = UC.ENDER_UC + " " + UC.COMPL_ENDER;
            txbMedidorUc.Text = UC.TIPO_MEDIC + "-" + UC.NUM_MEDIDR;
            txbUc.Text = UC.NUM_UC.ToString();

            UC_Atual = UC;

            MudaTextoOcorrencia();

            controlaCampos();
            
        }

        public frmOcorrenciaUc2(LeituraProvisoria UcProvisoria)
        {
            InitializeComponent();

            tipoUc = "P";

           /* UC_Atual = new Leitura();

            UC_Atual.NUM_UC = UcProvisoria.NUM_UC_REF;
            UC_Atual.NUM_MEDIDR = UcProvisoria.NUM_MEDIDR;
            UC_Atual.COD_EMPRT = UcProvisoria.COD_EMPRT;
            UC_Atual.COD_LOCAL = UcProvisoria.COD_LOCAL;
            UC_Atual.MATRIC_FUNC = UcProvisoria.MATRIC_FUNC;
            UC_Atual.NUM_RAZAO = UcProvisoria.NUM_RAZAO;
            UC_Atual.MES_ANO_FATUR = UcProvisoria.MES_ANO_FATUR;*/

            //exibe dados da UC selecionada           
            //Carrega os campos da telas            
            txbMedidorUc.Text = UcProvisoria.TIPO_MEDIC + "-" + UcProvisoria.NUM_MEDIDR;
            txbUc.Text = UcProvisoria.NUM_UC_REF.ToString();

            UC_AtualProvisoria = UcProvisoria;

            MudaTextoOcorrencia();

            controlaCampos();
        }

        /// <summary>
        /// Altera o texto da ocorrencia
        /// </summary>
        public void MudaTextoOcorrencia()
        {
            if (tipoUc == "C")
            {
                //Verifica qual irregularidade está vazia para ser gravado a ocorrencia
                if (UC_Atual.IRREGL_ATUAL1 == 0)
                {
                    lblOcorrencia.Text = "Ocorr.1:";
                }
                else if (UC_Atual.IRREGL_ATUAL2 == 0)
                {
                    lblOcorrencia.Text = "Ocorr.2:";
                }
                else if (UC_Atual.IRREGL_ATUAL3 == 0)
                {
                    lblOcorrencia.Text = "Ocorr.3:";
                }
            }
            else if (tipoUc == "P")
            {
                //Verifica qual irregularidade está vazia para ser gravado a ocorrencia
                if (UC_AtualProvisoria.IRREGL_ATUAL1 == 0)
                {
                    lblOcorrencia.Text = "Ocorr.1:";
                }
                else if (UC_AtualProvisoria.IRREGL_ATUAL2 == 0)
                {
                    lblOcorrencia.Text = "Ocorr.2:";
                }
                else if (UC_AtualProvisoria.IRREGL_ATUAL3 == 0)
                {
                    lblOcorrencia.Text = "Ocorr.3:";
                }
            }
        
        }

        private void frmOcorrenciaUc_Load(object sender, EventArgs e)
        {
            //Manda o focu para Código da ocorrencia
            txbCodOcorrencia.Focus();
        }

        private void txbCodOcorrencia_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbCodOcorrencia.Text))
            {
                //Carrega a descrição da ocorrencia
                Cursor.Current = Cursors.WaitCursor;
                lstOcorrencia = OcorrenciaFlow.getOcorrencia(txbCodOcorrencia.Text);

                //Vrifica se existe ocorrencia cadastrada para o codigo
                if (lstOcorrencia.Count > 0)
                {
                    txbOcorrencia.Text = lstOcorrencia[0].DESC_IRREGL;
                    txbImpedimento.Text = lstOcorrencia[0].FLAG_IMPEDIMENTO;
                    controlaCampos();
                    
                }
                Cursor.Current = Cursors.Default;
            }

        }

        /// <summary>
        /// Controle de botoes
        /// </summary>
        public void controlaCampos()
        {
            if (lstOcorrencia != null)
            {
                if (lstOcorrencia[0].FLAG_COMPLEMENTO == "N")
                {
                    txbComplemento.BackColor = Color.FromArgb(192, 224, 255);
                }
                else if (lstOcorrencia[0].FLAG_COMPLEMENTO == "S")
                {
                    //txbComplemento.BackColor = Color.LemonChiffon;
                    txbComplemento.BackColor = System.Drawing.SystemColors.Info;
                }
            }
            else
            {
                if (txbCodOcorrencia.Text != "")
                {
                    lstOcorrencia = OcorrenciaFlow.getOcorrencia(txbCodOcorrencia.Text);

                    if (lstOcorrencia[0].FLAG_COMPLEMENTO == "N")
                    {
                        txbComplemento.BackColor = Color.FromArgb(192, 224, 255);
                    }
                    else if (lstOcorrencia[0].FLAG_COMPLEMENTO == "S")
                    {
                        //txbComplemento.BackColor = Color.LemonChiffon;
                        txbComplemento.BackColor = System.Drawing.SystemColors.Info;
                    }
                }
            }

            if (txbCodOcorrencia.Text != "")
            {
                btnAvancar.Text = "Salvar";
            }
            else
            {
                btnAvancar.Text = "Leitura";
            }
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
                        //Verifica se código da ocorrencia está vazio 
            if (txbCodOcorrencia.Text != "")
            {
                //VErifica se existe ocorrencia
                if (lstOcorrencia == null)
                {
                    //Carrega a lista com a ocorrencia especifica
                    Cursor.Current = Cursors.WaitCursor;
                    lstOcorrencia = OcorrenciaFlow.getOcorrencia(txbCodOcorrencia.Text);

                    //Carrega campo de descrição
                    if (lstOcorrencia.Count > 0)
                    {
                        txbOcorrencia.Text = lstOcorrencia[0].DESC_IRREGL;
                        txbImpedimento.Text = lstOcorrencia[0].FLAG_IMPEDIMENTO;
                        controlaCampos();
                    }
                    Cursor.Current = Cursors.Default;
                }
                if (tipoUc == "C")
                {
                    if (txbCodOcorrencia.Text == UC_Atual.IRREGL_ATUAL1.ToString() || txbCodOcorrencia.Text == UC_Atual.IRREGL_ATUAL2.ToString() || txbCodOcorrencia.Text == UC_Atual.IRREGL_ATUAL3.ToString())
                    {
                        MessageBox.Show("Esta ocorrência já está cadastrada para esta UC.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        //Verifica se já existe tres ocorrencias cadastradas
                    }
                    else if (UC_Atual.IRREGL_ATUAL1 != 0 && UC_Atual.IRREGL_ATUAL2 != 0 && UC_Atual.IRREGL_ATUAL3 != 0)
                    {
                        MessageBox.Show("Já existem 3 ocorrências cadastradas para esta Uc.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        //Verifica se Existe ocorrencia para o código informado
                    }
                    else if (OcorrenciaFlow.getOcorrencia(txbCodOcorrencia.Text).Count < 1)
                    {
                        MessageBox.Show("Ocorrência inválida.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        //Verifica se é necessário impedimento
                    }
                    else if (lstOcorrencia[0].FLAG_COMPLEMENTO == "S" && txbComplemento.Text == "")
                    {
                        MessageBox.Show("Complemento deve ser informado.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        txbComplemento.Focus();
                        //verifica se é ocorrencia de impedimento
                    }
                    else if ((lstOcorrencia[0].FLAG_IMPEDIMENTO == "S") && (FotosFlow.ExisteFoto(UC_Atual.NUM_UC, UC_Atual.MES_ANO_FATUR, UC_Atual.TIPO_MEDIC) == 0))
                    {
                        //Verifica se a ocorrencia é de impedimento
                        MessageBox.Show("Ocorrências que geram impedimento são obrigatórias o registro de foto.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        //Abre tela de foto
                        using (frmCapturarFoto capturarFoto = new frmCapturarFoto(UC_Atual))
                        {
                            capturarFoto.ShowDialog();
                        }
                    }
                    else
                    {
                        //Verifica qual irregularidade está vazia para ser gravado a ocorrencia
                        if (UC_Atual.IRREGL_ATUAL1 == 0)
                        {
                            UC_Atual.IRREGL_ATUAL1 = int.Parse(txbCodOcorrencia.Text);
                            if (!string.IsNullOrEmpty(txbComplemento.Text))
                            {
                                UC_Atual.COMPL_ATUAL1 = txbComplemento.Text;
                            }
                        }
                        else if (UC_Atual.IRREGL_ATUAL2 == 0)
                        {
                            UC_Atual.IRREGL_ATUAL2 = int.Parse(txbCodOcorrencia.Text);
                            if (!string.IsNullOrEmpty(txbComplemento.Text))
                            {
                                UC_Atual.COMPL_ATUAL2 = txbComplemento.Text;
                            }
                        }
                        else if (UC_Atual.IRREGL_ATUAL3 == 0)
                        {
                            UC_Atual.IRREGL_ATUAL3 = int.Parse(txbCodOcorrencia.Text);
                            if (!string.IsNullOrEmpty(txbComplemento.Text))
                            {
                                UC_Atual.COMPL_ATUAL3 = txbComplemento.Text;
                            }
                        }

                        UC_Atual.DATA_ATLZ = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                        UC_Atual.HORA_ATLZ = DateTime.Now.ToString("HHmmss");
                        UC_Atual.MATRIC_FUNC = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC;
                        UC_Atual.DATA_VISITA = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                        UC_Atual.HORA_VISITA = DateTime.Now.ToString("HHmmss");
                        //UC_Atual.USUAR_ATLZ = UsuarioFlow.UsuarioCurrent.NOME_FUNC;
                        UC_Atual.USUAR_ATLZ = "Velp";
                        UC_Atual.DATA_CALENDARIO = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                        UC_Atual.ESTADO_SERVC = 1;

                        if (lstOcorrencia[0].FLAG_IMPEDIMENTO == "S")
                        {
                            UC_Atual.STATUS_REG = "2";
                            UC_Atual.ESTADO_SERVC = 2;

                            if (!frmLogin._gps.Opened && ConfigWebService.LigarGpsWebService)
                            {
                                frmLogin._gps.Open();
                            }

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

                                }

                            }
                        }

                        //Insere a ocorrencia
                        try
                        {
                            LeituraFlow.Update(UC_Atual);


                            if (lstOcorrencia[0].FLAG_IMPEDIMENTO == "S")
                            {
                                                                
                                MessageBox.Show("Esta UC foi caracterizada como impedimento.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                this.Close();

                                
                            }
                            MudaTextoOcorrencia();
                            MessageBox.Show("Ocorrência cadastrada com sucesso.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao salvar ocorrência. " + ex + "", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        }

                        //Limpa as ocorrencias da tela
                        txbCodOcorrencia.Text = "";
                        txbOcorrencia.Text = "";
                        txbComplemento.Text = "";
                        txbImpedimento.Text = "";
                        btnAvancar.Text = "Leitura";
                        txbCodOcorrencia.Focus();

                        controlaCampos();


                    }
                }
                else if (tipoUc == "P")
                {
                    if (txbCodOcorrencia.Text == UC_AtualProvisoria.IRREGL_ATUAL1.ToString() || txbCodOcorrencia.Text == UC_AtualProvisoria.IRREGL_ATUAL2.ToString() || txbCodOcorrencia.Text == UC_AtualProvisoria.IRREGL_ATUAL3.ToString())
                    {
                        MessageBox.Show("Esta ocorrência já está cadastrada para UC.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        //Verifica se já existe tres ocorrencias cadastradas
                    }
                    else if (UC_AtualProvisoria.IRREGL_ATUAL1 != 0 && UC_AtualProvisoria.IRREGL_ATUAL2 != 0 && UC_AtualProvisoria.IRREGL_ATUAL3 != 0)
                    {
                        MessageBox.Show("Já existem 3 ocorrências cadastradas para esta Uc.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        //Verifica se Existe ocorrencia para o código informado
                    }
                    else if (OcorrenciaFlow.getOcorrencia(txbCodOcorrencia.Text).Count < 1)
                    {
                        MessageBox.Show("Ocorrência inválida.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        //Verifica se é necessário impedimento
                    }
                    else if (lstOcorrencia[0].FLAG_COMPLEMENTO == "S" && txbComplemento.Text == "")
                    {
                        MessageBox.Show("Complemento deve ser informado.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        txbComplemento.Focus();
                        //verifica se é ocorrencia de impedimento
                    }
                    else if ((lstOcorrencia[0].FLAG_IMPEDIMENTO == "S") && (FotosFlow.ExisteFoto(UC_AtualProvisoria.NUM_UC_REF, UC_AtualProvisoria.MES_ANO_FATUR, "TMP") == 0))
                    {
                        //Verifica se a ocorrencia é de impedimento
                        MessageBox.Show("Ocorrências que geram impedimento são obrigatórias o registro de foto.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        //Abre tela de foto
                        using (frmCapturarFoto capturarFoto = new frmCapturarFoto(UC_AtualProvisoria))
                        {
                            capturarFoto.ShowDialog();
                        }
                    }
                    else
                    {
                        //Verifica qual irregularidade está vazia para ser gravado a ocorrencia
                        if (UC_AtualProvisoria.IRREGL_ATUAL1 == 0)
                        {
                            UC_AtualProvisoria.IRREGL_ATUAL1 = int.Parse(txbCodOcorrencia.Text);
                            if (!string.IsNullOrEmpty(txbComplemento.Text))
                            {
                                UC_AtualProvisoria.COMPL_ATUAL1 = txbComplemento.Text;
                            }
                        }
                        else if (UC_AtualProvisoria.IRREGL_ATUAL2 == 0)
                        {
                            UC_AtualProvisoria.IRREGL_ATUAL2 = int.Parse(txbCodOcorrencia.Text);
                            if (!string.IsNullOrEmpty(txbComplemento.Text))
                            {
                                UC_AtualProvisoria.COMPL_ATUAL2 = txbComplemento.Text;
                            }
                        }
                        else if (UC_AtualProvisoria.IRREGL_ATUAL3 == 0)
                        {
                            UC_AtualProvisoria.IRREGL_ATUAL3 = int.Parse(txbCodOcorrencia.Text);
                            if (!string.IsNullOrEmpty(txbComplemento.Text))
                            {
                                UC_AtualProvisoria.COMPL_ATUAL3 = txbComplemento.Text;
                            }
                        }


                        UC_AtualProvisoria.MATRIC_FUNC = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC;
                        UC_AtualProvisoria.DATA_VISITA = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                        UC_AtualProvisoria.HORA_VISITA = DateTime.Now.ToString("HHmmss");                        
                        /*
                        if (lstOcorrencia[0].FLAG_IMPEDIMENTO == "S")
                        {
                            UC_AtualProvisoria.ESTADO_SERVC = 2;
                        }*/

                        //Insere a ocorrencia
                        try
                        {
                            LeituraProvisoriaFlow.Update(UC_AtualProvisoria);

                            if (lstOcorrencia[0].FLAG_IMPEDIMENTO == "S")
                            {
                                using (frmRotaLeitura rotaLeitura = new frmRotaLeitura())
                                {
                                    this.Close();
                                    MessageBox.Show("Esta UC foi caracterizada como impedimento.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                    rotaLeitura.ShowDialog();

                                }
                            }
                            MudaTextoOcorrencia();
                            MessageBox.Show("Ocorrência cadastrada com sucesso.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao salvar ocorrência. " + ex + "", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        }

                        //Limpa as ocorrencias da tela
                        txbCodOcorrencia.Text = "";
                        txbOcorrencia.Text = "";
                        txbComplemento.Text = "";
                        txbImpedimento.Text = "";
                        btnAvancar.Text = "Leitura";
                        txbCodOcorrencia.Focus();

                        controlaCampos();
                    }
                }
            }
            else
            {
                if (tipoUc == "C")
                {
                    //Abre a tela de leitura
                    using (frmLeitura leitura = new frmLeitura(UC_Atual))
                    {
                        this.Close();
                        leitura.ShowDialog();
                    }
                }
                else if (tipoUc == "P")
                {
                    this.Close();
                }
            }

        }

        private void frmOcorrenciaUc_KeyDown(object sender, KeyEventArgs e)
        {
           
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                txbComplemento.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbCodOcorrencia.Focus();
            }

        }



        private void mnPesquisar_Click(object sender, EventArgs e)
        {
            //Abre a tela de pesquisa de ocorrencia
            using (frmPesquisarOcorrencia pesquisarOcorrencia = new frmPesquisarOcorrencia())
            {
                pesquisarOcorrencia.ShowDialog();

                //Carrega os dados na tela com os dados da pesquisa.
                Ocorrencia oc = pesquisarOcorrencia.Oc;
                if (oc != null)
                {
                    MudaTextoOcorrencia();
                    txbCodOcorrencia.Text = oc.COD_IRREGL.ToString();
                    txbOcorrencia.Text = oc.DESC_IRREGL.ToString();
                    txbImpedimento.Text = oc.FLAG_IMPEDIMENTO;
                    controlaCampos();
                }
                
            }
        }

        private void mnCancelar_Click(object sender, EventArgs e)
        {
            //Fecha tela
            this.Close();
        }

        private void mnApagar_Click(object sender, EventArgs e)
        {
            if (tipoUc == "C")
            {
                //Apaga ocorrência cadastrada.
                if ((UC_Atual.IRREGL_ATUAL1 != 0) || (UC_Atual.IRREGL_ATUAL2 != 0) || (UC_Atual.IRREGL_ATUAL3 != 0))
                {
                    using (frmListaOcorrencia listaOcorrencia = new frmListaOcorrencia(UC_Atual))
                    {
                        listaOcorrencia.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Não existe ocorrência cadastrada para esta Uc.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            else if (tipoUc == "P")
            {
                //Apaga ocorrência cadastrada.
                if ((UC_AtualProvisoria.IRREGL_ATUAL1 != 0) || (UC_AtualProvisoria.IRREGL_ATUAL2 != 0) || (UC_AtualProvisoria.IRREGL_ATUAL3 != 0))
                {
                    using (frmListaOcorrencia listaOcorrencia = new frmListaOcorrencia(UC_AtualProvisoria))
                    {
                        listaOcorrencia.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Não existe ocorrência cadastrada para esta Uc.", "Ocorrência de UC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txbCodOcorrencia_TextChanged(object sender, EventArgs e)
        {
            //Limpa campos
            txbOcorrencia.Text = "";
            txbComplemento.Text = "";
            txbImpedimento.Text = "";

            controlaCampos();
        }

        private void mnFotos_Click(object sender, EventArgs e)
        {
            if (tipoUc == "C")
            {
                using (frmCapturarFoto capturarFoto = new frmCapturarFoto(UC_Atual))
                {
                    capturarFoto.ShowDialog();
                }
            }
            else if (tipoUc == "P")
            {
                using (frmCapturarFoto capturarFoto = new frmCapturarFoto(UC_AtualProvisoria))
                {
                    capturarFoto.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Muda valores de letra para número
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

        private void frmOcorrenciaUc2_KeyUp(object sender, KeyEventArgs e)
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