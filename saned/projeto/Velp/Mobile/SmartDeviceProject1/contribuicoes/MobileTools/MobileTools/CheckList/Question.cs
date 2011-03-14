using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MobileTools.Controls;
using System.Drawing;
using System.ComponentModel;
using System.Reflection; 
namespace MobileTools.CheckList
{
    #region Enums

    /// <summary>
    /// Tipos de Perguntas.
    /// </summary>
    public enum QuestionType : int
    {
        SimpleQuestionAndComment = 1,
        SimpleQuestionAndListQuestionAndComment = 2,
        SimpleQuestionAndMultipleOptionsAndComment = 3,
        ListQuestionAndComment = 4,
        Comment = 5
    }

    #endregion

     
    /// <summary>
    /// Representa uma quest�o do checklist.
    /// </summary>
    /// 
    public class Question : Control
    {
        #region Vari�veis Locais

        /// <summary>
        /// Objeto usado na identifica��o da quest�o.
        /// </summary>
        private object _identification;
        private SimpleQuestion _currentSimpleQuestion;
        private QuestionType _currentQuestionType;
        private ItemQuestion _answer;
        private ItemQuestionCollection _itemsMultipleOptions;
        private ItemQuestionCollection _selectedItems;
        private int _selectedIndex = -1;
        private bool _warning;
        private bool _visibleCommentButton = true;
        private bool _visibleComment = true;
        private string _commentText = "";

        #region Controles

        private Control panelSimpleQuestion = new Control();
        private LabelAutoResize questionLabel = new LabelAutoResize();
        private UltraButton commentButton = new UltraButton();
        private TextBox comment = new TextBox();
        private ComboBox itemsComboBox = new ComboBox();
        private Control panelAdditionalsControls = new Control();
        private MultipleOptions mo = null;        
               

        #endregion

        #endregion

        #region Eventos

        /// <summary>
        /// Evento acionado quando a observa��o � alterada.
        /// </summary>
        //public event SelectedQuestion ChangedComment;

        /// <summary>
        /// Evento acionado quando a resposta � alterada.
        /// </summary>
        public event ChangeAnswer AnswerChanged;

        /// <summary>
        /// Evento acionado quando a resposta est� sendo alterada.
        /// </summary>
        public event ChangeAnswer AnswerChanging;

        /// <summary>
        /// Evento acionado quando os estado de uma op��o � alterado.
        /// </summary>
        public event EventOption OptionStateChanged;

        
        #endregion

        #region Propriedade

        /// <summary>
        /// Identifica se a combobox de op��es deve ficar vis�vel
        /// </summary>
        public bool VisibleComboOptions
        {
            get { return itemsComboBox.Visible; }
            set { itemsComboBox.Visible = value; }
        }

        /// <summary>
        /// Identifica se a combobox de multiplas op��es deve ficar vis�vel
        /// </summary>
        public bool VisibleMultipleOptions
        {
            get {
                if (mo != null)
                    return mo.Visible;
                else
                    return false;
            }
            set {
                if(mo != null)
                mo.Visible = value; }
        }


        /// <summary>
        /// Lista dos controles adicionais da quest�o.
        /// </summary>
        public ControlCollection AdditionalsControls
        {            
            get { return panelAdditionalsControls.Controls; }
        }

        /// <summary>
        /// Identifica se o bot�o de coment�rio � para ficar vis�vel ou n�o.
        /// </summary>
        public bool VisibleCommentButton
        {
            get { return _visibleCommentButton; }
            set { _visibleCommentButton = value; }
        }

        /// <summary>
        /// Identifica se o coment�rio � para ficar vis�vel ou n�o.
        /// </summary>
        public bool VisibleComment
        {
            get { return _visibleComment; }
            set { _visibleComment = value; }
        }

