using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;
using System.Data.SqlClient;
using System.Data;

namespace Data.DAL
{
    public class LigacoesDAO : BaseDAO<Ligacoes>
    {
        /// <summary>
        ///  Lista todos os 10 primeiros dados
        /// </summary>
        /// <returns></returns>
        public List<Ligacoes> Lista()
        {
            string sql = @"
                            SELECT TOP 10
                                *
				            FROM IDA_LIGACOES
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        ///  Lista as ligaçoes conforme a condição informada
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Ligacoes> RetornaLigacoes(string where)
        {
            List<Ligacoes> lista = new List<Ligacoes>();

            try
            {
                string sql = @"
                            SELECT DISTINCT
                                   LI.Codigo_Logradouro
                                  ,LI.Numero_Imovel
                                  ,LO.nome AS Complemento
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

                            FROM IDA_LIGACOES LI
                            RIGHT JOIN IDA_LOGRADOUROS LO ON LO.Codigo = LI.Codigo_Logradouro 
                            WHERE " + where + @"
                            ORDER BY CDC
                         ";
                lista = CurrentPersistenceObject.LoadData(sql);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }
            return lista;
        }

        /// <summary>
        ///  Lista as ligaçoes conforme a condição informada
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Ligacoes> RetornaLigacoes(int grupo)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
                            FROM IDA_LIGACOES
                            WHERE 
                                Grupo = ?Grupo
                            ORDER BY CDC                                
                         ";
            return CurrentPersistenceObject.LoadData(sql,new GDAParameter("?Grupo",grupo));
        }

