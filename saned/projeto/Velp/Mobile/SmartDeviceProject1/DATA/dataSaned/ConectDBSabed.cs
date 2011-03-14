using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;

namespace DeviceProject.DATA.dataSaned
{
    /// <summary>
    ///  Classe de conexão ao banco de controle da aplicação
    /// </summary>
    public class ConectDBSabed
    {
       /// <summary>
       ///  objeto de conexão
       /// </summary>
       public SqlCeConnection con;

       /// <summary>
       ///  Objeto de commando
       /// </summary>
       public SqlCeCommand cmd;
        
        /// <summary>
		/// Construtor padrão
		/// </summary>
		/// <param name='transaction'>Define o uso de transaction. true = Usa transaction</param>
        public ConectDBSabed()
		{
            con = new SqlCeConnection(ConectDBSabed.GetConnection());
			cmd = new SqlCeCommand();
			cmd.Connection = con;
			con.Open();
		}

        /// <summary>
        ///  Fecha a conexão com o banco de dados
        /// </summary>
        public void CloseConection()
        {
            con.Close();
        }

        /// <summary>
        /// Captura o diretório raiz da aplicação.
        /// </summary>
        /// <returns>Caminho do diretorio raíz da aplicação.</returns>
        public static string GetLocalPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }

        /// <summary>
        /// Retorna a string de conexão
        /// </summary>
        /// <returns>string caminho do banco de dados (FIXO)</returns>
        public static string GetConnection()
        {
            return "Data Source =\"Program files\\Saned_Distribuicao\\Data\\DataBase\\Saned.sdf\"";
        }
    }
}
