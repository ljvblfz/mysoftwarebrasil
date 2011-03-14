using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public  class TaxaDAO : BaseDAO<TaxaONP>
	{
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TaxaONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_TAXA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objIDA_TAXA"></param>
        public void DeleteTaxa(TaxaONP objIDA_TAXA)
        {
            try
            {
                GDA.Sql.Query query = new GDA.Sql.Query(" seq_taxa = '" + objIDA_TAXA.seq_taxa + @"'");
                this.Delete(query);
            }
            catch (Exception ex)
            {
            }

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objIDA_TAXA"></param>
        public void UpdateTaxa(TaxaONP objIDA_TAXA)
        {
            try
            {

                string sql = @"
                            UPDATE IDA_TAXA
                               SET
                                   des_taxa = ?des_taxa
                             WHERE seq_taxa = ?seq_taxa ";

                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql,
                                                                                new GDAParameter("?des_taxa", objIDA_TAXA.des_taxa),
                                                                                new GDAParameter("?seq_taxa", objIDA_TAXA.seq_taxa)
                                                                            );
            }
            catch (Exception ex)
            {

            }
            return;
        }

        public void InsertTaxa(TaxaONP objIDA_TAXA)
        {
            try
            {
                this.Insert(objIDA_TAXA);

            }catch(Exception ex){
            }
            return;
        }

	}
}
