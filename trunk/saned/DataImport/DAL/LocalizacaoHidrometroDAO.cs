using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class LocalizacaoHidrometroDAO : BaseDAO<LocalizacaoHidrometro>
    {
        public List<LocalizacaoHidrometro> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_LOCALIZACAO_HIDROMETRO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<LocalizacaoHidrometro> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_LOCALIZACAO_HIDROMETRO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}