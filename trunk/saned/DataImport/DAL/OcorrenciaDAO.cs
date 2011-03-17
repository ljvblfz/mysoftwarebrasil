using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class OcorrenciaDAO : BaseDAO<Ocorrencia>
    {
        public List<Ocorrencia> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_OCORRENCIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<Ocorrencia> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_OCORRENCIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}