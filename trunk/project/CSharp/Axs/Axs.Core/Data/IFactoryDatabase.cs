using System;
using FluentNHibernate.Cfg.Db;
using Axis.Infrastructure.Enum;

namespace Axis.Infrastructure.ModelView.Data
{
    /// <summary>
    ///  Inteface de fabrica de base de dados a ser utilizado pela persistencia
    /// </summary>
    public interface IFactoryDatabase
    {
        IPersistenceConfigurer GetDatabase(DatabaseType provider);
    }
}
