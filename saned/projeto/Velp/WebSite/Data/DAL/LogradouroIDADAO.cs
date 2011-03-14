using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class LogradouroIDADAO : BaseDAO<LogradouroIDA>
    {
        public List<LogradouroIDA> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_LOGRADOUROS
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
    }
}