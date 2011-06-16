using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class MembrofavoritoRepositorios 
    {

       public virtual void Save(Membrofavorito membrofavorito)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(membrofavorito);
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

       public virtual void Save(Membrofavorito membrofavorito, ISession session)
       {
           session.Save(membrofavorito);
       }

       public virtual void Update(Membrofavorito membrofavorito)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(membrofavorito);
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

       public virtual void Update(Membrofavorito membrofavorito, ISession session)
       {
           session.Update(membrofavorito);
       }

       public virtual void Delete(Membrofavorito membrofavorito)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(membrofavorito);
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

       public virtual void Delete(Membrofavorito membrofavorito, ISession session)
       {
           session.Delete(membrofavorito);
       }


       public Membrofavorito GetMembrofavorito(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Membrofavorito toReturn =  session.Get(typeof(Membrofavorito), id) as Membrofavorito;
               session.Close();
               return toReturn;
           }
       }

       public Membrofavorito GetMembrofavorito(object id, ISession session)
       {
           return  session.Get(typeof(Membrofavorito), id) as Membrofavorito;
       }


       public virtual IList<Membrofavorito> GetMembrofavorito()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from membrofavorito in session.Linq<Membrofavorito>()
 					  select membrofavorito).ToList();
           }
       }

       public virtual IList<Membrofavorito> GetMembrofavorito(ISession session)
       {
          return (from membrofavorito in session.Linq<Membrofavorito>()
 				  select membrofavorito).ToList();
       }


    }
}
