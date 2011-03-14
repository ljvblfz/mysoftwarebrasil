using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DeviceProject.Sincronizacao;
using DeviceProject.DATA.dataSaned.Flow;
using DeviceProject.Config;

namespace DeviceProject.DATA
{
    /// <summary>
    ///  Classe que contem os comandos SQL do envio dos dados
    /// </summary>
    public class SqlVolta
    {

        /// <summary>
        ///  Metodo que recuperao SQL da tabela informada
        ///  (os SQL são somente da descarga)
        /// </summary>
        /// <param name="TableName">string nome da tabela</param>
        /// <returns>string ,query a ser executada</returns>
        public static string Query(string TableName)
        {
            // Declaração da variavel de retorno
            string Sql = null;

            #region acessado através da thread

            //Alexis O. 14-12-2010
            string OnpFaturaF;
                      
            string matList = LogSyncFlow.GetListMatricula();

            if (string.IsNullOrEmpty(matList))
            {
                OnpFaturaF = string.Empty;
            }
            else
            {
                OnpFaturaF = string.Format(" and M.seq_matricula not in ({0}) ", matList);
            }          

            #endregion

            // Verifica qual e a tabela
            switch (TableName.ToUpper())
            {
                case "VOLTA_ROTEIRO":
                    {
                        Sql = @"
                                SELECT DISTINCT
                                    R.cod_referencia AS Referencia,
                                    R.seq_grupo_fatura AS Grupo,
                                    F.seq_roteiro AS Rota,
                                    MIN(F.dat_leitura) AS Data_Inicial,
                                    MAX( F.dat_leitura ) AS Data_Final,
                                    getdate() AS Data_Envio,
                                    0 AS Aparelho,
                                    NULL AS Data_Problema,
                                    NULL AS Data_Processamento,
                                    'N' AS Chuva
                                FROM 
                                    ONP_FATURA F
                                LEFT JOIN ONP_ROTEIRO R ON F.seq_roteiro = R.seq_roteiro
                                
                                WHERE
                                    --F.cod_referencia = @Referencia
                                    R.cod_referencia = @Referencia
                                GROUP BY 
                                    R.cod_referencia,
                                    R.seq_grupo_fatura,
                                    F.seq_roteiro
                           ";
                        break;
                    }
                case "VOLTA_LOG_ATENDIMENTO":
                    {
                        Sql = @"
                            SELECT DISTINCT
			                    R.seq_grupo_fatura AS Grupo
                                , F.seq_matricula AS CDC
                                , 'S'AS Tipo
                                , convert(datetime, substring(F.cod_referencia, 1, 4) + substring(F.cod_referencia, 6, 2) + '01') AS Referencia
                                , F.dat_leitura AS Data_Emissao
			                    , 0 AS Operador 
                            FROM ONP_FATURA F
                            LEFT JOIN ONP_ROTEIRO R ON F.seq_roteiro = R.seq_roteiro
                      
                            WHERE 
                                F.ind_fatura_emitida = 'S'
			                    AND F.seq_fatura <> 0                                
                           ";
                        break;
                    }
                case "VOLTA_LEITURA":
                    {
                        Sql = string.Format(@"
                            SELECT  
                                    R.seq_grupo_fatura AS Grupo,
                                    '0' AS Setor,
                                    SUBSTRING(CONVERT(NCHAR,max(M.seq_roteiro)),6,2) AS Rota,
                                    max(M.seq_matricula) AS CDC,
                                    CASE
                                        WHEN M.val_leitura_atribuida IS NULL
                                        THEN M.val_leitura_real
                                    ELSE
                                        M.val_leitura_atribuida 
                                    END AS Leitura_Ajustada,
                                    CASE
                                        WHEN M.val_leitura_real IS NULL 
                                        THEN 0
                                        ELSE M.val_leitura_real
                                    END AS Leitura_Real,
                                    M.dat_leitura AS Data_Leitura,
				                        CASE
					                        WHEN M.val_consumo_atribuido IS NULL
					                        THEN
						                        CASE
							                        WHEN M.val_consumo_atribuido > 0 AND M.val_consumo_medido = 0
							                        THEN M.val_consumo_atribuido
							                        WHEN Me.val_consumo_estimado > 0
							                        THEN Me.val_consumo_estimado
							                        WHEN M.val_consumo_medido > 0
							                        THEN M.val_consumo_medido			
							                        ELSE 0
						                        END
					                        ELSE M.val_consumo_atribuido 
				                        END AS Consumo_Ajustado,
				                        CASE
					                        WHEN M.val_consumo_atribuido IS NULL
					                        THEN CASE
							                        WHEN M.val_consumo_atribuido > 0 AND M.val_consumo_medido = 0
							                        THEN M.val_consumo_atribuido
							                        WHEN Me.val_consumo_estimado > 0
							                        THEN Me.val_consumo_estimado
							                        WHEN M.val_consumo_medido > 0
							                        THEN M.val_consumo_medido			
							                        ELSE 0
						                         END
					                        ELSE M.val_consumo_atribuido
				                        END  AS Esgoto_Ajustado,
                                    DATEDIFF(d, M.dat_leitura_anterior, M.dat_leitura) AS Dias_Consumo,
                                    min(MO.cod_ocorrencia) AS Ocorrencia,
                                    CASE 
                                        WHEN MD.val_fraudes = 0
                                        THEN 'N'
                                        ELSE 'S'
                                    END AS Ident_fraude,
                                    CASE 
                                        WHEN MD.ind_cortou_ligacao is null
                                        THEN 'N'
                                        ElSE 'S'
                                    END AS Indic_cortado,
                                    M.cod_agente AS Operador,
                                    CASE 
                                        WHEN MAX(FXa.val_valor_calculado) IS NOT NULL OR MAX(FXe.val_valor_calculado) IS NOT NULL
                                        THEN 'S'
                                        ELSE 'N' 
                                    END AS Flag_Calculo,
                                    M.ind_fatura_emitida AS Flag_Emissao,
                                    CONVERT(DATETIME,M.cod_referencia+'.01',120) AS Referencia,
                                    MAX(M.dat_leitura) AS Data_Emissao,
                                    M.dat_vencimento AS Vencimento,
		                            CASE 
			                            WHEN (
			                                    CASE
						                            WHEN CONVERT(INT,MAX(MC.seq_categoria)) = MIN(MC.seq_categoria) 
						                            THEN CONVERT(INT,MAX(MC.seq_categoria))
						                            ELSE 5
					                            END
				                              ) = 5
			                            THEN FXa.val_valor_faturado+FXe.val_valor_faturado
			                            ELSE FXa.val_valor_faturado
		                            END AS Valor_Agua,
		                            CASE 
			                            WHEN (
			                                    CASE
						                            WHEN CONVERT(INT,MAX(MC.seq_categoria)) = MIN(MC.seq_categoria) 
						                            THEN CONVERT(INT,MAX(MC.seq_categoria))
						                            ELSE 5
					                            END
				                              ) = 5
			                            THEN FXa.val_valor_faturado+FXe.val_valor_faturado 
			                            ELSE FXe.val_valor_faturado 
		                            END AS Valor_Esgoto,
                                    --FXa.val_valor_faturado AS Valor_Agua,
                                    --FXe.val_valor_faturado AS Valor_Esgoto,
                                    CASE
                                        WHEN SUM(S.val_servico) - MAX(F.val_valor_credito) IS NULL
                                        THEN 0.00
                                        ELSE SUM(S.val_servico) - MAX(F.val_valor_credito)
                                    END AS Valor_Credito,
                                    CASE
                                        WHEN MAX(F.val_desconto) IS NULL
                                        THEN 0.00 
                                        ELSE MAX(F.val_desconto)
                                    END AS Valor_Reducao,
                                    CASE
                                        WHEN ABS(MAX(FIDir.val_valor_calculado)) IS NULL
                                        THEN 0.00
                                        ELSE ABS(max(FIDir.val_valor_calculado))
                                    END AS Valor_IR,
                                    CASE
                                        WHEN ABS(max(FIDcsll.val_valor_calculado)) IS NULL
                                        THEN 0.00
                                        ELSE ABS(max(FIDcsll.val_valor_calculado)) 
                                    END AS Valor_CSLL,
                                    CASE
                                        WHEN ABS(max(FIDpis.val_valor_calculado)) IS NULL
                                        THEN 0.00
                                        ELSE ABS(max(FIDpis.val_valor_calculado)) 
                                    END AS Valor_PIS,
                                    CASE
                                        WHEN ABS(max(FIDcofins.val_valor_calculado)) IS NULL
                                        THEN 0.00
                                        ELSE ABS(max(FIDcofins.val_valor_calculado))
                                    END AS Valor_COFINS,
                                    CASE 
                                        WHEN MAX(FC.seq_categoria) IS NOT NULL AND MIN(FC.seq_categoria) IS NOT NULL
                                        THEN 
                                            CASE
                                                WHEN CONVERT(INT,MAX(MC.seq_categoria)) = MIN(MC.seq_categoria) 
                                                THEN CONVERT(INT,MAX(MC.seq_categoria))
                                                ELSE 5
                                            END
                                        ELSE CONVERT(INT,MAX(MC.seq_categoria))
                                    END AS Categoria,	
                                    CASE 
                                        WHEN max(MCr.val_numero_economia) IS NULL  
                                        THEN 0  
                                        ELSE CONVERT(INT,max(MCr.val_numero_economia))
                                    END AS Eco_Res,
                                    CASE 
                                        WHEN MAX(MCc.val_numero_economia) IS NULL 
                                        THEN 0 
                                        ELSE CONVERT(INT,max(MCc.val_numero_economia))
                                    END AS Eco_Com, 
                                    CASE 
                                        WHEN max(MCi.val_numero_economia) IS NULL
                                        THEN 0 
                                        ELSE CONVERT(INT,max(MCi.val_numero_economia))
                                    END AS Eco_Ind, 
                                    CASE 
                                        WHEN max(MCp.val_numero_economia) IS NULL 
                                        THEN 0 
                                        ELSE CONVERT(INT,max(MCp.val_numero_economia))
                                    END AS Eco_Pub, 
                                    CASE 
                                        WHEN max(MCs.val_numero_economia) IS NULL
                                        THEN 0 
                                        ELSE CONVERT(INT,max(MCs.val_numero_economia)) 
                                    END AS Eco_Soc,
                                    CASE
                                        WHEN M.val_consumo_rateado IS NULL
                                        THEN 0
                                        ELSE M.val_consumo_rateado 
                                    END AS Consumo_rateado,
                                    CASE
                                        WHEN max(F.val_valor_credito) IS NULL
                                        THEN 0.00
                                        ELSE max(F.val_valor_credito) 
                                    END AS Valor_Saldo_Debito,
                                    'S' AS Flag_Lido,
			                        CASE
				                        WHEN M.ind_situacao_movimento = 'R'
				                        THEN 'N'
    				                    WHEN M.ind_situacao_movimento = 'F'
				                        THEN 'S'
				                        ELSE M.ind_fatura_emitida 
			                        END AS Flag_faturado,
                                    CASE
                                                WHEN max(MO.cod_ocorrencia) <> min(MO.cod_ocorrencia)
                                                THEN CONVERT(INT,MAX(MO.cod_ocorrencia))
                                                ELSE NULL
                                    END AS Ocorrencia2,
                                    M.ind_situacao_movimento AS Flag_situacao_movimento
                                    
                                FROM ONP_MOVIMENTO M
                                LEFT JOIN ONP_FATURA F ON F.seq_matricula = M.seq_matricula and F.cod_referencia = M.cod_referencia
                                LEFT JOIN ONP_MATRICULA_SERVICO MS ON MS.seq_matricula = M.seq_matricula
                                LEFT JOIN ONP_SERVICO S ON S.seq_servico = MS.seq_servico
                                LEFT JOIN ONP_ROTEIRO R  ON R.seq_roteiro = M.seq_roteiro
                                LEFT JOIN ONP_MOVIMENTO_TAXA Me ON Me.seq_matricula = M.seq_matricula AND Me.seq_taxa = 2
                                LEFT JOIN ONP_MOVIMENTO_CATEGORIA MC ON MC.seq_matricula = M.seq_matricula
                                LEFT JOIN ONP_MOVIMENTO_CATEGORIA MCr ON MCr.seq_matricula = M.seq_matricula AND MCr.seq_categoria = 1
                                LEFT JOIN ONP_MOVIMENTO_CATEGORIA MCc ON MCc.seq_matricula = M.seq_matricula AND MCc.seq_categoria = 2
                                LEFT JOIN ONP_MOVIMENTO_CATEGORIA MCi ON MCi.seq_matricula = M.seq_matricula AND MCi.seq_categoria = 3
                                LEFT JOIN ONP_MOVIMENTO_CATEGORIA MCp ON MCp.seq_matricula = M.seq_matricula AND MCp.seq_categoria = 4
                                LEFT JOIN ONP_MOVIMENTO_CATEGORIA MCs ON MCs.seq_matricula = M.seq_matricula AND MCs.seq_categoria = 6
                                LEFT JOIN ONP_MOVIMENTO_OCORRENCIA MO ON MO.seq_matricula = M.seq_matricula AND MO.cod_referencia in (SELECT MAX(cod_referencia)FROM ONP_ROTEIRO)
                                LEFT JOIN ONP_MATRICULA_DIADEMA MD ON MD.seq_matricula = M.seq_matricula
                                LEFT JOIN ONP_FATURA_CATEGORIA FC ON FC.seq_fatura = F.seq_fatura and  FC.seq_matricula = M.seq_matricula
                                LEFT JOIN ONP_FATURA_CATEGORIA FCr ON FCr.seq_fatura = F.seq_fatura and  FCr.seq_matricula = M.seq_matricula AND (MAX(FC.seq_categoria) = 2 OR MAX(FC.seq_categoria) = 3)
                                LEFT JOIN ONP_FATURA_TAXA FXa ON FXa.seq_matricula = M.seq_matricula AND FXa.seq_taxa = 1 AND FXa.cod_referencia = M.cod_referencia
                                LEFT JOIN ONP_FATURA_TAXA FXe ON FXe.seq_matricula = M.seq_matricula AND FXe.seq_taxa = 2 AND FXe.cod_referencia = M.cod_referencia
                                LEFT JOIN ONP_FATURA_IMPOSTO_DIADEMA FIDir ON FIDir.seq_matricula = M.seq_matricula AND FIDir.cod_imposto = 'IRRF'
                                LEFT JOIN ONP_FATURA_IMPOSTO_DIADEMA FIDcsll ON FIDcsll.seq_matricula = M.seq_matricula AND FIDcsll.cod_imposto = 'CSLL'
                                LEFT JOIN ONP_FATURA_IMPOSTO_DIADEMA FIDpis ON FIDpis.seq_matricula = M.seq_matricula AND FIDpis.cod_imposto = 'PIS'
                                LEFT JOIN ONP_FATURA_IMPOSTO_DIADEMA FIDcofins ON FIDcofins.seq_matricula = M.seq_matricula AND FIDcofins.cod_imposto = 'COFINS'
		                        
								WHERE M.dat_leitura IS NOT NULL															
                                {0}
								GROUP BY 
                                         M.seq_matricula
                                        ,R.seq_grupo_fatura 
                                        ,M.val_leitura_atribuida
                                        ,M.val_leitura_real
                                        ,M.val_consumo_medio
                                        ,M.val_consumo_rateado
                                        ,M.dat_leitura_anterior
                                        ,M.dat_leitura
                                        ,MD.val_fraudes 
                                        ,MD.ind_cortou_ligacao 
                                        ,M.cod_agente 
                                        ,MD.ind_calcula_fatura
                                        ,MD.ind_emite_fatura
                                        ,M.cod_referencia
                                        ,M.dat_vencimento
                                        ,M.ind_fatura_emitida
                                        ,M.val_consumo_atribuido
                                        ,M.val_consumo_medido
                                        ,M.val_consumo_estimado
                                        ,Me.val_consumo_estimado
                                        ,M.ind_situacao_movimento
										,FXa.val_valor_faturado
										,FXe.val_valor_faturado
                               ", OnpFaturaF);
                        break;
                    }
                case "VOLTA_ALTERACAO":
                    {

                        Sql = @"
                            SELECT DISTINCT
								R.seq_grupo_fatura AS Grupo,
                                MA_CDC.seq_matricula AS CDC,
								R.cod_referencia AS referencia,
								CONVERT(nchar(10),MA_CP.des_conteudo_novo,1) AS Complemento,
                                CONVERT(nchar(11),MA_HD.des_conteudo_novo,1) AS Medidor,
								CONVERT(nchar(35),MA_NM.des_conteudo_novo,1) AS Nome_Consumidor,
								MA_NI.des_conteudo_novo AS Numero_Imovel,
								MA_OB.des_conteudo_novo AS observacao
                            FROM 
                                ONP_MATRICULA_ALTERACAO MA_CDC
								LEFT JOIN  ONP_ROTEIRO R ON R.seq_roteiro IS NOT NULL
								LEFT JOIN  ONP_MATRICULA_ALTERACAO MA_HD ON MA_CDC.seq_matricula = MA_HD.seq_matricula AND MA_HD.ind_dado_alterado = 'HD'
								LEFT JOIN  ONP_MATRICULA_ALTERACAO MA_CP ON MA_CDC.seq_matricula = MA_CP.seq_matricula AND MA_CP.ind_dado_alterado = 'CP'
								LEFT JOIN  ONP_MATRICULA_ALTERACAO MA_NM ON MA_CDC.seq_matricula = MA_NM.seq_matricula AND MA_NM.ind_dado_alterado = 'NM'																								
								LEFT JOIN  ONP_MATRICULA_ALTERACAO MA_NI ON MA_CDC.seq_matricula = MA_NI.seq_matricula AND MA_NI.ind_dado_alterado = 'NI'																								
								LEFT JOIN  ONP_MATRICULA_ALTERACAO MA_OB ON MA_CDC.seq_matricula = MA_OB.seq_matricula AND MA_OB.ind_dado_alterado = 'OB'
                                
                           ";

                        break;
                    }

                case "VOLTA_NOVO_REGISTRO":
                    {
                        Sql = @"
	                        SELECT 
		                        R.seq_grupo_fatura AS Grupo,
		                        R.seq_roteiro AS Rota,
		                        R.dat_base AS referencia,
		                        L.des_logradouro AS Logradouro,
		                        M.val_numero_imovel AS Numero,
		                        M.des_complemento AS Complemento,
		                        F.cod_hidrometro AS Medidor,
		                        M.nom_cliente AS Nome,
		                        MA.des_conteudo_novo AS OBS
	                        FROM 
		                        ONP_MATRICULA M,
		                        ONP_LOGRADOURO L,
		                        ONP_MATRICULA_ALTERACAO MA,
		                        ONP_ROTEIRO R,
		                        ONP_FATURA F
	                        WHERE 
		                        F.seq_matricula = M.seq_matricula
		                        AND L.seq_logradouro = M.seq_logradouro
		                        AND M.seq_matricula = MA.seq_matricula
		                        AND F.seq_roteiro = R.seq_roteiro                                
                           ";
                        break;
                    }

            }

            return Sql;
        }
    }
}
