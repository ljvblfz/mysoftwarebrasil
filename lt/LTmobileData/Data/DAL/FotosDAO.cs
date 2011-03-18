using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using System.Data.SqlServerCe;
using GDA;

namespace LTmobileData.Data.DAL
{
    public class FotosDAO:BaseDAO<Fotos>
    {
        /// <summary>
        /// Recupera o ultimo identificador
        /// </summary>
        /// <returns></returns>
        public uint GetLastId(int Uc, int Mes_Ano_Fatur, string TIPO_MEDIC)
        {
            uint cod;

            string sql = "Select Count(*) From LTMV_FOTO_LEITURA WHERE NUM_UC = " + Uc + " AND MES_ANO_FATUR =" + Mes_Ano_Fatur + " AND TIPO_MEDIC = '" + TIPO_MEDIC + "'";

            if (int.Parse(CurrentPersistenceObject.ExecuteScalar(sql).ToString()) < 1)
            {
                cod = 1;
            }
            else
            {
                sql = "Select Max(NUM_SEQ_FOTO) From LTMV_FOTO_LEITURA WHERE NUM_UC = " + Uc + " AND MES_ANO_FATUR =" + Mes_Ano_Fatur + " AND TIPO_MEDIC = '" + TIPO_MEDIC + "'";
                cod = uint.Parse(CurrentPersistenceObject.ExecuteScalar(sql).ToString()) + 1;
            }

            //if (cod < 900000000) cod += 900000000;

            return cod;
        }

        public void DeleteTodos()
        {
            string strSql = "DELETE FROM LTMV_FOTO_LEITURA";
            CurrentPersistenceObject.ExecuteCommand(strSql);
        }

        public int getIdFoto()
        {
            int cod;

            string sql = "Select Count(*) From LTMV_FOTO_LEITURA";

            if (int.Parse(CurrentPersistenceObject.ExecuteScalar(sql).ToString()) < 1)
            {
                cod = 1;
            }
            else
            {
                sql = "Select Max(ID_FOTO) From LTMV_FOTO_LEITURA";
                cod = int.Parse(CurrentPersistenceObject.ExecuteScalar(sql).ToString()) + 1;
            }

            //if (cod < 900000000) cod += 900000000;

            return cod;
        
        }

        public List<Fotos> getFotos(int NUM_UC, string TIPO_MEDIC)
        {
            string sql = "Select * From LTMV_FOTO_LEITURA "+
                        "WHERE NUM_UC = " + NUM_UC + " AND TIPO_MEDIC = '" + TIPO_MEDIC + "' ORDER BY NUM_SEQ_FOTO";
            return CurrentPersistenceObject.LoadData(sql);
        }

        public void AlteraStatusFoto(string Condicao)
        {
            /*string strSql = "DELETE FROM LTMV_FOTO_LEITURA" +                     
                     " WHERE STATUS_REG = 2 "+Condicao+"";*/
            string strSql = "DELETE FROM LTMV_FOTO_LEITURA WHERE "+Condicao+"";
                     
            CurrentPersistenceObject.ExecuteScalar(strSql);
        }

        public List<Fotos> getFotosNotSync()
        {
            string sql = "Select * From LTMV_FOTO_LEITURA " +
                         "WHERE STATUS_REG = 2";
            return CurrentPersistenceObject.LoadData(sql);
        }

        public int ExisteFoto(int NUM_UC, int MES_ANO_FATUR, string TIPO_MEDIC)
        {
            string sql = "SELECT COUNT(*) From LTMV_FOTO_LEITURA "+
                        "WHERE NUM_UC = " + NUM_UC + " AND MES_ANO_FATUR = " + MES_ANO_FATUR + " AND TIPO_MEDIC = '" + TIPO_MEDIC + "'";

            return int.Parse(CurrentPersistenceObject.ExecuteScalar(sql).ToString());            
        }

        public int getIdFotoUc(int MES_ANO_FATUR, string TIPO_MEDIC, int COD_LOCAL, int NUM_UC, int COD_EMPRT, int NUM_RAZAO, int NUM_SEQ_FOTO)
        {
            string strSql = "Select ID_FOTO From LTMV_FOTO_LEITURA WHERE MES_ANO_FATUR = " + MES_ANO_FATUR + " AND TIPO_MEDIC = '" + TIPO_MEDIC + "' AND COD_LOCAL = " + COD_LOCAL + " AND NUM_UC = " + NUM_UC + " AND COD_EMPRT = " + COD_EMPRT + " AND NUM_RAZAO = " + NUM_RAZAO + " AND NUM_SEQ_FOTO = " + NUM_SEQ_FOTO + "";
            return int.Parse(CurrentPersistenceObject.ExecuteScalar(strSql).ToString());
        }

        public void deletarFoto(int NUM_UC, int MES_ANO_FATUR, int COD_LOCAL, string TIPO_MEDIC, int NUM_SEQ_FOTO)
        {
            string strSql = "DELETE FROM LTMV_FOTO_LEITURA WHERE  NUM_UC=" + NUM_UC + " AND MES_ANO_FATUR=" + MES_ANO_FATUR + " AND COD_LOCAL = " + COD_LOCAL + " AND TIPO_MEDIC= '" + TIPO_MEDIC + "'  AND NUM_SEQ_FOTO=" + NUM_SEQ_FOTO + " AND TIPO_MEDIC = " + TIPO_MEDIC + "";
            CurrentPersistenceObject.ExecuteCommand(strSql);
        }
    }
}
