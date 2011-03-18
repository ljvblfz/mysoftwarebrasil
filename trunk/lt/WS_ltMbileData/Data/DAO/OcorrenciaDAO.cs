using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using System.Data.OracleClient;

namespace WS_ltMbileData.Data.DAO
{
    public class OcorrenciaDAO
    {
         #region Atributos

        private ConexaoBD conexaoBD;

        #endregion

        #region Construtores

        public OcorrenciaDAO()
        {
            conexaoBD = ConexaoBD.Create();
        }

        #endregion

        public List<OcorrenciaWS> getOcorrencia()
        {
            List<OcorrenciaWS> lstOcorrencia = new List<OcorrenciaWS>();
            OracleDataReader reader = null;
            string strSqlUpdate = "";
            try
            {
                string strSql = "select *" +
                                " FROM LTTB_IRREGULARIDADES";
                try
                {
                    conexaoBD.OpenConnection();
                }
                catch (Exception ex)
                {
                    string teste = ex.ToString();
                }
                OracleCommand cmd = conexaoBD.CreateCommand();
                cmd.CommandText = strSql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OcorrenciaWS ocorrencia = new OcorrenciaWS();

                    ocorrencia.COD_EMPRT = Convert.ToInt32(reader["COD_EMPRT"]);
                    ocorrencia.COD_IRREGL = Convert.ToInt32(reader["COD_IRREGL"]);
                    ocorrencia.DATA_ATLZ = Convert.ToDateTime(reader["DATA_ATLZ"]);
                    ocorrencia.DESC_IRREGL = reader["DESC_IRREGL"].ToString();
                    ocorrencia.FLAG_COMPLEMENTO = reader["FLAG_COMPLEMENTO"].ToString();
                    ocorrencia.FLAG_FOTO = reader["FLAG_FOTO"].ToString();
                    ocorrencia.OBS_PADRAO = reader["OBS_PADRAO"].ToString();
                    ocorrencia.FLAG_IMPEDIMENTO = reader["FLAG_IMPEDIMENTO"].ToString();
                    ocorrencia.HORA_ATLZ = reader["HORA_ATLZ"].ToString();
                    ocorrencia.NUM_PRIOR = Convert.ToInt32(reader["NUM_PRIOR"]);
                    ocorrencia.USUAR_ATLZ = reader["USUAR_ATLZ"].ToString();

                    lstOcorrencia.Add(ocorrencia);

                }

                

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.conexaoBD.CloseConection();
            }
            return lstOcorrencia;
        }
    }
}
