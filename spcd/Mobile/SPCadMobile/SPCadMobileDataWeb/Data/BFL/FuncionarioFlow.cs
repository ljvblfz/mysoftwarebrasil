using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.DAL;
using SPCadMobileDataWeb.Data.Model;
using GDA;
using GDA.Sql;
using System.Security.Authentication;

namespace SPCadMobileDataWeb.Data.BFL
{
    /// <summary>
    /// Classe Funcionario Flow
    /// </summary>
    public class FuncionarioFlow
    {
        private Dao<Funcionario> _funcionarioDAO = DaoFactory.getFuncionario();

        /// <summary>
        /// Identificador do usuario logado
        /// </summary>
        private static Funcionario _usuarioCurrent;

        #region crud

        public void Insert(Funcionario funcionario)
        {
            try
            {
                _funcionarioDAO.Insert(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex); ;
            }
        }

        public void Delete(Funcionario funcionario)
        {
            try
            {
                _funcionarioDAO.Delete(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex); ;
            }
        }

        public void Update(Funcionario funcionario)
        {
            try
            {
                _funcionarioDAO.Update(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex); ;
            }
        }

        #endregion

        public DateTime GetServerDate()
        {
            return (DateTime)_funcionarioDAO.CurrentPersistenceObject.ExecuteScalar("SELECT GETDATE()");
        }

        public bool AutenticarUsuario(string strUsuario, string strSenha)
        {
            try
            {
                bool boExiste = false;
                Funcionario usuario = new Funcionario();

                List<Funcionario> lstUsuario = new Query("login=?usuario").Add("?usuario", strUsuario).ToList<Funcionario>();

                //Verifica se existe usuário, caso exista verifica a senha no formato MD5
                if (lstUsuario != null && lstUsuario.Count > 0 && lstUsuario[0].Senha.TrimEnd() == strSenha)
                {
                    boExiste = true;
                    //Configura o usuário atual no sistema.
                    setUsuario(strUsuario);
                }

                return boExiste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Configura o usuário atual do sistema
        /// </summary>
        /// <param name="strLogin">Usuario</param>
        public void setUsuario(string strLogin)
        {
            Funcionario funcionario = new Funcionario();
            
            funcionario = GetFuncionario(strLogin);

            if (funcionario != null)
            {
                _usuarioCurrent = funcionario;
            }
        }

        public Funcionario GetFuncionario(string strLogin)
        {
            string strSql = string.Format("SELECT * from tb_funcionario where login_funcn = '{0}'", strLogin);
            return _funcionarioDAO.CurrentPersistenceObject.LoadOneData(strSql);
        }

        /// <summary>
        /// Retorna lista de Funcionario
        /// </summary>
        /// <returns></returns>
        public List<Funcionario> GetList()
        {
            try
            {
                return _funcionarioDAO.Select();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }
    }    
}
