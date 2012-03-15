using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Axis.Domain;

namespace Axis.Application.Validate
{
    /// <summary>
    ///  Validation de verificação de integridade
    /// </summary>
    public class CheckIntegrit : IValidate
    {
        /// <summary>
        ///  Messagens de erro
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return "Existe vinculo do registro em outros cadastros";
            }
        }

        /// <summary>
        ///  Indica se o objeto e valido
        ///  TRUE : valido
        ///  FALSE : não é valido
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        ///  Construtor
        /// </summary>
        public CheckIntegrit(object Entity)
        {
            var repositoryType = typeof(GenericRepository<>).MakeGenericType(Entity.GetType());
            object repo = Activator.CreateInstance(repositoryType);
            var isIntegrity = repo.GetType().GetMethod("CheckedIntegity").Invoke(repo, new object[] { Entity});

            // Se existe retrição a validação e falsa
            if ((bool)isIntegrity)
                this.IsValid = false;
        }
    }
}
