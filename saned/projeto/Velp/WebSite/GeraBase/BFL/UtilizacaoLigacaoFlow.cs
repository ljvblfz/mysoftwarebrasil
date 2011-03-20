using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using GeraBase.DAL;
using GeraBase.Model;

namespace GeraBase.BFL
{
    public class UtilizacaoLigacaoFlow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<UtilizacaoLigacaoONP> Lista()
        {
            UtilizacaoLigacaoDAO UtilizacaoLigacaoONP = new UtilizacaoLigacaoDAO();
            return UtilizacaoLigacaoONP.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<UtilizacaoLigacaoONP> ListUtilizacaoLigacaoONP)
        {
            UtilizacaoLigacaoDAO UtilizacaoLigacaoONP = new UtilizacaoLigacaoDAO();

            try
            {
                foreach(UtilizacaoLigacaoONP ItemUtilizacaoLigacaoONP in ListUtilizacaoLigacaoONP)
                    UtilizacaoLigacaoONP.Insert(ItemUtilizacaoLigacaoONP);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        ///  Metodo que retorna uma lista
        /// </summary>
        /// <returns></returns>
        public static List<UtilizacaoLigacaoONP> ListaUtilizacaoLigacao()
        {
            UtilizacaoLigacaoDAO UtilizacaoLigacaoONP = new UtilizacaoLigacaoDAO();
            return UtilizacaoLigacaoONP.RetornaLista();
        }
    }
}