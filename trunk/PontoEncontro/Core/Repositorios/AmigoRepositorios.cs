using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class AmigoRepositorios 
    {

       public virtual void Save(Amigo amigo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(amigo);
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

       public virtual void Save(Amigo amigo, ISession session)
       {
           session.Save(amigo);
       }

       public virtual void Update(Amigo amigo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(amigo);
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

       public virtual void Update(Amigo amigo, ISession session)
       {
           session.Update(amigo);
       }

       public virtual void Delete(Amigo amigo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(amigo);
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

       public virtual void Delete(Amigo amigo, ISession session)
       {
           session.Delete(amigo);
       }


       public Amigo GetAmigo(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Amigo toReturn =  session.Get(typeof(Amigo), id) as Amigo;
               session.Close();
               return toReturn;
           }
       }

       public Amigo GetAmigo(object id, ISession session)
       {
           return  session.Get(typeof(Amigo), id) as Amigo;
       }


       public virtual IList<Amigo> GetAmigo()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from amigo in session.Linq<Amigo>()
 					  select amigo).ToList();
           }
       }

       public virtual IList<Amigo> GetAmigo(ISession session)
       {
          return (from amigo in session.Linq<Amigo>()
 				  select amigo).ToList();
       }


    }
}
