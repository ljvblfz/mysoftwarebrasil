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

using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace Axis.Infrastructure.Mef.Contracts
{
    /// <summary>
    /// Constantes para metadados
    /// </summary>
    static class Constants
    {
        public const string ControllerNameMetadataName = "controller_name";
        public const string ControllerNamespaceMetadataName = "controller_ns";
        public const string ExportedTypeIdentityMetadataName = "ExportTypeIdentity";
        public static readonly string ControllerContract = AttributedModelServices.GetContractName(typeof(IController));
        public static readonly string ControllerTypeIdentity = AttributedModelServices.GetTypeIdentity(typeof(IController));
    }
}
