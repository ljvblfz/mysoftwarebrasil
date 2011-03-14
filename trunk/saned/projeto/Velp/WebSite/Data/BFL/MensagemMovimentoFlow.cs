using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.DAL;
using GDA;

namespace Data.BFL
{
    public static class MensagemMovimentoFlow
    {
        public static List<MensagemMovimentoONP> ListaMensagemMovimento(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            MensagemMovimentoDAO mensagem = new MensagemMovimentoDAO();
            return mensagem.Lista(grupo,referencia,rotaInicial,rotaFinal);
        }
    }
}
