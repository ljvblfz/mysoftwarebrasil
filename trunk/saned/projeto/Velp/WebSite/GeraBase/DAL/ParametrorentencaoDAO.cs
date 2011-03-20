using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;
using System.Globalization;

namespace GeraBase.DAL
{
    public  class ParametroRentencaoDAO : BaseDAO<ParametroRentencaoONP>
	{

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ParametroRentencaoONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_PARAMETRO_RETENCAO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objIDA_PARAMETRO_RETENCAO"></param>
        public void DeleteParametroRetencao(ParametroRentencaoONP objIDA_PARAMETRO_RETENCAO)
        {
            try
            {
                string sql = @"DELETE FROM IDA_PARAMETRO_RETENCAO WHERE ind_retencao = '" + objIDA_PARAMETRO_RETENCAO.ind_retencao.ToString() + @"' AND seq_faixa = " + objIDA_PARAMETRO_RETENCAO.seq_faixa.ToString();
                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql);
            }
            catch (Exception ex)
            {
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objIDA_PARAMETRO_RETENCAO"></param>
        public void UpdateParametroRetencao(ParametroRentencaoONP objIDA_PARAMETRO_RETENCAO)
        {
            try
            {
                string sql = @"
                            UPDATE IDA_PARAMETRO_RETENCAO
                               SET
                                    seq_faixa = ?seq_faixa , 
                                    val_media_inicial = ?val_media_inicial , 
                                    val_media_final = ?val_media_final, 
                                    val_variacao_aviso = ?val_variacao_aviso, 
                                    val_variacao_retencao = ?val_variacao_retencao , 
                                    ind_unidade_variacao = ?ind_unidade_variacao
                             WHERE  ind_retencao = ?ind_retencao ";

                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql,
                                                                                new GDAParameter("?seq_faixa", objIDA_PARAMETRO_RETENCAO.seq_faixa),
                                                                                new GDAParameter("?val_media_inicial", objIDA_PARAMETRO_RETENCAO.val_media_inicial),
                                                                                new GDAParameter("?val_media_final", objIDA_PARAMETRO_RETENCAO.val_media_final),
                                                                                new GDAParameter("?val_variacao_aviso", objIDA_PARAMETRO_RETENCAO.val_variacao_aviso),
                                                                                new GDAParameter("?val_variacao_retencao", objIDA_PARAMETRO_RETENCAO.val_variacao_retencao),
                                                                                new GDAParameter("?ind_unidade_variacao", objIDA_PARAMETRO_RETENCAO.ind_unidade_variacao),
                                                                                new GDAParameter("?ind_retencao",objIDA_PARAMETRO_RETENCAO.ind_retencao)
                                                                            );
            }
            catch (Exception ex)
            {

            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objIDA_PARAMETRO_RETENCAO"></param>
        public void InsertParametroRetencao(ParametroRentencaoONP objIDA_PARAMETRO_RETENCAO)
        {
            try
            {
                this.Insert(objIDA_PARAMETRO_RETENCAO);
            }catch(Exception ex){
            }
        }

	}
}
