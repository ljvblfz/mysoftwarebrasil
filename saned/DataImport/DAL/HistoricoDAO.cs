using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class HistoricoDAO : BaseDAO<Historico>
    {
        public List<Historico> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_HISTORICO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<Historico> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_HISTORICO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}