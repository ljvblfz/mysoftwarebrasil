using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonHelpMobile
{
    public class Paths
    {
        /// <summary>
        /// Retorna o local onde está armazenado o banco de dados SQLCE.
        /// </summary>
        /// <returns></returns>
        public static string GetLocalPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }
    }
}
