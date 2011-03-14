#region Using directives

using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

#endregion

namespace MobileTools.Controls
{    
    /// <summary>
    ///  Button customizado para aplicações em Windows CE ou PocketPC
    /// </summary>
    [DesignTimeVisible(true)]
    public class UltraButton : Control
    {
        // Imagem
        Bitmap m_bmp;
        Graphics m_Graphics;
        
        // Objeto graficos
        SolidBrush m_GdiDisabled; // Cor do item quando disabled
        Pen _border = new Pen(Color.Black); // Cor da borda realmente usada
        Color _buttonColor = Color.White;
        Color _buttonColorClick = SystemColors.GrayText; // Cor de fundo do quando acionado o evento OnMouseDown       
        Color _textColor = SystemColors.WindowText; // Cor do texto
        Color _textColorClick = Color.White; // Cor do texto quando acionado o evento OnMouseDown     
        Color _textColorDisabled = SystemColors.InactiveCaption; // Cor do texto Disabled
        TypeTextAlign _textAlign = TypeTextAlign.Center;

        Bitmap _imageButton = new Bitmap(10, 10);        
        Boolean _imageButtonView = false;
      
        
        // Variaveis das propriedades
        int _radius = 8; // Raio da vertices do componente
                

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Propriedades
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Gets ou sets o raio dos vertices.
        /// </summary>
        public int Radius
        {
            get { return _radius; }
            set 
            { 
                _radius = value;
                this.Refresh();
            }
                                   
        }

        public Color ButtonColor
        {
            get { return _buttonColor; }
            set 
            { 
                _buttonColor = value;
                this.Refresh();
            }
        }

        public TypeTextAlign TextAlign
        {
            get { return _textAlign; }
            set 
            { 
                _textAlign = value;
                this.Refresh();
            }
        }

        public Color BorderColor
        {
            get { return _border.Color; }
            set 
            { 
                _border.Color = value;
                this.Refresh();
            }
        }

        public Color ButtonColorClick
        {
            get { return _buttonColorClick; }
            set 
            { 
                _buttonColorClick = value;
                this.Refresh();
            }
        }

        public Color TextColor
        {
            get { return _textColor; }
            set 
            { 
                _textColor = value;
                this.Refresh();
            }
        }

        public Color TextColorClick
        {
            get { return _textColorClick; }
            set 
            { 
                _textColorClick = value;
                this.Refresh();
            }
        }

        public Bitmap ImageButton
        {
            get { return _imageButton; }
            set 
            { 
                _imageButton = value;
                this.Refresh();
            }
        }

        public Boolean ImageButtonView
        {
            get { return _imageButtonView; }
            set 
            { 
                _imageButtonView = value;
                this.Refresh();
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Construtor
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public UltraButton()
        {
            this.Size = new Size(80, 20);                  
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Overrides
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Redesenha o componente
            DrawClick();

            base.OnMouseDown(e); 
        }

        private void DrawClick()
        {
            // Redesenha o componente
            Draw(_buttonColorClick, _textColorClick);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Draw();                    
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Draw();                     
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            return;
        }
        
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return base.CreateControlsInstance();
        }

        // Desenha o Componente
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Desenha o bmp para memoria
            CreateMemoryBitmap();

            // Limpa o background da imagem
            m_Graphics.Clear(this.BackColor);

            // Desenha o botão
            Draw();
                                
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Funções
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Desenha o botão.
        /// </summary>
        private void Draw()
        {
            Draw(_buttonColor, _textColor);
        }

        /// <summary>
        /// Desenha o botão.
        /// </summary>
        /// <param name="bgColor">Cor de fundo do botão.</param>
        /// <param name="textColor">Cor do texto do botão.</param>
        private void Draw(Color bgColor, Color textColor)
        {
            try
            {
                if (m_Graphics == null)
                    return;

                // Captura o tamanho da texto do componente
                Size size = m_Graphics.MeasureString(this.Text, this.Font).ToSize();

                // Alinhamento com a imagem
                int addAlingWithImage = 0;

                // Desenha o fundo do componente
                DrawRoundRectangle(bgColor);

                // O botão possui uma imagem
                if (_imageButtonView)
                {
                    if (_imageButton != null)
                        try
                        {
                            m_Graphics.DrawImage(_imageButton, (string.IsNullOrEmpty(this.Text) ? (this.Width / 2) - (_imageButton.Width / 2) : 7),
                                                    ((this.Height - _imageButton.Height) / 2));

                            addAlingWithImage = _imageButton.Width + 8;
                        }
                        catch
                        {
                            m_Graphics.DrawLine(new Pen(Color.Red, 3), 0, 0, this.Width, this.Height);
                            m_Graphics.DrawLine(new Pen(Color.Red, 3), 0, this.Height, this.Width, 0);
                        }
                }

                // Desenha o texto no componente
                // Verifica a situação do componente a coloca a cor apropriada
                m_Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.Enabled ? textColor : _textColorDisabled),
                    addAlingWithImage + ((this._textAlign == TypeTextAlign.Center) ? (int)Math.Round((this.Width - addAlingWithImage - size.Width) / 2.0f) : 3),
                    (int)Math.Round((this.Height - size.Height) / 2.0f));

                // Carrega o bitmap da memoria para a tela
                this.CreateGraphics().DrawImage(m_bmp, 0, 0);
            }
            catch (ObjectDisposedException)
            {
                
            }          

        }

