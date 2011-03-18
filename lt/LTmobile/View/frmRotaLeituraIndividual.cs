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
    public partial class frmRotaLeituraIndividual : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Leitura atual
        /// </summary>
        string strLeituraAtual = "";
        /// <summary>
        /// UC selecionada
        /// </summary>
        Leitura UC;

        /// <summary>
        /// Direção do roteiro 0-Asc 1-Desc
        /// </summary>
        int DirecaoRoteiro = 0;

        /// <summary>
        /// Rota de Leitura
        /// </summary>
        List<Leitura> LstRotaLeitura;

        /// <summary>
        /// Status da interface
        /// </summary>
        enum ModoInteface { Edicao, Exibicao };

        /// <summary>
        /// Status da inteface
        /// </summary>
        string strModoInterface = "Exibicao";

        bool boExigeFoto = false;

        string strLeituraAnterior = "";
        string strIrreg1Ant = "";
        string strIrreg2Ant = "";
        string strIrreg3Ant = "";

        public frmRotaLeituraIndividual()
        {
            InitializeComponent();
     
            //Preenche o grid com as UC´s
            Cursor.Current = Cursors.WaitCursor;
            //Preenche a lista rota de leitura

            string servico = LeituraFlow.ServicoCurrent;

            if (servico == "Repasse")
            {
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraRepasseAsc();             
            }
            else if (servico == "Não Executados")
            {               
                   //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraNExecutadosAsc();
            }
            else if (servico == "Primeira Execução")
            {                
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraPriExecucaoAsc();

            }
            else
            {                
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraAsc();                
            }

           // LstRotaLeitura = LeituraFlow.getRotaLeituraNExecutadosAsc();
            bsRotaLeituraIndividual.DataSource = LstRotaLeitura;
            if (bsRotaLeituraIndividual.Count>0)
            {
                UC = (Leitura)bsRotaLeituraIndividual.Current;
                imgCarta.Visible = MensagemUcFlow.existeMensagem(((Leitura)bsRotaLeituraIndividual.Current).NUM_UC);
            }
            Cursor.Current = Cursors.Default;

            mnOcorrencia.Enabled = false;
            montaMenu();
            
        }

        public void montaMenu()
        {
            mnMenu.MenuItems.Remove(mnFormatoLeitura);
            mnMenu.MenuItems.Remove(mnPesquisarUc);
            mnMenu.MenuItems.Remove(mnEstatistica);
            mnMenu.MenuItems.Remove(mnUcProvisoria);
            mnMenu.MenuItems.Remove(mnMensagemUc);
            mnMenu.MenuItems.Remove(mnInverterRoteiro);
            mnMenu.MenuItems.Remove(mnExibir);
            mnMenu.MenuItems.Remove(mnMensagem);
            mnMenu.MenuItems.Remove(mnFotos);
            mnMenu.MenuItems.Remove(mnOcorrencia);
            mnMenu.MenuItems.Remove(mnObservacao);
            mnMenu.MenuItems.Remove(mnSincronizar);
            mnMenu.MenuItems.Remove(mnNomeCliente);
            mnMenu.MenuItems.Remove(mnFechar);

            mnMenu.MenuItems.Add(mnFormatoLeitura);
            mnMenu.MenuItems.Add(mnPesquisarUc);
            mnMenu.MenuItems.Add(mnEstatistica);
            mnMenu.MenuItems.Add(mnUcProvisoria);
            mnMenu.MenuItems.Add(mnMensagemUc);
            mnMenu.MenuItems.Add(mnInverterRoteiro);
           // mnMenu.MenuItems.Add(mnExibir);
            mnMenu.MenuItems.Add(mnMensagem);
            mnMenu.MenuItems.Add(mnFotos);
            //mnMenu.MenuItems.Add(mnOcorrencia);
            mnMenu.MenuItems.Add(mnObservacao);
            mnMenu.MenuItems.Add(mnSincronizar);
            mnMenu.MenuItems.Add(mnNomeCliente);
            mnMenu.MenuItems.Add(mnFechar);
        }


        private void frmRotaLeituraIndividual_Load(object sender, EventArgs e)
        {
           /* Cursor.Current = Cursors.WaitCursor;
            List<Leitura> lstRotaLeitura = LeituraFlow.getRotaLeituraAsc();
            bsRotaLeituraIndividual.DataSource = lstRotaLeitura;
            imgCarta.Visible = MensagemUcFlow.existeMensagem(((Leitura)bsRotaLeituraIndividual.Current).NUM_UC);
            Cursor.Current = Cursors.Default;*/
        }

        private void frmRotaLeituraIndividual_KeyDown(object sender, KeyEventArgs e)
        {
            if (strModoInterface == ModoInteface.Exibicao.ToString())
            {
                if ((e.KeyCode == System.Windows.Forms.Keys.Left))
                {
                    // Left
                    if (bsRotaLeituraIndividual.Count > 0)
                    {
                        bsRotaLeituraIndividual.MovePrevious();
                        imgCarta.Visible = MensagemUcFlow.existeMensagem(((Leitura)bsRotaLeituraIndividual.Current).NUM_UC);
                    }


                }
                if ((e.KeyCode == System.Windows.Forms.Keys.Right))
                {
                    if (bsRotaLeituraIndividual.Count > 0)
                    {
                        // Right
                        bsRotaLeituraIndividual.MoveNext();
                    
                        imgCarta.Visible = MensagemUcFlow.existeMensagem(((Leitura)bsRotaLeituraIndividual.Current).NUM_UC);
                    }
                }
            }
            else if (strModoInterface == ModoInteface.Edicao.ToString())
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Up)
                {
                    txbIrreg3.Focus();
                }

                if (e.KeyCode == System.Windows.Forms.Keys.Down)
                {
                    txbLeitura.Focus();
                }
            }

        }



        /// <summary>
        /// Verifica se a leitura é repasse
        /// </summary>
        /// <returns></returns>
        public bool ValidaRepasseLeitura()
        {
            //Repasse = 1, Não repasse = 0
            if (UC.FLAG_REPASSE == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valida se a Uc está com impedimento
        /// </summary>
        /// <returns></returns>
        public bool ValidaImpedimentoLeitura()
        {
            if (UC.ESTADO_SERVC == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valida as irregularidades
        /// </summary>
        private bool ValidarIrregularidade()
        {
            string strMensagem = "";

            if (((txbIrreg1.Text != "" && txbIrreg1.Text != "0") && (txbIrreg2.Text != "" && txbIrreg2.Text != "0"))&& (txbIrreg1.Text == txbIrreg2.Text))
            { 
                
                    strMensagem = "Não pode existir duas irregularidades iguais para a mesma UC.";
                
            }
            else if (((txbIrreg1.Text != "" && txbIrreg1.Text != "0") && (txbIrreg3.Text != "" && txbIrreg3.Text != "0"))&&(txbIrreg1.Text == txbIrreg3.Text))
            {
                
                    strMensagem = "Não pode existir duas irregularidades iguais para a mesma UC.";
                
            }
            else if (((txbIrreg3.Text != "" && txbIrreg3.Text != "0") && (txbIrreg2.Text != "" && txbIrreg2.Text != "0")) && (txbIrreg3.Text == txbIrreg2.Text))
            {
                
                    strMensagem = "Não pode existir duas irregularidades iguais para a mesma UC.";
                
            }
            else if ((txbIrreg1.Text != "" && txbIrreg1.Text != "0") && (OcorrenciaFlow.getOcorrencia(txbIrreg1.Text).Count < 1))
            {
                strMensagem = "Irreg.1 inválida.";
                
            }
            else if ((txbIrreg2.Text != "" && txbIrreg2.Text != "0") && (OcorrenciaFlow.getOcorrencia(txbIrreg2.Text).Count < 1))
            {
                strMensagem = "Irreg.2 inválida.";

            }
            else if ((txbIrreg3.Text != "" && txbIrreg3.Text != "0") && (OcorrenciaFlow.getOcorrencia(txbIrreg3.Text).Count < 1))
            {
                strMensagem = "Irreg.3 inválida.";

            }
            /*else if ((txbLeitura.Text != "0" && txbLeitura.Text != "")&&(UC.LEITUR_ANTER == int.Parse(txbLeitura.Text)) && (txbIrreg1.Text != "39" && txbIrreg2.Text != "39" && txbIrreg3.Text != "39"))
            {
                if (MessageBox.Show(string.Format("Há vestígio de energia no local? O disco do medidor está girando? Há vestígio de local habitado?"), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (txbIrreg1.Text == "" || txbIrreg1.Text == "0")
                    {
                        txbIrreg1.Text = "39";
                    }
                    else if (txbIrreg2.Text == "" || txbIrreg2.Text == "0")
                    {
                        txbIrreg2.Text = "39";
                    }
                    else if (txbIrreg3.Text == "" || txbIrreg3.Text == "0")
                    {
                        txbIrreg3.Text = "39";
                    }
                    else
                    {
                        txbIrreg3.Text = "39";
                    }
                    return false;
                }

            }*/
            /*else if ((txbLeitura.Text != "0" && txbLeitura.Text != "") && (int.Parse(txbLeitura.Text) < UC.LEITUR_ANTER) && ((FotosFlow.ExisteFoto(UC.NUM_UC, UC.MES_ANO_FATUR, UC.TIPO_MEDIC) == 0)))
            {
                MessageBox.Show("Leitura Atual Menor que Anterior. Necessário registro de FOTO.");
                //Abre tela de foto
                using (frmCapturarFoto capturarFoto = new frmCapturarFoto(UC))
                {
                    capturarFoto.ShowDialog();
                }
                return false;
            }*/
            else if (((txbIrreg1.Text != "" && txbIrreg1.Text != "0") && OcorrenciaFlow.NecessitaComplemento(txbIrreg1.Text) && UC.COMPL_ATUAL1 == "")||((txbIrreg2.Text != "" && txbIrreg2.Text != "0") && OcorrenciaFlow.NecessitaComplemento(txbIrreg2.Text) && UC.COMPL_ATUAL2 == "")||((txbIrreg3.Text != "" && txbIrreg3.Text != "0") && OcorrenciaFlow.NecessitaComplemento(txbIrreg3.Text) && UC.COMPL_ATUAL3 == ""))
            {
                UC.IRREGL_ATUAL1 = (txbIrreg1.Text != "") ? int.Parse(txbIrreg1.Text) : 0;
                UC.IRREGL_ATUAL2 = (txbIrreg2.Text != "") ? int.Parse(txbIrreg2.Text) : 0;
                UC.IRREGL_ATUAL3 = (txbIrreg3.Text!="")?int.Parse(txbIrreg3.Text):0;
                //Abre tela de complemento
                using (frmOcorrenciaUc ocorrenciaUc = new frmOcorrenciaUc(UC))
                {
                    ocorrenciaUc.ShowDialog();
                }
                return false;
            }/*            
            else if ((FotosFlow.ExisteFoto(UC.NUM_UC, UC.MES_ANO_FATUR, UC.TIPO_MEDIC) == 0) && (OcorrenciaFlow.ExigeFoto((txbIrreg1.Text == "") ? 0 : int.Parse(txbIrreg1.Text), (txbIrreg2.Text == "") ? 0 : int.Parse(txbIrreg2.Text), (txbIrreg3.Text == "") ? 0 : int.Parse(txbIrreg3.Text))))
            {
                //Verifica se a ocorrencia é de impedimento                
                MessageBox.Show("Ocorrência com obrigatoriedade de registro de foto.", "Execução de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                //Abre tela de foto
                using (frmCapturarFoto capturarFoto = new frmCapturarFoto(UC))
                {
                    capturarFoto.ShowDialog();
                }
                return false;
            }*/

            if (strMensagem != "")
            {
                MessageBox.Show(strMensagem, "Execução de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else { return true; }
        }


        /// <summary>
        /// Grava leitura no banco
        /// </summary>
        public void ExecutarLeitura()
        {
            try
            {
                UC.DATA_VISITA = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                UC.HORA_VISITA = DateTime.Now.ToString("HHmmss");
                UC.LEITUR_VISITA = (txbLeitura.Text == "")? 0 : int.Parse(txbLeitura.Text);
                UC.ESTADO_SERVC = 1;
                if (OcorrenciaFlow.ExisteOcorrenciaImpedimento((txbIrreg1.Text == "") ? 0 : int.Parse(txbIrreg1.Text), (txbIrreg2.Text == "") ? 0 : int.Parse(txbIrreg2.Text), (txbIrreg3.Text == "") ? 0 : int.Parse(txbIrreg3.Text)))
                {
                    UC.ESTADO_SERVC = 2;
                    UC.LEITUR_VISITA = 0;
                }
                if (UC.FLAG_REPASSE == "1")
                {
                    UC.ESTADO_SERVC = 6;
                }

                UC.STATUS_REG = "2";
                UC.DATA_ATLZ = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                UC.HORA_ATLZ = DateTime.Now.ToString("HHmmss");
                UC.MATRIC_FUNC = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC;
                //UC.USUAR_ATLZ = UsuarioFlow.UsuarioCurrent.NOME_FUNC;
                UC.USUAR_ATLZ = "Velp";
                UC.DATA_CALENDARIO = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                UC.IRREGL_ATUAL1 = (txbIrreg1.Text != "") ? int.Parse(txbIrreg1.Text) : 0;
                UC.IRREGL_ATUAL2 = (txbIrreg2.Text != "") ? int.Parse(txbIrreg2.Text) : 0;
                UC.IRREGL_ATUAL3 = (txbIrreg3.Text != "") ? int.Parse(txbIrreg3.Text) : 0;

                if (UC.COORD_X == "")
                {
                    if (frmLogin._gps.Opened && frmLogin._gps.GetPosition().LatitudeValid)
                    {
                        UC.COORD_X = frmLogin._gps.GetPosition().Latitude.ToString();
                    }

                }

                if (UC.COORD_Y == "")
                {
                    if (frmLogin._gps.Opened && frmLogin._gps.GetPosition().LongitudeValid)
                    {
                        UC.COORD_Y = frmLogin._gps.GetPosition().Longitude.ToString();

                        if (UC.COORD_X != "")
                        { frmLogin._gps.Close(); }
                    }

                }


                LeituraFlow.Update(UC);

                MessageBox.Show("Leitura salva com sucesso.", "Execução de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                
                if (OcorrenciaFlow.ExisteOcorrenciaImpedimento((txbIrreg1.Text == "") ? 0 : int.Parse(txbIrreg1.Text), (txbIrreg2.Text == "") ? 0 : int.Parse(txbIrreg2.Text), (txbIrreg3.Text == "") ? 0 : int.Parse(txbIrreg3.Text)))
                {
                    MessageBox.Show("Esta UC foi caracterizada como impedimento.", "Execução de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

                bsRotaLeituraIndividual.RemoveCurrent();
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar leitura. Ex " + ex + "", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                if (UC.LEITUR_MAX > UC.LEITUR_MIN)
                {
                    if ((int.Parse(txbLeitura.Text) > UC.LEITUR_MAX) || (int.Parse(txbLeitura.Text) < UC.LEITUR_MIN))
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
                    if ((int.Parse(txbLeitura.Text) < UC.LEITUR_MAX) || (int.Parse(txbLeitura.Text) > UC.LEITUR_MIN))
                    {
                        return false;
                    }
                    else
                    {
                        return true;

                    }
                }
            }
            else
            {
                return false;
            }
        }

        private void ControlaCamposEdicao()
        {
            //Executar Leitura            
            /*txbLeitura.Enabled = true;
            txbIrreg1.Enabled = true;
            txbIrreg2.Enabled = true;
            txbIrreg3.Enabled = true;*/

            mnOcorrencia.Enabled = true;
            
            txbLeitura.TabStop = true;
            txbIrreg1.TabStop = true;
            txbIrreg2.TabStop = true;
            txbIrreg3.TabStop = true;

            txbLeitura.Text = (txbLeitura.Text == "0") ? "" : txbLeitura.Text;

            txbIrreg1.Text = (txbIrreg1.Text == "0") ? "" : txbIrreg1.Text;
            txbIrreg2.Text = (txbIrreg2.Text == "0") ? "" : txbIrreg2.Text;
            txbIrreg3.Text = (txbIrreg3.Text == "0") ? "" : txbIrreg3.Text;

            txbLeitura.Focus();
            btnLeitura.Text = "Confirmar";
            mnFechar.Text = "Cancelar";

            mnMenu.MenuItems.Remove(mnPesquisarUc);
            mnMenu.MenuItems.Remove(mnEstatistica);
            mnMenu.MenuItems.Remove(mnUcProvisoria);
            mnMenu.MenuItems.Remove(mnInverterRoteiro);
            mnMenu.MenuItems.Remove(mnExibir);
            mnMenu.MenuItems.Remove(mnMensagem);
            mnMenu.MenuItems.Remove(mnSincronizar);

            txbIrreg1.Enabled = true;

            if (string.IsNullOrEmpty(txbIrreg1.Text) && string.IsNullOrEmpty(txbIrreg2.Text))
            {
                txbIrreg2.Enabled = false;
            }
            else 
            {
                txbIrreg2.Enabled = true;
            }

            if (string.IsNullOrEmpty(txbIrreg2.Text) && string.IsNullOrEmpty(txbIrreg3.Text))
            {
                txbIrreg3.Enabled = false;
            }
            else
            {
                txbIrreg3.Enabled = true;
            }
            

            strModoInterface = ModoInteface.Edicao.ToString();


        }

        private void ControlaCamposExibicao()
        {
            //Executar Leitura            
           /* txbLeitura.Enabled = false;
            txbIrreg1.Enabled = false;
            txbIrreg2.Enabled = false;
            txbIrreg3.Enabled = false;*/

            txbIrreg1.Enabled = true;
            txbIrreg2.Enabled = true;
            txbIrreg3.Enabled = true;

            mnOcorrencia.Enabled = false;
            
            txbLeitura.TabStop = false;
            txbIrreg1.TabStop = false;
            txbIrreg2.TabStop = false;
            txbIrreg3.TabStop = false;

            txbFoco.Focus();

            btnLeitura.Text = "Leitura";
            mnFechar.Text = "Sair";

            montaMenu();

            /*mnMenu.MenuItems.Remove(mnMensagemUc);
            mnMenu.MenuItems.Remove(mnFotos);
            mnMenu.MenuItems.Remove(mnOcorrencia);
            mnMenu.MenuItems.Remove(mnObservacao);
            mnMenu.MenuItems.Remove(mnFechar);

            mnMenu.MenuItems.Add(mnPesquisarUc);
            mnMenu.MenuItems.Add(mnEstatistica);
            mnMenu.MenuItems.Add(mnUcProvisoria);
            mnMenu.MenuItems.Add(mnMensagemUc);
            mnMenu.MenuItems.Add(mnInverterRoteiro);
            mnMenu.MenuItems.Add(mnExibir);
            mnMenu.MenuItems.Add(mnMensagem);
            mnMenu.MenuItems.Add(mnModoLista);
            mnMenu.MenuItems.Add(mnFotos);
            mnMenu.MenuItems.Add(mnOcorrencia);
            mnMenu.MenuItems.Add(mnObservacao);
            mnMenu.MenuItems.Add(mnFechar);*/

            strModoInterface = ModoInteface.Exibicao.ToString();
        }


        private void btnLeitura_Click(object sender, EventArgs e)
        {
            
            if (bsRotaLeituraIndividual.Count > 0)
            {
                if (((Leitura)bsRotaLeituraIndividual.Current).STATUS_REG == "1")
                {
                    MessageBox.Show("UC´s que já foram transmitidas não podem sofrer alterações.", "Rota leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {

                    if (strModoInterface == ModoInteface.Exibicao.ToString())
                    {
                        strLeituraAnterior = txbLeitura.Text;
                        strIrreg1Ant = txbIrreg1.Text;
                        strIrreg2Ant = txbIrreg2.Text;
                        strIrreg3Ant = txbIrreg3.Text;

                       
                        if (!(UC == null || UC.NUM_UC == 0))
                        {
                            if (MensagemUcFlow.existeMensagem(((Leitura)bsRotaLeituraIndividual.Current).NUM_UC))
                            {
                                //Abre a tela mensagem
                                using (frmMensagemUc MensagemUc = new frmMensagemUc(bsRotaLeituraIndividual))
                                {
                                    MensagemUc.ShowDialog();
                                }
                            }
                        }

                        if ((txbLeitura.Text != "" && txbLeitura.Text != "0") || (txbIrreg1.Text != "" && txbIrreg1.Text != "0") || (txbIrreg2.Text != "" && txbIrreg2.Text != "0") || (txbIrreg3.Text != "" && txbIrreg3.Text != "0"))
                        {
                            if (MessageBox.Show(string.Format("Deseja alterar leitura?"), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                ControlaCamposEdicao();
                            }
                        }
                        else
                        {
                            ControlaCamposEdicao();
                        }
                    }
                    else if (strModoInterface == ModoInteface.Edicao.ToString())
                    {

                        //Recebe uc
                        UC = (Leitura)bsRotaLeituraIndividual.Current;

                        if (UC == null || UC.NUM_UC == 0)
                        {
                            MessageBox.Show("Unidade consumidora deve ser informada.", "Rota leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            if ((txbLeitura.Text == "") && (!OcorrenciaFlow.ExisteOcorrenciaImpedimento((txbIrreg1.Text == "") ? 0 : int.Parse(txbIrreg1.Text), (txbIrreg2.Text == "") ? 0 : int.Parse(txbIrreg2.Text), (txbIrreg3.Text == "") ? 0 : int.Parse(txbIrreg3.Text))))
                            {
                                MessageBox.Show("Leitura deve ser informada.", "Execução Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                            else if (!ValidaPadraoLeitura())
                            {

                                if (strLeituraAtual != txbLeitura.Text && txbLeitura.Text != "")
                                {
                                    
                                        MessageBox.Show("Leitura fora do padrão. Redigite a leitura", "Execução de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                        txbLeitura.Focus();
                                        strLeituraAtual = txbLeitura.Text;
                                       //voltar igor boExigeFoto = true;
                                        txbLeitura.Text = "";

                                       // ValidarIrregularidade();
                                    

                                }
                                else
                                {
                                    if (ValidarIrregularidade())
                                    {
                                        /*if (boExigeFoto && (FotosFlow.ExisteFoto(UC.NUM_UC, UC.MES_ANO_FATUR, UC.TIPO_MEDIC) == 0))
                                        {
                                            //Verifica se a ocorrencia é de impedimento                
                                            MessageBox.Show("É obrigatório o registro de foto.", "Execução de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                                            //Abre tela de foto
                                            using (frmCapturarFoto capturarFoto = new frmCapturarFoto(UC))
                                            {
                                                capturarFoto.ShowDialog();
                                            }                                            
                                        }
                                        else
                                        {*/
                                            
                                            ExecutarLeitura();
                                            //ProximaUc();
                                            boExigeFoto = false;
                                            strLeituraAtual = "";
                                            ControlaCamposExibicao();
                                            
                                        //}
                                    }
                                }
                            }
                            else
                            {
                                if (ValidarIrregularidade())
                                {
                                    ExecutarLeitura();
                                    boExigeFoto = false;
                                    strLeituraAtual = "";
                                    //ProximaUc();
                                    ControlaCamposExibicao();
                                }
                            }
                            /*//Abre tela de ocorrência
                            using (frmOcorrenciaUc OcorrenciaUc = new frmOcorrenciaUc(UC))
                            {
                                OcorrenciaUc.ShowDialog();
                                ProximaUc();
                            }*/
                        }


                        /*UC = (Leitura)bsRotaLeituraIndividual.Current;

                        if ((UC.NUM_MEDIDR == null) || (UC.NUM_MEDIDR == ""))
                        {
                            MessageBox.Show("Unidade consumidora deve ser informada.", "Rota leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        /* fAZER VALIDAÇÃO DEPOIS
                        else if ((UC.LEITUR_VISITA != null || UC.LEITUR_VISITA != "")&&(UC.FLAG_REPASSE!=0))
                        {
                            MessageBox.Show("Leitura já realizada para UC "+UC.NUM_UC+"", "Rota leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }

                        //Abre tela Ocorrencia UC
                        using (frmOcorrenciaUc OcorrenciaUc = new frmOcorrenciaUc(UC))
                        {
                            OcorrenciaUc.ShowDialog();
                        }*/
                    }
                }
            }
            else
            { MessageBox.Show("Uc deve ser informada.", "Execução de leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); }
            
        }

        /// <summary>
        /// Aponta para próxima uc
        /// </summary>
        private void ProximaUc()
        {
            if ((bsRotaLeituraIndividual.Position + 1) == bsRotaLeituraIndividual.Count)
            {
                //Retorna para o primeiro registro
                bsRotaLeituraIndividual.MoveFirst();
            }
            else
            {
                //Vai para proximo registro
                bsRotaLeituraIndividual.MoveNext();
            }
        }

        private void mnPesquisarUc_Click(object sender, EventArgs e)
        {
            //Abre a tela de pesquisa Uc
            using (frmPesquisarUc pesquisarUc = new frmPesquisarUc(bsRotaLeituraIndividual))
            {
                pesquisarUc.ShowDialog();

                Leitura leituraSelect = pesquisarUc.UcSelecionada;
                if (leituraSelect != null)
                {
                    bsRotaLeituraIndividual.Position = bsRotaLeituraIndividual.IndexOf(leituraSelect);
                    //Carrega os campos da telas
                    txbEndereco.Text = leituraSelect.ENDER_UC + " " + leituraSelect.COMPL_ENDER;
                    txbMedidorUc.Text = leituraSelect.MedidorTipoMed;  

                }
            }
           /* using (frmPesquisarUc pesquisarUc = new frmPesquisarUc(bsRotaLeituraIndividual))
            {
                pesquisarUc.ShowDialog();
            }*/
        }

        private void mnEstatistica_Click(object sender, EventArgs e)
        {
            using (frmEstatistica estatistica = new frmEstatistica())
            {
                estatistica.ShowDialog();
            }
        }

        private void mnUcProvisoria_Click(object sender, EventArgs e)
        {
            using (frmUcProvisoria UcProvisoria = new frmUcProvisoria())
            {
                UcProvisoria.ShowDialog();
            }
        }

        private void mnMensagemUc_Click(object sender, EventArgs e)
        {
            if (bsRotaLeituraIndividual != null && bsRotaLeituraIndividual.Count > 0)
            {
                if (MensagemUcFlow.existeMensagem(((Leitura)bsRotaLeituraIndividual.Current).NUM_UC))
                {
                    //Abre a tela de mensagem de Uc
                    using (frmMensagemUc MensagemUc = new frmMensagemUc(bsRotaLeituraIndividual))
                    {
                        MensagemUc.ShowDialog();
                    }
                }
                else { MessageBox.Show("Não existe mensagem para esta Uc.", "Rota de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); }
            }
            else
            {
                MessageBox.Show("Uc deve ser selecionada.", "Rota de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            /*
            using (frmMensagemUc MensagemUc = new frmMensagemUc(bsRotaLeituraIndividual))
            {
                MensagemUc.ShowDialog();
            }*/
        }

        private void mnInverterRoteiro_Click(object sender, EventArgs e)
        {
            //Preenche o grid com as UC´s
            Cursor.Current = Cursors.WaitCursor;

            Leitura leituraAtual = (Leitura)bsRotaLeituraIndividual.Current;

            string servico = LeituraFlow.ServicoCurrent;

            if (servico == "Repasse")
            {
                //Exibe leitura de forma decrescente
                if (DirecaoRoteiro == 0)
                {
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraRepasse();
                    DirecaoRoteiro = 1;
                }
                else
                {
                    //Exibe leitura de forma crescente
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraRepasseAsc();
                    DirecaoRoteiro = 0;
                }
            }
            else if (servico == "Não Executados")
            {
                //Exibe leitura de forma decrescente
                if (DirecaoRoteiro == 0)
                {
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraNExecutadosDesc();
                    DirecaoRoteiro = 1;
                }
                else
                {
                    //Exibe leitura de forma crescente
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraNExecutadosAsc();
                    DirecaoRoteiro = 0;
                }
            }
            else if (servico == "Primeira Execução")
            {
                //Exibe leitura de forma decrescente
                if (DirecaoRoteiro == 0)
                {
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraPriExecucaoDesc();
                    DirecaoRoteiro = 1;
                }
                else
                {
                    //Exibe leitura de forma crescente
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraPriExecucaoAsc();
                    DirecaoRoteiro = 0;
                }
            }
            else
            {
                //Exibe leitura de forma decrescente
                if (DirecaoRoteiro == 0)
                {
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraAsc();
                    DirecaoRoteiro = 1;
                }
                else
                {
                    //Exibe leitura de forma crescente
                    //Preenche a lista rota de leitura
                    LstRotaLeitura = LeituraFlow.getRotaLeituraDesc();
                    DirecaoRoteiro = 0;
                }
            }

                
                bsRotaLeituraIndividual.DataSource = LstRotaLeitura;

                bsRotaLeituraIndividual.Position = bsRotaLeituraIndividual.IndexOf(leituraAtual);
               // bsRotaLeituraIndividual.MoveFirst();
                Cursor.Current = Cursors.Default;
          

        }

        private void mnExibirRepasse_Click(object sender, EventArgs e)
        {
            //Carrega grid apena com repasse
            Cursor.Current = Cursors.WaitCursor;
            LstRotaLeitura = LeituraFlow.getRotaLeituraRepasse();
            bsRotaLeituraIndividual.DataSource = LstRotaLeitura;
            tlRotaLeitura.Text = "Rota de Leitura - Repasse";
            Cursor.Current = Cursors.Default;
            /*
            Cursor.Current = Cursors.WaitCursor;
            LstRotaLeitura = LeituraFlow.getRotaLeituraRepasse();
            bsRotaLeituraIndividual.DataSource = LstRotaLeitura;
            tlRotaLeitura.Text = "Rota de Leitura - Repasse";
            Cursor.Current = Cursors.Default;*/
        }

        private void mnNaoExecutados_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Carrega o grid apena com Uc não executadas
            LstRotaLeitura = LeituraFlow.getRotaLeituraNExecutados();
            bsRotaLeituraIndividual.DataSource = LstRotaLeitura;
            tlRotaLeitura.Text = "Rota de Leitura - Não Executados";
            Cursor.Current = Cursors.Default;
            /*
            Cursor.Current = Cursors.WaitCursor;
            LstRotaLeitura = LeituraFlow.getRotaLeituraNExecutados();
            bsRotaLeituraIndividual.DataSource = LstRotaLeitura;
            tlRotaLeitura.Text = "Rota de Leitura - Não Executados";
            Cursor.Current = Cursors.Default;*/
        }

        private void mnExibirPExecucao_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Carrega o grid com primeirqa execução
            LstRotaLeitura = LeituraFlow.getRotaLeituraPriExecucaoAsc();
            bsRotaLeituraIndividual.DataSource = LstRotaLeitura;
            tlRotaLeitura.Text = "Rota de Leitura - Primeira Execução";
            Cursor.Current = Cursors.Default;
            /*
            Cursor.Current = Cursors.WaitCursor;
            LstRotaLeitura = LeituraFlow.getRotaLeituraPriExecucao();
            bsRotaLeituraIndividual.DataSource = LstRotaLeitura;
            tlRotaLeitura.Text = "Rota de Leitura - Primeira Execução";
            Cursor.Current = Cursors.Default;*/
        }

        private void mnExibirTodas_Click(object sender, EventArgs e)
        {
            //Carrega o grid com todas as UC
            Cursor.Current = Cursors.WaitCursor;
            LstRotaLeitura = LeituraFlow.getRotaLeituraAsc();
            bsRotaLeituraIndividual.DataSource = LstRotaLeitura;
            tlRotaLeitura.Text = "Rota de Leitura - Todas";
            Cursor.Current = Cursors.Default;
            /*Cursor.Current = Cursors.WaitCursor;
            LstRotaLeitura = LeituraFlow.getRotaLeituraAsc();
            bsRotaLeituraIndividual.DataSource = LstRotaLeitura;
            tlRotaLeitura.Text = "Rota de Leitura - Lista";
            Cursor.Current = Cursors.Default;*/
        }

        private void mnModoLista_Click(object sender, EventArgs e)
        {
            using (frmRotaLeitura rotaLeitura = new frmRotaLeitura())
            {
                this.Close();
                rotaLeitura.ShowDialog();
            }
        }

        private void mnFechar_Click(object sender, EventArgs e)
        {
            if (strModoInterface == ModoInteface.Edicao.ToString())
            {
                txbLeitura.Text = strLeituraAnterior;
                txbIrreg1.Text = strIrreg1Ant;
                txbIrreg2.Text = strIrreg2Ant;
                txbIrreg3.Text = strIrreg3Ant;

                ControlaCamposExibicao();
                boExigeFoto = false;
            }
            else
            {
                this.Close();
            }
        }

        private void mnCaixaEntrada_Click(object sender, EventArgs e)
        {
            using (frmCaixaEntrada caixaEntrada = new frmCaixaEntrada())
            {
                caixaEntrada.ShowDialog();
            }
        }

        private void mnCaixaSaida_Click(object sender, EventArgs e)
        {
            using (frmCaixaSaida caixaSaida = new frmCaixaSaida())
            {
                caixaSaida.ShowDialog();
            }
        }

        private void mnEnviarMsg_Click(object sender, EventArgs e)
        {
            using (frmEnviarMsg enviarMsg = new frmEnviarMsg())
            {
                enviarMsg.ShowDialog();
            }
        }

        private void mnFotos_Click(object sender, EventArgs e)
        {
            /* voltar igor
            if (UC != null && bsRotaLeituraIndividual.Count > 0)
            {
                //Abre a tela de fotos
                using (frmCapturarFoto capturaFoto = new frmCapturarFoto((Leitura)bsRotaLeituraIndividual.Current))
                {
                    capturaFoto.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Uc deve ser selecionada.", "Rota de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
              */
        }


        private void mnOcorrencia_Click(object sender, EventArgs e)
        {
            //Abre a tela de pesquisa de ocorrencia
            using (frmPesquisarOcorrencia pesquisarOcorrencia = new frmPesquisarOcorrencia())
            {
                pesquisarOcorrencia.ShowDialog();

                //Carrega os dados na tela com os dados da pesquisa.
                Ocorrencia oc = pesquisarOcorrencia.Oc;
                if (oc != null)
                {
                    if (txbIrreg1.Text == "0" || txbIrreg1.Text == "")
                    {
                        txbIrreg1.Text = oc.COD_IRREGL.ToString();
                    }
                    else if (txbIrreg2.Text == "0" || txbIrreg2.Text == "")
                    {
                        txbIrreg2.Text = oc.COD_IRREGL.ToString();
                    }
                    else if (txbIrreg3.Text == "0" || txbIrreg3.Text == "")
                    {
                        txbIrreg3.Text = oc.COD_IRREGL.ToString();
                    }

                }

            }
        }

        private void bsRotaLeituraIndividual_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.ErrorText == "FormatException")
            {
                e.Cancel = false;
            }
        }

        /// <summary>
        /// Muda valores de letra para número
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int selectStart = 0;

            selectStart = ((TextBox)sender).SelectionStart;
            


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

        /// <summary>
        /// Muda valores de letra para número
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPressComun(object sender, KeyPressEventArgs e)
        {
            int selectStart = 0;

            selectStart = ((TextBox)sender).SelectionStart;

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

        private void mnObservacao_Click(object sender, EventArgs e)
        {
            if (UC != null && bsRotaLeituraIndividual.Count > 0)
            {                
                using (frmObservacaoUc observacao = new frmObservacaoUc(((Leitura)bsRotaLeituraIndividual.Current)))
                {
                    observacao.ShowDialog();
                }
                    
               
            }
            else
            {
                MessageBox.Show("Uc deve ser selecionada.", "Rota de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }



        }

        private void mnSincronizar_Click(object sender, EventArgs e)
        {
            frmSincronizacao sinc = new frmSincronizacao();
            sinc.ShowDialog();
            /*
            if (frmLogin.StatusSinc == true)
            {
                MessageBox("Sincronização já está em andamento. Aguarde!");
                return;
            }
            else
            {
                frmLogin.setStatusSinc(true);
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                Sync sinc = new Sync();

                sinc.IniciaSinc();
                LeituraFlow.ReiniciaQtdLeitReal();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                frmLogin.setStatusSinc(false);
            }*/
            
        }

        private void mnDir_Esq_Click(object sender, EventArgs e)
        {
            ConfigWebService config = new ConfigWebService();
            config.CreateKey();
            config.setFormatoLeitura("direita");
            config.SetFormatoLeituraAtual();
            
        }

        private void mnEsq_Dir_Click(object sender, EventArgs e)
        {
            ConfigWebService config = new ConfigWebService();
            config.CreateKey();
            config.setFormatoLeitura("esquerda");
            config.SetFormatoLeituraAtual();
        }

        private void mnNomeCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nome do Cliente: "+UC.NOME_CONSMD);
        }

        private void txbIrreg1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 115 || e.KeyValue == 114)
            {
                Thread.Sleep(1000);
                Process P = Process.GetProcessById(Process.GetCurrentProcess().Id);
                SetForegroundWindow(P.MainWindowHandle);
            }

            if (!string.IsNullOrEmpty(txbIrreg1.Text) || !string.IsNullOrEmpty(txbIrreg2.Text))
            {
                txbIrreg2.Enabled = true;
            }
            else
            {
                txbIrreg2.Enabled = false;
            }
        }

        private void frmRotaLeituraIndividual_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 115 || e.KeyValue == 114)
            {
                Thread.Sleep(1000);
                Process P = Process.GetProcessById(Process.GetCurrentProcess().Id);
                SetForegroundWindow(P.MainWindowHandle);
            }
        }

        private void txbIrreg1_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void txbIrreg2_KeyDown(object sender, KeyEventArgs e)
        {
            

            
        }

        private void txbIrreg2_KeyUp(object sender, KeyEventArgs e)
        {

            if (!string.IsNullOrEmpty(txbIrreg2.Text) || !string.IsNullOrEmpty(txbIrreg3.Text))
            {
                txbIrreg3.Enabled = true;
            }
            else
            {
                txbIrreg3.Enabled = false;
            }
        }
    }
}