using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class ImpostoDiademaDAO : BaseDAO<ImpostoDiadema>
    {
        public List<ImpostoDiadema> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_IMPOSTO_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<ImpostoDiadema> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_IMPOSTO_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}