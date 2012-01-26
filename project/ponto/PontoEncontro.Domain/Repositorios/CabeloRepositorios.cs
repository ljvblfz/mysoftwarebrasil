using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class CabeloRepository 
    {

       public virtual void Save(Cabelo cabelo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(cabelo);
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

       public virtual void Save(Cabelo cabelo, ISession session)
       {
           session.Save(cabelo);
       }

       public virtual void Update(Cabelo cabelo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(cabelo);
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

       public virtual void Update(Cabelo cabelo, ISession session)
       {
           session.Update(cabelo);
       }

       public virtual void Delete(Cabelo cabelo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(cabelo);
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

       public virtual void Delete(Cabelo cabelo, ISession session)
       {
           session.Delete(cabelo);
       }


       public Cabelo GetCabelo(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Cabelo toReturn =  session.Get(typeof(Cabelo), id) as Cabelo;
               session.Close();
               return toReturn;
           }
       }

       public Cabelo GetCabelo(object id, ISession session)
       {
           return  session.Get(typeof(Cabelo), id) as Cabelo;
       }


       public virtual IList<Cabelo> GetCabelo()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from cabelo in session.Query<Cabelo>()
 					  select cabelo).ToList();
           }
       }

       public virtual IList<Cabelo> GetCabelo(ISession session)
       {
          return (from cabelo in session.Query<Cabelo>()
 				  select cabelo).ToList();
       }


    }
}
