using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class EstadoRepository 
    {

       public virtual void Save(Estado estado)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(estado);
                       transaction.Commit();
                       session.Flush();
                       session.Close();
                   }
                   catch (NHibernate.HibernateException)
                   {
                       transaction.Rollback();
                   }
               }
           }
       }

       public virtual void Save(Estado estado, ISession session)
       {
           session.Save(estado);
       }

       public virtual void Update(Estado estado)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(estado);
                       transaction.Commit();
                       session.Flush();
                       session.Close();
                   }
                   catch (NHibernate.HibernateException)
                   {
                       transaction.Rollback();
                   }
               }
           }
       }

       public virtual void Update(Estado estado, ISession session)
       {
           session.Update(estado);
       }

       public virtual void Delete(Estado estado)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(estado);
                       transaction.Commit();
                       session.Flush();
                       session.Close();
                   }
                   catch (NHibernate.HibernateException)
                   {
                       transaction.Rollback();
                   }
               }
           }
       }

       public virtual void Delete(Estado estado, ISession session)
       {
           session.Delete(estado);
       }


       public Estado GetEstado(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Estado toReturn =  session.Get(typeof(Estado), id) as Estado;
               session.Close();
               return toReturn;
           }
       }

       public Estado GetEstado(object id, ISession session)
       {
           return  session.Get(typeof(Estado), id) as Estado;
       }


       public virtual IList<Estado> GetEstado()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from estado in session.Query<Estado>()
 					  select estado).ToList();
           }
       }

       public virtual IList<Estado> GetEstado(ISession session)
       {
          return (from estado in session.Query<Estado>()
 				  select estado).ToList();
       }


    }
}
