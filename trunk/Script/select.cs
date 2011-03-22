		/// <summary>
        ///  Select generico que retorna um data table
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Select(string sql)
        {
            // Tabela de retorno
            DataTable mDataTable = new DataTable();

            // Instancia o objeto do banco de dados
            SQLHelper connect = new SQLHelper();

            // Dicionario de campos
            Dictionary<int, string> mapCampos = new Dictionary<int, string>();
            try
            {
                // Retorna a ultima fatura emitida
                connect.cmd.CommandText = sql;

                // Executa o comando
                IDataReader dReader;
                dReader = connect.cmd.ExecuteReader();

                // Adiciona os campos retornados
                int countFields = dReader.FieldCount;
                for (int i = 0; i < countFields; i++)
                    mapCampos.Add(i, dReader.GetName(i).ToLower());

                // Seta os valores
                while (dReader.Read())
                {
                    object[] linha = new object[mapCampos.Count];
                    for (int i = 0; i < mapCampos.Count; i++)
                    {
                        linha[i] = new object();
                        mDataTable.Columns.Add(mapCampos[i]);
                        linha[i] = dReader[mapCampos[i]];
                    }
                    mDataTable.Rows.Add(linha);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mDataTable;
        }