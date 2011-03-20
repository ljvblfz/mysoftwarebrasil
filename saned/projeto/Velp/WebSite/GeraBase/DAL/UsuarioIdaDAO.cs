using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;
using GeraBase.BFL;

namespace GeraBase.DAL
{
    public class UsuarioIdaDAO : BaseDAO<UsuarioIda>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UsuarioIda> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_USUARIO
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objUsuarioIda"></param>
		public void Delete(UsuarioIda objUsuarioIda)
        {
            try
            {
                GDA.Sql.Query query = new GDA.Sql.Query(String.Format(" Codigo = {0}", objUsuarioIda.Codigo));
                this.Delete(query);
            }
            catch (Exception e)
            { }

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objUsuarioIda"></param>
        public void Update(UsuarioIda objUsuarioIda)
        {
            try
            {
                UpdateSenha(objUsuarioIda);
                string sql = @"
                                UPDATE IDA_USUARIO
                                   SET
                                         Login = ?Login
                                        ,Nome = ?Nome  
                                        --,Senha = ?Senha
                                 WHERE Codigo = ?Codigo
                              ";

                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql,
                                                                                new GDAParameter("?Codigo", objUsuarioIda.Codigo),
                                                                                new GDAParameter("?Nome", objUsuarioIda.Nome),
                                                                                //new GDAParameter("?Senha", objUsuarioIda.Senha),
                                                                                new GDAParameter("?Login", objUsuarioIda.Login)
                                                                            );
            }
            catch (Exception e)
            {
            }

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objUsuarioIda"></param>
        public bool UpdateSenha(UsuarioIda objUsuarioIda)
        {
            bool retorno = false;
            try
            {
                string sql = @"
                                UPDATE IDA_USUARIO
                                   SET
                                        Senha = ?Senha
                                 WHERE Codigo = ?Codigo
                              ";

                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql,
                                                                                new GDAParameter("?Codigo", objUsuarioIda.Codigo),
                                                                                new GDAParameter("?Senha", objUsuarioIda.Senha)); 
                if(descontoSaida>0)
                    retorno = true;
            }
            catch (Exception e)
            {
            }

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objUsuarioIda"></param>
        public void InsertUsuario(UsuarioIda objUsuarioIda)
        {
            try
            {
                string sql = @"
                                INSERT INTO IDA_USUARIO
                                       (    
                                            Nome
                                           ,Login
                                           ,Senha
                                           --,Codigo
                                        )
                                 VALUES
                                       (
                                             ?Nome  
                                            ,?Login
                                            ,?Senha
                                            --,NULL
                                        )
                              ";

                int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql,
                                                                                new GDAParameter("?Nome", objUsuarioIda.Nome),
                                                                                new GDAParameter("?Senha", UsuarioIdaFlow.CalculateMD5Hash(objUsuarioIda.Senha)),
                                                                                //new GDAParameter("?Codigo", objUsuarioIda.Codigo),
                                                                                new GDAParameter("?Login", objUsuarioIda.Login)
                                                                            );
            }
            catch (Exception e)
            {
            }

            return;
        }

        /// <summary>
        ///  Autenticação
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public bool LoginUsusario(string usuario, string senha)
        {
            string sql = @"
                            SELECT  
                                *
				            FROM IDA_USUARIO
                            WHERE 
                                Login = '" + usuario + @"'
                                AND Senha = '" + senha + @"'
                         ";
            int retorno = CurrentPersistenceObject.ExecuteSqlQueryCount(sql);
            if (retorno > 0)
                return true;
            else
                return false;
        }
    }
}