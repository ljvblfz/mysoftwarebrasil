using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Reflection;

namespace DeviceProject.Util
{
    /// <summary>
    ///  Classe composta de metodos com varias funcionalidades
    /// </summary>
    public static class ExtensionMethods
    {

        /// <summary>
        /// Verifica se a conexão com o servidor pode ser estabelecida.
        /// </summary>
        /// <param name="targetAddress">Endereço do servidor.</param>
        /// <returns>True se o a conexão foi estabelecida.</returns>
        public static bool CheckConnected(string targetAddress)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            bool isConnected = false;
            try
            {
                // Cria uma instancia para fazer o requerimento ao servidor
                request = (HttpWebRequest)WebRequest.Create(targetAddress);

                // Altera o timeout do servidor para 10 segundos
                request.Timeout = 10000;

                // Faz o requerimento
                response = (HttpWebResponse)request.GetResponse();
                request.Abort();

                // Verifica se o servidor respondeu
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    isConnected = true;
                }
                response.GetResponseStream().Close();
            }
            catch
            {
                //MsgError("Conexão com o servidor não pode ser estabelecida.", "Erro");
                isConnected = false;
            }
            finally
            {
                request = null;
                response = null;
            }
            return isConnected;
        }

        /// <summary>
        /// Exibe uma Message box com o símbolo de informação "i"
        /// </summary>
        /// <param name="message">Texto da MsgBox</param>
        /// <param name="caption">Título da MsgBox</param>
        public static void MsgInfomation(string message, string caption)
        {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Exibe uma Message box com o símbolo de atenção "!"
        /// </summary>
        /// <param name="message">Texto da MsgBox</param>
        /// <param name="caption">Título da MsgBox</param>
        public static void MsgExclamation(string message, string caption)
        {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Exibe uma Message box com o símbolo de erro "x"
        /// </summary>
        /// <param name="message">Texto da MsgBox</param>
        /// <param name="caption">Título da MsgBox</param>
        public static DialogResult MsgQuestion(string message, string caption)
        {
            Cursor.Current = Cursors.Default;
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        /// <summary>
        /// Exibe uma Message box com o símbolo de erro "x"
        /// </summary>
        /// <param name="message">Texto da MsgBox</param>
        /// <param name="caption">Título da MsgBox</param>
        public static void MsgError(string message, string caption)
        {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Criptografa a string recebida
        /// </summary>
        /// <param name="value">string valor a ser convertido</param>
        /// <returns>String criptografada</returns>
        public static string ConvertToHASH(this string value)
        {
            HashAlgorithm hash = MD5.Create();
            StringBuilder str = new StringBuilder();
            byte[] result = hash.ComputeHash(Encoding.Convert(UnicodeEncoding.Unicode, UnicodeEncoding.ASCII, new UnicodeEncoding().GetBytes(value)));
            foreach (byte b in result)
                str.Append(string.Format("{0:X2}", b));

            return str.ToString();
        }

        /// <summary>
        ///  Verefica entre varias validações se existe uma falsa
        /// </summary>
        /// <param name="listaValidacoes">bool[] , array de validações</param>
        /// <returns>bool , retorna o resultado se todas as validações estão corretas</returns>
        public static bool ValidacaoCorreta(bool[] listaValidacoes)
        {
            bool retorno = false;
            List<bool> listaObjValidacoes = new List<bool>(listaValidacoes);
            List<bool> listaObjValidacoesAUX = listaObjValidacoes.FindAll(delegate(bool b) { return b == false; });
            if (listaObjValidacoesAUX.Count < 1)
                retorno = true;
            return retorno;
        }

        /// <summary>
        ///  Metodo que retorna o tempo decorrido
        /// </summary>
        /// <param name="sicronizacaoIni">data inicial</param>
        /// <returns>tempo decorrido apartir da data inicial</returns>
        public static string GetTime(DateTime sicronizacaoIni)
        {
            TimeSpan sicronizacaoTotal = DateTime.Now - sicronizacaoIni;
            string tempoTotal = String.Format("{0:G}", sicronizacaoTotal) + " Minutos.";
            return tempoTotal;
        }

        /// <summary>
        ///  Metodo que retorna o tempo decorrido
        /// </summary>
        /// <param name="sicronizacaoIni">data inicial</param>
        /// <returns>tempo decorrido apartir da data inicial</returns>
        public static string GetTimeWebService(string referencia,DateTime sicronizacaoIni)
        {
            TimeSpan sicronizacaoTotal = DateTime.Now - sicronizacaoIni;
            string tempoTotal = String.Format("{0:G}", sicronizacaoTotal) + " Minutos.";
            Debug.WriteLine("WebService:" + referencia + tempoTotal);
            return tempoTotal;
        }

        /// <summary>
        ///  Metodo que retorna o tempo decorrido
        /// </summary>
        /// <param name="sicronizacaoIni">data inicial</param>
        /// <returns>tempo decorrido apartir da data inicial</returns>
        public static string GetTimeDataBase(string referencia, DateTime sicronizacaoIni)
        {
            TimeSpan sicronizacaoTotal = DateTime.Now - sicronizacaoIni;
            string tempoTotal = String.Format("{0:G}", sicronizacaoTotal) + " Minutos.";
            Debug.WriteLine("Insert:" + referencia + tempoTotal);
            return tempoTotal;
        }


        /// <summary>
        ///  Valida uma URL
        /// </summary>
        /// <param name="URL">string URL</param>
        /// <param name="tipo"> existem dois tipos 1: WEB 2: REDE defaut FISICO</param>
        /// <returns>bool ,verificação se o endereço e valido</returns>
        public static bool ValidaURL(string URL, int tipo)
        {
            // Variavel de retorno
            bool retorno = true;

            // Verifica o tipo de ENDEREÇO
            switch (tipo)
            {
                case 1:// WEB
                    {
                        System.Globalization.CompareInfo cmpUrl = System.Globalization.CultureInfo.InvariantCulture.CompareInfo;
                        if (cmpUrl.IsPrefix(URL, "http://") == false)
                        {
                            retorno = false;
                        }
                        break;
                    }
                case 2:// REDE
                    {
                        System.Globalization.CompareInfo cmpUrl = System.Globalization.CultureInfo.InvariantCulture.CompareInfo;
                        if (cmpUrl.IsPrefix(URL, "\\") == false)
                        {
                            retorno = false;
                        }
                        break;
                    }
            }

            // Expressão regular
            Regex RgxUrl = new Regex("(([a-zA-Z][0-9a-zA-Z+\\-\\.]*:)?/{0,2}[0-9a-zA-Z;/?:@&=+$\\.\\-_!~*'()%]+)?(#[0-9a-zA-Z;/?:@&=+$\\.\\-_!~*'()%]+)?");

            // Verifica a validade 
            if (!RgxUrl.IsMatch(URL))
            {
                retorno = false;
            }
            return retorno;
        }
       

    }
}

