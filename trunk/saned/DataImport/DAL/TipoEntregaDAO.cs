using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class TipoEntregaDAO : BaseDAO<TipoEntrega>
    {
        public List<TipoEntrega> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TIPO_ENTREGA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<TipoEntrega> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_TIPO_ENTREGA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}