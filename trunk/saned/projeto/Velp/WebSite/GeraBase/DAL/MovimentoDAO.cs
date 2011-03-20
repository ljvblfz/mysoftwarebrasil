using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using GDA;
using GeraBase.Model;
using Data.Helper;
using System.Data.SqlClient;

namespace GeraBase.DAL
{
    public class MovimentoDAO : BaseDAO<MovimentoONP>
    {
        public List<MovimentoONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal, int agente, int pagina)
        {
            List<MovimentoONP> listaMovimento = new List<MovimentoONP>();

            string sql = @"
                            DECLARE @pagina INT
                            DECLARE @ultimoRegistro INT
                            DECLARE @primeiroRegistro INT
                            DECLARE @totalPagina INT
                            SET @totalPagina = 50000
                            SET @pagina = ?numeroPagina
                            SET @ultimoRegistro = (@pagina*@totalPagina)-1
                            SET @primeiroRegistro = ((@pagina*@totalPagina) - (@totalPagina))
                            SELECT
                            seq_matricula 
                            ,ind_situacao_movimento 
                            ,seq_roteiro                             
                            ,cod_referencia 
                            ,cod_agente  
                            ,cod_hidrometro 
                            ,val_numero_leituras 
                            ,dat_vencimento          
                            ,val_consumo_medio 
                            ,cod_banco   
                            ,cod_banco_agencia 
                            ,des_banco_debito               
                            ,des_banco_agencia_debito 
                            ,ind_leitura_divergente 
                            ,ind_fatura_emitida 
                            ,val_impressoes 
                            ,ind_entrega_especial 
                            ,dat_leitura_anterior    
                            ,dat_proxima_leitura     
                            ,val_leitura_anterior 
                            ,val_consumo_troca 
                            ,val_quantidade_pendente 
                            ,dat_troca
                            FROM (SELECT ROW_NUMBER()
                            OVER (ORDER BY L.CDC)AS Row,
		                            L.cdc AS seq_matricula, 
		                            'P' AS ind_situacao_movimento, 
		                            CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		                            CONVERT(char(7), G.referencia, 102) AS cod_referencia,
		                            ?agente AS cod_agente,
		                            L.medidor AS cod_hidrometro,
		                            0 AS val_numero_leituras,
		                            L.data_vencimento AS dat_vencimento, 
		                            L.media AS val_consumo_medio,
		                            L.banco AS cod_banco,
		                            L.agencia AS cod_banco_agencia,
		                            CONVERT(varchar(30),Banco) AS des_banco_debito,
		                            CONVERT(varchar(20),Agencia) AS des_banco_agencia_debito,
		                            'N' AS ind_leitura_divergente,
		                            'N' AS ind_fatura_emitida,
		                            0 AS val_impressoes,  
		                            CasE 	
		                            when (ISNULL(L.endereco_entrega,'') <> '') AND (L.banco > 0) THEN '5' 
		                            when (ISNULL(L.endereco_entrega,'') <> '') THEN '2' 
		                            when (L.banco > 0) THEN '1'
		                            ELSE '0' 
		                            END AS ind_entrega_especial,
		                            CONVERT( datetime, 
		                            CONVERT(char(8), 
					                              ISNULL(
							                               ISNULL( H.data_leitura, 
													                             (
														                            CASE
															                            WHEN L.Data_Inst_HD IS NULL
															                            THEN G.data_leitura+30
															                            ELSE L.Data_Inst_HD+30
														                            END
													                              )
									                              )
							                               , G.referencia
							                              )
				                            , 112)
		                            ,102
		                            ) AS dat_leitura_anterior, 
		                            G.data_proxima_leitura AS dat_proxima_leitura,
		                            CasE WHEN ISNULL(
		                            (
			                            CasE WHEN (
						                            (
							                            L.Data_Inst_HD > ( CASE 
													                            WHEN H.data_leitura IS NULL
													                            THEN GETDATE()
													                            ELSE H.data_leitura
												                            END
											                              )
						                            ) and (
								                            ISNULL(
										                            Ident_Ligacao_Nova,''
									                               ) != ''
							                               )
					                               ) THEN '' ELSE 1 END
		                            ), 'N') = 0 THEN ISNULL(L.leitura_inicial_hd, 0) ELSE ISNULL((CasE WHEN H.data_leitura is null THEN ISNULL(L.leitura_inicial_hd,0) ELSE ISNULL(H.leitura,0) END), 0) END AS val_leitura_anterior, 

		                            CASE 
		                            WHEN L.Data_Inst_HD >  H.Data_Leitura
		                            THEN  H.Consumo
		                            ELSE null 
		                            END AS val_consumo_troca,
		                            isnull(L.qtde_debitos,0) AS val_quantidade_pendente,
		                            NULL AS dat_troca
		                            FROM	
		                            IDA_GRUPOS G, 
		                            IDA_LOGRADOUROS E, 
		                            IDA_LIGACOES L
		                            LEFT OUTER JOIN IDA_HISTORICOS_CONSUMO H ON L.cdc = H.cdc 
										                            AND L.grupo = H.grupo
										                            AND H.referencia = (SELECT max(referencia) FROM IDA_HISTORICOS_CONSUMO WHERE CDC = L.CDC) 
		                            WHERE	
		                            L.grupo = G.grupo
		                            AND E.Codigo = L.Codigo_Logradouro
		                            AND E.grupo = G.grupo
	                                AND	L.grupo = ?grupo
	                                AND	L.rota = ?rotaInicial
                            )
                            AS crm_empresa2
                            WHERE Row between @primeiroRegistro AND @ultimoRegistro
                          ";

            listaMovimento = CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?agente", agente), new GDAParameter("?numeroPagina", pagina));

            return listaMovimento;
        }

