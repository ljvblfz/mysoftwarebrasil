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
    /// Representa a estrutura de uma questão simples.
    /// </summary>
    public class SimpleQuestion
    {
        #region Variáveis Locais

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
        /// Cor de fundo da questão.
        /// </summary>
        public Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }

        /// <summary>
        /// Cor do texto da questão.
        /// </summary>
        public Color ForeColor
        {
            get { return _foreColor; }
            set { _foreColor = value; }
        }

        /// <summary>
        /// Fonte dos itens da questão.
        /// </summary>
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        #endregion
    }    
}
