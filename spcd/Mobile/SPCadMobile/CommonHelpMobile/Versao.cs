using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace CommonHelpMobile
{
    public class Versao
    {
        #region Converte Versão.
        static string ConverteVersao(Version versao)
        {
            string[] dados = versao.ToString().Split('.');

            string textoVersao = "";

            if (dados[3] != "0")
            {
                textoVersao += "." + dados[3];
            }

            if ((dados[2] != "0") || (textoVersao != ""))
            {
                textoVersao = "." + dados[2] + textoVersao;
            }

            return dados[0] + "." + dados[1] + "." + dados[2] + "." + dados[3];
        }

        public static string NumeroVersao()
        {
            return ConverteVersao(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
        }

        #endregion      
    }    
}
