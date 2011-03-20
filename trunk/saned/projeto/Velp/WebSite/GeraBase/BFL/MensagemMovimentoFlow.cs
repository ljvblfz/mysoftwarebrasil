using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeraBase.Model;
using GeraBase.DAL;
using GDA;

namespace GeraBase.BFL
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
