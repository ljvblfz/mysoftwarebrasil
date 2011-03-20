using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public  class LocalizacaoHidrometroDAO : BaseDAO<LocalizacaoHidrometroONP>
	{
        /// <summary>
        ///  Retorna todos
        /// </summary>
        /// <returns></returns>
        public List<LocalizacaoHidrometroONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_LOCALIZACAO_HIDROMETRO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
        
        /// <summary>
        ///  Deleta 
        /// </summary>
        /// <param name="objIDA_LOCALIZACAO_HIDROMETRO"></param>
        public void DeleteHidrometro(LocalizacaoHidrometroONP objIDA_LOCALIZACAO_HIDROMETRO)
        {
            try
            {

                GDA.Sql.Query query = new GDA.Sql.Query(" seq_local = '" + objIDA_LOCALIZACAO_HIDROMETRO.seq_local + @"' ");
                this.Delete(query);
            }
            catch (Exception e)
            {

            }

            return;
        }

        /// <summary>
        /// Atualiza
        /// </summary>
        /// <param name="objIDA_LOCALIZACAO_HIDROMETRO"></param>
        public void UpdateHidrometro(LocalizacaoHidrometroONP objIDA_LOCALIZACAO_HIDROMETRO)
        {
            try
            {
                string sql = @"
                            UPDATE IDA_LOCALIZACAO_HIDROMETRO
                               SET 
                                   des_local = ?des_local
                            WHERE seq_local = ?seq_local ";

                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql, new GDAParameter("?des_local", objIDA_LOCALIZACAO_HIDROMETRO.des_local), new GDAParameter("?seq_local", objIDA_LOCALIZACAO_HIDROMETRO.seq_local));
            }
            catch (Exception e)
            {
            }
            return;
        }

        /// <summary>
        /// Insere
        /// </summary>
        /// <param name="objIDA_LOCALIZACAO_HIDROMETRO"></param>
        public void InsertHidrometro(LocalizacaoHidrometroONP objIDA_LOCALIZACAO_HIDROMETRO)
        {
            try
            {
                this.Insert(objIDA_LOCALIZACAO_HIDROMETRO);

            }
            catch(Exception e){

            }
            return;
        }

	}
}
