using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data.SqlServerCe;
using System.Data;
using System.Runtime.InteropServices;
using GeraBase.Model;



namespace GeraBase
{
    /// <summary>
    /// Classe generica de percistencia de dados
    /// </summary>
    /// <example>GenericDAO<teste> teste = new GenericDAO<teste>()</example>
    /// <typeparam name="T">Objeto generico</typeparam>
    public class GenericDAO<T> where T : new()
    {

        /// <summary>
        ///  Recupera a referencia corrente
        /// </summary>
        /// <returns>string contendo a maior referencia encontrada</returns>
        public string GetMaiorReferencia()
        {
            object Referencia = null;

            // instancia do banco de dados
            SQLHelper conect = SQLHelper.Instance;
            try
            {
                //Monta comandText
                conect.cmd.CommandText = @"SELECT MAX(cod_referencia) FROM ONP_ROTEIRO";

                //Retorna a maior referencia do banco
                Referencia = conect.cmd.ExecuteScalar();
                if (Referencia == null)
                    throw new Exception("Falha ao retornar a referencia.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Referencia.ToString();
        }
        
        /// <summary>
        ///  Metodo de insert Generico
        /// </summary>
        /// <param name="values">T[] , array de Model</param>
        /// <param name="tableName">string ,nome da tabela mapeada</param>
        /// <param name="campoChave">string ,nome do campo chave</param>
        public void Insert(T[] values, string tableName, string campoChave)
        {
            // instancia do banco de dados
            SQLHelper conect = SQLHelper.Instance;

            //Percorre todas as propriedades da classe T
            Type type = typeof(T);
            PropertyInfo[] property = type.GetProperties();
            int max = 0;

            string nome = "", nomeInsert = "";
            string valor = "", valuesInsert = "";

            //Recupera nome das propriedades
            foreach (PropertyInfo prop in property)
            {
                nomeInsert += prop.Name + ",";
                valuesInsert += "@" + prop.Name + ",";
            }
            
            //Monta comandText
            conect.cmd.CommandText = "INSERT INTO " + tableName + " (" + nomeInsert.TrimEnd(',') + ") VALUES(" + valuesInsert.TrimEnd(',') + ");";

            List<SqlCeParameter> parametros = new List<SqlCeParameter>();
            
            //Percorre todos os registros
            foreach (T valorItem in values)
            {
                // Limpa os parametros
                parametros.Clear();
                conect.cmd.Parameters.Clear();
                
                // percorre cada parametro do registro
                foreach (PropertyInfo prop in property)
                {
                    SqlCeParameter param = conect.cmd.CreateParameter();
                    param.ParameterName = "@" + prop.Name;

                    // Verifica se o valor e nulo ou se o campo incremental foi informado
                    if ( prop.Name.Equals(campoChave))
                    {
                        // adiciona a chave incremental
                        max++;
                        param.Value = max;
                    }
                    else if (prop.GetValue(valorItem, null) == null)
                    {   // Insere o valor nulo
                        param.Value = System.DBNull.Value;
                    }
                    else
                    {
                        param.Value = prop.GetValue(valorItem, null);
                    }
                    // Adciona os itens de parametros
                    parametros.Add(param);

                }
                try
                {
                    // Adicona todos os parametros a connecção
                    conect.cmd.Parameters.AddRange(parametros.ToArray());

                    // Executa o comando
                    conect.cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        ///  Metodo responsavel por Apagar a base de dados
        /// </summary>
        /// <returns>Boolean , verifica se o banco esta limpado</returns>
        public Boolean LimpaBanco()
        {
            // Variavel de retorno
            Boolean retorno = true;

            // Instancia o objeto do banco de dados
            SQLHelper connect = SQLHelper.Instance;

            // SQL PARA RETORNAR TODAS AS TABELAS DO BANCO DE DADOS
            connect.cmd.CommandText = @"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";

            try
            {
                IDataReader dReader;
                dReader = connect.cmd.ExecuteReader();

                // Percorre todas as tabelas do banco de dados
                while (dReader.Read())
                {
                    // Deleta todos os dados da tabela
                    connect.cmd.CommandText = @"DELETE " + dReader["TABLE_NAME"] + ";\n";
                    connect.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return retorno;
        }


        /// <summary>
        ///  Insere os dados na tabela de fatura categoria - ONP_FATURA_CATEGORIA
        /// </summary>
        /// <param name="faturaCategoria">FaturaCategoriaONP[] , array de dados de fatura categoria</param>
        /// <param name="fatura">FaturaONP[] , array de dados de fatura</param>
        /// <returns>bool ,verificador se os dados foram inseridos</returns>
        public bool InsertFaturaCategoria(FaturaCategoriaONP[] faturaCategoria, FaturaONP[] fatura)
        {
            // Variavel de retorno
            bool retorno = true;

            // Total (para o laço)
            int total = faturaCategoria.Count();

            // Converte o array para uma lista
            List<FaturaONP> listaFatura = new List<FaturaONP>(fatura);
            try
            {
                for (int i = 0; i < total; i++)
                {
                    // Busca o seq_fatura correspondente
                    List<FaturaONP> faturaAux = listaFatura.FindAll(delegate(FaturaONP type) { return type.seq_matricula == faturaCategoria[i].seq_matricula && type.cod_referencia == faturaCategoria[i].cod_referencia; });

                    // Verifica se existe item correspondente
                    if (faturaAux.Count() > 0)
                        faturaCategoria[i].seq_fatura = int.Parse(faturaAux[0].seq_fatura.ToString());
                }

                // INSERE OS DADOS
                GenericDAO<FaturaCategoriaONP> ObjFaturaCategoria = new GenericDAO<FaturaCategoriaONP>();
                ObjFaturaCategoria.Insert(faturaCategoria, "ONP_FATURA_CATEGORIA", null);
            }
            catch (Exception ex)
            {
                retorno = false;
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        /// <summary>
        ///  Insere os dados na tabela de fatura aviso - ONP_FATURAS_AVISO
        /// </summary>
        /// <param name="faturaCategoria">FaturasAvisoONP[] , array de dados </param>
        /// <param name="fatura">FaturaONP[] , array de dados de fatura</param>
        /// <returns>bool ,verificador se os dados foram inseridos</returns>
        public bool InsertFaturaAviso(FaturasAvisoONP[] faturaAviso, FaturaONP[] fatura)
        {
            // Variavel de retorno
            bool retorno = true;

            // Total (para o laço)
            int total = faturaAviso.Count();

            // Converte o array para uma lista
            List<FaturaONP> listaFatura = new List<FaturaONP>(fatura);
            try
            {
                for (int i = 0; i < total; i++)
                {

                    // Busca o seq_fatura
                    List<FaturaONP> faturaAux = listaFatura.FindAll(delegate(FaturaONP type) { return type.seq_matricula == faturaAviso[i].seq_matricula && type.cod_referencia == faturaAviso[i].cod_referencia; });

                    // Verifica se existe item correspondente
                    if (faturaAux.Count() > 0)
                        faturaAviso[i].seq_fatura = int.Parse(faturaAux[0].seq_fatura.ToString());
                }

                // INSERE OS DADOS
                GenericDAO<FaturasAvisoONP> ObjFaturaAviso = new GenericDAO<FaturasAvisoONP>();
                ObjFaturaAviso.Insert(faturaAviso, "ONP_FATURAS_AVISO", null);
            }
            catch (Exception ex)
            {
                retorno = false;
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        /// <summary>
        /// Insere os dados na tabela de referencia pendente - ONP_REFERENCIA_PENDENTE
        /// </summary>
        /// <param name="faturaCategoria">ReferenciaPendenteONP[] , array de dados </param>
        /// <param name="fatura">FaturaONP[] , array de dados de fatura</param>
        /// <returns>bool ,verificador se os dados foram inseridos</returns>
        public bool InsertReferenciaPendente(ReferenciaPendenteONP[] referenciaPendente,FaturaONP[] fatura)
        {
            // Variavel de retorno
            bool retorno = true;

            // Total (para o laço)
            int total = referenciaPendente.Count();

            // Converte o array para uma lista
            List<FaturaONP> listaFatura = new List<FaturaONP>(fatura);

            // Lista de refeencia pendente
            List<ReferenciaPendenteONP> listaReferenciaPendente = new List<ReferenciaPendenteONP>();
            try
            {
                for (int i = 0; i < total; i++)
                {
                    // Busca o seq_fatura correspondente
                    List<FaturaONP> faturaAux = listaFatura.FindAll(delegate(FaturaONP type) { return type.seq_matricula == referenciaPendente[i].seq_matricula && type.dat_vencimento == referenciaPendente[i].dat_vencimento && type.cod_referencia != "1974.05"; });

                    // Verifica se existe item correspondente
                    if (faturaAux.Count() > 0)
                    {
                        referenciaPendente[i].seq_fatura = int.Parse(faturaAux[0].seq_fatura.ToString());
                        listaReferenciaPendente.Add(referenciaPendente[i]);
                    }
                }

                // INSERE OS DADOS
                GenericDAO<ReferenciaPendenteONP> ObjFaturaAviso = new GenericDAO<ReferenciaPendenteONP>();
                ObjFaturaAviso.Insert(listaReferenciaPendente.ToArray(), "ONP_REFERENCIA_PENDENTE", null);
            }
            catch (Exception ex)
            {
                retorno = false;
                throw ex;
            }
            return retorno;
        }

        /// <summary>
        ///  Insere os dados na tabela de aviso debito - ONP_AVISO_DEBITO
        /// </summary>
        /// <param name="faturaCategoria">AvisoDebito[] , array de dados </param>
        /// <param name="fatura">FaturaONP[] , array de dados de fatura</param>
        /// <returns>bool ,verificador se os dados foram inseridos</return>
        public bool InsertAvisoDebito(AvisoDebito[] AvisoDebito, FaturaONP[] fatura)
        {
            // Instancia o objeto do banco de dados
            SQLHelper connect = SQLHelper.Instance;

            // Variavel de retorno
            bool retorno = true;

            // Total (para o laço)
            int total = AvisoDebito.Count();

            // Converte o array para uma lista
            List<FaturaONP> listaFatura = new List<FaturaONP>(fatura);

            try
            {
                for (int i = 0; i < total; i++)
                {
                    // Busca o seq_fatura   (OBS: REFERENCIA FIXA PARA LOCALIZAR A FATURA CORRESPONDENTE)
                    List<FaturaONP> faturaAux = listaFatura.FindAll(delegate(FaturaONP type) { return type.seq_matricula == AvisoDebito[i].seq_matricula && type.cod_referencia == "1974.05"; });
                    
                    // Verifica se existe item correspondente
                    if (faturaAux.Count() > 0)
                        AvisoDebito[i].seq_fatura = int.Parse(faturaAux[0].seq_fatura.ToString());

                    // Verififca se existem debitos e não existe fatura
                    if (faturaAux.Count() < 0 && AvisoDebito[i].val_quantidade_debito > 0)
                    {
                        throw new Exception("Falha na geração do aviso da matricula: "+AvisoDebito[i].seq_matricula+" a fatura não existe na base DIADEMA_IV ou não foi retornada.");
                    }
                }

                // INSERE OS DADOS
                GenericDAO<AvisoDebito> ObjAvisoDebito = new GenericDAO<AvisoDebito>();
                ObjAvisoDebito.Insert(AvisoDebito, "ONP_AVISO_DEBITO", null);
            }
            catch (Exception ex)
            {
                retorno = false;
                throw new Exception(ex.Message);
            }
            return retorno;
        }

    }
}
