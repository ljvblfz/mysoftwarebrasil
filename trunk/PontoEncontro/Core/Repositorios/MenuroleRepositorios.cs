using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class MenuroleRepositorios 
    {

       public virtual void Save(Menurole menurole)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(menurole);
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

       public virtual void Save(Menurole menurole, ISession session)
       {
           session.Save(menurole);
       }

       public virtual void Update(Menurole menurole)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(menurole);
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

       public virtual void Update(Menurole menurole, ISession session)
       {
           session.Update(menurole);
       }

       public virtual void Delete(Menurole menurole)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(menurole);
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

       public virtual void Delete(Menurole menurole, ISession session)
       {
           session.Delete(menurole);
       }


       public Menurole GetMenurole(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Menurole toReturn =  session.Get(typeof(Menurole), id) as Menurole;
               session.Close();
               return toReturn;
           }
       }

       public Menurole GetMenurole(object id, ISession session)
       {
           return  session.Get(typeof(Menurole), id) as Menurole;
       }


       public virtual IList<Menurole> GetMenurole()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from menurole in session.Linq<Menurole>()
 					  select menurole).ToList();
           }
       }

       public virtual IList<Menurole> GetMenurole(ISession session)
       {
          return (from menurole in session.Linq<Menurole>()
 				  select menurole).ToList();
       }


    }
}
