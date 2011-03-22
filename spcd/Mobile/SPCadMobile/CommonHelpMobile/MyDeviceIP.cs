using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace CommonHelpMobile
{
    public class MyDeviceIP
    {
        /// <summary>
        /// Retorna o IP do dispositivo móvel.
        /// </summary>
        /// <returns></returns>
        public static string GetMyIP()
        {
            IPHostEntry hostentry = Dns.GetHostEntry(Dns.GetHostName());
            if (hostentry != null)
            {
                IPAddress[] collectionOfIPs = hostentry.AddressList;
                return collectionOfIPs[0].ToString();
            }
            else
            {
                return "Ip Erro";
            }
        }
    }
}
