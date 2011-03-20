using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public  class OcorrenciaTDAO : BaseDAO<OcorrenciaTONP>
	{
        /// <summary>
        ///  Retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public List<OcorrenciaTONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_OCORRENCIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        ///  deleta
        /// </summary>
        /// <param name="objIDA_OCORRENCIA"></param>
        public void DeleteOcorrencia(OcorrenciaTONP objIDA_OCORRENCIA)
        {
            try
            {
                GDA.Sql.Query query = new GDA.Sql.Query(" cod_ocorrencia = '" + objIDA_OCORRENCIA.cod_ocorrencia + @"'");
                this.Delete(query);
            
            }catch(Exception ex){
            }
            return;
        }

        /// <summary>
        /// atualiza
        /// </summary>
        /// <param name="objIDA_OCORRENCIA"></param>
        public void UpdateOcorrencia(OcorrenciaTONP objIDA_OCORRENCIA)
        {
            try
            {
                string sql = @"
                            UPDATE IDA_OCORRENCIA
                               SET
                                    des_ocorrencia = ?des_ocorrencia , 
                                    des_mensagem = ?des_mensagem , 
                                    ind_grupo = ?ind_grupo , 
                                    ind_leitura = ?ind_leitura , 
                                    ind_consumo = ?ind_consumo , 
                                    ind_emite = ?ind_emite

                             WHERE cod_ocorrencia = ?cod_ocorrencia";

                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql,
                                                                             new GDAParameter("?des_ocorrencia",objIDA_OCORRENCIA.des_ocorrencia),
                                                                             new GDAParameter("?des_mensagem",objIDA_OCORRENCIA.des_mensagem),
                                                                             new GDAParameter("?ind_grupo",objIDA_OCORRENCIA.ind_grupo),
                                                                             new GDAParameter("?ind_leitura",objIDA_OCORRENCIA.ind_leitura),
                                                                             new GDAParameter("?ind_consumo",objIDA_OCORRENCIA.ind_consumo),
                                                                             new GDAParameter("?ind_emite",objIDA_OCORRENCIA.ind_emite),
                                                                             new GDAParameter("?cod_ocorrencia",objIDA_OCORRENCIA.cod_ocorrencia)
                                                                            );
            }catch(Exception ex){

            }
            return;
        }

        /// <summary>
        /// insere
        /// </summary>
        /// <param name="objIDA_OCORRENCIA"></param>
        public void InsertOcorrencia(OcorrenciaTONP objIDA_OCORRENCIA)
        {
            try
            {
                this.Insert(objIDA_OCORRENCIA);

            }catch(Exception ex){
            }
            return;
        }
	}
}
