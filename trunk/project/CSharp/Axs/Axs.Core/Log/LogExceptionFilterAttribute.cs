using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net.Config;
using log4net;
using System.Reflection;

namespace Axis.Infrastructure.Log
{
    /// <summary>
    ///  Classe que imoplementa os logs de erro
    /// </summary>
    public class LogExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        private ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                log.Error("Error in Controller", filterContext.Exception);
            }
        }
    }
}