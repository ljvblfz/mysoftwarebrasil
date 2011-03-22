using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.DAL;
using SPCadMobileData.Data.Model;
using CommonHelpMobile;
using GDA.Sql;

namespace SPCadMobileData.Data.BFL
{
    public class CadastroFlow
    {
        private Dao<Cadastro> _cadastroDAO = DaoFactory.getCadastro();                

        #region CRUD

        public void Insert(Cadastro cadastro)
        {
            try
            {
                cadastro.StatusReg = "3";
                _cadastroDAO.Insert(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(Cadastro cadastro)
        {
            try
            {
                _cadastroDAO.Delete(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(Cadastro cadastro)
        {
            try
            {
                cadastro.StatusReg = "2";
                cadastro.DtMovimentacao = DateTime.Now;
                cadastro.DataVisita = DateTime.Now;
                _cadastroDAO.Update(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        
        public void InsertOrUpdate(Cadastro cadastro)
        {
            try
            {
                cadastro.StatusReg = "2";
                cadastro.DtMovimentacao = DateTime.Now;
                _cadastroDAO.InsertOrUpdate(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        /// inserção ou atualização na sincronização
        /// </summary>
        /// <param name="cadastro"></param>
        public void InsertOrUpdateSync(Cadastro cadastro)
        {
            try
            {
                _cadastroDAO.InsertOrUpdateSync(cadastro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
        }

        public void SetListNotSync(List<long> listUpdate)
        {
            _cadastroDAO.SetListNotSync(listUpdate);
        }

        public void DeleteAll()
        {
            _cadastroDAO.DeleteAll();
        }      
    }
}
