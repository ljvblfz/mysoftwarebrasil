using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;
using System.Data;
using System.Data.SqlClient;

namespace GeraBase.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class CriticaDAO : BaseDAO<Critica>
    {

        /// <summary>
        ///     RETORNA UMA LISTA COM TODOS OS DADOS DE LEITURA
        /// </summary>
        /// <returns></returns>
        public List<Critica> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                L.*,LI.*
                                FROM VOLTA_LEITURA L
                                LEFT JOIN IDA_LIGACOES LI ON LI.CDC = L.CDC
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        ///     CHECAR SE EXISTEM CONSUMO NEGATIVO
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public List<Critica> ListaConsumoNegativo(string where, GDAParameter[] objArrayParam)
        {
            // Consulta
            string sql = getSqlCritica("CONSUMO NEGATIVO") // Parte do select
                        + where + // Condicao dinamica
                        @" AND L.Consumo_Ajustado < 0 " // Condicao da regra de critica
                        + getGroupBy(); // Parte do group by

            return CurrentPersistenceObject.LoadData(sql, objArrayParam);
        }

        /// <summary>
        ///     CHECAR SE EXISTEM MAIS ROTAS SEM DATA DE LEITURA
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<Critica> ListaLeituraNula(string where, GDAParameter[] objArrayParam)
        {
            // Consulta
            string sql = getSqlCritica("SEM DATA DE LEITURA") // Parte do select
                        + where + // Condicao dinamica
                        @" AND L.Data_Leitura IS NULL " // Condicao da regra de critica
                        + getGroupBy(); // Parte do group by

            return CurrentPersistenceObject.LoadData(sql, objArrayParam);
        }

        /// <summary>
        ///     CHECAR SE EXISTEM CONSUMIDORES CALCULADOS SEM DIAS DE CONSUMO
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<Critica> ListaDiasConsumoNulo(string where, GDAParameter[] objArrayParam)
        {
            // Consulta
            string sql = getSqlCritica("SEM DIAS DE CONSUMO") // Parte do select
                        + where + // Condicao dinamica
                        @" AND L.Dias_Consumo IS NULL AND 
		                   L.Flag_Calculo ='S' "
                // Condicao da regra de critica
                        + getGroupBy(); // Parte do group by

            return CurrentPersistenceObject.LoadData(sql, objArrayParam);
        }

        /// <summary>
        ///     CHECAR VALORES ZERADOS CALCULADOS
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<Critica> ListaValoresZerados(string where, GDAParameter[] objArrayParam)
        {
            // Consulta
            string sql = getSqlCritica("VALOR ZERADO") // Parte do select
                        + where + // Condicao dinamica
                        @"  AND L.Valor_Agua = 0 AND 
                                L.Valor_Esgoto = 0  AND 
                                L.Flag_Calculo ='S' AND
                                L.Flag_Faturado ='S' "
                // Condicao da regra de critica
                        + getGroupBy(); // Parte do group by

            return CurrentPersistenceObject.LoadData(sql, objArrayParam);
        }

        /// <summary>
        ///     CHECAR VALORES DE OCORRENCIA NULA
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<Critica> ListaOcorrenciaNula(string where, GDAParameter[] objArrayParam)
        {
            // Consulta
            string sql = getSqlCritica("OCORRENCIA NULA") // Parte do select
                        + where + // Condicao dinamica
                        @" AND( 
                                L.Ocorrencia IS NULL
                                OR L.Ocorrencia = 0
                                OR L.Ocorrencia = ''
                               ) "
                // Condicao da regra de critica
                        + getGroupBy(); // Parte do group by

            return CurrentPersistenceObject.LoadData(sql, objArrayParam);
        }

        /// <summary>
        ///     CHECAR SE A CONTA ESTA RERTIDA
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<Critica> ListaContaRetida(string where, GDAParameter[] objArrayParam)
        {
            // Consulta
            string sql = getSqlCritica("CONTA RERTIDA") // Parte do select
                        + where + // Condicao dinamica
                        @" AND L.Flag_Situacao_Movimento = 'R' "// Condicao da regra de critica
                        + getGroupBy(); // Parte do group by

            return CurrentPersistenceObject.LoadData(sql, objArrayParam);
        }

        /// <summary>
        ///     CHECAR CONSUMIDORES BLOQUEADOS
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<Critica> ListaConsumidoBloqueado(string where, GDAParameter[] objArrayParam)
        {
            // Consulta
            string sql = getSqlCritica("CONSUMIDORES BLOQUEADOS")// Parte do select
                        + where + // Condicao dinamica
                        @" AND  LI.Ident_Calculo='B' "// Condicao da regra de critica
                        +getGroupBy(); // Parte do group by

            return CurrentPersistenceObject.LoadData(sql, objArrayParam);
        }

        /// <summary>
        ///     CHECAR CONSUMIDORES QUE NÃO FORAM LIDOS
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<Critica> ListaNaoLidos(string where, GDAParameter[] objArrayParam)
        {
            // Consulta
            string sql = getSqlCritica("NÃO FORAM LIDOS") // Parte do select
                        + where + // Condicao dinamica
                        @" AND  NOT EXISTS (select 1 from VOLTA_LEITURA where LI.CDC = VOLTA_LEITURA.CDC) "// Condicao da regra de critica
                        + getGroupBy(); // Parte do group by

            return CurrentPersistenceObject.LoadData(sql, objArrayParam);
        }

        /// <summary>
        ///  Recupera o SQL da Critica
        /// </summary>
        /// <returns></returns>
        private string getSqlCritica(string tipo)
        {
            return @"
                        --PARTE DO SQL A SER USADO NA CRITICA
                        SELECT  DISTINCT
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
                              ,G.Referencia
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
                              ,LI.Codigo_Logradouro
                              ,LI.Numero_Imovel
                              --,LI.Complemento
                              ,(SELECT Nome from IDA_LOGRADOUROS where Codigo = LI.Codigo_Logradouro AND Grupo = LI.Grupo) as Complemento                              
                              ,LI.Inscricao
                              ,LI.Grupo
                              ,LI.Setor
                              ,LI.Rota
                              ,LI.Sequencia
                              ,LI.Cachorro
                              ,LI.CDC
                              ,LI.CDC_Pai
                              ,LI.Media
                              ,LI.Medidor
                              ,LI.Categoria_Imovel
                              ,LI.Natureza_Ligacao
                              ,LI.Eco_Res
                              ,LI.Eco_Com
                              ,LI.Eco_Ind
                              ,LI.Eco_Pub
                              ,LI.Eco_Soc
                              ,LI.Bloqueado
                              ,LI.Data_Bloqueio
                              ,LI.Data_DesBloqueio
                              ,LI.Qtde_Debitos
                              ,LI.Mensagem1
                              ,LI.Mensagem2
                              ,LI.Qtde_Registros_Fraude
                              ,LI.Clas_Imovel
                              ,LI.Ident_Consumidor
                              ,LI.Ident_Calculo
                              ,LI.Emite_Conta
                              ,LI.Data_Inst_HD
                              ,LI.Leitura_Inicial_HD
                              ,LI.Qtde_Ponteiros
                              ,LI.Cortar
                              ,LI.Nome
                              ,LI.Agencia
                              ,LI.Banco
                              ,LI.Data_Vencimento
                              ,LI.Calcula_Imposto
                              ,LI.Endereco_Entrega
                              ,LI.Calcula_Conta
                              ,LI.Dias_Bloqueio_Tarifa_Ant
                              ,LI.Dias_Bloqueio_Tarifa_Atual
                              ,LI.Ident_Ligacao_Nova
                            ,'" + tipo + @"'AS Tipo
                            FROM VOLTA_LEITURA L
                            LEFT JOIN IDA_LIGACOES LI ON LI.CDC = L.CDC 
                            LEFT JOIN IDA_GRUPOS G ON G.Grupo = LI.Grupo";
        }

        /// <summary>
        ///  Retorna o group by para o SQL da critica
        /// </summary>
        /// <returns></returns>
        private string getGroupBy()
        {
            return @"
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
	                  ,G.Referencia
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
	                  ,LI.Codigo_Logradouro
	                  ,LI.Numero_Imovel
	                  ,LI.Complemento
	                  ,LI.Inscricao
	                  ,LI.Grupo
	                  ,LI.Setor
	                  ,LI.Rota
	                  ,LI.Sequencia
	                  ,LI.Cachorro
	                  ,LI.CDC
	                  ,LI.CDC_Pai
	                  ,LI.Media
	                  ,LI.Medidor
	                  ,LI.Categoria_Imovel
	                  ,LI.Natureza_Ligacao
	                  ,LI.Eco_Res
	                  ,LI.Eco_Com
	                  ,LI.Eco_Ind
	                  ,LI.Eco_Pub
	                  ,LI.Eco_Soc
	                  ,LI.Bloqueado
	                  ,LI.Data_Bloqueio
	                  ,LI.Data_DesBloqueio
	                  ,LI.Qtde_Debitos
	                  ,LI.Mensagem1
	                  ,LI.Mensagem2
	                  ,LI.Qtde_Registros_Fraude
	                  ,LI.Clas_Imovel
	                  ,LI.Ident_Consumidor
	                  ,LI.Ident_Calculo
	                  ,LI.Emite_Conta
	                  ,LI.Data_Inst_HD
	                  ,LI.Leitura_Inicial_HD
	                  ,LI.Qtde_Ponteiros
	                  ,LI.Cortar
	                  ,LI.Nome
	                  ,LI.Agencia
	                  ,LI.Banco
	                  ,LI.Data_Vencimento
	                  ,LI.Calcula_Imposto
	                  ,LI.Endereco_Entrega
	                  ,LI.Calcula_Conta
	                  ,LI.Dias_Bloqueio_Tarifa_Ant
	                  ,LI.Dias_Bloqueio_Tarifa_Atual
	                  ,LI.Ident_Ligacao_Nova
                    ";
        }
    }
}
