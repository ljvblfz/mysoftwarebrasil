using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class MembroamigoRepositorios 
    {

       public virtual void Save(Membroamigo membroamigo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(membroamigo);
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

       public virtual void Save(Membroamigo membroamigo, ISession session)
       {
           session.Save(membroamigo);
       }

       public virtual void Update(Membroamigo membroamigo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(membroamigo);
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

       public virtual void Update(Membroamigo membroamigo, ISession session)
       {
           session.Update(membroamigo);
       }

       public virtual void Delete(Membroamigo membroamigo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(membroamigo);
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

       public virtual void Delete(Membroamigo membroamigo, ISession session)
       {
           session.Delete(membroamigo);
       }


       public Membroamigo GetMembroamigo(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Membroamigo toReturn =  session.Get(typeof(Membroamigo), id) as Membroamigo;
               session.Close();
               return toReturn;
           }
       }

       public Membroamigo GetMembroamigo(object id, ISession session)
       {
           return  session.Get(typeof(Membroamigo), id) as Membroamigo;
       }


       public virtual IList<Membroamigo> GetMembroamigo()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from membroamigo in session.Linq<Membroamigo>()
 					  select membroamigo).ToList();
           }
       }

       public virtual IList<Membroamigo> GetMembroamigo(ISession session)
       {
          return (from membroamigo in session.Linq<Membroamigo>()
 				  select membroamigo).ToList();
       }


    }
}
