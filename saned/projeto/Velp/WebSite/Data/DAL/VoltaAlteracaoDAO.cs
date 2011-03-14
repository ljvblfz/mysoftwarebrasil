using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class VoltaAlteracaoDAO : BaseDAO<VoltaAlteracao>
    {
        public List<VoltaAlteracao> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM volta_alteracao
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
    }
}