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
                            //.Mappings(MappingsAssembly)
                            .Mappings(x => x.FluentMappings.Add<ActionMap>())
                            .Mappings(x => x.FluentMappings.Add<AssociacaoMap>())
                            .Mappings(x => x.FluentMappings.Add<AssociadoMap>())
                            .Mappings(x => x.FluentMappings.Add<BairroMap>())
                            .Mappings(x => x.FluentMappings.Add<CabeloMap>())
                            .Mappings(x => x.FluentMappings.Add<CidadeMap>())
                            .Mappings(x => x.FluentMappings.Add<ContatoMap>())
                            .Mappings(x => x.FluentMappings.Add<ControllerMap>())
                            .Mappings(x => x.FluentMappings.Add<EnderecoMap>())
                            .Mappings(x => x.FluentMappings.Add<EstadoCivilMap>())
                            .Mappings(x => x.FluentMappings.Add<EstadoMap>())
                            .Mappings(x => x.FluentMappings.Add<EtiniaMap>())
                            .Mappings(x => x.FluentMappings.Add<FotoMap>())
                            .Mappings(x => x.FluentMappings.Add<InteresseMap>())
                            .Mappings(x => x.FluentMappings.Add<MembroMap>())
                            .Mappings(x => x.FluentMappings.Add<MenuMap>())
                            .Mappings(x => x.FluentMappings.Add<OlhoMap>())
                            .Mappings(x => x.FluentMappings.Add<PerfilMap>())
                            .Mappings(x => x.FluentMappings.Add<PermissaoRoleMap>())
                            .Mappings(x => x.FluentMappings.Add<PermissoesMap>())
                            .Mappings(x => x.FluentMappings.Add<PessoaMap>())
                            .Mappings(x => x.FluentMappings.Add<RoleMap>())
                            .Mappings(x => x.FluentMappings.Add<SexoMap>())
                            .Mappings(x => x.FluentMappings.Add<TipoAssociacaoMap>())
                            .Mappings(x => x.FluentMappings.Add<TipoContatoMap>())
                            .Mappings(x => x.FluentMappings.Add<TipoInteresseMap>())
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
