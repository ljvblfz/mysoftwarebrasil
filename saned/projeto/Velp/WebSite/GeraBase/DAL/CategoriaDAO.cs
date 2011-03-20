using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public  class CategoriaDAO : BaseDAO<CategoriaONP>
	{

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CategoriaONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_CATEGORIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoria"></param>
        public void DeleteCategoria(CategoriaONP categoria)
        {
            try
            {
                GDA.Sql.Query query = new GDA.Sql.Query("seq_categoria = " + categoria.seq_categoria);
                this.Delete(query);
            }catch(Exception e){

            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoria"></param>
        public void UpdateCategoria(CategoriaONP categoria)
        {
            try
            {
                string des_categoria = categoria.des_categoria;
                string sql = @"
                            UPDATE IDA_CATEGORIA
                               SET 
                                   des_categoria = '" + des_categoria + @"'
                             WHERE seq_categoria = " + categoria.seq_categoria;

                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql);
            }
            catch (Exception e)
            {
            }

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoria"></param>
        public void InsertCategoria(CategoriaONP categoria)
        {
            try
            {
                this.Insert(categoria);

            }catch(Exception e){
            }
            return;
        }
	}
}
