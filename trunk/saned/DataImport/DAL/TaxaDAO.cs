using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class TaxaDAO : BaseDAO<Taxa>
    {
        public List<Taxa> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TAXA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<Taxa> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TAXA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}