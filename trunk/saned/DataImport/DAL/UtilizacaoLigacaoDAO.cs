using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class UtilizacaoLigacaoDAO : BaseDAO<UtilizacaoLigacao>
    {
        public List<UtilizacaoLigacao> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_UTILIZACAO_LIGACAO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<UtilizacaoLigacao> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_UTILIZACAO_LIGACAO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}