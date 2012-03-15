using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using System.Reflection;

namespace Axis.Infrastructure.MVC
{
    /// <summary>
    /// Fornece métodos que respondam às solicitações HTTP que são feitas para uma página ASP.NET MVC
    ///  Importante : Todos os controllers devem herdar desta classe
    /// </summary>
    [HandleError]
    public abstract class BaseController : Controller
    {
        public void AddMessage(string message)
        {
            IList<string> listaMessage = null;

            if(TempData["mensage"] != null)
                listaMessage = (List<string>)TempData["mensage"];
            else
                listaMessage =  new List<string>();

            listaMessage.Add(message);
            TempData["mensage"] = listaMessage;
        }

        private void RenderMessenger()
        {
            ViewBag.Message = TempData["mensage"];
        }

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
            this.RenderMessenger();
            return AutoMappedView(model, typeDestination);
        }

        /// <summary>
        /// Cria um objeto que torna System.Web.Mvc.ViewResult em vista a resposta.
        /// executa a conversão do objeto para o modelView
        /// </summary>
        /// <param name="model">objeto model do dominio</param>
        /// <returns>Objeto de visão</returns>
        public ViewResult View(object model)
        {
            this.RenderMessenger();
            return base.View(model);
        }

        /// <summary>
        /// Cria um objeto que torna System.Web.Mvc.ViewResult em vista a resposta.
        /// executa a conversão do objeto para o modelView
        /// </summary>
        /// <returns>Objeto de visão</returns>
        public ViewResult View()
        {
            this.RenderMessenger();
            return base.View();
        }

        /// <summary>
        /// Creates a System.Web.Mvc.JsonResult object that serializes the specified
        ///  object to JavaScript Object Notation (JSON).
        /// </summary>
        /// <param name="data">The JavaScript object graph to serialize.</param>
        /// <returns>
        /// The JSON result object that serializes the specified object to JSON format.
        /// The result object that is prepared by this method is written to the response
        /// by the ASP.NET MVC framework when the object is executed.
        /// </returns>
        public JsonResult Json(object data)
        {
            return base.Json(data);
        }

        #endregion
    }
}