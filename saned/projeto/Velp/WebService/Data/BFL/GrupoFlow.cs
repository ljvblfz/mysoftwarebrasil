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
    public static class GrupoFlow
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<GrupoONP> ListaGrupo()
        {
            GrupoDAO grupos = new GrupoDAO();
            return grupos.ListaGrupo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="rotaInicial"></param>
        /// <param name="rotaFinal"></param>
        /// <returns></returns>
        public static int RetornaSetor(int grupo, int rotaInicial, int rotaFinal)
        {
            GrupoDAO grupos = new GrupoDAO();
            int setor = grupos.RetornaSetor(grupo, rotaInicial, rotaFinal);
            return setor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public static DateTime RetornaReferencia(int grupo)
        {
            GrupoDAO grupos = new GrupoDAO();
            DateTime setor = grupos.RetornaReferencia(grupo);
            return setor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<GrupoONP> ListaGrupoSelect()
        {
            GrupoDAO grupos = new GrupoDAO();
            GrupoONP itemGrupo = new GrupoONP();
            List<GrupoONP> listaGrupo = new List<GrupoONP>();
            listaGrupo.Add(itemGrupo);
            listaGrupo = grupos.ListaGrupo();
            return listaGrupo;
        }
    }
}
