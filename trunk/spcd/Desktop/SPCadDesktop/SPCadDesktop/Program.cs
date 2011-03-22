using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SPCadDesktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GDA.GDASettings.EnabledDebugTrace = true;
            GDA.GDAOperations.DebugTrace += new GDA.DebugTraceDelegate(GDAOperations_DebugTrace);

            Application.Run(new frmLogin());
        }
        static void GDAOperations_DebugTrace(object sender, string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

    }
}
