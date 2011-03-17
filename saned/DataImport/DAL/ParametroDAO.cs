using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class ParametroDAO : BaseDAO<Parametro>
    {
        public List<Parametro> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_PARAMETRO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<Parametro> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_PARAMETRO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}