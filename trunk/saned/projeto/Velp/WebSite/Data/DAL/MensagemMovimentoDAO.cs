using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class MensagemMovimentoDAO : BaseDAO<MensagemMovimentoONP>
    {
        public List<MensagemMovimentoONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            List<MensagemMovimentoONP> lista = new List<MensagemMovimentoONP>();
            string sql = @"
                             SELECT DISTINCT
                                            NULL as seq_matricula,
                                            NULL as seq_mensagem_movimento,  
                                            NULL as seq_grupo_fatura,
                                            NULL as seq_roteiro,
                                            1 as seq_tipo_documento,
                                            CONVERT(CHAR(62), LTRIM(RTRIM(M.Mensagem1))+LTRIM(RTRIM(M.Mensagem2))++LTRIM(RTRIM(M.Mensagem3)))AS des_mensagem_movimento,
                                            M.Data_Inicial as dat_inicio, 
                                            (
                                                SELECT 	
                                                    max(G.referencia)
                                                FROM	
                                                        IDA_GRUPOS G
                                             ) as dat_final
                                        FROM 	IDA_MENSAGENS M
                                        RIGHT JOIN IDA_LIGACOES L ON L.Grupo = M.Grupo 
                                        WHERE	
                                            (LTRIM(RTRIM(M.Mensagem1))+LTRIM(RTRIM(M.Mensagem2))+LTRIM(RTRIM(M.Mensagem3)) <> '')
				                            AND  (M.Mensagem1+M.Mensagem2+M.Mensagem3 is not null AND LTRIM(RTRIM(M.Mensagem1))+LTRIM(RTRIM(M.Mensagem2))+LTRIM(RTRIM(M.Mensagem3)) <> '')
                                UNION ALL

                                   SELECT DISTINCT
                                            L.CDC as seq_matricula,
                                            null as seq_mensagem_movimento,  
                                            L.Grupo as seq_grupo_fatura,
                                            CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                            1 as seq_tipo_documento,
                                            CONVERT(CHAR(62), LTRIM(RTRIM(L.Mensagem1))+LTRIM(RTRIM(L.Mensagem2)) ) AS des_mensagem_movimento, 
                                            M.Data_Inicial as dat_inicio, 
                                            (
                                                SELECT 	
                                                    max(G.referencia)
                                                FROM	
                                                        IDA_GRUPOS G
                                             ) as dat_final
                                        FROM 	IDA_MENSAGENS M
                                        RIGHT JOIN IDA_LIGACOES L ON L.Grupo = M.Grupo 
                                        WHERE	
                                            M.Grupo = ?Grupo
                                            AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                                            AND (LTRIM(RTRIM(L.Mensagem1))+LTRIM(RTRIM(L.Mensagem2)) <> '')
				                            AND  (L.Mensagem1+L.Mensagem2 is not null AND LTRIM(RTRIM(L.Mensagem1))+LTRIM(RTRIM(L.Mensagem2)) <> '')
                          ";
            lista = CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
            return lista;
        }
    }
}
