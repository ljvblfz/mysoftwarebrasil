using System;
using System.Linq;
using System.Collections.Generic;
using LTmobileData.Data.Model;
using LTmobileData.Data.DAL;
using GDA.Sql;
using System.Text;

namespace LTmobileData.Data.BFL
{
    public class OcorrenciaFlow
    {
        /// <summary>
        /// Retorna a ocorrencia específica do código
        /// </summary>
        /// <param name="ocorrencia">código da ocorrencia</param>
        /// <returns></returns>
        public static List<Ocorrencia> getOcorrencia(string ocorrencia)
        {
            return new OcorrenciaDAO().getOcorrencia(ocorrencia);
        }

        /// <summary>
        /// Necessita de complemento
        /// </summary>
        /// <param name="Irregularidade"></param>
        /// <returns></returns>
        public static bool NecessitaComplemento(string Irregularidade)
        {
            return new OcorrenciaDAO().NecessitaComplemento(Irregularidade);
        }

        public static bool ExisteImpedimento(string Irregularidade)
        {
            return new OcorrenciaDAO().ExisteImpedimento(Irregularidade);
        }

        public static void InsertOrUpdate(Ocorrencia ocorrencia)
        {

            try
            {
                new OcorrenciaDAO().InsertOrUpdate(ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar ocorrência");
            }
        }

        /// <summary>
        /// Retorna todas as ocorrencias
        /// </summary>
        /// <param name="ocorrencia"></param>
        /// <returns></returns>
        public List<Ocorrencia> getTodasOcorrencias()
        {
            return new OcorrenciaDAO().getTodasOcorrencias();
        }

        public static List<Ocorrencia> getOcorrenciaUC(int IRREGL_ATUAL1, int IRREGL_ATUAL2, int IRREGL_ATUAL3)
        {
            return new OcorrenciaDAO().getOcorrenciaUC(IRREGL_ATUAL1, IRREGL_ATUAL2, IRREGL_ATUAL3);
        }

        public static bool ExisteOcorrenciaImpedimento(int IRREGL_ATUAL1, int IRREGL_ATUAL2, int IRREGL_ATUAL3)
        { 
            return new OcorrenciaDAO().ExisteOcorrenciaImpedimento(IRREGL_ATUAL1, IRREGL_ATUAL2, IRREGL_ATUAL3);
        }

        public static bool ExigeFoto(int IRREGL_ATUAL1, int IRREGL_ATUAL2, int IRREGL_ATUAL3)
        {
            return new OcorrenciaDAO().ExigeFoto(IRREGL_ATUAL1, IRREGL_ATUAL2, IRREGL_ATUAL3);
        }

        public static void DeleteTodos()
        {
            new OcorrenciaDAO().DeleteTodos();
        }
    }
}