        /// <summary>
        /// Texto da caixa de coment�rio.
        /// </summary>
        public string CommentText
        {
            get { return _commentText; }
            set
            {
                _commentText = value;
                foreach (Control ctrl in Controls)
                    if (ctrl is TextBox)
                    {
                        TextBox tb = (TextBox)ctrl;
                        // Seta o texto do Coment�rio
                        tb.Text = _commentText;
                    }
            }
        }

        /// <summary>
        /// Bot�o de coment�rio.
        /// </summary>
        public UltraButton CommentButton
        {
            get { return commentButton; }
        }

        /// <summary>
        /// Campo para identificar a pergunta.
        /// </summary>
        public object Identification
        {
            get { return _identification; }
            set { _identification = value; }
        }

        /// <summary>
        /// Resposta da quest�o simples.
        /// </summary>
        public ItemQuestion SimpleQuestionAnswer
        {
            get { return _answer; }
            set
            {
                _answer = value;

                foreach (Control ctrl in panelSimpleQuestion.Controls)
                    if (ctrl is RadioButton)
                    {
                        // Recupera o item da quest�o relacionado com o radioButton
                        ItemQuestion it = (ItemQuestion)ctrl.Tag;

                        // Verifica se � o elemento da resposta
                        if (_answer != null && ((_answer.Value != null && _answer.Value.Equals(it.Value)) || (_answer.Value == null && it.Value == null)))
                        {
                            ((RadioButton)ctrl).Checked = true;
                            break;
                        }
                    }
            }
        }

        /// <summary>
        /// Quest�o simples relacionada.
        /// </summary>
        public SimpleQuestion CurrentSimpleQuestion
        {
            get { return _currentSimpleQuestion; }
            set { _currentSimpleQuestion = value; }
        }

        /// <summary>
        /// Itens da lista de quest�es.
        /// </summary>
        public ItemQuestionCollection ItemsMultipleOptions
        {
            get
            {
                if (_itemsMultipleOptions == null)
                    _itemsMultipleOptions = new ItemQuestionCollection();

                return _itemsMultipleOptions;
            }
        }

        /// <summary>
        /// Index do item selecionado.
        /// </summary>
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }

        /// <summary>
        /// Item selecionado.
        /// </summary>
        public ItemQuestion SelectedItem
        {
            get
            {
                if (_selectedIndex > -1 && _itemsMultipleOptions != null)
                    return (ItemQuestion)_itemsMultipleOptions[_selectedIndex];
                else
                    return null;
            }
            set
            {
                if (_itemsMultipleOptions == null)
                    throw new KeyNotFoundException("Item not found list.");

                for (int i = 0; i < _itemsMultipleOptions.Count; i++)
                    if (_itemsMultipleOptions[i] == value)
                    {
                        _selectedIndex = i;
                        return;
                    }

                // Item n�o foi encontrado.
                throw new KeyNotFoundException("Item not found list.");
            }
        }

        /// <summary>
        /// Itens selecinados.
        /// </summary>
        public ItemQuestionCollection SelectedItems
        {
            get
            {
                if (_selectedItems == null)
                    _selectedItems = new ItemQuestionCollection();

                return _selectedItems;
            }
        }

        /// <summary>
        /// Tipo de pergunta.
        /// </summary>
        public QuestionType CurrentQuestionType
        {
            get { return _currentQuestionType; }
            set { _currentQuestionType = value; }
        }

