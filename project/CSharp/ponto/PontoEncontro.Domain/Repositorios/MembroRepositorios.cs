using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace PontoEncontro.Domain
{
    public class MembroRepository : GenericRepository<Membro>
    {
        public MembroRepository()
        :base(){
        }

        public void Register(Membro member, Perfil profile, Endereco address, Pessoa person)
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
