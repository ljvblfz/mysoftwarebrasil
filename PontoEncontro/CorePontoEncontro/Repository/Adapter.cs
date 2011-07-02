using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace CorePontoEncontro.Repository
{
    public class Adapter<T>
    {
        public static IList<T> ListAll()
        {
            T[] collection = ActiveRecordBase<T>.FindAll();
            IList<T> list = new List<T>(collection);
             return list;
        }
    }
}
