using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class AssociacaoRepository 
    {

       public virtual void Save(Associacao associacao)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(associacao);
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

       public virtual void Save(Associacao associacao, ISession session)
       {
           session.Save(associacao);
       }

       public virtual void Update(Associacao associacao)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(associacao);
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

       public virtual void Update(Associacao associacao, ISession session)
       {
           session.Update(associacao);
       }

       public virtual void Delete(Associacao associacao)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(associacao);
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

       public virtual void Delete(Associacao associacao, ISession session)
       {
           session.Delete(associacao);
       }


       public Associacao GetAssociacao(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Associacao toReturn =  session.Get(typeof(Associacao), id) as Associacao;
               session.Close();
               return toReturn;
           }
       }

       public Associacao GetAssociacao(object id, ISession session)
       {
           return  session.Get(typeof(Associacao), id) as Associacao;
       }


       public virtual IList<Associacao> GetAssociacao()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from associacao in session.Query<Associacao>()
 					  select associacao).ToList();
           }
       }

       public virtual IList<Associacao> GetAssociacao(ISession session)
       {
          return (from associacao in session.Query<Associacao>()
 				  select associacao).ToList();
       }


    }
}
