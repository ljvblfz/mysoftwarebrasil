using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;

namespace SPCadMobileDataWeb.Data.DAL
{
    /// <summary>
    /// Dao Genérica.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Dao<T>: BaseDAO<T> where T: new()
    {
        //Permite acessar na flow, os métodos da classe CurrentPersistenceObject.         
        public readonly PersistenceObject<T> CurrentPersistenceObject = new PersistenceObject<T>(GDA.GDASettings.DefaultProviderConfiguration);        
    }
}
