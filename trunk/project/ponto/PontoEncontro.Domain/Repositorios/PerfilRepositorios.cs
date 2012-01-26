using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class PerfilRepository 
    {

       public virtual void Save(Perfil perfil)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(perfil);
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

       public virtual void Save(Perfil perfil, ISession session)
       {
           session.Save(perfil);
       }

       public virtual void Update(Perfil perfil)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(perfil);
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

       public virtual void Update(Perfil perfil, ISession session)
       {
           session.Update(perfil);
       }

       public virtual void Delete(Perfil perfil)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(perfil);
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

       public virtual void Delete(Perfil perfil, ISession session)
       {
           session.Delete(perfil);
       }


       public Perfil GetPerfil(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Perfil toReturn =  session.Get(typeof(Perfil), id) as Perfil;
               session.Close();
               return toReturn;
           }
       }

       public Perfil GetPerfil(object id, ISession session)
       {
           return  session.Get(typeof(Perfil), id) as Perfil;
       }


       public virtual IList<Perfil> GetPerfil()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from perfil in session.Query<Perfil>()
 					  select perfil).ToList();
           }
       }

       public virtual IList<Perfil> GetPerfil(ISession session)
       {
          return (from perfil in session.Query<Perfil>()
 				  select perfil).ToList();
       }


    }
}
