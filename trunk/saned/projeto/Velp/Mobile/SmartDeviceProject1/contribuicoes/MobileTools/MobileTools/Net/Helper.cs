using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace MobileTools.Net
{
    public class Helper
    {
        /// <summary>
        /// Verifica se a conexão com o servidor pode ser estabelecida.
        /// </summary>
        /// <param name="targetAddress">Endereço do servidor.</param>
        /// <returns>
        /// <para>True: se o a conexão foi estabelecida.</para>
        /// <para>False: se o a conexão não foi estabelecida.</para>
        /// </returns>
        public static bool CheckConnected(string targetAddress)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            bool isConnected = false;

            try
            {
                // Cria uma instancia para fazer o requerimento ao servidor
                request = (HttpWebRequest)WebRequest.Create(targetAddress);
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
                isConnected = false;
            }
            finally
            {
                request = null;
                response = null;
            }
            return isConnected;
        }
    }
}
