using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class EnderecoRepositorios 
    {

       public virtual void Save(Endereco endereco)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(endereco);
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

       public virtual void Save(Endereco endereco, ISession session)
       {
           session.Save(endereco);
       }

       public virtual void Update(Endereco endereco)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(endereco);
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

       public virtual void Update(Endereco endereco, ISession session)
       {
           session.Update(endereco);
       }

       public virtual void Delete(Endereco endereco)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(endereco);
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

       public virtual void Delete(Endereco endereco, ISession session)
       {
           session.Delete(endereco);
       }


       public Endereco GetEndereco(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Endereco toReturn =  session.Get(typeof(Endereco), id) as Endereco;
               session.Close();
               return toReturn;
           }
       }

       public Endereco GetEndereco(object id, ISession session)
       {
           return  session.Get(typeof(Endereco), id) as Endereco;
       }


       public virtual IList<Endereco> GetEndereco()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from endereco in session.Linq<Endereco>()
 					  select endereco).ToList();
           }
       }

       public virtual IList<Endereco> GetEndereco(ISession session)
       {
          return (from endereco in session.Linq<Endereco>()
 				  select endereco).ToList();
       }


    }
}
