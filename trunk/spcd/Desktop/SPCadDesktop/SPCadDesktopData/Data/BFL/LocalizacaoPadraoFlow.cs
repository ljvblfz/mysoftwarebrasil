﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadDesktopData.Data.DAL;
using SPCadDesktopData.Data.Model;
using GDA.Sql;

namespace SPCadDesktopData.Data.BFL
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

        public void InsertOrUpdate(LocalizacaoPadrao localizacaoPadrao)
        {
            try
            {
                _localizacaoPadraoDAO.InsertOrUpdate(localizacaoPadrao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public List<LocalizacaoPadrao> getList()
        {
            return _localizacaoPadraoDAO.CurrentPersistenceObject.Select();
        }

        public LocalizacaoPadrao getLocalizacaoPadrao(int id)
        {
            return new Query("Id = ?Id ").Add("?Id", id).First<LocalizacaoPadrao>();
        }

        public void DeleteAll()
        {
            _localizacaoPadraoDAO.DeleteAll();
        }
    }
}