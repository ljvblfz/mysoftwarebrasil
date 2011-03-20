using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public class TaxaTarifaFaixaDAO : BaseDAO<TaxaTarifaFaixaONP>
    {
        public List<TaxaTarifaFaixaONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
                            SELECT DISTINCT
	                              T.categoria AS seq_categoria,
	                              REPLACE(convert(char(10),T.data_vigencia,102),'.','') as seq_taxa_tarifa,
			                      1 AS seq_taxa,
	                              (
		                            SELECT DISTINCT COUNT(*) + 1
			                            FROM  IDA_TARIFAS T2
			                            WHERE T2.categoria = T.categoria
			                              AND T2.data_vigencia = T.data_vigencia
			                              AND T2.limite_consumo < T.limite_consumo
			                              AND T2.data_vigencia = T.data_vigencia
			                              AND T2.grupo = T.grupo
	                              ) AS seq_taxa_tarifa_faixa,
	                              CasE WHEN T.limite_consumo >= 999999 THEN 9999999 ELSE T.limite_consumo END AS val_limite_consumo,
	                              (
									SELECT  agua
									FROM  IDA_TARIFAS T3
									WHERE T3.grupo = ?Grupo
										AND T3.categoria = T.categoria
										AND T3.limite_consumo = T.limite_consumo
										AND T3.data_vigencia = T.data_vigencia	
								   ) as val_valor_tarifa
	                            FROM 
		                            IDA_LIGACOES L,
		                            IDA_TARIFAS T
	                            WHERE 
		                            L.grupo = ?Grupo
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal

                            UNION ALL


                            SELECT DISTINCT
	                              T.categoria AS seq_categoria,
	                              REPLACE(convert(char(10),T.data_vigencia,102),'.','') as seq_taxa_tarifa,
			                      2 AS seq_taxa,
	                              (
		                            SELECT DISTINCT COUNT(*) + 1
			                            FROM  IDA_TARIFAS T2
			                            WHERE T2.categoria = T.categoria
			                              AND T2.data_vigencia = T.data_vigencia
			                              AND T2.limite_consumo < T.limite_consumo
			                              AND T2.data_vigencia = T.data_vigencia
			                              AND T2.grupo = T.grupo
	                              ) AS seq_taxa_tarifa_faixa,
	                              CASE WHEN T.limite_consumo >= 999999 THEN 9999999 ELSE T.limite_consumo END AS val_limite_consumo,
	                              (
									SELECT  esgoto
									FROM  IDA_TARIFAS T3
									WHERE T3.grupo = ?Grupo
										AND T3.categoria = T.categoria
										AND T3.limite_consumo = T.limite_consumo
										AND T3.data_vigencia = T.data_vigencia	
								   ) as val_valor_tarifa
	                            FROM 
		                            IDA_LIGACOES L,
		                            IDA_TARIFAS T
	                            WHERE 
		                            L.grupo = ?Grupo
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
    }
}
