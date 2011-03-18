using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using LTmobileData.Data.DAL;
using GDA.Sql;

namespace LTmobileData.Data.BFL
{
    public class LeituraProvisoriaFlow
    {
        public static List<LeituraProvisoria> LeituraProvisoriaNotSync()
        {
            return new LeituraProvisoriaDAO().getLeituraProvisoriaNotSync();

        }

        public static void AlteraStatusLeituraProvisoria(string Condicao)
        {
            new LeituraProvisoriaDAO().AlteraStatusLeituraProvisoria(Condicao);
        }

        /// <summary>
        /// Atualiza informações da UC Provisória
        /// </summary>
        /// <param name="leituraProvisória"></param>
        public static void Insert(LeituraProvisoria leituraProvisoria)
        {
            try
            {
                new LeituraProvisoriaDAO().Insert(leituraProvisoria);
                LeituraFlow.setQtdLeituraRealizada();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir UC provisória.");
            }

        }

        public static void InsertOrUpdate(LeituraProvisoria leituraProvisoria)
        {
            try
            {
                new LeituraProvisoriaDAO().InsertOrUpdate(leituraProvisoria);
                LeituraFlow.setQtdLeituraRealizada();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir UC provisória.");
            }

        }

        public static void Update(LeituraProvisoria leituraProvisoria)
        {
            try
            {
                new LeituraProvisoriaDAO().Update(leituraProvisoria);
                LeituraFlow.setQtdLeituraRealizada();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível alterar UC provisória.");
            }

        }

        public static void DeleteTodos()
        {
            new LeituraProvisoriaDAO().DeleteTodos();
        }

    }
}
