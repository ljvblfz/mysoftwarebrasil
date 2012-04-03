using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;
using Axis.Infrastructure.Linq;
using Axis.Infrastructure;


namespace Axis.Domain
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
        /// <param name="address">endereço</param>
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

        /// <summary>
        ///  Lista membros
        /// </summary>
        /// <param name="idEstado"></param>
        /// <param name="idCidade"></param>
        /// <returns></returns>
        public Dynamic ListMember(int idEstado, int idCidade, string loginMembro, int[] age, bool lastUpdate, bool lastAccessed, int page = 0)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var result = (
                                        from m in session.Query<Membro>()
                                        join p in session.Query<Pessoa>() on m.idPessoa equals p.idPessoa
                                        join pe in session.Query<Perfil>() on p.idPerfil equals pe.idPerfil
                                        join e in session.Query<Endereco>() on pe.idEndereco equals e.idEndereco
                                        join c in session.Query<Cidade>() on e.idCidade equals c.idCidade
                                        join f in session.Query<Foto>() on m.idMembro equals f.idMembro
                                        //where
                                        //    c.idEstado == (idEstado == 0 ? c.idEstado : idEstado)
                                        //    &&
                                        //    c.idCidade == (idCidade == 0 ? c.idCidade : idCidade)
                                        //    &&
                                        //    m.loginMembro.Contains(
                                        //        (String.IsNullOrEmpty(loginMembro) ? m.loginMembro : loginMembro)
                                        //    )
                                        //    &&
                                        //    p.nascimentoPessoa.Year > (age.Count() > 1 ? age[1] :  0)
                                        //    &&
                                        //    p.nascimentoPessoa.Year < (age.Count() > 1 ? age[0] : 10000)
                                        select new { membro = m, foto = f }
                                     ).Take(10).Skip(page).ToList();
                        session.Flush();
                        session.Close();
                        return new Dynamic(result); ;
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

        public Dynamic GetMember(string loginMembro)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var result = (
                                        from m in session.Query<Membro>()
                                        join p in session.Query<Pessoa>() on m.idPessoa equals p.idPessoa
                                        join pe in session.Query<Perfil>() on p.idPerfil equals pe.idPerfil
                                        join e in session.Query<Endereco>() on pe.idEndereco equals e.idEndereco
                                        join c in session.Query<Cidade>() on e.idCidade equals c.idCidade
                                        join f in session.Query<Foto>() on m.idMembro equals f.idMembro
                                        where
                                            m.loginMembro.Contains(
                                                (String.IsNullOrEmpty(loginMembro) ? m.loginMembro : loginMembro)
                                            )

                                        select new { membro = m, foto = f }
                                     ).ToList();
                        session.Flush();
                        session.Close();
                        return new Dynamic(result); ;
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
