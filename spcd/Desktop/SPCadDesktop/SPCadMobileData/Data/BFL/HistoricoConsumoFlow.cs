using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.Model;
using SPCadMobileData.Data.DAL;
using System.Data.SqlServerCe;

namespace SPCadMobileData.Data.BFL
{
    public class HistoricoConsumoFlow
    {
        #region FlowHistorico
        private Dao<HistoricoConsumo> _historicoConsumoDAO = DaoFactory.getHistoricoConsumo();

        #region CRUD

        public void Insert(HistoricoConsumo historicoConsumo)
        {
            try
            {
                historicoConsumo.StatusReg = "3";
                _historicoConsumoDAO.Insert(historicoConsumo);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(HistoricoConsumo historicoConsumo)
        {
            try
            {
                _historicoConsumoDAO.Delete(historicoConsumo);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(HistoricoConsumo historicoConsumo)
        {
            try
            {
                historicoConsumo.StatusReg = "2";
                historicoConsumo.DtMovimentacao = DateTime.Now;
                _historicoConsumoDAO.Update(historicoConsumo);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        public void InsertOrUpdate(HistoricoConsumo historicoConsumo)
        {
            try
            {
                historicoConsumo.StatusReg = "2";
                historicoConsumo.DtMovimentacao = DateTime.Now;
                _historicoConsumoDAO.InsertOrUpdate(historicoConsumo);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }



        public void InsertOrUpdateSync(HistoricoConsumo historicoConsumo)
        {
            try
            {
                _historicoConsumoDAO.InsertOrUpdateSync(historicoConsumo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
        }

       

        /// <summary>
        /// Recupera todos os registros ainda não sincronizados
        /// </summary>
        /// <returns>Lista tipada</returns>
        public void SetListNotSync(List<long> listUpdate)
        {
            _historicoConsumoDAO.SetListNotSync(listUpdate);
        }

        public void DeleteAll()
        {
            _historicoConsumoDAO.DeleteAll();
        }

        #endregion
    }
}
