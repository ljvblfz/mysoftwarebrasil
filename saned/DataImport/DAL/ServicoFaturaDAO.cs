using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Sinc_DATA.Model;

namespace Sinc_DATA.DAL
{
    public class ServicoFaturaDAO : BaseDAO<ServicoFatura>
    {
        public List<ServicoFatura> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_SERVICO_FATURA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        public List<ServicoFatura> Importar(int grupo, int rotaInicial, int rotaFinal, DateTime referencia)
        {
            string sql = @"
                            SELECT DISTINCT
	                            L.CDC AS seq_matricula
	                            ,S.SEQUENCIA AS seq_item_servico
	                            ,CONVERT(char(7), G.referencia, 102) AS cod_referencia
	                            ,CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) AS seq_roteiro       
	                            ,S.DESCRICAO AS des_servico
	                            ,NULL AS seq_plano
	                            ,NULL AS seq_parcela 
	                            ,S.VALOR AS val_parcela
	                            ,'D' AS ind_credito
	                            ,NULL AS val_diferenca_fatura
                            FROM 
	                            IDA_LIGACOES L
	                            INNER JOIN IDA_SERVICOS S ON S.CDC = L.CDC
	                            INNER JOIN IDA_GRUPOS G ON G.Grupo = L.Grupo 
                            WHERE
	                            L.Grupo = ?Grupo
	                            AND L.Rota BETWEEN ?rotaInicial AND ?rotaFinal
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }

    }
}