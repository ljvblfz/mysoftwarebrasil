using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class FaturaTaxaDAO : BaseDAO<FaturaTaxa>
    {
        public List<FaturaTaxa> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_FATURA_TAXA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        public List<FaturaTaxa> Importar(int grupo, int rotaIni, int rotaFim, DateTime referencia)
        {
            string sql = @"
                                -- CATEGORIA MISTA----------------------------------------------------------

		                        -- AGUA
		                        SELECT DISTINCT
			                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura, 
	                                1 AS seq_taxa,--agua
			                        5 AS seq_categoria,
			                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
			                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS seq_roteiro,  
			                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                    SV.cdc AS seq_matricula,
			                        (
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_com END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_ind END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END
			                        ) as val_numero_economia,
			                        (
				                        SV.consumo_faturado*
			                        (
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_com END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_ind END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END+
				                        CASE L.categoria_imovel WHEN 8 THEN (L.eco_res + L.eco_com + L.eco_ind + L.eco_pub +  +L.eco_soc) ELSE 0 END
			                        )
			                        )AS val_consumo_faturado,
			                        0 AS val_valor_calculado,
			                        SV.valor_total AS val_valor_faturado,
			                        1 AS ind_situacao,
			                        'L' AS ind_tipo_consumo
		                        FROM	
			                        IDA_GRUPOS G, 
			                        IDA_LIGACOES L, 
			                        IDA_SEGUNDAS_VIAS SV
		                        WHERE 
		                        L.cdc = SV.cdc	
		                        AND	L.grupo = SV.grupo
		                        AND	G.referencia = SV.referencia
		                        AND	L.grupo = ?Grupo
		                        --AND	G.referencia = ?referencia
		                        AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                        UNION ALL
                        		
		                        -- ESGOTO
		                        SELECT DISTINCT
			                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura,  
	                                2 AS seq_taxa,--esgoto
			                        5 AS seq_categoria,
			                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
			                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS seq_roteiro,  
			                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                    SV.cdc AS seq_matricula,
			                        (
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_com END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_ind END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END
			                        ) as val_numero_economia,
			                        (
				                        SV.consumo_faturado*
			                        (
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_com END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_ind END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END+
				                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END+
				                        CASE L.categoria_imovel WHEN 8 THEN (L.eco_res + L.eco_com + L.eco_ind + L.eco_pub +  +L.eco_soc) ELSE 0 END
			                        )
			                        )AS val_consumo_faturado,
			                        0 AS val_valor_calculado,
			                        SV.valor_total AS val_valor_faturado,
			                        1 AS ind_situacao,
			                        'L' AS ind_tipo_consumo
		                        FROM	
			                        IDA_GRUPOS G, 
			                        IDA_LIGACOES L, 
			                        IDA_SEGUNDAS_VIAS SV
		                        WHERE 
		                        L.cdc = SV.cdc	
		                        AND	L.grupo = SV.grupo
		                        AND	G.referencia = SV.referencia
		                        AND	L.grupo = ?Grupo
		                        --AND	G.referencia = ?referencia
		                        AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                            
                            ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaIni), new GDAParameter("?rotaFinal", rotaFim));
        }

    }
}