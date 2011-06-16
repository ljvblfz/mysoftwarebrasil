using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class ComunidadeRepositorios 
    {

       public virtual void Save(Comunidade comunidade)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(comunidade);
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

       public virtual void Save(Comunidade comunidade, ISession session)
       {
           session.Save(comunidade);
       }

       public virtual void Update(Comunidade comunidade)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(comunidade);
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

       public virtual void Update(Comunidade comunidade, ISession session)
       {
           session.Update(comunidade);
       }

       public virtual void Delete(Comunidade comunidade)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(comunidade);
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

       public virtual void Delete(Comunidade comunidade, ISession session)
       {
           session.Delete(comunidade);
       }


       public Comunidade GetComunidade(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Comunidade toReturn =  session.Get(typeof(Comunidade), id) as Comunidade;
               session.Close();
               return toReturn;
           }
       }

       public Comunidade GetComunidade(object id, ISession session)
       {
           return  session.Get(typeof(Comunidade), id) as Comunidade;
       }


       public virtual IList<Comunidade> GetComunidade()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from comunidade in session.Linq<Comunidade>()
 					  select comunidade).ToList();
           }
       }

       public virtual IList<Comunidade> GetComunidade(ISession session)
       {
          return (from comunidade in session.Linq<Comunidade>()
 				  select comunidade).ToList();
       }


    }
}
