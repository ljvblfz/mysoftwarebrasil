using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using Data.DAL;
using Data.Model;

namespace Data.BFL
{
    public class VoltaLogAtendimentoFlow
    {
        /// <summary>
        /// Retorna uma lista 
        /// </summary>
        /// <returns></returns>
        public static List<VoltaLogAtendimento> Lista()
        {
            VoltaLogAtendimentoDAO VoltaLogAtendimento = new VoltaLogAtendimentoDAO();
            return VoltaLogAtendimento.Lista();
        }
        
        /// <summary>
        /// Insere os dados de atendimento
        /// </summary>
        /// <param name="logAtendimento"></param>
        public static void Insert(VoltaLogAtendimento logAtendimento)
        {
            try
            {
                VoltaLogAtendimentoDAO VoltaLogAtendimento = new VoltaLogAtendimentoDAO();
                VoltaLogAtendimento.Insert(logAtendimento).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  Veirifica Carga
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rota"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public static int VerificaCarga(int grupo, int rota, DateTime referencia)
        {
            int qtdRoteiros = 0;
            try
            {
                VoltaLogAtendimentoDAO VoltaLogAtendimento = new VoltaLogAtendimentoDAO();
                string where = String.Format("Grupo = {0} AND Rota = {1} AND Referencia = CONVERT(DATETIME,'{2}',102)", grupo, rota, referencia);
                qtdRoteiros = (int)VoltaLogAtendimento.Count(new GDA.Sql.Query(where));
            }
            catch (Exception ex)
            {
            }
            return qtdRoteiros;
        }
    }
}