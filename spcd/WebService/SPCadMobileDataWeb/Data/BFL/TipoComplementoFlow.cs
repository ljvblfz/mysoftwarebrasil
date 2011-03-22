using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.Model;
using SPCadMobileDataWeb.Data.DAL;

namespace SPCadMobileDataWeb.Data.BFL
{
    public class TipoComplementoFlow
    {
        private Dao<TipoComplemento> _tipoComplementoDAO = DaoFactory.getTipoComplemento();

        #region CRUD

        public void Insert(TipoComplemento tipoComplemento)
        {
            try
            {
                _tipoComplementoDAO.Insert(tipoComplemento);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(TipoComplemento tipoComplemento)
        {
            try
            {
                _tipoComplementoDAO.Delete(tipoComplemento);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(TipoComplemento tipoComplemento)
        {
            try
            {
                _tipoComplementoDAO.Update(tipoComplemento);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        /// <summary>
        /// Retorna uma lista de TipoComplemento.
        /// </summary>
        /// <returns></returns>
        public List<TipoComplemento> GetList()
        {
            return _tipoComplementoDAO.CurrentPersistenceObject.Select();
        }
    }
}
