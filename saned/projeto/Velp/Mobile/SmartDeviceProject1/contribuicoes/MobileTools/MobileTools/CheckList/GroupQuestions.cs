using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

namespace MobileTools.CheckList
{
    [DesignerCategory("Component")]
    public class GroupQuestions : Panel
    {
        #region Vari�veis Locais

        private QuestionCollection _questions = new QuestionCollection();
        private List<int> positions = new List<int>();

        #endregion

        #region Propriedades

        /// <summary>
        /// Lista dos itens do checklist.
        /// </summary>
        public QuestionCollection Questions
        {
            get
            {
                return _questions;
            }
        }

        new public Control Controls
        {
            get { throw new InvalidOperationException("Property Controls not more use."); }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor
        /// </summary>
        public GroupQuestions()
        {
            this.AutoScroll = true;
        }

        #endregion

        #region M�todos P�blicos

        /// <summary>
        /// Constro� o itens no grupo.
        /// </summary>
        public void BuildItems()
        {
            int pos = 0;

            // Remove todos os controles do grupo
            DestroyItensCheckList();

            // Pecorre os itens do grupo
            foreach (Question ctrl in _questions)
            {
                // Define a posi��o do controle
                ctrl.Location = new Point(0, pos);
                positions.Add(pos);
                ctrl.Width = Width - 22;
                pos += ctrl.Height;
                base.Controls.Add(ctrl);
            }
        }

        /// <summary>
        /// Destro� o itens.
        /// </summary>
        public void DestroyItensCheckList()
        {
            foreach (Control c in base.Controls)
                c.Dispose();

            positions.Clear();
            base.Controls.Clear();
        }

        /// <summary>
        /// Posiciona o pr�ximo item do grupo.
        /// </summary>
        public void MoveNext()
        {
            // Recupera a posia��o do pr�ximo item
            int pos = GetIndexCurrentQuestionPosition() + 1;

            // Verifica se n�o o ultimo item
            if (pos < _questions.Count - 1)
                AutoScrollPosition = new Point(0, positions[pos]);

        }

        /// <summary>
        /// Posiciona o grupo no item anterior.
        /// </summary>
        public void MovePrevious()
        {
            // Recupera a posi��o do item anterior
            int pos = GetIndexCurrentQuestionPosition() - 1;

            // Verifica se existe item anterior
            if (pos >= 0)
                AutoScrollPosition = new Point(0, positions[pos]);
        }

        /// <summary>
        /// Move para o ultimo item do grupo.
        /// </summary>
        public void MoveLast()
        {
            if (_questions.Count > 0)
                AutoScrollPosition = new Point(0, positions[_questions.Count - 1]);
        }

        /// <summary>
        /// Move para o primeiro item do grupo.
        /// </summary>
        public void MoveFirst()
        {
            if (_questions.Count > 0)
            {
                AutoScrollPosition = new Point(0, positions[0]);
            }
        }

        #endregion

        #region M�todos Privados

        /// <summary>
        /// Recupera a posia��o do atual item no grupo.
        /// </summary>
        /// <returns></returns>
        private int GetIndexCurrentQuestionPosition()
        {
            int y = Math.Abs(AutoScrollPosition.Y);

            for (int i = 0; i < positions.Count; i++)
                if (positions[i] > y)
                    return (i > 0 ? i - 1 : 0);

            return 0;
        }

        #endregion

        #region Classes P�blicas Internas

        public class QuestionCollection : MobileTools.Controls.Collections.ObjectCollection
        {

        }

        #endregion

    }
}
