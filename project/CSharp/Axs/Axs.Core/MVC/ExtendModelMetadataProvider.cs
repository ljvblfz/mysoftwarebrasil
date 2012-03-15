using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Axis.Infrastructure.MVC
{
    /// <summary>
    ///  Classe extendida que reimplementa provedor padrão de metadados do ModelView para ASP.NET MVC.
    /// </summary>
    public class ExtendModelMetadataProvider : ModelMetadataProvider
    {
        /// <summary>
        /// Provedor padrão de metadados
        /// </summary>
        private readonly ModelMetadataProvider _innerProvider;

        /// <summary>
        ///  Construtor
        /// </summary>
        /// <param name="innerProvider">Provedor modificado com as customizações</param>
        public ExtendModelMetadataProvider(ModelMetadataProvider innerProvider)
        {
            _innerProvider = innerProvider;
        }

        /// <summary>
        ///  Obtém um objeto System.Web.Mvc.ModelMetadata para cada propriedade de um ModelView.
        /// </summary>
        /// <param name="container">O recipiente, conteudo</param>
        /// <param name="containerType">O tipo do container.</param>
        /// <returns>Um objeto System.Web.Mvc.ModelMetadata para cada propriedade de um ModelView.</returns>
        public override IEnumerable<ModelMetadata> GetMetadataForProperties(object container,Type containerType)
        {
            foreach (ModelMetadata modelMetadata in _innerProvider.GetMetadataForProperties(container,containerType))
            {
                ModelMetadata metadata = modelMetadata;
                Func<object> modelAccessor = () => metadata.Model;
                yield return new ExtendModelMetadata(this, modelAccessor, modelMetadata);
            }
        }

        /// <summary>
        /// Obtém metadados para o propriedade especificada.
        /// </summary>
        /// <param name="modelAccessor">O assessor modelo.</param>
        /// <param name="containerType">O tipo do container.</param>
        /// <param name="propertyName">A propriedade para obter o modelo de metadados para.</param>
        /// <returns>Um objeto System.Web.Mvc.ModelMetadata para a propriedade.</returns>
        public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType,string propertyName)
        {
            ModelMetadata modelMetadata = _innerProvider.GetMetadataForProperty(modelAccessor,containerType, propertyName);
            return new ExtendModelMetadata(this, modelAccessor, modelMetadata);
        }

        /// <summary>
        /// Obtém metadados para o acessador modelo especificado e tipo de modelo.
        /// </summary>
        /// <param name="modelAccessor">O assessor modelo.</param>
        /// <param name="modelType">O tipo do modelo.</param>
        /// <returns>Um objeto System.Web.Mvc.ModelMetadata para o acessador modelo</returns>
        public override ModelMetadata GetMetadataForType(Func<object> modelAccessor, Type modelType)
        {
            ModelMetadata modelMetadata = _innerProvider.GetMetadataForType(modelAccessor,modelType);
            return new ExtendModelMetadata(this, modelAccessor, modelMetadata);
        }
    }
}
