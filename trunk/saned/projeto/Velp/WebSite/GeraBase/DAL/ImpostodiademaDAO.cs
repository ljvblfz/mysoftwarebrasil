using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;
using System.Text.RegularExpressions;
using System.Globalization;


namespace GeraBase.DAL
{
    public  class ImpostoDiademaDAO : BaseDAO<ImpostoDiademaONP>
	{
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ImpostoDiademaONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_IMPOSTO_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="impostoDiadema"></param>
        public void DeleteImposto(ImpostoDiademaONP impostoDiadema)
        {
            try
            {
                GDA.Sql.Query query = new GDA.Sql.Query("cod_imposto = '" + impostoDiadema.cod_imposto + @"'");
                this.Delete(query);

            }catch(Exception ex){
            }

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="impostoDiadema"></param>
        public void UpdateImposto(ImpostoDiademaONP impostoDiadema)
        {
            try
            {
                String val_porcentagem = String.Format(impostoDiadema.val_porcentagem.ToString(), CultureInfo.CreateSpecificCulture("en-US")).Replace(',', '.');
            
                string sql = @"
                            UPDATE IDA_IMPOSTO_DIADEMA
                               SET val_porcentagem = " + val_porcentagem + @"
                             WHERE cod_imposto = '" + impostoDiadema.cod_imposto.ToString() + @"'";

                if (impostoDiadema.val_porcentagem > 0 && impostoDiadema.val_porcentagem < 101)
                {
                    int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql);
                }
            }
            catch (Exception ex){

                throw new Exception(ex.Message);
            }

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="impostoDiadema"></param>
        public void InsertImposto(ImpostoDiademaONP impostoDiadema)
        {
            impostoDiadema.val_porcentagem = Decimal.Parse(String.Format(impostoDiadema.val_porcentagem.ToString(), CultureInfo.CreateSpecificCulture("en-US")).Replace(',', '.'));
            try
            {
                if (impostoDiadema.val_porcentagem > 0 && impostoDiadema.val_porcentagem < 101)
                {
                    uint retorno = this.Insert(impostoDiadema);
                }

            }catch(Exception ex){
            }
        }
	}
}
