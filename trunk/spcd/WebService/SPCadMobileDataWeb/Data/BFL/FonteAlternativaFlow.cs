using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.Model;
using SPCadMobileDataWeb.Data.DAL;


namespace SPCadMobileDataWeb.Data.BFL
{
    public class FonteAlternativaFlow
    {
        private Dao<FonteAlternativa> _fonteAlternativaDAO = DaoFactory.getFonteAlternativa();

        #region CRUD

        public void Insert(FonteAlternativa fonteAlternativa)
        {
            try
            {
                _fonteAlternativaDAO.Insert(fonteAlternativa);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(FonteAlternativa fonteAlternativa)
        {
            try
            {
                _fonteAlternativaDAO.Delete(fonteAlternativa);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(FonteAlternativa fonteAlternativa)
        {
            try
            {
                _fonteAlternativaDAO.Update(fonteAlternativa);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        public List<FonteAlternativa> GetList()
        {
            return _fonteAlternativaDAO.Select();
        }        
    }
}
