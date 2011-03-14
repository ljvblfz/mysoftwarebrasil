using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class MatriculaDAO : BaseDAO<MatriculaONP>
    {
        public List<MatriculaONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
                            SELECT	
                                    L.cdc as seq_matricula, 
                                    E.codigo as seq_logradouro,
                                    L.categoria_imovel AS seq_utilizacao_ligacao, 
                                    RTRIM(LTRIM(L.NOME)) as nom_cliente,
				                    L.Numero_Imovel as val_numero_imovel,
                                    L.complemento as des_complemento,
                                    'N' AS ind_processado,
                                    G.grupo AS seq_rota,
                                    L.Sequencia as seq_leitura, 
                                    'N' as ind_impresso,
				                    NULL as des_cep,
				                    G.grupo AS seq_zona_abastecimento,
                                    NULL as val_fotos_minima,
				                    NULL as val_fotos_maxima,
				                    RIGHT ('000'+ CAST (L.setor AS varchar), 3) + L.inscricao AS des_inscricao,
                                    (CASE WHEN LTRIM(RTRIM(L.Endereco_Entrega)) <> ''
                                         THEN LTRIM(RTRIM(E.nome))+','+CAST (L.Numero_Imovel AS VARCHAR)+'  '+L.Endereco_Entrega
                                         ELSE L.Endereco_Entrega
                                    END ) AS des_endereco_alternativo
                            FROM
                                IDA_GRUPOS G, 
                                IDA_LOGRADOUROS E, 
                                IDA_LIGACOES L
                            WHERE
                            L.grupo = G.grupo
                            AND E.grupo = L.grupo
                            AND L.codigo_logradouro = E.codigo
	                        AND L.grupo =  ?Grupo
	                        AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
    }
}
