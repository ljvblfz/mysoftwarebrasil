using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using LTmobileData.Data.DAL;
using GDA.Sql;

namespace LTmobileData.Data.BFL
{
    public class MensagemUcFlow
    {
        public static void AlteraStatusMensagem(string Condicao)
        {
            new MensagemUcDAO().AlteraStatusMensagem(Condicao);
        }

        public static List<mensagemUc> getMensagemNotSync()
        {
            return new MensagemUcDAO().getMensagemNotSync();
        }

        /// <summary>
        /// Recupera todas as mensagens da Uc
        /// </summary>
        /// <param name="Uc"></param>
        /// <returns></returns>
        public static List<mensagemUc> getMensagemUc(int Uc)
        {
            return new MensagemUcDAO().getMensagemUc(Uc);
        }

        /// <summary>
        /// Verifica se existe mensagem
        /// </summary>
        /// <param name="Uc"></param>
        /// <returns></returns>
        public static Boolean existeMensagem(int Uc)
        {
            return new MensagemUcDAO().existeMensagem(Uc);
        }

        /// <summary>
        /// Insere
        /// </summary>
        /// <param name="mensagem"></param>
        public static void Insert(mensagemUc mensagem)
        {
            try
            {
                new MensagemUcDAO().Insert(mensagem);
                LeituraFlow.setQtdLeituraRealizada();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir informações da unidade consumidora. Ex: "+ex+"");
            }

        }

        /// <summary>
        /// Cria um identificador para mensagem
        /// </summary>
        /// <returns></returns>
        public static int getIdMensagem()
        {
            return new MensagemUcDAO().getIdMensagem();
        }

        public static void DeleteTodos()
        {
            new MensagemUcDAO().DeleteTodos();
        }
    }
}
