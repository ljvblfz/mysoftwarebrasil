using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using GeraBase.DAL;
using GeraBase.Model;

namespace GeraBase.BFL
{
    public class AvisoDebitoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<AvisoDebito> Lista()
        {
            AvisoDebitoDAO AvisoDebito = new AvisoDebitoDAO();
            return AvisoDebito.Lista();
        }

        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<AvisoDebito> RetornaAvisoDebito(int grupo, int rotaInicial, int rotaFinal)
        {
            AvisoDebitoDAO AvisoDebito = new AvisoDebitoDAO();
            return AvisoDebito.RetornaAvisoDebito(grupo, rotaInicial, rotaFinal);
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<AvisoDebito> ListAvisoDebito)
        {
            AvisoDebitoDAO AvisoDebito = new AvisoDebitoDAO();

            try
            {
                foreach(AvisoDebito ItemAvisoDebito in ListAvisoDebito)
                    AvisoDebito.Insert(ItemAvisoDebito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}