using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class RolemembroRepositorios 
    {

       public virtual void Save(Rolemembro rolemembro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(rolemembro);
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

       public virtual void Save(Rolemembro rolemembro, ISession session)
       {
           session.Save(rolemembro);
       }

       public virtual void Update(Rolemembro rolemembro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(rolemembro);
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

       public virtual void Update(Rolemembro rolemembro, ISession session)
       {
           session.Update(rolemembro);
       }

       public virtual void Delete(Rolemembro rolemembro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(rolemembro);
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

       public virtual void Delete(Rolemembro rolemembro, ISession session)
       {
           session.Delete(rolemembro);
       }


       public Rolemembro GetRolemembro(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Rolemembro toReturn =  session.Get(typeof(Rolemembro), id) as Rolemembro;
               session.Close();
               return toReturn;
           }
       }

       public Rolemembro GetRolemembro(object id, ISession session)
       {
           return  session.Get(typeof(Rolemembro), id) as Rolemembro;
       }


       public virtual IList<Rolemembro> GetRolemembro()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from rolemembro in session.Linq<Rolemembro>()
 					  select rolemembro).ToList();
           }
       }

       public virtual IList<Rolemembro> GetRolemembro(ISession session)
       {
          return (from rolemembro in session.Linq<Rolemembro>()
 				  select rolemembro).ToList();
       }


    }
}
