using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class RoleRepository  : GenericRepository<Role>
    {

       public virtual void Save(Role role)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(role);
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

       public virtual void Save(Role role, ISession session)
       {
           session.Save(role);
       }

       public virtual void Update(Role role)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(role);
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

       public virtual void Update(Role role, ISession session)
       {
           session.Update(role);
       }

       public virtual void Delete(Role role)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(role);
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

       public virtual void Delete(Role role, ISession session)
       {
           session.Delete(role);
       }


       public Role GetRole(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Role toReturn =  session.Get(typeof(Role), id) as Role;
               session.Close();
               return toReturn;
           }
       }

       public Role GetRole(object id, ISession session)
       {
           return  session.Get(typeof(Role), id) as Role;
       }


       public virtual IList<Role> GetRole()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from role in session.Query<Role>()
 					  select role).ToList();
           }
       }

       public virtual IList<Role> GetRole(ISession session)
       {
          return (from role in session.Query<Role>()
 				  select role).ToList();
       }


    }
}
