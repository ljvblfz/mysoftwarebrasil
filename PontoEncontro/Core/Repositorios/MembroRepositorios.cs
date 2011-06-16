using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class MembroRepositorios 
    {

       public virtual void Save(Membro membro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(membro);
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

       public virtual void Save(Membro membro, ISession session)
       {
           session.Save(membro);
       }

       public virtual void Update(Membro membro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(membro);
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

       public virtual void Update(Membro membro, ISession session)
       {
           session.Update(membro);
       }

       public virtual void Delete(Membro membro)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(membro);
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

       public virtual void Delete(Membro membro, ISession session)
       {
           session.Delete(membro);
       }


       public Membro GetMembro(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Membro toReturn =  session.Get(typeof(Membro), id) as Membro;
               session.Close();
               return toReturn;
           }
       }

       public Membro GetMembro(object id, ISession session)
       {
           return  session.Get(typeof(Membro), id) as Membro;
       }


       public virtual IList<Membro> GetMembro()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from membro in session.Linq<Membro>()
 					  select membro).ToList();
           }
       }

       public virtual IList<Membro> GetMembro(ISession session)
       {
          return (from membro in session.Linq<Membro>()
 				  select membro).ToList();
       }


    }
}
