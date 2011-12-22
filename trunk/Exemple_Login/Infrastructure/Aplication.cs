using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using Exemple_Login.Context;

namespace Exemple_Login
{
    /// <summary>
    ///  Classe que possui metodos que envolve a aplicação globalmente 
    /// </summary>
    public class Aplication
    {
        /// <summary>
        ///  Verifica se o usuario esta autenticado
        /// </summary>
        /// <returns>true se o usuario esta autenticado</returns>
        public static bool IsAuthenticated()
        {
            return GetTicket() is FormsAuthenticationTicket ? true : false;
        }

        /// <summary>
        ///  Retorna o ticket (cookie) do usuario
        /// </summary>
        /// <returns>HttpCookie</returns>
        public static FormsAuthenticationTicket GetTicket()
        {
            FormsAuthenticationTicket ticket = null;
            HttpCookie ticketCookie = System.Web.HttpContext.Current.Request.Cookies["Ticket"];
            if (ticketCookie != null)
                ticket = FormsAuthentication.Decrypt( TicketDecompress(ticketCookie.Value));
            return ticket;
        }

        /// <summary>
        ///  Destroi o ticket
        /// </summary>
        public static void DestroyTicket()
        {
            System.Web.HttpCookie ticket = HttpContext.Current.Response.Cookies["Ticket"];
            if (ticket != null)
            {
                ticket.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.AppendCookie(ticket);
            }
        }

        /// <summary>
        /// Cria um ticket com as informações do usuario
        /// </summary>
        /// <param name="userId">codigo do usuario</param>
        /// <param name="username">nome do usuario</param>
        /// <param name="isPersistent">true se o cookie será armazenado em um cookie persistente 
        ///                             (salvo em browser Sessions), caso contrário, 
        ///                             false o cookie é armazenado na URL, este valor É ignorado.
        /// </param>
        /// <param name="roles">Os dados específicos do usuário para ser armazenado com o cookie.(roles)</param>
        /// <param name="expiration">A data local e hora em que o cookie expira.</param>
        /// <returns>cookie criptografado</returns>
        public static string CreateTicket(string username, bool isPersistent, User userData, DateTime expiration)
        {
            var userSerialize = new JavaScriptSerializer().Serialize(userData);

            FormsAuthentication.Initialize();

            // Cria o ticket de autenticação
            var ticket = new FormsAuthenticationTicket(
                                                        1,
                                                        username,
                                                        DateTime.Now,
                                                        expiration,
                                                        isPersistent,
                                                        userSerialize,
                                                        FormsAuthentication.FormsCookiePath
                                                       );

            // Criptografa o ticket
            string hash = FormsAuthentication.Encrypt(ticket);

            // Cria o cookie
            System.Web.HttpCookie ticketCookie = new HttpCookie("Ticket", TicketCompress(hash));
            ticketCookie.Expires = DateTime.Now.AddDays(3);
            HttpContext.Current.Response.Cookies.Add(ticketCookie);

            return hash;
        }

        /// <summary>
        ///  Retorna o usuario corrente
        /// </summary>
        /// <returns></returns>
        public static User GetUser()
        {
            var ticket = GetTicket();
            var user = new JavaScriptSerializer().Deserialize<User>(ticket.UserData);
            return user == null ? new User() : user;
        }

        /// <summary>
        ///  Comprime o Ticket
        /// </summary>
        /// <param name="uncompressedString"></param>
        /// <returns></returns>
        public static string TicketCompress(string uncompressedString)
        {
            string[] arrModules = uncompressedString.Split('|');

            int pos = 0;

            string oldModuleName = arrModules[pos].Split('.')[0];

            for (pos = 1; pos < arrModules.Length; pos++)
            {
                string newModuleName = arrModules[pos].Split('.')[0];

                if (oldModuleName == newModuleName)
                    arrModules[pos] = arrModules[pos].Replace(oldModuleName + ".", ",");
                else
                {
                    arrModules[pos] = "|" + arrModules[pos];
                    oldModuleName = newModuleName;
                }
            }

            string compressedString = new StringCompressor().Compress(string.Join(string.Empty, arrModules));

            return compressedString;
        }

        /// <summary>
        ///  Descomprime o ticked
        /// </summary>
        /// <param name="compressedString"></param>
        /// <returns></returns>
        public static string TicketDecompress(string compressedString)
        {
            compressedString = new StringCompressor().Decompress(compressedString);

            string[] arrModules = compressedString.Split('|');

            for (int pos = 0; pos < arrModules.Length; pos++)
            {
                string moduleName = arrModules[pos].Split('.')[0];
                arrModules[pos] = arrModules[pos].Replace(",", "|" + moduleName + ".");
            }

            return string.Join("|", arrModules);
        }

    }
}