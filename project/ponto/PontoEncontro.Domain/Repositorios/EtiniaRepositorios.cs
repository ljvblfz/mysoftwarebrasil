using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class EtiniaRepository 
    {

       public virtual void Save(Etinia etinia)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(etinia);
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

       public virtual void Save(Etinia etinia, ISession session)
       {
           session.Save(etinia);
       }

       public virtual void Update(Etinia etinia)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(etinia);
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

       public virtual void Update(Etinia etinia, ISession session)
       {
           session.Update(etinia);
       }

       public virtual void Delete(Etinia etinia)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(etinia);
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

       public virtual void Delete(Etinia etinia, ISession session)
       {
           session.Delete(etinia);
       }


       public Etinia GetEtinia(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Etinia toReturn =  session.Get(typeof(Etinia), id) as Etinia;
               session.Close();
               return toReturn;
           }
       }

       public Etinia GetEtinia(object id, ISession session)
       {
           return  session.Get(typeof(Etinia), id) as Etinia;
       }


       public virtual IList<Etinia> GetEtinia()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from etinia in session.Query<Etinia>()
 					  select etinia).ToList();
           }
       }

       public virtual IList<Etinia> GetEtinia(ISession session)
       {
          return (from etinia in session.Query<Etinia>()
 				  select etinia).ToList();
       }


    }
}
