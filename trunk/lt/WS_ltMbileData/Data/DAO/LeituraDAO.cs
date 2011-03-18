using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace WS_ltMbileData.Data.DAO
{
    public class LeituraDAO
    {
        #region Atributos

        private ConexaoBD conexaoBD;

        #endregion

        #region Construtores

        public LeituraDAO()
        {
            conexaoBD = ConexaoBD.Create();
        }

        string strSqlUC;

        #endregion

        /// <summary>
        /// Altera o status da leitura baseado na condião recebida do PDA
        /// </summary>
        public void setLeituraConfirmada(string Usuario, string Condicao)
        {
            string strSql = "UPDATE LTDT_ORDENS_LEITURA " +
                            "SET ESTADO_EXEC = 2 " +
                            "WHERE ((ESTADO_EXEC = 1) OR (ESTADO_EXEC = 3 AND ESTADO_SERVC = 5)) AND SUBSTR(LPAD(MES_ANO_FATUR,6,'0'),3,4) || SUBSTR(LPAD(MES_ANO_FATUR,6,'0'),1,2)>=201009 AND MATRIC_FUNC = " + Usuario + " " + Condicao + "";

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

        public int getVersao(LeituraWS leitura)
        {
            int cod;

            OracleDataReader reader = null;
            try
            {

                string strSql2 ="SELECT count(*) from LTTB_Versoes_Leitura" +
                                "where COD_EMPRT = " + leitura.COD_EMPRT + " and COD_LOCAL = " + leitura.COD_LOCAL + "" +
                                "NUM_RAZAO = " + leitura.NUM_RAZAO + " and MES_ANO_FATUR = " + leitura.MES_ANO_FATUR + "" +
                                "NUM_UC = " + leitura.NUM_UC + ""; 

                conexaoBD.OpenConnection();
                OracleCommand cmd2 = conexaoBD.CreateCommand();
                cmd2.CommandText = strSql2;

                if (int.Parse(cmd2.ExecuteScalar().ToString()) == 0)
                {
                    cod = 0;
                }
                else
                {
                    string strSql = "SELECT max(Num_Versao) from LTTB_Versoes_Leitura" +
                                    "where COD_EMPRT = " + leitura.COD_EMPRT + " and COD_LOCAL = " + leitura.COD_LOCAL + "" +
                                    "NUM_RAZAO = " + leitura.NUM_RAZAO + " and MES_ANO_FATUR = " + leitura.MES_ANO_FATUR + "" +
                                    "NUM_UC = " + leitura.NUM_UC + "";

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

        public List<int> getUltimaVersao(int versao, LeituraWS leitura)
        {
            int vers = versao-1;

            List<int> lista = new List<int>();

            OracleDataReader reader = null;
            try
            {


                string strSql = "SELECT Leitur_Anter, Irrgl1_Anter, Irrgl2_Anter, Irrgl3_Anter from LTTB_Versoes_Leitura" +
                                    "where COD_EMPRT = " + leitura.COD_EMPRT + " and COD_LOCAL = " + leitura.COD_LOCAL + "" +
                                    "NUM_RAZAO = " + leitura.NUM_RAZAO + " and MES_ANO_FATUR = " + leitura.MES_ANO_FATUR + "" +
                                    "NUM_UC = " + leitura.NUM_UC + " and Num_Versao = "+vers+"";

                    conexaoBD.OpenConnection();
                    OracleCommand cmd = conexaoBD.CreateCommand();
                    cmd.CommandText = strSql;

                     reader = cmd.ExecuteReader();
                     while (reader.Read())
                     {
                         lista.Add(Convert.ToInt32(reader["Leitur_Anter"]));
                         lista.Add(Convert.ToInt32(reader["Irrgl1_Anter"]));
                         lista.Add(Convert.ToInt32(reader["Irrgl2_Anter"]));
                         lista.Add(Convert.ToInt32(reader["Irrgl3_Anter"]));
                     }
                    
            }
            finally
            {
                this.conexaoBD.CloseConection();
            }
            return lista;
        
        }



        public void setVersao(LeituraWS leitura)
        {
            int Leitur_Anter = 0;
            int Irrgl1_Anter = 0;
            int Irrgl2_Anter = 0;
            int Irrgl3_Anter = 0;

            string strSql = strSqlUC = "INSERT INTO LTTB_Versoes_Leitura(COD_EMPRT, COD_LOCAL, NUM_RAZAO, MES_ANO_FATUR, NUM_UC, TIPO_MEDIC, Num_Versao, " +
                                        "NUM_LIVRO, Leitur_Anter, Irrgl1_Anter, Irrgl2_Anter, Irrgl3_Anter, Leitur_Alter, Irrgl1_Alter, Irrgl2_Alter, "+
                                        "Irrgl3_Alter, Orig_Inform_Leitur, Versao_Devlc, Usuar_Atlz, Hora_Atlz, Matri_Func) " +
                                    "VALUES (:COD_EMPRT, :COD_LOCAL, :NUM_RAZAO, :MES_ANO_FATUR, :NUM_UC, :TIPO_MEDIC, :Num_Versao, " +
                                        ":NUM_LIVRO, :Leitur_Anter, :Irrgl1_Anter, :Irrgl2_Anter, :Irrgl3_Anter, :Leitur_Alter, :Irrgl1_Alter, :Irrgl2_Alter, " +
                                        ":Irrgl3_Alter, :Orig_Inform_Leitur, :Versao_Devlc, :Usuar_Atlz, :Hora_Atlz, :Matri_Func)";

                       
            int numVersao = getVersao(leitura);

            if(numVersao!=0)
            {
                List<int> lista = getUltimaVersao(numVersao, leitura);

                Leitur_Anter = lista[0];
                Irrgl1_Anter = lista[1];
                Irrgl2_Anter = lista[2];
                Irrgl3_Anter = lista[3];
            }

            this.conexaoBD.ExecuteNonQuery(strSql,
                new OracleParameter(":COD_EMPRT", leitura.COD_EMPRT),
                new OracleParameter(":COD_LOCAL", leitura.COD_LOCAL),
                new OracleParameter(":NUM_RAZAO", leitura.NUM_RAZAO),
                new OracleParameter(":MES_ANO_FATUR", leitura.MES_ANO_FATUR),
                new OracleParameter(":NUM_UC", leitura.NUM_UC),
                new OracleParameter(":TIPO_MEDIC", leitura.TIPO_MEDIC),
                new OracleParameter(":Num_Versao", numVersao),
                new OracleParameter(":NUM_LIVRO", leitura.NUM_LIVRO),
                new OracleParameter(":Leitur_Anter", Leitur_Anter),
                new OracleParameter(":Irrgl1_Anter", Irrgl1_Anter),
                new OracleParameter(":Irrgl2_Anter", Irrgl2_Anter),
                new OracleParameter(":Irrgl3_Anter", Irrgl3_Anter),
                new OracleParameter(":Leitur_Alter", leitura.LEITUR_VISITA),
                new OracleParameter(":Irrgl1_Alter", leitura.IRREGL_ATUAL1),
                new OracleParameter(":Irrgl2_Alter", leitura.IRREGL_ATUAL2),
                new OracleParameter(":Irrgl3_Alter", leitura.IRREGL_ATUAL3),
                new OracleParameter(":Orig_Inform_Leitur", "2"),
                new OracleParameter(":Versao_Devlc", "N"),
                new OracleParameter(":Usuar_Atlz", "VELP" ),
                new OracleParameter(":Data_Atlz", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"))),
                new OracleParameter(":Hora_Atlz", Convert.ToDateTime(DateTime.Now.ToString("HHmmss"))),
                new OracleParameter(":Matri_Func", leitura.MATRIC_FUNC));

           

        }

        public List<LeituraWS> getLeitura(string Usuario)
        {
            List<LeituraWS> lstLeitura = new List<LeituraWS>();
            OracleDataReader reader = null;            
            try
            {
                string strSql = "select OL.*, "+
                                    "(SELECT CI.COMPL_EVENT FROM LTTB_COMPL_IRREGL CI WHERE CI.COD_LOCAL = OL.COD_LOCAL AND CI.MES_ANO_FATUR = OL.MES_ANO_FATUR AND CI.NUM_RAZAO= OL.NUM_RAZAO AND CI.NUM_UC = OL.NUM_UC AND CI.TIPO_MEDIC = OL.TIPO_MEDIC AND OL.IRREGL_ATUAL1 = CI.COD_EVENT) AS COMPL_ATUAL1, "+
                                    "(SELECT CI.COMPL_EVENT FROM LTTB_COMPL_IRREGL CI WHERE CI.COD_LOCAL = OL.COD_LOCAL AND CI.MES_ANO_FATUR = OL.MES_ANO_FATUR AND CI.NUM_RAZAO= OL.NUM_RAZAO AND CI.NUM_UC = OL.NUM_UC AND CI.TIPO_MEDIC = OL.TIPO_MEDIC AND OL.IRREGL_ATUAL2 = CI.COD_EVENT) AS COMPL_ATUAL2, "+ 
                                    "(SELECT CI.COMPL_EVENT FROM LTTB_COMPL_IRREGL CI WHERE CI.COD_LOCAL = OL.COD_LOCAL AND CI.MES_ANO_FATUR = OL.MES_ANO_FATUR AND CI.NUM_RAZAO= OL.NUM_RAZAO AND CI.NUM_UC = OL.NUM_UC AND CI.TIPO_MEDIC = OL.TIPO_MEDIC AND OL.IRREGL_ATUAL3 = CI.COD_EVENT) AS COMPL_ATUAL3, "+
                                    "(SELECT UC.COORD_X FROM LTTB_UNIDADES_CONSMD UC WHERE UC.COD_LOCAL = OL.COD_LOCAL AND UC.NUM_MEDIDR = OL.NUM_MEDIDR AND UC.COD_NUM_RAZAO= OL.NUM_RAZAO AND UC.NUM_UC = OL.NUM_UC AND UC.TIPO_MEDIC = OL.TIPO_MEDIC AND UC.COD_EMPRT = OL.COD_EMPRT) AS COORD_X, "+
                                    "(SELECT UC.COORD_Y FROM LTTB_UNIDADES_CONSMD UC WHERE UC.COD_LOCAL = OL.COD_LOCAL AND UC.NUM_MEDIDR = OL.NUM_MEDIDR AND UC.COD_NUM_RAZAO= OL.NUM_RAZAO AND UC.NUM_UC = OL.NUM_UC AND UC.TIPO_MEDIC = OL.TIPO_MEDIC AND UC.COD_EMPRT = OL.COD_EMPRT) AS COORD_Y, "+
                                    "(SELECT UC.NOME_CONSMD FROM LTTB_UNIDADES_CONSMD UC WHERE UC.COD_LOCAL = OL.COD_LOCAL AND UC.NUM_MEDIDR = OL.NUM_MEDIDR AND UC.COD_NUM_RAZAO= OL.NUM_RAZAO AND UC.NUM_UC = OL.NUM_UC AND UC.TIPO_MEDIC = OL.TIPO_MEDIC AND UC.COD_EMPRT = OL.COD_EMPRT) AS NOME_CONSMD " + 
                                "FROM LTDT_ORDENS_LEITURA OL "+
                                "WHERE ((ESTADO_EXEC = 1) OR (ESTADO_EXEC = 3 AND ESTADO_SERVC = 5)) AND SUBSTR(LPAD(OL.MES_ANO_FATUR,6,'0'),3,4) || SUBSTR(LPAD(OL.MES_ANO_FATUR,6,'0'),1,2)>=201009 AND MATRIC_FUNC = " + Usuario;

                                                           
                conexaoBD.OpenConnection();
                OracleCommand cmd = conexaoBD.CreateCommand();                
                cmd.CommandText = strSql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LeituraWS leitura = new LeituraWS();
                    
                    leitura.NUM_RAZAO = Convert.ToInt32(reader["NUM_RAZAO"]);                    
                    leitura.ESTADO_SERVC = Convert.ToInt32(reader["ESTADO_SERVC"]);
                    leitura.MATRIC_FUNC = Convert.ToInt32(reader["MATRIC_FUNC"]);
                    leitura.NUM_UC = Convert.ToInt32(reader["NUM_UC"]);
                    leitura.MES_ANO_FATUR = Convert.ToInt32(reader["MES_ANO_FATUR"]);
                    leitura.COD_LOCAL = Convert.ToInt32(reader["COD_LOCAL"]);
                    leitura.COD_EMPRT = Convert.ToInt32(reader["COD_EMPRT"]);
                    leitura.TIPO_MEDIC = reader["TIPO_MEDIC"].ToString();
                    leitura.NUM_LIVRO = reader["NUM_LIVRO"].ToString();
                    leitura.SEQ_LIVRO = Convert.ToInt32(reader["SEQ_LIVRO"]);
                    //Não vai - leitura.COD_IRREGL = Convert.ToInt32(reader["COD_IRREGL"]);  
                    //leitura.COD_IRREGL = 0;
                    leitura.NUM_ROTR_OPER = Convert.ToInt32(reader["NUM_ROTR_OPER"]);
                    leitura.SEQ_ROTR_OPER = Convert.ToInt32(reader["SEQ_ROTR_OPER"]);
                    leitura.ENDER_UC = reader["ENDER_UC"].ToString();
                    leitura.COMPL_ENDER = reader["COMPL_ENDER"].ToString();
                    leitura.NUM_MEDIDR = reader["NUM_MEDIDR"].ToString();
                    leitura.LEITUR_MAX = Convert.ToInt32(reader["LEITUR_MAX"]);
                    leitura.LEITUR_MIN = Convert.ToInt32(reader["LEITUR_MIN"]);
                    leitura.LEITUR_ANTER = Convert.ToInt32(reader["LEITUR_ANTER"]);
                    leitura.SITUAC_UC = reader["SITUAC_UC"].ToString();
                    leitura.MEDIA_CONSUM = Convert.ToInt32(reader["MEDIA_CONSUM"]);
                    leitura.CONSUM_ANTER = Convert.ToInt32(reader["CONSUM_ANTER"]);
                    leitura.QTDE_LEITUR_ESTIMD = Convert.ToInt32(reader["QTDE_LEITUR_ESTIMD"]);
                    leitura.IRREGL_ANTER = Convert.ToInt32(reader["IRREGL_ANTER"]);
                    leitura.IRREGL_ATUAL1 = Convert.ToInt32(reader["IRREGL_ATUAL1"]);
                    leitura.IRREGL_ATUAL2 = Convert.ToInt32(reader["IRREGL_ATUAL2"]);
                    leitura.IRREGL_ATUAL3 = Convert.ToInt32(reader["IRREGL_ATUAL3"]);
                    leitura.DATA_IMPORT = Convert.ToDateTime(reader["DATA_IMPORT"]);
                    leitura.NOME_CONSMD = reader["NOME_CONSMD"].ToString();
                   // Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                    leitura.HORA_IMPORT = reader["HORA_IMPORT"].ToString();
                    leitura.DATA_VISITA = Convert.ToDateTime(reader["DATA_VISITA"]);
                    leitura.HORA_VISITA = reader["HORA_VISITA"].ToString();
                    leitura.USUAR_ATLZ = reader["USUAR_ATLZ"].ToString();
                    leitura.DATA_ATLZ = Convert.ToDateTime(reader["DATA_ATLZ"]);
                    leitura.HORA_ATLZ = reader["HORA_ATLZ"].ToString();
                    //leitura.FLAG_REPASSE = reader["FLAG_REPASSE"].ToString();
                   // leitura.COMPL_ATUAL1 = reader["COMPL_ATUAL1"].ToString();
                  //  leitura.COMPL_ATUAL2 = reader["COMPL_ATUAL2"].ToString();
                  //  leitura.COMPL_ATUAL3 = reader["COMPL_ATUAL3"].ToString();

                    //leitura.FLAG_REPASSE = reader["FLAG_REPASSE"].ToString(); 
                    /*leitura.COMPL_ATUAL1 = " ";
                    leitura.COMPL_ATUAL2 = " ";
                    leitura.COMPL_ATUAL3 = " ";*/

                    leitura.DATA_CALENDARIO = Convert.ToDateTime(reader["DATA_CALENDARIO"]);
                    //leitura.COORD_X = Convert.ToInt32(reader["COORD_X"]); 
                    //leitura.COORD_Y = Convert.ToInt32(reader["COORD_Y"]); 
                    // leitura.STATUS_REG = reader["STATUS_REG"].ToString(); 

                    leitura.COORD_X = reader["COORD_X"].ToString();
                    leitura.COORD_Y = reader["COORD_Y"].ToString();
                    //leitura.STATUS_REG = reader["STATUS_REG"].ToString();

                    leitura.NUM_RAZAO = Convert.ToInt32(reader["NUM_RAZAO"]);
                    leitura.FATOR_MULTIP = Convert.ToInt32(reader["FATOR_MULTIP"]);
                    leitura.QTDE_DIGIT = Convert.ToInt32(reader["QTDE_DIGIT"]);
                    leitura.FASE_MEDIDR = reader["FASE_MEDIDR"].ToString();
                    leitura.CLASSE_CONSUMO = reader["CLASSE_CONSUMO"].ToString();

                    lstLeitura.Add(leitura);



                    /*if (reader != null)
                    {
                        reader.Close();
                    }*/



                   /* string strSqlUpdate = "UPDATE LTDT_ORDENS_LEITURA OL " +
                      "SET ESTADO_EXEC = 2 " +
                      "WHERE " + leitura.COD_LOCAL + " = OL.COD_LOCAL AND " + leitura.MES_ANO_FATUR + " = OL.MES_ANO_FATUR " +
                      "AND " + leitura.NUM_RAZAO + "= OL.NUM_RAZAO AND " + leitura.NUM_UC + " = OL.NUM_UC AND '" + leitura.TIPO_MEDIC + "' = OL.TIPO_MEDIC";
                    OracleCommand cmd2 = conexaoBD.CreateCommand();
                    cmd2.CommandText = strSqlUpdate;
                    cmd2.ExecuteNonQuery();


                    Update(leitura);*/

                    
                    

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
            return lstLeitura;
        }

        public void Update(LeituraWS leitura)
        {
            /*string strSql = "UPDATE LTDT_ORDENS_LEITURA " +
            "SET MATRIC_FUNC= :MATRIC_FUNC, " +
            "NUM_ROTR_OPER= :NUM_ROTR_OPER, " +
            "SEQ_ROTR_OPER= :SEQ_ROTR_OPER, ENDER_UC= :ENDER_UC, " +
            "COMPL_ENDER= :COMPL_ENDER, NUM_MEDIDR= :NUM_MEDIDR, " +
            "LEITUR_MAX= :LEITUR_MAX, LEITUR_MIN= :LEITUR_MIN, " +
            "LEITUR_ANTER= :LEITUR_ANTER, LEITUR_VISITA= :LEITUR_VISITA, " +
            "SITUAC_UC= :SITUAC_UC, MEDIA_CONSUM= :MEDIA_CONSUM, " +
            "CONSUM_ANTER= :CONSUM_ANTER, QTDE_LEITUR_ESTIMD= :QTDE_LEITUR_ESTIMD, " +
            "IRREGL_ANTER= :IRREGL_ANTER, IRREGL_ATUAL1= :IRREGL_ATUAL1, " +
            "IRREGL_ATUAL2= :IRREGL_ATUAL2, IRREGL_ATUAL3= :IRREGL_ATUAL3, " +
            "DATA_IMPORT= :DATA_IMPORT, HORA_IMPORT= :HORA_IMPORT, " +
            "DATA_VISITA= :DATA_VISITA, HORA_VISITA= :HORA_VISITA, " +
            "USUAR_ATLZ= :USUAR_ATLZ, DATA_ATLZ= :DATA_ATLZ, " +
            "HORA_ATLZ= :HORA_ATLZ, " +            
            "DATA_CALENDARIO= :DATA_CALENDARIO, " +
            "NUM_RAZAO= :NUM_RAZAO, " +
            "FATOR_MULTIP= :FATOR_MULTIP, QTDE_DIGIT= :QTDE_DIGIT, " +
            "FASE_MEDIDR= :FASE_MEDIDR, CLASSE_CONSUMO= :CLASSE_CONSUMO, " +
            "NUM_LIVRO= :NUM_LIVRO, SEQ_LIVRO = :SEQ_LIVRO "+
            "WHERE NUM_UC= :NUM_UC AND MES_ANO_FATUR= :MES_ANO_FATUR AND " +
            "COD_LOCAL= :COD_LOCAL AND TIPO_MEDIC= :TIPO_MEDIC AND " +
            "COD_EMPRT= :COD_EMPRT";*/
 
            string strSql = "UPDATE LTDT_ORDENS_LEITURA "+  
                            "SET LEITUR_VISITA = :LEITUR_VISITA, SITUAC_UC = :SITUAC_UC, "+
                            "IRREGL_ATUAL1= :IRREGL_ATUAL1, IRREGL_ATUAL2= :IRREGL_ATUAL2, "+
                            "IRREGL_ATUAL3 = :IRREGL_ATUAL3, DATA_IMPORT = :DATA_IMPORT, "+
                            "HORA_IMPORT = :HORA_IMPORT, DATA_VISITA = :DATA_VISITA, "+
                            "HORA_VISITA = :HORA_VISITA, USUAR_ATLZ = :USUAR_ATLZ, DATA_ATLZ = :DATA_ATLZ, "+
                            "HORA_ATLZ = :HORA_ATLZ, "+
                            "ESTADO_EXEC = :ESTADO_EXEC, ESTADO_SERVC = :ESTADO_SERVC " +
                            "WHERE NUM_UC = :NUM_UC AND MES_ANO_FATUR = :MES_ANO_FATUR AND " +
                            "COD_LOCAL = :COD_LOCAL AND TIPO_MEDIC = :TIPO_MEDIC AND COD_EMPRT = :COD_EMPRT AND NUM_RAZAO = :NUM_RAZAO";

            this.conexaoBD.ExecuteNonQuery(strSql,
                new OracleParameter(":NUM_UC", leitura.NUM_UC),
                new OracleParameter(":MES_ANO_FATUR", leitura.MES_ANO_FATUR),
                new OracleParameter(":COD_LOCAL", leitura.COD_LOCAL),
                new OracleParameter(":TIPO_MEDIC", leitura.TIPO_MEDIC),
                new OracleParameter(":COD_EMPRT", leitura.COD_EMPRT),
                new OracleParameter(":NUM_RAZAO", leitura.NUM_RAZAO),                                
                new OracleParameter(":LEITUR_VISITA", leitura.LEITUR_VISITA),
                new OracleParameter(":SITUAC_UC", leitura.SITUAC_UC),                
                new OracleParameter(":IRREGL_ATUAL1", leitura.IRREGL_ATUAL1),
                new OracleParameter(":IRREGL_ATUAL2", leitura.IRREGL_ATUAL2),
                new OracleParameter(":IRREGL_ATUAL3", leitura.IRREGL_ATUAL3),
                new OracleParameter(":DATA_IMPORT", leitura.DATA_IMPORT),
                new OracleParameter(":HORA_IMPORT", leitura.HORA_IMPORT),
                new OracleParameter(":DATA_VISITA", leitura.DATA_VISITA),
                new OracleParameter(":HORA_VISITA", leitura.HORA_VISITA),
                new OracleParameter(":USUAR_ATLZ", leitura.USUAR_ATLZ),
                new OracleParameter(":DATA_ATLZ", leitura.DATA_ATLZ),
                new OracleParameter(":HORA_ATLZ", leitura.HORA_ATLZ),
                //new OracleParameter(":FLAG_REPASSE", leitura.FLAG_REPASSE),
                //new OracleParameter(":COMPL_ATUAL1", leitura.COMPL_ATUAL1),
                //new OracleParameter(":COMPL_ATUAL2", leitura.COMPL_ATUAL2),
                //new OracleParameter(":COMPL_ATUAL3", leitura.COMPL_ATUAL3),
                new OracleParameter(":ESTADO_SERVC", leitura.ESTADO_SERVC),
                new OracleParameter(":ESTADO_EXEC", 3));

            if (leitura.COORD_X != "" || leitura.COORD_Y != "")
            {
                string strSqlUC = "UPDATE LTTB_UNIDADES_CONSMD " +
                                "SET COORD_Y = :COORD_Y, COORD_X = :COORD_X " +
                                "WHERE COD_LOCAL = :COD_LOCAL AND " +
                                "COD_NUM_RAZAO = :COD_NUM_RAZAO AND NUM_UC = :NUM_UC AND TIPO_MEDIC = :TIPO_MEDIC AND COD_EMPRT = :COD_EMPRT";

                this.conexaoBD.ExecuteNonQuery(strSqlUC,
                    new OracleParameter(":COORD_Y", leitura.COORD_Y),
                    new OracleParameter(":COORD_X", leitura.COORD_X),
                    new OracleParameter(":COD_LOCAL", leitura.COD_LOCAL),                    
                    new OracleParameter(":COD_NUM_RAZAO", leitura.NUM_RAZAO),
                    new OracleParameter(":NUM_UC", leitura.NUM_UC),
                    new OracleParameter(":TIPO_MEDIC", leitura.TIPO_MEDIC),
                    new OracleParameter(":COD_EMPRT", leitura.COD_EMPRT),
                    new OracleParameter(":NUM_UC", leitura.NUM_UC));
            }

            if (leitura.COMPL_ATUAL1 != "" && leitura.COMPL_ATUAL1 != null)
            {
                try
                {
                    string SqlQuantidade = "select count (*) from LTTB_COMPL_IRREGL " +
                        "WHERE COD_LOCAL = " + leitura.COD_LOCAL + " AND MES_ANO_FATUR = " + leitura.MES_ANO_FATUR + " AND NUM_RAZAO = " + leitura.NUM_RAZAO + " AND " +
                        "NUM_UC = " + leitura.NUM_UC + " AND TIPO_MEDIC = '" + leitura.TIPO_MEDIC + "' AND COD_EVENT = " + leitura.IRREGL_ATUAL1 + "";

                    conexaoBD.OpenConnection();
                    OracleCommand cmd = conexaoBD.CreateCommand();
                    cmd.CommandText = SqlQuantidade;

                    if (int.Parse(cmd.ExecuteScalar().ToString()) == 0)
                    {
                        strSqlUC = "INSERT INTO LTTB_COMPL_IRREGL(COD_LOCAL, MES_ANO_FATUR, NUM_RAZAO, NUM_UC, TIPO_MEDIC, COD_EVENT, COMPL_EVENT) " +
                                    "VALUES (:COD_LOCAL, :MES_ANO_FATUR, :NUM_RAZAO, :NUM_UC, :TIPO_MEDIC, :IRREGL_ATUAL1, :COMPL_ATUAL1)";


                        this.conexaoBD.ExecuteNonQuery(strSqlUC,
                            new OracleParameter(":COD_LOCAL", leitura.COD_LOCAL),
                            new OracleParameter(":MES_ANO_FATUR", leitura.MES_ANO_FATUR),
                            new OracleParameter(":NUM_RAZAO", leitura.NUM_RAZAO),
                            new OracleParameter(":NUM_UC", leitura.NUM_UC),
                            new OracleParameter(":TIPO_MEDIC", leitura.TIPO_MEDIC),
                            new OracleParameter(":IRREGL_ATUAL1", leitura.IRREGL_ATUAL1),
                            new OracleParameter(":COMPL_ATUAL1", leitura.COMPL_ATUAL1));
                    }
                    else
                    {
                        strSqlUC = "UPDATE LTTB_COMPL_IRREGL SET COMPL_EVENT = :COMPL_ATUAL1 " +
                                    "WHERE COD_LOCAL = :COD_LOCAL AND MES_ANO_FATUR = :MES_ANO_FATUR AND NUM_RAZAO = :NUM_RAZAO AND NUM_UC = :NUM_UC AND TIPO_MEDIC = :TIPO_MEDIC AND COD_EVENT = :IRREGL_ATUAL1";


                        this.conexaoBD.ExecuteNonQuery(strSqlUC,
                            new OracleParameter(":COD_LOCAL", leitura.COD_LOCAL),
                            new OracleParameter(":MES_ANO_FATUR", leitura.MES_ANO_FATUR),
                            new OracleParameter(":NUM_RAZAO", leitura.NUM_RAZAO),
                            new OracleParameter(":NUM_UC", leitura.NUM_UC),
                            new OracleParameter(":TIPO_MEDIC", leitura.TIPO_MEDIC),
                            new OracleParameter(":IRREGL_ATUAL1", leitura.IRREGL_ATUAL1),
                            new OracleParameter(":COMPL_ATUAL1", leitura.COMPL_ATUAL1));
                    }
                }
                finally
                {
                    this.conexaoBD.CloseConection();
                }

                
                    

            }

            if (leitura.COMPL_ATUAL2 != "" && leitura.COMPL_ATUAL2 != null)
            {
                try
                {
                string SqlQuantidade = "select count (*) from LTTB_COMPL_IRREGL " +
                    "WHERE COD_LOCAL = " + leitura.COD_LOCAL + " AND MES_ANO_FATUR = " + leitura.MES_ANO_FATUR + " AND NUM_RAZAO = " + leitura.NUM_RAZAO + " AND " +
                    "NUM_UC = " + leitura.NUM_UC + " AND TIPO_MEDIC = '" + leitura.TIPO_MEDIC + "' AND COD_EVENT = " + leitura.IRREGL_ATUAL2 + "";               

                conexaoBD.OpenConnection();
                OracleCommand cmd2 = conexaoBD.CreateCommand();
                cmd2.CommandText = SqlQuantidade;

                if (int.Parse(cmd2.ExecuteScalar().ToString()) == 0)
                {
                    strSqlUC = "INSERT INTO LTTB_COMPL_IRREGL(COD_LOCAL, MES_ANO_FATUR, NUM_RAZAO, NUM_UC, TIPO_MEDIC, COD_EVENT, COMPL_EVENT) " +
                                "VALUES (:COD_LOCAL, :MES_ANO_FATUR, :NUM_RAZAO, :NUM_UC, :TIPO_MEDIC, :IRREGL_ATUAL2, :COMPL_ATUAL2)";


                    this.conexaoBD.ExecuteNonQuery(strSqlUC,
                        new OracleParameter(":COD_LOCAL", leitura.COD_LOCAL),
                        new OracleParameter(":MES_ANO_FATUR", leitura.MES_ANO_FATUR),
                        new OracleParameter(":NUM_RAZAO", leitura.NUM_RAZAO),
                        new OracleParameter(":NUM_UC", leitura.NUM_UC),
                        new OracleParameter(":TIPO_MEDIC", leitura.TIPO_MEDIC),
                        new OracleParameter(":IRREGL_ATUAL2", leitura.IRREGL_ATUAL2),
                        new OracleParameter(":COMPL_ATUAL2", leitura.COMPL_ATUAL2));
                }
                else
                {
                    strSqlUC = "UPDATE LTTB_COMPL_IRREGL SET COMPL_EVENT = :COMPL_ATUAL2 " +
                                "WHERE COD_LOCAL = :COD_LOCAL AND MES_ANO_FATUR = :MES_ANO_FATUR AND NUM_RAZAO = :NUM_RAZAO AND NUM_UC = :NUM_UC AND TIPO_MEDIC = :TIPO_MEDIC AND COD_EVENT = :IRREGL_ATUAL2";


                    this.conexaoBD.ExecuteNonQuery(strSqlUC,
                        new OracleParameter(":COD_LOCAL", leitura.COD_LOCAL),
                        new OracleParameter(":MES_ANO_FATUR", leitura.MES_ANO_FATUR),
                        new OracleParameter(":NUM_RAZAO", leitura.NUM_RAZAO),
                        new OracleParameter(":NUM_UC", leitura.NUM_UC),
                        new OracleParameter(":TIPO_MEDIC", leitura.TIPO_MEDIC),
                        new OracleParameter(":IRREGL_ATUAL2", leitura.IRREGL_ATUAL2),
                        new OracleParameter(":COMPL_ATUAL2", leitura.COMPL_ATUAL2));
                }


                }
                finally
                {
                    this.conexaoBD.CloseConection();
                }


            }

            if (leitura.COMPL_ATUAL3 != "" && leitura.COMPL_ATUAL3 != null)
            {
                try
                    {
                    string SqlQuantidade = "select count (*) from LTTB_COMPL_IRREGL " +
                        "WHERE COD_LOCAL = " + leitura.COD_LOCAL + " AND MES_ANO_FATUR = " + leitura.MES_ANO_FATUR + " AND NUM_RAZAO = " + leitura.NUM_RAZAO + " AND " +
                        "NUM_UC = " + leitura.NUM_UC + " AND TIPO_MEDIC = '" + leitura.TIPO_MEDIC + "' AND COD_EVENT = " + leitura.IRREGL_ATUAL3 + "";               

                    conexaoBD.OpenConnection();
                    OracleCommand cmd3 = conexaoBD.CreateCommand();
                    cmd3.CommandText = SqlQuantidade;

                    if (int.Parse(cmd3.ExecuteScalar().ToString()) == 0)
                    {
                        strSqlUC = "INSERT INTO LTTB_COMPL_IRREGL(COD_LOCAL, MES_ANO_FATUR, NUM_RAZAO, NUM_UC, TIPO_MEDIC, COD_EVENT, COMPL_EVENT) " +
                                    "VALUES (:COD_LOCAL, :MES_ANO_FATUR, :NUM_RAZAO, :NUM_UC, :TIPO_MEDIC, :IRREGL_ATUAL3, :COMPL_ATUAL3)";


                        this.conexaoBD.ExecuteNonQuery(strSqlUC,
                            new OracleParameter(":COD_LOCAL", leitura.COD_LOCAL),
                            new OracleParameter(":MES_ANO_FATUR", leitura.MES_ANO_FATUR),
                            new OracleParameter(":NUM_RAZAO", leitura.NUM_RAZAO),
                            new OracleParameter(":NUM_UC", leitura.NUM_UC),
                            new OracleParameter(":TIPO_MEDIC", leitura.TIPO_MEDIC),
                            new OracleParameter(":IRREGL_ATUAL3", leitura.IRREGL_ATUAL3),
                            new OracleParameter(":COMPL_ATUAL3", leitura.COMPL_ATUAL3));
                    }
                    else
                    {
                        strSqlUC = "UPDATE LTTB_COMPL_IRREGL SET COMPL_EVENT = :COMPL_ATUAL3 " +
                                    "WHERE COD_LOCAL = :COD_LOCAL AND MES_ANO_FATUR = :MES_ANO_FATUR AND NUM_RAZAO = :NUM_RAZAO AND NUM_UC = :NUM_UC AND TIPO_MEDIC = :TIPO_MEDIC AND COD_EVENT = :IRREGL_ATUAL3";


                        this.conexaoBD.ExecuteNonQuery(strSqlUC,
                            new OracleParameter(":COD_LOCAL", leitura.COD_LOCAL),
                            new OracleParameter(":MES_ANO_FATUR", leitura.MES_ANO_FATUR),
                            new OracleParameter(":NUM_RAZAO", leitura.NUM_RAZAO),
                            new OracleParameter(":NUM_UC", leitura.NUM_UC),
                            new OracleParameter(":TIPO_MEDIC", leitura.TIPO_MEDIC),
                            new OracleParameter(":IRREGL_ATUAL3", leitura.IRREGL_ATUAL3),
                            new OracleParameter(":COMPL_ATUAL3", leitura.COMPL_ATUAL3));
                    }


                }
                finally
                {
                    this.conexaoBD.CloseConection();
                }


            }
            
            setVersao(leitura);
        }

        public void Insert(LeituraWS leitura)
        {
            string strSql = "INSERT INTO  LTDT_ORDENS_LEITURA( NUM_UC, MES_ANO_FATUR, COD_LOCAL, TIPO_MEDIC, COD_EMPRT, MATRIC_FUNC, COD_IRREGL, NUM_ROTR_OPER, SEQ_ROTR_OPER," +
                                  "ENDER_UC, COMPL_ENDER, NUM_MEDIDR, LEITUR_MAX, LEITUR_MIN, LEITUR_ANTER, LEITUR_VISITA, SITUAC_UC, MEDIA_CONSUM, " +
                                  "CONSUM_ANTER, QTDE_LEITUR_ESTIMD, IRREGL_ANTER, IRREGL_ATUAL1, IRREGL_ATUAL2, IRREGL_ATUAL3, DATA_IMPORT, HORA_IMPORT, " +
                                  "DATA_VISITA, HORA_VISITA, USUAR_ATLZ, DATA_ATLZ, HORA_ATLZ, FLAG_REPASSE, COMPL_ATUAL1, COMPL_ATUAL2, COMPL_ATUAL3, " +
                                  "OBS_LEITURA, DATA_CALENDARIO, COORD_X, COORD_Y, STATUS_REG, NUM_RAZAO, FATOR_MULTIP, QTDE_DIGIT, FASE_MEDIDR, " +
                                  "CLASSE_CONSUMO, NUM_LIVRO, SEQ_LIVRO)" +
                             "VALUES(NUM_UC, @MES_ANO_FATUR, @COD_LOCAL, @TIPO_MEDIC, @COD_EMPRT, @MATRIC_FUNC, @COD_IRREGL, @NUM_ROTR_OPER, @SEQ_ROTR_OPER," +
                                  "@ENDER_UC, @COMPL_ENDER, @NUM_MEDIDR, @LEITUR_MAX, @LEITUR_MIN, @LEITUR_ANTER, @LEITUR_VISITA, @SITUAC_UC, @MEDIA_CONSUM, @" +
                                  "@CONSUM_ANTER, @QTDE_LEITUR_ESTIMD, @IRREGL_ANTER, @IRREGL_ATUAL1, @IRREGL_ATUAL2, @IRREGL_ATUAL3, @DATA_IMPORT, @HORA_IMPORT, @" +
                                  "@DATA_VISITA, @HORA_VISITA, @USUAR_ATLZ, @DATA_ATLZ, @HORA_ATLZ, @FLAG_REPASSE, @COMPL_ATUAL1, @COMPL_ATUAL2, @COMPL_ATUAL3, @" +
                                  "@OBS_LEITURA, @DATA_CALENDARIO, @COORD_X, @COORD_Y, @STATUS_REG, @NUM_RAZAO, @FATOR_MULTIP, @QTDE_DIGIT, @FASE_MEDIDR, @" +
                                  "@CLASSE_CONSUMO, @NUM_LIVRO, @SEQ_LIVRO)";

           /* this.conexaoBD.ExecuteNonQuery(strSql,
                new SqlParameter("NUM_UC", leitura.NUM_UC),
                new SqlParameter("MES_ANO_FATUR", leitura.MES_ANO_FATUR),
                new SqlParameter("COD_LOCAL", leitura.COD_LOCAL),
                new SqlParameter("TIPO_MEDIC", leitura.TIPO_MEDIC),
                new SqlParameter("COD_EMPRT", leitura.COD_EMPRT),
                new SqlParameter("MATRIC_FUNC", leitura.MATRIC_FUNC),
                new SqlParameter("COD_IRREGL", leitura.COD_IRREGL),
                new SqlParameter("NUM_ROTR_OPER", leitura.NUM_ROTR_OPER),
                new SqlParameter("SEQ_ROTR_OPER", leitura.SEQ_ROTR_OPER),
                new SqlParameter("ENDER_UC", leitura.ENDER_UC),
                new SqlParameter("COMPL_ENDER", leitura.COMPL_ENDER),
                new SqlParameter("NUM_MEDIDR", leitura.NUM_MEDIDR),
                new SqlParameter("LEITUR_MAX", leitura.LEITUR_MAX),
                new SqlParameter("LEITUR_MIN", leitura.LEITUR_MIN),
                new SqlParameter("LEITUR_ANTER", leitura.LEITUR_ANTER),
                new SqlParameter("LEITUR_VISITA", leitura.LEITUR_VISITA),
                new SqlParameter("SITUAC_UC", leitura.SITUAC_UC),
                new SqlParameter("MEDIA_CONSUM", leitura.MEDIA_CONSUM),
                new SqlParameter("CONSUM_ANTER", leitura.CONSUM_ANTER),
                new SqlParameter("QTDE_LEITUR_ESTIMD", leitura.QTDE_LEITUR_ESTIMD),
                new SqlParameter("IRREGL_ANTER", leitura.IRREGL_ANTER),
                new SqlParameter("IRREGL_ATUAL1", leitura.IRREGL_ATUAL1),
                new SqlParameter("IRREGL_ATUAL2", leitura.IRREGL_ATUAL2),
                new SqlParameter("IRREGL_ATUAL3", leitura.IRREGL_ATUAL3),
                new SqlParameter("DATA_IMPORT", leitura.DATA_IMPORT),
                new SqlParameter("HORA_IMPORT", leitura.HORA_IMPORT),
                new SqlParameter("DATA_VISITA", leitura.DATA_VISITA),
                new SqlParameter("HORA_VISITA", leitura.HORA_VISITA),
                new SqlParameter("USUAR_ATLZ", leitura.USUAR_ATLZ),
                new SqlParameter("DATA_ATLZ", leitura.DATA_ATLZ),
                new SqlParameter("HORA_ATLZ", leitura.HORA_ATLZ),
                new SqlParameter("FLAG_REPASSE", leitura.FLAG_REPASSE),
                new SqlParameter("COMPL_ATUAL1", leitura.COMPL_ATUAL1),
                new SqlParameter("COMPL_ATUAL2", leitura.COMPL_ATUAL2),
                new SqlParameter("COMPL_ATUAL3", leitura.COMPL_ATUAL3),                
                new SqlParameter("DATA_CALENDARIO", leitura.DATA_CALENDARIO),
                new SqlParameter("COORD_X", leitura.COORD_X),
                new SqlParameter("COORD_Y", leitura.COORD_Y),
                new SqlParameter("STATUS_REG", leitura.STATUS_REG),
                new SqlParameter("NUM_RAZAO", leitura.NUM_RAZAO),
                new SqlParameter("FATOR_MULTIP", leitura.FATOR_MULTIP),
                new SqlParameter("QTDE_DIGIT", leitura.QTDE_DIGIT),
                new SqlParameter("FASE_MEDIDR", leitura.FASE_MEDIDR),
                new SqlParameter("CLASSE_CONSUMO", leitura.CLASSE_CONSUMO),
                new SqlParameter("NUM_LIVRO", leitura.NUM_LIVRO),
                new SqlParameter("SEQ_LIVRO", leitura.SEQ_LIVRO));*/
        
        }

        public DateTime GetServerDate()
        {
            DateTime dtHoraAtual = new DateTime();
            OracleDataReader reader = null;            
            try
            {
                string strSql = "SELECT to_char(CURRENT_TIMESTAMP, 'DD-MM-YYYY HH24:MI:SS') AS agora " +
                                "FROM sys.dual";

                conexaoBD.OpenConnection();
                OracleCommand cmd = conexaoBD.CreateCommand();
                cmd.CommandText = strSql;
                dtHoraAtual = Convert.ToDateTime(cmd.ExecuteScalar().ToString());
               

            }
            finally
            {
                
                this.conexaoBD.CloseConection();
            }
            return dtHoraAtual;
        }
    }
}

