using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class EncontromembroRepositorios 
    {

       public virtual void Save(Encontromembro encontromembro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(encontromembro);
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

       public virtual void Save(Encontromembro encontromembro, ISession session)
       {
           session.Save(encontromembro);
       }

       public virtual void Update(Encontromembro encontromembro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(encontromembro);
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

       public virtual void Update(Encontromembro encontromembro, ISession session)
       {
           session.Update(encontromembro);
       }

       public virtual void Delete(Encontromembro encontromembro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(encontromembro);
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

       public virtual void Delete(Encontromembro encontromembro, ISession session)
       {
           session.Delete(encontromembro);
       }


       public Encontromembro GetEncontromembro(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Encontromembro toReturn =  session.Get(typeof(Encontromembro), id) as Encontromembro;
               session.Close();
               return toReturn;
           }
       }

       public Encontromembro GetEncontromembro(object id, ISession session)
       {
           return  session.Get(typeof(Encontromembro), id) as Encontromembro;
       }


       public virtual IList<Encontromembro> GetEncontromembro()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from encontromembro in session.Linq<Encontromembro>()
 					  select encontromembro).ToList();
           }
       }

       public virtual IList<Encontromembro> GetEncontromembro(ISession session)
       {
          return (from encontromembro in session.Linq<Encontromembro>()
 				  select encontromembro).ToList();
       }


    }
}
