using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Axis.Infrastructure.MVC.DataAnnotations;
using Axis.Infrastructure.MVC.Helper.Grid;
using Axis.Infrastructure.MVC.DataAnnotations;

namespace Axis.Infrastructure.MVC
{
    /// <summary>
    ///  Classe que implementa o provedor padrão de metadados modelo para ASP.NET MVC.
    /// </summary>
    public class CustomMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        /// <summary>
        ///  Obtém os metadados para a propriedade especificada.
        /// </summary>
        /// <param name="attributes">Atributos</param>
        /// <param name="containerType">O tipo do container.</param>
        /// <param name="modelAccessor">O assessor modelo.</param>
        /// <param name="modelType">O tipo do modelo.</param>
        /// <param name="propertyName">O nome da propriedade.</param>
        /// <returns>Os metadados para a propriedade.</returns>
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            // retorna o metadata da classe base
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            // Cria um valor adicional para DropDown
            var additionalDropDown = attributes.OfType<DropDownAttribute>().FirstOrDefault();
            if (additionalDropDown != null)
            {
                metadata.AdditionalValues.Add("DropDownAttribute", additionalDropDown);
            }

            // Cria um valor adicional para campo de pesquisa Ajax
            var additionalSearch = attributes.OfType<SearchAttribute>().FirstOrDefault();
            if (additionalSearch != null)
            {
                metadata.AdditionalValues.Add("SearchAttribute", additionalSearch);
            }

            return metadata;
        }

    }
}
