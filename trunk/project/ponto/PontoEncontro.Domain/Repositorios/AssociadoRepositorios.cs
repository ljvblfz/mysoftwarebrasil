using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class AssociadoRepository 
    {

       public virtual void Save(Associado associado)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(associado);
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

       public virtual void Save(Associado associado, ISession session)
       {
           session.Save(associado);
       }

       public virtual void Update(Associado associado)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(associado);
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

       public virtual void Update(Associado associado, ISession session)
       {
           session.Update(associado);
       }

       public virtual void Delete(Associado associado)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(associado);
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

       public virtual void Delete(Associado associado, ISession session)
       {
           session.Delete(associado);
       }


       public Associado GetAssociado(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Associado toReturn =  session.Get(typeof(Associado), id) as Associado;
               session.Close();
               return toReturn;
           }
       }

       public Associado GetAssociado(object id, ISession session)
       {
           return  session.Get(typeof(Associado), id) as Associado;
       }


       public virtual IList<Associado> GetAssociado()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from associado in session.Query<Associado>()
 					  select associado).ToList();
           }
       }

       public virtual IList<Associado> GetAssociado(ISession session)
       {
          return (from associado in session.Query<Associado>()
 				  select associado).ToList();
       }


    }
}
