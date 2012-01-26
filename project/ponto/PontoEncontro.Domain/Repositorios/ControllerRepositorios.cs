using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class ControllerRepository 
    {

       public virtual void Save(Controller controller)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(controller);
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

       public virtual void Save(Controller controller, ISession session)
       {
           session.Save(controller);
       }

       public virtual void Update(Controller controller)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(controller);
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

       public virtual void Update(Controller controller, ISession session)
       {
           session.Update(controller);
       }

       public virtual void Delete(Controller controller)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(controller);
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

       public virtual void Delete(Controller controller, ISession session)
       {
           session.Delete(controller);
       }


       public Controller GetController(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Controller toReturn =  session.Get(typeof(Controller), id) as Controller;
               session.Close();
               return toReturn;
           }
       }

       public Controller GetController(object id, ISession session)
       {
           return  session.Get(typeof(Controller), id) as Controller;
       }


       public virtual IList<Controller> GetController()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from controller in session.Query<Controller>()
 					  select controller).ToList();
           }
       }

       public virtual IList<Controller> GetController(ISession session)
       {
          return (from controller in session.Query<Controller>()
 				  select controller).ToList();
       }


    }
}
