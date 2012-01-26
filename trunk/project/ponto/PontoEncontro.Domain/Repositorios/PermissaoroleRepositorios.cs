using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class PermissaoroleRepository 
    {

       public virtual void Save(Permissaorole permissaorole)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(permissaorole);
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

       public virtual void Save(Permissaorole permissaorole, ISession session)
       {
           session.Save(permissaorole);
       }

       public virtual void Update(Permissaorole permissaorole)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(permissaorole);
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

       public virtual void Update(Permissaorole permissaorole, ISession session)
       {
           session.Update(permissaorole);
       }

       public virtual void Delete(Permissaorole permissaorole)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(permissaorole);
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

       public virtual void Delete(Permissaorole permissaorole, ISession session)
       {
           session.Delete(permissaorole);
       }


       public Permissaorole GetPermissaorole(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Permissaorole toReturn =  session.Get(typeof(Permissaorole), id) as Permissaorole;
               session.Close();
               return toReturn;
           }
       }

       public Permissaorole GetPermissaorole(object id, ISession session)
       {
           return  session.Get(typeof(Permissaorole), id) as Permissaorole;
       }


       public virtual IList<Permissaorole> GetPermissaorole()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from permissaorole in session.Query<Permissaorole>()
 					  select permissaorole).ToList();
           }
       }

       public virtual IList<Permissaorole> GetPermissaorole(ISession session)
       {
          return (from permissaorole in session.Query<Permissaorole>()
 				  select permissaorole).ToList();
       }


    }
}
