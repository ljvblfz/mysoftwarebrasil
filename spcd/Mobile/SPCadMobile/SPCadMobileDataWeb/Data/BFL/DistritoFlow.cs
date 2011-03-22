using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.DAL;
using SPCadMobileDataWeb.Data.Model;
using GDA;
using GDA.Sql;
using CommonHelpMobile;

namespace SPCadMobileDataWeb.Data.BFL
{
    public class DistritoFlow
    {
        private Dao<Distrito> _distritoDAO = DaoFactory.getDistrito();

        #region CRUD
        
        public void Insert(Distrito distrito)
        {
            try
            {
                _distritoDAO.Insert(distrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(Distrito distrito)
        {
            try
            {
                _distritoDAO.Delete(distrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(Distrito distrito)
        {
            try
            {
                _distritoDAO.Update(distrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion           

        /// <summary>
        /// Retorna lista de Distrito
        /// </summary>
        /// <returns></returns>
        public List<Distrito> GetList()
        {
            try
            {
                return _distritoDAO.Select();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }
    }
}
