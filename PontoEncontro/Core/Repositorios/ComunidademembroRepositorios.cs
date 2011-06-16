using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class ComunidademembroRepositorios 
    {

       public virtual void Save(Comunidademembro comunidademembro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(comunidademembro);
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

       public virtual void Save(Comunidademembro comunidademembro, ISession session)
       {
           session.Save(comunidademembro);
       }

       public virtual void Update(Comunidademembro comunidademembro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(comunidademembro);
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

       public virtual void Update(Comunidademembro comunidademembro, ISession session)
       {
           session.Update(comunidademembro);
       }

       public virtual void Delete(Comunidademembro comunidademembro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(comunidademembro);
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

       public virtual void Delete(Comunidademembro comunidademembro, ISession session)
       {
           session.Delete(comunidademembro);
       }


       public Comunidademembro GetComunidademembro(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Comunidademembro toReturn =  session.Get(typeof(Comunidademembro), id) as Comunidademembro;
               session.Close();
               return toReturn;
           }
       }

       public Comunidademembro GetComunidademembro(object id, ISession session)
       {
           return  session.Get(typeof(Comunidademembro), id) as Comunidademembro;
       }


       public virtual IList<Comunidademembro> GetComunidademembro()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from comunidademembro in session.Linq<Comunidademembro>()
 					  select comunidademembro).ToList();
           }
       }

       public virtual IList<Comunidademembro> GetComunidademembro(ISession session)
       {
          return (from comunidademembro in session.Linq<Comunidademembro>()
 				  select comunidademembro).ToList();
       }


    }
}
