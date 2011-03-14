using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;
using System.Data;
using System.Data.SqlClient;

namespace Data.DAL
{
    public  class DistribuicaoDAO : BaseDAO<Distribuicao>
    {
        /// <summary>
        ///  Retorna o grupo pertencente ao usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public List<Distribuicao> RetornaGrupoRota(int idUsuario, string senha)
        {
            string sql = @"
                            SELECT 
                                   * 
                            FROM IDA_DISTRIBUICAO
                            WHERE 
                                Codigo_Agente = ?Codigo
                                AND Situacao = 'L' 
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Codigo", idUsuario));
        }

        /// <summary>
        ///  Retorna uma lista de distribuições
        /// </summary>
        /// <param name="Rota"></param>
        /// <returns></returns>
        public DataTable RetornaDistribuicao2(int grupo)
        {
            // Instancia do objeto de conexao com o banco de dados
            string connectionString = Configuration.ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            // Abre a conexão
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();

            // Criando a tabela 
            DataSet ds = new DataSet();

            string sql = @"
                            SELECT 
                                    L.Rota,
			                        (
                                        SELECT DISTINCT
                                            COUNT(L2.CDC) 	 
                                        FROM IDA_LIGACOES L2
                                        WHERE
					                        L2.Rota = L.Rota 
                                            AND L2.Grupo = L.Grupo
				                        GROUP BY L2.Rota
                          
                                     ) AS Quant_Matricula,
                                    D.Data_Carga,
                                    D.Data_Descarga,
                                    --D.Situacao,
                                    A.Codigo AS Agente		 
                            FROM IDA_DISTRIBUICAO D
                            LEFT JOIN IDA_LIGACOES L ON D.Grupo = L.Grupo AND L.Rota = D.Rota
                            LEFT JOIN IDA_AGENTES A ON A.Codigo = D.Codigo_Agente
                            WHERE 
                                L.Rota IN (
                                            SELECT DISTINCT 
                                                   Rota 
                                            FROM IDA_LIGACOES 
                                            WHERE Grupo = " + grupo + @" 
				                          )
                                AND L.Grupo = " + grupo + @"
                            GROUP BY 
                                    L.Rota,
			                        L.Grupo,
                                    D.Data_Carga,
                                    D.Data_Descarga,
                                    --D.Situacao,
                                    A.Codigo
                            ORDER BY A.Codigo DESC -- IMPORTANTE PARA PEGAR O NOME QUE NÂO ESTA NULO
                         ";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

            //Preencho o dataset
            adapter.Fill(ds);
            return ds.Tables[0];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Rota"></param>
        /// <returns></returns>
        public DataTable RetornaDistribuicao(int rota, int grupo)
        {
            // Instancia do objeto de conexao com o banco de dados
            string connectionString = Configuration.ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            // Abre a conexão
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();

            // Criando a tabela 
            DataTable dtRota = new DataTable();
            dtRota.Columns.Add("Quant_Matricula");
            dtRota.Columns.Add("Data_Carga");
            dtRota.Columns.Add("Data_Descarga");
            dtRota.Columns.Add("Agente");
            dtRota.Columns.Add("Rota");

            string sql = @"
                            SELECT 
                                    L.Rota,
                                    (
			                            SELECT DISTINCT
				                            COUNT(L.CDC) 	 
			                            FROM IDA_LIGACOES L
			                            WHERE 
				                            L.Rota = " + rota + @"
                                            AND L.Grupo = " + grupo + @"  
		                             ) AS Quant_Matricula,
                                    D.Data_Carga,
                                    D.Data_Descarga,
                                    A.Codigo AS Agente		 
                            FROM IDA_LIGACOES L
                            LEFT JOIN IDA_DISTRIBUICAO D ON D.Grupo = L.Grupo AND L.Rota = D.Rota
                            LEFT JOIN IDA_AGENTES A ON A.Codigo = D.Codigo_Agente
                            --LEFT JOIN IDA_LIGACOES L ON L.Grupo = D.Grupo AND L.Rota = D.Rota
                            WHERE 
                                L.Rota = " + rota + @"
                                AND L.Grupo = " + grupo + @"
                            GROUP BY 
                                    L.Rota,
                                    D.Data_Carga,
                                    D.Data_Descarga,
                                    A.Codigo
                            ORDER BY A.Codigo DESC -- IMPORTANTE PARA PEGAR O NOME QUE NÂO ESTA NULO
                         ";

            cmd.CommandText = sql;
            IDataReader dReader = cmd.ExecuteReader();

            // Converte os tipos e seta os valores
            while (dReader.Read())
            {
                object objRota = dReader["Rota"];
                object objAgente = dReader["Agente"];
                object objData_descarga = dReader["Data_Descarga"];
                object objData_carga = dReader["data_carga"];
                object objQuant_matricula = dReader["quant_matricula"];

                dtRota.Rows.Add(new object[] { objQuant_matricula, objData_carga, objData_descarga, objAgente, objRota });
                break;
            }
            conn.Close();
            return dtRota;
        }

        /// <summary>
        ///  Atualiza a distribuição no banco
        /// </summary>
        /// <param name="objDistribuicao"></param>
        public int UpdateDistribuicao(Distribuicao objDistribuicao)
        {
            // Condicional para resolver data
            GDAParameter paramData_Carga;
            if (objDistribuicao.Data_Carga == null)
                paramData_Carga = new GDAParameter("?Data_Carga", System.DBNull.Value);
            else
                paramData_Carga = new GDAParameter("?Data_Carga", objDistribuicao.Data_Carga);

            // Condicional para resolver data
            GDAParameter paramData_Descarga;
            if (objDistribuicao.Data_Descarga == null)
                paramData_Descarga = new GDAParameter("?Data_Descarga", System.DBNull.Value);
            else
                paramData_Descarga = new GDAParameter("?Data_Descarga", objDistribuicao.Data_Descarga);

            // Condicional para resolver data
            GDAParameter paramReferencia;
            if (objDistribuicao.Referencia == null)
                paramReferencia = new GDAParameter("?Referencia", System.DBNull.Value);
            else
                paramReferencia = new GDAParameter("?Referencia", objDistribuicao.Referencia);

            // Query SQL
            string sql = @"
                            UPDATE IDA_DISTRIBUICAO
                               SET
                                    Codigo_Agente = ?Codigo_Agente,
                                    Situacao = ?Situacao, 
                                    Data_Carga =  ?Data_Carga, 
                                    Data_Descarga = ?Data_Descarga 
                             WHERE
                                    Grupo = ?Grupo
                                    AND Rota = ?Rota
                                    AND Referencia = ?Referencia                                 
                                    ";
            // Executa os comendos
            int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql, new GDAParameter("?Codigo_Agente", objDistribuicao.Codigo_Agente),
                                                                             new GDAParameter("?Situacao", objDistribuicao.Situacao),
                                                                             new GDAParameter("?Grupo", objDistribuicao.Grupo),
                                                                             new GDAParameter("?Rota", objDistribuicao.Rota),
                                                                             paramData_Carga, // Data da carga
                                                                             paramData_Descarga,// Data descarga
                                                                             paramReferencia// Rferencia
                                                                        );
            return descontoSaida;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDistribuicao"></param>
        public int InsertDistribuicao(Distribuicao objDistribuicao)
        {
            string Data_Carga;
            string Data_Descarga;

            if (objDistribuicao.Data_Carga.ToString() != "")
            {
                Data_Carga = "CONVERT(DATETIME,'" + objDistribuicao.Data_Carga.ToString() + @"',103)";
            }
            else
            {
                Data_Carga = objDistribuicao.Data_Carga.ToString();
            }

            if (objDistribuicao.Data_Descarga.ToString() != "")
            {
                Data_Descarga = "CONVERT(DATETIME,'" + objDistribuicao.Data_Descarga.ToString() + @"',103)";
            }
            else
            {
                Data_Descarga = objDistribuicao.Data_Descarga.ToString();
            }

            string sql = @"
                            INSERT INTO IDA_DISTRIBUICAO
                                   (Codigo_Agente
                                   ,Situacao
                                   ,Referencia
                                   ,Grupo
                                   ,Rota
                                   ,Data_Carga
                                   ,Data_Descarga)
                             VALUES
                                    Codigo_Agente = '" + objDistribuicao.Codigo_Agente + @"',
                                    Situacao = '" + objDistribuicao.Situacao + @"' , 
                                    Data_Carga = '" + Data_Carga + @"' , 
                                    Data_Descarga = '" + Data_Descarga + @"'
                                    Grupo = '" + objDistribuicao.Grupo + @"'
                                    Rota = '" + objDistribuicao.Rota + @"'
                                    Referencia = '" + objDistribuicao.Referencia + @"'                                   
                                    ";

            int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql);
            return descontoSaida;
        }

