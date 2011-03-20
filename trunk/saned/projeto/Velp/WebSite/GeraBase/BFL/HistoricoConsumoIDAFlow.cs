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
    public class HistoricoConsumoIDAFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<HistoricoConsumoIDA> Lista()
        {
            HistoricoConsumoIDADAO HistoricoConsumoIDA = new HistoricoConsumoIDADAO();
            return HistoricoConsumoIDA.Lista();
        }

        /// <summary>
        /// Metodo que retorna historico
        /// </summary>
        /// <returns></returns>
        public static List<HistoricoConsumoIDA> Lista(int CDC)
        {
            HistoricoConsumoIDADAO HistoricoConsumoIDA = new HistoricoConsumoIDADAO();
            string where = String.Format("CDC = {0}", CDC);
            return HistoricoConsumoIDA.Select(where);
        }

        /// <summary>
        /// Metodo que retorna historico
        /// </summary>
        /// <returns></returns>
        public static List<HistoricoConsumoIDA> Lista(int CDC,DateTime referencia)
        {
            List<HistoricoConsumoIDA> listaHistorioco = new List<HistoricoConsumoIDA>();
            HistoricoConsumoIDADAO HistoricoConsumoIDA = new HistoricoConsumoIDADAO();
            string where = String.Format("CDC = {0} AND Referencia = CONVERT(DATETIME,'{1}',103) ", CDC, referencia.ToString());
            listaHistorioco = HistoricoConsumoIDA.Select(where);
            return listaHistorioco;
        }

        /// <summary>
        ///  Retorna a referencia anterior
        /// </summary>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public static DateTime getReferenciaAnterior(DateTime referencia,int CDC)
        {
            DateTime referenciaAnterior = referencia;
            HistoricoConsumoIDADAO HistoricoConsumoIDA = new HistoricoConsumoIDADAO();
            referenciaAnterior = HistoricoConsumoIDA.MaxReferencia(referencia,CDC);
            return referenciaAnterior;
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<HistoricoConsumoIDA> ListHistoricoConsumoIDA)
        {
            HistoricoConsumoIDADAO HistoricoConsumoIDA = new HistoricoConsumoIDADAO();

            try
            {
                foreach(HistoricoConsumoIDA ItemHistoricoConsumoIDA in ListHistoricoConsumoIDA)
                    HistoricoConsumoIDA.Insert(ItemHistoricoConsumoIDA);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}