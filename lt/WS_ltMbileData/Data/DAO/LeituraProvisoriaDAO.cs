using System;
using System.Collections.Generic;
using System.Text;
using WS_ltMbileData.Data.Model;
using System.Data.OracleClient;

namespace WS_ltMbileData.Data.DAO
{
    public class LeituraProvisoriaDAO
    {
         #region Atributos

        private ConexaoBD conexaoBD;

        #endregion

        #region Construtores

        public LeituraProvisoriaDAO()
        {
            conexaoBD = ConexaoBD.Create();
        }

        #endregion

        public void Insert(LeituraProvisoriaWS LeituraProvisoria)
        {
            string strSql = "INSERT INTO TB_LEITURA_PROVISORIA (MES_ANO_FATUR, COD_LOCAL, "+
                            "COD_EMPRT, TIPO_MEDIC, NUM_MEDIDR, MATRIC_FUNC, NUM_UC_REF, "+
                            "NUM_RAZAO, IRREGL_ATUAL1, IRREGL_ATUAL2, IRREGL_ATUAL3, "+
                            "DATA_VISITA, HORA_VISITA, LEITUR_VISITA, COORD_X, COORD_Y, "+
                            "STATUS_REG, COMPL_ATUAL1, COMPL_ATUAL2, COMPL_ATUAL3, OBSERVACAO) "+
                            "VALUES(:MES_ANO_FATUR, :COD_LOCAL, :COD_EMPRT, :TIPO_MEDIC, "+
                            ":NUM_MEDIDR, :MATRIC_FUNC, :NUM_UC_REF, :NUM_RAZAO, "+
                            ":IRREGL_ATUAL1, :IRREGL_ATUAL2, :IRREGL_ATUAL3, :DATA_VISITA, "+
                            ":HORA_VISITA, :LEITUR_VISITA, :COORD_X, :COORD_Y, :STATUS_REG, "+
                            ":COMPL_ATUAL1, :COMPL_ATUAL2, :COMPL_ATUAL3, :OBSERVACAO)";

            this.conexaoBD.ExecuteNonQuery(strSql,
                new OracleParameter(":MES_ANO_FATUR", LeituraProvisoria.MES_ANO_FATUR),
                new OracleParameter(":COD_LOCAL", LeituraProvisoria.COD_LOCAL),
                new OracleParameter(":COD_EMPRT", LeituraProvisoria.COD_EMPRT),
                new OracleParameter(":TIPO_MEDIC", LeituraProvisoria.TIPO_MEDIC),
                new OracleParameter(":NUM_MEDIDR", LeituraProvisoria.NUM_MEDIDR),
                new OracleParameter(":MATRIC_FUNC", LeituraProvisoria.MATRIC_FUNC),
                new OracleParameter(":NUM_UC_REF", LeituraProvisoria.NUM_UC_REF),
                new OracleParameter(":NUM_RAZAO", LeituraProvisoria.NUM_RAZAO),
                new OracleParameter(":IRREGL_ATUAL1", LeituraProvisoria.IRREGL_ATUAL1),
                new OracleParameter(":IRREGL_ATUAL2", LeituraProvisoria.IRREGL_ATUAL2),
                new OracleParameter(":IRREGL_ATUAL3", LeituraProvisoria.IRREGL_ATUAL3),
                new OracleParameter(":DATA_VISITA", LeituraProvisoria.DATA_VISITA),
                new OracleParameter(":HORA_VISITA", LeituraProvisoria.HORA_VISITA),
                new OracleParameter(":LEITUR_VISITA", LeituraProvisoria.LEITUR_VISITA),
                new OracleParameter(":COORD_X", LeituraProvisoria.COORD_X),
                new OracleParameter(":COORD_Y", LeituraProvisoria.COORD_Y),
                new OracleParameter(":STATUS_REG", LeituraProvisoria.STATUS_REG),
                new OracleParameter(":COMPL_ATUAL1", LeituraProvisoria.COMPL_ATUAL1),
                new OracleParameter(":COMPL_ATUAL2", LeituraProvisoria.COMPL_ATUAL2),
                new OracleParameter(":COMPL_ATUAL3", LeituraProvisoria.COMPL_ATUAL3),
                new OracleParameter(":OBSERVACAO", LeituraProvisoria.OBSERVACAO));


        }
    }
}
