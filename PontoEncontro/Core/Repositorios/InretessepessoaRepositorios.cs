using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class InretessepessoaRepositorios 
    {

       public virtual void Save(Inretessepessoa inretessepessoa)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(inretessepessoa);
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

       public virtual void Save(Inretessepessoa inretessepessoa, ISession session)
       {
           session.Save(inretessepessoa);
       }

       public virtual void Update(Inretessepessoa inretessepessoa)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(inretessepessoa);
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

       public virtual void Update(Inretessepessoa inretessepessoa, ISession session)
       {
           session.Update(inretessepessoa);
       }

       public virtual void Delete(Inretessepessoa inretessepessoa)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(inretessepessoa);
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

       public virtual void Delete(Inretessepessoa inretessepessoa, ISession session)
       {
           session.Delete(inretessepessoa);
       }


       public Inretessepessoa GetInretessepessoa(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Inretessepessoa toReturn =  session.Get(typeof(Inretessepessoa), id) as Inretessepessoa;
               session.Close();
               return toReturn;
           }
       }

       public Inretessepessoa GetInretessepessoa(object id, ISession session)
       {
           return  session.Get(typeof(Inretessepessoa), id) as Inretessepessoa;
       }


       public virtual IList<Inretessepessoa> GetInretessepessoa()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from inretessepessoa in session.Linq<Inretessepessoa>()
 					  select inretessepessoa).ToList();
           }
       }

       public virtual IList<Inretessepessoa> GetInretessepessoa(ISession session)
       {
          return (from inretessepessoa in session.Linq<Inretessepessoa>()
 				  select inretessepessoa).ToList();
       }


    }
}
