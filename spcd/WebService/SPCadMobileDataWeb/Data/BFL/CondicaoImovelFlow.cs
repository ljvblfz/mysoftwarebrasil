using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.Model;
using SPCadMobileDataWeb.Data.DAL;

namespace SPCadMobileDataWeb.Data.BFL
{
    public class CondicaoImovelFlow
    {
        private Dao<CondicaoImovel> _situacaoImovelDAO = DaoFactory.getCondicaoImovel();

        #region CRUD

        public void Insert(CondicaoImovel situacaoImovel)
        {
            try
            {
                _situacaoImovelDAO.Insert(situacaoImovel);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(CondicaoImovel situacaoImovel)
        {
            try
            {
                _situacaoImovelDAO.Delete(situacaoImovel);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(CondicaoImovel situacaoImovel)
        {
            try
            {
                _situacaoImovelDAO.Update(situacaoImovel);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        public List<CondicaoImovel> GetList()
        {
            return _situacaoImovelDAO.CurrentPersistenceObject.Select();
        }
    }
}
