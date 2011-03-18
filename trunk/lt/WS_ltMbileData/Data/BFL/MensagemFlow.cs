using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.DAO;
using WS_ltMbileData.Data.Model;

namespace WS_ltMbileData.Data.BFL
{
    public class MensagemFlow
    {
        /// <summary>
        /// Recupera as mensagens
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public static List<MensagemWS> getMensagem(string Condicao)
        {
            return new MensagemDAO().getMensagem(Condicao);
        }

        public static void Insert(MensagemWS mensagem)
        {
            new MensagemDAO().Insert(mensagem);
        }

        public static void setMensagemConfirmada(string Condicao)
        {
            new MensagemDAO().setMensagemConfirmada(Condicao);
        }
    }
}
