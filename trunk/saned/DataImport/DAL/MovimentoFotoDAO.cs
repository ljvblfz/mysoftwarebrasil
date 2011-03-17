using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class MovimentoFotoDAO : BaseDAO<MovimentoFoto>
    {
        public List<MovimentoFoto> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MOVIMENTO_FOTO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<MovimentoFoto> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MOVIMENTO_FOTO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}