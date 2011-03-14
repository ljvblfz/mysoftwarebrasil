using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public  class OcorrenciaDAO : BaseDAO<OcorrenciaONP>
	{
        public List<OcorrenciaONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_OCORRENCIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

	}
}
