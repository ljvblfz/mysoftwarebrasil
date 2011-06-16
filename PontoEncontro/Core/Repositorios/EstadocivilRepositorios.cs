using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class EstadocivilRepositorios 
    {

       public virtual void Save(Estadocivil estadocivil)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(estadocivil);
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

       public virtual void Save(Estadocivil estadocivil, ISession session)
       {
           session.Save(estadocivil);
       }

       public virtual void Update(Estadocivil estadocivil)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(estadocivil);
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

       public virtual void Update(Estadocivil estadocivil, ISession session)
       {
           session.Update(estadocivil);
       }

       public virtual void Delete(Estadocivil estadocivil)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(estadocivil);
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

       public virtual void Delete(Estadocivil estadocivil, ISession session)
       {
           session.Delete(estadocivil);
       }


       public Estadocivil GetEstadocivil(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Estadocivil toReturn =  session.Get(typeof(Estadocivil), id) as Estadocivil;
               session.Close();
               return toReturn;
           }
       }

       public Estadocivil GetEstadocivil(object id, ISession session)
       {
           return  session.Get(typeof(Estadocivil), id) as Estadocivil;
       }


       public virtual IList<Estadocivil> GetEstadocivil()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from estadocivil in session.Linq<Estadocivil>()
 					  select estadocivil).ToList();
           }
       }

       public virtual IList<Estadocivil> GetEstadocivil(ISession session)
       {
          return (from estadocivil in session.Linq<Estadocivil>()
 				  select estadocivil).ToList();
       }


    }
}
