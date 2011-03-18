using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using System.Data.SqlServerCe;
using GDA;

namespace LTmobileData.Data.DAL
{
    public class OcorrenciaDAO : BaseDAO<Ocorrencia>
    {
        /// <summary>
        /// Sql
        /// </summary>
        string strSql;

        /// <summary>
        /// Retorna a ocorrencia específica do código
        /// </summary>
        /// <param name="Ocorrencia"></param>
        /// <returns></returns>
        public List<Ocorrencia> getOcorrencia(string Ocorrencia)
        {
            strSql = "SELECT * " +
                            "FROM LTTB_IRREGULARIDADES WHERE COD_IRREGL = " + Ocorrencia + " AND COD_IRREGL <> 0";

            return CurrentPersistenceObject.LoadData(strSql);
                            
        }
        

        /// <summary>
        /// Retrna todas as ocorrencias
        /// </summary>
        /// <returns></returns>
        public List<Ocorrencia> getTodasOcorrencias()
        {
            strSql = "SELECT COD_IRREGL, DESC_IRREGL, COD_EMPRT, USUAR_ATLZ, DATA_ATLZ, HORA_ATLZ, NUM_PRIOR, FLAG_IMPEDIMENTO, FLAG_COMPLEMENTO, FLAG_FOTO, OBS_PADRAO " +
                     "FROM LTTB_IRREGULARIDADES "+
                     "WHERE COD_IRREGL <> 0";

            return CurrentPersistenceObject.LoadData(strSql);
        }

        public List<Ocorrencia> getOcorrenciaUC(int IRREGL_ATUAL1, int IRREGL_ATUAL2, int IRREGL_ATUAL3)
        {
            strSql = "SELECT COD_IRREGL, DESC_IRREGL, COD_EMPRT, USUAR_ATLZ, DATA_ATLZ, HORA_ATLZ, NUM_PRIOR, FLAG_IMPEDIMENTO, FLAG_COMPLEMENTO, FLAG_FOTO, OBS_PADRAO " +
                     "FROM LTTB_IRREGULARIDADES WHERE (COD_IRREGL = " + IRREGL_ATUAL1 + " OR COD_IRREGL = " + IRREGL_ATUAL2 + " OR COD_IRREGL = " + IRREGL_ATUAL3 + ") AND COD_IRREGL <> 0";

            return CurrentPersistenceObject.LoadData(strSql);
        }

        public bool ExisteOcorrenciaImpedimento(int IRREGL_ATUAL1, int IRREGL_ATUAL2, int IRREGL_ATUAL3)
        {
            strSql = "SELECT COUNT(*) " +
                     "FROM LTTB_IRREGULARIDADES WHERE (COD_IRREGL = " + IRREGL_ATUAL1 + " OR COD_IRREGL = " + IRREGL_ATUAL2 + " OR COD_IRREGL = " + IRREGL_ATUAL3 + ") AND COD_IRREGL <> 0 AND FLAG_IMPEDIMENTO = 'S'";
            if (int.Parse(CurrentPersistenceObject.ExecuteScalar(strSql).ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExigeFoto(int IRREGL_ATUAL1, int IRREGL_ATUAL2, int IRREGL_ATUAL3)
        {
            strSql = "SELECT COUNT(*) " +
                     "FROM LTTB_IRREGULARIDADES WHERE (COD_IRREGL = " + IRREGL_ATUAL1 + " OR COD_IRREGL = " + IRREGL_ATUAL2 + " OR COD_IRREGL = " + IRREGL_ATUAL3 + ") AND COD_IRREGL <> 0 AND FLAG_FOTO = 'S'";
            if (int.Parse(CurrentPersistenceObject.ExecuteScalar(strSql).ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NecessitaComplemento(string Irregularidade)
        {
            strSql = "SELECT FLAG_COMPLEMENTO FROM LTTB_IRREGULARIDADES WHERE COD_IRREGL = " + Irregularidade + "";
            if (CurrentPersistenceObject.ExecuteScalar(strSql).ToString() == "S")
            {
                return true;
            }else 
            {return false;}
        }

        public bool ExisteImpedimento(string Irregularidade)
        {
            strSql = "SELECT FLAG_IMPEDIMENTO FROM LTTB_IRREGULARIDADES WHERE COD_IRREGL = " + Irregularidade + "";
            if (CurrentPersistenceObject.ExecuteScalar(strSql).ToString() == "S")
            {
                return true;
            }
            else
            { return false; } 
        }

        public void DeleteTodos()
        {
            string strSql = "DELETE FROM LTTB_IRREGULARIDADES";
            CurrentPersistenceObject.ExecuteCommand(strSql);
        }
    }
}
