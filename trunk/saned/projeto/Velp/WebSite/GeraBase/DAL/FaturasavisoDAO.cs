using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public class FaturasAvisoDAO : BaseDAO<FaturasAvisoONP>
	{
        public List<FaturasAvisoONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
	                        SELECT DISTINCT
                                null AS seq_fatura
		                        --,SV.seq_fatura_auto AS seq_fatura
                                ,CAST(D.CDC AS NUMERIC(9,0)) AS seq_matricula
		                        ,CONVERT(char(7),D.referencia,102) AS cod_referencia
		                        ,CONVERT(DATETIME,D.referencia,102) AS dat_vencimento
		                        ,CAST(D.Valor AS NUMERIC(11,3)) AS val_valor_fatura
	                        FROM 
		                        IDA_DEBITOS_ITENS D
		                        LEFT JOIN IDA_LIGACOES L ON L.CDC = D.CDC
		                        LEFT JOIN IDA_SEGUNDAS_VIAS SV ON SV.CDC = L.CDC  AND SV.Referencia = D.Referencia
	                        WHERE 
                                L.Grupo = ?Grupo
	                            AND L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                                AND SV.seq_fatura_auto IS NOT NULL

                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
		
	}
}
