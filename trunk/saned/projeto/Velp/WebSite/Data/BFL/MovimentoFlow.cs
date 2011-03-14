using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{
    public class MovimentoFlow
    {
        public static List<MovimentoONP> ListaMovimento(int grupo, DateTime referencia, int rotaInicial, int rotaFinal,int agente,int pagina)
        {
            MovimentoDAO Movimento = new MovimentoDAO();
            List<MovimentoONP> listaMovimento = Movimento.Lista(grupo, referencia, rotaInicial, rotaFinal,agente,pagina);
            return listaMovimento;
        }
    }
}
