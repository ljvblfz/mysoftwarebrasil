using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PontoEncontro.Infrastructure.MVC.DataAnnotations;

namespace PontoEncontro.Infrastructure.MVC
{
    /// <summary>
    /// Classe extendiada que reimplementa a classe System.Web.Mvc.ModelMetadata esta classe
    /// fornece um contêiner para metadados comum, para o System.Web.Mvc.ModelMetadataProvider
    /// classe, e para a classe System.Web.Mvc.ModelValidator para um modelo de dados.
    /// </summary>
    public class ExtendModelMetadata : ModelMetadata
    {
        /// <summary>
        /// Classe extendida para ser utilizada para aceitar tipos complexos:
        /// Fornece um contêiner para metadados comum, para a classe System.Web.Mvc.ModelMetadataProvider
        /// , e para a classe System.Web.Mvc.ModelValidator para um modelo de dados.
        /// </summary>
        private readonly ModelMetadata _innerMetadata;

        /// <summary>
        ///  Construtor
        /// </summary>
        /// <param name="provider">O provider.</param>
        /// <param name="modelAccessor">O assessor do modelo.</param>
        /// <param name="innerMetadata">MetaData do Modelo</param>
        public ExtendModelMetadata(ExtendModelMetadataProvider provider, Func<object> modelAccessor, ModelMetadata innerMetadata)
            : base(provider, innerMetadata.ContainerType,modelAccessor, innerMetadata.ModelType,innerMetadata.PropertyName)
        {
            _innerMetadata = innerMetadata;
        }

        /// <summary>
        ///  Obtém um dicionário que contém metadados adicionais sobre o modelo.
        /// </summary>
        public override Dictionary<string, object> AdditionalValues
        {
            get { return _innerMetadata.AdditionalValues; }
        }

        /// <summary>
        ///  Obtém ou define um valor que indica se strings vazias que são postados 
        ///  de volta em formulários deverão ser convertidos para nulos.
        /// </summary>
        public override bool ConvertEmptyStringToNull
        {
            get { return _innerMetadata.ConvertEmptyStringToNull; }
            set { _innerMetadata.ConvertEmptyStringToNull = value; }
        }

        /// <summary>
        ///  Obtém ou define informações de meta sobre o tipo de dados.
        /// </summary>
        public override string DataTypeName
        {
            get { return _innerMetadata.DataTypeName; }
            set { _innerMetadata.DataTypeName = value; }
        }

        /// <summary>
        /// Obtém ou define a descrição do modelo.
        /// </summary>
        public override string Description
        {
            get { return _innerMetadata.Description; }
            set { _innerMetadata.Description = value; }
        }

        /// <summary>
        /// Obtém ou define a seqüência de formato de exibição para o modelo.
        /// </summary>
        public override string DisplayFormatString
        {
            get { return _innerMetadata.DisplayFormatString; }
            set { _innerMetadata.DisplayFormatString = value; }
        }

        /// <summary>
        /// Obtém ou define o nome para exibição do modelo.
        /// </summary>
        public override string DisplayName
        {
            get { return _innerMetadata.DisplayName; }
            set { _innerMetadata.DisplayName = value; }
        }

        /// <summary>
        /// Obtém ou define a seqüência de formato de edição do modelo.
        /// </summary>
        public override string EditFormatString
        {
            get { return _innerMetadata.EditFormatString; }
            set { _innerMetadata.EditFormatString = value; }
        }

        /// <summary>
        ///  Obtém uma lista de validadores para o modelo.
        /// </summary>
        /// <param name="context">O contexto do controlador.</param>
        /// <returns>A lista de validadores para o modelo.</returns>
        public override IEnumerable<ModelValidator> GetValidators( ControllerContext context)
        {
            return _innerMetadata.GetValidators(context);
        }

        /// <summary>
        /// Obtém ou define um valor que indica se o objeto do 
        /// modelo deve ser processado utilizando associados elementos HTML.
        /// </summary>
        public override bool HideSurroundingHtml
        {
            get { return _innerMetadata.HideSurroundingHtml; }
            set { _innerMetadata.HideSurroundingHtml = value; }
        }

        /// <summary>
        /// Obtém ou define um valor que indica se o modelo é somente leitura.
        /// </summary>
        public override bool IsReadOnly
        {
            get { return _innerMetadata.IsReadOnly; }
            set { _innerMetadata.IsReadOnly = value; }
        }

        /// <summary>
        /// Obtém ou define um valor que indica se o modelo é necessária.
        /// </summary>
        public override bool IsRequired
        {
            get { return _innerMetadata.IsRequired; }
            set { _innerMetadata.IsRequired = value; }
        }

        /// <summary>
        /// Obtém ou define a seqüência para mostrar para valores nulos.
        /// </summary>
        public override string NullDisplayText
        {
            get { return _innerMetadata.NullDisplayText; }
            set { _innerMetadata.NullDisplayText = value; }
        }

        /// <summary>
        /// Obtém ou define um nome de exibição de curta duração.
        /// </summary>
        public override string ShortDisplayName
        {
            get { return _innerMetadata.ShortDisplayName; }
            set { _innerMetadata.ShortDisplayName = value; }
        }

        /// <summary>
        /// Obtém ou define um valor que indica se a propriedade deve ser exibida 
        /// em exibições somente leitura, tais como lista e vistas de detalhe.
        /// </summary>
        public override bool ShowForDisplay
        {
            get { return _innerMetadata.ShowForDisplay; }
            set { _innerMetadata.ShowForDisplay = value; }
        }

        /// <summary>
        /// Obtém ou define um valor que indica se o modelo deve ser exibido
        ///  em vistas editável.
        /// </summary>
        public override bool ShowForEdit
        {
            get { return _innerMetadata.ShowForEdit; }
            set { _innerMetadata.ShowForEdit = value; }
        }

        /// <summary>
        /// Obtém ou define a seqüência de exibição simples para o modelo.
        /// </summary>
        public override string SimpleDisplayText
        {
            get { return _innerMetadata.SimpleDisplayText; }
            set { _innerMetadata.SimpleDisplayText = value; }
        }

        /// <summary>
        /// Obtém ou define um template a ser usado para este modelo.
        /// </summary>
        public override string TemplateHint
        {
            get { return _innerMetadata.TemplateHint; }
            set { _innerMetadata.TemplateHint = value; }
        }

        /// <summary>
        /// Obtém ou define um valor que pode ser usado como uma marca d'água
        /// Obs: Uma marca d'água normalmente aparece como texto cinza claro dentro 
        ///     de uma entrada ou elemento geral um text sempre que o elemento é vazio e não tem foco. 
        ///     Isto proporciona uma dica para o usuário quanto ao que é a entrada ou elemento 
        ///     no geral um text é utilizada, ou o tipo de entrada que é necessária.
        /// </summary>
        public override string Watermark
        {
            get { return _innerMetadata.Watermark; }
            set { _innerMetadata.Watermark = value; }
        }

        /// <summary>
        /// Obtém ou define um valor que indica se o modelo é um tipo complexo.
        /// Obs: Metodo alterado ele faz uma verificação se o tipo e um UIHint e ignora a verificação padrão
        /// </summary>
        public override bool IsComplexType
        {
            get
            {
                // Valor de retorno padrão
                bool result = _innerMetadata.IsComplexType;

                // Se o modelo especificado, e UIHint marca como tipo simples para permitir complexo
                if (!string.IsNullOrEmpty(TemplateHint))
                    result = false;

                return result;
            }
        }
    }
}
