using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonHelpMobile;

namespace SPCadMobileSync
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //conecta com a base de dados.
            ConnectionGDA.DataBaseConnect("SPCad.sdf", "velp2010");
                        
            new frmSincronizacao().ShowDialog();          
        }
    }
}