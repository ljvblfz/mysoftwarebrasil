using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using Sinc_DATA.DAL;
using Sinc_DATA.Model;

namespace Sinc_DATA.BFL
{
    public class MensagemMovimentoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<MensagemMovimento> Lista()
        {
            MensagemMovimentoDAO MensagemMovimento = new MensagemMovimentoDAO();
            return MensagemMovimento.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<MensagemMovimento> ListMensagemMovimento)
        {
            MensagemMovimentoDAO MensagemMovimento = new MensagemMovimentoDAO();

            try
            {
                foreach(MensagemMovimento ItemMensagemMovimento in ListMensagemMovimento)
                    MensagemMovimento.Insert(ItemMensagemMovimento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
		
		/// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static string getImpotacao(int grupo,int rotaIni,int rotaFim)
        {
            string result = "";
            MensagemMovimentoDAO MensagemMovimento = new MensagemMovimentoDAO();
            List<MensagemMovimento> lista = MensagemMovimento.Importar(grupo,rotaIni,rotaFim);
            foreach(MensagemMovimento item in lista)
            {
                result+=item.__ToSQL+";";
            }
            return result;
        }
    }
}