using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileSync.DataADO.DAL;

namespace SPCadMobileSync.DataADO.Flow
{
    public class HistoricoConsumoFlow
    {
        static HistoricoDAL _histDAL = new HistoricoDAL();

        //insere um registro no banco
        public static void Insert(SPCadMobileSync.SPCadServices.HistoricoConsumo obj)
        {
            try
            {

                _histDAL.Insert(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //insere uma lista no banco
        public static void Insert(List<SPCadMobileSync.SPCadServices.HistoricoConsumo> lst)
        {
            try
            {
                foreach (SPCadMobileSync.SPCadServices.HistoricoConsumo item in lst)
                {
                    Insert(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public static void Delete(SPCadMobileSync.SPCadServices.HistoricoConsumo item)
        {
            _histDAL.Delete(item);
        }
    }
}
