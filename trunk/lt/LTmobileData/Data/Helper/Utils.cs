using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data;
using GDA;

namespace LTmobileData.Data.Helper
{
    public class Utils
    {
        /// <summary>
        /// Retorna o diretório raiz da aplicação
        /// </summary>
        public static string LocalPath
        {
            get
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            }
        }
    }
}
