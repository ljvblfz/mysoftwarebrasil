using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.Model;
using SPCadMobileData.Data.DAL;
using GDA;
using GDA.Sql;
using CommonHelpMobile;

namespace SPCadMobileData.Data.BFL
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

        public void InsertOrUpdate(RamoAtividade ramoAtividade)
        {
            try
            {
                _ramoAtividadeDAO.InsertOrUpdate(ramoAtividade);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void InsertOrUpdateSync(RamoAtividade ramoAtividade)
        {
            try
            {
                _ramoAtividadeDAO.InsertOrUpdateSync(ramoAtividade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
        }

        public void DeleteAll()
        {
            _ramoAtividadeDAO.DeleteAll();
        }
    }
}
