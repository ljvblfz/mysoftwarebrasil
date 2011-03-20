using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public class QualidadeAguaDAO : BaseDAO<QualidadeAguaONP>
    {

        //Metodo que retorna a qualidade da agua
        #region Metodo Geral


        /// <summary>
        ///  Retorna a lista de qualidade da agua
        ///   
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<QualidadeAguaONP> ListaQualidadeAgua(int grupo)
        {
            string sql = @"
		                    SELECT 	
			                    ?Grupo AS seq_zona_abastecimento,
			                    (
				                    SELECT referencia
					                    FROM IDA_GRUPOS
					                    WHERE grupo = ?Grupo ---PARAMETRO INFORMADO
					                    --AND data_processamento is null -- VERIFICAR  
			                    ) AS dat_referencia, 
			                    1 AS seq_parametro, 
			                    'PH' AS des_parametro,
			                    ISNULL(pH_Amostras,150) AS val_previstas, 
			                    ISNULL(pH_Amostras,150) AS val_realizadas, 
			                    ISNULL(pH_Nao_Conformes, 0) AS val_fora_limite, 
			                    CONVERT (NUMERIC (5,2), REPLACE(pH, ',', '.')) AS val_media
		                    FROM  IDA_QUALIDADE_AGUA
		                    WHERE	
			                    grupo = ?Grupo 
			                    AND data = 
					                       (  
						                       SELECT MAX(data)
						                       FROM IDA_QUALIDADE_AGUA
						                       WHERE grupo = ?Grupo
						                    )

		                    UNION ALL
                    		
		                    SELECT 	
			                    grupo AS seq_zona_abastecimento,
			                    (
				                    SELECT referencia
					                    FROM IDA_GRUPOS
					                    WHERE grupo = ?Grupo ---PARAMETRO INFORMADO
					                    --AND data_processamento is null -- VERIFICAR  
			                    ) AS dat_referencia, 
			                    2 AS seq_parametro, 
			                    'CLORO RESIDUAL' AS des_parametro,
			                    ISNULL(cloro_Amostras,150) AS val_previstas, 
			                    ISNULL(cloro_Amostras,150) AS val_realizadas, 
			                    ISNULL(Cloro_Nao_Conformes,0) AS val_fora_limite, 
			                    CONVERT (NUMERIC (5,2), REPLACE(Cloro, ',', '.')) AS val_media
		                    FROM 	IDA_QUALIDADE_AGUA
		                    WHERE	grupo =?Grupo 
				                    AND data = 
							                    (  
							                       SELECT MAX(data)
							                       FROM IDA_QUALIDADE_AGUA
							                       WHERE grupo = ?Grupo
							                     )	
		                    UNION ALL
                    		
		                    SELECT 	
			                    grupo AS seq_zona_abastecimento,
			                    (
				                    SELECT referencia
					                    FROM IDA_GRUPOS
					                    WHERE grupo =?Grupo ---PARAMETRO INFORMADO 
					                    --AND data_processamento is null -- VERIFICAR 
			                    ) AS dat_referencia, 
			                    3 AS seq_parametro, 
			                    'COR APARENTE' AS des_parametro,
			                    ISNULL(cor_Amostras,150) AS val_previstas, 
			                    ISNULL(cor_Amostras,150) AS val_realizadas, 
			                    ISNULL(Cor_Nao_Conformes, 0) AS val_fora_limite, 
			                    CONVERT (NUMERIC (5,2), REPLACE(Cor, ',', '.')) AS val_media
		                    FROM 	IDA_QUALIDADE_AGUA
		                    WHERE	grupo =?Grupo
				                    AND data = 
							                    (  
							                       SELECT MAX(data)
							                       FROM IDA_QUALIDADE_AGUA
							                       WHERE grupo =?Grupo
							                    )
		                    UNION ALL
                    		
		                    SELECT 	
			                    grupo AS seq_zona_abastecimento,
			                    (
				                    SELECT referencia
					                    FROM IDA_GRUPOS
					                    WHERE grupo =?Grupo ---PARAMETRO INFORMADO 
					                    --AND data_processamento is null -- VERIFICAR 
			                    ) AS dat_referencia, 
			                    4 AS seq_parametro, 
			                    'TURBIDEZ' AS des_parametro,
			                    ISNULL(turbidez_Amostras,150) AS val_previstas, 
			                    ISNULL(turbidez_Amostras,150) AS val_realizadas, 
			                    ISNULL(Turbidez_Nao_Conformes, 0) AS val_fora_limite, 
			                    CONVERT (NUMERIC (5,2), REPLACE(Turbidez, ',', '.')) AS val_media
		                    FROM 	IDA_QUALIDADE_AGUA
		                    WHERE	grupo =?Grupo 
				                    AND data = 
							                    (  SELECT MAX(data)
							                       FROM IDA_QUALIDADE_AGUA
							                       WHERE grupo =?Grupo
							                    )
		                    UNION ALL
                    		
		                    SELECT 	
			                    grupo AS seq_zona_abastecimento,
			                    (
				                    SELECT referencia
					                    FROM IDA_GRUPOS
					                    WHERE grupo =?Grupo ---PARAMETRO INFORMADO 
					                    --AND data_processamento is null -- VERIFICAR 
			                    ) AS dat_referencia, 
			                    5 AS seq_parametro, 
			                    'FLUORETO' AS des_parametro,
			                    ISNULL(fluoreto_Amostras,150) AS val_previstas, 
			                    ISNULL(fluoreto_Amostras,150) AS val_realizadas, 
			                    ISNULL(Fluoreto_Nao_Conformes, 0) AS val_fora_limite, 
			                    CONVERT (NUMERIC (5,2), REPLACE(Fluoreto, ',', '.')) AS val_media
		                    FROM 	IDA_QUALIDADE_AGUA
		                    WHERE	grupo =?Grupo 
				                    AND data = 
							                    (  SELECT MAX(data)
							                       FROM IDA_QUALIDADE_AGUA
							                       WHERE grupo =?Grupo
							                    )

                            UNION ALL
                    		
		                    SELECT  	
			                    grupo AS seq_zona_abastecimento,
			                    (
				                    SELECT referencia
					                    FROM IDA_GRUPOS
					                    WHERE grupo =?Grupo ---PARAMETRO INFORMADO 
					                    --AND data_processamento is null -- VERIFICAR 
			                    ) AS dat_referencia, 
			                    6 AS seq_parametro, 
							    'COLIF. TOTAIS' AS des_parametro,
							    ISNULL(coliformes_Totais_Amostras,150) AS val_previstas, 
							    ISNULL(coliformes_Totais_Amostras,150) AS val_realizadas, 
							    ISNULL(Coliformes_Totais_Nao_Conformes, 0) AS val_fora_limite, 
							    CONVERT (NUMERIC (5,2), REPLACE(Coliformes_Totais, ',', '.')) AS val_media
		                    FROM 	IDA_QUALIDADE_AGUA
		                    WHERE	grupo =?Grupo 
				                    AND data = 
							                    (  SELECT MAX(data)
							                       FROM IDA_QUALIDADE_AGUA
							                       WHERE grupo =?Grupo
							                    )
		                    UNION ALL
                    		
		                    SELECT  	
			                    grupo AS seq_zona_abastecimento,
			                    (
				                    SELECT referencia
					                    FROM IDA_GRUPOS
					                    WHERE grupo =?Grupo ---PARAMETRO INFORMADO 
					                    --AND data_processamento is null -- VERIFICAR 
			                    ) AS dat_referencia, 
			                    7 AS seq_parametro, 
			                    'E. COLI' AS des_parametro,
			                    ISNULL(coliformes_Termotolerantes_Amostras,150) AS val_previstas, 
			                    ISNULL(coliformes_Termotolerantes_Amostras,150) AS val_realizadas, 
			                    ISNULL(Coliformes_Termotolerantes_Nao_Conformes, 0) AS val_fora_limite, 
			                    CONVERT (NUMERIC (5,2), REPLACE(Coliformes_Termotolerantes, ',', '.')) AS val_media
		                    FROM 	IDA_QUALIDADE_AGUA
		                    WHERE	grupo =?Grupo 
				                    AND data = 
							                    (  SELECT MAX(data)
							                       FROM IDA_QUALIDADE_AGUA
							                       WHERE grupo =?Grupo
							                    )
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }

        #endregion


        //Metodos por partes
        #region Metodos Fragmentados    

        /// <summary>
        ///  Retorna a lista de qualidade da agua
        ///     (dados de 1-PH)
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<QualidadeAguaONP> ListaPh(int grupo)
        {
            string sql = @"
						    SELECT 	
							    (
								    SELECT referencia
									    FROM IDA_GRUPOS
									    WHERE grupo = ?Grupo ---PARAMETRO INFORMADO
                                        --AND data_processamento is null -- VERIFICAR  
							    ) AS dat_referencia, 
							    grupo AS seq_zona_abastecimento,
							    1 AS seq_parametro, 
							    'PH' AS des_parametro,
							    ISNULL(pH_Amostras,150) AS val_previstas, 
							    ISNULL(pH_Amostras,150) AS val_realizadas, 
							    ISNULL(pH_Nao_Conformes, 150) AS val_fora_limite, 
							    CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						    FROM  IDA_QUALIDADE_AGUA
						    WHERE	
                                grupo = ?Grupo 
							    AND data = 
										   (  
                                               SELECT MAX(data)
										       FROM IDA_QUALIDADE_AGUA
										       WHERE grupo = ?Grupo
										    )
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }

        /// <summary>
        ///  Retorna a lista de qualidade da agua
        ///     (dados de 2-CLORO RESIDUAL)
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<QualidadeAguaONP> ListaCloroResidual(int grupo)
        {
            string sql = @"
						    SELECT 	
							    (
								    SELECT referencia
									    FROM IDA_GRUPOS
									    WHERE grupo = ?Grupo ---PARAMETRO INFORMADO
                                        --AND data_processamento is null -- VERIFICAR  
							    ) AS dat_referencia, 
							    grupo AS seq_zona_abastecimento,
							    2 AS seq_parametro, 
							    'CLORO RESIDUAL' AS des_parametro,
							    ISNULL(cloro_Amostras,150) AS val_previstas, 
							    ISNULL(cloro_Amostras,150) AS val_realizadas, 
							    ISNULL(cloro_Amostras, 0) AS val_fora_limite, 
							    CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						    FROM 	IDA_QUALIDADE_AGUA
						    WHERE	grupo =?Grupo 
								    AND data = 
											    (  
                                                   SELECT MAX(data)
											       FROM IDA_QUALIDADE_AGUA
											       WHERE grupo = ?Grupo
                                                 )	
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }


        /// <summary>
        ///  Retorna a lista de qualidade da agua
        ///     (dados de 3-COR APARENTE)
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<QualidadeAguaONP> ListaCorAparente(int grupo)
        {
            string sql = @"
						    SELECT 	
							    (
								    SELECT referencia
									    FROM IDA_GRUPOS
									    WHERE grupo =?Grupo ---PARAMETRO INFORMADO 
									    --AND data_processamento is null -- VERIFICAR 
							    ) AS dat_referencia, 
							    grupo AS seq_zona_abastecimento,
							    3 AS seq_parametro, 
							    'COR APARENTE' AS des_parametro,
							    ISNULL(cor_Amostras,150) AS val_previstas, 
							    ISNULL(cor_Amostras,150) AS val_realizadas, 
							    ISNULL(cor_Amostras, 0) AS val_fora_limite, 
							    CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						    FROM 	IDA_QUALIDADE_AGUA
						    WHERE	grupo =?Grupo
								    AND data = 
											    (  
                                                   SELECT MAX(data)
											       FROM IDA_QUALIDADE_AGUA
											       WHERE grupo =?Grupo
											    )
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }

        /// <summary>
        ///  Retorna a lista de qualidade da agua
        ///     (dados de 4-TURBIDEZ)
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<QualidadeAguaONP> ListaTurbidez(int grupo)
        {
            string sql = @"
						    SELECT 	
							    (
								    SELECT referencia
									    FROM IDA_GRUPOS
									    WHERE grupo =?Grupo ---PARAMETRO INFORMADO 
									    --AND data_processamento is null -- VERIFICAR 
							    ) AS dat_referencia, 
							    grupo AS seq_zona_abastecimento,
							    4 AS seq_parametro, 
							    'TURBIDEZ' AS des_parametro,
							    ISNULL(turbidez_Amostras,150) AS val_previstas, 
							    ISNULL(turbidez_Amostras,150) AS val_realizadas, 
							    ISNULL(turbidez_Amostras, 0) AS val_fora_limite, 
							    CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						    FROM 	IDA_QUALIDADE_AGUA
						    WHERE	grupo =?Grupo 
								    AND data = 
											    (  SELECT MAX(data)
											       FROM IDA_QUALIDADE_AGUA
											       WHERE grupo =?Grupo
											    )
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }

        /// <summary>
        ///  Retorna a lista de qualidade da agua
        ///     (dados de 5-FLUORETO)
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<QualidadeAguaONP> ListaFluoreto(int grupo)
        {
            string sql = @"
						    SELECT 	
							    (
								    SELECT referencia
									    FROM IDA_GRUPOS
									    WHERE grupo =?Grupo ---PARAMETRO INFORMADO 
									    --AND data_processamento is null -- VERIFICAR 
							    ) AS dat_referencia, 
							    grupo AS seq_zona_abastecimento,
							    5 AS seq_parametro, 
							    'FLUORETO' AS des_parametro,
							    ISNULL(fluoreto_Amostras,150) AS val_previstas, 
							    ISNULL(fluoreto_Amostras,150) AS val_realizadas, 
							    ISNULL(fluoreto_Amostras, 0) AS val_fora_limite, 
							    CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						    FROM 	IDA_QUALIDADE_AGUA
						    WHERE	grupo =?Grupo 
								    AND data = 
											    (  SELECT MAX(data)
											       FROM IDA_QUALIDADE_AGUA
											       WHERE grupo =?Grupo
											    )
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }

        /// <summary>
        ///  Retorna a lista de qualidade da agua
        ///     (dados de 6-COLIF. TOTAIS)
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<QualidadeAguaONP> ListaColifTotais(int grupo)
        {
            string sql = @"
						    SELECT 	
							    (
								    SELECT referencia
									    FROM IDA_GRUPOS
									    WHERE grupo =?Grupo ---PARAMETRO INFORMADO 
									    --AND data_processamento is null -- VERIFICAR 
							    ) AS dat_referencia, 
							    grupo AS seq_zona_abastecimento,
							    5 AS seq_parametro, 
							    'FLUORETO' AS des_parametro,
							    ISNULL(fluoreto_Amostras,150) AS val_previstas, 
							    ISNULL(fluoreto_Amostras,150) AS val_realizadas, 
							    ISNULL(fluoreto_Amostras, 0) AS val_fora_limite, 
							    CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						    FROM 	IDA_QUALIDADE_AGUA
						    WHERE	grupo =?Grupo 
								    AND data = 
											    (  SELECT MAX(data)
											       FROM IDA_QUALIDADE_AGUA
											       WHERE grupo =?Grupo
											    )
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }


        /// <summary>
        ///  Retorna a lista de qualidade da agua
        ///     (dados de 7-E. COLI)
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<QualidadeAguaONP> ListaEColi(int grupo)
        {
            string sql = @"
		                    SELECT  	
			                        (
			                            SELECT referencia
				                            FROM IDA_GRUPOS
				                            WHERE grupo =?Grupo ---PARAMETRO INFORMADO 
				                            --AND data_processamento is null -- VERIFICAR 
			                        ) AS dat_referencia, 
			                    grupo AS seq_zona_abastecimento,
			                    7 AS seq_parametro, 
			                    'E. COLI' AS des_parametro,
			                    ISNULL(coliformes_Termotolerantes_Amostras,150) AS val_previstas, 
			                    ISNULL(coliformes_Termotolerantes_Amostras,150) AS val_realizadas, 
			                    ISNULL(coliformes_Termotolerantes_Amostras, 0) AS val_fora_limite, 
			                    CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
		                    FROM 	IDA_QUALIDADE_AGUA
		                    WHERE	grupo =?Grupo 
				                    AND data = 
							                    (  SELECT MAX(data)
							                       FROM IDA_QUALIDADE_AGUA
							                       WHERE grupo =?Grupo
							                    )
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }

        #endregion
    }
    
}
