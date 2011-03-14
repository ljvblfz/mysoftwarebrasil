using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace MobileTools.Controls.Collections
{
    /// <summary>
    /// Coleção de objetos generica.
    /// </summary>
    public class ObjectCollection : IList, ICollection, IEnumerable
    {
        // Fields
        internal ArrayList _mainCollection;

        // Methods
        internal ObjectCollection()
        {
            this._mainCollection = new ArrayList();
        }

        public int Add(object obj)
        {
            this._mainCollection.Add(obj);
            return (this._mainCollection.Count - 1);
        }

        internal void AddRangeInternal(ICollection colItems)
        {
            this._mainCollection.AddRange(colItems);
            
        }

        public virtual void Clear()
        {
            _mainCollection.Clear();
        }

        internal void ClearInternal()
        {
            this._mainCollection.Clear();
        }

        public bool Contains(object obj)
        {
            return this._mainCollection.Contains(obj);
        }

        public IEnumerator GetEnumerator()
        {
            return this._mainCollection.GetEnumerator();
        }

        public int IndexOf(object obj)
        {
            return this._mainCollection.IndexOf(obj);
        }

        public void Insert(int index, object obj)
        {
      
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            this._mainCollection.Insert(index, obj);
      
        }

        public void Remove(object obj)
        {
            this.RemoveAt(this._mainCollection.IndexOf(obj));
        }

        public void RemoveAt(int index)
        {
            this._mainCollection.RemoveAt(index);
        }

        void ICollection.CopyTo(Array array, int index)
        {
            this._mainCollection.CopyTo(array, index);
        }

        // Properties
        public int Count
        {
            get
            {
                return this._mainCollection.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual object this[int index]
        {
            get
            {
                return this._mainCollection[index];
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this._mainCollection[index] = value;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }
    }


}
