using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class TabelasCargaDAO : BaseDAO<TabelasCarga>
    {
        public List<TabelasCarga> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TABELAS_CARGA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<TabelasCarga> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TABELAS_CARGA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}