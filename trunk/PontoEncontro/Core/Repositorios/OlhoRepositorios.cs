using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class OlhoRepositorios 
    {

       public virtual void Save(Olho olho)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(olho);
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

       public virtual void Save(Olho olho, ISession session)
       {
           session.Save(olho);
       }

       public virtual void Update(Olho olho)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(olho);
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

       public virtual void Update(Olho olho, ISession session)
       {
           session.Update(olho);
       }

       public virtual void Delete(Olho olho)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(olho);
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

       public virtual void Delete(Olho olho, ISession session)
       {
           session.Delete(olho);
       }


       public Olho GetOlho(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Olho toReturn =  session.Get(typeof(Olho), id) as Olho;
               session.Close();
               return toReturn;
           }
       }

       public Olho GetOlho(object id, ISession session)
       {
           return  session.Get(typeof(Olho), id) as Olho;
       }


       public virtual IList<Olho> GetOlho()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from olho in session.Linq<Olho>()
 					  select olho).ToList();
           }
       }

       public virtual IList<Olho> GetOlho(ISession session)
       {
          return (from olho in session.Linq<Olho>()
 				  select olho).ToList();
       }


    }
}
