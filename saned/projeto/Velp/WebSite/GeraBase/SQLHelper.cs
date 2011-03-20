using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;
using System.Data;

namespace GeraBase
{
    /// <summary>
    ///  Classe responsavel pelo controle do banco de dados
    /// </summary>
    public class SQLHelper
    {
        /// <summary>
        ///  Objeto de conexão com o banco de dados
        /// </summary>
        public static SqlCeConnection con;

        /// <summary>
        ///  Abre um execute command
        /// </summary>
        public SqlCeCommandEx cmd;

        /// <summary>
        ///  Command padrão do banco
        /// </summary>
        public static SqlCeCommand cmdOrigem = new SqlCeCommand(); 

        /// <summary>
        ///  Instancia da classe de banco de dados onplace
        /// </summary>
        private static SQLHelper instancia;

        /// <summary>
        ///  Metodo que implementa o Singleton
        /// </summary>
        public static SQLHelper Instance
        {
            get
            {
                // Verifica se foi instanciado
                if (instancia == null)
                {
                    // Cria uma nova instancia
                    instancia = new SQLHelper();
                }
                else
                {
                    // Limpa os parametros e comandos
                    instancia.cmd.Parameters.Clear();
                    instancia.cmd.CommandText = string.Empty;
                }
                return instancia;
            }
        }

        /// <summary>
		/// Construtor padrão
		/// </summary>
		public SQLHelper()
		{
            Conectar();
		}

        /// <summary>
        ///  Metodo que abre uma conecxão com o banco de dados
        /// </summary>
        public void Conectar()
        {
            try
            {
                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
                con = new SqlCeConnection(SQLHelper.GetConnection());
                cmd = new SqlCeCommandEx();
                cmd.Connection = con;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            return "Data Source =\"" + Config.conectionString + "\"";
        }

        /// <summary>
        /// Copiar Banco de dados para o aplicativo onplayce
        /// </summary>
        /// <param name="fileOrigem">caminho origem + arquivo </param>
        /// <param name="fileDestino"> caminho destino + arquivo </param>
        public static void copyFiles(string fileOrigem, string diretorioDestino, string fileDestino)
        {
            DirectoryInfo dir = new DirectoryInfo(fileDestino);
            if (!dir.Exists)
                dir.Create();

            if (File.Exists(fileOrigem))
            {
                try
                {
                    if (!File.Exists(diretorioDestino + fileDestino))
                        File.Copy(fileOrigem, diretorioDestino + fileDestino, true);
                }
                catch (IOException ex)
                {
                    throw new IOException("Erro ao copiar arquivo " + fileOrigem + ", erro: " + ex.Message, ex);
                }
            }
            else
            {
                throw new IOException("Erro ao copiar arquivo de banco de dados movel não existe. ");
            }
        }

    }
}
