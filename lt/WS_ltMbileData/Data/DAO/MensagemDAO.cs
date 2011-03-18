using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using System.Data.OracleClient;

namespace WS_ltMbileData.Data.DAO
{
    public class MensagemDAO
    {
         #region Atributos

        private ConexaoBD conexaoBD;

        #endregion

        #region Construtores

        public MensagemDAO()
        {
            conexaoBD = ConexaoBD.Create();
        }

        #endregion

        /// <summary>
        /// Altera o status da Correio Eletronico baseado na condião recebida do PDA
        /// </summary>
        public void setMensagemConfirmada(string Condicao)
        {
            string strSql = "UPDATE TB_MENSAGEM " +
                                "SET STATUS_REG = 1 " +
                                "where STATUS_REG = 2 AND FLAG_SENTIDO = 'R' " + Condicao + "";

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

        public List<MensagemWS> getMensagem(string Condicao)
        {
            List<MensagemWS> lstMensagem = new List<MensagemWS>();
            OracleDataReader reader = null;
            string strSqlUpdate = "";
            try
            {
                /*string strSql = "select *"+ 
                                "from TB_MENSAGEM M, LTDT_ORDENS_LEITURA L "+
                                "where M.COD_EMPRT = L.COD_EMPRT "+
                                "AND M.COD_LOCAL = L.COD_LOCAL "+
                                "AND M.MES_ANO_FATUR = L.MES_ANO_FATUR "+
                                "AND M.NUM_RAZAO = L.NUM_RAZAO "+
                                "AND L.NUM_UC = M.NUM_UC "+
                                "AND M.TIPO_MEDIC = L.TIPO_MEDIC "+
                                "AND L.ESTADO_EXEC = 1 AND MATRIC_FUNC = " + Usuario;*/

                string strSql = "select * " +
                                "from TB_MENSAGEM " +
                                "where STATUS_REG = 2 AND FLAG_SENTIDO = 'R' " + Condicao + "";
                   
                                                                           
                conexaoBD.OpenConnection();
                OracleCommand cmd = conexaoBD.CreateCommand();                
                cmd.CommandText = strSql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MensagemWS mensagem = new MensagemWS();

                    mensagem.COD_EMPRT = Convert.ToInt32(reader["COD_EMPRT"]);
                    mensagem.COD_LOCAL = Convert.ToInt32(reader["COD_LOCAL"]);
                    mensagem.DESC_MSG = reader["DESC_MSG"].ToString();
                    mensagem.DT_MSG = Convert.ToDateTime(reader["DT_MSG"]);
                    mensagem.FLAG_SENTIDO = reader["FLAG_SENTIDO"].ToString();
                    mensagem.ID_MSG = Convert.ToInt32(reader["ID_MSG"]);
                    mensagem.MES_ANO_FATUR = Convert.ToInt32(reader["MES_ANO_FATUR"]);
                    mensagem.NUM_RAZAO = Convert.ToInt32(reader["NUM_RAZAO"]);
                    mensagem.NUM_UC = Convert.ToInt32(reader["NUM_UC"]);
                    mensagem.STATUS_REG = reader["STATUS_REG"].ToString();
                    mensagem.TIPO_MEDIC = reader["TIPO_MEDIC"].ToString();
                    
                    
                    lstMensagem.Add(mensagem);

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
            return lstMensagem;
        }

        public void Insert(MensagemWS mensagem)
        {
            string strSql = "INSERT INTO TB_MENSAGEM (ID_MSG, DESC_MSG, NUM_UC, " +
                            "MES_ANO_FATUR, COD_LOCAL, COD_EMPRT, STATUS_REG, " +
                            "NUM_RAZAO, FLAG_SENTIDO, DT_MSG, TIPO_MEDIC) " +
                            "VALUES(:ID_MSG, :DESC_MSG, :NUM_UC, :MES_ANO_FATUR, " +
                            ":COD_LOCAL, :COD_EMPRT, :STATUS_REG, :NUM_RAZAO, :FLAG_SENTIDO, " +
                            ":DT_MSG, :TIPO_MEDIC)";



            this.conexaoBD.ExecuteNonQuery(strSql,
                new OracleParameter(":ID_MSG", mensagem.ID_MSG),
                new OracleParameter(":DESC_MSG", mensagem.DESC_MSG),
                new OracleParameter(":NUM_UC", mensagem.NUM_UC),
                new OracleParameter(":MES_ANO_FATUR", mensagem.MES_ANO_FATUR),
                new OracleParameter(":COD_LOCAL", mensagem.COD_LOCAL),
                new OracleParameter(":COD_EMPRT", mensagem.COD_EMPRT),
                new OracleParameter(":STATUS_REG", mensagem.STATUS_REG),
                new OracleParameter(":NUM_RAZAO", mensagem.NUM_RAZAO),
                new OracleParameter(":FLAG_SENTIDO", mensagem.FLAG_SENTIDO),
                new OracleParameter(":TIPO_MEDIC", mensagem.TIPO_MEDIC),
                new OracleParameter(":DT_MSG", mensagem.DT_MSG));



        }
    }
}
