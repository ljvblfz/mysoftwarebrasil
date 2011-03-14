using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace MobileTools.Controls
{
    public class Title : Control
    {
        #region Variáveis Locais

        // Imagem
        Bitmap m_bmp;
        Graphics m_Graphics;

        // Objeto graficos
        SolidBrush m_TextColor = new SolidBrush(SystemColors.WindowText); // Cor do texto
        SolidBrush m_TextColorDisabled; // Cor do texto Disabled
        TypeTextAlign m_TextAlign = TypeTextAlign.Right;
        SolidBrush m_BgLine = new SolidBrush(Color.WhiteSmoke);
        
        // Atributos
        int m_HeightLine = 10; // Altura a linha a ser desenhada
        int m_WidthInclination = 10; // Largura da inclinação dos cantos
        int m_DistanceWordLine = 4; // Distancia da palavra com a linha

        /// <summary>
        /// Proporção da altura com a tela.
        /// </summary>
        private static float heightProportion = (float)Math.Round(Screen.PrimaryScreen.Bounds.Height / 240f);
        /// <summary>
        /// Proporção da largura com a tela.
        /// </summary>
        private static float widthProportion = (float)Math.Round(Screen.PrimaryScreen.Bounds.Width / 320f);

        #endregion

        #region Propriedades

        /// <summary>
        /// Sobrescreve propriedade text para garantir
        /// que quando for setada, o objeto seja 
        /// redesenhado
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }
        
        /// <summary>
        /// Alinhamento do texto.
        /// </summary>
        public TypeTextAlign TextAlign
        {
            get { return m_TextAlign; }
            set { m_TextAlign = value; }
        }

        /// <summary>
        ///  Define a cor do texto
        /// </summary>
        public Color TextColor
        {
            get { return m_TextColor.Color; }
            set { m_TextColor.Color = value; }
        }

        /// <summary>
        ///  Define a altura da linha
        /// </summary>
        public int HeightLine
        {
            get { return m_HeightLine; }
            set { m_HeightLine = value; }
        }
        
        /// <summary>
        ///  Define a largura do ponto de inclinação da linha
        /// </summary>
        public int WidthInclination
        {
            get { return m_WidthInclination; }
            set { m_WidthInclination = value; }
        }

        /// <summary>
        ///  Define a cor da linha
        /// </summary>
        public Color ColorLine
        {
            get { return m_BgLine.Color; }
            set { m_BgLine.Color = value; }
        }

        /// <summary>
        ///  Define a distância entre a titulo e a linha
        /// </summary>
        public int DistanceWordLine
        {
            get { return m_DistanceWordLine; }
            set { m_DistanceWordLine = value; }
        }

        #endregion

        #region Métodos Sobreescritos

        // Desenha o Componente
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Desenha o bmp para memoria
            CreateMemoryBitmap();
            CreateGraphicObject();

            // Limpa o background da imagem
            m_Graphics.Clear(Color.White);

            // Desenha o botão
            Draw();

        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Desenhao componente.
        /// </summary>
        private void Draw()
        {
            // Captura o tamanho da texto do componente
            Size size = m_Graphics.MeasureString(this.Text, this.Font).ToSize();

            // Define a altura do componente
            this.Height = m_HeightLine + size.Height + m_DistanceWordLine + 2;
           
            // Desenha o texto no componente
            // Verifica a situação do componente a coloca a cor apropriada
            m_Graphics.DrawString(this.Text, this.Font,
                this.Enabled ? m_TextColor : m_TextColorDisabled,
                (int)(((this.m_TextAlign == TypeTextAlign.Center) ? ((this.Width - size.Width + 2) / 2) + 2 * m_WidthInclination : 3 + m_WidthInclination) * widthProportion),
                (int)((this.Height - m_HeightLine - size.Height - m_DistanceWordLine) * heightProportion));

            // Desenha a linha
            DrawLine();

            // Carrega o bitmap da memoria para a tela
            this.CreateGraphics().DrawImage(m_bmp, 0, 0);

        }

        /// <summary>
        /// Desenha a linha.
        /// </summary>
        private void DrawLine()
        {
            // Pontos do desenho
            Point[] pon = new Point[4];

            // Ponto inferior do lado esquerdo
            pon[0].X = 0; 
            pon[0].Y = this.Height;

            // Ponto inferior do lado direitor
            pon[1].X = this.Width - m_WidthInclination; 
            pon[1].Y = this.Height;

            // Ponto superior do lado direito
            pon[2].X = this.Width; 
            pon[2].Y = this.Height - m_HeightLine;
            
            // Ponto superior do lado esquerdo
            pon[3].X = m_WidthInclination;
            pon[3].Y = this.Height - m_HeightLine;

            m_Graphics.FillPolygon(m_BgLine, pon);

        }

        /// <summary>
        ///  Cria as instancias graficas para o objeto
        /// </summary>
        private void CreateGraphicObject()
        {
                       
            // Define a cor para o texto normal
            if (m_TextColor == null)
                m_TextColor = new SolidBrush(SystemColors.WindowText);

            // Define a cor para o texto Disabled
            if (m_TextColorDisabled == null)
                m_TextColorDisabled = new SolidBrush(SystemColors.InactiveCaption);


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

        #endregion
    }
}
