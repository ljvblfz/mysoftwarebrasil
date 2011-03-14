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
    public class GrupoFaturaFlow
    {
        public static List<GrupoFaturaONP> ListaGrupoFatura(int grupo)
        {
            GrupoFaturaDAO GrupoFatura = new GrupoFaturaDAO();
            return GrupoFatura.Lista(grupo);
        }
    }
}
