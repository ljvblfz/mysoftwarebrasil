using System;
using System.Web.Mvc;
using PontoEncontro.Infrastructure;
using System.Web;
using System.Web.Security;
using System.Threading;
using System.Security.Principal;
using System.Collections.Generic;

namespace PontoEncontro.Infrastructure.MVC.Security
{
    /// <summary>
    ///  Objeto de permissão a usuarios autenticados no sistema
    /// </summary>
    public sealed class AuthorizeUserAttribute : AuthorizeAttribute 
    {
        /// <summary>
        ///  Usado para restringir o acesso por chamadores para um método de ação.
        /// </summary>
        /// <param name="filterContext">contentexto do MVC</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var ticket = Aplication.GetTicket();

            // Se a requisição é autenticada definimos o contexo para o usuário autenticado
            if (ticket != null)
            {
                // Retorna o controller e o action da requisição
                var controllerName = filterContext.Controller.GetType().Name.ToString().Replace("Controller", "");
                var actionName = filterContext.ActionDescriptor.ActionName;

                // Retorna as permissoes do usuario e verifica se possui permissão
                // as permissoes e a junção de: (Controlller.Action)
                var roles = new List<string>(ticket.UserData.Split('|'));
                var isRoler = roles.Find(x => x == (controllerName + "." + actionName));

                // Verifica a autenticação por rotina
                if (!String.IsNullOrEmpty(isRoler))
                {
                    FormsIdentity identity = new FormsIdentity(ticket);
                    GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());

                    // Define o contexto atual como sendo executado pelo GenericPrincipal
                    Thread.CurrentPrincipal = HttpContext.Current.User = HttpContext.Current.User = principal;
                }
                else
                {
                    filterContext.Controller
                        .ViewData
                        .ModelState
                        .AddModelError("", "Usuario " + ticket.Name + " não tem permissão em :" + controllerName + "." + actionName);
                }
                base.OnAuthorization(filterContext);
            }

        }//OnAuthorization

    }
}