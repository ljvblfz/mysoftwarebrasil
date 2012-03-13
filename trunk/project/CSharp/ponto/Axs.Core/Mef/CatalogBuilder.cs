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

using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;

namespace PontoEncontro.Infrastructure.Mef
{
    /// <summary>
    /// Construtor de catálogos
    /// </summary>
    public class CatalogBuilder
    {
        private readonly IList<ComposablePartCatalog> catalogs = new List<ComposablePartCatalog>();

        public CatalogBuilder ForAssembly(Assembly assembly)
        {
            this.catalogs.Add(new AssemblyCatalog(assembly));
            return this;
        }

        public CatalogBuilder ForMvcAssembly(Assembly assembly)
        {
            this.catalogs.Add(new MvcCatalog(assembly));
            return this;
        }

        public CatalogBuilder ForMvcAssembliesInDirectory(string directory)
        {
            this.catalogs.Add(new DirectoryCatalog(directory));
            return this;
        }

        public ComposablePartCatalog Build()
        {
            return new AggregateCatalog(this.catalogs);
        }
    }
}
