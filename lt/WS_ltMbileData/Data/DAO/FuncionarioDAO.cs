using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using System.Data.OracleClient;

namespace WS_ltMbileData.Data.DAO
{
    public class FuncionarioDAO
    {
        #region Atributos

        private ConexaoBD conexaoBD;

        #endregion

        #region Construtores

        public FuncionarioDAO()
        {
            conexaoBD = ConexaoBD.Create();
        }

        #endregion

        public List<FuncionariosWS> getFuncionario(string Usuario)
        {
            List<FuncionariosWS> lstFuncioanario = new List<FuncionariosWS>();
            OracleDataReader reader = null;
            string strSqlUpdate = "";
            try
            {
                string strSql = "select *" +
                                " FROM LTTB_FUNCIONARIOS" +
                                " WHERE MATRIC_FUNC = " + Usuario;


                conexaoBD.OpenConnection();
                OracleCommand cmd = conexaoBD.CreateCommand();
                cmd.CommandText = strSql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FuncionariosWS funcionario = new FuncionariosWS();

                    funcionario.COD_EMPRT = Convert.ToInt32(reader["COD_EMPRT"]);
                    funcionario.COD_LOCAL_TRAB = Convert.ToInt32(reader["COD_LOCAL_TRAB"]);
                    funcionario.MATRIC_FUNC = Convert.ToInt32(reader["MATRIC_FUNC"]);
                    funcionario.NOME_FUNC = reader["NOME_FUNC"].ToString();
                    funcionario.NUM_COLETR = Convert.ToInt32(reader["NUM_COLETR"]);
                    funcionario.SENHA_FUNC = reader["SENHA_FUNC"].ToString();
                    funcionario.SITUAC_FUNC = Convert.ToInt32(reader["SITUAC_FUNC"]);

                    lstFuncioanario.Add(funcionario);

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
            return lstFuncioanario;
        }

    }
}
