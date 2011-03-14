using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject.Util
{
    /// <summary>
    ///  Classe responsavel por conversão de tipos
    /// </summary>
    /// <typeparam name="T">T objeto generico</typeparam>
    public class Convert<T>
    {
        /// <summary>
        ///  Convert um array do tipo object de models e uma lista do tipo model comtendo as models
        /// </summary>
        /// <param name="arrayDados">array (ATENÇÃO O ARRAY DEVERA CONTER O TIPO DA MODEL "T")</param>
        /// <returns>uma lista de models</returns>
        public static List<T> convertObjectToModel(object[] arrayDados)
        {
            List<T> listaRetorno = new List<T>();
            foreach (object item in arrayDados)
                listaRetorno.Add((T)item);
            return listaRetorno;
        }
    }
}
