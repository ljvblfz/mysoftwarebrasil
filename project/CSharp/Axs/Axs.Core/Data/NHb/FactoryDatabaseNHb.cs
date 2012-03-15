using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg.Db;
using Axis.Infrastructure.ModelView.Data;
using Axis.Infrastructure.Enum;

namespace Axis.Infrastructure.ModelView.Data.NHb
{
    /// <summary>
    ///  Classe fabrica para conecção com varios banco para NHibernate 
    /// </summary>
    public class FactoryDatabaseNHb : IFactoryDatabase
    {
        /// <summary>
        ///  String de conexão
        /// </summary>
        private string _connectionString;

        /// <summary>
        ///  Extrair do connectioString o NameProvider
        /// </summary>
        /// <param name="connectionString">string de conexão</param>
        public FactoryDatabaseNHb(string connectionString)
        {
            this._connectionString = connectionString;
        }

        /// <summary>
        ///  Reorna o objeto de configuração correspondente ao provider
        /// </summary>
        /// <param name="provider">numero do provide</param>
        /// <returns> Objeto de configurção de banco do FluentNHibernate</returns>
        public IPersistenceConfigurer GetDatabase(DatabaseType provider)
        {
            switch (provider)
            {
                case DatabaseType.Sql:
                    return MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString);
                case DatabaseType.Oracle:
                    return OracleClientConfiguration.Oracle10.ConnectionString(_connectionString);
                case DatabaseType.MySql:
                    break;
                case DatabaseType.OleDb:
                    break;
                case DatabaseType.Oledbc:
                    break;
                default:
                    break;
            }

            return null;
        }

    }
}
