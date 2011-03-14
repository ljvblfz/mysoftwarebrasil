using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{

    public class HistoricoFlow
    {
        /// <summary>
        ///  Retorna uma lista com os historicos de consumo
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="referencia"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public static List<HistoricoONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            HistoricoDAO Historico = new HistoricoDAO();
            List<HistoricoONP> listaHistoriocoAUX = Historico.Lista(grupo, referencia, rotaInicial, rotaFinal);
            List<HistoricoONP> listaHistorioco = new List<HistoricoONP>(); 

            // Logica para evitar registros com a chave repetida
            foreach (HistoricoONP item in listaHistoriocoAUX)
            {
                HistoricoONP historico = listaHistorioco.Find(delegate(HistoricoONP p1) { return (p1.cod_referencia == item.cod_referencia && p1.seq_matricula == item.seq_matricula); });

                if (historico == null)
                    listaHistorioco.Add(item);
            }
            return listaHistorioco;
        }
    }
}