        /// <summary>
        ///  Lista todas as matriculas relacionadas (com a matricula pai)
        /// </summary>
        /// <returns></returns>
        public List<Ligacoes> RetornaCDCrelacionadas(int CDC)
        {
            string sql = @"
                            SELECT DISTINCT
 				                             T.Codigo_Logradouro
				                            ,T.Numero_Imovel
				                            ,T.Complemento
				                            ,T.Inscricao
				                            ,T.Grupo
				                            ,T.Setor
				                            ,T.Rota
				                            ,T.Sequencia
				                            ,T.Cachorro
				                            ,T.CDC
				                            ,T.CDC_Pai
				                            ,T.Media
				                            ,T.Medidor
				                            ,T.Categoria_Imovel
				                            ,T.Natureza_Ligacao
				                            ,T.Eco_Res
				                            ,T.Eco_Com
				                            ,T.Eco_Ind
				                            ,T.Eco_Pub
				                            ,T.Eco_Soc
				                            ,T.Bloqueado
				                            ,T.Data_Bloqueio
				                            ,T.Data_DesBloqueio
				                            ,T.Qtde_Debitos
				                            ,T.Mensagem1
				                            ,T.Mensagem2
				                            ,T.Qtde_Registros_Fraude
				                            ,T.Clas_Imovel
				                            ,T.Ident_Consumidor
				                            ,T.Ident_Calculo
				                            ,T.Emite_Conta
				                            ,T.Data_Inst_HD
				                            ,T.Leitura_Inicial_HD
				                            ,T.Qtde_Ponteiros
				                            ,T.Cortar
				                            ,T.Nome
				                            ,T.Agencia
				                            ,T.Banco
				                            ,T.Data_Vencimento
				                            ,T.Calcula_Imposto
				                            ,T.Endereco_Entrega
				                            ,T.Calcula_Conta
				                            ,T.Dias_Bloqueio_Tarifa_Ant
				                            ,T.Dias_Bloqueio_Tarifa_Atual
				                            ,T.Ident_Ligacao_Nova
                            FROM ( 
		                            SELECT DISTINCT
				                             L2.Codigo_Logradouro
				                            ,L2.Numero_Imovel
				                            ,L2.Complemento
				                            ,L2.Inscricao
				                            ,L2.Grupo
				                            ,L2.Setor
				                            ,L2.Rota
				                            ,L2.Sequencia
				                            ,L2.Cachorro
				                            ,L2.CDC
				                            ,L2.CDC_Pai
				                            ,L2.Media
				                            ,L2.Medidor
				                            ,L2.Categoria_Imovel
				                            ,L2.Natureza_Ligacao
				                            ,L2.Eco_Res
				                            ,L2.Eco_Com
				                            ,L2.Eco_Ind
				                            ,L2.Eco_Pub
				                            ,L2.Eco_Soc
				                            ,L2.Bloqueado
				                            ,L2.Data_Bloqueio
				                            ,L2.Data_DesBloqueio
				                            ,L2.Qtde_Debitos
				                            ,L2.Mensagem1
				                            ,L2.Mensagem2
				                            ,L2.Qtde_Registros_Fraude
				                            ,L2.Clas_Imovel
				                            ,L2.Ident_Consumidor
				                            ,L2.Ident_Calculo
				                            ,L2.Emite_Conta
				                            ,L2.Data_Inst_HD
				                            ,L2.Leitura_Inicial_HD
				                            ,L2.Qtde_Ponteiros
				                            ,L2.Cortar
				                            ,L2.Nome
				                            ,L2.Agencia
				                            ,L2.Banco
				                            ,L2.Data_Vencimento
				                            ,L2.Calcula_Imposto
				                            ,L2.Endereco_Entrega
				                            ,L2.Calcula_Conta
				                            ,L2.Dias_Bloqueio_Tarifa_Ant
				                            ,L2.Dias_Bloqueio_Tarifa_Atual
				                            ,L2.Ident_Ligacao_Nova
		                            FROM IDA_LIGACOES L1
		                            JOIN  IDA_LIGACOES L2 ON L2.CDC_Pai = ( 
												                            SELECT 
													                            Case when CDC_Pai = 0 OR CDC_Pai IS NULL
														                             then ?CDC
														                             else CDC_Pai
													                            end
												                            FROM IDA_LIGACOES 
												                            WHERE CDC = ?CDC 
											                               )


		                            UNION ALL

		                            SELECT DISTINCT
				                             L2.Codigo_Logradouro
				                            ,L2.Numero_Imovel
				                            ,L2.Complemento
				                            ,L2.Inscricao
				                            ,L2.Grupo
				                            ,L2.Setor
				                            ,L2.Rota
				                            ,L2.Sequencia
				                            ,L2.Cachorro
				                            ,L2.CDC
				                            ,L2.CDC_Pai
				                            ,L2.Media
				                            ,L2.Medidor
				                            ,L2.Categoria_Imovel
				                            ,L2.Natureza_Ligacao
				                            ,L2.Eco_Res
				                            ,L2.Eco_Com
				                            ,L2.Eco_Ind
				                            ,L2.Eco_Pub
				                            ,L2.Eco_Soc
				                            ,L2.Bloqueado
				                            ,L2.Data_Bloqueio
				                            ,L2.Data_DesBloqueio
				                            ,L2.Qtde_Debitos
				                            ,L2.Mensagem1
				                            ,L2.Mensagem2
				                            ,L2.Qtde_Registros_Fraude
				                            ,L2.Clas_Imovel
				                            ,L2.Ident_Consumidor
				                            ,L2.Ident_Calculo
				                            ,L2.Emite_Conta
				                            ,L2.Data_Inst_HD
				                            ,L2.Leitura_Inicial_HD
				                            ,L2.Qtde_Ponteiros
				                            ,L2.Cortar
				                            ,L2.Nome
				                            ,L2.Agencia
				                            ,L2.Banco
				                            ,L2.Data_Vencimento
				                            ,L2.Calcula_Imposto
				                            ,L2.Endereco_Entrega
				                            ,L2.Calcula_Conta
				                            ,L2.Dias_Bloqueio_Tarifa_Ant
				                            ,L2.Dias_Bloqueio_Tarifa_Atual
				                            ,L2.Ident_Ligacao_Nova
		                            FROM IDA_LIGACOES L1					
		                            JOIN  IDA_LIGACOES L2 ON L2.CDC_Pai = ?CDC
	                             )T
                       ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?CDC", CDC));
        }

