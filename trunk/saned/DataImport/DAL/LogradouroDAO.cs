using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class LogradouroDAO : BaseDAO<Logradouro>
    {
        public List<Logradouro> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_LOGRADOURO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        public List<Logradouro> Importar(int grupo, int rotaIni, int rotaFim, DateTime referencia)
        {
            string sql = @"
                            SELECT  DISTINCT 
	                            L.codigo_logradouro as seq_logradouro,
	                            LTRIM(RTRIM(E.nome)) AS des_logradouro
                            FROM        
	                            IDA_LOGRADOUROS E, 
	                            IDA_LIGACOES L
                            WHERE	
	                            E.grupo = L.grupo
	                            AND L.codigo_logradouro = E.codigo
		                        AND L.grupo = ?grupo
                                AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaIni), new GDAParameter("?rotaFinal", rotaFim));
        }

    }
}