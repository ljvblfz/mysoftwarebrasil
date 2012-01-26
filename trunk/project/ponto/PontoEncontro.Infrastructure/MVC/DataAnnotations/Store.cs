using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PontoEncontro.Infrastructure.MVC.DataAnnotations
{
    /// <summary>
    ///  Classe que implementa armazenamento de valor da model
    /// </summary>
    public class StoreAttribute : Attribute
    {
        /// <summary>
        ///  Define que a propriedade aceita setar valor nulo
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        ///  Construtor
        /// </summary>
        public StoreAttribute()
        {
            this.IsNullable = false;
        }
    }
}
