using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    /// <summary>
    ///  Class de membro
    /// </summary>
    public class MembroRepository : GenericRepository<Membro>
    {
        /// <summary>
        ///  Construtor
        /// </summary>
        public MembroRepository()
        :base(){
        }

        /// <summary>
        ///  Cria um novo membro
        /// </summary>
        /// <param name="member">dados do membro</param>
        /// <param name="profile">perfil</param>
        /// <param name="address">endere�o</param>
        /// <param name="person">dados pessoais</param>
        public bool Register(Membro member, Perfil profile, Endereco address, Pessoa person)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(address);
                        profile.idEndereco = address.idEndereco;
                        session.Save(profile);
                        person.idPerfil = profile.idPerfil;
                        session.Save(person);
                        member.idPessoa = person.idPessoa;
                        session.Save(member);
                        transaction.Commit();
                        session.Flush();
                        session.Close();
                        return true;
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        ///  Metodo que realiza o login com o usuario
        /// </summary>
        /// <param name="NickName">login</param>
        /// <param name="Password">senha</param>
        /// <returns>true se o usuario e valido</returns>
        public bool Login(string login, string password)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var result = (
                                        from t in session.Query<Membro>()
                                        where t.loginMembro.Equals(login)
                                        where t.senhaMembro.Equals(password)
                                        select t
                                     ).ToList();
                        session.Flush();
                        session.Close();
                        return (result != null && result.Count > 0);
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        ///  Retorna o usuario pelo login
        /// </summary>
        /// <param name="NickName">login</param>
        /// <returns>usuario</returns>
        public Membro GetMemberLogin(string login)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var result = (
                                        from t in session.Query<Membro>()
                                        where t.loginMembro.Equals(login)
                                        select t
                                     ).ToList();
                        session.Flush();
                        session.Close();
                        return (result != null && result.Count > 0) ? result[0] : new Membro();
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }
    }
}