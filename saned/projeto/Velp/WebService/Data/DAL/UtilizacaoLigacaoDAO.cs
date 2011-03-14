using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class UtilizacaoLigacaoDAO : BaseDAO<UtilizacaoLigacaoONP>
    {
        public List<UtilizacaoLigacaoONP> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM ONP_UTILIZACAO_LIGACAO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        public List<UtilizacaoLigacaoONP> RetornaLista()
        {
            string sql = @"
                            SELECT 
                                   seq_categoria AS seq_utilizacao_ligacao
                                  ,des_categoria AS des_utilizacao_ligacao
                              FROM IDA_CATEGORIA
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

		public void Delete(UtilizacaoLigacaoONP objUtilizacaoLigacaoONP)
        {
            GDA.Sql.Query query = new GDA.Sql.Query(" seq_utilizacao_ligacao = "+ objUtilizacaoLigacaoONP.seq_utilizacao_ligacao+@" AND des_utilizacao_ligacao = '"+ objUtilizacaoLigacaoONP.des_utilizacao_ligacao+@"'");
            this.Delete(query);
            return;
        }

        public void Update(UtilizacaoLigacaoONP objUtilizacaoLigacaoONP)
        {
            string sql = @"
                            INSERT ONP_UTILIZACAO_LIGACAO
                               SET
                                    seq_utilizacao_ligacao = " + objUtilizacaoLigacaoONP.seq_utilizacao_ligacao + @" , 
                                    des_utilizacao_ligacao = '" + objUtilizacaoLigacaoONP.des_utilizacao_ligacao + @"'
                             WHERE seq_utilizacao_ligacao = " + objUtilizacaoLigacaoONP.seq_utilizacao_ligacao + @"";

            int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql);
            return;
        }

    	public void Insert(UtilizacaoLigacaoONP objUtilizacaoLigacaoONP)
        {
            string sql = @"
                            UPDATE ONP_UTILIZACAO_LIGACAO
                               SET
                                   seq_utilizacao_ligacao = " + objUtilizacaoLigacaoONP.seq_utilizacao_ligacao + @" , 
                                   des_utilizacao_ligacao = '" + objUtilizacaoLigacaoONP.des_utilizacao_ligacao + @"'
                             WHERE seq_utilizacao_ligacao = " + objUtilizacaoLigacaoONP.seq_utilizacao_ligacao + @"";

            int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql);
            return;
        }
    }
}