using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class ReferenciaPendenteDAO : BaseDAO<ReferenciaPendente>
    {
        public List<ReferenciaPendente> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_REFERENCIA_PENDENTE
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<ReferenciaPendente> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
								null AS seq_fatura
		                        --,SV.seq_fatura_auto AS seq_fatura
								,SV.CDC AS seq_matricula
								,SV.Data_Vencimento AS dat_vencimento
                            FROM IDA_SEGUNDAS_VIAS SV
                            LEFT JOIN IDA_LIGACOES L ON L.CDC = SV.CDC
                            LEFT JOIN IDA_GRUPOS G ON G.Grupo = L.Grupo
                            WHERE 
	                            L.Grupo = ?grupo
	                            AND L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?rotaInicial", rotaIni), new GDAParameter("?rotaFinal", rotaFim));
        }

    }
}