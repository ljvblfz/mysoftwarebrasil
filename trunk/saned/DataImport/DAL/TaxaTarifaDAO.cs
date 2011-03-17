using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class TaxaTarifaDAO : BaseDAO<TaxaTarifa>
    {
        public List<TaxaTarifa> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TAXA_TARIFA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<TaxaTarifa> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TAXA_TARIFA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}