using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class MatriculaSCSDAO : BaseDAO<MatriculaSCS>
    {
        public List<MatriculaSCS> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MATRICULA_SCS
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<MatriculaSCS> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MATRICULA_SCS
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}