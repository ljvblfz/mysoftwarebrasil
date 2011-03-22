using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MobileTools.CheckList
{
    /// <summary>
    /// Representa a estrutura de uma quest�o simples.
    /// </summary>
    public class SimpleQuestion
    {
        #region Vari�veis Locais

        private ItemQuestionCollection _items = new ItemQuestionCollection();
        private Color _backColor;
        private Color _foreColor;
        private Font _font;

        #endregion

        #region Propriedades

        /// <summary>
        /// Lista dos itens da resposta simples.
        /// </summary>
        public ItemQuestionCollection Items
        {
            get { return _items; }
        }

        /// <summary>
        /// Cor de fundo da quest�o.
        /// </summary>
        public Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }

        /// <summary>
        /// Cor do texto da quest�o.
        /// </summary>
        public Color ForeColor
        {
            get { return _foreColor; }
            set { _foreColor = value; }
        }

        /// <summary>
        /// Fonte dos itens da quest�o.
        /// </summary>
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        #endregion
    }    
}
