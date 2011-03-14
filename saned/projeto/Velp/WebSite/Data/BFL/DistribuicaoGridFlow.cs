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
    public class DistribuicaoGridFlow
    {
        /// <summary>
        ///  Lista a Distribuição para carregar o grid
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public static List<DistribuicaoGrid> Lista(DateTime Referencia)
        {
            DistribuicaoGridDAO objDistribuicao = new DistribuicaoGridDAO();
            
            // Retorna todos os grupos
            List<GrupoONP> listaGrupos = GrupoFlow.ListaGrupo();
            
            List<DistribuicaoGrid> listaDistribuicao = new List<DistribuicaoGrid>();

            foreach (GrupoONP item in listaGrupos)
            {
                DistribuicaoGrid distribuicaoAUX = objDistribuicao.ListaDistribuicao(item.Grupo, Referencia);
                listaDistribuicao.Add(distribuicaoAUX);
            }
            return listaDistribuicao;
        }

    }
}
