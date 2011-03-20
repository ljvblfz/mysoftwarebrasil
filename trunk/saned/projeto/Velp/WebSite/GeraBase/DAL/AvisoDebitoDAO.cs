using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
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

        public List<AvisoDebito> RetornaAvisoDebito(int grupo, int rotaInicial, int rotaFinal)
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
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }

		public void Delete(AvisoDebito objAvisoDebito)
        {
            GDA.Sql.Query query = new GDA.Sql.Query(" seq_matricula = '"+ objAvisoDebito.seq_matricula+@"' AND 
             dat_emissao = '"+ objAvisoDebito.dat_emissao+@"' AND 
             ind_documento = '"+ objAvisoDebito.ind_documento+@"' AND 
             ind_pagavel = '"+ objAvisoDebito.ind_pagavel+@"' AND 
             val_quantidade_debito = '"+ objAvisoDebito.val_quantidade_debito+@"' AND 
             val_impressoes = '"+ objAvisoDebito.val_impressoes+@"' AND 
             ind_protocolado = '"+ objAvisoDebito.ind_protocolado+@"' AND 
             seq_fatura = '"+ objAvisoDebito.seq_fatura+@"'");
            this.Delete(query);
            return;
        }

        public void Update(AvisoDebito objAvisoDebito)
        {
            string sql = @"
                            INSERT ONP_AVISO_DEBITO
                               SET
                                    seq_matricula = '" + objAvisoDebito.seq_matricula + @"' , 
                                    dat_emissao = '" + objAvisoDebito.dat_emissao + @"' , 
                                    ind_documento = '" + objAvisoDebito.ind_documento + @"' , 
                                    ind_pagavel = '" + objAvisoDebito.ind_pagavel + @"' , 
                                    val_quantidade_debito = '" + objAvisoDebito.val_quantidade_debito + @"' , 
                                    val_impressoes = '" + objAvisoDebito.val_impressoes + @"' , 
                                    ind_protocolado = '" + objAvisoDebito.ind_protocolado + @"' , 
                                    seq_fatura = '" + objAvisoDebito.seq_fatura + @"'
                             WHERE 
                                    seq_matricula = '" + objAvisoDebito.seq_matricula + @"' AND 
                                    seq_fatura = '" + objAvisoDebito.seq_fatura + @"'";

            int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql);
            return;
        }

    	public void Insert(AvisoDebito objAvisoDebito)
        {
            string sql = @"
                            UPDATE ONP_AVISO_DEBITO
                               SET
                                    seq_matricula = '" + objAvisoDebito.seq_matricula + @"' , 
                                    dat_emissao = '" + objAvisoDebito.dat_emissao + @"' , 
                                    ind_documento = '" + objAvisoDebito.ind_documento + @"' , 
                                    ind_pagavel = '" + objAvisoDebito.ind_pagavel + @"' , 
                                    val_quantidade_debito = '" + objAvisoDebito.val_quantidade_debito + @"' , 
                                    val_impressoes = '" + objAvisoDebito.val_impressoes + @"' , 
                                    ind_protocolado = '" + objAvisoDebito.ind_protocolado + @"' , 
                                    seq_fatura = '" + objAvisoDebito.seq_fatura + @"'
                             WHERE 
                                seq_matricula = '" + objAvisoDebito.seq_matricula + @"' AND 
                                seq_fatura = '" + objAvisoDebito.seq_fatura + @"'";

            int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql);
            return;
        }
    }
}