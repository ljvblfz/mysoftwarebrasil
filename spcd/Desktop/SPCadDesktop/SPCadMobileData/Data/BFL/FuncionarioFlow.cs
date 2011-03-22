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
}
