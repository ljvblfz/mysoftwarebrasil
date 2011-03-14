using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using Data.DAL;
using Data.Model;

namespace Data.BFL
{
    public class VoltaAlteracaoFlow
    {
        /// <summary>
        ///  Retorna uma lista 
        /// </summary>
        /// <returns></returns>
        public static List<VoltaAlteracao> Lista()
        {
            VoltaAlteracaoDAO VoltaAlteracao = new VoltaAlteracaoDAO();
            return VoltaAlteracao.Lista();
        }

        /// <summary>
        ///  Insere os dados
        /// </summary>
        /// <param name="alteracao"></param>
        public static void Insert(VoltaAlteracao alteracao)
        {
            VoltaAlteracaoDAO VoltaAlteracao = new VoltaAlteracaoDAO();
            try
            {
                VoltaAlteracao.Insert(alteracao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}