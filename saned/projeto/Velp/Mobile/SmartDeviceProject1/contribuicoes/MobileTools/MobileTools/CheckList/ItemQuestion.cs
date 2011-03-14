using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTools.CheckList
{
    public class ItemQuestion
    {
        #region Variáveis Locais

        private object _value;
        private string _description;
        private long _tag;

        #endregion

        #region Propriedades

        /// <summary>
        /// Valor do item.
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Descrição do item.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Tag
        /// </summary>
        public long Tag {
            get { return _tag;}
            set { _tag = value; }
        }
        #endregion

        #region Construtores

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="value">Número do item.</param>
        /// <param name="description">Descrição.</param>
        public ItemQuestion(string description, object value)
        {
            _value = value;
            _description = description;
        }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="value">Número do item.</param>
        /// <param name="description">Descrição.</param>
        /// <param name="tag">Identificador livre</param>
        public ItemQuestion(string description, object value, long tag)
        {
            _value = value;
            _description = description;
            _tag = tag;
        }

        #endregion

        #region Métodos Públicos

        public override string ToString()
        {
            return _description;
        }

        public static bool operator == (ItemQuestion it1, ItemQuestion it2)
        {
            if (it1 == (object)null && it2 == (object)null)
                return true;
            else if ((it1 == (object)null && it2 != (object)null) || (it1 != (object)null && it2 == (object)null))
                return false;
            else
                return it1.Equals(it2);
        }

        public static bool operator != (ItemQuestion it1, ItemQuestion it2)
        {
            if (it1 == (object)null && it2 == (object)null)
                return false;
            else if ((it1 == (object)null && it2 != (object)null) || (it1 != (object)null && it2 == (object)null))
                return true;
            else
                return !it1.Equals(it2);
        }

        public override bool Equals(object obj)
        {
            if (obj is ItemQuestion)
                return ((ItemQuestion)obj).Value.Equals(this.Value);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
