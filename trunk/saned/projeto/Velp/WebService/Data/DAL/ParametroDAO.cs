using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public  class ParametroDAO : BaseDAO<ParametroONP>
	{
        public List<ParametroONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_PARAMETRO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        public void DeleteParametro(ParametroONP objIDA_PARAMETRO)
        {
            try
            {
                GDA.Sql.Query query = new GDA.Sql.Query(" des_nome = '" + objIDA_PARAMETRO.des_nome + @"'");
                this.Delete(query);

            }catch(Exception ex){
            }
            return;
        }

        public void UpdateParametro(ParametroONP objIDA_PARAMETRO)
        {
            try
            {
                string sql = @"
                            UPDATE IDA_PARAMETRO
                               SET
                                   des_valor = '" + objIDA_PARAMETRO.des_valor + @"'
                             WHERE des_nome = '" + objIDA_PARAMETRO.des_nome + @"'";

                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql);
            }
            catch (Exception ex)
            {

            }
            return;
        }

        public void InsertParametro(ParametroONP objIDA_PARAMETRO)
        {
            try
            {
                this.Insert(objIDA_PARAMETRO);
            }
            catch (Exception ex)
            {
            }
            return;
        }
	}
}
