using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class InteresseRepository 
    {

       public virtual void Save(Interesse interesse)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(interesse);
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

       public virtual void Save(Interesse interesse, ISession session)
       {
           session.Save(interesse);
       }

       public virtual void Update(Interesse interesse)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(interesse);
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

       public virtual void Update(Interesse interesse, ISession session)
       {
           session.Update(interesse);
       }

       public virtual void Delete(Interesse interesse)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(interesse);
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

       public virtual void Delete(Interesse interesse, ISession session)
       {
           session.Delete(interesse);
       }


       public Interesse GetInteresse(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Interesse toReturn =  session.Get(typeof(Interesse), id) as Interesse;
               session.Close();
               return toReturn;
           }
       }

       public Interesse GetInteresse(object id, ISession session)
       {
           return  session.Get(typeof(Interesse), id) as Interesse;
       }


       public virtual IList<Interesse> GetInteresse()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from interesse in session.Query<Interesse>()
 					  select interesse).ToList();
           }
       }

       public virtual IList<Interesse> GetInteresse(ISession session)
       {
          return (from interesse in session.Query<Interesse>()
 				  select interesse).ToList();
       }


    }
}
