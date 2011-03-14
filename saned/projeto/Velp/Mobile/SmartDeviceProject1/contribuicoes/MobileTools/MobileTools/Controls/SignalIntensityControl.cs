using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MobileTools.Controls
{
    /// <summary>
    /// Controle usado para mostrar intensidade de sinal.
    /// </summary>
    public class SignalIntensityControl : Control
    {
        #region Variáveis Locais

        /// <summary>
        /// Bitmap usado no controle.
        /// </summary>
        private Bitmap _mainBmp;

        /// <summary>
        /// Graphics usado no controle.
        /// </summary>
        private Graphics _mainGraphics;

        /// <summary>
        /// Brush usado para desenhar o fundo da barra quando ela estiver preenchida.
        /// </summary>
        private Brush _fillBarBrush = new SolidBrush(Color.Green);

        /// <summary>
        /// Brush usado para desenhar o fundo da barra quando ela não estiver preenchida.
        /// </summary>
        private Brush _emptyBarBrush = new SolidBrush(Color.White);

        private Color _fillBarBackColor = Color.Green;
        private Color _emptyBarBackColor = Color.White;
        private int _barCount = 5;
        private int _value = 0;

        #endregion

        #region Propriedades

        /// <summary>
        /// Cor de fundo da barra quando ela estiver preenchida.
        /// </summary>
        public Color FillBarBackColor
        {
            get { return _fillBarBackColor; }
            set 
            {
                if (value != _fillBarBackColor)
                    _fillBarBrush = new SolidBrush(value);

                _fillBarBackColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Cor de fundo da barra quando ela não estiver preenchida.
        /// </summary>
        public Color EmptyBarBackColor
        {
            get { return _emptyBarBackColor; }
            set 
            {
                if (value != _emptyBarBackColor)
                    _emptyBarBrush = new SolidBrush(value);

                _emptyBarBackColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Quantidade de barras que serão usadas.
        /// </summary>
        public int BarCount
        {
            get { return _barCount; }
            set 
            { 
                _barCount = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Valor do sinal.
        /// </summary>
        public int Value
        {
            get { return _value; }
            set
            {
                if (value > _barCount || value < 0)
                    throw new Exception("Value not in range.");

                _value = value;

                this.Refresh();
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Verifica se o bitmap do controle ainda não foi carregado ou se as dimensões do controle forem alteradas
            if (_mainBmp == null || _mainBmp.Width != this.Width || _mainBmp.Height != this.Height)
            {
                if (_mainBmp != null)
                    try
                    {
                        // Libera o bitmap que estava sendo usado
                        _mainBmp.Dispose();
                    }
                    catch
                    {
                    }

                // Cria um bitmap na memoria
                _mainBmp = new Bitmap(this.Width, this.Height);
                _mainGraphics = Graphics.FromImage(_mainBmp);
            }

            _mainGraphics.Clear(this.BackColor);

            if (!Visible)
                return;
            
            // Recupera a largura de cada bara do controle
            int barWidth = (int)Math.Floor(this.Width / (float)_barCount);

            // Cada barra tem que ter pelo menos 3 pixels
            if (barWidth < 3) return;

            // Recupera o tamanho do passo de cada bara
            float step = (this.Height / 100.0f) * (100 / (_barCount + 1));

            // Alturas das barras
            float[] heights = new float[_barCount];

            // Preenche as alturas das barras
            for (int i = 2; i < _barCount + 1; i++)
                heights[i - 2] = step * i;

            // A ultima barra tem a altura do controle
            heights[_barCount - 1] = this.Height - 1;

            // Largura das barras
            int[] widths = new int[_barCount + 1]; // { 0, barWidth, barWidth * 2, barWidth * 3, barWidth * 4, (barWidth * 5) };

            for (int i = 0; i < _barCount + 1; i++)
                widths[i] = barWidth * i;

            for (int i = 0; i < _barCount; i++)
            {
                Point[] points = new Point[5];

                points[0] = new Point(widths[i], this.Height - 1);
                points[1] = new Point(widths[i], this.Height - 1 - (int)Math.Floor(heights[i]));
                points[2] = new Point(widths[i + 1], this.Height - 1 - (int)Math.Floor(heights[i]));
                points[3] = new Point(widths[i + 1], this.Height - 1);
                points[4] = points[0];

                Pen borderPen = new Pen(Color.Black, 1.0f);

                _mainGraphics.FillPolygon((_value >= (i + 1) ? _fillBarBrush : _emptyBarBrush), points);
                _mainGraphics.DrawPolygon(new Pen(Color.Black, 1.0f), points);

            }
           
            // Carrega o bitmap da memoria para a tela
            this.CreateGraphics().DrawImage(_mainBmp, 0, 0);

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            try
            {
                _mainGraphics.Dispose();
                _mainBmp.Dispose();
            }
            catch
            {

            }

        }
    }
}
