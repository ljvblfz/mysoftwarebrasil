using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Axis.Domain
{
    /// <summary>
    ///  Repositorio de foto
    /// </summary>
    public class FotoRepository : GenericRepository<Foto>
    {
        /// <summary>
        ///  Retorna os dados da foto
        /// </summary>
        /// <param name="nameFoto">nome da foto</param>
        /// <returns>foto</returns>
        public Foto GetFoto(string nameFoto)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var result = (from t in session.Query<Foto>()
                                      where t.nameFoto == nameFoto
                                      select t).First<Foto>();
                        session.Flush();
                        session.Close();
                        return result;
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

        public IList<Foto> ListFoto(int idMembro)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var result = (from f in session.Query<Foto>()
                                      where f.idMembro == idMembro
                                      select f).ToList<Foto>();
                        session.Flush();
                        session.Close();
                        return result;
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
