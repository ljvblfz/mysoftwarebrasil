using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.Model;
using SPCadMobileDataWeb.Data.DAL;
using CommonHelpMobile;

namespace SPCadMobileDataWeb.Data.BFL
{
    public class FotoFlow
    {
        private Dao<Foto> _fotoDAO = DaoFactory.getFoto();

        #region CRUD

        public void Insert(Foto foto)
        {
            try
            {
                _fotoDAO.Insert(foto);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(Foto foto)
        {
            try
            {
                _fotoDAO.Delete(foto);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(Foto foto)
        {
            try
            {   
                _fotoDAO.Update(foto);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        public void InsertOrUpdate(Foto item)
        {
            _fotoDAO.InsertOrUpdate(item);
        }
    }
}
