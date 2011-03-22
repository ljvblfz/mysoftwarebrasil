using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.DAL;
using SPCadMobileData.Data.Model;
using GDA;
using GDA.Sql;

namespace SPCadMobileData.Data.BFL
{
    /// <summary>
    /// Classe Funcionario Flow
    /// </summary>
    public class FuncionarioFlow
    {
        private static Funcionario funcionarioLogado;

        public static Funcionario FuncionarioLogado
        {
            get { return FuncionarioFlow.funcionarioLogado; }            
        }
       

        private Dao<Funcionario> _funcionarioDAO = DaoFactory.getFuncionario();

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

        public void InsertOrUpdate(Funcionario funcionario)
        {
            try
            {
                _funcionarioDAO.InsertOrUpdate(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void InsertOrUpdateSync(Funcionario funcionario)
        {
            try
            {
                _funcionarioDAO.InsertOrUpdateSync(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        /// Validar login de usuário.
        /// </summary>
        /// <param name="login">nome de usuário</param>
        /// <param name="senha">senha</param>
        /// <returns></returns>
        public bool Autenticar(string login, string senha)
        {
            bool status = false;

            ValidacaoTela(login, senha);

            // Recupera usuário
            List<Funcionario> lstUser = new Query("LOGIN=?usuario").Add("?usuario", login).ToList<Funcionario>();

            // Verifica se existe usuário
            if (lstUser == null || lstUser.Count == 0)
            {
                throw new LoginException("Usuário não cadastrado.");
            }

            // Verifica se algum usuário possui a senha
            foreach (Funcionario func in lstUser)
            {
                if (func.Senha.Trim() == senha.Trim())
                {
                    status = true;
                    funcionarioLogado = func;
                }
            }
            if (!status)
            {
                throw new SenhaException("Senha inválida.");
            }

            return status;//retorna true se o usuario for autentica
        }

        /// <summary>
        /// Valida a interface de login
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public bool ValidacaoTela(string login, string senha)
        {
            bool status = false;

            if (string.IsNullOrEmpty(login))
            {
                throw new LoginException("Usuário deve ser informado.");
            }

            if (string.IsNullOrEmpty(senha))
            {
                throw new SenhaException("Senha deve ser informada.");
            }

            return status;
        }

        public void DeleteAll()
        {
            _funcionarioDAO.DeleteAll();
        }

        public Funcionario GetFuncionario(string strLogin)
        {
            string strSql = string.Format("SELECT * from tb_funcionario where login_funcn = '{0}'", strLogin);
            return _funcionarioDAO.CurrentPersistenceObject.LoadOneData(strSql);
        }
    }

    #region Excecões

    public class LoginException : Exception
    {
        public string msg { get; set; }

        public LoginException(Exception msg)
        {
            this.msg = msg.Message;
        }

        public LoginException(string msg)
        {
            this.msg = msg;
        }
    }

    public class SenhaException : Exception
    {
        public string msg { get; set; }

        public SenhaException(Exception msg)
        {
            this.msg = msg.Message;
        }

        public SenhaException(string msg)
        {
            this.msg = msg;
        }
    }

#endregion
}
