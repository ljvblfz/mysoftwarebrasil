using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public  class TipoEntregaDAO : BaseDAO<TipoEntregaONP>
	{
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TipoEntregaONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_TIPO_ENTREGA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objIDA_TIPO_ENTREGA"></param>
        public void DeleteTipoEntrega(TipoEntregaONP objIDA_TIPO_ENTREGA)
        {
            GDA.Sql.Query query = new GDA.Sql.Query(" seq_tipo_entrega = '" + objIDA_TIPO_ENTREGA.seq_tipo_entrega + @"'");
            this.Delete(query);

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objIDA_TIPO_ENTREGA"></param>
        public void UpdateTipoEntrega(TipoEntregaONP objIDA_TIPO_ENTREGA)
        {
            string sql = @"
                            UPDATE IDA_TIPO_ENTREGA
                               SET
                                   des_tipo_entrega = ?des_tipo_entrega
                             WHERE seq_tipo_entrega = ?seq_tipo_entrega";

            int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql,
                                                                                new GDAParameter("?des_tipo_entrega", objIDA_TIPO_ENTREGA.des_tipo_entrega),
                                                                                new GDAParameter("?seq_tipo_entrega", objIDA_TIPO_ENTREGA.seq_tipo_entrega)
                                                                            );

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objIDA_TIPO_ENTREGA"></param>
        public void InsertTipoEntrega(TipoEntregaONP objIDA_TIPO_ENTREGA)
        {
            try
            {
                this.Insert(objIDA_TIPO_ENTREGA);
            }
            catch (Exception ex)
            {
            }

            return;
        }
	}
}
