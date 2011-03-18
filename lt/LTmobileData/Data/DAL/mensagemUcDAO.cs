using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using System.Data.SqlServerCe;
using GDA;

namespace LTmobileData.Data.DAL
{
    public class MensagemUcDAO : BaseDAO<mensagemUc>
    {
        string strSql;

        public void AlteraStatusMensagem(string Condicao)
        { 
           /* strSql = "DELETE FROM TB_MENSAGEM"+                     
                     " WHERE STATUS_REG = 2 AND FLAG_SENTIDO = 'C' "+Condicao+"";*/

            strSql = "DELETE FROM TB_MENSAGEM WHERE " +
                     " " + Condicao + "";
            CurrentPersistenceObject.ExecuteScalar(strSql);
        }

        public List<mensagemUc> getMensagemNotSync()
        {
            strSql = "SELECT DESC_MSG, NUM_UC, MES_ANO_FATUR, COD_LOCAL, COD_EMPRT, STATUS_REG, FLAG_SENTIDO, ID_MSG, DT_MSG, NUM_RAZAO," +
                     "TIPO_MEDIC " +
                     "FROM TB_MENSAGEM " +
                     "WHERE STATUS_REG = 2 AND FLAG_SENTIDO = 'C'";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        public List<mensagemUc> getMensagemUc(int UC)
        {
            strSql = "SELECT DESC_MSG, NUM_UC, MES_ANO_FATUR, COD_LOCAL, COD_EMPRT, STATUS_REG, FLAG_SENTIDO, ID_MSG, DT_MSG, NUM_RAZAO,"+ 
                     "TIPO_MEDIC " +
                     "FROM TB_MENSAGEM " +
                     "WHERE NUM_UC ="+UC+" AND FLAG_SENTIDO = 'R'";
            return CurrentPersistenceObject.LoadData(strSql);
        }

        public Boolean existeMensagem(int Uc)
        {
            strSql = "SELECT COUNT(*) " +
                    "FROM TB_MENSAGEM " +
                    "WHERE NUM_UC =" + Uc + " AND FLAG_SENTIDO = 'R'";
            if (CurrentPersistenceObject.LoadValues<int>(strSql)[0] > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int getIdMensagem()
        {
            int IdMensagem;

            string sql = "Select count(*) From TB_MENSAGEM";

            if (int.Parse(CurrentPersistenceObject.ExecuteScalar(sql).ToString()) < 1)
            {
                IdMensagem = 1;
            }
            else
            {
                sql = "Select MAX(ID_MSG) From TB_MENSAGEM";
                IdMensagem = int.Parse(CurrentPersistenceObject.ExecuteScalar(sql).ToString()) + 1;
            }

            //if (cod < 900000000) cod += 900000000;

            return IdMensagem;
        }

        public void DeleteTodos()
        {
            string strSql = "DELETE FROM TB_MENSAGEM";
            CurrentPersistenceObject.ExecuteCommand(strSql);
        }
    }
}
