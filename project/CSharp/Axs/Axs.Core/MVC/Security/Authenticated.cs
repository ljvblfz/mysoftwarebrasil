using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Axis.Infrastructure.MVC.Security
{
    /// <summary>
    ///  Filter de Autorização de rotias
    /// </summary>
    public class Authenticated : AuthorizeAttribute
    {
        /// <summary>
        ///  Usado para restringir o acesso por chamadores para um método de ação.
        /// </summary>
        /// <param name="filterContext">contentexto do MVC</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AnonymousAttribute), true)
            || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AnonymousAttribute), true) 
            || Aplication.IsAuthenticated();

            if (!skipAuthorization)
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
}
