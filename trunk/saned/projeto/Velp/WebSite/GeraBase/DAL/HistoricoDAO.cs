using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public class HistoricoDAO : BaseDAO<HistoricoONP>
	{
        public List<HistoricoONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
                            SELECT 
                                CAST (L.CDC AS varchar) AS seq_matricula
                                ,CONVERT(char(7), H.Referencia, 102) AS cod_referencia
                                ,CAST (H.Consumo AS varchar) AS val_consumo
                                ,CAST (H.Ocorrencia AS varchar) AS cod_ocorrencia 
                            FROM 
                                IDA_LIGACOES L
                                LEFT JOIN IDA_HISTORICOS_CONSUMO H ON  H.CDC = L.CDC  
                            WHERE 
                                L.Grupo = ?grupo
                                AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
	}
}
