using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class FaturaAvisoDAO : BaseDAO<FaturaAviso>
    {
        public List<FaturaAviso> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_FATURAS_AVISO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<FaturaAviso> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_FATURAS_AVISO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}