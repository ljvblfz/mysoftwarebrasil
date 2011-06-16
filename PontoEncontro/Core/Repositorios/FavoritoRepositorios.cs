using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class FavoritoRepositorios 
    {

       public virtual void Save(Favorito favorito)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(favorito);
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

       public virtual void Save(Favorito favorito, ISession session)
       {
           session.Save(favorito);
       }

       public virtual void Update(Favorito favorito)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(favorito);
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

       public virtual void Update(Favorito favorito, ISession session)
       {
           session.Update(favorito);
       }

       public virtual void Delete(Favorito favorito)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(favorito);
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

       public virtual void Delete(Favorito favorito, ISession session)
       {
           session.Delete(favorito);
       }


       public Favorito GetFavorito(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Favorito toReturn =  session.Get(typeof(Favorito), id) as Favorito;
               session.Close();
               return toReturn;
           }
       }

       public Favorito GetFavorito(object id, ISession session)
       {
           return  session.Get(typeof(Favorito), id) as Favorito;
       }


       public virtual IList<Favorito> GetFavorito()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from favorito in session.Linq<Favorito>()
 					  select favorito).ToList();
           }
       }

       public virtual IList<Favorito> GetFavorito(ISession session)
       {
          return (from favorito in session.Linq<Favorito>()
 				  select favorito).ToList();
       }


    }
}
