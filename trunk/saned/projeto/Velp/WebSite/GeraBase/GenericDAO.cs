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

        /// <summary>
        ///  Metodo que retorna os dados de fatura
        /// </summary>
        /// <param name="indice">int quantidade de registro em fatura</param>
        /// <returns>FaturaONP[] array de dados de fatura</returns>
        public FaturaONP[] SelectFatura(int indice)
        {
            // Instancia o objeto do banco de dados
            SQLHelper connect = SQLHelper.Instance;

            string referencia = GetMaiorReferencia();

            FaturaONP[] arrayFatura = new FaturaONP[indice];

            List<FaturaONP> list = new List<FaturaONP>();

            try
            {
                // Adiciona o parametro Referencia
                SqlCeParameter param = connect.cmd.CreateParameter();
                param.ParameterName = "@Referencia";
                param.Value = referencia;//Referencia;
                connect.cmd.Parameters.Add(param);

                //Monta comandText
                connect.cmd.CommandText = "Select * from ONP_FATURA";

                // Executa o comando
                IDataReader dReader;
                dReader = connect.cmd.ExecuteReader();

                // converte os tipos e seta os valores
                while (dReader.Read())
                {

                    FaturaONP Fatura = new FaturaONP();

                    #region
                    if (dReader["seq_fatura"] != DBNull.Value)
                        Fatura.seq_fatura = double.Parse(dReader["seq_fatura"].ToString());
                    else Fatura.seq_fatura = null;

                    if (dReader["cod_referencia"] != DBNull.Value)
                        Fatura.cod_referencia = dReader["cod_referencia"].ToString();
                    else Fatura.cod_referencia = null;

                    if (dReader["seq_roteiro"] != DBNull.Value)
                        Fatura.seq_roteiro = double.Parse(dReader["seq_roteiro"].ToString());
                    else Fatura.seq_roteiro = null;

                    if (dReader["seq_matricula"] != DBNull.Value)
                        Fatura.seq_matricula = int.Parse(dReader["seq_matricula"].ToString());
                    else Fatura.seq_matricula = null;

                    if (dReader["seq_tipo_entrega"] != DBNull.Value)
                        Fatura.seq_tipo_entrega = double.Parse(dReader["seq_tipo_entrega"].ToString());
                    else Fatura.seq_tipo_entrega = null;

                    if (dReader["cod_hidrometro"] != DBNull.Value)
                        Fatura.cod_hidrometro = dReader["cod_hidrometro"].ToString();
                    else Fatura.cod_hidrometro = null;

                    if (dReader["ind_fatura_emitida"] != DBNull.Value)
                        Fatura.ind_fatura_emitida = dReader["ind_fatura_emitida"].ToString();
                    else Fatura.ind_fatura_emitida = null;

                    if (dReader["dat_vencimento"] != DBNull.Value)
                        Fatura.dat_vencimento = DateTime.Parse(dReader["dat_vencimento"].ToString());
                    else Fatura.dat_vencimento = null;

                    if (dReader["val_arredonda_anterior"] != DBNull.Value)
                        Fatura.val_arredonda_anterior = double.Parse(dReader["val_arredonda_anterior"].ToString());
                    else Fatura.val_arredonda_anterior = null;

                    if (dReader["val_arredonda_atual"] != DBNull.Value)
                        Fatura.val_arredonda_atual = double.Parse(dReader["val_arredonda_atual"].ToString());
                    else Fatura.val_arredonda_atual = null;

                    if (dReader["dat_hora_emissao"] != DBNull.Value)
                        Fatura.dat_hora_emissao = DateTime.Parse(dReader["dat_hora_emissao"].ToString());
                    else Fatura.dat_hora_emissao = null;

                    if (dReader["val_valor_faturado"] != DBNull.Value)
                        Fatura.val_valor_faturado = double.Parse(dReader["val_valor_faturado"].ToString());
                    else Fatura.val_valor_faturado = null;

                    if (dReader["dat_leitura"] != DBNull.Value)
                        Fatura.dat_leitura = DateTime.Parse(dReader["dat_leitura"].ToString());
                    else Fatura.dat_leitura = null;

                    if (dReader["dat_leitura_anterior"] != DBNull.Value)
                        Fatura.dat_leitura_anterior = DateTime.Parse(dReader["dat_leitura_anterior"].ToString());
                    else Fatura.dat_leitura_anterior = null;

                    if (dReader["ind_entrega_especial"] != DBNull.Value)
                        Fatura.ind_entrega_especial = dReader["ind_entrega_especial"].ToString();
                    else Fatura.ind_entrega_especial = null;

                    if (dReader["des_banco_debito"] != DBNull.Value)
                        Fatura.des_banco_debito = dReader["des_banco_debito"].ToString();
                    else Fatura.des_banco_debito = null;

                    if (dReader["des_banco_agencia_debito"] != DBNull.Value)
                        Fatura.des_banco_agencia_debito = dReader["des_banco_agencia_debito"].ToString();
                    else Fatura.des_banco_agencia_debito = null;

                    if (dReader["val_quantidade_pendente"] != DBNull.Value)
                        Fatura.val_quantidade_pendente = double.Parse(dReader["val_quantidade_pendente"].ToString());
                    else Fatura.val_quantidade_pendente = null;

                    if (dReader["val_consumo_medio"] != DBNull.Value)
                        Fatura.val_consumo_medio = double.Parse(dReader["val_consumo_medio"].ToString());
                    else Fatura.val_consumo_medio = null;

                    if (dReader["val_desconto"] != DBNull.Value)
                        Fatura.val_desconto = double.Parse(dReader["val_desconto"].ToString());
                    else Fatura.val_desconto = null;

                    if (dReader["des_linha_digitavel"] != DBNull.Value)
                        Fatura.des_linha_digitavel = dReader["des_linha_digitavel"].ToString();
                    else Fatura.des_linha_digitavel = null;

                    if (dReader["des_codigo_barras"] != DBNull.Value)
                        Fatura.des_codigo_barras = dReader["des_codigo_barras"].ToString();
                    else Fatura.des_codigo_barras = null;

                    if (dReader["val_consumo_medido"] != DBNull.Value)
                        Fatura.val_consumo_medido = double.Parse(dReader["val_consumo_medido"].ToString());
                    else Fatura.val_consumo_medido = null;

                    if (dReader["val_consumo_atribuido"] != DBNull.Value)
                        Fatura.val_consumo_atribuido = double.Parse(dReader["val_consumo_atribuido"].ToString());
                    else Fatura.val_consumo_atribuido = null;

                    if (dReader["val_consumo_rateado"] != DBNull.Value)
                        Fatura.val_consumo_rateado = double.Parse(dReader["val_consumo_rateado"].ToString());
                    else Fatura.val_consumo_rateado = null;

                    if (dReader["val_leitura_anterior"] != DBNull.Value)
                        Fatura.val_leitura_anterior = double.Parse(dReader["val_leitura_anterior"].ToString());
                    else Fatura.val_leitura_anterior = null;

                    if (dReader["val_leitura_real"] != DBNull.Value)
                        Fatura.val_leitura_real = double.Parse(dReader["val_leitura_real"].ToString());
                    else Fatura.val_leitura_real = null;

                    if (dReader["val_leitura_atribuida"] != DBNull.Value)
                        Fatura.val_leitura_atribuida = double.Parse(dReader["val_leitura_atribuida"].ToString());
                    else Fatura.val_leitura_atribuida = null;

                    if (dReader["val_impressoes"] != DBNull.Value)
                        Fatura.val_impressoes = double.Parse(dReader["val_impressoes"].ToString());

                    if (dReader["dat_proxima_leitura"] != DBNull.Value)
                        Fatura.dat_proxima_leitura = DateTime.Parse(dReader["dat_proxima_leitura"].ToString());
                    else Fatura.dat_proxima_leitura = null;

                    if (dReader["val_valor_credito"] != DBNull.Value)
                        Fatura.val_valor_credito = double.Parse(dReader["val_valor_credito"].ToString());
                    else Fatura.val_valor_credito = null;
                    #endregion

                    list.Add(Fatura);
                }
                dReader.Close();
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
            finally
            {

            }

            if (list.Count() > 0)
                arrayFatura = list.ToArray();

            return arrayFatura;
        }

    }
}
