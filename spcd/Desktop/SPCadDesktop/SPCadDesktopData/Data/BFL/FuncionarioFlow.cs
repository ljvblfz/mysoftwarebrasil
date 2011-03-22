using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadDesktopData.Data.DAL;
using SPCadDesktopData.Data.Model;
using GDA;
using GDA.Sql;
using SPCadDesktopData.Data.BFL.CustomException;

namespace SPCadDesktopData.Data.BFL
{
    /// <summary>
    /// Classe Funcionario Flow
    /// </summary>
    public class FuncionarioFlow
    {
        private Dao<Funcionario> _funcionarioDAO = DaoFactory.getFuncionario();

        public static Funcionario UsuarioLogado { get; private set; }

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

        //public void InsertOrUpdateSync(Funcionario funcionario)
        //{
        //    try
        //    {
        //        _funcionarioDAO.InsertOrUpdateSync(funcionario);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, (Exception)ex);
        //    }
        //}

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
                    UsuarioLogado = func;
                    status = true;
                }
                else
                {
                    UsuarioLogado = null;
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

        public List<Funcionario> getListFuncionarioByTipo(TipoFuncionario tipo)
        {
            return new Query("Tipo = ?tipo", "Nome").Add("?tipo",(int)tipo).ToList<Funcionario>();
        }

        public List<Funcionario> getListFuncionario()
        {
            return new Query().ToList<Funcionario>();
        }

        public Funcionario GetFuncionarioById(int p)
        {
            return new Query("ID = ?id").Add("?id",p).First<Funcionario>();
        }
    }

    #region Excecões



#endregion
}
