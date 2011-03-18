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
    public partial class frmListaOcorrencia : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Uc Atual
        /// </summary>
        Leitura UcAtual;

        /// <summary>
        /// Uc atual provisória
        /// </summary>
        LeituraProvisoria UcAtualProvisoria;

        /// <summary>
        /// Lista de ocorrencia
        /// </summary>
        List<Ocorrencia> lstOcorrencia;

        /// <summary>
        /// Tipo da Uc P-provisória, C-Comun
        /// </summary>
        string tipoUc;

        public frmListaOcorrencia(Leitura Uc)
        {
            tipoUc = "C";
            //Recupera a uc
            UcAtual = Uc;

            InitializeComponent();

            //Carrega o grid
            carregarGrid();

        }

        public frmListaOcorrencia(LeituraProvisoria UcP)
        {
            tipoUc = "P";
            
            //Recupera a uc
            UcAtualProvisoria = UcP;

            InitializeComponent();

            //Carrega o grid
            carregarGrid();
        }

        /// <summary>
        /// Carrega o grid de ocorrencia.
        /// </summary>
        public void carregarGrid()
        {
            if (tipoUc == "C")
            {
                //Carrega o grid
                Cursor.Current = Cursors.WaitCursor;
                lstOcorrencia = OcorrenciaFlow.getOcorrenciaUC(UcAtual.IRREGL_ATUAL1, UcAtual.IRREGL_ATUAL2, UcAtual.IRREGL_ATUAL3);
                bsListaOcorrencia.DataSource = lstOcorrencia;
                grdPesqOcorrencia.Focus();
                Cursor.Current = Cursors.Default;
            }
            else if (tipoUc == "P")
            {
                //Carrega o grid
                Cursor.Current = Cursors.WaitCursor;
                lstOcorrencia = OcorrenciaFlow.getOcorrenciaUC(UcAtualProvisoria.IRREGL_ATUAL1, UcAtualProvisoria.IRREGL_ATUAL2, UcAtualProvisoria.IRREGL_ATUAL3);
                bsListaOcorrencia.DataSource = lstOcorrencia;
                grdPesqOcorrencia.Focus();
                Cursor.Current = Cursors.Default;
            }
        }

        private void mnCancelar_Click(object sender, EventArgs e)
        {
            //Fecha a tela
            this.Close();
        }

        private void mnApagar_Click(object sender, EventArgs e)
        {
            //Se existe ocorrencia
            if (bsListaOcorrencia.Count > 0)
            {
                if (MessageBox.Show(string.Format("Deseja apagar ocorrência?"), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //recupera o codigo da ocorrencia selecionada
                    int OcorenciaSelcionada = ((Ocorrencia)bsListaOcorrencia.Current).COD_IRREGL;

                    if (tipoUc == "C")
                    {
                        //Verifica qual ocorrencia foi alterada
                        if (OcorenciaSelcionada != 0)
                        {
                            if (UcAtual.IRREGL_ATUAL1 == OcorenciaSelcionada)
                            {
                                UcAtual.IRREGL_ATUAL1 = 0;
                                UcAtual.COMPL_ATUAL1 = "";
                            }
                            else if (UcAtual.IRREGL_ATUAL2 == OcorenciaSelcionada)
                            {
                                UcAtual.IRREGL_ATUAL2 = 0;
                                UcAtual.COMPL_ATUAL2 = "";
                            }
                            else if (UcAtual.IRREGL_ATUAL3 == OcorenciaSelcionada)
                            {
                                UcAtual.IRREGL_ATUAL3 = 0;
                                UcAtual.COMPL_ATUAL3 = "";
                            }

                            //Apaga a ocorrencia selecioanda
                            try
                            {
                                LeituraFlow.Update(UcAtual);

                                carregarGrid();
                                MessageBox.Show("Ocorrência apagada com sucesso. ", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                                if (bsListaOcorrencia.Count < 1)
                                {
                                    this.Close();
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Não foi possível apagar ocorrência. " + ex + "", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    else if (tipoUc == "P")
                    {
                        //Verifica qual ocorrencia foi alterada
                        if (OcorenciaSelcionada != 0)
                        {
                            if (UcAtualProvisoria.IRREGL_ATUAL1 == OcorenciaSelcionada)
                            {
                                UcAtualProvisoria.IRREGL_ATUAL1 = 0;
                                UcAtualProvisoria.COMPL_ATUAL1 = "";
                            }
                            else if (UcAtualProvisoria.IRREGL_ATUAL2 == OcorenciaSelcionada)
                            {
                                UcAtualProvisoria.IRREGL_ATUAL2 = 0;
                                UcAtualProvisoria.COMPL_ATUAL2 = "";
                            }
                            else if (UcAtualProvisoria.IRREGL_ATUAL3 == OcorenciaSelcionada)
                            {
                                UcAtualProvisoria.IRREGL_ATUAL3 = 0;
                                UcAtualProvisoria.COMPL_ATUAL3 = "";
                            }

                            //Apaga a ocorrencia selecioanda
                            try
                            {
                                LeituraProvisoriaFlow.Update(UcAtualProvisoria);

                                carregarGrid();
                                MessageBox.Show("Ocorrência apagada com sucesso. ", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                                if (bsListaOcorrencia.Count < 1)
                                {
                                    this.Close();
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Não foi possível apagar ocorrência. " + ex + "", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Não existe ocorrência cadastrada.", "Ocorrência", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmListaOcorrencia_KeyUp(object sender, KeyEventArgs e)
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