        #region OBSOLETOS

        public string Lista2(int grupo,int rota, int agente)
        {
            // Instancia do objeto de conexao com o banco de dados
            string connectionString = Configuration.ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            // Abre a conexão
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();

            string sql = @"
	                        SELECT	
		                        L.cdc AS seq_matricula, 
		                        'P' AS ind_situacao_movimento, 
		                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		                        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
		                        "+agente+@" AS cod_agente,
		                        L.medidor AS cod_hidrometro,
		                        0 AS val_numero_leituras,
		                        L.data_vencimento AS dat_vencimento, 
		                        L.media AS val_consumo_medio,
		                        L.banco AS cod_banco,
		                        L.agencia AS cod_banco_agencia,
		                        CONVERT(varchar(30),Banco) AS des_banco_debito,
		                        CONVERT(varchar(20),Agencia) AS des_banco_agencia_debito,
		                        'N' AS ind_leitura_divergente,
		                        'N' AS ind_fatura_emitida,
		                        0 AS val_impressoes,  
		                        CasE 	
			                        when (ISNULL(L.endereco_entrega,'') <> '') AND (L.banco > 0) THEN '5' 
			                        when (ISNULL(L.endereco_entrega,'') <> '') THEN '2' 
			                        when (L.banco > 0) THEN '1'
		                        ELSE '0' 
		                        END AS ind_entrega_especial,
		                        CONVERT( datetime, 
						                          CONVERT(char(8), 
										                          ISNULL(
													                       ISNULL( H.data_leitura, 
																								 (
																									CASE
																										WHEN L.Data_Inst_HD IS NULL
																										THEN G.data_leitura+30
																										ELSE L.Data_Inst_HD+30
																									END
																								  )
														                          )
														                   , G.referencia
																		  )
															, 112)
										 ,102
								) AS dat_leitura_anterior, 
		                        G.data_proxima_leitura AS dat_proxima_leitura,
		                        CasE WHEN ISNULL(
							                        (
								                        CasE WHEN (
											                        (
												                        L.Data_Inst_HD > ( CASE 
																		                        WHEN H.data_leitura IS NULL
																		                        THEN GETDATE()
																		                        ELSE H.data_leitura
																	                        END
																                          )
											                        ) and (
													                        ISNULL(
															                        Ident_Ligacao_Nova,''
														                           ) != ''
												                           )
										                           ) THEN '' ELSE 1 END
							                        ), 'N') = 0 THEN ISNULL(L.leitura_inicial_hd, 0) ELSE ISNULL((CasE WHEN H.data_leitura is null THEN ISNULL(L.leitura_inicial_hd,0) ELSE ISNULL(H.leitura,0) END), 0) END AS val_leitura_anterior, 
                        		
		                        CASE 
			                         WHEN L.Data_Inst_HD >  H.Data_Leitura
			                         THEN  H.Consumo
			                         ELSE null 
		                        END AS val_consumo_troca,
		                        isnull(L.qtde_debitos,0) AS val_quantidade_pendente,
		                        NULL AS dat_troca
	                        FROM	
		                        IDA_GRUPOS G, 
		                        IDA_LOGRADOUROS E, 
		                        IDA_LIGACOES L
	                          LEFT OUTER JOIN IDA_HISTORICOS_CONSUMO H ON L.cdc = H.cdc 
															                        AND L.grupo = H.grupo
															                        AND H.referencia = (SELECT max(referencia) FROM IDA_HISTORICOS_CONSUMO WHERE CDC = L.CDC) 
	                        WHERE	
	                        L.grupo = G.grupo
	                        AND E.Codigo = L.Codigo_Logradouro
                            AND E.grupo = G.grupo
	                        AND	L.grupo = " + grupo + @"
	                        AND	L.rota BETWEEN " + rota + @" AND " + rota + @"
                          ";
            cmd.CommandText = sql;
            IDataReader dReader = cmd.ExecuteReader();
            int cont = 0;
            object xml = "";
            while (dReader.Read())
            {
                xml = dReader[cont];
                break;
            }

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] arrayByte64 = encoding.GetBytes(xml.ToString());
            string base64String = System.Convert.ToBase64String(arrayByte64);
            return base64String;
        }

        public List<MovimentoONP> Lista_old(int grupo, DateTime referencia, int rotaInicial, int rotaFinal,int agente, int pagina)
        {
            List<MovimentoONP> listaMovimento = new List<MovimentoONP>();

            string sql = @"
	                        SELECT	DISTINCT
--								(
--			                        SELECT 
--				                        Data_Leitura 
--			                        FROM IDA_HISTORICOS_CONSUMO
--			                        WHERE 
--				                        CDC = L.CDC
--				                        AND grupo = L.grupo
--				                        AND referencia = (SELECT max(referencia) FROM IDA_HISTORICOS_CONSUMO WHERE CDC = L.CDC)
--		                        ),
		                        L.cdc AS seq_matricula, 
		                        'P' AS ind_situacao_movimento, 
		                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		                        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
		                        ?agente AS cod_agente,
		                        L.medidor AS cod_hidrometro,
		                        0 AS val_numero_leituras,
		                        L.data_vencimento AS dat_vencimento, 
		                        L.media AS val_consumo_medio,
		                        L.banco AS cod_banco,
		                        L.agencia AS cod_banco_agencia,
		                        CONVERT(varchar(30),Banco) AS des_banco_debito,
		                        CONVERT(varchar(20),Agencia) AS des_banco_agencia_debito,
		                        'N' AS ind_leitura_divergente,
		                        'N' AS ind_fatura_emitida,
		                        0 AS val_impressoes,  
		                        CasE 	
			                        when (isnull(L.endereco_entrega,'') <> '') AND (L.banco > 0) THEN '5' 
			                        when (isnull(L.endereco_entrega,'') <> '') THEN '2' 
			                        when (L.banco > 0) THEN '1'
		                        ELSE '0' 
		                        END AS ind_entrega_especial,
		                        CONVERT( datetime, 
						                          CONVERT(char(8), 
										                          isnull(
													                        CASE 
														                        WHEN H.data_leitura is null 
														                        THEN (
                                                                                        CASE
                                                                                            WHEN L.Data_Inst_HD IS NULL
                                                                                            THEN G.data_leitura+30
                                                                                            ELSE L.Data_Inst_HD+30
                                                                                        END
                                                                                        --IsNull(L.Data_Inst_HD, ( + G.data_leitura-30)) 
                                                                                      )
														                        ELSE H.data_leitura 
													                        END, G.referencia), 112) ) AS dat_leitura_anterior, 
		                        G.data_proxima_leitura AS dat_proxima_leitura,
		                        CasE WHEN isnull(
							                        (
								                        CasE WHEN (
											                        (
												                        L.Data_Inst_HD > ( CASE 
																		                        WHEN H.data_leitura IS NULL
																		                        THEN getdate()
																		                        ELSE H.data_leitura
																	                        END
																                          )
											                        ) and (
													                        IsNull(
															                        Ident_Ligacao_Nova,''
														                           ) != ''
												                           )
										                           ) THEN '' ELSE 1 END
							                        ), 'N') = 0 THEN isnull(L.leitura_inicial_hd, 0) ELSE isnull((CasE WHEN H.data_leitura is null THEN isnull(L.leitura_inicial_hd,0) ELSE isnull(H.leitura,0) END), 0) END AS val_leitura_anterior, 
                        		
		                        CASE 
			                         WHEN (
						                        L.Data_Inst_HD > (
											                        SELECT 
												                        Data_Leitura 
											                        FROM IDA_HISTORICOS_CONSUMO
											                        WHERE 
												                        CDC = L.CDC
												                        AND referencia = (SELECT MAX(referencia) FROM IDA_HISTORICOS_CONSUMO WHERE CDC = L.CDC)
										                         )
				                           ) 
			                         THEN (
					                        SELECT 
						                        Consumo
					                        FROM IDA_HISTORICOS_CONSUMO
					                        WHERE 
						                        CDC = L.CDC
						                        AND referencia = (SELECT MAX(referencia) FROM IDA_HISTORICOS_CONSUMO WHERE CDC = L.CDC)
				                          )  
			                         ELSE null 
		                        END AS val_consumo_troca,
		                        isnull(L.qtde_debitos,0) AS val_quantidade_pendente,
		                        NULL AS dat_troca
	                        FROM	
		                        IDA_GRUPOS G, 
		                        IDA_LOGRADOUROS E, 
		                        IDA_LIGACOES L
	                          LEFT OUTER JOIN IDA_HISTORICOS_CONSUMO H ON L.cdc = H.cdc 
															                        AND L.grupo = H.grupo
															                        AND referencia = (SELECT max(referencia) FROM IDA_HISTORICOS_CONSUMO WHERE CDC = L.CDC) 

	                        WHERE	
	                        L.grupo = G.grupo
	                        and E.Codigo = L.Codigo_Logradouro
	                        AND	L.grupo = ?Grupo
	                        AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
            
                            ORDER BY L.CDC
                          ";
            
            List<MovimentoONP> listaMovimentoAUX = new List<MovimentoONP>();

            //GDAParameter[] parametros = new GDAParameter[] { new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal), new GDAParameter("?agente", agente) };
            //listaMovimentoAUX = CurrentPersistenceObject.LoadDataWithSortExpression(sql, new InfoSortExpression("ORDER BY L.CDC"), new InfoPaging(1, 50), parametros);

            listaMovimentoAUX = CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal), new GDAParameter("?agente", agente));
            listaMovimento = new ExtensionMetodos<MovimentoONP>().RetornaPagina(listaMovimentoAUX, pagina, 50);
            
            return listaMovimento;
        }

        /// <summary>
        ///  Retorna os dados de numero de leituras
        /// </summary>
        /// <param name="CDC"></param>
        /// <returns></returns>
        private int RetornaNumeroLeitura(int CDC)
        {
            int retorno = 0;
            string sql = @"
                            SELECT 
                                Convert(int,(SELECT max(referencia) FROM IDA_HISTORICOS_CONSUMO WHERE CDC = 26299)-Data_Inst_HD)/30
                            FROM IDA_LIGACOES
                            WHERE 
                                CDC = ?CDC
                          ";
            object saida = CurrentPersistenceObject.ExecuteScalar(sql, new GDAParameter("?CDC", CDC));

            if (saida != null)
            {
                retorno = int.Parse(saida.ToString());
            }
            return retorno;
        }

        #endregion
    }
}
