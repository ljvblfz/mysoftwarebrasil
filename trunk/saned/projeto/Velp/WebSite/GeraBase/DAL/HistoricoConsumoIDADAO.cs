using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public class HistoricoConsumoIDADAO : BaseDAO<HistoricoConsumoIDA>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<HistoricoConsumoIDA> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_HISTORICOS_CONSUMO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<HistoricoConsumoIDA> Select(string where)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_HISTORICOS_CONSUMO
                            WHERE "+where+@"
                            ORDER BY Referencia DESC";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        ///  Retorna a ultima referencia
        /// </summary>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public DateTime MaxReferencia(DateTime referencia,int CDC)
        {
            DateTime referenciaAnterior = referencia;
            string sql = @"
                            SELECT DISTINCT
                                MAX(Referencia)
				            FROM IDA_HISTORICOS_CONSUMO
                            WHERE 
                                Referencia < ?referencia
                                AND CDC = ?CDC
                            GROUP BY CDC ";
            object referenciaAnteriorAUX = CurrentPersistenceObject.ExecuteScalar(sql, new GDAParameter("?CDC", CDC), new GDAParameter("?referencia", referencia));

            if (referenciaAnteriorAUX != null)
                referenciaAnterior = DateTime.Parse(referenciaAnteriorAUX.ToString());
            return referenciaAnterior;
        }
    }
}