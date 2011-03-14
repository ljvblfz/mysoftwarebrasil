using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class GrupoFaturaDAO: BaseDAO<GrupoFaturaONP>
    {
        public List<GrupoFaturaONP> Lista(int grupo)
        {
            string sql = @"
                            SELECT DISTINCT
                                ?grupo AS seq_grupo_fatura
                                ,'D'   AS ind_tipo_vencimento
                                ,NULL  AS num_dias
                                ,NULL  AS des_dias_vencimento
                            FROM
                                IDA_GRUPOS

                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo));
        }
    }
}

