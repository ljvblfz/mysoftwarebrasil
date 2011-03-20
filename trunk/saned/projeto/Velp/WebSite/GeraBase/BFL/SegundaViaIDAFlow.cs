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
    public class SegundaViaIDAFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<SegundaViaIDA> Lista()
        {
            SegundaViaIDADAO SegundaViaIDA = new SegundaViaIDADAO();
            return SegundaViaIDA.Lista();
        }

        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <param name="CDC"></param>
        /// <returns></returns>
        public static List<SegundaViaIDA> Lista(int CDC)
        {
            SegundaViaIDADAO SegundaViaIDA = new SegundaViaIDADAO();
            string where = String.Format("CDC = {0}", CDC);
            return SegundaViaIDA.Select(new GDA.Sql.Query(where));
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<SegundaViaIDA> ListSegundaViaIDA)
        {
            SegundaViaIDADAO SegundaViaIDA = new SegundaViaIDADAO();

            try
            {
                foreach(SegundaViaIDA ItemSegundaViaIDA in ListSegundaViaIDA)
                    SegundaViaIDA.Insert(ItemSegundaViaIDA);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}