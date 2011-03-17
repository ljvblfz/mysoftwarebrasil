using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class ServicoDAO : BaseDAO<Servico>
    {
        public List<Servico> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_SERVICO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<Servico> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_SERVICO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}