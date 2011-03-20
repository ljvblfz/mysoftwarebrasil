using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public class LogradouroDAO : BaseDAO<LogradouroONP>
    {
        public List<LogradouroONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
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
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
    }
}
