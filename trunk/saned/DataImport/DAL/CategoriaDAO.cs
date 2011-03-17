using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class CategoriaDAO : BaseDAO<Categoria>
    {
        public List<Categoria> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_CATEGORIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<Categoria> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_CATEGORIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}