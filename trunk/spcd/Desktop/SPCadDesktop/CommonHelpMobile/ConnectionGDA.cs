﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace CommonHelpMobile
{
    /// <summary>
    /// Conexão com a base de dados através do GDA
    /// </summary>
    public static class ConnectionGDA
    {
        /// <summary>
        /// construtor inicializa os campos nome e senha da base de dados
        /// </summary>
        /// <param name="banc">Nome do banco com extensão</param>
        /// <param name="code">Senha do banco</param>
        public static void DataBaseConnect(string LocalPath)
        {
            string nome = "SPCad.sdf";
            string senha = "velp2010";
            string bancoString = string.Format("Data Source = \"{0}\\{1}\"; Password=\"{2}\"", LocalPath, nome, senha);

            GDA.GDASettings.AddProvider("SqlServerCE", "GDA.Provider.SqlServerCE", "GDA.Provider.SqlServerCE");
            GDA.GDASettings.DefaultProviderConfiguration = GDA.GDASettings.CreateProviderConfiguration("SqlServerCE", bancoString);                  
        }

        //Exibe a sql executada no GDA
        //public static void AtivaDebugGDA()
        //{
        //    GDA.GDAOperations.DebugTrace += new GDA.DebugTraceDelegate(GDAOperations_DebugTrace);
        //}

        //static void GDAOperations_DebugTrace(object sender, string message)
        //{
        //    System.Diagnostics.Debug.WriteLine(message);
        //}
    }
}