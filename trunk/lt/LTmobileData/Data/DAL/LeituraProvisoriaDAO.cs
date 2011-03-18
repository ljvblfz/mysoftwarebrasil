using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using System.Data.SqlServerCe;
using GDA;

namespace LTmobileData.Data.DAL
{
    public class LeituraProvisoriaDAO : BaseDAO<LeituraProvisoria>
    {
        public List<LeituraProvisoria> getLeituraProvisoriaNotSync()
        {

            string strSql = "SELECT COD_LOCAL, MES_ANO_FATUR, TIPO_MEDIC, NUM_MEDIDR, MATRIC_FUNC, NUM_UC_REF, IRREGL_ATUAL1, IRREGL_ATUAL2, IRREGL_ATUAL3, " +
                            "DATA_VISITA, HORA_VISITA, LEITUR_VISITA, COMPL_ATUAL1, COMPL_ATUAL2, COMPL_ATUAL3, OBSERVACAO, STATUS_REG, COORD_X, COORD_Y, " +
                            "COD_EMPRT, NUM_RAZAO " +
                            "FROM TB_LEITURA_PROVISORIA " +
                            "WHERE STATUS_REG = 2";

            return CurrentPersistenceObject.LoadData(strSql);
        }

        public void AlteraStatusLeituraProvisoria(string Condicao)
        {
            /*string strSql = "DELETE FROM TB_LEITURA_PROVISORIA " +                     
                     "WHERE STATUS_REG = 2 " + Condicao + "";*/
            string strSql = "DELETE FROM TB_LEITURA_PROVISORIA WHERE " + Condicao + "";                     
            CurrentPersistenceObject.ExecuteScalar(strSql);
        }

        public void DeleteTodos()
        {
            string strSql = "DELETE FROM TB_LEITURA_PROVISORIA";
            CurrentPersistenceObject.ExecuteCommand(strSql);
        }
    }
}
