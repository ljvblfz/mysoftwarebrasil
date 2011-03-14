using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;
using System.Data;

namespace DeviceProject.Util
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
        ///  Testa a conecxão com o banco movel
        /// </summary>
        /// <returns></returns>
        public static bool TestCon()
        {
            SqlCeConnection con = new SqlCeConnection(SQLHelper.GetConnection());
            SqlCeCommandEx cmd = new SqlCeCommandEx();
            try
            {
                cmd.Connection = con;
                con.Open();
            }
            catch
            {
                DeviceProject.Util.ExtensionMethods.MsgError("Fala ao connectar com o banco de dados movel.", "Erro");
                return false;
            }
            finally
            {
                con.Close();
                GC.SuppressFinalize(cmd);
                GC.SuppressFinalize(con);
            }
            return true;
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
            return "Data Source =\"Program files\\OnPlaceMovel\\base\\OnPlace.sdf\"";
        }

        /// <summary>
        /// Verifica se o banco movel existe
        /// </summary>
        /// <returns>string</returns>
        public static void VerificaBanco()
        {
            string caminhoBanco = "Program files\\OnPlaceMovel\\base\\OnPlace.sdf";

            // Se o banco não existe copia a aplicação
            if (!File.Exists(caminhoBanco))
            {
                copyFiles(GetLocalPath() + "\\DATA\\DataBase\\OnPlace.sdf", "\\Program files\\OnPlaceMovel\\base\\OnPlace.sdf");
            }
        }

        /// <summary>
        ///  Faz um backp do banco
        /// </summary>
        public static void BackpBanco()
        {
            string caminhoBanco = GetLocalPath() + "\\DATA\\DataBase\\OnPlaceBackp.sdf";
            FileInfo destino = new FileInfo(caminhoBanco);
            
            if(destino.Exists)
            {
                destino.Delete();
            }

            // Se o banco não existe copia a aplicação
            if (!File.Exists(caminhoBanco))
            {
                copyFiles("\\Program files\\OnPlaceMovel\\base\\OnPlace.sdf", caminhoBanco);
            }
        }

        /// <summary>
        /// Copiar Banco de dados para o aplicativo onplayce
        /// </summary>
        /// <param name="fileOrigem">caminho origem + arquivo </param>
        /// <param name="fileDestino"> caminho destino + arquivo </param>
        public static void copyFiles(string fileOrigem, string fileDestino)
        {
            if (File.Exists(fileOrigem))
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(@"Program files\\OnPlaceMovel\\base\\");
                    dir.Create();
                    
                    File.Copy(fileOrigem, fileDestino, true);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao copiar arquivo " + fileOrigem + ", erro: " + ex);
                }
            }
            else
            {
                throw new Exception("erro");
            }
        }

    }
}
