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
    public partial class frmRotaLeitura : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        #region Variáveis
        /// <summary>
        /// UC selecionada
        /// </summary>
        Leitura UC;

        /// <summary>
        /// Rota de Leitura
        /// </summary>
        List<Leitura> LstRotaLeitura;

        /// <summary>
        /// Direção do roteiro 0-Asc 1-Desc
        /// </summary>
        int DirecaoRoteiro = 0;
        #endregion


        public frmRotaLeitura()
        {
            InitializeComponent();

            //Preenche o grid com as UC´s
            Cursor.Current = Cursors.WaitCursor;
            //Preenche a lista rota de leitura
            LstRotaLeitura = LeituraFlow.getRotaLeituraAsc();
            Cursor.Current = Cursors.Default;
            preencherCampos();
           
        }

        /// <summary>
        /// Carrega os dados na tela
        /// </summary>
        public void preencherCampos()
        {
            //Carrega o bind com a lista de leitura
            bsRotaLeitura.DataSource = LstRotaLeitura;
            
            //Recebe UC selecionada
            UC = (Leitura)bsRotaLeitura.Current;
            if (UC != null)
            {
                //Carrega os campos da telas
                txbEndereco.Text = UC.ENDER_UC + " " + UC.COMPL_ENDER;
                txbMedidorUc.Text = UC.TIPO_MEDIC + "-" + UC.NUM_MEDIDR;
                txbUc.Text = UC.NUM_UC.ToString();
            }

            grdRotaLeitura.Focus();
            
        }

        private void grdRotaLeitura_CurrentCellChanged(object sender, EventArgs e)
        {
            /*//exibe dados da UC selecionada
            Leitura UC = (Leitura)bsRotaLeitura.Current;
            txbEndereco.Text = UC.ENDER_UC + " "+UC.COMPL_ENDER;
            txbMedidorUc.Text = UC.NUM_MEDIDR + " / " + UC.NUM_UC;  */
            preencherCampos();          
            
        }

        /// <summary>
        /// Valida se leitura está fora dos padões
        /// </summary>
        /// <returns></returns>
        public bool ValidaPadraoLeitura()
        {
            if (UC.LEITUR_VISITA != 0)
            {
                if ((UC.LEITUR_VISITA > UC.LEITUR_MAX) || (UC.LEITUR_VISITA < UC.LEITUR_MIN))
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
            if(UC.ESTADO_SERVC == 2)
            {
                return true;
            }else
            {
                return false;
            }
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            //Recebe uc
            UC = (Leitura)bsRotaLeitura.Current;

            if (UC == null || UC.NUM_UC == 0)
            {
                MessageBox.Show("Unidade consumidora deve ser informada.", "Rota leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (UC.STATUS_REG == "1")
                {
                    MessageBox.Show("UC´s que já foram transmitidas não podem sofre alterações.", "Rota leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    //Verifica se existe mensagem específica para Uc
                    if (MensagemUcFlow.existeMensagem(UC.NUM_UC))
                    {
                        //Abre a tela mensagem
                        using (frmMensagemUc MensagemUc = new frmMensagemUc(bsRotaLeitura))
                        {
                            MensagemUc.ShowDialog();
                        }
                    }

                    /*//Abre tela de ocorrência
                    using (frmOcorrenciaUc OcorrenciaUc = new frmOcorrenciaUc(UC))
                    {
                        OcorrenciaUc.ShowDialog();
                        ProximaUc();
                    }*/

                    using (frmOcorrenciaUc2 ocorrenciaUc2 = new frmOcorrenciaUc2(UC))
                    {
                        ocorrenciaUc2.ShowDialog();
                    }
                }

            }

        }

        /// <summary>
        /// Aponta para próxima uc
        /// </summary>
        private void ProximaUc()
        {
            if ((bsRotaLeitura.Position + 1) == bsRotaLeitura.Count)
            {
                //Retorna para o primeiro registro
                bsRotaLeitura.MoveFirst();                
            }
            else
            {
                //Vai para proximo registro
                bsRotaLeitura.MoveNext();                
            }
        }

        private void frmRotaLeitura_Load(object sender, EventArgs e)
        {
            //Manda o focus para o grid
            grdRotaLeitura.Focus();
        }

        private void mnPesqUC_Click(object sender, EventArgs e)
        {
            //Abre a tela de pesquisa Uc
            using (frmPesquisarUc pesquisarUc = new frmPesquisarUc(bsRotaLeitura))
            {
                pesquisarUc.ShowDialog();

                //Retorna leitura selecionada
                Leitura leituraSelect = pesquisarUc.UcSelecionada;
                if (leituraSelect != null)
                {
                    bsRotaLeitura.Position = bsRotaLeitura.IndexOf(leituraSelect); 
                        //Carrega os campos da telas
                    txbEndereco.Text = leituraSelect.ENDER_UC + " " + leituraSelect.COMPL_ENDER;
                    txbMedidorUc.Text = leituraSelect.NUM_MEDIDR + " / " + leituraSelect.NUM_UC;
                    

                    grdRotaLeitura.Focus();

                }
            }
        }

        private void mnEstatistica_Click(object sender, EventArgs e)
        {
            //Abre a tela de estatística
            using (frmEstatistica estatistica = new frmEstatistica())
            {
                estatistica.ShowDialog();
            }
        }

        private void mnUcProvisoria_Click(object sender, EventArgs e)
        {
            //Abre a tela de cadastro de Uc provisória
            using (frmUcProvisoria UcProvisoria = new frmUcProvisoria())
            {
                UcProvisoria.ShowDialog();
            }
        }

        private void mnMensagemUc_Click(object sender, EventArgs e)
        {
            if (UC != null)
            {
                if (MensagemUcFlow.existeMensagem(UC.NUM_UC))
                {
                    //Abre a tela de mensagem de Uc
                    using (frmMensagemUc MensagemUc = new frmMensagemUc(bsRotaLeitura))
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
        }

        private void mnInverterRoteiro_Click(object sender, EventArgs e)
        {

            //Exibe leitura de forma decrescente
            if (DirecaoRoteiro == 0)
            {
                //Preenche o grid com as UC´s
                Cursor.Current = Cursors.WaitCursor;
                //Preenche a lista rota de leitura
                LstRotaLeitura = LeituraFlow.getRotaLeituraDesc();
                Cursor.Current = Cursors.Default;
                DirecaoRoteiro = 1;

            }
            else
            {
                //Exibe leitura de forma crescente

                //Preenche o grid com as UC´s
                Cursor.Current = Cursors.WaitCursor;
                //Preenche a lista rota de leitura
                LstRotaLeitura = LeituraFlow.getRotaLeituraAsc();
                Cursor.Current = Cursors.Default;
                DirecaoRoteiro = 0;
            }

            preencherCampos();

            
        }

        private void mnExibirRepasse_Click(object sender, EventArgs e)
        {
            //Carrega grid apena com repasse
            Cursor.Current = Cursors.WaitCursor;
            LstRotaLeitura = LeituraFlow.getRotaLeituraRepasse();
            preencherCampos();
            tlRotaLeitura.Text = "Rota de Leitura - Repasse";
            Cursor.Current = Cursors.Default;
        }

        private void mnExibirNaoExecutados_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Carrega o grid apena com Uc não executadas
            LstRotaLeitura = LeituraFlow.getRotaLeituraNExecutados();
            preencherCampos();
            tlRotaLeitura.Text = "Rota de Leitura - Não Executados";
            Cursor.Current = Cursors.Default;
        }

        private void mnExibirPrimExec_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Carrega o grid com primeirqa execução
            LstRotaLeitura = LeituraFlow.getRotaLeituraPriExecucaoAsc();
            preencherCampos();
            tlRotaLeitura.Text = "Rota de Leitura - Primeira Execução";
            Cursor.Current = Cursors.Default;
        }

        private void mnExibirTodas_Click(object sender, EventArgs e)
        {
            //Carrega o grid com todas as UC
            Cursor.Current = Cursors.WaitCursor;
            LstRotaLeitura = LeituraFlow.getRotaLeituraAsc();
            preencherCampos();
            tlRotaLeitura.Text = "Rota de Leitura - Lista";
            Cursor.Current = Cursors.Default;
        }

        private void mnMsgCaixaEntrada_Click(object sender, EventArgs e)
        {
            //Abre a tela caixa de Entrada
            using (frmCaixaEntrada caixaEntrada = new frmCaixaEntrada())
            {
                caixaEntrada.ShowDialog();
            }
        }

        private void mnMsgCaixaSaida_Click(object sender, EventArgs e)
        {
            //Abre a tela caixa de saida
            using (frmCaixaSaida caixaSaida = new frmCaixaSaida())
            {
                caixaSaida.ShowDialog();
            }
        }

        private void mnMsgEnviarMsg_Click(object sender, EventArgs e)
        {
            //Abre a tela enviar mensagem
            using(frmEnviarMsg enviarMsg = new frmEnviarMsg())
            {
                enviarMsg.ShowDialog();
            }
        }

        private void mnModoInd_Click(object sender, EventArgs e)
        {
            //Abre a tela rota de leitura em formato individual
            using (frmRotaLeituraIndividual rotaLeituraInd = new frmRotaLeituraIndividual())
            {                
                rotaLeituraInd.ShowDialog();

                //Carrega o grid com todas as UC
                Cursor.Current = Cursors.WaitCursor;
                LstRotaLeitura = LeituraFlow.getRotaLeituraAsc();
                preencherCampos();
                tlRotaLeitura.Text = "Rota de Leitura - Lista";
                Cursor.Current = Cursors.Default;
            }
        }

        private void mnFotos_Click(object sender, EventArgs e)
        {
            if (UC != null)
            {
                //Abre a tela de fotos
                using (frmCapturarFoto capturaFoto = new frmCapturarFoto(UC))
                {
                    capturaFoto.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Uc deve ser selecionada.", "Rota de Leitura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void mnFechar_Click(object sender, EventArgs e)
        {
            //Fecha a tela.
            this.Close();
        }

        private void frmRotaLeitura_KeyUp(object sender, KeyEventArgs e)
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