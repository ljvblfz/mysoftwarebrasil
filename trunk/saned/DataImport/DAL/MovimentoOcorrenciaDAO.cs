using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class MovimentoOcorrenciaDAO : BaseDAO<MovimentoOcorrencia>
    {
        public List<MovimentoOcorrencia> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MOVIMENTO_OCORRENCIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<MovimentoOcorrencia> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_MOVIMENTO_OCORRENCIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}