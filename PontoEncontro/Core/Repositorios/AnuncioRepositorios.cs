using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class AnuncioRepositorios 
    {

       public virtual void Save(Anuncio anuncio)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(anuncio);
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

       public virtual void Save(Anuncio anuncio, ISession session)
       {
           session.Save(anuncio);
       }

       public virtual void Update(Anuncio anuncio)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(anuncio);
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

       public virtual void Update(Anuncio anuncio, ISession session)
       {
           session.Update(anuncio);
       }

       public virtual void Delete(Anuncio anuncio)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(anuncio);
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

       public virtual void Delete(Anuncio anuncio, ISession session)
       {
           session.Delete(anuncio);
       }


       public Anuncio GetAnuncio(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Anuncio toReturn =  session.Get(typeof(Anuncio), id) as Anuncio;
               session.Close();
               return toReturn;
           }
       }

       public Anuncio GetAnuncio(object id, ISession session)
       {
           return  session.Get(typeof(Anuncio), id) as Anuncio;
       }


       public virtual IList<Anuncio> GetAnuncio()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from anuncio in session.Linq<Anuncio>()
 					  select anuncio).ToList();
           }
       }

       public virtual IList<Anuncio> GetAnuncio(ISession session)
       {
          return (from anuncio in session.Linq<Anuncio>()
 				  select anuncio).ToList();
       }


    }
}
