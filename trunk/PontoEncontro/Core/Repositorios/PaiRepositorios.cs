using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class PaiRepositorios 
    {

       public virtual void Save(Pai pai)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(pai);
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

       public virtual void Save(Pai pai, ISession session)
       {
           session.Save(pai);
       }

       public virtual void Update(Pai pai)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(pai);
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

       public virtual void Update(Pai pai, ISession session)
       {
           session.Update(pai);
       }

       public virtual void Delete(Pai pai)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(pai);
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

       public virtual void Delete(Pai pai, ISession session)
       {
           session.Delete(pai);
       }


       public Pai GetPai(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Pai toReturn =  session.Get(typeof(Pai), id) as Pai;
               session.Close();
               return toReturn;
           }
       }

       public Pai GetPai(object id, ISession session)
       {
           return  session.Get(typeof(Pai), id) as Pai;
       }


       public virtual IList<Pai> GetPai()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from pai in session.Linq<Pai>()
 					  select pai).ToList();
           }
       }

       public virtual IList<Pai> GetPai(ISession session)
       {
          return (from pai in session.Linq<Pai>()
 				  select pai).ToList();
       }


    }
}