        /// <summary>
        /// Define que a pergunta deve receber mais aten��o.
        /// </summary>
        public bool Warning
        {
            get { return _warning; }
            set { _warning = value; }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor padr�o.
        /// </summary>
        public Question()
        {
            commentButton.Text = "Comment";
            this.Controls.Add(questionLabel);
        }

        #endregion

        #region M�todos Privados

        /// <summary>
        /// Cria a quest�o simples.
        /// </summary>
        /// <returns></returns>
        private Control CreateSimpleQuestion()
        {
            panelSimpleQuestion.Width = this.Width - 4;
            panelSimpleQuestion.BackColor = _currentSimpleQuestion.BackColor;

            int posX = 0, height = 0;

            Bitmap aux = new Bitmap(1, 1);
            Graphics grp = Graphics.FromImage(aux);

            for (int i = 0; i < _currentSimpleQuestion.Items.Count; i++)
            {
                ItemQuestion it = (ItemQuestion)_currentSimpleQuestion.Items[i];
                RadioButton itemRadioButton = new RadioButton();

                // Define os dados do elemento
                itemRadioButton.Text = it.Description;
                itemRadioButton.Tag = it;
                // Define a formata��o
                itemRadioButton.Font = _currentSimpleQuestion.Font;
                itemRadioButton.ForeColor = _currentSimpleQuestion.ForeColor;

                // Verifica se � o elemento da resposta
                if (_answer != null && ((_answer.Value != null && _answer.Value.Equals(it.Value)) || (_answer.Value == null && it.Value == null)))
                    itemRadioButton.Checked = true;

                // Define as dimens�es
            itemRadioButton.Location = new Point(posX, 0);
                SizeF textDimensions = grp.MeasureString(it.Description, itemRadioButton.Font);
                // Calcula as dimens�es dos componentes para ajusta a tela dos dispositivos 
                itemRadioButton.Width = (int)(textDimensions.Width + (25 * (Screen.PrimaryScreen.Bounds.Width / 240.0f)));
                itemRadioButton.Height = (int)(itemRadioButton.Height * (Screen.PrimaryScreen.Bounds.Height / 320.0f));


                // Define o evento que ser� acionado quando selecionado
                itemRadioButton.CheckedChanged += itemRadioButton_CheckStateChanged;

                posX += itemRadioButton.Width + 4;

                height = itemRadioButton.Height;

                // Adiciona o controle no panel
                
                panelSimpleQuestion.Controls.Add(itemRadioButton);

                
            }

            grp.Dispose();
            aux.Dispose();

            panelSimpleQuestion.Height = height + 2;
            return panelSimpleQuestion;
        }

        /// <summary>
        /// M�todo acionado quando a resposta da quest�o simples � alterada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemRadioButton_CheckStateChanged(object sender, EventArgs e)
        {
            RadioButton itemRadioButton = (RadioButton)sender;

            if (itemRadioButton.Tag as ItemQuestion  == _answer) return;

            // Constr�i o argumento para o evento
            ChangeAnswerArgs arg = new ChangeAnswerArgs((ItemQuestion)itemRadioButton.Tag, _answer);

            if (this.AnswerChanging != null)
                AnswerChanging(this, arg);

            if (arg.Cancel)
            {
                // Recupera o elemento pai
                Control panel = itemRadioButton.Parent;

                itemRadioButton.CheckedChanged -= itemRadioButton_CheckStateChanged;

                // Procura o item da resposta anterior
                foreach (Control it in panel.Controls)
                {
                    if (it.Tag as ItemQuestion == _answer)
                    {
                        RadioButton it2 = ((RadioButton)it);
                        // Remove o m�todo de altera��o
                        it2.CheckedChanged -= itemRadioButton_CheckStateChanged;
                        it2.Checked = !it2.Checked;
                        it2.CheckedChanged += itemRadioButton_CheckStateChanged;

                        break;
                    }
                }

                itemRadioButton.CheckedChanged += itemRadioButton_CheckStateChanged;
                return;
            }

            _answer = arg.NewAnswer;

            if (AnswerChanged != null)
                AnswerChanged(this, arg);

        }

        /// <summary>
        /// M�todo acionado quando um item � marcado ou n�o na multipla escolha.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="item"></param>
        private void mo_ItemCheckStateChanged(object sender, ItemQuestion item)
        {
            if (OptionStateChanged != null)
                OptionStateChanged(this, item);
        }

        /// <summary>
        /// M�todo acionado quando o item da combobox � selecionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            _selectedIndex = cmb.SelectedIndex;

            if (cmb.SelectedIndex >= 0 && OptionStateChanged != null)
            {
                OptionStateChanged(this, (ItemQuestion)cmb.SelectedItem);
            }
        }

