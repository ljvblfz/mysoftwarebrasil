using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class RoteiroDAO : BaseDAO<Roteiro>
    {
        public List<Roteiro> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_ROTEIRO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<Roteiro> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_ROTEIRO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}