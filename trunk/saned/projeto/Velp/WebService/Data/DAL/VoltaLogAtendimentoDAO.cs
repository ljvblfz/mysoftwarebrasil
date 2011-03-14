using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class VoltaLogAtendimentoDAO : BaseDAO<VoltaLogAtendimento>
    {
        public List<VoltaLogAtendimento> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM volta_log_atendimento
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
    }
}