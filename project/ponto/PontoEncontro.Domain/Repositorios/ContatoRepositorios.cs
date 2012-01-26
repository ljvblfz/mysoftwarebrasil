using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class ContatoRepository 
    {

       public virtual void Save(Contato contato)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(contato);
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

       public virtual void Save(Contato contato, ISession session)
       {
           session.Save(contato);
       }

       public virtual void Update(Contato contato)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(contato);
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

       public virtual void Update(Contato contato, ISession session)
       {
           session.Update(contato);
       }

       public virtual void Delete(Contato contato)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(contato);
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

       public virtual void Delete(Contato contato, ISession session)
       {
           session.Delete(contato);
       }


       public Contato GetContato(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Contato toReturn =  session.Get(typeof(Contato), id) as Contato;
               session.Close();
               return toReturn;
           }
       }

       public Contato GetContato(object id, ISession session)
       {
           return  session.Get(typeof(Contato), id) as Contato;
       }


       public virtual IList<Contato> GetContato()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from contato in session.Query<Contato>()
 					  select contato).ToList();
           }
       }

       public virtual IList<Contato> GetContato(ISession session)
       {
          return (from contato in session.Query<Contato>()
 				  select contato).ToList();
       }


    }
}
