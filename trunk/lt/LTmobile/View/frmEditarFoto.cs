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
using LTmobileData.Data.Helper;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace LTmobile.View
{
    public partial class frmEditarFoto : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Lista de fotos
        /// </summary>
        List<Fotos> lstFotos;

        /// <summary>
        /// Dados da Uc
        /// </summary>
        public static Leitura leituraAux;

       // public Leitura getLeitura{get; set;}

        public frmEditarFoto(Leitura leitura)
        {
            InitializeComponent();

            //Recupera Uc
            leituraAux = leitura;
          //  getLeitura = leitura;
            CarregarTela();


        }
        public frmEditarFoto()
        {
            InitializeComponent();

            CarregarTela();
        }

        public void frmEditarFoto_Load(object sender, EventArgs e)
        {
            CarregarTela();          
        }

        /// <summary>
        /// Carrega a tela de foto;
        /// </summary>
        public void CarregarTela()
        {
            Cursor.Current = Cursors.WaitCursor;
            //Carrega as fotos
            lstFotos = FotosFlow.getFotos(leituraAux.NUM_UC, leituraAux.TIPO_MEDIC);
            bsFoto.DataSource = lstFotos;
           // getLeitura = leituraAux;
            //Manda foco para grid
            grdFoto.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void mnVoltar_Click(object sender, EventArgs e)
        {
            //Fecha a tela
            this.Close();
        }

        private void mnApagar_Click(object sender, EventArgs e)
        {
            if (bsFoto.Count < 1)
            {
                MessageBox.Show("Foto deve ser selecionada.", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);   
            }else{
                if (MessageBox.Show(string.Format("Deseja apagar a foto?"), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        // string caminhoFoto = Utils.LocalPath + "\\Fotos\\" + ((Fotos)bsFoto.Current).NUM_UC + "_" + ((Fotos)bsFoto.Current).MES_ANO_FATUR + "_" + ((Fotos)bsFoto.Current).COD_LOCAL + "_" + ((Fotos)bsFoto.Current).TIPO_MEDIC + "_" + ((Fotos)bsFoto.Current).NUM_SEQ_FOTO + ".jpg";                   
                        string caminhoFoto = Utils.LocalPath + "\\Fotos\\" + FotosFlow.getIdFotoUc(((Fotos)bsFoto.Current).MES_ANO_FATUR, ((Fotos)bsFoto.Current).TIPO_MEDIC, ((Fotos)bsFoto.Current).COD_LOCAL, ((Fotos)bsFoto.Current).NUM_UC, ((Fotos)bsFoto.Current).COD_EMPRT, ((Fotos)bsFoto.Current).NUM_RAZAO, ((Fotos)bsFoto.Current).NUM_SEQ_FOTO);

                        //Deleta a foto no banco de dados
                        // FotosFlow.DeletarFoto(((Fotos)bsFoto.Current).NUM_UC, ((Fotos)bsFoto.Current).MES_ANO_FATUR, ((Fotos)bsFoto.Current).COD_LOCAL, ((Fotos)bsFoto.Current).TIPO_MEDIC, ((Fotos)bsFoto.Current).NUM_SEQ_FOTO);
                        FotosFlow.Delete(((Fotos)bsFoto.Current));

                        //Deleta a foto do aparelho
                        if (File.Exists(caminhoFoto))
                        {
                            File.Delete(caminhoFoto);
                        }
                        bsFoto.RemoveCurrent();
                        MessageBox.Show("Foto apagada com sucesso.", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        if (bsFoto.Count < 1)
                        {
                            this.Close();
                        }
                        else
                        {
                            CarregarTela();
                        }

                    }
                    catch (Exception ex) { MessageBox.Show("Não foi possível apagar a foto: " + ex + ".", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1); }
                }
            }
            
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (bsFoto.Count > 0)
            {
                using (frmVisualizarFoto visualizarfoto = new frmVisualizarFoto((Fotos)bsFoto.Current))
                {
                    visualizarfoto.ShowDialog();
                    if (visualizarfoto.Apagou)
                    {
                        bsFoto.RemoveCurrent();
                        
                    }

                    bsFoto.ResetBindings(false);
                }
            }
            else
            {
                MessageBox.Show("Foto deve ser selecionada.", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmEditarFoto_KeyUp(object sender, KeyEventArgs e)
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