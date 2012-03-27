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
    ///  Repositorio de cidades
    /// </summary>
    public class CidadeRepository : GenericRepository<Cidade>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public CidadeRepository()
            : base()
        {
        }

        /// <summary>
        ///  Retorna todas as cidades
        /// </summary>
        /// <param name="idState">codigo da cidade</param>
        /// <returns>as cidades pertencentes ao estado</returns>
        public IList<Cidade> GetListCity(int idState)
        {
            return Cidade.GetCidade(idState);
            //using (ISession session = this.SessionFactory.OpenSession())
            //{
            //    using (ITransaction transaction = session.BeginTransaction())
            //    {
            //        try
            //        {
            //            var result = (from c in session.Query<Cidade>()
            //                                    where c.idEstado == idState
            //                                    select c
            //                            ).ToList();
            //            session.Flush();
            //            session.Close();
            //            return result;
            //        }
            //        catch (NHibernate.HibernateException ex)
            //        {
            //            transaction.Rollback();
            //            if (ex.InnerException != null)
            //                throw new Exception(ex.InnerException.Message, ex);
            //            throw new Exception(ex.Message, ex);
            //        }
            //    }
            //}
        }

        public override IList<Cidade> ListAll()
        {
            var list = Cidade.List();
            return list;
        }
    }
}
