using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class QualidadeAguaDAO : BaseDAO<QualidadeAgua>
    {
        public List<QualidadeAgua> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_QUALIDADE_AGUA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<QualidadeAgua> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_QUALIDADE_AGUA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}