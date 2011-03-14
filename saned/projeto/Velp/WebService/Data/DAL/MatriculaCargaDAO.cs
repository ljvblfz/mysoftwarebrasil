using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class MatriculaCargaDAO : BaseDAO<MatriculaCargaONP>
    {
        public List<MatriculaCargaONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
	                        SELECT	DISTINCT
		                        L.CDC AS seq_matricula,
                                'S' AS ind_carga,
                                'N' AS ind_descarga   
	                        FROM	
		                        IDA_LIGACOES L
	                        WHERE	
	                            L.grupo = ?Grupo
                                --AND	G.referencia = ?referencia
                                AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
		                            
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
    }
}

