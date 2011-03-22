using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace SPCadMobileSync.Data.DAL
{
    public class ConectSPCad
    {
        public SqlCeConnection con;
        public SqlCeCommand cmd;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name='transaction'>Define o uso de transaction. true = Usa transaction</param>
        public ConectSPCad()
        {
            string nome = "SPcad.sdf";
            string senha = "velp2010";
            con = new SqlCeConnection("Data Source =\"" + GetLocalPath() + "\\" + nome + "\"; Password=\"" + senha + "\"");            
            cmd = new SqlCeCommand();
            cmd.Connection = con;
            con.Open();
        }

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
        /// <returns>string</returns>
        public static string GetConnection()
        {
            return "Data Source =\"Program Files\\SPCadMobile\\SPCad.sdf\"";
        }
    }
}
