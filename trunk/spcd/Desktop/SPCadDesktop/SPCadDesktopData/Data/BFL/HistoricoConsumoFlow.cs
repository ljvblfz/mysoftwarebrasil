using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadDesktopData.Data.DAL;
using SPCadDesktopData.Data.Model;
using GDA.Sql;

namespace SPCadDesktopData.Data.BFL
{

    public class HistoricoConsumoFlow
    {
        private Dao<HistoricoConsumo> _historicoConsumoDAO = DaoFactory.getHistoricoConsumo();


        #region CRUD

        public void Insert(HistoricoConsumo historicoConsumoDAO)
        { 
            try
            {
                _historicoConsumoDAO.Insert(historicoConsumoDAO);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(HistoricoConsumo historicoConsumoDAO)
        {
            try
            {
                _historicoConsumoDAO.Delete(historicoConsumoDAO);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(HistoricoConsumo historicoConsumoDAO)
        {
            try
            {
                _historicoConsumoDAO.Update(historicoConsumoDAO);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        /// <summary>
        /// Retorna lista de histórico consumo por cadastro/matrícula.
        /// </summary>
        /// <param name="cadastro"></param>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public List<HistoricoConsumo> getListHistoricobyCadastro(long cadastro, long matricula)
        {
            string sql = string.Format(@"SELECT HIS.*,
                                        CAD.DAT_INSTAL DataInstalacao, 
                                        CAD.EXPCTV_CONSM ExpectativaConsu,
                                        CAD.SUSPEI_FRAUDE Incompatibilidade,
                                        CAD.OBS_SUSPEI_FRAUDE ObsNaoConf,
                                        OCO1.DES_OCORRC DescOcorrencia1, 
                                        OCO2.DES_OCORRC DescOcorrencia2
                                        FROM TB_HISTORICO_CONSUMO HIS
                                        INNER JOIN TB_CADASTRO CAD ON(CAD.ID_CADAST = HIS.ID_CADAST)
                                        left JOIN TB_OCORRENCIA OCO1 ON(OCO1.COD_OCORRC = HIS.COD_OCORRC1 )
                                        left JOIN TB_OCORRENCIA OCO2 ON(OCO2.COD_OCORRC = HIS.COD_OCORRC2)
                                        WHERE HIS.ID_CADAST = {0} and HIS.NUM_MATRIC = {1}", cadastro, matricula);

            return _historicoConsumoDAO.CurrentPersistenceObject.LoadData(sql);
        }

        public void DeleteByCad(long p)
        {
            string sql = string.Format(@"delete from TB_HISTORICO_CONSUMO where ID_CADAST = {0}", p);

            _historicoConsumoDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }
    }
}
