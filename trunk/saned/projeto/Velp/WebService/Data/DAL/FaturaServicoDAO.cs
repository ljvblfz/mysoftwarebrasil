using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class FaturaServicoDAO : BaseDAO<FaturaServicoONP>
    {
        public List<FaturaServicoONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
              
                                    SELECT DISTINCT
                                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura,
                                        null AS seq_item_servico,
                                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
                                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as roteiro,
                                        SV.cdc AS seq_matricula,
                                        isnull(SV.servico_01,'') AS des_servico, 
                                        1 AS seq_parcela,
                                        isnull(SV.valor_01,0) AS val_parcela,
                                        null AS ind_credito,
                                        L.rota AS seq_roteiro 
                                    FROM	
                                        IDA_GRUPOS G, 
                                        IDA_LIGACOES L, 
                                        IDA_SEGUNDAS_VIAS SV
                                    WHERE 
                                    L.cdc = SV.cdc	
                                    AND	L.grupo = SV.grupo
                                    AND	G.referencia = SV.referencia
                                    AND	L.grupo = ?Grupo
                                    --AND	G.referencia = ?referencia
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
		                            AND SV.servico_01  <> ''

                            UNION ALL

                                    SELECT  DISTINCT
                                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura,
                                        null AS seq_item_servico,
                                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
                                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as roteiro,
                                        SV.cdc AS seq_matricula,
                                        isnull(SV.servico_02,'') AS des_servico, 
                                        1 AS seq_parcela,
                                        isnull(SV.valor_02,0) AS val_parcela,
                                        null AS ind_credito,
                                        L.rota AS seq_roteiro
                                    FROM	
                                        IDA_GRUPOS G, 
                                        IDA_LIGACOES L, 
                                        IDA_SEGUNDAS_VIAS SV
                                    WHERE 
                                    L.cdc = SV.cdc	
                                    AND	L.grupo = SV.grupo
                                    AND	G.referencia = SV.referencia
                                    AND	L.grupo = ?Grupo
                                    --AND	G.referencia = ?referencia
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
		                            AND SV.servico_02  <> ''

                            UNION ALL

                                    SELECT DISTINCT 
                                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura,
                                        null AS seq_item_servico,
                                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
                                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as roteiro,
                                        SV.cdc AS seq_matricula,
                                        isnull(SV.servico_03,'') AS des_servico, 
                                        1 AS seq_parcela,
                                        isnull(SV.valor_03,0) AS val_parcela,
                                        null AS ind_credito,
                                        L.rota AS seq_roteiro
                                    FROM	
                                        IDA_GRUPOS G, 
                                        IDA_LIGACOES L, 
                                        IDA_SEGUNDAS_VIAS SV
                                    WHERE 
                                    L.cdc = SV.cdc	
                                    AND	L.grupo = SV.grupo
                                    AND	G.referencia = SV.referencia
                                    AND	L.grupo = ?Grupo
                                    --AND	G.referencia = ?referencia
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
		                            AND SV.servico_03  <> ''

                            UNION ALL

                                    SELECT DISTINCT 
                                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura,
                                        null AS seq_item_servico,
                                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
                                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as roteiro,
                                        SV.cdc AS seq_matricula,
                                        isnull(SV.servico_04,'') AS des_servico, 
                                        1 AS seq_parcela,
                                        isnull(SV.valor_04,0) AS val_parcela,
                                        null AS ind_credito,
                                        L.rota AS seq_roteiro
                                    FROM	
                                        IDA_GRUPOS G, 
                                        IDA_LIGACOES L, 
                                        IDA_SEGUNDAS_VIAS SV
                                    WHERE 
                                    L.cdc = SV.cdc	
                                    AND	L.grupo = SV.grupo
                                    AND	G.referencia = SV.referencia
                                    AND	L.grupo = ?Grupo
                                    --AND	G.referencia = ?referencia
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
		                            AND SV.servico_04  <> ''

                            UNION ALL

                                    SELECT DISTINCT 
                                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura,
                                        null AS seq_item_servico,
                                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
                                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as roteiro,
                                        SV.cdc AS seq_matricula,
                                        isnull(SV.servico_05,'') AS des_servico, 
                                        1 AS seq_parcela,
                                        isnull(SV.valor_05,0) AS val_parcela,
                                        null AS ind_credito,
                                        L.rota AS seq_roteiro
                                    FROM	
                                        IDA_GRUPOS G, 
                                        IDA_LIGACOES L, 
                                        IDA_SEGUNDAS_VIAS SV
                                    WHERE 
                                    L.cdc = SV.cdc	
                                    AND	L.grupo = SV.grupo
                                    AND	G.referencia = SV.referencia
                                    AND	L.grupo = ?Grupo
                                    --AND	G.referencia = ?referencia
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
		                            AND SV.servico_05  <> ''

                            UNION ALL

                                    SELECT DISTINCT
                                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura,
                                        null AS seq_item_servico,
                                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
                                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as roteiro,
                                        SV.cdc AS seq_matricula,
                                        isnull(SV.servico_06,'') AS des_servico, 
                                        1 AS seq_parcela,
                                        isnull(SV.valor_06,0) AS val_parcela,
                                        null AS ind_credito,
                                        L.rota AS seq_roteiro
                                    FROM	
                                        IDA_GRUPOS G, 
                                        IDA_LIGACOES L, 
                                        IDA_SEGUNDAS_VIAS SV
                                    WHERE 
                                    L.cdc = SV.cdc	
                                    AND	L.grupo = SV.grupo
                                    AND	G.referencia = SV.referencia
                                    AND	L.grupo = ?Grupo
                                    --AND	G.referencia = ?referencia
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
		                            AND SV.servico_06  <> ''

                            UNION ALL

                                    SELECT DISTINCT 
                                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura,
                                        null AS seq_item_servico,
                                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
                                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as roteiro,
                                        SV.cdc AS seq_matricula,
                                        isnull(SV.servico_07,'') AS des_servico, 
                                        1 AS seq_parcela,
                                        isnull(SV.valor_07,0) AS val_parcela,
                                        null AS ind_credito,
                                        L.rota AS seq_roteiro
                                    FROM	
                                        IDA_GRUPOS G, 
                                        IDA_LIGACOES L, 
                                        IDA_SEGUNDAS_VIAS SV
                                    WHERE 
                                    L.cdc = SV.cdc	
                                    AND	L.grupo = SV.grupo
                                    AND	G.referencia = SV.referencia
                                    AND	L.grupo = ?Grupo
                                    --AND	G.referencia = ?referencia
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
		                            AND SV.servico_07  <> ''

                            UNION ALL

                                    SELECT DISTINCT 
                                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura,
                                        null AS seq_item_servico,
                                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
                                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as roteiro,
                                        SV.cdc AS seq_matricula,
                                        isnull(SV.servico_08,'') AS des_servico, 
                                        1 AS seq_parcela,
                                        isnull(SV.valor_08,0) AS val_parcela,
                                        null AS ind_credito,
                                        L.rota AS seq_roteiro
                                    FROM	
                                        IDA_GRUPOS G, 
                                        IDA_LIGACOES L, 
                                        IDA_SEGUNDAS_VIAS SV
                                    WHERE 
                                    L.cdc = SV.cdc	
                                    AND	L.grupo = SV.grupo
                                    AND	G.referencia = SV.referencia
                                    AND	L.grupo = ?Grupo
                                    --AND	G.referencia = ?referencia
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
		                            AND SV.servico_08  <> ''

                            UNION ALL

                                    SELECT DISTINCT 
                                        CONVERT(numeric(7),G.referencia+L.cdc,102) AS seq_fatura,
                                        null AS seq_item_servico,
                                        CONVERT(char(7),SV.referencia,102) AS cod_referencia,
                                        --CONVERT(numeric, '1'+dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
                                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as roteiro,
                                        SV.cdc AS seq_matricula,
                                        isnull(SV.servico_09,'') AS des_servico, 
                                        1 AS seq_parcela,
                                        isnull(SV.valor_09,0) AS val_parcela,
                                        null AS ind_credito,
                                        L.rota AS seq_roteiro
                                    FROM	
                                        IDA_GRUPOS G, 
                                        IDA_LIGACOES L, 
                                        IDA_SEGUNDAS_VIAS SV
                                    WHERE 
                                    L.cdc = SV.cdc	
                                    AND	L.grupo = SV.grupo
                                    AND	G.referencia = SV.referencia
                                    AND	L.grupo = ?Grupo
                                    --AND	G.referencia = ?referencia
                                    AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
		                            AND SV.servico_09 <> ''

                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
    }
}
