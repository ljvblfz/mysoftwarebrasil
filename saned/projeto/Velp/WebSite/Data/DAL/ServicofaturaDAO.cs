using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public  class ServicoFaturaDAO : BaseDAO<ServicoFaturaONP>
	{
        public List<ServicoFaturaONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
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

        public List<ServicoFaturaONP> Insert(
											 string des_servico,
											 string seq_plano,
											 string seq_parcela,
											 string val_parcela,
											 string ind_credito,
											 string val_diferenca_fatura,
											 string seq_matricula,
											 string seq_item_servico,
											 string cod_referencia,
											 string seq_roteiro 
   										    )
        {
            string sql = @"
                            INSERT INTO onp_servico_fatura
                                       (
											des_servico 
   											seq_plano 
   											seq_parcela 
   											val_parcela 
   											ind_credito 
   											val_diferenca_fatura 
   											seq_matricula 
   											seq_item_servico 
   											cod_referencia 
   											seq_roteiro 
   										)
							VALUES
										(
											?des_servico 
   											?seq_plano 
   											?seq_parcela 
   											?val_parcela 
   											?ind_credito 
   											?val_diferenca_fatura 
   											?seq_matricula 
   											?seq_item_servico 
   											?cod_referencia 
   											?seq_roteiro 
   										)
                         ";
            return CurrentPersistenceObject.LoadData(
													    sql
														,new GDAParameter("?des_servico",des_servico)
														,new GDAParameter("?seq_plano",seq_plano)
														,new GDAParameter("?seq_parcela",seq_parcela)
														,new GDAParameter("?val_parcela",val_parcela)
														,new GDAParameter("?ind_credito",ind_credito)
														,new GDAParameter("?val_diferenca_fatura",val_diferenca_fatura)
														,new GDAParameter("?seq_matricula",seq_matricula)
														,new GDAParameter("?seq_item_servico",seq_item_servico)
														,new GDAParameter("?cod_referencia",cod_referencia)
														,new GDAParameter("?seq_roteiro",seq_roteiro)
													 );
        }
	}
}
