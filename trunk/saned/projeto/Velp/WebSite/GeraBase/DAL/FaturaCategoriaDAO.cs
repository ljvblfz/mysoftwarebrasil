using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public class FaturaCategoriaDAO: BaseDAO<FaturaCategoriaONP>
    {
        public List<FaturaCategoriaONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
                            -- CATEGORIA RESIDENSIAL
                            SELECT DISTINCT
                                null AS seq_fatura,
		                        --SV.seq_fatura_auto AS seq_fatura,
                                1 AS seq_categoria, 
                                null AS val_valor_faturado,
                                CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                SV.cdc AS seq_matricula,
                                CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END AS val_numero_economia
                            FROM
                                IDA_GRUPOS G,	
                                IDA_LIGACOES L, 
                                IDA_SEGUNDAS_VIAS SV
                            WHERE 
                            L.cdc = SV.cdc	
                            AND	L.grupo = SV.grupo
                            AND	G.grupo = SV.grupo
                            AND L.eco_res <> 0
                            AND	(
			                        SELECT 
				                        case 
					                        when (	
							                        case when Eco_Res > 0 then 1 else 0 end +
							                        case when Eco_Com > 0 then 1 else 0 end +
							                        case when Eco_Ind > 0 then 1 else 0 end +
							                        case when Eco_Pub > 0 then 1 else 0 end +
							                        case when Eco_Soc > 0 then 1 else 0 end
						                         ) >= 2
					                        then 1 
					                        else 0 
				                        end
			                        FROM IDA_LIGACOES
			                        WHERE CDC =L.CDC
		                        ) = 0 

                            AND	L.grupo = ?grupo
	                        AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                        	
                        UNION ALL
                        	
	                        -- CATEGORIA COMERCIAL
                            SELECT DISTINCT
                                null AS seq_fatura,
		                        --SV.seq_fatura_auto AS seq_fatura,
                                2 AS seq_categoria, 
                                null AS val_valor_faturado,
                                CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                SV.cdc AS seq_matricula,
                                CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.Eco_Com END AS val_numero_economia
                            FROM
                                IDA_GRUPOS G,	
                                IDA_LIGACOES L, 
                                IDA_SEGUNDAS_VIAS SV
                            WHERE 
                            L.cdc = SV.cdc	
                            AND	L.grupo = SV.grupo
                            AND	G.grupo = SV.grupo
                            AND L.Eco_Com <> 0
                            AND	(
			                        SELECT 
				                        case 
					                        when (	
							                        case when Eco_Res > 0 then 1 else 0 end +
							                        case when Eco_Com > 0 then 1 else 0 end +
							                        case when Eco_Ind > 0 then 1 else 0 end +
							                        case when Eco_Pub > 0 then 1 else 0 end +
							                        case when Eco_Soc > 0 then 1 else 0 end
						                         ) >= 2
					                        then 1 
					                        else 0 
				                        end
			                        FROM IDA_LIGACOES
			                        WHERE CDC =L.CDC
		                        ) = 0 

                            AND	L.grupo = ?grupo
                            AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                        	
                        UNION ALL
                        	
	                        -- CATEGORIA INDUSTRIAL
                            SELECT DISTINCT
                                null AS seq_fatura,
		                        --SV.seq_fatura_auto AS seq_fatura,
                                3 AS seq_categoria, 
                                null AS val_valor_faturado,
                                CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                SV.cdc AS seq_matricula,
                                CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.Eco_Ind END AS val_numero_economia
                            FROM	
                                IDA_GRUPOS G, 
                                IDA_LIGACOES L, 
                                IDA_SEGUNDAS_VIAS SV
                            WHERE 
                            L.cdc = SV.cdc	
                            AND	L.grupo = SV.grupo
                            AND	G.grupo = SV.grupo
                            AND	L.Eco_Ind <> 0
                            AND	(
			                        SELECT 
				                        case 
					                        when (	
							                        case when Eco_Res > 0 then 1 else 0 end +
							                        case when Eco_Com > 0 then 1 else 0 end +
							                        case when Eco_Ind > 0 then 1 else 0 end +
							                        case when Eco_Pub > 0 then 1 else 0 end +
							                        case when Eco_Soc > 0 then 1 else 0 end
						                         ) >= 2
					                        then 1 
					                        else 0 
				                        end
			                        FROM IDA_LIGACOES
			                        WHERE CDC =L.CDC
		                        ) = 0  

	                        AND	L.grupo = ?grupo
                            AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal

                        UNION ALL

                            -- CATEGORIA PUBLICA
                            SELECT DISTINCT
                                null AS seq_fatura,
		                        --SV.seq_fatura_auto AS seq_fatura,
                                4 AS seq_categoria, 
                                null AS val_valor_faturado,
                                CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                SV.cdc AS seq_matricula,
                                CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.Eco_Pub END AS val_numero_economia
                            FROM	
                                IDA_GRUPOS G, 
                                IDA_LIGACOES L, 
                                IDA_SEGUNDAS_VIAS SV
                            WHERE 
                            L.cdc = SV.cdc	
                            AND	L.grupo = SV.grupo
                            AND	G.grupo = SV.grupo
                            AND L.Eco_Pub <> 0
                            AND	(
		                        SELECT 
			                        case 
				                        when (	
						                        case when Eco_Res > 0 then 1 else 0 end +
						                        case when Eco_Com > 0 then 1 else 0 end +
						                        case when Eco_Ind > 0 then 1 else 0 end +
						                        case when Eco_Pub > 0 then 1 else 0 end +
						                        case when Eco_Soc > 0 then 1 else 0 end
					                         ) >= 2
				                        then 1 
				                        else 0 
			                        end
		                        FROM IDA_LIGACOES
		                        WHERE CDC =L.CDC
	                        ) = 0      

	                        AND	L.grupo = ?grupo
                            AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal

                        UNION ALL

                            -- CATEGORIA MISTA
                            SELECT DISTINCT
                                null AS seq_fatura,
		                        --SV.seq_fatura_auto AS seq_fatura,
                                5 AS seq_categoria, 
                                null AS val_valor_faturado, 
                                CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                SV.cdc AS seq_matricula,
                                CASE 
			                        L.categoria_imovel WHEN 8 THEN 0 
			                        ELSE 
				                        (
				                         Eco_Res+Eco_Com+Eco_Ind+Eco_Pub+Eco_Soc
				                        ) 
		                        END AS val_numero_economia
                            FROM	
                                IDA_GRUPOS G, 
                                IDA_LIGACOES L, 
                                IDA_SEGUNDAS_VIAS SV
                            WHERE 
                            L.cdc = SV.cdc	
                            AND	L.grupo = SV.grupo
                            AND	G.grupo = SV.grupo
                            AND	(
			                        SELECT 
				                        case 
					                        when (	
							                        case when Eco_Res > 0 then 1 else 0 end +
							                        case when Eco_Com > 0 then 1 else 0 end +
							                        case when Eco_Ind > 0 then 1 else 0 end +
							                        case when Eco_Pub > 0 then 1 else 0 end +
							                        case when Eco_Soc > 0 then 1 else 0 end
						                         ) >= 2
					                        then 1 
					                        else 0 
				                        end
			                        FROM IDA_LIGACOES
			                        WHERE CDC =L.CDC
		                        ) = 1 

                            AND	L.grupo = ?grupo
                            AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal


                        UNION ALL

                            -- CATEGORIA SOCIAL
                            SELECT DISTINCT
                                null AS seq_fatura,
		                        --SV.seq_fatura_auto AS seq_fatura,
                                6 AS seq_categoria, 
                                null AS val_valor_faturado,
                                CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                SV.cdc AS seq_matricula,
                                L.Eco_Soc AS val_numero_economia
                            FROM	
                                IDA_GRUPOS G, 
                                IDA_LIGACOES L, 
                                IDA_SEGUNDAS_VIAS SV
                            WHERE 
                            L.cdc = SV.cdc	
                            AND	L.grupo = SV.grupo
                            AND	G.grupo = SV.grupo
                            AND	L.Eco_Soc <> 0
                            AND	(
		                        SELECT 
			                        case 
				                        when (	
						                        case when Eco_Res > 0 then 1 else 0 end +
						                        case when Eco_Com > 0 then 1 else 0 end +
						                        case when Eco_Ind > 0 then 1 else 0 end +
						                        case when Eco_Pub > 0 then 1 else 0 end +
						                        case when Eco_Soc > 0 then 1 else 0 end
					                         ) >= 2
				                        then 1 
				                        else 0 
			                        end
		                        FROM IDA_LIGACOES
		                        WHERE CDC =L.CDC
	                        ) = 0  

                            AND	L.grupo = ?grupo
                            AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal

                        UNION ALL

                            -- CATEGORIA ENTIDADE ASSISTENCIAL 
                            SELECT DISTINCT
                                null AS seq_fatura,
		                        --SV.seq_fatura_auto AS seq_fatura,
                                8 AS seq_categoria, 
                                null AS val_valor_faturado,
                                CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                SV.cdc AS seq_matricula,
                                0 AS val_numero_economia
                            FROM	
                                IDA_GRUPOS G, 
                                IDA_LIGACOES L, 
                                IDA_SEGUNDAS_VIAS SV
                            WHERE 
                            L.cdc = SV.cdc	
                            AND	L.grupo = SV.grupo
                            AND	G.grupo = L.grupo
                            AND	L.categoria_imovel = 8

                            AND	L.grupo = ?grupo
                            AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
    }
}
