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
            IList<T> list = new List<T>();
            T[] collection = ActiveRecordBase<T>.FindAll();
            foreach (var item in collection)
            {
                //list.Add(Convert(item, 0));
            }
            return list;
        }
    }
}
