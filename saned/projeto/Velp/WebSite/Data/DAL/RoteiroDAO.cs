using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class RoteiroDAO : BaseDAO<RoteiroONP>
    {

        public List<RoteiroONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
                                SELECT TOP 1	
                                    CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                    CONVERT(char(7),G.referencia,102) AS cod_referencia,
                                    G.grupo as seq_grupo_fatura,
                                    'S' AS ind_fatura,
                                    G.data_leitura AS dat_base,
                                    GETDATE()AS dat_servidor
                                FROM 	
                                    --VOLTA_ROTEIRO R,
                                    IDA_SEGUNDAS_VIAS SV,
                                    IDA_GRUPOS G,
                                    IDA_LIGACOES L
                                WHERE	
                                    G.grupo = ?Grupo
                                    --AND R.grupo = L.grupo
                                    AND L.grupo = G.grupo
                                    AND SV.grupo = G.grupo
                                    --AND	referencia = ?parReferencia
                                    AND	L.rota between ?rotaInicial AND ?rotaFinal
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
    }
}
