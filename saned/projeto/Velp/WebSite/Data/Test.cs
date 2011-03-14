using System;
using System.Data;
using GDA;

namespace Data
{
    public static class Test
    {
        /// <summary>
        /// Conexão com BD.
        /// </summary>
        public static bool Connection()
        {
            try
            {
                // Instancia do objeto de conexao com o banco de dados
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();

                // retorna a string de connexão
                string connectionString = GDA.GDASettings.DefaultProviderConfiguration.ConnectionString.Replace("Timeout=60", "Timeout=60");

                // Abre a conexão
                con.ConnectionString = connectionString;
                con.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}