using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CommonHelpMobile
{
    public static class TrataString
    {
        /// <summary>
        /// Remove acentos e cedilhas.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CutAccent(string text)
        {
            string newText = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == "ã") newText += "a";
                else if (text[i].ToString() == "á") newText += "a";
                else if (text[i].ToString() == "à") newText += "a";
                else if (text[i].ToString() == "â") newText += "a";
                else if (text[i].ToString() == "ä") newText += "a";
                else if (text[i].ToString() == "é") newText += "e";
                else if (text[i].ToString() == "è") newText += "e";
                else if (text[i].ToString() == "ê") newText += "e";
                else if (text[i].ToString() == "ë") newText += "e";
                else if (text[i].ToString() == "í") newText += "i";
                else if (text[i].ToString() == "ì") newText += "i";
                else if (text[i].ToString() == "ï") newText += "i";
                else if (text[i].ToString() == "õ") newText += "o";
                else if (text[i].ToString() == "ó") newText += "o";
                else if (text[i].ToString() == "ò") newText += "o";
                else if (text[i].ToString() == "ö") newText += "o";
                else if (text[i].ToString() == "ú") newText += "u";
                else if (text[i].ToString() == "ù") newText += "u";
                else if (text[i].ToString() == "ü") newText += "u";
                else if (text[i].ToString() == "ç") newText += "c";
                else if (text[i].ToString() == "Ã") newText += "A";
                else if (text[i].ToString() == "Á") newText += "A";
                else if (text[i].ToString() == "À") newText += "A";
                else if (text[i].ToString() == "Â") newText += "A";
                else if (text[i].ToString() == "Ä") newText += "A";
                else if (text[i].ToString() == "É") newText += "E";
                else if (text[i].ToString() == "È") newText += "E";
                else if (text[i].ToString() == "Ê") newText += "E";
                else if (text[i].ToString() == "Ë") newText += "E";
                else if (text[i].ToString() == "Í") newText += "I";
                else if (text[i].ToString() == "Ì") newText += "I";
                else if (text[i].ToString() == "Ï") newText += "I";
                else if (text[i].ToString() == "Õ") newText += "O";
                else if (text[i].ToString() == "Ó") newText += "O";
                else if (text[i].ToString() == "Ò") newText += "O";
                else if (text[i].ToString() == "Ö") newText += "O";
                else if (text[i].ToString() == "Ú") newText += "U";
                else if (text[i].ToString() == "Ù") newText += "U";
                else if (text[i].ToString() == "Ü") newText += "U";
                else if (text[i].ToString() == "Ç") newText += "C";
                else newText += text[i];
            }
            return newText;
        }

        /// <summary>
        /// Retorna true se for Hora no formato válido. Ex: 12:00.
        /// </summary>
        /// <param name="data">recebe uma string</param>
        /// <returns>retorna true ou false</returns>
        public static bool validaHora(string data)
        {
            bool valida = false;
            int hora;
            int minuto;

            hora = int.Parse(data.Substring(0, 2));
            minuto = int.Parse(data.Substring(3, 2));

            if (hora <= 23 && minuto <= 59) { valida = true; }

            return valida;
        }

        /// <summary>
        /// Remove os caracteres '/', '-', '.', ' '(espaço em branco).
        /// </summary>
        /// <param name="textOld"></param>
        /// <returns></returns>
        public static string RemoveCaracter(string textOld)
        {
            string newText = "";

            for (int i = 0; i < textOld.Length; i++)
            {
                if (textOld[i].ToString() == "/") newText += "";
                else if (textOld[i].ToString() == "-") newText += "";
                else if (textOld[i].ToString() == ".") newText += "";
                else if (textOld[i].ToString() == " ") newText += "";
                else if (textOld[i].ToString() == "\\") newText += "";
                else newText += textOld[i];
            }

            return newText;
        }

        /// <summary>
        /// Remove aspas simples (').
        /// </summary>
        /// <param name="textOld"></param>
        /// <returns></returns>
        public static string RemoveAspas(string textOld)
        {
            string newText = "";

            for (int i = 0; i < textOld.Length; i++)
            {
                if (textOld[i].ToString() == "'") newText += "";
                else if (textOld[i].ToString() == "\"") newText += "";
                else newText += textOld[i];
            }

            return newText;
        }        
    }

    /// <summary>
    /// //altera o caractere de nova linha '\n' para '\r\n'
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class AjustBrokeLine<T> where T : new()
    {
        //altera o caractere de nova linha '\n' para '\r\n'
        public static T ajusteNovaLinha(T Object)
        {
            string valorPropriedade;
            string novoValorPropriedade;

            foreach (PropertyInfo p in typeof(T).GetProperties())
            {
                string nome = p.Name;


                try
                {
                    if (p.PropertyType.FullName == "System.String")
                    {
                        if (p.GetValue(Object, null) != null)
                        {
                            //recupera o valor da propriedade.
                            valorPropriedade = p.GetValue(Object, null).ToString();
                            if (checkbrokeline(valorPropriedade))
                            {
                                novoValorPropriedade = valorPropriedade.Replace("\n", "\r\n");
                                p.SetValue(Object, novoValorPropriedade, null);
                            }
                        }
                    }
                }
                catch (Exception) { }
            }

            return Object;
        }

        //auxilia o metodo ajusteNovaLinha, identificando se existe o caractere de quebra de linha
        private static bool checkbrokeline(string texto)
        {
            bool existente = false;

            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i].ToString() == "\n" && texto[i - 1].ToString() != "\r")
                    existente = true;
            }

            return existente;
        }
    }
}
