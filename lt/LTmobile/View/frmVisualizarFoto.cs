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
using Microsoft.WindowsMobile.Forms;
using LTmobileData.Data.Helper;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace LTmobile.View
{
    public partial class frmVisualizarFoto : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Foto a ser visualizada
        /// </summary>
        Fotos fotoAtual;
        /// <summary>
        /// Diretório da foto.
        /// </summary>
        string caminhoFoto;

        public bool Apagou { get; set; }

        public frmVisualizarFoto(Fotos fotos)
        {
            InitializeComponent();
            fotoAtual = fotos;
            txbLegenda.Focus();
            Apagou = false;
        }

        private void frmVisualizarFoto_Load(object sender, EventArgs e)
        {
            
            //Carrega os campos da tela
            txbMedidorUc.Text = fotoAtual.NUM_MEDIDR.ToString() + " / " + fotoAtual.NUM_UC.ToString();
            txbLegenda.Text = fotoAtual.DESC_FOTO;
           // caminhoFoto = Utils.LocalPath + "\\Fotos\\" + fotoAtual.NUM_UC + "_" + fotoAtual.MES_ANO_FATUR + "_" + fotoAtual.COD_LOCAL + "_" + fotoAtual.TIPO_MEDIC + "_" + fotoAtual.NUM_SEQ_FOTO + ".jpg";                   
            string caminhoFoto = Utils.LocalPath + "\\Fotos\\" + FotosFlow.getIdFotoUc(fotoAtual.MES_ANO_FATUR, fotoAtual.TIPO_MEDIC, fotoAtual.COD_LOCAL, fotoAtual.NUM_UC, fotoAtual.COD_EMPRT, fotoAtual.NUM_RAZAO, fotoAtual.NUM_SEQ_FOTO) + ".jpg"; 
            txbLegenda.Focus();

            if (!string.IsNullOrEmpty(caminhoFoto))
            {
                if (File.Exists(caminhoFoto))
                {
                    //mostra a foto na tela do aparelho
                    pctFoto.Image = new Bitmap(caminhoFoto);
                    pctFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                MessageBox.Show("Foto não encontrada no diretório: "+caminhoFoto+"", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txbLegenda.Text == "")
            {
                MessageBox.Show("Legenda deve ser informada.", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else if (fotoAtual == null)
            {
                MessageBox.Show("Foto deve ser selecionada.", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                //Recupera dados para inserir fotos
               /* Fotos fotos = new Fotos();
                fotos.ID_FOTO = fotoAtual.ID_FOTO;
                fotos.COD_EMPRT = fotoAtual.COD_EMPRT;
                fotos.NUM_RAZAO = fotoAtual.NUM_RAZAO;
                fotos.COD_LOCAL = fotoAtual.COD_LOCAL;
                fotos.CORD_X = "10.00000";
                fotos.CORD_Y = "11.00000";
                fotos.DATA_ATLZ = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                fotos.DESC_FOTO = txbLegenda.Text;
                fotos.HORA_ATLZ = DateTime.Now.ToString("HHmmss");
                fotos.MES_ANO_FATUR = fotoAtual.MES_ANO_FATUR;
                fotos.NUM_MEDIDR = fotoAtual.NUM_MEDIDR;
                fotos.NUM_SEQ_FOTO = fotoAtual.NUM_SEQ_FOTO;
                fotos.NUM_UC = fotoAtual.NUM_UC;
                fotos.STATUS_REG = "2";
                fotos.TIPO_MEDIC = fotoAtual.TIPO_MEDIC;
                fotos.USUAR_ATLZ = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC.ToString();
                */

                fotoAtual.CORD_X = "10.00000";
                fotoAtual.CORD_Y = "11.00000";
                fotoAtual.DATA_ATLZ = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                fotoAtual.DESC_FOTO = txbLegenda.Text;
                fotoAtual.HORA_ATLZ = DateTime.Now.ToString("HHmmss");
                fotoAtual.STATUS_REG = "2";
                //fotoAtual.USUAR_ATLZ = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC.ToString();
                fotoAtual.USUAR_ATLZ = "Velp";
                try
                {
                    //Insere foto
                    FotosFlow.Update(fotoAtual);
                    MessageBox.Show("Foto alterada com sucesso.", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível editar foto: "+ex+".", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void mnApagar_Click(object sender, EventArgs e)
        {
            if (fotoAtual == null)
            {
                MessageBox.Show("Foto deve ser selecionada.", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (MessageBox.Show(string.Format("Deseja apagar a foto " + caminhoFoto + "?"), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        //  string caminhoFoto = Utils.LocalPath + "\\Fotos\\" + fotoAtual.NUM_UC + "_" + fotoAtual.MES_ANO_FATUR + "_" + fotoAtual.COD_LOCAL + "_" + fotoAtual.TIPO_MEDIC + "_" + fotoAtual.NUM_SEQ_FOTO + ".jpg";
                        caminhoFoto = Utils.LocalPath + "\\Fotos\\" + FotosFlow.getIdFotoUc(fotoAtual.MES_ANO_FATUR, fotoAtual.TIPO_MEDIC, fotoAtual.COD_LOCAL, fotoAtual.NUM_UC, fotoAtual.COD_EMPRT, fotoAtual.NUM_RAZAO, fotoAtual.NUM_SEQ_FOTO) + ".jpg";

                        //Deleta a foto no banco de dados
                        // FotosFlow.DeletarFoto(fotoAtual.NUM_UC, fotoAtual.MES_ANO_FATUR, fotoAtual.COD_LOCAL, fotoAtual.TIPO_MEDIC, fotoAtual.NUM_SEQ_FOTO);
                        FotosFlow.Delete(fotoAtual);

                        //Deleta a foto do aparelho
                        if (File.Exists(caminhoFoto))
                        {
                            File.Delete(caminhoFoto);
                        }
                        MessageBox.Show("Foto apagada com sucesso.", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        Apagou = true;
                        this.Close();

                    }
                    catch (Exception ex) { MessageBox.Show("Não foi possível apagar a foto: " + ex + ".", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1); }
                }
            }
        }

        private void mnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVisualizarFoto_KeyUp(object sender, KeyEventArgs e)
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