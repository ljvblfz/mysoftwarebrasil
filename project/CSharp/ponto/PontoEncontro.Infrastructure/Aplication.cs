using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading;
using PontoEncontro.Infrastructure.Compression;
using PontoEncontro.Infrastructure.MVC.DataAnnotations;
using System.Reflection;
using System.Web.Script.Serialization;
using PontoEncontro.Infrastructure.Linq;

namespace PontoEncontro.Infrastructure
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
        ///  Cria um cookie
        /// </summary>
        /// <returns>void</returns>
        public static void AddCookie<TSourse>(TSourse objects,string key)
        {
            var serializer = new JavaScriptSerializer().Serialize(objects);

            // Cria o cookie
            var cookie = new HttpCookie(key,serializer);
            cookie.Expires = DateTime.Now.AddDays(3);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        ///  Recupera o objeto no cookie
        /// </summary>
        /// <returns>objeto tipado</returns>
        public static object GetCookie(Type type, string key)
        {
            var cookie = System.Web.HttpContext.Current.Request.Cookies[key];
            if (cookie is HttpCookie)
             return new JavaScriptSerializer().Deserialize(cookie.Value, type);

            return new object();
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
                ticket = FormsAuthentication.Decrypt(new TicketCompressor().Decompress(ticketCookie.Value));
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
                FormsAuthentication.SignOut();
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
        public static string CreateTicket(string username, bool isPersistent, object user, DateTime expiration)
        {
            FormsAuthentication.Initialize();

            // Cria o ticket de autenticação
            var ticket = new FormsAuthenticationTicket(
                                                        1,
                                                        username,
                                                        DateTime.Now,
                                                        expiration,
                                                        isPersistent,
                                                        new JavaScriptSerializer().Serialize(user),
                                                        FormsAuthentication.FormsCookiePath
                                                       );

            // Criptografa o ticket
            string hash = FormsAuthentication.Encrypt(ticket);

            // Cria o cookie
            System.Web.HttpCookie ticketCookie = new HttpCookie("Ticket", new TicketCompressor().Compress(hash));
            ticketCookie.Expires = DateTime.Now.AddDays(3);
            HttpContext.Current.Response.Cookies.Add(ticketCookie);

            return hash;
        }

        /// <summary>
        ///  Retorna o usuario corrente
        /// </summary>
        /// <returns></returns>
        public static object GetUser<T>(Type type)
        {
            var ticket = GetTicket();
            return new JavaScriptSerializer()
                .Deserialize(ticket.UserData, type);
        }

        /// <summary>
        ///  Retorna o user name
        /// </summary>
        /// <returns>user name</returns>
        public static string GetUserName()
        {
            var ticket = GetTicket();
            return ticket.Name;
        }

        /// <summary>
        ///  Retorna o host do servidor
        /// </summary>
        /// <returns>host do servidor</returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        /// <summary>
        ///  Armazena valores de um objeto em cache dinamicamente
        ///   estes valores podem ser checados(marcados) pelo atributo [Store] no objeto
        ///   Ex:
        /// <code>
        ///  Class objectT{
        ///  
        ///     [Store]
        ///     public int objStore {get;set}
        ///     
        ///     public int objNotStore {get;set}
        ///  }
        ///  var key = Aplication.StoreObjectCache(typeof(objectT),new objectT());
        /// </code>
        /// </summary>
        /// <param name="type">
        ///     type do objeto armazenavel 
        ///     OBS:(o tipo e informado pois pode ser um objeto de transição DTO, ModelView)
        /// </param>
        /// <param name="objStore">objeto armazenavel</param>
        /// <returns></returns>
        public static string StoreObjectCache(Type type, object objStore)
        {
            // Captura as propriedades armazenaveis
            var prop = (
                            from x in type.GetProperties()
                            where (
                                        from s in x.GetCustomAttributes(true)
                                        where s.GetType() == typeof(StoreAttribute)
                                        select s
                                   ).Count() > 0
                            select x
                        ).ToArray();

            // Seta o objeto temporatio e armazena
            Dictionary<string, object> temp = new Dictionary<string, object>();
            foreach (var propItem in prop)
            {
                temp.Add(propItem.Name, objStore.GetType().GetProperty(propItem.Name).GetValue(objStore, null));
            }

            // Gera uma chave para o cache
            var key = new Guid().ToString();

            // Armazena o objeto
            Webaula.Cache.CacheHelper.Add<Dictionary<string, object>>(temp, key);
            return key;
        }


        /// <summary>
        /// CopyProperties, copia as propriedades de uma instância para outra.
        /// </summary>
        /// <typeparam name="D">TModel destino de dados</typeparam>
        /// <param name="origin">Dicionário de origem de dados</param>
        /// <param name="destination">Objeto destino de dados</param>
        /// <returns>Objeto destino de dados</returns>
        public static D CopyProperties<D>(Dictionary<String, Object> origin, D destination)
        {
            foreach (var item in origin)
            {
                PropertyInfo destinyProp = destination.GetType().GetProperty(item.Key);
                if (destinyProp != null)
                    destinyProp.SetValue(destination, item.Value, null);
            }
            return destination;
        }
    }
}
