using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class FaturaImporstoDiademaDAO : BaseDAO<FaturaImporstoDiadema>
    {
        public List<FaturaImporstoDiadema> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_FATURA_IMPOSTO_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<FaturaImporstoDiadema> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_FATURA_IMPOSTO_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}