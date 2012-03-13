using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PontoEncontro.Infrastructure
{
    /// <summary>
    ///  Classe de Data hora
    /// </summary>
    public class Date
    {
        /// <summary>
        ///  Retorna a idade apartir do nascimento
        /// </summary>
        /// <param name="birth">data de nascimento</param>
        /// <returns>idade</returns>
        public static int GetAge(DateTime birth)
        {
            int age = DateTime.Now.Year - birth.Year;
            if (DateTime.Now.Month < birth.Month ||
            (DateTime.Now.Month == birth.Month &&
            DateTime.Now.Day < birth.Day))
                age--;
            return age == null ? 0 : age;
        }
    }
}
