using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SPCadMobileData.Data.Model;
using SPCadMobile.View.AuxiliarClass;
using CommonHelpMobile;
using SPCadMobileData.Data;

namespace SPCadMobile.View
{
    public partial class FrmExibeFoto : Form
    {
        private Foto fotoCurrent;

        public FrmExibeFoto(Foto foto)
        {
            InitializeComponent();
            bindingSourceFoto.DataSource = foto;
            carregaFoto(foto);
        }

        private void carregaFoto(Foto foto)
        {
            picBoxFoto.Image = new Bitmap(InfoFiles.GetPathFoto() + foto.nomFoto); 
        }

        /// <summary>
        /// Salva informações da foto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemSalvar_Click(object sender, EventArgs e)
        {
            bindingSourceFoto.EndEdit();

            Foto foto = (Foto)bindingSourceFoto.Current;

            try
            {
                //atualiza ou insere nova foto.                
                SingletonFlow.fotoFlow.Insert(foto);
                fotoCurrent = foto;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            this.Close();
        }

        private void menuitemCancelar_Click(object sender, EventArgs e)
        {
            if (fotoCurrent != null && fotoCurrent.sequencia < 1)
            {
                System.IO.File.Delete(InfoFiles.GetPathFoto() + fotoCurrent.nomFoto);
            }

            this.Close();
        }

        private void inputPanelTeclado_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                if (inputPanelTeclado.Enabled)
                {
                    panelImagem.AutoScroll = true;
                    panelImagem.Height = inputPanelTeclado.VisibleDesktop.Height;
                }
                else
                {
                    panelImagem.AutoScroll = false;
                    panelImagem.Height = 294;
                }
            }
            catch (Exception)
            {
                inputPanelTeclado.Dispose();
            }
        }       

    }
}