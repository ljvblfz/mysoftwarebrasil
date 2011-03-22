using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPCadDesktop.Views
{
    public partial class frmVisualizarFoto : Form
    {
        public frmVisualizarFoto(Image imagem)
        {
            InitializeComponent();
            pictureFotoGrande.Image = imagem;
            pictureFotoGrande.Image = pictureFotoGrande.Image.GetThumbnailImage(800, 600, null, new System.IntPtr(0));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // largura original
            int oWidth = pictureFotoGrande.Image.Width;

            // altura original
            int oHeight = pictureFotoGrande.Image.Height;

            // aumenta a imagem em 10 
            pictureFotoGrande.Image = pictureFotoGrande.Image.GetThumbnailImage(oWidth + 10, oHeight + 10, null, new System.IntPtr(0));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // largura original
            int oWidth = pictureFotoGrande.Image.Width;

            // altura original
            int oHeight = pictureFotoGrande.Image.Height;

            if (oWidth > 800 && oHeight > 600)
                // diminuir a imagem em 10 
                pictureFotoGrande.Image = pictureFotoGrande.Image.GetThumbnailImage(oWidth - 10, oHeight - 10, null, new System.IntPtr(0));
        }
    }
}
