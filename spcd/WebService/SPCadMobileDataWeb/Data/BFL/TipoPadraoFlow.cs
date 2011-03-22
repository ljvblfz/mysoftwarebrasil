using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.Model;
using SPCadMobileDataWeb.Data.DAL;

namespace SPCadMobileDataWeb.Data.BFL
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

        public List<TipoPadrao> GetList()
        {
            return _tipoPadraoDAO.CurrentPersistenceObject.Select();
        }
    }
}
