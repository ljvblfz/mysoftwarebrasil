using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MobileTools.Controls.Collections;
using System.ComponentModel;

namespace MobileTools.Controls
{
    public class ImageListView : Control
    {
        #region Variáveis Locais

        /// <summary>
        /// Altura da base.
        /// </summary>
        private const int baseHeight = 50;

        /// <summary>
        /// Images da lista.
        /// </summary>
        private ImageSourceCollection _images = new ImageSourceCollection();

        private int _perLine = 2;

        private Color _borderColor = Color.Black;

        private int _borderWidth = 1;

        private int currentPage = 0;

        /// <summary>
        /// Ultima página válida.
        /// </summary>
        private int lastPage = 0;

        /// <summary>
        /// Vetor dos controles das imagens.
        /// </summary>
        private ImageButton[] imagesControls = null;

        private UltraButton nextPageButton;

        private UltraButton previousPageButton;

        /// <summary>
        /// Identifica se o controle foi liberado.
        /// </summary>
        private bool disposed = false;

        private int _selectedIndex = -1;

        private string _typeImage;

        #endregion

        #region Propriedades

        /// <summary>
        /// Cor da borda da lista.
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }
        
        /// <summary>
        /// Índice da imagem  selecionada.
        /// </summary>
        public int SelectedIndex
        {
          get { return _selectedIndex; }
        }

        /// <summary>
        /// Define o tipo da imagem a ser exibida
        /// </summary>
        public string TypeImage
        {
            get { return _typeImage; }
            set { _typeImage = value; }
        }

