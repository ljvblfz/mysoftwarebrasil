using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPCadMobileDataWeb.Data.DAL;
using SPCadMobileDataWeb.Data.Model;

namespace SPCadMobileDataWeb.Data.BFL
{
    public class OcorrenciaFlow
    {
        private Dao<Ocorrencia> _ocorrenciaDAO = DaoFactory.getOcorrencia();

        #region CRUD

        public void Insert(Ocorrencia ocorrencia)
        {
            try
            {
                _ocorrenciaDAO.Insert(ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(Ocorrencia ocorrencia)
        {
            try
            {
                _ocorrenciaDAO.Delete(ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(Ocorrencia ocorrencia)
        {
            try
            {
                _ocorrenciaDAO.Update(ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        /// Retorna lista de ocorrência
        /// </summary>
        /// <returns></returns>
        public List<Ocorrencia> GetList()
        {
            try
            {                
                return _ocorrenciaDAO.Select();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            } 
        }      

        #endregion

    }
}
