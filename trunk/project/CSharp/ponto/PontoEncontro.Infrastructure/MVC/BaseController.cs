using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using System.Reflection;

namespace PontoEncontro.Infrastructure.MVC
{
    /// <summary>
    /// Fornece métodos que respondam às solicitações HTTP que são feitas para uma página ASP.NET MVC
    ///  Importante : Todos os controllers devem herdar desta classe
    /// </summary>
    [HandleError]
    public abstract class BaseController : Controller
    {

        #region Metodos privados

        /// <summary>
        ///  Metodo responsavel pela rederização do objeto POCO
        ///  na tela criada pelo ModelView
        /// </summary>
        /// <typeparam name="TModel">modelo da view</typeparam>
        /// <param name="Model">modelo POCO</param>
        /// <returns>modelo convertido e renderizado</returns>
        private AutoMappedViewResult AutoMappedView(object model,Type modelView)
        {
            // Objeto de dados para a visão
            //  Obs: objeto e informado como POCO mas será convetido
            ViewData.Model = model;

            return new AutoMappedViewResult(modelView)
            {
                ViewData = ViewData,
                TempData = TempData
            };
        }

        #endregion

        #region Metodos Sobreescritos

        /// <summary>
        /// Cria um objeto que torna System.Web.Mvc.ViewResult em vista a resposta.
        /// executa a conversão do objeto para o modelView
        /// </summary>
        /// <param name="model">objeto model do dominio</param>
        /// <param name="typeDestination">type de destino</param>
        /// <returns>Objeto de visão</returns>
        public ViewResult View(object model, Type typeDestination)
        {
            return AutoMappedView(model, typeDestination);
        }

        #endregion
    }
}