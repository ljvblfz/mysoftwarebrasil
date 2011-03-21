using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeraBase.DAL;
using GeraBase.Model;

namespace GeraBase.BFL
{
    public class LogSyncServerFlow
    {
        #region CRUD

        static LogSyncServerDAO _logSyncServerDAO = new LogSyncServerDAO();

        public static void Insert(LogSyncServer logSyncServer)
        {
            try
            {
                //_logSyncServerDAO.InsertOrUpdate(logSyncServer);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public static void Delete(LogSyncServer logSyncServer)
        {
            try
            {
                _logSyncServerDAO.Delete(logSyncServer);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion
    }
}
