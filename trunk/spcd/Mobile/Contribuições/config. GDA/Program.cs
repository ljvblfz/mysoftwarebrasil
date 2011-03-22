using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HIOB.Mobile
{
    static class Program
    {
        /// <summary>
        /// Captura o diretório raiz da aplicação.
        /// </summary>
        /// <returns>Caminho do diretorio raíz da aplicação.</returns>
        public static string GetLocalPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            GDA.GDASettings.EnabledDebugTrace = true;
            GDA.GDAOperations.DebugTrace += new GDA.DebugTraceDelegate(GDAOperations_DebugTrace);
            GDA.GDASettings.AddProvider("SqlServerCE", "GDA.Provider.SqlServerCE", "GDA.Provider.SqlServerCE");
            GDA.GDASettings.DefaultProviderConfiguration = GDA.GDASettings.CreateProviderConfiguration("SqlServerCE", "Data Source =\""
            + GetLocalPath() + "\\base_deop.sdf\"");

            Application.Run(new frmLogin());
        }

        static void GDAOperations_DebugTrace(object sender, string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

    }
}