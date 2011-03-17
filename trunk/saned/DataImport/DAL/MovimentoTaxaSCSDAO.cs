using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class MovimentoTaxaSCSDAO : BaseDAO<MovimentoTaxaSCS>
    {
        public List<MovimentoTaxaSCS> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MOVIMENTO_TAXA_SCS
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<MovimentoTaxaSCS> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MOVIMENTO_TAXA_SCS
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}