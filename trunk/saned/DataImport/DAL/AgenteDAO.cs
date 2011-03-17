using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class AgenteDAO : BaseDAO<Agente>
    {
        public List<Agente> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_AGENTE
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<Agente> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                --Grupo,
                                Codigo as cod_agente,
                                Nome as nom_agente,
                                Senha as des_senha
				            FROM IDA_AGENTES
                            WHERE Grupo = ?Grupo
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }

    }
}