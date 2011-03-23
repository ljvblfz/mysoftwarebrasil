﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.Model;
using SPCadMobileData.Data.DAL;

namespace SPCadMobileData.Data.BFL
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

        public void InsertOrUpdate(FonteAlternativa fonteAlternativa)
        {
            try
            {
                _fonteAlternativaDAO.InsertOrUpdate(fonteAlternativa);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void InsertOrUpdateSync(FonteAlternativa fonteAlternativa)
        {
            try
            {
                _fonteAlternativaDAO.InsertOrUpdateSync(fonteAlternativa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
        }

        public List<FonteAlternativa> getListFontAltern()
        {
            return _fonteAlternativaDAO.Select();
        }

        public void DeleteAll()
        {
            _fonteAlternativaDAO.DeleteAll();
        }
    }
}