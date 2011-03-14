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

    public class VoltaRoteiroFlow
    {
        /// <summary>
        /// Retorna uma lista de roteiros
        /// </summary>
        /// <returns></returns>
        public static List<VoltaRoteiro> Lista()
        {
            VoltaRoteiroDAO VoltaRoteiro = new VoltaRoteiroDAO();
            return VoltaRoteiro.Lista();
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
                VoltaRoteiroDAO objRoteiro = new VoltaRoteiroDAO();
                qtdRoteiros = (int)objRoteiro.QuantRoteiro(grupo, rota, referencia);
            }
            catch (Exception ex)
            {
            }
            return qtdRoteiros;
        }

        /// <summary>
        /// Insere os dados de um roteiro
        /// </summary>
        /// <param name="roteiro"></param>
        public static void Insert(VoltaRoteiro roteiro)
        {
            try
            {
                VoltaRoteiroDAO ObjRoteiro = new VoltaRoteiroDAO();
                List<VoltaRoteiro> listaAUX = Lista().FindAll(delegate (VoltaRoteiro r) {return r.Rota == roteiro.Rota && r.Referencia == roteiro.Referencia;});

                if (listaAUX.Count <= 0)
                    ObjRoteiro.Insert(roteiro);
                if (listaAUX.Count > 1)
                {
                    ObjRoteiro.Delete(roteiro);
                    ObjRoteiro.Insert(roteiro);
                }
                if (listaAUX.Count == 1)
                    ObjRoteiro.Update(roteiro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}