using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using LTmobile;
using LTmobileData.Data.BFL;
using System.Runtime.InteropServices;
using System.Diagnostics;



namespace LTmobile
{
    static class Program
    {
       // [DllImport("user32.dll")]
        //public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd); 

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
            + GetLocalPath() + "\\LTmobile.sdf\"; password = ");

            Application.Run(new frmLogin());

        }

        static void GDAOperations_DebugTrace(object sender, string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

       
    }
}