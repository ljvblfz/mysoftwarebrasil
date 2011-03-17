using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class MatriculaServicoDAO : BaseDAO<MatriculaServico>
    {
        public List<MatriculaServico> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MATRICULA_SERVICO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<MatriculaServico> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MATRICULA_SERVICO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}