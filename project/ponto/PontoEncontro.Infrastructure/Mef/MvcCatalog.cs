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
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;

namespace PontoEncontro.Infrastructure.Mef
{
    /// <summary>
    /// Catálogos de Mvc
    /// </summary>
    public class MvcCatalog : ComposablePartCatalog, ICompositionElement
    {
        private readonly Type[] types;
        private readonly object locker = new object();
        private IQueryable<ComposablePartDefinition> parts;

        public MvcCatalog(params Type[] types)
        {
            this.types = types;
        }

        public MvcCatalog(Assembly assembly)
        {
            try
            {
                this.types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                this.types = typeLoadException.Types;
            }
        }

        public MvcCatalog(string dir, string pattern)
        {
            var fileSet = new List<Type>();

            foreach (var fileName in Directory.GetFiles(dir, pattern))
            {
                var assembly = Assembly.LoadFrom(fileName);
                fileSet.AddRange(assembly.GetExportedTypes());
            }

            this.types = fileSet.ToArray();
        }

        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return InternalParts; }
        }

        #region Implementation of ICompositionElement

        string ICompositionElement.DisplayName
        {
            get { return "MvcCatalog"; }
        }

        ICompositionElement ICompositionElement.Origin
        {
            get { return null; }
        }

        #endregion

        internal IQueryable<ComposablePartDefinition> InternalParts
        {
            get
            {
                if (this.parts == null)
                {
                    lock (this.locker)
                    {
                        if (this.parts == null)
                        {
                            var partsCollection = new List<ComposablePartDefinition>();

                            foreach (var type in this.types)
                            {
                                var part = AttributedModelServices.CreatePartDefinition(type, this, true);

                                if (part == null) continue;

                                if (typeof(IController).IsAssignableFrom(type))
                                {
                                    var fixedType = type;
                                    var fixedPart = part;

                                    // Forces controllers to be NonShared
                                    var newPartMetadata = new Dictionary<string, object>(part.Metadata);
                                    newPartMetadata[CompositionConstants.PartCreationPolicyMetadataName] =
                                        CreationPolicy.NonShared;

                                    part = ReflectionModelServices.CreatePartDefinition(
                                        new Lazy<Type>(() => fixedType), true,
                                        new Lazy<IEnumerable<ImportDefinition>>(() => fixedPart.ImportDefinitions),
                                        new Lazy<IEnumerable<ExportDefinition>>(() => GetControllerExports(fixedPart.ExportDefinitions, fixedType)),
                                        new Lazy<IDictionary<string, object>>(() => newPartMetadata), this);
                                }

                                partsCollection.Add(part);
                            }

                            Thread.MemoryBarrier();

                            this.parts = partsCollection.AsQueryable();
                        }
                    }
                }

                return this.parts;
            }
        }

        /// <summary>
        /// Creates a custom export for the contract IController, with additional metadata
        /// </summary>
        /// <param name="exports"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        private IEnumerable<ExportDefinition> GetControllerExports(IEnumerable<ExportDefinition> exports, Type controllerType)
        {
            var typeName = controllerType.Name;
            var controllerName = typeName.Substring(0, typeName.Length - "Controller".Length);
            var controllerNamespace = controllerType.Namespace;

            var metadata = new Dictionary<string, object>();
            metadata[Contracts.Constants.ControllerNameMetadataName] = controllerName;
            metadata[Contracts.Constants.ControllerNamespaceMetadataName] = controllerNamespace;
            metadata[Contracts.Constants.ExportedTypeIdentityMetadataName] = Contracts.Constants.ControllerTypeIdentity;

            var controllerExport = ReflectionModelServices.CreateExportDefinition(
                new LazyMemberInfo(controllerType),
                Contracts.Constants.ControllerContract,
                new Lazy<IDictionary<string, object>>(() => metadata),
                this);

            return exports.Union(new[] { controllerExport }).ToArray();
        }
    }
}
