using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SPCadToPDA.Helper;
using CommonHelpMobile;

namespace SPCadToPDA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            User usuario = new User();

            string valor = string.Empty;
            foreach (string s in args)
            {
                valor += s + " ";
            }

            string[] us = valor.Split(',');
            usuario.IdUsuario = int.Parse(us[0].Trim());
            usuario.Usuario = us[1].Trim();
            usuario.Senha = us[2].Trim();
            usuario.Login = us[3].Trim();


            // Inicia o programa
            Application.Run(new FrmExportToPDA(usuario));
        }
    }
}
