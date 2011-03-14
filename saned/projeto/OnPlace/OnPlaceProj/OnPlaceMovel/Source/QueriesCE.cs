using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Text;
using System.Reflection;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using Strategos.Api.Database.Interface;
using Strategos.Api.Database.Attributes;
using System.Data;

namespace Strategos.Api.Database.Impl {
    /// <summary>
    /// Classe com query SQL
    /// </summary>
    public static class QueriesCE {
        /// <summary>
        /// Lista as tarifas de uma taxa que estão entre a data de leitura anterior e atual
        /// </summary>
        /// <remarks>
        /// Funcionamento:
        /// <list type="bullet">
        /// <item><description>Conecta no banco de dados criando um novo ConnectionCE</description></item>
        /// <item><description>Monta uma query para a tabela ONP_TAXA_TARIFA procurando tarifas que tem dat_inicio entre datLeituraAnterior e datLeituraAtual do <paramref name="movimento"/>, seq_categoria igual <paramref name="seqCategoria"/>, seq_taxa igual a <paramref name="seqTaxa"/> e ind_dias_consumo igual a 'S'</description></item>
        /// <item><description>Chama o metodo ExecuteReader da conexão criada.</description></item>
        /// <item><description>Enquanto o metodo Read() do reader retornado retorna true:</description></item>
        /// <item><description>- Cria um novo OnpTaxaTarifa e copia os campos do reader para este obejto criado</description></item>
        /// <item><description>- Adiciona o objeto criado em uma lista</description></item>
        /// <item><description>Chama os metodos Dispose() e Close() do reader</description></item>
        /// <item><description>Desconecta do banco de dados</description></item>
        /// <item><description>Retorna a lista preenchida ou uma lista vazia caso nao tenha achado nenhum registro</description></item>
        /// </list>
        /// </remarks>
        /// <param name="movimento">movimento do qual sao extraidas as datas de leitura</param>
        /// <param name="seqCategoria">Sequencial da categoria para filtrar as tarifas</param>
        /// <param name="seqTaxa">Sequencial da taxa para filtrar as tarifas</param>
        /// <returns>Retorna a coleção com as tarifas encontradas ou null</returns>
        public static Collection<OnpTaxaTarifa> procuraTarifa(OnpMovimento movimento, int seqCategoria, int seqTaxa) {
            Collection<OnpTaxaTarifa> retorno = new Collection<OnpTaxaTarifa>();

            ICommand command = ConnectionCE.Instancia.NovoCommand();

            DateTime leituraAnterior = movimento.DatLeituraAnterior.Value.Date;
            DateTime leituraAtual = movimento.DatLeitura.Value.Date;
            IDataReader dataReader = null;

            string query =
                "SELECT * " +
                "FROM ONP_TAXA_TARIFA " +
                "WHERE dat_inicio > '" + leituraAnterior.ToString("yyyy-MM-dd") + "'" +
                " AND dat_inicio <= '" + leituraAtual.ToString("yyyy-MM-dd") + "'" +
                " AND seq_categoria = " + seqCategoria.ToString() +
                " AND seq_taxa = " + seqTaxa.ToString();

            try {
                dataReader = command.ExecuteReader(query);

                if (dataReader != null) {
                    PropertyInfo[] properties = typeof(OnpTaxaTarifa).GetProperties();

                    while (dataReader.Read()) {
                        OnpTaxaTarifa aux = new OnpTaxaTarifa();

                        for (int i = 0; i < dataReader.FieldCount; i++)
                            if (dataReader.GetValue(i) != System.DBNull.Value)
                                foreach (PropertyInfo p in properties)
                                    if (dataReader.GetName(i).Equals(ColumnAttribute.makeColumnName(p.Name))) {
                                        object drValue = dataReader.GetValue(i), value;

                                        if (drValue is decimal) {
                                            if (typeof(int?).Equals(p.PropertyType))
                                                value = System.Convert.ToInt32(drValue);
                                            else
                                                value = System.Convert.ToDouble(drValue);
                                        } else if (DBNull.Value.Equals(drValue))
                                            value = null;
                                        else
                                            value = drValue;

                                        p.SetValue(aux, value, null);
                                        break;
                                    }

                        retorno.Add(aux);
                    }
                }

            } catch (Exception) {
                retorno = null;
            } finally {
				if (dataReader != null)
					dataReader.Close();
				
				if (command != null)
					command.Dispose();
			}


            return retorno;
        }

        /// <summary>
        /// Pega o consumo minimo de uma taxa com base em uma data base
        /// </summary>
        /// <param name="ft">Taxa a qual se deve pegar o consumo minimo</param>
        /// <param name="datBase">Data base de calculo</param>
        /// <returns>Retorna o consumo encontrado</returns>
        public static int ConsumoMinimo(int seqTaxa, int seqCategoria, DateTime datBase) {
            int result = 0;

            ICommand command = ConnectionCE.Instancia.NovoCommand();

            string query = "select min(ttf.val_limite_consumo) from onp_taxa_tarifa tt, onp_taxa_tarifa_faixa ttf " +
                "where ttf.seq_taxa = @seqTaxa and ttf.seq_categoria = @seqCategoria and tt.dat_inicio < @datBase " +
                "and tt.seq_taxa_tarifa = ttf.seq_taxa_tarifa";

            try {
                command.AdicionarParametro("@seqTaxa", seqTaxa);
                command.AdicionarParametro("@seqCategoria", seqCategoria);
                command.AdicionarParametro("@datBase", datBase);

                object obj = command.ExecuteScalar(query);
				if (!obj.Equals(DBNull.Value))
					result = Convert.ToInt32((decimal)obj);
            } catch (Exception ex) {
				result = 0;
                throw ex;
            } finally {
               if (command != null)
                    command.Dispose();
            }

            return result;
        }
    }
}
