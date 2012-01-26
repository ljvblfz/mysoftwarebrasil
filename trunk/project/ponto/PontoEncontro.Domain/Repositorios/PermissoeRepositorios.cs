using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class PermissoeRepository 
    {

       public virtual void Save(Permissoe permissoe)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(permissoe);
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

       public virtual void Save(Permissoe permissoe, ISession session)
       {
           session.Save(permissoe);
       }

       public virtual void Update(Permissoe permissoe)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(permissoe);
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

       public virtual void Update(Permissoe permissoe, ISession session)
       {
           session.Update(permissoe);
       }

       public virtual void Delete(Permissoe permissoe)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(permissoe);
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

       public virtual void Delete(Permissoe permissoe, ISession session)
       {
           session.Delete(permissoe);
       }


       public Permissoe GetPermissoe(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Permissoe toReturn =  session.Get(typeof(Permissoe), id) as Permissoe;
               session.Close();
               return toReturn;
           }
       }

       public Permissoe GetPermissoe(object id, ISession session)
       {
           return  session.Get(typeof(Permissoe), id) as Permissoe;
       }


       public virtual IList<Permissoe> GetPermissoe()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from permissoe in session.Query<Permissoe>()
 					  select permissoe).ToList();
           }
       }

       public virtual IList<Permissoe> GetPermissoe(ISession session)
       {
          return (from permissoe in session.Query<Permissoe>()
 				  select permissoe).ToList();
       }


    }
}
