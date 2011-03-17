using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class DescontoDiademaDAO : BaseDAO<DescontoDiadema>
    {
        public List<DescontoDiadema> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_DESCONTO_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<DescontoDiadema> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_DESCONTO_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}