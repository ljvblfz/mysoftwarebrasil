using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadDesktopData.Data.DAL;
using SPCadDesktopData.Data.Model;
using GDA.Sql;

namespace SPCadDesktopData.Data.BFL
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

        public void InsertOrUpdate(CondicaoImovel condicaoImovel)
        {
            try
            {
                _situacaoImovelDAO.InsertOrUpdate(condicaoImovel);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public List<CondicaoImovel> getListCondicaoImovel()
        {
            return _situacaoImovelDAO.CurrentPersistenceObject.Select();
        }

        public CondicaoImovel getCondicaoImovel(int id)
        {
            return new Query("Id = ?Id ").Add("?Id", id).First<CondicaoImovel>();
        }

        public void DeleteAll()
        {
            _situacaoImovelDAO.DeleteAll();
        }
    }
}
