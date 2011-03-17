using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class AvisoDebitoDAO : BaseDAO<AvisoDebito>
    {
        public List<AvisoDebito> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_AVISO_DEBITO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<AvisoDebito> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                               SELECT DISTINCT
                                        (D.CDC)             AS seq_matricula,
                                        D.Data_Vencimento   AS dat_emissao,  
                                        D.tipo                 AS ind_documento,
                                        NULL                AS ind_pagavel,
                                        D.Qtde_Debitos      AS val_quantidade_debito,
                                        0                   AS val_impressoes,
			                            'N'                 AS ind_protocolado,
			                            NULL AS seq_fatura
                                    FROM 	IDA_DEBITOS D
			                            LEFT JOIN IDA_LIGACOES L ON L.CDC = D.CDC 
			                            LEFT JOIN IDA_GRUPOS G ON G.grupo = L.grupo 
		                            WHERE
	                                    L.Grupo = ?grupo
										AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?rotaInicial", rotaIni), new GDAParameter("?rotaFinal", rotaFim));
        }

    }
}