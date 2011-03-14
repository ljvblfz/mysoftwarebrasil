using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace MobileTools.Controls
{
    public class LabelAutoResize : Control
    {
        #region Variáveis Locais

        private Bitmap bmp;
        private Graphics grp = null;

        /// <summary>
        /// Indica que houve alguma modificação no design do controle.
        /// </summary>
        private bool changeDesign = true;

        private Color m_BackColorUp;
        private Color m_BackColorClick;
        private Color m_BackColorOver;

        private bool m_AutoResize = true;

        private string m_myText = null;

        #endregion

        #region Propriedades

        public Color BackColorUp
        {
            get { return m_BackColorUp; }
            set { m_BackColorUp = value; }
        }

        public Color BackColorClick
        {
            get { return m_BackColorClick; }
            set { m_BackColorClick = value; }
        }

        public Color BackColorOver
        {
            get { return m_BackColorOver; }
            set { m_BackColorOver = value; }
        }

        [DefaultValue(true)]
        public bool AutoResize
        {
            get { return m_AutoResize; }
            set { m_AutoResize = value; }
        }

        #endregion

        #region Métodos Locais

        /// <summary>
        /// Cria um instância de um bitmap me memória.
        /// </summary>
        private void CreateMemoryBmp()
        {
            // Verifica se houve alguma modificação na dimensão do controle
            if (bmp == null || bmp.Width != this.Width || bmp.Height != this.Height)
            {
                // Libera memória
                if (bmp != null) bmp.Dispose();

                // Cria um bitmap do tamanho do controle
                bmp = new Bitmap(this.Width, Height);

                grp = Graphics.FromImage(bmp);

                // Preenche o imagem com a cor do controle
                grp.Clear(this.BackColor);

                changeDesign = true;

            }
        }

        /// <summary>
        /// Desenha o controle.
        /// </summary>
        private void Draw()
        {
            if (grp != null)
            {
                if (changeDesign)
                {
                    // Preenche o imagem com a cor do controle
                    grp.Clear(this.BackColor);
                    WriteText();
                }
                CreateGraphics().DrawImage(bmp, 0, 0);
                changeDesign = false;
            }
        }

        private void WriteText()
        {
            grp.DrawString(m_myText, Font, new SolidBrush(ForeColor), new RectangleF(0, 0, this.Width, this.Height));
        }

        #endregion

        public LabelAutoResize()
        {
            BackColor = SystemColors.Window;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Cria uma imagem em memoria.
            CreateMemoryBmp();

            Draw();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GenerateText();
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            base.OnBindingContextChanged(e);
            if (m_AutoResize)
            {
                GenerateText();
            }
        }

        private static SizeF MeasureStringExtended(Graphics g, string text, Font font, int desWidth)
        {
            string textRef = "";
            return MeasureStringExtended(g, text, font, desWidth, out textRef);
        }

        private static SizeF MeasureStringExtended(Graphics g, string text, Font font, int desWidth, out string textRef)
        {
            string tempString = text;
            string workString = "";
            string outputstring = "";
            int npos = 1;
            int sp_pos = 0, sp_pos1 = 0, sp_pos2 = 0, sp_pos3 = 0;
            bool bNeeded = false;
            int nWidth = 0;

            // Captura o tamanho original do texto
            SizeF size = g.MeasureString(text, font);

            // Verifica se o tamanho do texto é maior do tamanho desejado
            if (size.Width > desWidth)
            {
                while (tempString.Length > 0)
                {
                    //Verifica se existe mais letras a serem tratadas
                    if (npos > tempString.Length)
                    {
                        outputstring = outputstring + tempString;
                        break;
                    }
                    workString = tempString.Substring(0, npos);
                    //captura o tamanho atual da string
                    nWidth = (int)g.MeasureString(workString, font).Width;

                    // Verifica se a largura ultrapassa a lagura desejada
                    if (nWidth > desWidth)
                    {
                        // Procura indicadores que simbolizam quebra de linha
                        sp_pos1 = workString.LastIndexOf(" ");
                        sp_pos2 = workString.LastIndexOf(";");
                        sp_pos3 = workString.IndexOf("\r\n");

                        if (sp_pos3 > 0)
                        {
                            sp_pos = sp_pos3;
                            bNeeded = false;
                        }
                        else
                        {
                            if ((sp_pos2 > 0) && (sp_pos2 > sp_pos1))
                            {
                                sp_pos = sp_pos2;
                                bNeeded = true;
                            }
                            else if (sp_pos1 > 0)
                            {
                                sp_pos = sp_pos1;
                                bNeeded = true;
                            }
                            else
                            {
                                sp_pos = 0;
                                bNeeded = true;
                            }                        
                        }

                        if (sp_pos > 0)
                        {
                            if (sp_pos < 10)
                                continue;

                            //cut out the wrap lane we've found
                            outputstring = outputstring + tempString.Substring(0, sp_pos);
                            if (bNeeded) outputstring = outputstring + "\n";
                            tempString = tempString.Substring((sp_pos + 1), tempString.Length - (sp_pos + 1));
                            npos = 0;
                        }
                        else //no space
                        {
                            outputstring = outputstring + tempString.Substring(0, npos + 1);

                            if (bNeeded) outputstring = outputstring + "\n";
                            tempString = tempString.Substring(npos - 1, tempString.Length - npos);
                            npos = 0;
                        }
                    }
                    npos++;
                }
            }
            else
                outputstring = text;

            textRef = outputstring;

            SizeF returnSize = g.MeasureString(outputstring, font);

            return returnSize;
        }
        
        /// <summary>
        /// Obtem a dimensão que o texto vai ocupar.
        /// </summary>
        /// <param name="text">Texto.</param>
        /// <param name="font">Fonte do texto.</param>
        /// <param name="width">Largura máxima.</param>
        /// <returns></returns>
        public static SizeF GetSize(string text, Font font, int width)
        {
            string textRef = "";
            return GetSize(text, font, width, out textRef);
        }

        /// <summary>
        /// Obtem a dimensão que o texto vai ocupar.
        /// </summary>
        /// <param name="text">Texto.</param>
        /// <param name="font">Fonte do texto.</param>
        /// <param name="width">Largura máxima.</param>
        /// <returns></returns>
        public static SizeF GetSize(string text, Font font, int width, out string textRef)
        {
            if (width < 0)
            {
                textRef = null;
                return new SizeF(0.0f, 0.0f);
            }

            Bitmap b = new Bitmap(width, 10);
            Graphics g = Graphics.FromImage(b);
            SizeF s = MeasureStringExtended(g, text, font, width, out textRef);
            g.Dispose();
            g = null;
            b.Dispose();
            b = null;
            return s;
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                m_myText = value;
                base.Text = value;
                if (m_AutoResize)
                {
                    GenerateText();
                }
            }
        }

        private void GenerateText()
        {
            if (Text != null && Text != "")
            {
                try
                {
                    this.Height = (int)GetSize(Text, Font, Width, out m_myText).Height;
                }
                catch
                {

                }
            }
            changeDesign = true;
            Refresh();
        }
    }
}
