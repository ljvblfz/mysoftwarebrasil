using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class ParametroRetencaoDAO : BaseDAO<ParametroRetencao>
    {
        public List<ParametroRetencao> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_PARAMETRO_RETENCAO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<ParametroRetencao> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_PARAMETRO_RETENCAO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}