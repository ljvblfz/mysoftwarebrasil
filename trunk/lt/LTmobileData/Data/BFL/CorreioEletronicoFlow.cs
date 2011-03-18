using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using LTmobileData.Data.DAL;
using GDA.Sql;

namespace LTmobileData.Data.BFL
{
    public class CorreioEletronicoFlow
    {
        /// <summary>
        /// Retorna mensagens da caixa de entrada
        /// </summary>
        /// <returns></returns>
        public static List<CorreioEletronico> getCaixaEntrada()
        {
            return new CorreioEletronicoDAO().getCaixaEntrada(UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        public static void DeleteTodos()
        {
            new CorreioEletronicoDAO().DeleteTodos();
        }

        public static void AlteraStatusCorreioEletronico(string Condicao)
        {
            new CorreioEletronicoDAO().AlteraStatusCorreioEletronico(Condicao);
        }

        public static List<CorreioEletronico> getCorreioEletronicoNotSync()
        {
            return new CorreioEletronicoDAO().getCorreioEletronicoNotSync();
        }

        /// <summary>
        /// Retorna mensagens da caixa de Saída
        /// </summary>
        /// <returns></returns>
        public static List<CorreioEletronico> getCaixaSaida()
        {
            return new CorreioEletronicoDAO().getCaixaSaida(UsuarioFlow.UsuarioCurrent.MATRIC_FUNC);
        }

        public static void Insert(CorreioEletronico correioEletronico)
        {
            try
            {
                new CorreioEletronicoDAO().Insert(correioEletronico);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível enviar mensagem.");
            }
        }

        public static void DeleteMsg(int id_Msg)
        {
            try
            {
                new CorreioEletronicoDAO().DeleteMsg(id_Msg);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Apagar mensagem. "+ex+"");
            }
        }

        public static int getIdMensagem()
        {
            return new CorreioEletronicoDAO().getIdMensagem();
        }
    }
}
