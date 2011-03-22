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
                                        Left JOIN TB_OCORRENCIA OCO1 ON(OCO1.COD_OCORRC = HIS.COD_OCORRC1 )
                                        Left JOIN TB_OCORRENCIA OCO2 ON(OCO2.COD_OCORRC = HIS.COD_OCORRC2)
                                        WHERE HIS.ID_CADAST = {0} and HIS.NUM_MATRIC = {1}", cadastro, matricula);

            return _historicoConsumoDAO.CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// retorna flag de conclusão de historico consumo.
        /// </summary>
        /// <param name="cadastro"></param>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public string getFlagHistConsumo(long cadastro, long matricula)
        {
            string sql = string.Format("SELECT * FROM TB_HISTORICO_CONSUMO WHERE ID_CADAST = {0} and NUM_MATRIC = {1}", cadastro, matricula);
            HistoricoConsumo flgHistcons = _historicoConsumoDAO.CurrentPersistenceObject.LoadOneData(sql);

            if (flgHistcons == null)
            {
                return null;
            }

            return flgHistcons.FlgHistconsumo;
        }

        //public void UpdateCad(HistoricoConsumo hist)
        //{
        //    try
        //    {
        //        HistoricoConsumo historico = hist;

        //        historico.FlgHistconsumo = "2";

        //        //string expectativa = hist.ExpectativaConsu;
        //        //string suspeita = hist.Incompatibilidade;
        //        //string observConf = hist.ObsNaoConf;

        //        //validacao
        //        if (string.IsNullOrEmpty(hist.ExpectativaConsu) ||
        //           string.IsNullOrEmpty(hist.Incompatibilidade) ||
        //           string.IsNullOrEmpty(hist.ObsNaoConf)
        //            )
        //        {
        //            historico.FlgHistconsumo = "1";
        //        }

        //        historico.StatusReg = "2";

        //        SingletonFlow.cadastroFlow.UpdateCadConsumo(historico);

        //        _historicoConsumoDAO.Update(historico);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Não foi possível atualizar.");
        //    }
        //}

        public List<HistoricoConsumo> GetListNotSync()
        {
            string sql = string.Format(@"SELECT *
                                        FROM TB_HISTORICO_CONSUMO 
                                        WHERE status_reg <> 1 ");

            return _historicoConsumoDAO.CurrentPersistenceObject.LoadData(sql);
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

        public void DelHisConsExecOrFinal(Rota rota)
        {
            string sql = string.Format(@"delete from TB_HISTORICO_CONSUMO
                                        where ID_CADAST in(
                                        select hi.ID_CADAST from TB_HISTORICO_CONSUMO hi
                                        inner join TB_CADASTRO ca on(ca.ID_CADAST = hi.ID_CADAST)
                                        where ca.COD_DISTRT = {0} and 
                                        ca.NUM_SETOR = {1} and
                                        ca.COD_ROTA = {2}
                                        )", rota.CodigoDistrito, rota.Setor, rota.CodigoRota);

            _historicoConsumoDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }
        #endregion
    }
}
