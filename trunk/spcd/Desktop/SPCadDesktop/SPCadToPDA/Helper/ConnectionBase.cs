using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace SPCadToPDA.Helper
{
    
    /// <summary>
    /// Conexão com a base de dados através do GDA
    /// </summary>
    //public class ConnectionGDAeee
    //{
    //    /// <summary>
    //    /// construtor inicializa os campos nome e senha da base de dados
    //    /// </summary>
    //    /// <param name="banc">Nome do banco com extensão</param>
    //    /// <param name="code">Senha do banco</param>
    //    public static SqlCeConnection DataBaseConnect(string nome, string senha, string Paths)
    //    {
    //        try
    //        {
    //            //GDA.GDASettings.AddProvider("SqlServerCE", "GDA.Provider.SqlServerCE", "GDA.Provider.SqlServerCE");
    //            //GDA.GDASettings.DefaultProviderConfiguration = GDA.GDASettings.CreateProviderConfiguration("SqlServerCE", "Data Source =\""
    //            //+ Paths + "\\" + nome + "\"; Password=\"" + senha + "\"");

    //            string StringGDA = string.Format("Data Source =\"{0}\\{1}\"; Password=\"{2}\"", Paths, nome, senha);
    //            return new SqlCeConnection(StringGDA);                
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }
    //    }        
    //}

    public class ConnectionBase
    {
        public SqlCeConnection con;
        public SqlCeCommand cmd;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name='transaction'>Define o uso de transaction. true = Usa transaction</param>
        public ConnectionBase(string LocalPath)
        {
            string nome = "SPCad.sdf";
            string senha = "velp2010";
            string bancoString = string.Format("Data Source = \"{0}\\{1}\"; Password=\"{2}\"",LocalPath, nome, senha);
            con = new SqlCeConnection(bancoString);
            cmd = new SqlCeCommand();
            cmd.Connection = con;
            con.Open();
        }

        public void CloseConection()
        {
            con.Close();
        }
    }
}