        /// <summary>
        ///  Busca a distribuição
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rota"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public List<Distribuicao> RetornaDistribuicao(int grupo, int rota, DateTime? referencia)
        {
            string sql = @"
                            SELECT 
                                   * 
                            FROM IDA_DISTRIBUICAO
                            WHERE 
                                Grupo = ?Grupo
                                AND Rota = ?Rota
                                AND Referencia = ?Referencia 
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?Rota", rota), new GDAParameter("?Referencia", referencia));
        }

        /// <summary>
        ///  Libera  distribuição para carga
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public int LiberarDistribuicao(int grupo, DateTime referencia)
        {
            
            string sqlAUX = @"
                                SELECT * FROM
                                    IDA_DISTRIBUICAO       
                                WHERE
                                    Grupo = ?grupo
                                    AND Referencia = ?referencia
		                            AND Situacao <> 'L'
                             ";
            int result = CurrentPersistenceObject.ExecuteSqlQueryCount(sqlAUX, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia));

            if (result >= 1)
            {
                string sql = @"
                                UPDATE 
                                    IDA_DISTRIBUICAO
                                SET
                                    Situacao = 'L'
                                WHERE
                                    Grupo = ?grupo
                                    AND Referencia = ?referencia
                             ";
                result = CurrentPersistenceObject.ExecuteCommand(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia));
            }
            return result;
        }

        /// <summary>
        ///  Retorna a distribuicao
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Distribuicao> ListaDistribuicao(string where)
        {
            string sql = @"
                            SELECT 
                                   * 
                            FROM IDA_DISTRIBUICAO
                            WHERE " + where;
            return CurrentPersistenceObject.LoadData(sql);
        }
    }
}


