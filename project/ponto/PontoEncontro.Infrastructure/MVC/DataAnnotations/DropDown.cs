using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PontoEncontro.Infrastructure.MVC.DataAnnotations
{
    /// <summary>
    ///  Classe de Atributo personalizado do ModcelView do DropDown
    /// </summary>
    public class DropDownAttribute : Attribute
    {
        /// <summary>
        ///  Nome da propriedade a ser carregada no HTML 
        /// </summary>
        public String NameProperty { get; set; }

        /// <summary>
        ///  Nome do template a ser usado 
        ///  template e uma view default que utilizada em varios locais
        /// </summary>
        public String TemplateName { get; set; }

        /// <summary>
        ///  Construtor da classe
        /// </summary>
        public DropDownAttribute()
        {
            // Template padrão da aplicação
            this.TemplateName = "DropDown";
        }
    }
}
