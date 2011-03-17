using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class MatriculaAlteracaoDAO : BaseDAO<MatriculaAlteracao>
    {
        public List<MatriculaAlteracao> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MATRICULA_ALTERACAO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<MatriculaAlteracao> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MATRICULA_ALTERACAO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}