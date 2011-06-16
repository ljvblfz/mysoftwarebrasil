using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Core
{
    public class PostRepositorios 
    {

       public virtual void Save(Post post)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Save(post);
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

       public virtual void Save(Post post, ISession session)
       {
           session.Save(post);
       }

       public virtual void Update(Post post)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Update(post);
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

       public virtual void Update(Post post, ISession session)
       {
           session.Update(post);
       }

       public virtual void Delete(Post post)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               using (ITransaction transaction = session.BeginTransaction())
               {
                   try
                   {
                       session.Delete(post);
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

       public virtual void Delete(Post post, ISession session)
       {
           session.Delete(post);
       }


       public Post GetPost(object id)
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               Post toReturn =  session.Get(typeof(Post), id) as Post;
               session.Close();
               return toReturn;
           }
       }

       public Post GetPost(object id, ISession session)
       {
           return  session.Get(typeof(Post), id) as Post;
       }


       public virtual IList<Post> GetPost()
       {
           using (ISession session = NHibernateHelper.OpenSession())
           {
               return (from post in session.Linq<Post>()
 					  select post).ToList();
           }
       }

       public virtual IList<Post> GetPost(ISession session)
       {
          return (from post in session.Linq<Post>()
 				  select post).ToList();
       }


    }
}
