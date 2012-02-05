using NHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg;
using PontoEncontro.Domain.Mapping;
using System.Reflection;
using System;
using System.Linq;

namespace PontoEncontro.Domain
{
	public class SessionFactoryHelper
	{
		private static ISessionFactory sessionFactory;


        private SessionFactoryHelper()
		{
		}

        public static ISessionFactory GetSessionFactory()
		{
			if (sessionFactory != null)
			{
				return sessionFactory;
			}
            var cfg = new Configuration().Configure();
            var config = Fluently.Configure(cfg);
            sessionFactory = config
                            .Mappings(MappingsAssembly)
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            //.Mappings(x => x.FluentMappings.Add<ActionMap>())
                            .BuildSessionFactory();

			return sessionFactory;
		}

        #region Private Methods

        /// <summary>
        ///  Mapeia dinamicamente pela referencia do assembly
        /// </summary>
        /// <param name="config"></param>
        public static void MappingsAssembly(MappingConfiguration config)
        {
            string topNamespace = "PontoEncontro.Domain";
            Assembly assemblyNamespace = Assembly.Load(topNamespace);

            Type[] mappingList = Assembly.GetExecutingAssembly()
                                                .GetTypes()
                                                .Where(t => String.Equals(t.Namespace, topNamespace + ".Mapping", StringComparison.Ordinal)).ToArray();
            foreach (var item in mappingList)
            {
                config.FluentMappings.Add(assemblyNamespace.GetType(topNamespace + ".Mapping." + item.Name, true, true));
            }
        }

        #endregion
	}
}
