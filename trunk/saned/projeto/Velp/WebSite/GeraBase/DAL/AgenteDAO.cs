using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public  class AgenteDAO : BaseDAO<AgenteONP>
    {
        /// <summary>
        /// Lista todos os dados
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<AgenteONP> ListaAgente(int grupo)
        {
            string sql = @"
                            SELECT DISTINCT
                                --Grupo,
                                Codigo as cod_agente,
                                Nome as nom_agente,
                                Senha as des_senha
				            FROM IDA_AGENTES
                            WHERE Grupo = ?Grupo
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo));
        }

        /// <summary>
        /// Autenticação
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public List<AgenteONP> LoginAgente(int idUsuario, string senha)
        {
            string sql = @"
                            SELECT DISTINCT
                                --Grupo,
                                Codigo as cod_agente,
                                Nome as nom_agente,
                                Senha as des_senha
				            FROM IDA_AGENTES
                            WHERE 
                                Codigo = ?Codigo
                                AND Senha = ?Senha
                         ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Codigo", idUsuario), new GDAParameter("?Senha", senha));
        }

        /// <summary>
        ///  Autenticação
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public bool LoginAgente(string usuario, string senha)
        {
            string sql = string.Format(@"
                            SELECT DISTINCT Codigo as cod_agente,
                                   Nome as nom_agente,
                                   Senha as des_senha
				            FROM IDA_AGENTES
                            WHERE Codigo = {0}
                                  AND Senha = '{1}'
                         ", usuario, senha);
            List<AgenteONP> user = CurrentPersistenceObject.LoadData(sql);
            if (user.Count > 0)
                return true;
            else
                return false;
        }
    }
}
