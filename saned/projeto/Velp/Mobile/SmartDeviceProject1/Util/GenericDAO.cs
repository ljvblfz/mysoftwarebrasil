using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data.SqlServerCe;
using DeviceProject.Util;
using System.Data;
using DeviceProject.referencia;
using System.Runtime.InteropServices;
using DeviceProject.DATA.dataSaned.Flow;
using DeviceProject.Config;


namespace DeviceProject.DATA
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
        ///  Metodo que retorna uma lista com os dados de novo registro
        /// </summary>
        /// <returns>lista de dados da tabela novo registro</returns>
        public List<VoltaNovoRegistro> SelectVoltaNovoRegistro()
        {
            // instancia do banco de dados
            SQLHelper conect = SQLHelper.Instance;
            
            // Lista de retorno
            List<VoltaNovoRegistro> list = new List<VoltaNovoRegistro>();

            //Monta comandText
            conect.cmd.CommandText = SqlVolta.Query("VOLTA_NOVO_REGISTRO");

            try
            {
                // Executa o comando
                IDataReader dReader;
                dReader = conect.cmd.ExecuteReader();

                // Converte os tipos e seta os valores
                while (dReader.Read())
                {

                    VoltaNovoRegistro NovoRegistro = new VoltaNovoRegistro();

                    NovoRegistro.Grupo = int.Parse(dReader["Grupo"].ToString());
                    NovoRegistro.Rota = int.Parse(dReader["Rota"].ToString().Remove(0, 5));

                    if (dReader["Complemento"] != DBNull.Value)
                        NovoRegistro.Complemento = dReader["Complemento"].ToString();
                    else
                        NovoRegistro.Complemento = null;

                    if (dReader["Medidor"] != DBNull.Value)
                        NovoRegistro.Medidor = dReader["Medidor"].ToString();
                    else
                        NovoRegistro.Medidor = null;

                    if (dReader["Nome"] != DBNull.Value)
                        NovoRegistro.Nome = dReader["Nome"].ToString();
                    else
                        NovoRegistro.Nome = null;

                    if (dReader["OBS"] != DBNull.Value)
                        NovoRegistro.OBS = dReader["OBS"].ToString();
                    else
                        NovoRegistro.OBS = null;

                    if (dReader["referencia"] != DBNull.Value)
                        NovoRegistro.referencia = DateTime.Parse(dReader["Referencia"].ToString().Replace('.', '-') + "-01");

                    else
                        NovoRegistro.referencia = null;

                    if (dReader["logradouro"] != DBNull.Value)
                        NovoRegistro.logradouro = dReader["logradouro"].ToString();
                    else
                        NovoRegistro.logradouro = null;

                    if (dReader["numero"] != DBNull.Value)
                        NovoRegistro.numero = int.Parse(dReader["numero"].ToString());
                    else
                        NovoRegistro.numero = null;

                    // adciona a lista
                    list.Add(NovoRegistro);
                }
                dReader.Close();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            return list;
        }

        /// <summary>
        ///  Metodo que retorna uma lista de dados de alteração
        /// </summary>
        /// <returns>lista da model voltaAlteração</returns>
        public List<VoltaAlteracao> SelectVoltaAlteracao()
        {
            // instancia do banco de dados
            SQLHelper conect = SQLHelper.Instance;

            // Lista de retorno
            List<VoltaAlteracao> list = new List<VoltaAlteracao>();

            //Monta comandText
            conect.cmd.CommandText = SqlVolta.Query("VOLTA_ALTERACAO");
            try
            {
                // Executa o comando
                IDataReader dReader;
                dReader = conect.cmd.ExecuteReader();

                // converte os tipos e seta os valores
                while (dReader.Read())
                {

                    VoltaAlteracao Alteracao = new VoltaAlteracao();

                    Alteracao.Grupo = int.Parse(dReader["Grupo"].ToString());
                    Alteracao.CDC = int.Parse(dReader["CDC"].ToString());

                    if (dReader["Numero_Imovel"] != DBNull.Value)
                        Alteracao.Numero_Imovel = int.Parse(dReader["Numero_Imovel"].ToString());
                    else
                        Alteracao.Numero_Imovel = 0;

                    if (dReader["Complemento"] != DBNull.Value)
                        Alteracao.Complemento = dReader["Complemento"].ToString();
                    else
                        Alteracao.Complemento = null;

                    if (dReader["Medidor"] != DBNull.Value)
                        Alteracao.Medidor = dReader["Medidor"].ToString();
                    else
                        Alteracao.Medidor = null;

                    if (dReader["Nome_Consumidor"] != DBNull.Value)
                        Alteracao.Nome_Consumidor = dReader["Nome_Consumidor"].ToString();
                    else
                        Alteracao.Nome_Consumidor = null;

                    if (dReader["observacao"] != DBNull.Value)
                        Alteracao.observacao = dReader["observacao"].ToString();
                    else
                        Alteracao.observacao = null;

                    if (dReader["referencia"] != DBNull.Value)
                        Alteracao.referencia = DateTime.Parse(dReader["Referencia"].ToString().Replace('.', '-') + "-01");

                    list.Add(Alteracao);
                }
                dReader.Close();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            return list;
        }

        /// <summary>
        ///  Metodo que retorna dados de volta leitura
        /// </summary>
        /// <returns>List<VoltaLeitura> ,uma lista com os dados da model de voltaLeitura</returns>
        public List<VoltaLeitura> SelectVoltaLeitura(int setor)
        {
            // Conexão com o banco
            SQLHelper conect = SQLHelper.Instance;

            // Lista de retorno
            List<VoltaLeitura> list = new List<VoltaLeitura>();

            //Monta comandText
            conect.cmd.CommandText = SqlVolta.Query("VOLTA_LEITURA");
            try
            {
                // Executa o comando
                IDataReader dReader;
                dReader = conect.cmd.ExecuteReader();

                // converte os tipos e seta os valores
                while (dReader.Read())
                {
                    VoltaLeitura Leitura = new VoltaLeitura();
                    try
                    {
                        if (dReader["Grupo"] != DBNull.Value)
                            Leitura.Grupo = int.Parse(dReader["Grupo"].ToString());

                        if (dReader["Setor"] != DBNull.Value)
                            Leitura.Setor = int.Parse(dReader["Setor"].ToString());

                        if (dReader["Rota"] != DBNull.Value)
                            Leitura.Rota = int.Parse(dReader["Rota"].ToString());

                        if (dReader["CDC"] != DBNull.Value)
                            Leitura.CDC = int.Parse(dReader["CDC"].ToString());

                        if (dReader["Ident_fraude"] != DBNull.Value)
                            Leitura.Ident_fraude = dReader["Ident_fraude"].ToString();

                        if (dReader["Indic_cortado"] != DBNull.Value)
                            Leitura.Indic_cortado = dReader["Indic_cortado"].ToString();

                        if (dReader["Flag_Calculo"] != DBNull.Value)
                            Leitura.Flag_Calculo = dReader["Flag_Calculo"].ToString();

                        if (dReader["Flag_Emissao"] != DBNull.Value)
                            Leitura.Flag_Emissao = dReader["Flag_Emissao"].ToString();

                        if (dReader["Referencia"] != DBNull.Value)
                            Leitura.Referencia = DateTime.Parse(dReader["Referencia"].ToString());
                        else
                            Leitura.Referencia = DateTime.Now;

                        if (dReader["Data_Emissao"] != DBNull.Value)
                            Leitura.Data_Emissao = DateTime.Parse(dReader["Data_Emissao"].ToString());
                        else
                            Leitura.Data_Emissao = DateTime.Now;

                        if (dReader["Categoria"] != DBNull.Value)
                            Leitura.Categoria = int.Parse(dReader["Categoria"].ToString());

                        if (dReader["Eco_Res"] != DBNull.Value)
                            Leitura.Eco_Res = int.Parse(dReader["Eco_Res"].ToString());

                        if (dReader["Eco_Com"] != DBNull.Value)
                            Leitura.Eco_Com = int.Parse(dReader["Eco_Com"].ToString());

                        if (dReader["Eco_Ind"] != DBNull.Value)
                            Leitura.Eco_Ind = int.Parse(dReader["Eco_Ind"].ToString());

                        if (dReader["Eco_Pub"] != DBNull.Value)
                            Leitura.Eco_Pub = int.Parse(dReader["Eco_Pub"].ToString());

                        if (dReader["Eco_Soc"] != DBNull.Value)
                            Leitura.Eco_Soc = int.Parse(dReader["Eco_Soc"].ToString());

                        if (dReader["Flag_Lido"] != DBNull.Value)
                            Leitura.Flag_Lido = dReader["Flag_Lido"].ToString();

                        if (dReader["Flag_Faturado"] != DBNull.Value)
                            Leitura.Flag_Faturado = dReader["Flag_Faturado"].ToString();

                        // Valores que podem ser nulos
                        if (dReader["Leitura_Ajustada"] != DBNull.Value)
                            Leitura.Leitura_Ajustada = int.Parse(dReader["Leitura_Ajustada"].ToString());
                        else
                            Leitura.Leitura_Ajustada = 0;

                        if (dReader["Leitura_Real"] != DBNull.Value)
                            Leitura.Leitura_Real = int.Parse(dReader["Leitura_Real"].ToString());
                        else
                            Leitura.Leitura_Real = 0;

                        if (dReader["Data_Leitura"] != DBNull.Value)
                            Leitura.Data_Leitura = DateTime.Parse(dReader["Data_Leitura"].ToString());
                        else
                            Leitura.Data_Leitura = null;

                        if (dReader["Consumo_Ajustado"] != DBNull.Value)
                            Leitura.Consumo_Ajustado = int.Parse(dReader["Consumo_Ajustado"].ToString());
                        else
                            Leitura.Consumo_Ajustado = 0;

                        if (dReader["Consumo_Rateado"] != DBNull.Value)
                            Leitura.Consumo_Rateado = int.Parse(dReader["Consumo_Rateado"].ToString());
                        else
                            Leitura.Consumo_Rateado = 0;

                        if (dReader["Ocorrencia"] != DBNull.Value)
                            Leitura.Ocorrencia = int.Parse(dReader["Ocorrencia"].ToString());
                        else
                            Leitura.Ocorrencia = null;

                        if (dReader["Ocorrencia2"] != DBNull.Value)
                            Leitura.Ocorrencia2 = int.Parse(dReader["Ocorrencia2"].ToString());
                        else
                            Leitura.Ocorrencia2 = null;

                        if (dReader["Valor_Saldo_Debito"] != DBNull.Value)
                            Leitura.Valor_Saldo_Debito = Decimal.Parse(dReader["Valor_Saldo_Debito"].ToString());
                        else
                            Leitura.Valor_Saldo_Debito = 0;

                        if (dReader["Valor_IR"] != DBNull.Value)
                            Leitura.Valor_IR = Decimal.Parse(dReader["Valor_IR"].ToString());
                        else
                            Leitura.Valor_IR = 0;

                        if (dReader["Valor_CSLL"] != DBNull.Value)
                            Leitura.Valor_CSLL = Decimal.Parse(dReader["Valor_CSLL"].ToString());
                        else
                            Leitura.Valor_CSLL = 0;

                        if (dReader["Valor_PIS"] != DBNull.Value)
                            Leitura.Valor_PIS = Decimal.Parse(dReader["Valor_PIS"].ToString());
                        else
                            Leitura.Valor_PIS = 0;

                        if (dReader["Valor_COFINS"] != DBNull.Value)
                            Leitura.Valor_COFINS = Decimal.Parse(dReader["Valor_COFINS"].ToString());
                        else
                            Leitura.Valor_COFINS = 0;

                        if (dReader["Esgoto_Ajustado"] != DBNull.Value)
                            Leitura.Esgoto_Ajustado = int.Parse(dReader["Esgoto_Ajustado"].ToString());
                        else
                            Leitura.Esgoto_Ajustado = null;

                        if (dReader["Dias_Consumo"] != DBNull.Value)
                            Leitura.Dias_Consumo = int.Parse(dReader["Dias_Consumo"].ToString());
                        else
                            Leitura.Dias_Consumo = 0;

                        if (dReader["Operador"] != DBNull.Value)
                            Leitura.Operador = int.Parse(dReader["Operador"].ToString());
                        else
                            Leitura.Operador = null;

                        if (dReader["Vencimento"] != DBNull.Value)
                            Leitura.Vencimento = DateTime.Parse(dReader["Vencimento"].ToString());
                        else
                            Leitura.Vencimento = null;

                        if (dReader["Valor_Agua"] != DBNull.Value)
                            Leitura.Valor_Agua = Decimal.Parse(dReader["Valor_Agua"].ToString());
                        else
                            Leitura.Valor_Agua = 0;

                        if (dReader["Valor_Esgoto"] != DBNull.Value)
                            Leitura.Valor_Esgoto = Decimal.Parse(dReader["Valor_Esgoto"].ToString());
                        else
                            Leitura.Valor_Esgoto = 0;

                        if (dReader["Valor_Credito"] != DBNull.Value)
                            Leitura.Valor_Credito = Decimal.Parse(dReader["Valor_Credito"].ToString());
                        else
                            Leitura.Valor_Credito = 0;

                        if (dReader["Valor_Reducao"] != DBNull.Value)
                            Leitura.Valor_Reducao = Decimal.Parse(dReader["Valor_Reducao"].ToString());
                        else
                            Leitura.Valor_Reducao = 0;

                        if (dReader["Flag_situacao_movimento"] != DBNull.Value)
                            Leitura.Flag_Situacao_Movimento = dReader["Flag_situacao_movimento"].ToString();
                        else
                            Leitura.Flag_Situacao_Movimento = null;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    list.Add(Leitura);
                    GC.SuppressFinalize(Leitura);
                }
                dReader.Close();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            return setEconomiaMista(list);
        }

        /// <summary>
        ///  Retorna os dados de roteiro
        /// </summary>
        /// <returns>List<VoltaRoteiro> ,uma lista com os dados da model voltaRoteiro</returns>
        public List<VoltaRoteiro> SelectVoltaRoteiro()
        {
            // Abre uma conecxão com o banco
            SQLHelper connect = SQLHelper.Instance;

            // Lista de retorno
            List<VoltaRoteiro> list = new List<VoltaRoteiro>();

            try
            {
                // Adiciona o parametro Referencia
                SqlCeParameter param = connect.cmd.CreateParameter();
                param.ParameterName = "@Referencia";
                param.Value = GetMaiorReferencia();//Referencia;
                connect.cmd.Parameters.Add(param);

                //Monta comandText
                connect.cmd.CommandText = SqlVolta.Query("VOLTA_ROTEIRO");

                // Executa o comando
                IDataReader dReader;
                dReader = connect.cmd.ExecuteReader();

                // converte os tipos e seta os valores
                while (dReader.Read())
                {

                    VoltaRoteiro Roteiro = new VoltaRoteiro();
                    Roteiro.Referencia = DateTime.Parse(dReader["Referencia"].ToString().Replace('.', '-') + "-01");
                    Roteiro.Grupo = int.Parse(dReader["Grupo"].ToString());
                    Roteiro.Rota = int.Parse(dReader["Rota"].ToString().Remove(0, 5));
                    Roteiro.Data_Inicial = DateTime.Parse(dReader["Data_Inicial"].ToString());
                    Roteiro.Data_Final = DateTime.Parse(dReader["Data_Final"].ToString());
                    Roteiro.Data_Envio = DateTime.Parse(dReader["Data_Envio"].ToString());
                    Roteiro.Aparelho = int.Parse(dReader["Aparelho"].ToString());
                    Roteiro.Chuva = dReader["Chuva"].ToString();
                    Roteiro.Data_Processamento = null;
                    Roteiro.Data_Problema = null;

                    list.Add(Roteiro);
                }
                dReader.Close();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return list;
        }

        /// <summary>
        ///  Metodo que retorna uma lista de dados de VoltaLogAtendimento
        /// </summary>
        /// <returns>List<VoltaLogAtendimento> ,retorna uma tabela com os dados de VoltaLogAtendimento</returns>
        public List<VoltaLogAtendimento> SelectVoltaLodAtendimento()
        {
            // Conexão com o banco de dados
            SQLHelper conect = SQLHelper.Instance;

            // Lista de retorno
            List<VoltaLogAtendimento> list = new List<VoltaLogAtendimento>();

            // Agente
            string codAgente = null;

            // Retorna dados do ultimo agente cadastrado
            codAgente = GetAgenteCadastrador();

            try
            {
                //Monta comandText
                conect.cmd.CommandText = SqlVolta.Query("VOLTA_LOG_ATENDIMENTO");

                // Executa o comando
                IDataReader dReader;
                dReader = conect.cmd.ExecuteReader();

                // converte os tipos e seta os valores
                while (dReader.Read())
                {

                    VoltaLogAtendimento logAtendimento = new VoltaLogAtendimento();
                    if (dReader["Grupo"] != DBNull.Value)
                        logAtendimento.Grupo = int.Parse(dReader["Grupo"].ToString());

                    if (dReader["CDC"] != DBNull.Value)
                        logAtendimento.CDC = int.Parse(dReader["CDC"].ToString());

                    if (dReader["Tipo"] != DBNull.Value)
                        logAtendimento.Tipo = (dReader["Tipo"].ToString());

                    if (dReader["Referencia"] != DBNull.Value)
                        logAtendimento.Referencia = DateTime.Parse(dReader["Referencia"].ToString());

                    if (dReader["Data_Emissao"] != DBNull.Value)
                        logAtendimento.Data_Emissao = DateTime.Parse(dReader["Data_Emissao"].ToString());

                    if (dReader["Operador"] != DBNull.Value)
                        logAtendimento.Operador = int.Parse(codAgente);

                    list.Add(logAtendimento);
                }
                dReader.Close();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            return list;
        }

        /// <summary>
        /// Recupera o agente que efetuou as leituras
        /// </summary>
        /// <returns>string ,retorna o codigo do agente</returns>
        public string GetAgenteCadastrador()
        {
            string codAgente = DeviceProject.Config.ConfiguracaoPDA.CurrentInstance.Username;

            // Instancia o objeto do banco de dados
            SQLHelper connect = SQLHelper.Instance;

            try
            {
                // Retorna a ultima fatura emitida
                connect.cmd.CommandText = @"SELECT MAX(dat_hora_emissao) FROM ONP_FATURA";

                //Retorna o dado
                object ultimaLeitura = connect.cmd.ExecuteScalar();

                if (ultimaLeitura != null)
                {
                    SqlCeParameter param1 = connect.cmd.CreateParameter();
                    param1.ParameterName = "@dat_hora_emissao";
                    param1.Value = ultimaLeitura;
                    connect.cmd.Parameters.Add(param1);

                    // Retorna a ultima fatura emitida
                    connect.cmd.CommandText = @"
                                                SELECT 
                                                    seq_matricula 
                                                FROM onp_fatura 
                                                WHERE 
                                                    dat_hora_emissao = @dat_hora_emissao
                                                ";
                    //Retorna o dado
                    object matricula = connect.cmd.ExecuteScalar();

                    if (matricula != null)
                    {
                        // Rtorna o codigo do agente
                        connect.cmd.CommandText = @"
                                                    SELECT 
	                                                    cod_agente 
                                                    FROM onp_movimento 
                                                    WHERE seq_matricula = " + matricula.ToString() + @"
                                                    ";
                        object codAgenteAUX = connect.cmd.ExecuteScalar();

                        if (codAgenteAUX != null)
                            codAgente = codAgenteAUX.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codAgente;
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

        /// <summary>
        ///  Metodo que verifica a quantidade de leituras realizadas
        /// </summary>
        /// <returns>numero de matriculas com leitura realizadas</returns>
        public int VerficaCarga()
        {
            // Quantidade de leituras
            int Quantidade = 0;

            // Recupera a maior referencia
            string Referencia = GetMaiorReferencia();

            // instancia do banco de dados
            SQLHelper conect = SQLHelper.Instance;

            try
            {
                // Instacia do objeto parametro
                SqlCeParameter Param = conect.cmd.CreateParameter();

                // Adiciona o parametro Referencia
                conect.cmd.Parameters.Clear();
                Param.ParameterName = "@Referencia";
                Param.Value = Referencia;
                conect.cmd.Parameters.Add(Param);

                //SQL
                conect.cmd.CommandText = @"
                                        SELECT 
	                                        COUNT(*) 
                                        FROM ONP_MOVIMENTO 
                                        WHERE 
	                                        cod_referencia = @Referencia
	                                        AND dat_leitura IS NOT NULL
                                      ";

                // retorna a quantidade de registro para descarga
                object QuantidadeRegistros = conect.cmd.ExecuteScalar();
                if (QuantidadeRegistros != null)
                    Quantidade = int.Parse(QuantidadeRegistros.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Quantidade;
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
        ///  Implementa a regra de valor faturado da economia mista
        /// </summary>
        /// <param name="listaVoltaLeitura">lita de dados retornados do banco</param>
        /// <returns>uma lista com os valores setados</returns>
        public List<VoltaLeitura> setEconomiaMista(List<VoltaLeitura> listaVoltaLeitura)
        {
            // Lista de retorno
            List<VoltaLeitura> listaRetorno = new List<VoltaLeitura>();

            // Percorre todos os dados da lista
            foreach (VoltaLeitura item in listaVoltaLeitura)
            {
                if (item.Categoria == 5)
                {
                    VoltaLeitura objAUX = new VoltaLeitura();
                    objAUX = getValValorFatorado(item);
                    listaRetorno.Add(objAUX);
                }
                else
                {
                    listaRetorno.Add(item);
                }
            }
            return listaRetorno;
        }

        /// <summary>
        ///  Retorna o valor da agua e do esgoto
        /// </summary>
        /// <param name="model">objeto modelo de volta_leitura</param>
        /// <returns>objeto modelo de volta_leitura (ALTERADO VALOR DE AGUA E ESGOTO)</returns>
        public VoltaLeitura getValValorFatorado(VoltaLeitura model)
        {
            // Instancia o objeto do banco de dados
            SQLHelper connect = SQLHelper.Instance;

            // Adiciona o parametro Referencia
            SqlCeParameter param = connect.cmd.CreateParameter();
            param.ParameterName = "@seq_matricula";
            param.Value = model.CDC;
            connect.cmd.Parameters.Add(param);
            
            // Valor agua
            connect.cmd.CommandText = @"
                                        SELECT 
                                            SUM(val_valor_faturado) 
                                        FROM ONP_FATURA_TAXA FX
                                        WHERE 
                                            FX.seq_matricula = @seq_matricula 
                                            AND FX.seq_taxa = 1";
            object valorAgua = connect.cmd.ExecuteScalar();
            if (valorAgua != null)
                model.Valor_Agua = decimal.Parse(valorAgua.ToString());

            // Valor esgoto
            connect.cmd.CommandText = @"
                                        SELECT 
                                            SUM(val_valor_faturado) 
                                        FROM ONP_FATURA_TAXA FX
                                        WHERE 
                                            FX.seq_matricula = @seq_matricula 
                                            AND FX.seq_taxa = 2";
            object valorEsgoto = connect.cmd.ExecuteScalar();
            if (valorEsgoto != null)
                model.Valor_Esgoto = decimal.Parse(valorEsgoto.ToString());

            return model;
        }

    }
}