        #endregion

        #region M�todos Publicos

        /// <summary>
        /// Constr�i a quest�o.
        /// </summary>
        public void Build()
        {
            this.SuspendLayout();

            // Libera os controles da quest�o simples
            foreach (Control ctrl in panelSimpleQuestion.Controls)
                ctrl.Dispose();

            // Remove todos o controles
            panelSimpleQuestion.Controls.Clear();

            // Remove os controles existentes
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i] == panelSimpleQuestion ||
                    Controls[i] == panelAdditionalsControls ||
                    Controls[i] == itemsComboBox)
                {
                    Controls.RemoveAt(i);
                    i--;
                }
                else if (Controls[i] is MultipleOptions)
                {
                    // Libera o controle
                    //Controls[i].Dispose();
                    //Controls.RemoveAt(i);
                    //i--;
                    MultipleOptions aRemover = (MultipleOptions)Controls[i];
                    Controls.RemoveAt(i);
                    aRemover.Dispose();
                    i--;
                }


            Size currentSize = Size;

            // Verifica o tamanho que vai ficar o label com a pergunta.
            SizeF s = LabelAutoResize.GetSize(Text, Font, Width - 4);

            questionLabel.Font = Font;
            // Posiciona o label da quest�o.
            questionLabel.Location = new System.Drawing.Point(2, 3);
            // Define a largura
            questionLabel.Width = Width - 4;
            questionLabel.Text = Text;


            // Recupera a posi��o onde ir� ficar o pr�ximo elemento da quest�o
            int pos = questionLabel.Location.Y + ((int)s.Height) + 5;

            // Verifica se � menor que a altura minima
            if (pos < 42)
                // Ajusta para a altura minima
                pos = 42;


            int posAux = pos;

            // Cria o trecho de quest�es simples
            if (_currentQuestionType == QuestionType.SimpleQuestionAndComment
                || _currentQuestionType == QuestionType.SimpleQuestionAndListQuestionAndComment
                || _currentQuestionType == QuestionType.SimpleQuestionAndMultipleOptionsAndComment)
            {
                Control sq = CreateSimpleQuestion();
                sq.Location = new Point(2, pos);

                this.Controls.Add(sq);
                pos += sq.Height + 5;
                
            }           

            if (_currentQuestionType == QuestionType.ListQuestionAndComment ||
                _currentQuestionType == QuestionType.SimpleQuestionAndListQuestionAndComment)
            {

                itemsComboBox.SelectedIndexChanged -= new EventHandler(itemsComboBox_SelectedIndexChanged);

                itemsComboBox.Items.Clear();
                itemsComboBox.Width = this.Width - 4;
                itemsComboBox.Height = (int)(itemsComboBox.Height * (Screen.PrimaryScreen.Bounds.Height / 320.0f));

                // Carrega os itens de multipla escolha
                foreach (ItemQuestion it in _itemsMultipleOptions)
                {
                    itemsComboBox.Items.Add(it);

                    // Verifica se � o item selecionado
                    if (it == SelectedItem)
                        itemsComboBox.SelectedIndex = itemsComboBox.Items.Count - 1;
                }

                // Define o elemento selecionado
                itemsComboBox.SelectedIndex = SelectedIndex;

                itemsComboBox.Location = new System.Drawing.Point(2, pos);

                itemsComboBox.SelectedIndexChanged += new EventHandler(itemsComboBox_SelectedIndexChanged);
                this.Controls.Add(itemsComboBox);

                pos += itemsComboBox.Height + 5;
            }
            else if (_currentQuestionType == QuestionType.SimpleQuestionAndMultipleOptionsAndComment)
            {
                //MultipleOptions mo = new MultipleOptions(this);
                mo = new MultipleOptions(this);
                mo.ItemCheckStateChanged += new EventOption(mo_ItemCheckStateChanged);
                mo.Width = this.Width - 4;
                mo.Location = new System.Drawing.Point(2, pos);
                Controls.Add(mo);
                
                pos += mo.Height + 5;
            }

            bool foundCommentButton = false;
            // Verifica se o bot�o de coment�rio j� foi carregado
            foreach (Control ctrl in this.Controls)
                if (ctrl == commentButton)
                {
                    // Identifica que o controle foi encontrado
                    foundCommentButton = true;
                    break;
                }

            // Verifica se � para mostrar o bot�o de coment�rio
            if (_visibleCommentButton)
            {
                if (!foundCommentButton)
                    this.Controls.Add(commentButton);

                commentButton.Location = new Point((this.Width - 4) - (int)(commentButton.Width * (Screen.PrimaryScreen.Bounds.Width / 240.0f)), pos);

                pos += commentButton.Height + 2;
            }
            else
            {
                if (foundCommentButton)
                    this.Controls.Remove(commentButton);
            }

            bool foundComment = false;
            // Verifica se o TextBox de coment�rio j� foi carrega
            foreach (Control ctrl in this.Controls)
                if (ctrl == comment)
                {
                    // Identifica que o controle foi encontrado
                    foundComment = true;
                    break;
                }

            // Verifica se � para mostrar o TextBox de coment�rio
            if (_visibleComment)
            {
                comment.TextChanged += new EventHandler(comment_TextChanged);
                //comment.Text = "";
                comment.Multiline = true;
                comment.ScrollBars = ScrollBars.Vertical;
                if (!foundComment)
                    this.Controls.Add(comment);

                comment.Location = new System.Drawing.Point(2, pos);
                comment.Width = questionLabel.Size.Width;
                comment.Height = Screen.PrimaryScreen.WorkingArea.Height - (pos + 30);

                pos += comment.Height + 2;
            }
            else
            {
                if (foundComment)
                    this.Controls.Remove(comment);
            }

            // Verifica se existe controles adicionais
            if (panelAdditionalsControls.Controls.Count > 0)
            {
                // Maxima altura do panel
                int maxHeight = 0;

                foreach (Control ctrl in panelAdditionalsControls.Controls)
                {
                    if (ctrl.Location.Y + ctrl.Height > maxHeight)
                        maxHeight = ctrl.Location.Y + ctrl.Height;
                }

                panelAdditionalsControls.Height = maxHeight;
                panelAdditionalsControls.Location = new Point(2, pos);

                panelAdditionalsControls.Width = this.Width;

                this.Controls.Add(panelAdditionalsControls);

                pos += maxHeight + 2;
            }

            this.Size = new System.Drawing.Size(Width, pos + 3);

            this.ResumeLayout(false);
        }

        void comment_TextChanged(object sender, EventArgs e)
        {
            _commentText = ((TextBox)sender).Text;
        }

        #endregion
    }

    /// <summary>
    /// Cole��o de perguntas.
    /// </summary>
    public class QuestionCollection : MobileTools.Controls.Collections.ObjectCollection
    {

    }

    public class ItemQuestionCollection : MobileTools.Controls.Collections.ObjectCollection, IEnumerable<ItemQuestion>
    {
        /// <summary>
        /// Adiciona uma novo item na cole��o.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="value"></param>
        public void Add(string description, object value)
        {
            base.Add(new ItemQuestion(description, value));
        }

        public ItemQuestion this[int index]
        {
            get { return base[index] as ItemQuestion; }
            set { base[index] = value; }
        }

        #region IEnumerable<ItemQuestion> Members

        public new IEnumerator<ItemQuestion> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i] as ItemQuestion;                
            }
        }

        #endregion
    }
}
