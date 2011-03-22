using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.Model;
using SPCadMobileDataWeb.Data.DAL;

namespace SPCadMobileDataWeb.Data.BFL
{
    public class LocalizacaoPadraoFlow
    {
        private Dao<LocalizacaoPadrao> _localizacaoPadraoDAO = DaoFactory.getLocalizacaoPadrao();

        #region CRUD

        public void Insert(LocalizacaoPadrao localizacaoPadrao)
        {
            try
            {
                _localizacaoPadraoDAO.Insert(localizacaoPadrao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(LocalizacaoPadrao localizacaoPadrao)
        {
            try
            {
                _localizacaoPadraoDAO.Delete(localizacaoPadrao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(LocalizacaoPadrao localizacaoPadrao)
        {
            try
            {
                _localizacaoPadraoDAO.Update(localizacaoPadrao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        public List<LocalizacaoPadrao> GetList()
        {
            return _localizacaoPadraoDAO.CurrentPersistenceObject.Select();
        }
    }
}
