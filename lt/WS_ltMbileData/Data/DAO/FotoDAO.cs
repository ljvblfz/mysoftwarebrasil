using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using System.Data.OracleClient;

namespace WS_ltMbileData.Data.DAO
{
    public class FotoDAO
    {
        #region Atributos

        private ConexaoBD conexaoBD;

        #endregion

        #region Construtores

        public FotoDAO()
        {
            conexaoBD = ConexaoBD.Create();
        }

        #endregion

        public int getLastIdFoto()
        {
            int cod;

            OracleDataReader reader = null;
            string strSqlUpdate = "";
            try
            {
                string strSql2 = "select count(*) from LTMV_FOTO_LEITURA";

                conexaoBD.OpenConnection();
                OracleCommand cmd2 = conexaoBD.CreateCommand();
                cmd2.CommandText = strSql2;
                
                if (int.Parse(cmd2.ExecuteScalar().ToString()) == 0)
                {
                    cod = 0;
                }
                else
                {
                    string strSql = "Select Max(ID_FOTO) From LTMV_FOTO_LEITURA ";

                    conexaoBD.OpenConnection();
                    OracleCommand cmd = conexaoBD.CreateCommand();
                    cmd.CommandText = strSql;

                    cod = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
                }
                

            }
            finally
            {
                this.conexaoBD.CloseConection();
            }
            return cod;
        }

        public List<FotoWS> getFoto(string Usuario)
        {
            List<FotoWS> lstFoto = new List<FotoWS>();
            OracleDataReader reader = null;
            string strSqlUpdate = "";
            try
            {
                //VERIFICAR CLAUSULA WHERE
                string strSql = "select *" +
                                " FROM LTMV_FOTO_LEITURA" +
                                " WHERE STATUS_REG = 2";


                conexaoBD.OpenConnection();
                OracleCommand cmd = conexaoBD.CreateCommand();
                cmd.CommandText = strSql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FotoWS foto = new FotoWS();

                    foto.COD_EMPRT = Convert.ToInt32(reader["COD_EMPRT"]);
                    foto.COD_LOCAL = Convert.ToInt32(reader["COD_LOCAL"]);
                    foto.CORD_X = reader["CORD_X"].ToString();
                    foto.CORD_Y = reader["CORD_Y"].ToString();
                    foto.DATA_ATLZ = Convert.ToDateTime(reader["DATA_ATLZ"]);
                    foto.DESC_FOTO = reader["DESC_FOTO"].ToString();
                    foto.HORA_ATLZ = reader["HORA_ATLZ"].ToString();
                    foto.ID_FOTO = Convert.ToInt32(reader["ID_FOTO"]);
                    foto.MES_ANO_FATUR = Convert.ToInt32(reader["MES_ANO_FATUR"]);
                    foto.NUM_MEDIDR = reader["NUM_MEDIDR"].ToString();
                    foto.NUM_RAZAO = Convert.ToInt32(reader["NUM_RAZAO"]);
                    foto.NUM_SEQ_FOTO = Convert.ToInt32(reader["NUM_SEQ_FOTO"]);
                    foto.NUM_UC = Convert.ToInt32(reader["NUM_UC"]);
                    foto.STATUS_REG = reader["STATUS_REG"].ToString();
                    foto.TIPO_MEDIC = reader["TIPO_MEDIC"].ToString();
                    foto.USUAR_ATLZ = reader["USUAR_ATLZ"].ToString();

                    lstFoto.Add(foto);

                }

                strSqlUpdate = "UPDATE LTMV_FOTO_LEITURA " +
                                "SET STATUS_REG = 1 " +
                                "WHERE STATUS_REG = 2";
                reader.Close();



                OracleCommand cmd2 = conexaoBD.CreateCommand();
                cmd2.CommandText = strSqlUpdate;
                cmd2.ExecuteNonQuery();

                this.conexaoBD.CloseConection();

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.conexaoBD.CloseConection();
            }
            return lstFoto;
        }

        public void Insert(FotoWS foto)
        { 
            string strSql ="INSERT INTO LTMV_FOTO_LEITURA(ID_FOTO, MES_ANO_FATUR, "+
                           "TIPO_MEDIC, COD_LOCAL, NUM_UC, COD_EMPRT, NUM_RAZAO, "+
                           "NUM_MEDIDR, NUM_SEQ_FOTO, DESC_FOTO, USUAR_ATLZ, DATA_ATLZ, "+
                           "HORA_ATLZ, CORD_X, CORD_Y, STATUS_REG)" + 
                           "VALUES(:ID_FOTO, :MES_ANO_FATUR, :TIPO_MEDIC, :COD_LOCAL, "+
                           ":NUM_UC, :COD_EMPRT, :NUM_RAZAO, :NUM_MEDIDR, :NUM_SEQ_FOTO, "+
                           ":DESC_FOTO, :USUAR_ATLZ, :DATA_ATLZ, :HORA_ATLZ, :CORD_X, :CORD_Y, :STATUS_REG)";

            this.conexaoBD.ExecuteNonQuery(strSql,
                new OracleParameter(":ID_FOTO", foto.ID_FOTO),
                new OracleParameter(":MES_ANO_FATUR", foto.MES_ANO_FATUR),
                new OracleParameter(":TIPO_MEDIC", foto.TIPO_MEDIC),
                new OracleParameter(":COD_LOCAL", foto.COD_LOCAL),
                new OracleParameter(":NUM_UC", foto.NUM_UC),
                new OracleParameter(":COD_EMPRT", foto.COD_EMPRT),
                new OracleParameter(":NUM_RAZAO", foto.NUM_RAZAO),
                new OracleParameter(":NUM_MEDIDR", foto.NUM_MEDIDR),
                new OracleParameter(":NUM_SEQ_FOTO", foto.NUM_SEQ_FOTO),
                new OracleParameter(":DESC_FOTO", foto.DESC_FOTO),
                new OracleParameter(":USUAR_ATLZ", foto.USUAR_ATLZ),
                new OracleParameter(":DATA_ATLZ", foto.DATA_ATLZ),
                new OracleParameter(":HORA_ATLZ", foto.HORA_ATLZ),
                new OracleParameter(":STATUS_REG", foto.STATUS_REG),
                new OracleParameter(":CORD_X", foto.CORD_X),
                new OracleParameter(":CORD_Y", foto.CORD_Y));

        
        }
    }
}
