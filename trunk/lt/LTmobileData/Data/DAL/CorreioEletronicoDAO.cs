using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using System.Data.SqlServerCe;
using GDA;

namespace LTmobileData.Data.DAL
{
    public class CorreioEletronicoDAO:BaseDAO<CorreioEletronico>
    {
        string strSql;

        public void DeleteTodos()
        {
            string strSql = "DELETE FROM TB_CORREIOELETRONICO";
            CurrentPersistenceObject.ExecuteCommand(strSql);
        }

        public void DeleteMsg(int ID_MSG)
        {
            string strSql = "DELETE FROM TB_CORREIOELETRONICO WHERE ID_MSG= " + ID_MSG + "";
            CurrentPersistenceObject.ExecuteCommand(strSql);
        }

        public void AlteraStatusCorreioEletronico(string Condicao)
        {
            /*strSql = "DELETE FROM TB_CORREIOELETRONICO" +                     
                     " WHERE STATUS_REG = 2 AND TIPO_MSG = 'C' AND STATUS_MSG = 0 "+Condicao+"";*/

            strSql = "DELETE FROM TB_CORREIOELETRONICO WHERE " + Condicao + "";                     
            CurrentPersistenceObject.ExecuteScalar(strSql);
        }

        public List<CorreioEletronico> getCaixaEntrada(int matricula)
        {
            strSql = "SELECT MATRIC_FUNC, ID_MSG, ASSUNTO, DT_MSG, STATUS_MSG, DESC_MSG, COD_EMPRT, TIPO_MSG, DT_LEITURA, STATUS_REG " +
                     "FROM TB_CORREIOELETRONICO " +
                     "WHERE MATRIC_FUNC = " + matricula + " AND TIPO_MSG = 'R'";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        public List<CorreioEletronico> getCorreioEletronicoNotSync()
        {
            strSql = "SELECT MATRIC_FUNC, ID_MSG, ASSUNTO, DT_MSG, STATUS_MSG, DESC_MSG, COD_EMPRT, TIPO_MSG, DT_LEITURA, STATUS_REG " +
                     "FROM TB_CORREIOELETRONICO " +
                     "WHERE STATUS_REG = 2 AND TIPO_MSG = 'C' AND STATUS_MSG = 0";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        public List<CorreioEletronico> getCaixaSaida(int matricula)
        {
            strSql = "SELECT MATRIC_FUNC, ID_MSG, ASSUNTO, DT_MSG, STATUS_MSG, DESC_MSG, COD_EMPRT, TIPO_MSG, DT_LEITURA, STATUS_REG " +
                     "FROM TB_CORREIOELETRONICO " +
                     "WHERE MATRIC_FUNC = " + matricula + " AND TIPO_MSG = 'C'";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        public int getIdMensagem()
        {
            int cod;

            string sql = "Select Count(*) From TB_CORREIOELETRONICO";

            if (int.Parse(CurrentPersistenceObject.ExecuteScalar(sql).ToString()) < 1)
            {
                cod = 1;
            }
            else
            {
                sql = "Select Max(ID_MSG) From TB_CORREIOELETRONICO";
                cod = int.Parse(CurrentPersistenceObject.ExecuteScalar(sql).ToString()) + 1;
            }


            return cod;
        }
    }
}
