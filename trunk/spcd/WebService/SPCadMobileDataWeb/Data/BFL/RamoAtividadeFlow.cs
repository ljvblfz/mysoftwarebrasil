using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.Model;
using SPCadMobileDataWeb.Data.DAL;
using GDA;


namespace SPCadMobileDataWeb.Data.BFL
{
    public class RamoAtividadeFlow
    {
        private Dao<RamoAtividade> _ramoAtividadeDAO = DaoFactory.getRamoAtividade();

        #region CRUD

        public void Insert(RamoAtividade ramoAtividade)
        {
            try
            {
                _ramoAtividadeDAO.Insert(ramoAtividade);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(RamoAtividade ramoAtividade)
        {
            try
            {
                _ramoAtividadeDAO.Delete(ramoAtividade);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(RamoAtividade ramoAtividade)
        {
            try
            {
                _ramoAtividadeDAO.Update(ramoAtividade);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        /// <summary>
        /// Retorna lista de RamoAtividade
        /// </summary>
        /// <returns></returns>
        public List<RamoAtividade> GetList()
        {
            try
            {
                return _ramoAtividadeDAO.Select();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }
        
    }
}
