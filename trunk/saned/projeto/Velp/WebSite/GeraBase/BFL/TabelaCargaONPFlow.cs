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
    public class TabelaCargaONPFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<TabelaCargaONP> Lista()
        {
            TabelaCargaONPDAO TabelaCargaONP = new TabelaCargaONPDAO();
            return TabelaCargaONP.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<TabelaCargaONP> ListTabelaCargaONP)
        {
            TabelaCargaONPDAO TabelaCargaONP = new TabelaCargaONPDAO();

            try
            {
                foreach(TabelaCargaONP ItemTabelaCargaONP in ListTabelaCargaONP)
                    TabelaCargaONP.Insert(ItemTabelaCargaONP);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}