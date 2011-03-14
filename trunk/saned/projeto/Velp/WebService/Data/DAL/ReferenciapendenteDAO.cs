using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public  class ReferenciaPendenteDAO : BaseDAO<ReferenciaPendenteONP>
	{
        public List<ReferenciaPendenteONP> Lista(int grupo, int rotaInicial, int rotaFinal)
        {
            string sql = @"
                
                --            SELECT DISTINCT
				--				null AS seq_fatura
		        --                ,SV.CDC AS seq_matricula
				--				,CONVERT(DATETIME,'1974-05-06',102) AS dat_vencimento
                --            FROM IDA_DEBITOS SV
                --            LEFT JOIN IDA_LIGACOES L ON L.CDC = SV.CDC
                --            LEFT JOIN IDA_GRUPOS G ON G.Grupo = L.Grupo
                --            WHERE 
	            --                L.Grupo = ?grupo
	            --                AND L.rota BETWEEN ?rotaInicial AND ?rotaFinal
							
				--	UNION ALL
--
--                            SELECT DISTINCT
--								null AS seq_fatura
--		                        --,SV.seq_fatura_auto AS seq_fatura
--								,SV.CDC AS seq_matricula
--								,SV.Data_Vencimento AS dat_vencimento
--                            FROM IDA_DEBITOS SV
--                            LEFT JOIN IDA_LIGACOES L ON L.CDC = SV.CDC
--                            LEFT JOIN IDA_GRUPOS G ON G.Grupo = L.Grupo
--                            WHERE 
--	                            L.Grupo = ?grupo
--	                            AND L.rota BETWEEN ?rotaInicial AND ?rotaFinal
--					UNION ALL

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
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }

        public List<ReferenciaPendenteONP> Insert(
											 DateTime dat_vencimento,
											 string seq_matricula,
																						string seq_fatura 
								   										   )
        {
            string sql = @"
                            INSERT INTO onp_referencia_pendente
                                       (
																						dat_vencimento 
								   											seq_matricula 
								   											seq_fatura 
								   										)
							VALUES
										(
																						?dat_vencimento 
								   											?seq_matricula 
								   											?seq_fatura 
								   										)
                         ";
            return CurrentPersistenceObject.LoadData(
													sql
																										,new GDAParameter("?dat_vencimento",dat_vencimento)
																										,new GDAParameter("?seq_matricula",seq_matricula)
																										,new GDAParameter("?seq_fatura",seq_fatura)
																										);
        }
	}
}
