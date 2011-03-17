using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class MatriculaImpostoDiademaDAO : BaseDAO<MatriculaImpostoDiadema>
    {
        public List<MatriculaImpostoDiadema> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MATRICULA_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        public List<MatriculaImpostoDiadema> Importar(int grupo, int rotaIni, int rotaFim, DateTime referencia)
        {
            string sql = @"
                            SELECT	
	                            L.cdc AS seq_matricula,
	                            --L.cdc_pai AS seq_matricula_pai,
                                CASE WHEN L.cdc_pai > 0 THEN L.cdc_pai ELSE NULL END AS seq_matricula_pai,
                                --null AS seq_matricula_pai,
	                            isnull(L.qtde_registros_fraude,0)  AS val_fraudes, 
	                            CASE WHEN isnull(L.cortar,'') = '' THEN '' ELSE L.cortar END AS ind_corta_ligacao, 
	                            L.calcula_imposto AS ind_retencao_impostos, 
	                            case when isnull(L.bloqueado,'L') in ('L', '') then 'N' else 'S' END AS ind_bloqueio, 
	                            isnull(L.dias_bloqueio_tarifa_ant,0) AS val_dias_bloqueio_anterior,
	                            isnull(L.dias_bloqueio_tarifa_atual,0) AS val_dias_bloqueio_atual,
	                            L.cachorro AS ind_cachorro, 
	                            L.ident_consumidor AS ind_tipo_consumidor,
                    			
	                            CASE /*CALCULA_CONTA*/
		                            WHEN (L.ident_consumidor = 1)
		                            THEN L.calcula_conta
		                            WHEN (L.ident_consumidor = 2) and (L.cdc <> L.cdc_pai)
		                            THEN L.calcula_conta
		                            WHEN (L.ident_consumidor = 3) and (L.cdc = L.cdc_pai)
		                            THEN L.calcula_conta
		                            WHEN (L.ident_consumidor = 4) and (L.cdc = L.cdc_pai)
		                            THEN L.calcula_conta
		                            WHEN (L.ident_consumidor = 5) and (L.cdc = L.cdc_pai)
		                            THEN L.calcula_conta
		                            WHEN (L.ident_consumidor = 6) and (L.cdc = L.cdc_pai)
		                            THEN L.calcula_conta
		                            WHEN (L.ident_consumidor = 7) and (L.cdc = L.cdc_pai)
		                            THEN L.calcula_conta
		                            WHEN (L.ident_consumidor = 8) and (L.cdc = L.cdc_pai)
		                            THEN L.calcula_conta
		                            WHEN (L.ident_consumidor = 9) and (L.cdc <> L.cdc_pai)
		                            THEN L.calcula_conta
		                            WHEN (L.ident_consumidor = 10) and (L.cdc = L.cdc_pai)
		                            THEN L.calcula_conta
	                            ELSE 'N' END AS ind_calcula_fatura, 
	                            CASE WHEN (ISNULL(L.bloqueado,'L') NOT IN ('L', '')) AND (L.ident_consumidor = 9) then 'N' else L.emite_conta END AS ind_emite_fatura, 
	                            CASE WHEN (L.clas_imovel IN (4, 64)) AND (ISNULL(L.cdc_pai,0) = 0) THEN 0 ELSE L.clas_imovel END AS seq_desconto, 
	                            ISNULL(SUBSTRING(L.mensagem1, 0, 29),'') AS des_mensagem_1, 
	                            ISNULL(L.mensagem2,'') AS des_mensagem_2, 
	                            NULL AS dat_bloqueio
                    			
                        FROM	
                            IDA_GRUPOS G, 
                            IDA_LIGACOES L	
                        WHERE
                            L.grupo = G.grupo
                            AND L.grupo = ?Grupo
                            --AND	G.referencia = ?referencia
                            AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal

                         ";
            List<MatriculaImpostoDiadema> matriculasDiadema = CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaIni), new GDAParameter("?rotaFinal", rotaFim));

            // Altera o valor da data da troca para data atual
            for (int i = 0; i < matriculasDiadema.Count(); i++)
            {
                matriculasDiadema[i].dat_bloqueio = null;
            }
            return matriculasDiadema;
        }

    }
}