        /// <summary>
        /// Largura da borda da lista.
        /// </summary>
        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; }
        }

        /// <summary>
        /// Imagens da lista.
        /// </summary>
        public ImageSourceCollection Images
        {
            get { return _images; }
        }

        /// <summary>
        /// Quantidade de imagens por linha da lista.
        /// </summary>
        [DefaultValue(2)]
        public int PerLine
        {
            get { return _perLine; }
            set { _perLine = value; }
        }

        #endregion

        #region Classes Internas

        private class ImageButton : Control
        {
            #region Variáveis Locais

            /// <summary>
            /// Fonta da imagem usada no botão.
            /// </summary>
            private IImageSource _source;

            private Color _borderColor = Color.Black;

            private int _borderWidth = 1;

            #endregion

            #region Construtores

            public ImageButton()
                : base()
            {

            }

            #endregion

            #region Métodos Públicos

            public IImageSource Source
            {
                get
                {
                    return _source;
                }

                set
                {
                    _source = value;
                    OnPaint(new PaintEventArgs(this.CreateGraphics(), new Rectangle()));
                }
            }

            #endregion

            #region Métodos Protegidos

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                Graphics grp = e.Graphics;

                // Limpa o botão
                grp.Clear(this.BackColor);

                if (_source == null) return;

                // Imagem que será tratada
                Bitmap bmp = _source.CreateSource();

                // Verifica se a imagem está na posição vertical
                bool vertical = (bmp.Width < bmp.Height);

                // Novas dim da imagem
                float width, height;

                if (vertical)
                {
                    height = (bmp.Height * (float)this.Width) / bmp.Width;
                    width = (float)this.Width;
                }
                else
                {
                    // Veririca a escala da imagem
                    width = (bmp.Width * (float)this.Height) / bmp.Height;
                    height = (float)this.Height;
                }

                float left = (this.Width / 2.0f) - (width / 2);
                float top = (this.Height / 2.0f) - (height / 2);

                Rectangle dest = new Rectangle((int)Math.Round(left), (int)Math.Round(top), (int)Math.Round(width), (int)Math.Round(height));
                Rectangle recSource = new Rectangle(0, 0, bmp.Width, bmp.Height);

                // Desenha a imagem
                grp.DrawImage(bmp, dest, recSource, GraphicsUnit.Pixel);

                // Desenha a borda da imagem
                grp.DrawPolygon(new Pen(_borderColor, _borderWidth),
                   new Point[] { new Point(0, 0), new Point(this.Width - _borderWidth, 0),
                                  new Point(this.Width - _borderWidth, this.Height - _borderWidth), new Point(0, this.Height - _borderWidth),
                                  new Point(0, 0) });
            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);

                if (_source != null)
                    _source.Dispose();
            }

            #endregion
        }

        #endregion

        #region Construtores

        public ImageListView()
        {
            _images.ListChanged += new EventHandler(images_ListChanged);

            nextPageButton = new UltraButton();
            nextPageButton.Width = 50;
            nextPageButton.Height = 20;
            nextPageButton.Click += new EventHandler(nextPageButton_Click);
            nextPageButton.ImageButtonView = true;
            nextPageButton.ImageButton = Resources.NextButton;

            previousPageButton = new UltraButton();
            previousPageButton.Width = 50;
            previousPageButton.Height = 20;
            previousPageButton.Click += new EventHandler(previousPageButton_Click);
            previousPageButton.ImageButtonView = true;
            previousPageButton.ImageButton = Resources.PreviousButton;
            previousPageButton.Enabled = false;

            previousPageButton.Location = new Point(2, this.Height - previousPageButton.Height - 2);
            nextPageButton.Location = new Point(this.Width - nextPageButton.Width - 2, this.Height - nextPageButton.Height - 2);

            this.Controls.Add(nextPageButton);
            this.Controls.Add(previousPageButton);
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Método acionado quando um a lista de imagens é alterada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void images_ListChanged(object sender, EventArgs e)
        {
            RenderImages();
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            // Recupera o tamanho de cada página
            int pageSize = imagesControls.Length / PerLine;

            if ((imagesControls.Length * (currentPage + 1)) < _images.Count)
                currentPage++;
            else
            {
                nextPageButton.Enabled = false;
                return;
            }          

            // Move as imagens para cima
            for (int i = PerLine; i < imagesControls.Length; i++)
                imagesControls[i - PerLine].Source = imagesControls[i].Source;

            for (int i = pageSize * (currentPage + 1), j = 0; j < PerLine; i++, j++)
            {
                imagesControls[(imagesControls.Length - PerLine) + j].Tag = i;

                if (i < _images.Count)
                    imagesControls[(imagesControls.Length - PerLine) + j].Source = _images[i];
                else
                    imagesControls[(imagesControls.Length - PerLine) + j].Source = null;
            }

            nextPageButton.Enabled = ((imagesControls.Length * currentPage) < _images.Count);
            previousPageButton.Enabled = (currentPage != 0);            
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            // Recupera o tamanho de cada página
            int pageSize = imagesControls.Length / PerLine;

            if ((imagesControls.Length * (currentPage + 1)) > 0)
                currentPage--;
            else
            {
                previousPageButton.Enabled = false;
                return;
            }   

            // Move as imagens para baixo
            for (int i = imagesControls.Length - PerLine - 1; i >= 0; i--)
                imagesControls[i + PerLine].Source = imagesControls[i].Source;

            for (int i = (pageSize * currentPage), j = 0; j < PerLine; i++, j++)
            {
                if (i < _images.Count)
                    imagesControls[j].Source = _images[i];
                else
                    imagesControls[j].Source = null;
            }

            nextPageButton.Enabled = ((imagesControls.Length * currentPage) < _images.Count);
            previousPageButton.Enabled = (currentPage != 0);
        }

        private void imgBtn_Click(object sender, EventArgs e)
        {
            ImageButton imgBtn = (ImageButton)sender;

            if (imgBtn.Source == null) 
            {
                _selectedIndex = -1;
                return;
            }
            
            _selectedIndex = (int)imgBtn.Tag;

            PictureBox pic = new PictureBox();            

            pic.Click += new EventHandler(pic_Click);

            pic.Location = new Point(0, 0);

            Bitmap bmp = imgBtn.Source.CreateSource();

            // Verifica se a imagem está na posição vertical
            bool vertical = (bmp.Width < bmp.Height);

            // Novas dim da imagem
            float width, height;

            if (vertical)
            {
                width = (bmp.Width * (float)this.Height) / bmp.Height;
                height = (float)this.Height;
            }
            else
            {
                height = (bmp.Height * (float)this.Width) / bmp.Width;
                width = (float)this.Width;
            }

            Bitmap bmpAux = new Bitmap((int)Math.Round(width), (int)Math.Round(height));

            Graphics grp = Graphics.FromImage(bmpAux);

            Rectangle dest = new Rectangle(0, 0, (int)Math.Round(width), (int)Math.Round(height));
            Rectangle recSource = new Rectangle(0, 0, bmp.Width, bmp.Height);

            // Desenha a imagem
            grp.DrawImage(bmp, dest, recSource, GraphicsUnit.Pixel);

            pic.Image = bmpAux;

            // Defina o tamanho do PictureBox
            pic.Height = bmpAux.Height;
            pic.Width = bmpAux.Width;

            pic.Location = new Point((this.Width / 2) - (pic.Width / 2), (this.Height / 2) - (pic.Height / 2));

            foreach (Control ctrl in Controls)
                ctrl.Visible = false;

            this.Controls.Add(pic);
        }

        private void pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;

            Controls.Remove(pic);

            pic.Dispose();

            foreach (Control ctrl in Controls)
                ctrl.Visible = true;
        }

        /// <summary>
        /// Desenha o objeto
        /// </summary>
        private void CreateGraphicObject(Graphics grp)
        {
            if (_borderWidth > 0)
            {
                grp.DrawPolygon(new Pen(_borderColor, _borderWidth),
                    new Point[] { new Point(0, 0), new Point(this.Width - _borderWidth, 0),
                                  new Point(this.Width - _borderWidth, this.Height - _borderWidth), new Point(0, this.Height - _borderWidth),
                                  new Point(0, 0) });
            }
        }

        private void CreateImagesControls()
        {
            if (disposed) return;

            this.SuspendLayout();

            int imageWidth, imageHeight;

            // Define a largura de cada imagem
            imageWidth = (this.Width - 12) / PerLine;

            // Define a altura de cada imagem
            imageHeight = (int)Math.Round((imageWidth * 240.0f) / 320.0f);

            // Define o número máximo de linhas para exibição das imagens
            int maxLines = (int)Math.Ceiling((this.Height - baseHeight) / imageHeight);

            // Quantidade de controles na lista
            int controlsCount = (maxLines * PerLine);

            if (imagesControls != null && controlsCount > 0 && 
                imagesControls.Length == controlsCount && 
                imagesControls[0].Width == imageWidth && imagesControls[0].Height == imageHeight) return;

            if (imagesControls != null)
            {
                for (int x = 0; x < imagesControls.Length; x++)
                {
                    this.Controls.Remove(imagesControls[x]);
                    imagesControls[x].Dispose();
                }
            }

            // Define a quantidade de controles na tela
            imagesControls = new ImageButton[maxLines * PerLine];

            int i = 0, j = 0;

            for (int x = 0; x < imagesControls.Length; x++)
            {
                ImageButton imgBtn = new ImageButton();
                imgBtn.Width = imageWidth;
                imgBtn.Height = imageHeight;

                imgBtn.Click += new EventHandler(imgBtn_Click);

                // Define a locailização do controle
                imgBtn.Location = new Point((j * imageWidth) + (j * 4) + 4, (i * imageHeight) + (i * 4) + 4);

                if ((j + 1) == PerLine)
                {
                    i++;
                    j = 0;
                }
                else
                    j++;

                imagesControls[x] = imgBtn;

                this.Controls.Add(imagesControls[x]);
            }

            this.ResumeLayout();
        }

        /// <summary>
        /// Desenha a imagem na tela
        /// </summary>
        private void RenderImages()
        {
            if (disposed) return;

            CreateImagesControls();

            // Recupera o tamanho de cada página
            int pageSize = imagesControls.Length / PerLine;

            for (int i = pageSize * currentPage, j = 0; j < imagesControls.Length; i++, j++)
            {
                if (i < _images.Count)
                    imagesControls[j].Source = _images[i];
                else
                    imagesControls[j].Source = null;

                imagesControls[j].Tag = i;
            }

            nextPageButton.Enabled = ((pageSize * currentPage) < _images.Count);
                
        }

        #endregion

        #region Métodos Protegidos

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            CreateGraphicObject(e.Graphics);
        }

        public override void Refresh()
        {
            base.Refresh();
            RenderImages();
        }

        protected override void OnResize(EventArgs e)
        {
            previousPageButton.Location = new Point(2, this.Height - previousPageButton.Height - 2);
            nextPageButton.Location = new Point(this.Width - nextPageButton.Width - 2, this.Height - nextPageButton.Height - 2);

            base.OnResize(e);
            RenderImages();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            disposed = true;
            _images.Clear();
        }

        #endregion
    }
}
