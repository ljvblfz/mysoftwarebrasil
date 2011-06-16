using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class PessoaRepositorios 
    {

       public virtual void Save(Pessoa pessoa)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(pessoa);
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

       public virtual void Save(Pessoa pessoa, ISession session)
       {
           session.Save(pessoa);
       }

       public virtual void Update(Pessoa pessoa)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(pessoa);
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

       public virtual void Update(Pessoa pessoa, ISession session)
       {
           session.Update(pessoa);
       }

       public virtual void Delete(Pessoa pessoa)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(pessoa);
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

       public virtual void Delete(Pessoa pessoa, ISession session)
       {
           session.Delete(pessoa);
       }


       public Pessoa GetPessoa(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Pessoa toReturn =  session.Get(typeof(Pessoa), id) as Pessoa;
               session.Close();
               return toReturn;
           }
       }

       public Pessoa GetPessoa(object id, ISession session)
       {
           return  session.Get(typeof(Pessoa), id) as Pessoa;
       }


       public virtual IList<Pessoa> GetPessoa()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from pessoa in session.Linq<Pessoa>()
 					  select pessoa).ToList();
           }
       }

       public virtual IList<Pessoa> GetPessoa(ISession session)
       {
          return (from pessoa in session.Linq<Pessoa>()
 				  select pessoa).ToList();
       }


    }
}
