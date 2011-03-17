using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class MovimentoTaxaDAO : BaseDAO<MovimentoTaxa>
    {
        public List<MovimentoTaxa> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MOVIMENTO_TAXA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<MovimentoTaxa> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MOVIMENTO_TAXA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}