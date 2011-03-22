using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTools.CheckList
{
    public delegate void ChangeAnswer(object sender, ChangeAnswerArgs args);

    public class ChangeAnswerArgs
    {
        #region Variáveis Locais

        private bool _cancel = false;
        private ItemQuestion _newAnswer;
        private ItemQuestion _oldAnswer;

        #endregion

        #region Propriedades

        /// <summary>
        /// Cancela a modificação.
        /// </summary>
        public bool Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }

        /// <summary>
        /// Nova Resposta.
        /// </summary>
        public ItemQuestion NewAnswer
        {
            get { return _newAnswer; }
            set { _newAnswer = value; }
        }

        /// <summary>
        /// Resposta anterior.
        /// </summary>
        public ItemQuestion OldAnswer
        {
            get { return _oldAnswer; }
            set { _oldAnswer = value; }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="newAnswer"></param>
        /// <param name="oldAnswer"></param>
        internal ChangeAnswerArgs(ItemQuestion newAnswer, ItemQuestion oldAnswer)
        {
            _newAnswer = newAnswer;
            _oldAnswer = oldAnswer;
        }

        #endregion

    }
}
