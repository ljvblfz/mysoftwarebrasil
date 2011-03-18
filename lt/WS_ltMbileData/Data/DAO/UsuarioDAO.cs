using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using System.Data.SqlServerCe;
using GDA;
using LTmobileData.Data.Model;
using System.Data.OracleClient;
using WS_ltMbileData.Data;


namespace LTmobileData.Data.DAL
{
    public class UsuarioDAO
    {
        
        #region Atributos

        private ConexaoBD conexaoBD;


        #endregion

        public UsuarioDAO()
        {
            conexaoBD = ConexaoBD.Create();
        }


        public bool existeUsuario(string strUsuario, string strSenha)
        {
            int quantidade = 0;
            OracleDataReader reader = null;
            try
            {
                string strSql = "select count(*) from LTTB_FUNCIONARIOS where MATRIC_FUNC = " + strUsuario + "";

                conexaoBD.OpenConnection();
                OracleCommand cmd = conexaoBD.CreateCommand();
                cmd.CommandText = strSql;
                quantidade = int.Parse(cmd.ExecuteScalar().ToString());
                
                    if (quantidade > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
                    
            
        }

    }
}
