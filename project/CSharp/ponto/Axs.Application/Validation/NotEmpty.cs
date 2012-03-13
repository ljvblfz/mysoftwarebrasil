using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PontoEncontro.Application.Validate
{
    /// <summary>
    ///  Classe de validação de vaor vazio
    /// </summary>
    public class NotEmpty : IValidate
    {
        /// <summary>
        ///  Messagem de erro
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return "Valor {0} não pode ser nulo.";
            }
        }

        /// <summary>
        ///  Indica se o objeto e valido
        ///  TRUE : valido
        ///  FALSE : não é valido
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        ///  contrutor
        /// </summary>
        public NotEmpty(object value)
        {
            this.IsValid = value != null && !String.IsNullOrEmpty(value.ToString().Trim());
        }

    }
}