        /// <summary>
        ///  Retorna a quantidade de rotas
        /// </summary>
        /// <returns></returns>
        public int QuantidadeRotas(int grupo)
        {
            // Instancia do objeto de conexao com o banco de dados
            System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection();
            string connectionString =  Configuration.ConnectionString;

            // Abre a conexão
            objConn.ConnectionString = connectionString;
            objConn.Open();
            
            string sql = @"
                            SELECT DISTINCT 
                                   Rota 
                            FROM IDA_LIGACOES 
                            WHERE Grupo = "+grupo+@" 
                            ORDER BY Rota
                         ";

            SqlCommand objCmd = new SqlCommand(sql, objConn);
            
            // Executa o comando
            IDataReader dReader;
            dReader = objCmd.ExecuteReader();
            int contador = 0;
            while (dReader.Read())
            {
                contador++;
            }
            dReader.Close();
            objConn.Close();
            return contador;
        }

        /// <summary>
        ///  Retorna a quantidade de rotas
        /// </summary>
        /// <returns></returns>
        public DataTable RetornaRotas(int grupo)
        {
            // Instancia do objeto de conexao com o banco de dados
            string connectionString = Configuration.ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            // Abre a conexão
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();

            string sql = @"
                            SELECT DISTINCT 
                                   Rota 
                            FROM IDA_LIGACOES 
                            WHERE Grupo = " + grupo + @" 
                            ORDER BY Rota
                         ";

            cmd.CommandText = sql;

            DataTable dtRota = new DataTable();
            dtRota.Columns.Add("Rota");

            // Executa o comando
            IDataReader dReader = cmd.ExecuteReader();
            
            // Converte os tipos e seta os valores
            while (dReader.Read())
            {
                object rota = dReader["Rota"];
                dtRota.Rows.Add(new object[] { rota });
            }

            dReader.Close();
            conn.Close();
            return dtRota;
        }

        /// <summary>
        ///  Retorna a quantidade de rotas
        /// </summary>
        /// <returns></returns>
        public DataTable RetornaAcompanhamento(int grupo)
        {
            // Instancia do objeto de conexao com o banco de dados
            string connectionString = Configuration.ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            // Abre a conexão
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();

            string sql = @"
                            SELECT DISTINCT
                                d.grupo
                                ,d.rota
                                ,d.data_carga 
                                ,d.data_descarga as data_ultima_descarga
                                ,(SELECT COUNT(*)from ida_ligacoes where grupo = d.grupo and rota =d.rota) as qtd_matriculas
                                ,(SELECT COUNT(*)from volta_leitura where grupo = d.grupo and rota =d.rota) as qtd_matriculas_descarregadas
                                ,CONVERT(numeric(3,2),((CONVERT(numeric(9,3),(SELECT COUNT(*)from volta_leitura where grupo = d.grupo and rota =d.rota))/CONVERT(numeric(9,3),(select count(*)from ida_ligacoes where grupo = d.grupo and rota =d.rota)))))*100 as perc_descarregado
                            FROM ida_distribuicao d
                            LEFT JOIN volta_leitura l on  d.referencia = l.referencia and d.grupo = l.grupo and d.rota = l.rota  
                            WHERE 
                               d.grupo = " + grupo + @"
                         ";

            cmd.CommandText = sql;

            DataTable dtRota = new DataTable();
            dtRota.Columns.Add("grupo");
            dtRota.Columns.Add("rota");
            dtRota.Columns.Add("data_carga");
            dtRota.Columns.Add("data_ultima_descarga");
            dtRota.Columns.Add("qtd_matriculas");
            dtRota.Columns.Add("qtd_matriculas_descarregadas");
            dtRota.Columns.Add("perc_descarregado");

            IDataReader dReader = null;
            int cont = 0;

            // Executa o comando
            tentativa:
            try
            {
                dReader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                if (cont < 3)
                {
                    cont++;
                    goto tentativa;
                }
                else
                    throw ex;
            }

            // Converte os tipos e seta os valores
            while (dReader.Read())
            {
                object grupo2 = dReader["grupo"];
                object rota2 = dReader["rota"];
                object data_carga = dReader["data_carga"];
                object data_ultima_descarga = dReader["data_ultima_descarga"];
                object qtd_matriculas = dReader["qtd_matriculas"];
                object qtd_matriculas_descarregadas = dReader["qtd_matriculas_descarregadas"];
                object perc_descarregado = dReader["perc_descarregado"];
                dtRota.Rows.Add(new object[] { grupo2, rota2, data_carga, data_ultima_descarga, qtd_matriculas, qtd_matriculas_descarregadas, perc_descarregado });
            }

            dReader.Close();
            conn.Close();
            return dtRota;
        }
    }
}