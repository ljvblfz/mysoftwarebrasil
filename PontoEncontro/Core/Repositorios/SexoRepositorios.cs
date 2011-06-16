using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class SexoRepositorios 
    {

       public virtual void Save(Sexo sexo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(sexo);
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

       public virtual void Save(Sexo sexo, ISession session)
       {
           session.Save(sexo);
       }

       public virtual void Update(Sexo sexo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(sexo);
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

       public virtual void Update(Sexo sexo, ISession session)
       {
           session.Update(sexo);
       }

       public virtual void Delete(Sexo sexo)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(sexo);
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

       public virtual void Delete(Sexo sexo, ISession session)
       {
           session.Delete(sexo);
       }


       public Sexo GetSexo(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Sexo toReturn =  session.Get(typeof(Sexo), id) as Sexo;
               session.Close();
               return toReturn;
           }
       }

       public Sexo GetSexo(object id, ISession session)
       {
           return  session.Get(typeof(Sexo), id) as Sexo;
       }


       public virtual IList<Sexo> GetSexo()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from sexo in session.Linq<Sexo>()
 					  select sexo).ToList();
           }
       }

       public virtual IList<Sexo> GetSexo(ISession session)
       {
          return (from sexo in session.Linq<Sexo>()
 				  select sexo).ToList();
       }


    }
}
