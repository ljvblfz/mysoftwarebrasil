//
//  Copyright (c) 2009, WebAula S/A 
//  All rights reserved.
//
//  Authors: 
//               
//           * Ivan Paulovich (ivan@100loop.com)
//           Blog: http://www.100loop.com/          
//           Messenger: ivanpaulovich@hotmail.com 
//

using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using PontoEncontro.Infrastructure.Mef.Contracts;

namespace PontoEncontro.Infrastructure.Mef
{
    /// <summary>
    /// Construtor de Controladores em MEF
    /// </summary>
    public class MefControllerFactory : IControllerFactory
    {
        private CompositionContainer container;

        private DefaultControllerFactory defaultControllerFactory;

        public MefControllerFactory(CompositionContainer container)
        {
            this.container = container;
            this.defaultControllerFactory = new DefaultControllerFactory();
        }

        #region IControllerFactory Members

        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            IController controller = null;

            if (controllerName != null)
            {
                var export = this.container.GetExports<IController, IControllerMetadata>()
                                                 .Where(c => c.Metadata.Name.Equals(controllerName, StringComparison.InvariantCultureIgnoreCase))
                                                 .FirstOrDefault();
                if (export != null)
                    controller = export.Value;
            }

            if (controller == null)
                return this.defaultControllerFactory.CreateController(requestContext, controllerName);

            return controller;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }

        #endregion

        #region IControllerFactory Members


        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return System.Web.SessionState.SessionStateBehavior.Default;
        }

        #endregion
    }
}
