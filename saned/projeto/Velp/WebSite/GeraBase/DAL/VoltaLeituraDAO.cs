using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;
using System.Globalization;

namespace GeraBase.DAL
{
    public class VoltaLeituraDAO : BaseDAO<VoltaLeitura>
    {
        /// <summary>
        ///     RETORNA UMA LISTA COM TODOS OS DADOS DE LEITURA
        /// </summary>
        /// <returns></returns>
        public List<VoltaLeitura> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM volta_leitura
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        ///     CHECAR SE EXISTEM MAIS ROTAS COM LEITURA MENOR QUE ZERO
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public List<VoltaLeitura> ListaConsumoNegativo(int grupo, DateTime? referencia)
        {
            string sql = @"
                            --CHECAR SE EXISTEM MAIS ROTAS SEM DATA DE LEITURA
                            SELECT --CDC,ROTA,
                                *
                                FROM VOLTA_LEITURA
                                WHERE 
	                                REFERENCIA = CONVERT(dateTime,?referencia,102) AND
	                                GRUPO = ?grupo AND
	                                Consumo_Ajustado < 0
                                ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia));
        }

        /// <summary>
        ///     CHECAR SE EXISTEM MAIS ROTAS COM LEITURA MENOR QUE ZERO
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<VoltaLeitura> ListaConsumoNegativo(int grupo)
        {
            string sql = @"
                            --CHECAR SE EXISTEM MAIS ROTAS SEM DATA DE LEITURA
                            SELECT --CDC,ROTA,
                                *
                                FROM VOLTA_LEITURA
                                WHERE 
	                                GRUPO = ?grupo AND
	                                Consumo_Ajustado < 0
                                ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo));
        }

        /// <summary>
        ///     CHECAR SE EXISTEM MAIS ROTAS SEM DATA DE LEITURA
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<VoltaLeitura> ListaLeituraNula(int grupo)
        {
            string sql = @"
                            --CHECAR SE EXISTEM MAIS ROTAS SEM DATA DE LEITURA
                            SELECT 
                                *
                                FROM VOLTA_LEITURA
                                WHERE 
	                                GRUPO = ?grupo AND
	                                Data_Leitura IS NULL
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo));

        }

        /// <summary>
        ///     CHECAR SE EXISTEM CONSUMIDORES CALCULADOS SEM DIAS DE CONSUMO
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<VoltaLeitura> ListaDiasConsumoNulo(int grupo)
        {
            string sql = @"
                            --CHECAR SE EXISTEM CONSUMIDORES CALCULADOS SEM DIAS DE CONSUMO
                            SELECT --CDC,ROTA,
                                *
                                FROM VOLTA_LEITURA 
	                            WHERE	
		                            GRUPO = ?grupo AND 
		                            Dias_Consumo IS NULL AND 
		                            Flag_Calculo ='S'
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo));

        }

        /// <summary>
        ///     CHECAR VALORES ZERADOS CALCULADOS
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<VoltaLeitura> ListaValoresZerados(int grupo)
        {
            string sql = @"
                            --CHECAR VALORES ZERADOS CALCULADOS
                            SELECT --CDC,ROTA,
                                *
                                FROM VOLTA_LEITURA
	                            WHERE	
		                            GRUPO = ?grupo  AND 
		                            Valor_Agua = 0 AND 
		                            Valor_Esgoto = 0  AND 
		                            Flag_Calculo ='S' AND
		                            Flag_Faturado ='S'
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo));

        }

        /// <summary>
        ///     CHECAR VALORES DE OCORRENCIA NULA
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<VoltaLeitura> ListaOcorrenciaNula(int grupo)
        {
            string sql = @"
                            SELECT --CDC,ROTA,
                                *    
                                FROM VOLTA_LEITURA 
	                            WHERE 
		                            GRUPO = ?grupo  
		                            AND ( Ocorrencia = 0 OR Ocorrencia IS NULL)
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo));
        }

        /// <summary>
        ///  CHECAR SE EXISTEM CONTAS RETIDAS
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<VoltaLeitura> ListaContaRetida()
        {
            string sql = @"
                            SELECT --CDC,ROTA,
                                *    
                                FROM VOLTA_LEITURA 
	                            WHERE 
		                            Flag_Situacao_Movimento = 'R'
                          ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        ///     CHECAR CONSUMIDORES BLOQUEADOS
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<VoltaLeitura> ListaConsumidoBloqueado(int grupo)
        {

            string sql = @"
                            SELECT DISTINCT
                                   L.Grupo
				                  ,L.Setor
				                  ,L.Rota
				                  ,L.CDC
				                  ,L.Leitura_Ajustada
				                  ,L.Leitura_Real
				                  ,L.Data_Leitura
				                  ,L.Consumo_Ajustado
				                  ,L.Esgoto_Ajustado
				                  ,L.Dias_Consumo
				                  ,L.Ocorrencia
				                  ,L.Ident_fraude
				                  ,L.Indic_cortado
				                  ,L.Operador
				                  ,L.Flag_Calculo
				                  ,L.Flag_Emissao
				                  ,L.Referencia
				                  ,MAX(L.Data_Emissao) AS Data_Emissao
				                  ,L.Vencimento
				                  ,L.Valor_Agua
				                  ,L.Valor_Esgoto
				                  ,L.Valor_Credito
				                  ,L.Valor_Reducao
				                  ,L.Valor_IR
				                  ,L.Valor_CSLL
				                  ,L.Valor_PIS
				                  ,L.Valor_COFINS
				                  ,L.Categoria
				                  ,L.Eco_Res
				                  ,L.Eco_Com
				                  ,L.Eco_Ind
				                  ,L.Eco_Pub
				                  ,L.Eco_Soc
				                  ,L.Consumo_Rateado
				                  ,L.Valor_Saldo_Debito
				                  ,L.Flag_Lido
				                  ,L.Flag_Faturado
				                  ,L.Ocorrencia2
				                  ,L.Flag_Situacao_Movimento
				                  ,L.Flag_Repasse
                                  ,'SEM LEITURA'AS Tipo
                                FROM VOLTA_LEITURA L
                                LEFT JOIN IDA_LIGACOES LI ON LI.CDC = L.CDC
                                WHERE 
                                    L.Grupo=?Grupo 
                                    AND Ident_Calculo= 'B' 
                                GROUP BY 
				                   L.Grupo
				                  ,L.Setor
				                  ,L.Rota
				                  ,L.CDC
				                  ,L.Leitura_Ajustada
				                  ,L.Leitura_Real
				                  ,L.Data_Leitura
				                  ,L.Consumo_Ajustado
				                  ,L.Esgoto_Ajustado
				                  ,L.Dias_Consumo
				                  ,L.Ocorrencia
				                  ,L.Ident_fraude
				                  ,L.Indic_cortado
				                  ,L.Operador
				                  ,L.Flag_Calculo
				                  ,L.Flag_Emissao
				                  ,L.Referencia
				                  ,L.Vencimento
				                  ,L.Valor_Agua
				                  ,L.Valor_Esgoto
				                  ,L.Valor_Credito
				                  ,L.Valor_Reducao
				                  ,L.Valor_IR
				                  ,L.Valor_CSLL
				                  ,L.Valor_PIS
				                  ,L.Valor_COFINS
				                  ,L.Categoria
				                  ,L.Eco_Res
				                  ,L.Eco_Com
				                  ,L.Eco_Ind
				                  ,L.Eco_Pub
				                  ,L.Eco_Soc
				                  ,L.Consumo_Rateado
				                  ,L.Valor_Saldo_Debito
				                  ,L.Flag_Lido
				                  ,L.Flag_Faturado
				                  ,L.Ocorrencia2
				                  ,L.Flag_Situacao_Movimento
				                  ,L.Flag_Repasse
                          ";

            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }

        /// <summary>
        ///     CHECAR CONSUMIDORES QUE NÃO FORAM LIDOS
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<VoltaLeitura> ListaNaoLidos(int grupo)
        {

            string sql = @"
                            SELECT DISTINCT
                                   L.Grupo
				                  ,L.Setor
				                  ,L.Rota
				                  ,L.CDC
				                  ,L.Leitura_Ajustada
				                  ,L.Leitura_Real
				                  ,L.Data_Leitura
				                  ,L.Consumo_Ajustado
				                  ,L.Esgoto_Ajustado
				                  ,L.Dias_Consumo
				                  ,L.Ocorrencia
				                  ,L.Ident_fraude
				                  ,L.Indic_cortado
				                  ,L.Operador
				                  ,L.Flag_Calculo
				                  ,L.Flag_Emissao
				                  ,L.Referencia
				                  ,MAX(L.Data_Emissao) AS Data_Emissao
				                  ,L.Vencimento
				                  ,L.Valor_Agua
				                  ,L.Valor_Esgoto
				                  ,L.Valor_Credito
				                  ,L.Valor_Reducao
				                  ,L.Valor_IR
				                  ,L.Valor_CSLL
				                  ,L.Valor_PIS
				                  ,L.Valor_COFINS
				                  ,L.Categoria
				                  ,L.Eco_Res
				                  ,L.Eco_Com
				                  ,L.Eco_Ind
				                  ,L.Eco_Pub
				                  ,L.Eco_Soc
				                  ,L.Consumo_Rateado
				                  ,L.Valor_Saldo_Debito
				                  ,L.Flag_Lido
				                  ,L.Flag_Faturado
				                  ,L.Ocorrencia2
				                  ,L.Flag_Situacao_Movimento
				                  ,L.Flag_Repasse
                                  ,'SEM LEITURA'AS Tipo
                                FROM VOLTA_LEITURA L
                                LEFT JOIN IDA_LIGACOES LI ON LI.CDC = L.CDC
                                WHERE 
                                    L.Grupo=?Grupo 
                                    AND NOT EXISTS (select 1 from VOLTA_LEITURA where LI.CDC = VOLTA_LEITURA.CDC)
                                GROUP BY 
				                   L.Grupo
				                  ,L.Setor
				                  ,L.Rota
				                  ,L.CDC
				                  ,L.Leitura_Ajustada
				                  ,L.Leitura_Real
				                  ,L.Data_Leitura
				                  ,L.Consumo_Ajustado
				                  ,L.Esgoto_Ajustado
				                  ,L.Dias_Consumo
				                  ,L.Ocorrencia
				                  ,L.Ident_fraude
				                  ,L.Indic_cortado
				                  ,L.Operador
				                  ,L.Flag_Calculo
				                  ,L.Flag_Emissao
				                  ,L.Referencia
				                  ,L.Vencimento
				                  ,L.Valor_Agua
				                  ,L.Valor_Esgoto
				                  ,L.Valor_Credito
				                  ,L.Valor_Reducao
				                  ,L.Valor_IR
				                  ,L.Valor_CSLL
				                  ,L.Valor_PIS
				                  ,L.Valor_COFINS
				                  ,L.Categoria
				                  ,L.Eco_Res
				                  ,L.Eco_Com
				                  ,L.Eco_Ind
				                  ,L.Eco_Pub
				                  ,L.Eco_Soc
				                  ,L.Consumo_Rateado
				                  ,L.Valor_Saldo_Debito
				                  ,L.Flag_Lido
				                  ,L.Flag_Faturado
				                  ,L.Ocorrencia2
				                  ,L.Flag_Situacao_Movimento
				                  ,L.Flag_Repasse
                          ";

            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }

        /// <summary>
        ///  ATUALIZA OS DADOS
        /// </summary>
        /// <param name="objVoltaLeitura"></param>
        public void UpdateLeitura(VoltaLeitura objVoltaLeitura)
        {

            // Condicional para resolver data
            GDAParameter paramData_Leitura;
            if (objVoltaLeitura.Data_Leitura == null)
                paramData_Leitura = new GDAParameter("?Data_Leitura", System.DBNull.Value);
            else
                paramData_Leitura = new GDAParameter("?Data_Leitura", objVoltaLeitura.Data_Leitura);

            // Condicional para resolver data
            GDAParameter paramReferencia;
            if (objVoltaLeitura.Referencia == null)
                paramReferencia = new GDAParameter("?Referencia", System.DBNull.Value);
            else
                paramReferencia = new GDAParameter("?Referencia", objVoltaLeitura.Referencia);

            // Condicional para resolver data
            GDAParameter paramData_Emissao;
            if (objVoltaLeitura.Data_Emissao == null)
                paramData_Emissao = new GDAParameter("?Data_Emissao", System.DBNull.Value);
            else
                paramData_Emissao = new GDAParameter("?Data_Emissao", objVoltaLeitura.Data_Emissao);

            // Condicional para resolver data
            GDAParameter paramVencimento;
            if (objVoltaLeitura.Vencimento == null)
                paramVencimento = new GDAParameter("?Vencimento", System.DBNull.Value);
            else
                paramVencimento = new GDAParameter("?Vencimento", objVoltaLeitura.Vencimento);



            GDAParameter paramGrupo; if (objVoltaLeitura.Grupo == null) paramGrupo = new GDAParameter("?Grupo", System.DBNull.Value); else paramGrupo = new GDAParameter("?Grupo", objVoltaLeitura.Grupo);
            GDAParameter paramSetor; if (objVoltaLeitura.Setor == null) paramSetor = new GDAParameter("?Setor", System.DBNull.Value); else paramSetor = new GDAParameter("?Setor", objVoltaLeitura.Setor);
            GDAParameter paramRota; if (objVoltaLeitura.Rota == null) paramRota = new GDAParameter("?Rota", System.DBNull.Value); else paramRota = new GDAParameter("?Rota", objVoltaLeitura.Rota);
            GDAParameter paramCDC; if (objVoltaLeitura.CDC == null) paramCDC = new GDAParameter("?CDC", System.DBNull.Value); else paramCDC = new GDAParameter("?CDC", objVoltaLeitura.CDC);
            GDAParameter paramLeitura_Ajustada; if (objVoltaLeitura.Leitura_Ajustada == null) paramLeitura_Ajustada = new GDAParameter("?Leitura_Ajustada", System.DBNull.Value); else paramLeitura_Ajustada = new GDAParameter("?Leitura_Ajustada", objVoltaLeitura.Leitura_Ajustada);
            GDAParameter paramLeitura_Real; if (objVoltaLeitura.Leitura_Real == null) paramLeitura_Real = new GDAParameter("?Leitura_Real", System.DBNull.Value); else paramLeitura_Real = new GDAParameter("?Leitura_Real", objVoltaLeitura.Leitura_Real);
            GDAParameter paramConsumo_Ajustado; if (objVoltaLeitura.Consumo_Ajustado == null) paramConsumo_Ajustado = new GDAParameter("?Consumo_Ajustado", System.DBNull.Value); else paramConsumo_Ajustado = new GDAParameter("?Consumo_Ajustado", objVoltaLeitura.Consumo_Ajustado);
            GDAParameter paramEsgoto_Ajustado; if (objVoltaLeitura.Esgoto_Ajustado == null) paramEsgoto_Ajustado = new GDAParameter("?Esgoto_Ajustado", System.DBNull.Value); else paramEsgoto_Ajustado = new GDAParameter("?Esgoto_Ajustado", objVoltaLeitura.Esgoto_Ajustado);
            GDAParameter paramDias_Consumo; if (objVoltaLeitura.Dias_Consumo == null) paramDias_Consumo = new GDAParameter("?Dias_Consumo", System.DBNull.Value); else paramDias_Consumo = new GDAParameter("?Dias_Consumo", objVoltaLeitura.Dias_Consumo);
            GDAParameter paramOcorrencia; if (objVoltaLeitura.Ocorrencia == null) paramOcorrencia = new GDAParameter("?Ocorrencia", System.DBNull.Value); else paramOcorrencia = new GDAParameter("?Ocorrencia", objVoltaLeitura.Ocorrencia);
            GDAParameter paramIdent_fraude; if (objVoltaLeitura.Ident_fraude == null) paramIdent_fraude = new GDAParameter("?Ident_fraude", System.DBNull.Value); else paramIdent_fraude = new GDAParameter("?Ident_fraude", objVoltaLeitura.Ident_fraude);
            GDAParameter paramIndic_cortado; if (objVoltaLeitura.Indic_cortado == null) paramIndic_cortado = new GDAParameter("?Indic_cortado", System.DBNull.Value); else paramIndic_cortado = new GDAParameter("?Indic_cortado", objVoltaLeitura.Indic_cortado);
            GDAParameter paramOperador; if (objVoltaLeitura.Operador == null) paramOperador = new GDAParameter("?Operador", System.DBNull.Value); else paramOperador = new GDAParameter("?Operador", objVoltaLeitura.Operador);
            GDAParameter paramFlag_Calculo; if (objVoltaLeitura.Flag_Calculo == null) paramFlag_Calculo = new GDAParameter("?Flag_Calculo", System.DBNull.Value); else paramFlag_Calculo = new GDAParameter("?Flag_Calculo", objVoltaLeitura.Flag_Calculo);
            GDAParameter paramFlag_Emissao; if (objVoltaLeitura.Flag_Emissao == null) paramFlag_Emissao = new GDAParameter("?Flag_Emissao", System.DBNull.Value); else paramFlag_Emissao = new GDAParameter("?Flag_Emissao", objVoltaLeitura.Flag_Emissao);
            GDAParameter paramValor_Agua; if (objVoltaLeitura.Valor_Agua == null) paramValor_Agua = new GDAParameter("?Valor_Agua", System.DBNull.Value); else paramValor_Agua = new GDAParameter("?Valor_Agua", objVoltaLeitura.Valor_Agua);
            GDAParameter paramValor_Esgoto; if (objVoltaLeitura.Valor_Esgoto == null) paramValor_Esgoto = new GDAParameter("?Valor_Esgoto", System.DBNull.Value); else paramValor_Esgoto = new GDAParameter("?Valor_Esgoto", objVoltaLeitura.Valor_Esgoto);
            GDAParameter paramValor_Credito; if (objVoltaLeitura.Valor_Credito == null) paramValor_Credito = new GDAParameter("?Valor_Credito", System.DBNull.Value); else paramValor_Credito = new GDAParameter("?Valor_Credito", objVoltaLeitura.Valor_Credito);
            GDAParameter paramValor_Reducao; if (objVoltaLeitura.Valor_Reducao == null) paramValor_Reducao = new GDAParameter("?Valor_Reducao", System.DBNull.Value); else paramValor_Reducao = new GDAParameter("?Valor_Reducao", objVoltaLeitura.Valor_Reducao);
            GDAParameter paramValor_IR; if (objVoltaLeitura.Valor_IR == null) paramValor_IR = new GDAParameter("?Valor_IR", System.DBNull.Value); else paramValor_IR = new GDAParameter("?Valor_IR", objVoltaLeitura.Valor_IR);
            GDAParameter paramValor_CSLL; if (objVoltaLeitura.Valor_CSLL == null) paramValor_CSLL = new GDAParameter("?Valor_CSLL", System.DBNull.Value); else paramValor_CSLL = new GDAParameter("?Valor_CSLL", objVoltaLeitura.Valor_CSLL);
            GDAParameter paramValor_PIS; if (objVoltaLeitura.Valor_PIS == null) paramValor_PIS = new GDAParameter("?Valor_PIS", System.DBNull.Value); else paramValor_PIS = new GDAParameter("?Valor_PIS", objVoltaLeitura.Valor_PIS);
            GDAParameter paramValor_COFINS; if (objVoltaLeitura.Valor_COFINS == null) paramValor_COFINS = new GDAParameter("?Valor_COFINS", System.DBNull.Value); else paramValor_COFINS = new GDAParameter("?Valor_COFINS", objVoltaLeitura.Valor_COFINS);
            GDAParameter paramCategoria; if (objVoltaLeitura.Categoria == null) paramCategoria = new GDAParameter("?Categoria", System.DBNull.Value); else paramCategoria = new GDAParameter("?Categoria", objVoltaLeitura.Categoria);
            GDAParameter paramEco_Res; if (objVoltaLeitura.Eco_Res == null) paramEco_Res = new GDAParameter("?Eco_Res", System.DBNull.Value); else paramEco_Res = new GDAParameter("?Eco_Res", objVoltaLeitura.Eco_Res);
            GDAParameter paramEco_Com; if (objVoltaLeitura.Eco_Com == null) paramEco_Com = new GDAParameter("?Eco_Com", System.DBNull.Value); else paramEco_Com = new GDAParameter("?Eco_Com", objVoltaLeitura.Eco_Com);
            GDAParameter paramEco_Ind; if (objVoltaLeitura.Eco_Ind == null) paramEco_Ind = new GDAParameter("?Eco_Ind", System.DBNull.Value); else paramEco_Ind = new GDAParameter("?Eco_Ind", objVoltaLeitura.Eco_Ind);
            GDAParameter paramEco_Pub; if (objVoltaLeitura.Eco_Pub == null) paramEco_Pub = new GDAParameter("?Eco_Pub", System.DBNull.Value); else paramEco_Pub = new GDAParameter("?Eco_Pub", objVoltaLeitura.Eco_Pub);
            GDAParameter paramEco_Soc; if (objVoltaLeitura.Eco_Soc == null) paramEco_Soc = new GDAParameter("?Eco_Soc", System.DBNull.Value); else paramEco_Soc = new GDAParameter("?Eco_Soc", objVoltaLeitura.Eco_Soc);
            GDAParameter paramConsumo_Rateado; if (objVoltaLeitura.Consumo_Rateado == null) paramConsumo_Rateado = new GDAParameter("?Consumo_Rateado", System.DBNull.Value); else paramConsumo_Rateado = new GDAParameter("?Consumo_Rateado", objVoltaLeitura.Consumo_Rateado);
            GDAParameter paramValor_Saldo_Debito; if (objVoltaLeitura.Valor_Saldo_Debito == null) paramValor_Saldo_Debito = new GDAParameter("?Valor_Saldo_Debito", System.DBNull.Value); else paramValor_Saldo_Debito = new GDAParameter("?Valor_Saldo_Debito", objVoltaLeitura.Valor_Saldo_Debito);
            GDAParameter paramFlag_Lido; if (objVoltaLeitura.Flag_Lido == null) paramFlag_Lido = new GDAParameter("?Flag_Lido", System.DBNull.Value); else paramFlag_Lido = new GDAParameter("?Flag_Lido", objVoltaLeitura.Flag_Lido);
            GDAParameter paramFlag_Faturado; if (objVoltaLeitura.Flag_Faturado == null) paramFlag_Faturado = new GDAParameter("?Flag_Faturado", System.DBNull.Value); else paramFlag_Faturado = new GDAParameter("?Flag_Faturado", objVoltaLeitura.Flag_Faturado);
            GDAParameter paramOcorrencia2; if (objVoltaLeitura.Ocorrencia2 == null) paramOcorrencia2 = new GDAParameter("?Ocorrencia2", System.DBNull.Value); else paramOcorrencia2 = new GDAParameter("?Ocorrencia2", objVoltaLeitura.Ocorrencia2);
            GDAParameter paramFlag_Situacao_Movimento; if (objVoltaLeitura.Flag_Situacao_Movimento == null) paramFlag_Situacao_Movimento = new GDAParameter("?Flag_Situacao_Movimento", System.DBNull.Value); else paramFlag_Situacao_Movimento = new GDAParameter("?Flag_Situacao_Movimento", objVoltaLeitura.Flag_Situacao_Movimento);
            GDAParameter paramFlag_Repasse; if (objVoltaLeitura.Flag_Repasse == null) paramFlag_Repasse = new GDAParameter("?Flag_Repasse", System.DBNull.Value); else paramFlag_Repasse = new GDAParameter("?Flag_Repasse", objVoltaLeitura.Flag_Repasse);



            string ocorrencia = objVoltaLeitura.Ocorrencia == null ? "null" : objVoltaLeitura.Ocorrencia.ToString();
            string sql = @"
                            UPDATE VOLTA_LEITURA
                               SET
                                    Leitura_Ajustada		    =	?Leitura_Ajustada
                                    ,Leitura_Real				=	?Leitura_Real
                                    ,Data_Leitura				=	?Data_Leitura
                                    ,Consumo_Ajustado			=	?Consumo_Ajustado
                                    ,Esgoto_Ajustado		    =	?Esgoto_Ajustado
                                    ,Dias_Consumo				=	?Dias_Consumo
                                    ,Ocorrencia				    =	?Ocorrencia
                                    ,Ident_fraude				=	?Ident_fraude
                                    ,Indic_cortado				=	?Indic_cortado
                                    ,Operador				    =	?Operador
                                    ,Flag_Calculo				=	?Flag_Calculo
                                    ,Flag_Emissao				=	?Flag_Emissao
                                    ,Referencia				    =	?Referencia
                                    ,Data_Emissao				=	?Data_Emissao
                                    ,Vencimento				    =	?Vencimento
                                    ,Valor_Agua				    =	?Valor_Agua
                                    ,Valor_Esgoto				=	?Valor_Esgoto
                                    ,Valor_Credito				=	?Valor_Credito
                                    ,Valor_Reducao				=	?Valor_Reducao
                                    ,Valor_IR				    =	?Valor_IR
                                    ,Valor_CSLL				    =	?Valor_CSLL
                                    ,Valor_PIS				    =	?Valor_PIS
                                    ,Valor_COFINS				=	?Valor_COFINS
                                    ,Categoria				    =	?Categoria
                                    ,Eco_Res				    =	?Eco_Res
                                    ,Eco_Com				    =	?Eco_Com
                                    ,Eco_Ind				    =	?Eco_Ind
                                    ,Eco_Pub				    =	?Eco_Pub
                                    ,Eco_Soc				    =	?Eco_Soc
                                    ,Consumo_Rateado			=   ?Consumo_Rateado
                                    ,Valor_Saldo_Debito			=	?Valor_Saldo_Debito
                                    ,Flag_Lido				    =	?Flag_Lido
                                    ,Flag_Faturado				=	?Flag_Faturado
                                    ,Flag_Situacao_Movimento	=	?Flag_Situacao_Movimento
 
                             WHERE CDC = ?CDC";

            int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql,paramGrupo
                                                                            ,paramSetor
                                                                            ,paramRota
                                                                            ,paramCDC
                                                                            ,paramLeitura_Ajustada
                                                                            ,paramLeitura_Real
                                                                            ,paramData_Leitura
                                                                            ,paramConsumo_Ajustado
                                                                            ,paramEsgoto_Ajustado
                                                                            ,paramDias_Consumo
                                                                            ,paramOcorrencia
                                                                            ,paramIdent_fraude
                                                                            ,paramIndic_cortado
                                                                            ,paramOperador
                                                                            ,paramFlag_Calculo
                                                                            ,paramFlag_Emissao
                                                                            ,paramReferencia
                                                                            ,paramData_Emissao
                                                                            ,paramVencimento
                                                                            ,paramValor_Agua
                                                                            ,paramValor_Esgoto
                                                                            ,paramValor_Credito
                                                                            ,paramValor_Reducao
                                                                            ,paramValor_IR
                                                                            ,paramValor_CSLL
                                                                            ,paramValor_PIS
                                                                            ,paramValor_COFINS
                                                                            ,paramCategoria
                                                                            ,paramEco_Res
                                                                            ,paramEco_Com
                                                                            ,paramEco_Ind
                                                                            ,paramEco_Pub
                                                                            ,paramEco_Soc
                                                                            ,paramConsumo_Rateado
                                                                            ,paramValor_Saldo_Debito
                                                                            ,paramFlag_Lido
                                                                            ,paramFlag_Faturado
                                                                            ,paramOcorrencia2
                                                                            ,paramFlag_Situacao_Movimento
                                                                            ,paramFlag_Repasse
                                                                        );
            return;
        }

        /// <summary>
        ///  INSERE OS DADOS 
        /// </summary>
        /// <param name="objVoltaLeitura"></param>
        public void InsertLeitura(VoltaLeitura objVoltaLeitura)
        {
            // Condicional para resolver data
            GDAParameter paramData_Leitura;
            if (objVoltaLeitura.Data_Leitura == null)
                paramData_Leitura = new GDAParameter("?Data_Leitura", System.DBNull.Value);
            else
                paramData_Leitura = new GDAParameter("?Data_Leitura", objVoltaLeitura.Data_Leitura);

            // Condicional para resolver data
            GDAParameter paramReferencia;
            if (objVoltaLeitura.Referencia == null)
                paramReferencia = new GDAParameter("?Referencia", System.DBNull.Value);
            else
                paramReferencia = new GDAParameter("?Referencia", objVoltaLeitura.Referencia);

            // Condicional para resolver data
            GDAParameter paramData_Emissao;
            if (objVoltaLeitura.Data_Emissao == null)
                paramData_Emissao = new GDAParameter("?Data_Emissao", System.DBNull.Value);
            else
                paramData_Emissao = new GDAParameter("?Data_Emissao", objVoltaLeitura.Data_Emissao);

            // Condicional para resolver data
            GDAParameter paramVencimento;
            if (objVoltaLeitura.Vencimento == null)
                paramVencimento = new GDAParameter("?Vencimento", System.DBNull.Value);
            else
                paramVencimento = new GDAParameter("?Vencimento", objVoltaLeitura.Vencimento);

            GDAParameter paramOcorrencia;
            if (objVoltaLeitura.Ocorrencia == null)
                paramOcorrencia = new GDAParameter("?Ocorrencia", System.DBNull.Value); 
            else
                paramOcorrencia = new GDAParameter("?Ocorrencia", objVoltaLeitura.Ocorrencia);

            GDAParameter paramOcorrencia2;
            if (objVoltaLeitura.Ocorrencia2 == null)
                paramOcorrencia2 = new GDAParameter("?Ocorrencia2", System.DBNull.Value);
            else
                paramOcorrencia2 = new GDAParameter("?Ocorrencia2", objVoltaLeitura.Ocorrencia2);

            GDAParameter paramOperador;
            if (objVoltaLeitura.Operador == null)
                paramOperador = new GDAParameter("?Operador", System.DBNull.Value);
            else
                paramOperador = new GDAParameter("?Operador", objVoltaLeitura.Operador);

            GDAParameter paramFlag_Situacao_Movimento;
            if (objVoltaLeitura.Flag_Situacao_Movimento == null)
                paramFlag_Situacao_Movimento = new GDAParameter("?Flag_Situacao_Movimento", System.DBNull.Value);
            else
                paramFlag_Situacao_Movimento = new GDAParameter("?Flag_Situacao_Movimento", objVoltaLeitura.Flag_Situacao_Movimento);

            GDAParameter paramFlag_Repasse;
            if (objVoltaLeitura.Flag_Repasse == null)
                paramFlag_Repasse = new GDAParameter("?Flag_Repasse", System.DBNull.Value);
            else
                paramFlag_Repasse = new GDAParameter("?Flag_Repasse", objVoltaLeitura.Flag_Repasse);

            GDAParameter consumoAjustado;
            if (objVoltaLeitura.Consumo_Ajustado == null)
                consumoAjustado = new GDAParameter("?Consumo_Ajustado", System.DBNull.Value);
            else
                consumoAjustado = new GDAParameter("?Consumo_Ajustado", objVoltaLeitura.Consumo_Ajustado);

            GDAParameter esgotoAjustado;
            if (objVoltaLeitura.Esgoto_Ajustado == null)
                esgotoAjustado = new GDAParameter("?Esgoto_Ajustado", System.DBNull.Value);
            else
                esgotoAjustado = new GDAParameter("?Esgoto_Ajustado", objVoltaLeitura.Esgoto_Ajustado);
            //

            GDAParameter consumoRateado;
            if (objVoltaLeitura.Consumo_Rateado == null)
                consumoRateado = new GDAParameter("?Consumo_Rateado", System.DBNull.Value);
            else
                consumoRateado = new GDAParameter("?Consumo_Rateado", objVoltaLeitura.Consumo_Rateado);

            string sql = @"
                            INSERT INTO VOLTA_LEITURA
                                       (
                                        Grupo
                                       ,Setor
                                       ,Rota
                                       ,CDC
                                       ,Leitura_Ajustada
                                       ,Leitura_Real
                                       ,Data_Leitura
                                       ,Consumo_Ajustado
                                       ,Esgoto_Ajustado
                                       ,Dias_Consumo
                                       ,Ocorrencia
                                       ,Ident_fraude
                                       ,Indic_cortado
                                       ,Operador
                                       ,Flag_Calculo
                                       ,Flag_Emissao
                                       ,Referencia
                                       ,Data_Emissao
                                       ,Vencimento
                                       ,Valor_Agua
                                       ,Valor_Esgoto
                                       ,Valor_Credito
                                       ,Valor_Reducao
                                       ,Valor_IR
                                       ,Valor_CSLL
                                       ,Valor_PIS
                                       ,Valor_COFINS
                                       ,Categoria
                                       ,Eco_Res
                                       ,Eco_Com
                                       ,Eco_Ind
                                       ,Eco_Pub
                                       ,Eco_Soc
                                       ,Consumo_Rateado
                                       ,Valor_Saldo_Debito
                                       ,Flag_Lido
                                       ,Flag_Faturado
                                       ,Ocorrencia2
                                       ,Flag_Situacao_Movimento
                                       ,Flag_Repasse
                                       )
                                 VALUES
                                       (
                                        ?Grupo
                                       ,?Setor
                                       ,?Rota
                                       ,?CDC
                                       ,?Leitura_Ajustada
                                       ,?Leitura_Real
                                       ,?Data_Leitura
                                       ,?Consumo_Ajustado
                                       ,?Esgoto_Ajustado
                                       ,?Dias_Consumo
                                       ,?Ocorrencia
                                       ,?Ident_fraude
                                       ,?Indic_cortado
                                       ,?Operador
                                       ,?Flag_Calculo
                                       ,?Flag_Emissao
                                       ,?Referencia
                                       ,?Data_Emissao
                                       ,?Vencimento
                                       ,?Valor_Agua
                                       ,?Valor_Esgoto
                                       ,?Valor_Credito
                                       ,?Valor_Reducao
                                       ,?Valor_IR
                                       ,?Valor_CSLL
                                       ,?Valor_PIS
                                       ,?Valor_COFINS
                                       ,?Categoria
                                       ,?Eco_Res
                                       ,?Eco_Com
                                       ,?Eco_Ind
                                       ,?Eco_Pub
                                       ,?Eco_Soc
                                       ,?Consumo_Rateado
                                       ,?Valor_Saldo_Debito
                                       ,?Flag_Lido
                                       ,?Flag_Faturado
                                       ,?Ocorrencia2
                                       ,?Flag_Situacao_Movimento
                                       ,?Flag_Repasse
                                    )
                             ";

            int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql,
                                                                                new GDAParameter("?Grupo", objVoltaLeitura.Grupo)
                                                                               , new GDAParameter("?Setor", objVoltaLeitura.Setor)
                                                                               , new GDAParameter("?Rota", objVoltaLeitura.Rota)
                                                                               , new GDAParameter("?CDC", objVoltaLeitura.CDC)
                                                                               , new GDAParameter("?Leitura_Ajustada", objVoltaLeitura.Leitura_Ajustada)
                                                                               , new GDAParameter("?Leitura_Real", objVoltaLeitura.Leitura_Real)
                                                                               , paramData_Leitura
                                                                               , consumoAjustado
                                                                               , esgotoAjustado
                                                                               , new GDAParameter("?Dias_Consumo", objVoltaLeitura.Dias_Consumo)
                                                                               , paramOcorrencia
                                                                               , new GDAParameter("?Ident_fraude", objVoltaLeitura.Ident_fraude)
                                                                               , new GDAParameter("?Indic_cortado", objVoltaLeitura.Indic_cortado)
                                                                               , paramOperador
                                                                               , new GDAParameter("?Flag_Calculo", objVoltaLeitura.Flag_Calculo)
                                                                               , new GDAParameter("?Flag_Emissao", objVoltaLeitura.Flag_Emissao)
                                                                               , paramReferencia
                                                                               , paramData_Emissao
                                                                               , paramVencimento
                                                                               , new GDAParameter("?Valor_Agua", objVoltaLeitura.Valor_Agua)
                                                                               , new GDAParameter("?Valor_Esgoto", objVoltaLeitura.Valor_Esgoto)
                                                                               , new GDAParameter("?Valor_Credito", objVoltaLeitura.Valor_Credito)
                                                                               , new GDAParameter("?Valor_Reducao", objVoltaLeitura.Valor_Reducao)
                                                                               , new GDAParameter("?Valor_IR", objVoltaLeitura.Valor_IR)
                                                                               , new GDAParameter("?Valor_CSLL", objVoltaLeitura.Valor_CSLL)
                                                                               , new GDAParameter("?Valor_PIS", objVoltaLeitura.Valor_PIS)
                                                                               , new GDAParameter("?Valor_COFINS", objVoltaLeitura.Valor_COFINS)
                                                                               , new GDAParameter("?Categoria", objVoltaLeitura.Categoria)
                                                                               , new GDAParameter("?Eco_Res", objVoltaLeitura.Eco_Res)
                                                                               , new GDAParameter("?Eco_Com", objVoltaLeitura.Eco_Com)
                                                                               , new GDAParameter("?Eco_Ind", objVoltaLeitura.Eco_Ind)
                                                                               , new GDAParameter("?Eco_Pub", objVoltaLeitura.Eco_Pub)
                                                                               , new GDAParameter("?Eco_Soc", objVoltaLeitura.Eco_Soc)
                                                                               , consumoRateado
                                                                               , new GDAParameter("?Valor_Saldo_Debito", objVoltaLeitura.Valor_Saldo_Debito)
                                                                               , new GDAParameter("?Flag_Lido", objVoltaLeitura.Flag_Lido)
                                                                               , new GDAParameter("?Flag_Faturado", objVoltaLeitura.Flag_Faturado)
                                                                               , paramOcorrencia2
                                                                               , paramFlag_Situacao_Movimento
                                                                               , paramFlag_Repasse

                                                                        );
            return;
        }

        /// <summary>
        ///  Retorna os dados de volta leitura
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rota"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public int ListaVoltaLeitura(int grupo, int rota, DateTime referencia)
        {
            string sql = @"
                            SELECT DISTINCT count(cdc)
				            FROM volta_leitura
                            WHERE
                                Referencia = ?referencia
                                AND Grupo = ?grupo
                                AND Rota = ?rota
                         ";
            object qtd = CurrentPersistenceObject.ExecuteScalar(sql, new GDAParameter("?referencia", referencia), new GDAParameter("?grupo", grupo), new GDAParameter("?rota", rota));

            if(qtd != null)
            {
                return (int)qtd;
            }
            else
            {
                return 0;
            }   
        }

        /// <summary>
        ///  Retorna a leitura
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rota"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public int CountVoltaLeitura(int grupo, int rota,int cdc, DateTime referencia)
        {
            string sql = @"
                            SELECT DISTINCT count(cdc)
				            FROM volta_leitura
                            WHERE
                                Referencia = ?referencia
                                AND Grupo = ?grupo
                                AND Rota = ?rota
                                AND CDC = ?cdc
                         ";
            object qtd = CurrentPersistenceObject.ExecuteScalar(sql, new GDAParameter("?cdc", cdc), new GDAParameter("?referencia", referencia), new GDAParameter("?grupo", grupo), new GDAParameter("?rota", rota));

            if (qtd != null)
            {
                return (int)qtd;
            }
            else
            {
                return 0;
            }
        }
    }
}