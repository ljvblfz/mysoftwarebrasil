using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class FaturaDAO : BaseDAO<FaturaONP>
    {

        public List<FaturaONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal,int numeroPagina)
        {
            string sql = @"
DECLARE @pagina INT
DECLARE @ultimoRegistro INT
DECLARE @primeiroRegistro INT
DECLARE @totalPagina INT
SET @totalPagina = 50
SET @pagina = ?numeroPagina
SET @ultimoRegistro = (@pagina*@totalPagina)-1
SET @primeiroRegistro = ((@pagina*@totalPagina) - (@totalPagina))
SELECT
	aux2.seq_fatura  
	,aux2.cod_referencia 
	,aux2.seq_roteiro                             
	,aux2.seq_matricula                           
	,aux2.seq_tipo_entrega 
	,aux2.cod_hidrometro 
	,aux2.ind_fatura_emitida 
	,aux2.dat_vencimento          
	,aux2.val_arredonda_anterior 
	,aux2.val_arredonda_atual 
	,aux2.dat_hora_emissao 
	,aux2.val_valor_faturado                      
	,aux2.dat_leitura             
	,aux2.dat_leitura_anterior    
	,aux2.ind_entrega_especial 
	,aux2.des_banco_debito 
	,aux2.des_banco_agencia_debito 
	,aux2.val_quantidade_pendente 
	,aux2.val_consumo_medio                       
	,aux2.val_desconto 
	,aux2.des_linha_digitavel                                
	,aux2.des_codigo_barras                                
	,aux2.val_consumo_medido                      
	,aux2.val_consumo_atribuido 
	,aux2.val_consumo_rateado 
	,aux2.val_leitura_anterior                    
	,aux2.val_leitura_real                        
	,aux2.val_leitura_atribuida 
	,aux2.val_impressoes 
	,aux2.dat_proxima_leitura 
	,aux2.val_valor_credito 
	,aux2.val_leitura_atual
	FROM ( SELECT ROW_NUMBER() OVER (ORDER BY aux1.seq_matricula) ln,aux1.* 
           FROM (
					SELECT DISTINCT

						null AS seq_fatura,
						'1974.05' AS cod_referencia,
						CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) AS seq_roteiro,
						CONVERT(numeric(9),DD.cdc,102) AS seq_matricula,
						NULL AS seq_tipo_entrega,
						NULL AS cod_hidrometro,   
						'N' AS ind_fatura_emitida, 
						DD.Data_vencimento AS dat_vencimento,
						NULL AS val_arredonda_anterior,
						NULL AS val_arredonda_atual,
						NUll AS dat_hora_emissao,
						DD.Valor_Total AS val_valor_faturado,
						CONVERT(DATETIME,'1974-05-06',102) AS dat_leitura,
						NULL AS dat_leitura_anterior,
						NULL AS ind_entrega_especial,
						NULL AS des_banco_debito,
						NULL AS des_banco_agencia_debito,
						NULL AS val_quantidade_pendente, 
						NULL AS val_consumo_medio,
						NULL AS val_desconto,
						dbo.FC_CODIGO_BARRAS_CONTROLE(DD.codigo_barras) AS des_linha_digitavel,
						DD.codigo_barras AS des_codigo_barras,
						NULL AS val_consumo_medido,
						NULL AS val_consumo_atribuido,
						NULL AS val_consumo_rateado,  
						NULL AS val_leitura_anterior, 
						NULL AS val_leitura_real, 
						NULL AS val_leitura_atribuida,
						0 AS val_impressoes,
						NULL AS dat_proxima_leitura,
						NULL AS val_valor_credito,
						NULL AS val_leitura_atual
					    
					FROM
						IDA_DEBITOS DD
						LEFT JOIN IDA_LIGACOES L ON DD.cdc = L.cdc
						LEFT JOIN IDA_SEGUNDAS_VIAS SV ON SV.cdc = L.cdc 
						LEFT JOIN IDA_GRUPOS G ON G.grupo = L.grupo 
						
					WHERE 
					    L.grupo = ?grupo
					    AND	L.rota = ?rotaFinal
					    
					GROUP BY
						G.referencia
						,L.grupo
						,L.rota
						,L.CDC
						,DD.CDC
						,SV.Codigo_Barras
						,DD.Data_vencimento
						,DD.codigo_barras
						,SV.seq_fatura_auto
						,DD.Valor_Total

					UNION ALL 

					SELECT DISTINCT

						null AS seq_fatura,
						CONVERT(char(7),D.referencia,102) AS cod_referencia,
						CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) AS seq_roteiro,
						CONVERT(numeric(9),D.cdc,102) AS seq_matricula,
						NULL AS seq_tipo_entrega,
						NULL AS cod_hidrometro,   
						'N' AS ind_fatura_emitida, 
						DD.Data_Vencimento AS dat_vencimento,
						NULL AS val_arredonda_anterior,
						NULL AS val_arredonda_atual,
						NUll AS dat_hora_emissao,
						D.Valor AS val_valor_faturado,
						CONVERT(DATETIME,D.referencia,102) AS dat_leitura,
						NULL AS dat_leitura_anterior,
						NULL AS ind_entrega_especial,
						NULL AS des_banco_debito,
						NULL AS des_banco_agencia_debito,
						NULL AS val_quantidade_pendente, 
						NULL AS val_consumo_medio,
						NULL AS val_desconto,
						NULL AS des_linha_digitavel,
						NULL AS des_codigo_barras,
						NULL AS val_consumo_medido,
						NULL AS val_consumo_atribuido,
						NULL AS val_consumo_rateado,  
						NULL AS val_leitura_anterior, 
						NULL AS val_leitura_real, 
						NULL AS val_leitura_atribuida,
						0 AS val_impressoes,
						NULL AS dat_proxima_leitura,
						NULL AS val_valor_credito,
						NULL AS val_leitura_atual

					FROM
						IDA_LIGACOES L 
						LEFT JOIN IDA_DEBITOS_ITENS D ON D.cdc = L.cdc
						LEFT JOIN IDA_DEBITOS DD ON DD.cdc = L.cdc
						LEFT JOIN IDA_SEGUNDAS_VIAS SV ON SV.cdc = L.cdc AND SV.referencia = D.referencia --OR SV.referencia IS NULL
						LEFT JOIN IDA_HISTORICOS_CONSUMO H	ON  H.cdc = L.cdc AND H.referencia = SV.referencia
						LEFT JOIN IDA_GRUPOS G ON G.grupo = L.grupo 
						
					WHERE 
						SV.referencia IS NOT NULL
					    AND	L.grupo = ?grupo
					    AND	L.rota = ?rotaFinal
						AND D.cdc IS NOT NULL

					UNION ALL


					SELECT DISTINCT
						null AS seq_fatura,
						CONVERT(char(7),SV.referencia,102) AS cod_referencia,
						CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) AS seq_roteiro,
						SV.cdc AS seq_matricula,
						NULL AS seq_tipo_entrega,
						NULL AS cod_hidrometro,   
						'N' AS ind_fatura_emitida, 
						SV.data_vencimento AS dat_vencimento,
						NULL AS val_arredonda_anterior,
						NULL AS val_arredonda_atual,
						NUll AS dat_hora_emissao,
						CONVERT(numeric(11,3),SV.valor_total,102) AS val_valor_faturado,
						SV.data_leitura AS dat_leitura,
						SV.data_leitura_anterior AS dat_leitura_anterior,
						NULL AS ind_entrega_especial,
						NULL AS des_banco_debito,
						NULL AS des_banco_agencia_debito,
						NULL AS val_quantidade_pendente, 
						CAST(SV.media AS NUMERIC(7,0)) AS val_consumo_medio,
						NULL AS val_desconto,
						dbo.FC_CODIGO_BARRAS_CONTROLE(SV.codigo_barras) AS des_linha_digitavel,
						SV.codigo_barras AS des_codigo_barras,
						CONVERT(numeric(7),SV.consumo_faturado,102) AS val_consumo_medido,
						NULL AS val_consumo_atribuido,
						NULL AS val_consumo_rateado,  
						CONVERT(numeric(7),SV.leitura_anterior,102) AS val_leitura_anterior, 
						CONVERT(numeric(7),H.Leitura_Real,102) AS val_leitura_real, 
						NULL AS val_leitura_atribuida,
						0 AS val_impressoes,
						NULL AS dat_proxima_leitura,
						NULL AS val_valor_credito,
						CONVERT(numeric(7),SV.leitura_atual,102) AS val_leitura_atual

					FROM
					IDA_LIGACOES L 
					LEFT JOIN IDA_SEGUNDAS_VIAS SV ON SV.cdc = L.cdc AND SV.grupo = L.grupo 
					LEFT JOIN IDA_HISTORICOS_CONSUMO H	ON  H.cdc = L.cdc AND H.referencia = SV.referencia
					LEFT JOIN IDA_GRUPOS G ON G.grupo = L.grupo 

					WHERE 
					SV.referencia IS NOT NULL
					AND	L.grupo = ?grupo
					AND	L.rota = ?rotaFinal
				)as aux1
		) as aux2
