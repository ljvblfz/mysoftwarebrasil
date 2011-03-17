using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class CategoriaDiademaDAO : BaseDAO<CategoriaDiadema>
    {
        public List<CategoriaDiadema> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_CATEGORIA_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<CategoriaDiadema> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_CATEGORIA_DIADEMA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}