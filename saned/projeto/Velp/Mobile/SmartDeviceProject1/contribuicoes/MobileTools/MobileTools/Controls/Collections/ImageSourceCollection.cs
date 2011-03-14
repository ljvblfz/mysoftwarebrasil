using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MobileTools.Controls.Collections
{
    public class ImageSourceCollection : IList, ICollection, IEnumerable
    {
        #region Variáveis Locais

        /// <summary>
        /// Coleção onde será armazenado as fontes de imagem.
        /// </summary>
        private ArrayList _mainCollection;

        #endregion

        #region Eventos

        /// <summary>
        /// Evento acionado quando a lista é alterada.
        /// </summary>
        public event EventHandler ListChanged;

        #endregion

        #region Construtores

        internal ImageSourceCollection()
        {
            _mainCollection = new ArrayList();
        }

        #endregion

        #region Métodos Privados

        private void OnChanged()
        {
            if (ListChanged != null)
                ListChanged(this, EventArgs.Empty);
        }

        #endregion

        #region Métodos Públicos

        public int Add(IImageSource image)
        {
            OnChanged();
            return _mainCollection.Add(image);
        }

        public IImageSource this[int index]
        {
            get
            {
                return (IImageSource)_mainCollection[index];
            }
            set
            {
                OnChanged();
                _mainCollection[index] = value;
            }
        }

        #endregion

        #region IList Members

        int IList.Add(object value)
        {
            if (!(value is IImageSource))
                throw new InvalidCastException("Value is not IImageSource.");

            int result = _mainCollection.Add(value);
            OnChanged();
            return result;
        }

        public void Clear()
        {
            foreach (object obj in _mainCollection)
                ((IImageSource)obj).CloseSource();

            _mainCollection.Clear();
            OnChanged();
        }

        bool IList.Contains(object value)
        {
            if (!(value is IImageSource))
                throw new InvalidCastException("Value is not IImageSource.");

            bool result = _mainCollection.Contains(value);
            OnChanged();
            return result;
        }

        int IList.IndexOf(object value)
        {
            if (!(value is IImageSource))
                throw new InvalidCastException("Value is not IImageSource.");

            int result = _mainCollection.IndexOf(value);
            OnChanged();
            return result;
        }

        void IList.Insert(int index, object value)
        {
            if (!(value is IImageSource))
                throw new InvalidCastException("Value is not IImageSource.");

            _mainCollection.Insert(index, value);
            OnChanged();
        }

        bool IList.IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        void IList.Remove(object value)
        {
            if (!(value is IImageSource))
                throw new InvalidCastException("Value is not IImageSource.");

            _mainCollection.Remove(value);
            OnChanged();
        }

        public void RemoveAt(int index)
        {
            _mainCollection.RemoveAt(index);
            OnChanged();
        }

        object IList.this[int index]
        {
            get
            {
                return _mainCollection[index];
            }
            set
            {
                if (!(value is IImageSource))
                    throw new InvalidCastException("Value is not IImageSource.");

                _mainCollection[index] = value;
                OnChanged();
            }
        }

        #endregion

        #region ICollection Members

        void ICollection.CopyTo(Array array, int index)
        {
            if (array != null && !(array.GetType().GetElementType() is IImageSource))
                throw new InvalidCastException("Value is not IImageSource.");

            _mainCollection.CopyTo(array, index);
            OnChanged();
        }

        public int Count
        {
            get { return _mainCollection.Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        object ICollection.SyncRoot
        {
            get { return this; }
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _mainCollection.GetEnumerator();
        }

        #endregion
    }
}