WHERE aux2.ln BETWEEN @primeiroRegistro AND @ultimoRegistro";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?rotaFinal", rotaFinal), new GDAParameter("?numeroPagina", numeroPagina));
        }


        //[OBSOLETO]
        public List<FaturaONP> Lista_old(int grupo,DateTime referencia,int rotaInicial,int rotaFinal)
        {
            string sql = @"
						SELECT DISTINCT
							null AS seq_fatura,
							'1974.05' AS cod_referencia,
							CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) AS seq_roteiro,
							CONVERT(numeric(9),DD.cdc,102) AS seq_matricula,
							NULL AS seq_tipo_entrega,
							NULL AS cod_hidrometro,   
							'N' AS ind_fatura_emitida, 
							DD.Data_vencimento AS dat_vencimento,
							NULL AS val_arredonda_anterior,
							NULL AS val_arredonda_atual,
							NUll AS dat_hora_emissao,
                            DD.Valor_Total AS val_valor_faturado,
							CONVERT(DATETIME,'1974-05-06',102) AS dat_leitura,
							NULL AS dat_leitura_anterior,
							NULL AS ind_entrega_especial,
							NULL AS des_banco_debito,
							NULL AS des_banco_agencia_debito,
							NULL AS val_quantidade_pendente, 
							NULL AS val_consumo_medio,
							NULL AS val_desconto,
							dbo.FC_CODIGO_BARRAS_CONTROLE(DD.codigo_barras) AS des_linha_digitavel,
							DD.codigo_barras AS des_codigo_barras,
							NULL AS val_consumo_medido,
							NULL AS val_consumo_atribuido,
							NULL AS val_consumo_rateado,  
							NULL AS val_leitura_anterior, 
							NULL AS val_leitura_real, 
							NULL AS val_leitura_atribuida,
							0 AS val_impressoes,
							NULL AS dat_proxima_leitura,
							NULL AS val_valor_credito,
							NULL AS val_leitura_atual
						    
						FROM
							IDA_DEBITOS DD
							LEFT JOIN IDA_LIGACOES L ON DD.cdc = L.cdc
							LEFT JOIN IDA_SEGUNDAS_VIAS SV ON SV.cdc = L.cdc 
							LEFT JOIN IDA_GRUPOS G ON G.grupo = L.grupo 
							
						WHERE 
							L.grupo = ?grupo
                            AND	L.rota = ?rotaFinal
						    
						GROUP BY
							G.referencia
							,L.grupo
							,L.rota
							,L.CDC
							,DD.CDC
							,SV.Codigo_Barras
							,DD.Data_vencimento
							,DD.codigo_barras
                            ,SV.seq_fatura_auto
                            ,DD.Valor_Total

			UNION ALL 

						SELECT DISTINCT

							null AS seq_fatura,
                            CONVERT(char(7),D.referencia,102) AS cod_referencia,
							CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) AS seq_roteiro,
							CONVERT(numeric(9),D.cdc,102) AS seq_matricula,
							NULL AS seq_tipo_entrega,
							NULL AS cod_hidrometro,   
							'N' AS ind_fatura_emitida, 
							DD.Data_Vencimento AS dat_vencimento,
							NULL AS val_arredonda_anterior,
							NULL AS val_arredonda_atual,
							NUll AS dat_hora_emissao,
							D.Valor AS val_valor_faturado,
							CONVERT(DATETIME,D.referencia,102) AS dat_leitura,
							NULL AS dat_leitura_anterior,
							NULL AS ind_entrega_especial,
							NULL AS des_banco_debito,
							NULL AS des_banco_agencia_debito,
							NULL AS val_quantidade_pendente, 
							NULL AS val_consumo_medio,
							NULL AS val_desconto,
							NULL AS des_linha_digitavel,
							NULL AS des_codigo_barras,
							NULL AS val_consumo_medido,
							NULL AS val_consumo_atribuido,
							NULL AS val_consumo_rateado,  
							NULL AS val_leitura_anterior, 
							NULL AS val_leitura_real, 
							NULL AS val_leitura_atribuida,
							0 AS val_impressoes,
							NULL AS dat_proxima_leitura,
							NULL AS val_valor_credito,
							NULL AS val_leitura_atual

						FROM
							IDA_LIGACOES L 
							LEFT JOIN IDA_DEBITOS_ITENS D ON D.cdc = L.cdc
							LEFT JOIN IDA_DEBITOS DD ON DD.cdc = L.cdc
							LEFT JOIN IDA_SEGUNDAS_VIAS SV ON SV.cdc = L.cdc AND SV.referencia = D.referencia --OR SV.referencia IS NULL
							LEFT JOIN IDA_HISTORICOS_CONSUMO H	ON  H.cdc = L.cdc AND H.referencia = SV.referencia
							LEFT JOIN IDA_GRUPOS G ON G.grupo = L.grupo 
							
						WHERE 
							SV.referencia IS NOT NULL
                            AND	L.grupo = ?grupo
                            AND	L.rota = ?rotaFinal
							AND D.cdc IS NOT NULL

				UNION ALL


		           SELECT DISTINCT
                            null AS seq_fatura,
                            CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                            CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) AS seq_roteiro,
                            SV.cdc AS seq_matricula,
                            NULL AS seq_tipo_entrega,
                            NULL AS cod_hidrometro,   
                            'N' AS ind_fatura_emitida, 
                            SV.data_vencimento AS dat_vencimento,
                            NULL AS val_arredonda_anterior,
                            NULL AS val_arredonda_atual,
                            NUll AS dat_hora_emissao,
                            CONVERT(numeric(11,3),SV.valor_total,102) AS val_valor_faturado,
                            SV.data_leitura AS dat_leitura,
                            SV.data_leitura_anterior AS dat_leitura_anterior,
                            NULL AS ind_entrega_especial,
                            NULL AS des_banco_debito,
                            NULL AS des_banco_agencia_debito,
                            NULL AS val_quantidade_pendente, 
                            CAST(SV.media AS NUMERIC(7,0)) AS val_consumo_medio,
                            NULL AS val_desconto,
                            dbo.FC_CODIGO_BARRAS_CONTROLE(SV.codigo_barras) AS des_linha_digitavel,
                            SV.codigo_barras AS des_codigo_barras,
                            CONVERT(numeric(7),SV.consumo_faturado,102) AS val_consumo_medido,
                            NULL AS val_consumo_atribuido,
                            NULL AS val_consumo_rateado,  
                            CONVERT(numeric(7),SV.leitura_anterior,102) AS val_leitura_anterior, 
                            CONVERT(numeric(7),H.Leitura_Real,102) AS val_leitura_real, 
                            NULL AS val_leitura_atribuida,
                            0 AS val_impressoes,
                            NULL AS dat_proxima_leitura,
                            NULL AS val_valor_credito,
                            CONVERT(numeric(7),SV.leitura_atual,102) AS val_leitura_atual
                	    
                    FROM
                        IDA_LIGACOES L 
                        LEFT JOIN IDA_SEGUNDAS_VIAS SV ON SV.cdc = L.cdc AND SV.grupo = L.grupo 
                        LEFT JOIN IDA_HISTORICOS_CONSUMO H	ON  H.cdc = L.cdc AND H.referencia = SV.referencia
                        LEFT JOIN IDA_GRUPOS G ON G.grupo = L.grupo 
                		
                    WHERE 
                        SV.referencia IS NOT NULL
                        AND	L.grupo = ?grupo
                        AND	L.rota = ?rotaFinal

                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaFinal", rotaFinal));
        }
    }
}
