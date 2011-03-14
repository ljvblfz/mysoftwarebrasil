using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DeviceProject.DATA.dataSaned.Model;
using DeviceProject.DATA.dataSaned.Dao;

namespace DeviceProject.DATA.dataSaned.Flow
{
    /// <summary>
    ///  Classe Flow da model logSync
    /// </summary>
    public class LogSyncFlow
    {
        /// <summary>
        ///  Objeto DAO
        /// </summary>
        public static LogSyncDao _logSyncDao = new LogSyncDao();

        #region

        /// <summary>
        ///  Insere os dados na tabela 
        /// </summary>
        /// <param name="logSync">LogSync ,Model contendo os dados</param>
        public static void Insert(LogSync logSync)
        {
            try
            {
                if (logSync.Matricula < 1)
                {
                    throw new Exception();
                }

                logSync.DataSync = DateTime.Now;

                _logSyncDao.Insert(logSync);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        /// Deleta os dados
        /// </summary>
        /// <param name="logSync">objeto model</param>
        public static void Delete(LogSync logSync)
        {
            try
            {
                _logSyncDao.Delete(logSync);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        /// Deleta todos os dados da tabela
        /// </summary>
        public static void DeleteAll()
        {
            try
            {
                _logSyncDao.DeleteAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        //retorna uma string com todas as matriculas da log
        /// <summary>
        /// Lista dados
        /// </summary>
        public static string GetListMatricula()
        {
            try
            {
                string matriculaList = "";

                List<LogSync> listLog = _logSyncDao.Select();

                foreach (LogSync item in listLog)
                {                    
                    matriculaList += item.Matricula + ",";
                }

                //remove a virgula do final.
                if (matriculaList.Length > 0)
                {
                    matriculaList = matriculaList.Remove(matriculaList.Length - 1, 1);
                }

                return matriculaList;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion
    }
}
