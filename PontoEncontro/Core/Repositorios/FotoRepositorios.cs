using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class FotoRepositorios 
    {

       public virtual void Save(Foto foto)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(foto);
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

       public virtual void Save(Foto foto, ISession session)
       {
           session.Save(foto);
       }

       public virtual void Update(Foto foto)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(foto);
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

       public virtual void Update(Foto foto, ISession session)
       {
           session.Update(foto);
       }

       public virtual void Delete(Foto foto)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(foto);
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

       public virtual void Delete(Foto foto, ISession session)
       {
           session.Delete(foto);
       }


       public Foto GetFoto(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Foto toReturn =  session.Get(typeof(Foto), id) as Foto;
               session.Close();
               return toReturn;
           }
       }

       public Foto GetFoto(object id, ISession session)
       {
           return  session.Get(typeof(Foto), id) as Foto;
       }


       public virtual IList<Foto> GetFoto()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from foto in session.Linq<Foto>()
 					  select foto).ToList();
           }
       }

       public virtual IList<Foto> GetFoto(ISession session)
       {
          return (from foto in session.Linq<Foto>()
 				  select foto).ToList();
       }


    }
}
