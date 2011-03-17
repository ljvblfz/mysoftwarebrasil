using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class MatriculaCargaDAO : BaseDAO<MatriculaCarga>
    {
        public List<MatriculaCarga> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MATRICULAS_CARGA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<MatriculaCarga> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MATRICULAS_CARGA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}