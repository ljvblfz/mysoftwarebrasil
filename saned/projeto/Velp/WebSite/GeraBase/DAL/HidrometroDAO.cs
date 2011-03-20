using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public class HidrometroDAO : BaseDAO<HidrometroONP>
    {
        public List<HidrometroONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
                            SELECT
                                L.medidor AS cod_hidrometro, 
                                L.cdc AS seq_matricula,
                                5 AS seq_local,	
		                        9 AS cod_marca, 
                                1 AS seq_tamanho_hidrometro, 
                                max(isnull(L.qtde_ponteiros,5)) AS val_numero_digitos, 
                                1 AS seq_diametro_ligacao, 
                        --        9 AS cod_modelo_hidrometro, 
                        --        'C' AS ind_tipo_hidrometro,
                        --        1 AS seq_capacidade_hidrometro, 
                        --        'U' AS ind_status, 
                        --        1 AS seq_composicao_numero_medidor,
                        --        2 AS ind_transmissao,
                                NULL AS dat_aquisicao, 
                                NULL AS dat_fabricacao,
                                null AS des_classe
                        	
                            FROM	
                                IDA_GRUPOS G,
                                IDA_LIGACOES L
                            WHERE	
                                L.grupo = ?Grupo
                                AND	G.grupo = L.grupo
                                AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
                                AND	LTRIM(RTRIM(isnull(L.medidor,''))) != ''

                            GROUP	by L.medidor,L.cdc,L.data_inst_hd
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
    }
}
