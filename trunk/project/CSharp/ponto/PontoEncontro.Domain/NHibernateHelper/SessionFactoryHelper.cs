using NHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg;
using PontoEncontro.Domain.Mapping;
using System.Reflection;
using System;
using System.Linq;
using System.IO;
using NHibernate.Tool.hbm2ddl;

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
            //CreateSqlCeDatabaseFile(cfg);
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
                            //.ExposeConfiguration(BuildSchema)
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

        private static void BuildSchema(Configuration cfg)
        {
            new SchemaExport(cfg)
              .Create(false, true);
        }

        private static void CreateSqlCeDatabaseFile(Configuration cfg)
        {
            var connectionString = cfg.Properties["connection.connection_string"];
            var _dataFolder = "E:/PROJETO/C#/PontoEncontro/PontoEncontro/App_Data";
            if (!string.IsNullOrEmpty(_dataFolder))
                Directory.CreateDirectory(_dataFolder);

            // We want to execute this code using Reflection, to avoid having a binary
            // dependency on SqlCe assembly

            //engine engine = new SqlCeEngine();
            //const string assemblyName = "System.Data.SqlServerCe, Version=4.0.0.1, Culture=neutral, PublicKeyToken=89845dcd8080cc91";
            const string assemblyName = "System.Data.SqlServerCe";
            const string typeName = "System.Data.SqlServerCe.SqlCeEngine";

            var sqlceEngineHandle = Activator.CreateInstance(assemblyName, typeName);
            var engine = sqlceEngineHandle.Unwrap();

            //engine.LocalConnectionString = connectionString;
            engine.GetType().GetProperty("LocalConnectionString").SetValue(engine, connectionString, null);

            //engine.CreateDatabase();
            engine.GetType().GetMethod("CreateDatabase").Invoke(engine, null);

            //engine.Dispose();
            engine.GetType().GetMethod("Dispose").Invoke(engine, null);
        }

        #endregion
	}
}
