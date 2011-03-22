using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.Model;
using SPCadMobileData.Data.DAL;

namespace SPCadMobileData.Data.BFL
{
    public class TipoPadraoFlow
    {
        private Dao<TipoPadrao> _tipoPadraoDAO = DaoFactory.getTipoPadrao();

        #region CRUD

        public void Insert(TipoPadrao tipoPadrao)
        {
            try
            {
                _tipoPadraoDAO.Insert(tipoPadrao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(TipoPadrao tipoPadrao)
        {
            try
            {
                _tipoPadraoDAO.Delete(tipoPadrao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(TipoPadrao tipoPadrao)
        {
            try
            {
                _tipoPadraoDAO.Update(tipoPadrao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        public void InsertOrUpdate(TipoPadrao tipoPadrao)
        {
            try
            {
                _tipoPadraoDAO.InsertOrUpdate(tipoPadrao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void InsertOrUpdateSync(TipoPadrao tipoPadrao)
        {
            try
            {
                _tipoPadraoDAO.InsertOrUpdateSync(tipoPadrao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
        }

        public List<TipoPadrao> getList()
        {
            return _tipoPadraoDAO.CurrentPersistenceObject.Select();
        }

        public void DeleteAll()
        {
            _tipoPadraoDAO.DeleteAll();
        }
    }
}