        /// <summary>
        ///  Cria um bitmap na memoria. Isso evita cria um duplo buffer
        ///  para previnir que o imagem não fique piscando
        /// </summary>
        private void CreateMemoryBitmap()
        {
            if (m_bmp == null || m_bmp.Width != this.Width || m_bmp.Height != this.Height)
            {

                // Cria um bitmap na memoria
                m_bmp = new Bitmap(this.Width, this.Height);
                m_Graphics = Graphics.FromImage(m_bmp);
                m_Graphics.Clear(this.BackColor);
            }
        }

        /// <summary>
        ///  Essa função tem como objetivo desenhar um retangulo
        ///  com os lados arredondados
        /// </summary>
        /// <param name="bgColor">Cor de fundo do botão.</param>
        private void DrawRoundRectangle(Color bgColor)
        {
            // Caso o botão sejá retagular
            if (_radius == 0)
            {
                m_Graphics.FillRectangle(new SolidBrush(bgColor), 0, 0, this.Width, this.Height);
                m_Graphics.DrawRectangle(_border, 0, 0, this.Width - 1, this.Height - 1);
                return;
            }

            int Width = this.Width, Height = this.Height;
            // Redefine os valores de altura e largura de acordo 
            // com o tamanho do raio
            int pontoX = (Width - _radius),
                pontoY = (Height - _radius);
            int i, count = 0;

            Point[] pon = new Point[360];

            for (i = 89; i > 0; i--)
            {
                pon[count].X = pontoX + (int)(Math.Cos(ConvertGruasRadianos(i)) * _radius);
                pon[count++].Y = pontoY + (int)(Math.Sin(ConvertGruasRadianos(i)) * _radius);
            }

            pontoY = pon[count - 1].Y - Height + (_radius * 2);
            pon[count].X = pon[count - 1].X;
            pon[count].Y = pontoY;

            count++;

            for (i = 359; i > 270; i--)
            {
                pon[count].X = pontoX + (int)(Math.Cos(ConvertGruasRadianos(i)) * _radius);
                pon[count++].Y = pontoY + (int)(Math.Sin(ConvertGruasRadianos(i)) * _radius);
            }

            pontoX = pon[count - 1].X - Width + (_radius * 2);
            pon[count].X = pontoX;
            pon[count].Y = pon[count - 1].Y;
            count++;

            for (i = 269; i > 180; i--)
            {
                pon[count].X = pontoX + (int)(Math.Cos(ConvertGruasRadianos(i)) * _radius);
                pon[count++].Y = pontoY + (int)(Math.Sin(ConvertGruasRadianos(i)) * _radius);
            }

            pontoY = pon[count - 1].Y + Height - (_radius * 2);
            pon[count].X = pon[count - 1].X;
            pon[count].Y = pontoY;
            count++;

            for (i = 179; i > 90; i--)
            {
                pon[count].X = pontoX + (int)(Math.Cos(ConvertGruasRadianos(i)) * _radius);
                pon[count++].Y = pontoY + (int)(Math.Sin(ConvertGruasRadianos(i)) * _radius);
            }

            pontoX = pon[count - 1].X + Width - (_radius * 2);
            pon[count].X = pontoX;
            pon[count].Y = pon[count - 1].Y;


            m_Graphics.FillPolygon(new SolidBrush(bgColor), pon);
            m_Graphics.DrawPolygon(_border, pon);
            
        }

        private static double ConvertGruasRadianos(int graus)
        {
            return ((graus * Math.PI) / 180);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            try
            {
                _imageButton.Dispose();
            }
            catch
            {

            }
        }       

    }
}
