using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class BairroRepository 
    {

       public virtual void Save(Bairro bairro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(bairro);
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

       public virtual void Save(Bairro bairro, ISession session)
       {
           session.Save(bairro);
       }

       public virtual void Update(Bairro bairro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(bairro);
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

       public virtual void Update(Bairro bairro, ISession session)
       {
           session.Update(bairro);
       }

       public virtual void Delete(Bairro bairro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(bairro);
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

       public virtual void Delete(Bairro bairro, ISession session)
       {
           session.Delete(bairro);
       }


       public Bairro GetBairro(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Bairro toReturn =  session.Get(typeof(Bairro), id) as Bairro;
               session.Close();
               return toReturn;
           }
       }

       public Bairro GetBairro(object id, ISession session)
       {
           return  session.Get(typeof(Bairro), id) as Bairro;
       }


       public virtual IList<Bairro> GetBairro()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from bairro in session.Query<Bairro>()
 					  select bairro).ToList();
           }
       }

       public virtual IList<Bairro> GetBairro(ISession session)
       {
          return (from bairro in session.Query<Bairro>()
 				  select bairro).ToList();
       }


    }
}
