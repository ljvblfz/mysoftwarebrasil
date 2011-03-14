using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using DeviceProject.Config;
using DeviceProject.Sincronizacao;

namespace DeviceProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Sincronizar sinc = new Sincronizar();
            Application.Run(sinc);
        }
    }
}