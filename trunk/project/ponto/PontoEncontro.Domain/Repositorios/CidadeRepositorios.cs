using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class CidadeRepository 
    {

       public virtual void Save(Cidade cidade)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(cidade);
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

       public virtual void Save(Cidade cidade, ISession session)
       {
           session.Save(cidade);
       }

       public virtual void Update(Cidade cidade)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(cidade);
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

       public virtual void Update(Cidade cidade, ISession session)
       {
           session.Update(cidade);
       }

       public virtual void Delete(Cidade cidade)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(cidade);
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

       public virtual void Delete(Cidade cidade, ISession session)
       {
           session.Delete(cidade);
       }


       public Cidade GetCidade(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Cidade toReturn =  session.Get(typeof(Cidade), id) as Cidade;
               session.Close();
               return toReturn;
           }
       }

       public Cidade GetCidade(object id, ISession session)
       {
           return  session.Get(typeof(Cidade), id) as Cidade;
       }


       public virtual IList<Cidade> GetCidade()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from cidade in session.Query<Cidade>()
 					  select cidade).ToList();
           }
       }

       public virtual IList<Cidade> GetCidade(ISession session)
       {
          return (from cidade in session.Query<Cidade>()
 				  select cidade).ToList();
       }


    }
}
