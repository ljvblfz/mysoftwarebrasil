using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PontoEncontro.Infrastructure.MVC.DataAnnotations
{
    /// <summary>
    ///  Classe que implementa atributo do campo de pesquisa de formularios Ajax
    /// </summary>
    public class SearchAttribute : Attribute
    {
        /// <summary>
        ///  Desabilitar
        /// </summary>
        public bool IsDisable { get; set; }

        /// <summary>
        ///  Construtor
        /// </summary>
        public SearchAttribute()
        {
            this.IsDisable = true;
        }
    }
}
