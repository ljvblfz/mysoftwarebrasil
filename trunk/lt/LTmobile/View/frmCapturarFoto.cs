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
    public partial class frmCapturarFoto : Form
    {
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Uc selecionada
        /// </summary>
        Leitura UC;

        /// <summary>
        /// Diretório da foto.
        /// </summary>
        string caminhoFoto;

        int idFoto;

        bool boProvisorio = false;

        public frmCapturarFoto(Leitura Uc)
        {
            InitializeComponent();
            //REcupera UC
            UC = Uc;
            lblMedidor.Text = "UC/Medidor:";
            //Manda foco paa campo de egenda            
            txbLegenda.Focus();
            
            
        }

        public frmCapturarFoto(LeituraProvisoria UcProvisoria)
        {
            InitializeComponent();
            UC = new Leitura();
            lblMedidor.Text = "Medidor:";
            UC.NUM_UC = UcProvisoria.NUM_UC_REF;
            UC.NUM_MEDIDR = UcProvisoria.NUM_MEDIDR;
            UC.TIPO_MEDIC = "TMP";
            UC.COD_EMPRT = UcProvisoria.COD_EMPRT;
            UC.COD_LOCAL = UcProvisoria.COD_LOCAL;
            UC.MATRIC_FUNC = UcProvisoria.MATRIC_FUNC;
            UC.NUM_RAZAO = UcProvisoria.NUM_RAZAO;
            UC.MES_ANO_FATUR = UcProvisoria.MES_ANO_FATUR;
            boProvisorio = true;

            //Manda foco paa campo de egenda            
            txbLegenda.Focus();
        }

        private void frmCapturarFoto_Load(object sender, EventArgs e)
        {
            if (UC != null)
            {
                //Carrega os campos da tela
                if (boProvisorio)
                {
                    txbMedidorUc.Text = UC.NUM_MEDIDR.ToString();
                }
                else
                {
                    txbMedidorUc.Text = UC.NUM_UC.ToString() + " / " + UC.NUM_MEDIDR.ToString();
                }
            }
            
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {

        }

        private void camera()
        {
            CameraCaptureDialog camera = new CameraCaptureDialog();

            //Tira foto com melhor qualidade possível
            camera.StillQuality = CameraCaptureStillQuality.High;

            //Resolução da camera
            //camera.Resolution = new Size(640, 480);
            camera.Resolution = new Size(640, 480);

            //Diretório que sará salvo a foto
            camera.InitialDirectory = Utils.LocalPath + "\\Fotos";

            //Nome da imagem
            //camera.DefaultFileName = UC.NUM_UC + "_" + UC.MES_ANO_FATUR + "_" + UC.COD_LOCAL + "_" + UC.TIPO_MEDIC + "_" + FotosFlow.GetLastId(UC.NUM_UC, UC.MES_ANO_FATUR) + ".jpg";  
            idFoto = FotosFlow.GetIdFoto();
            camera.DefaultFileName = idFoto + ".jpg";

            //Caminho da foto
            //caminhoFoto = Utils.LocalPath + "\\Fotos\\" + UC.NUM_UC + "_" + UC.MES_ANO_FATUR + "_" + UC.COD_LOCAL + "_" + UC.TIPO_MEDIC +"_" + FotosFlow.GetLastId(UC.NUM_UC, UC.MES_ANO_FATUR) + ".jpg";
            caminhoFoto = Utils.LocalPath + "\\Fotos\\" + idFoto + ".jpg";

            //Tipo de captura de imagem - foto
            camera.Mode = CameraCaptureMode.Still;

            try
            {
                //exibe a tela de captura de foto.
                DialogResult a = camera.ShowDialog();

                if (a.ToString() == "OK")
                {
                    SalvarFoto();
                }
                else
                {
                    //Verifica se o diretporio da fotk existe
                    if (File.Exists(caminhoFoto))
                    {
                        //Deleta a foto
                        File.Delete(caminhoFoto);
                    }
                    caminhoFoto = "";
                    txbLegenda.Text = "";
                    pctFoto.Image = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Cria um diretório para armazenar as imagens
        /// </summary>
        public void CriarDiretorio()
        {
            try
            {
                //Recebe diretório raiz da aplicação
                string strDiretorio = Utils.LocalPath;

                //Verifica se existe a pasta de fotos
                if (!Directory.Exists(strDiretorio + "\\Fotos"))
                {
                    //Cria pasta fotos
                    Directory.CreateDirectory(strDiretorio + "\\Fotos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ao criar diretório para as fotos. Ex->" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {

                //Cria diretório para armazenar fotos
                CriarDiretorio();

                try
                {
                    //Abre a camera
                    camera();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível abrir a camera: " + ex.Message, "Foto", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    this.Close();
                }

                if (!string.IsNullOrEmpty(caminhoFoto))
                {
                    //mostra a foto na tela do aparelho
                    pctFoto.Image = new Bitmap(caminhoFoto);
                    pctFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    
                }
                /*Cursor.Current = Cursors.WaitCursor;
                //Recupera dados para inserir fotos
                Fotos fotos = new Fotos();

                fotos.COD_LOCAL = UC.COD_LOCAL;
                fotos.CORD_X = "10.00000";
                fotos.CORD_Y = "11.00000";
                fotos.DATA_ATLZ = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                fotos.DESC_FOTO = txbLegenda.Text;
                fotos.HORA_ATLZ = DateTime.Now.ToString("HHmmss");
                fotos.MES_ANO_FATUR = UC.MES_ANO_FATUR;
                fotos.NUM_MEDIDR = UC.NUM_MEDIDR;
                fotos.NUM_SEQ_FOTO = (int)FotosFlow.GetLastId(UC.NUM_UC, UC.MES_ANO_FATUR);
                fotos.NUM_UC = UC.NUM_UC;
                fotos.STATUS_REG = "2";
                fotos.TIPO_MEDIC = UC.TIPO_MEDIC;
                fotos.USUAR_ATLZ = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC.ToString();
                Cursor.Current = Cursors.Default;
                //Insere foto
                FotosFlow.Insert(fotos);
            */
        }

        private void SalvarFoto()
        {
            string strErro = "";

                Cursor.Current = Cursors.WaitCursor;
                //Recupera dados paa insrir fotos
                Fotos fotos = new Fotos();

                fotos.ID_FOTO = idFoto;
                fotos.COD_EMPRT = UC.COD_EMPRT;
                fotos.NUM_RAZAO = UC.NUM_RAZAO;
                fotos.COD_LOCAL = UC.COD_LOCAL;


                //TODO: O que o GPS esta fazendo aqui??
                if (!frmLogin._gps.Opened && ConfigWebService.LigarGpsWebService)
                {
                    frmLogin._gps.Open();
                }

                if (frmLogin._gps.Opened)
                {
                    if (frmLogin._gps.GetPosition().LatitudeValid)
                    {

                        fotos.CORD_X = frmLogin._gps.GetPosition().Latitude.ToString();

                    }

                    if (frmLogin._gps.GetPosition().LongitudeValid)
                    {

                        fotos.CORD_Y = frmLogin._gps.GetPosition().Longitude.ToString();

                    }
                }
                
                fotos.DATA_ATLZ = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                fotos.DESC_FOTO = txbLegenda.Text;
                fotos.HORA_ATLZ = DateTime.Now.ToString("HHmmss");
                fotos.MES_ANO_FATUR = UC.MES_ANO_FATUR;
                fotos.NUM_MEDIDR = UC.NUM_MEDIDR;
                fotos.NUM_SEQ_FOTO = (int)FotosFlow.GetLastId(UC.NUM_UC, UC.MES_ANO_FATUR, UC.TIPO_MEDIC);
                fotos.NUM_UC = UC.NUM_UC;
                fotos.STATUS_REG = "2";
                fotos.TIPO_MEDIC = UC.TIPO_MEDIC;
               // fotos.USUAR_ATLZ = UsuarioFlow.UsuarioCurrent.MATRIC_FUNC.ToString();
                fotos.USUAR_ATLZ = "Velp";
                Cursor.Current = Cursors.Default;

                if (UC.FLAG_REPASSE == "1")
                {
                    fotos.ORIG_INFORM = 3;
                }
                else { fotos.ORIG_INFORM = 2; }
                //Insere foto
                try
                {
                    FotosFlow.Insert(fotos);
                    MessageBox.Show("Foto salva com sucesso.", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível salvar foto. Ex: " + ex + "", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }

           

        }

        private void mnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        private void mnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (FotosFlow.ExisteFoto(UC.NUM_UC, UC.MES_ANO_FATUR, UC.TIPO_MEDIC) > 0)
            {

                using (frmEditarFoto editarFoto = new frmEditarFoto(UC))
                {
                    //Abre tela editar foto.
                    editarFoto.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Não existe foto cadastrada para esta UC.", "Foto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmCapturarFoto_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                txbLegenda.Focus();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                txbLegenda.Focus();
            }
           
        }

        private void frmCapturarFoto_KeyUp(object sender, KeyEventArgs e)
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