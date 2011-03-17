using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class TaxaTarifaSCSDAO : BaseDAO<TaxaTarifaSCS>
    {
        public List<TaxaTarifaSCS> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TAXA_TARIFA_SCS
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<TaxaTarifaSCS> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TAXA_TARIFA_SCS
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}