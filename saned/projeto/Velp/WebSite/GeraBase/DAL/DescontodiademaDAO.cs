using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;
using System.Globalization;


namespace GeraBase.DAL
{
    public  class DescontoDiademaDAO : BaseDAO<DescontoDiademaONP>
	{
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DescontoDiademaONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_DESCONTO_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desconto"></param>
        public void DeleteDesconto(DescontoDiademaONP desconto)
        {
            try
            {
                GDA.Sql.Query query = new GDA.Sql.Query("seq_desconto = " + desconto.seq_desconto);
                this.Delete(query);
            }
            catch (Exception e)
            {
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desconto"></param>
        public void UpdateDesconto(DescontoDiademaONP desconto)
        {
            
            string sql = @"
                            UPDATE IDA_DESCONTO_DIADEMA
                               SET ind_tipo_desconto = ?ind_tipo_desconto
                                  ,val_limite_inicial = ?val_limite_inicial
                                  ,val_valor_desconto = ?val_valor_desconto
                             WHERE seq_desconto = ?seq_desconto ";
            try
            {
                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql, 
                                                                            new GDAParameter("?ind_tipo_desconto", desconto.ind_tipo_desconto),
                                                                            new GDAParameter("?val_limite_inicial", desconto.val_limite_inicial),
                                                                            new GDAParameter("?val_valor_desconto", desconto.val_valor_desconto),
                                                                            new GDAParameter("?seq_desconto", desconto.seq_desconto)
                                                                            );
            }
            catch(Exception e)
            {
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desconto"></param>
        public void InsertDesconto(DescontoDiademaONP desconto)
        {
            try
            {
                this.Insert(desconto);

            }catch(Exception e)
            {

            }
            return;
        }
	}
}
