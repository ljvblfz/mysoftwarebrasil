using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class MenuRepositorios 
    {

       public virtual void Save(Menu menu)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(menu);
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

       public virtual void Save(Menu menu, ISession session)
       {
           session.Save(menu);
       }

       public virtual void Update(Menu menu)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(menu);
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

       public virtual void Update(Menu menu, ISession session)
       {
           session.Update(menu);
       }

       public virtual void Delete(Menu menu)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(menu);
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

       public virtual void Delete(Menu menu, ISession session)
       {
           session.Delete(menu);
       }


       public Menu GetMenu(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Menu toReturn =  session.Get(typeof(Menu), id) as Menu;
               session.Close();
               return toReturn;
           }
       }

       public Menu GetMenu(object id, ISession session)
       {
           return  session.Get(typeof(Menu), id) as Menu;
       }


       public virtual IList<Menu> GetMenu()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from menu in session.Linq<Menu>()
 					  select menu).ToList();
           }
       }

       public virtual IList<Menu> GetMenu(ISession session)
       {
          return (from menu in session.Linq<Menu>()
 				  select menu).ToList();
       }


    }
}
