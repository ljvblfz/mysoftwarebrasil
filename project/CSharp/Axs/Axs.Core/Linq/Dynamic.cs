using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Collections;

namespace Axis.Infrastructure.Linq
{
    /// <summary>
    ///  Classe responsavel por armazenar anomimamente 
    ///  objetos em uma lista acessivel pelo type
    /// </summary>
    public class Dynamic
    {
        /// <summary>
        ///  Lista de objetos
        /// </summary>
        public IList ListObjects { get; private set; }

        /// <summary>
        ///  Construtor
        /// </summary>
        /// <param name="objects">objetos</param>
        public Dynamic(IList objects)
        {
            this.ListObjects = new ArrayList();
            foreach (var objectItem in objects)
            {
                var value = (from p in objectItem.GetType().GetProperties()
                        select p.GetValue(objectItem,null)
                        ).ToDictionary(x => x.GetType());
                this.ListObjects.Add(value);
            }
        }
    }
}
