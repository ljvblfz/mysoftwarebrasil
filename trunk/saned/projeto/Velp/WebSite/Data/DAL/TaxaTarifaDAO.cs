using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class TaxaTarifaDAO : BaseDAO<TaxaTarifaONP>
    {

        public List<TaxaTarifaONP> Lista(int grupo)
        {
            string sql = @"
                            SELECT  DISTINCT  
                                    categoria AS seq_categoria, 
                                    1 AS seq_taxa, 
                                    REPLACE(convert(char(10),T.data_vigencia,102),'.','') as seq_taxa_tarifa,
			                        --CONVERT(numeric(9),convert(char(6), data_vigencia, 112) + RIGHT ('000'+ convert(char(6),T.data_vigencia,104), 3)) as seq_taxa_tarifa,
                                    null AS seq_taxa_base, 
                                    T.data_vigencia AS dat_inicio, 
                                    'C' AS ind_tipo_taxa, 
                                    'S' AS ind_escalonada, 
                                    'N' AS ind_dias_consumo, 
                                    'S' AS ind_minimo,
                                    'N' AS ind_proporcional, 
                                    null AS val_valor_tarifa, 
                                    null AS val_percentual
                            FROM 	 IDA_TARIFAS T
                            WHERE	 
                                 --referencia = ?parReferencia
                                 --and 
                                 T.grupo = ?Grupo
                        	
                            UNION ALL

                                SELECT	DISTINCT 
			                        T.categoria AS seq_categoria, 
                                    2 AS seq_taxa, 
                                    REPLACE(convert(char(10),T.data_vigencia,102),'.','') as seq_taxa_tarifa,
			                        --CONVERT(numeric(9),convert(char(6), data_vigencia, 112) + RIGHT ('000'+ CAST (T.data_vigencia AS varchar), 3)) as seq_taxa_tarifa,
                                    NULL AS seq_taxa_base, 
                                    T.data_vigencia AS dat_inicio, 
                                    'C' AS ind_tipo_taxa, 
                                    'S' AS ind_escalonada, 
                                    'N' AS ind_dias_consumo, 
                                    'S' AS ind_minimo, 
                                    'S' AS ind_proporcional, 
                                    null AS val_valor_tarifa, 
                                    null AS val_percentual
                                FROM 	IDA_TARIFAS T
                                WHERE	T.grupo = ?Grupo
                                --AND 	(
                                            --SELECT referencia
                                                --FROM IDA_GRUPOS
                                                --WHERE grupo = ?Grupo
                                                --AND data_processamento IS NULL
                                                --AND data_retorno IS NULL
                                        --) = ?parReferencia
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }
    }
}
