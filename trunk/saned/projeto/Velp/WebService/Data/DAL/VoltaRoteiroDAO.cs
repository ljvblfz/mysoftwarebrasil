using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class VoltaRoteiroDAO : BaseDAO<VoltaRoteiro>
    {
        public List<VoltaRoteiro> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM volta_roteiro
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        ///  Retorna a quantidade de roteiros
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rota"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public int QuantRoteiro(int grupo, int rota, DateTime referencia)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM volta_roteiro
                            WHERE 
                                Grupo = ?grupo 
                                AND Rota = ?rota 
                                AND Referencia = ?referencia
                         ";
            return CurrentPersistenceObject.ExecuteSqlQueryCount(sql, new GDAParameter("grupo", grupo), new GDAParameter("rota", rota), new GDAParameter("referencia", referencia));
        }
    }
}
