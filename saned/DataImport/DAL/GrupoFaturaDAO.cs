using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class GrupoFaturaDAO : BaseDAO<GrupoFatura>
    {
        public List<GrupoFatura> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_GRUPO_FATURA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<GrupoFatura> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_GRUPO_FATURA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}