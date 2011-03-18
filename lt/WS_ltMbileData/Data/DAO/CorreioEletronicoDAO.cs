using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using System.Data.OracleClient;


namespace WS_ltMbileData.Data.DAO
{
    public class CorreioEletronicoDAO
    {
        #region Atributos

        private ConexaoBD conexaoBD;

        #endregion

        #region Construtores

        public CorreioEletronicoDAO()
        {
            conexaoBD = ConexaoBD.Create();
        }

        #endregion

        /// <summary>
        /// Altera o status da Correio Eletronico baseado na condião recebida do PDA
        /// </summary>
        public void setCorreioEletronicoConfirmado(string Usuario, string Condicao)
        {
            string strSql = "UPDATE TB_CORREIOELETRONICO " +
                    "SET STATUS_REG = 1, STATUS_MSG = 1 " +
                    "WHERE MATRIC_FUNC = "+Usuario+" AND TIPO_MSG = 'R' AND STATUS_REG = 2 "+
                    "AND STATUS_MSG = 0 "+Condicao+"";

            try
            {
                conexaoBD.OpenConnection();
                OracleCommand cmd = conexaoBD.CreateCommand();
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.conexaoBD.CloseConection();
            }

        }

        public List<CorreioEletronicoWS> getCorreioEletronico(string Usuario)
        { 
            List<CorreioEletronicoWS> lstCorreioEletronico = new List<CorreioEletronicoWS>();
            OracleDataReader reader = null;
            string strSqlUpdate = "";
            try
            {
                string strSql = "select *" +
                                " FROM TB_CORREIOELETRONICO" +
                                " WHERE MATRIC_FUNC = " + Usuario+" AND TIPO_MSG = 'R' AND STATUS_REG = 2 AND STATUS_MSG = 0";


                conexaoBD.OpenConnection();
                OracleCommand cmd = conexaoBD.CreateCommand();
                cmd.CommandText = strSql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CorreioEletronicoWS correio = new CorreioEletronicoWS();
                    correio.ASSUNTO = reader["ASSUNTO"].ToString();
                    correio.COD_EMPRT = Convert.ToInt32(reader["COD_EMPRT"]); 
                    correio.DESC_MSG = reader["DESC_MSG"].ToString();
                    correio.DT_MSG = Convert.ToDateTime(reader["DT_MSG"]);
                    correio.ID_MSG = Convert.ToInt32(reader["ID_MSG"]);
                    correio.MATRIC_FUNC = Convert.ToInt32(reader["MATRIC_FUNC"]);
                    correio.STATUS_MSG = reader["STATUS_MSG"].ToString();
                    correio.STATUS_REG = reader["STATUS_REG"].ToString();
                    correio.TIPO_MSG = reader["TIPO_MSG"].ToString();

                    lstCorreioEletronico.Add(correio);
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
            return lstCorreioEletronico;
        }

        public void Insert(CorreioEletronicoWS correio)
        {
            string strSql = "INSERT INTO TB_CORREIOELETRONICO (COD_EMPRT, MATRIC_FUNC, ID_MSG, ASSUNTO, " +
                            "DT_MSG, STATUS_MSG, DESC_MSG, TIPO_MSG, STATUS_REG) " +
                            "VALUES (:COD_EMPRT, :MATRIC_FUNC, :ID_MSG, :ASSUNTO, "+
                            ":DT_MSG, :STATUS_MSG, :DESC_MSG, :TIPO_MSG, :STATUS_REG)";

            this.conexaoBD.ExecuteNonQuery(strSql,
            new OracleParameter(":COD_EMPRT", correio.COD_EMPRT),
            new OracleParameter(":MATRIC_FUNC", correio.MATRIC_FUNC),
            new OracleParameter(":ID_MSG", correio.ID_MSG),
            new OracleParameter(":ASSUNTO", correio.ASSUNTO),
            new OracleParameter(":DT_MSG", correio.DT_MSG),
            new OracleParameter(":STATUS_MSG", correio.STATUS_MSG),
            new OracleParameter(":DESC_MSG", correio.DESC_MSG),
            new OracleParameter(":TIPO_MSG", correio.TIPO_MSG),
            new OracleParameter(":STATUS_REG", correio.STATUS_REG));

        
        }
    }
}
