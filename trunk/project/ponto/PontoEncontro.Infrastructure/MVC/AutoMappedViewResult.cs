using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using Telerik.Web.Mvc;
using AutoMapper;

namespace PontoEncontro.Infrastructure.MVC
{
    /// <summary>
    ///  Classe que implementa a conversão inplicita dos modelos
    /// </summary>
    public class AutoMappedViewResult : ViewResult
    {
        /// <summary>
        ///  Tipo da model View
        /// </summary>
        private Type _viewModelType { get; set; }

        /// <summary>
        ///  Retorna a instancia do objeto modelView
        /// </summary>
        public static Func<object, Type, Type, object> Map = (source, sourceType, destinationType) =>
        {
            // Se os tipos são identicos ou e um GridModel(Telerik)
            if (sourceType == destinationType || source.GetType().GetInterfaces().Contains(typeof(IGridModel)))
                return source;

            // Se o tipo e uma Colletion utiliza o mapeamento automatico
            else if (source.GetType().GetInterfaces().Contains(typeof(IList))
                                                || source.GetType().GetInterfaces().Contains(typeof(IEnumerable)))
            {
                Mapper.CreateMap(sourceType, destinationType);
                return Mapper.Map(source, sourceType, destinationType);
            }
            else
                return Activator.CreateInstance(destinationType, source);
        };

        /// <summary>
        ///  Renderiza o objeto Convertido para o ModelView
        /// </summary>
        /// <param name="context">O contexto que o resultado é executado dentro</param>
        public override void ExecuteResult(ControllerContext context)
        {
            base.ViewData.Model = Map(ViewData.Model, ViewData.Model.GetType(), _viewModelType);
            base.ExecuteResult(context);
        }

        /// <summary>
        ///  Construtor
        /// </summary>
        /// <param name="type">tipo do modelView</param>
        public AutoMappedViewResult(Type type)
        {
            _viewModelType = type;
        }
    }
}