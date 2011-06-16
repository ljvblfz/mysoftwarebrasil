using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class EncontroRepositorios 
    {

       public virtual void Save(Encontro encontro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(encontro);
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

       public virtual void Save(Encontro encontro, ISession session)
       {
           session.Save(encontro);
       }

       public virtual void Update(Encontro encontro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(encontro);
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

       public virtual void Update(Encontro encontro, ISession session)
       {
           session.Update(encontro);
       }

       public virtual void Delete(Encontro encontro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(encontro);
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

       public virtual void Delete(Encontro encontro, ISession session)
       {
           session.Delete(encontro);
       }


       public Encontro GetEncontro(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Encontro toReturn =  session.Get(typeof(Encontro), id) as Encontro;
               session.Close();
               return toReturn;
           }
       }

       public Encontro GetEncontro(object id, ISession session)
       {
           return  session.Get(typeof(Encontro), id) as Encontro;
       }


       public virtual IList<Encontro> GetEncontro()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from encontro in session.Linq<Encontro>()
 					  select encontro).ToList();
           }
       }

       public virtual IList<Encontro> GetEncontro(ISession session)
       {
          return (from encontro in session.Linq<Encontro>()
 				  select encontro).ToList();
       }


    }
}
