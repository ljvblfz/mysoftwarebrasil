using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Instalador
{
    static class Program
    {
        public static bool status = false; 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main(params string[] args)
        {
            // Verifica os parâmetros de inicialização
            bool atualizacao = false;
            foreach (string s in args)
                if (s == "-a")
                {
                    atualizacao = true;
                    break;
                }
            // Inicia o programa
            Application.Run(new frmInstalacao(atualizacao));
        }
    }
}