using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class TaxaTarifaFaixaDAO : BaseDAO<TaxaTarifaFaixa>
    {
        public List<TaxaTarifaFaixa> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TAXA_TARIFA_FAIXA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<TaxaTarifaFaixa> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TAXA_TARIFA_FAIXA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}