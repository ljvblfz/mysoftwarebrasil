using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class MovimentoCategoriaDAO : BaseDAO<MovimentoCategoria>
    {
        public List<MovimentoCategoria> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MOVIMENTO_CATEGORIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<MovimentoCategoria> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MOVIMENTO_CATEGORIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}