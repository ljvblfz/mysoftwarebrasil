using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.DAL;
using SPCadMobileDataWeb.Data.Model;
using CommonHelpMobile;

namespace SPCadMobileDataWeb.Data.BFL
{
    public class RotaFlow
    {
        private Dao<Rota> _rotaDAO = DaoFactory.getRota();

        #region CRUD

        public void Insert(Rota rota)
        {
            try
            {
                _rotaDAO.Insert(rota);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(Rota rota)
        {
            try
            {
                _rotaDAO.Delete(rota);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(Rota rota)
        {
            try
            {
                _rotaDAO.Update(rota);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        /// <summary>
        /// Retorna lista de Rota
        /// </summary>
        /// <returns></returns>
        public List<Rota> GetList()
        {
            try
            {
                return _rotaDAO.Select();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        /// Retorna as rotas liberadas para o funcionario
        /// </summary>
        /// <returns></returns>        
        public List<Rota> GetListRotaLibQtdCad(int CodFunc, bool parcial)
        {
            string sitCarga = string.Empty;

            if (parcial)
            {
                sitCarga = "'2'";// 2 = roteiro liberado
            }
            else
            {
                sitCarga = "'2','3'";// 2 = roteiro liberado, 3 = carregado
            }

            string sql = string.Format(@"Select ro.COD_DISTRT,
                                           ro.NUM_SETOR,
                                           ro.COD_ROTA, 
                                           COUNT(ca.ID_CADAST) as QtdCad, 
                                                (SELECT COUNT(*) FROM TB_HISTORICO_CONSUMO hi
                                                    WHERE hi.ID_CADAST IN (SELECT C2.ID_CADAST FROM TB_CADASTRO C2
                                                                     WHERE C2.COD_DISTRT = RO.COD_DISTRT
                                                                       AND C2.NUM_SETOR =  RO.NUM_SETOR
                                                                       AND C2.COD_ROTA =   RO.COD_ROTA 
                                                                       AND C2.STATUS_EXEC <> '1'
                                                                    ) 
                                                 ) AS QtdHist,
                                           null as DAT_DISTRB,
                                           null as DAT_PREV,
                                           null as DAT_EXPORT,
                                           null as USU_MOVIMENTACAO,
                                           null as DT_MOVIMENTACAO,
                                           null as IP_MOVIMENTACAO                                   
                                    from TB_rota ro
                                    inner join TB_CADASTRO ca on(ca.COD_DISTRT = ro.COD_DISTRT and ca.NUM_SETOR = ro.NUM_SETOR and ca.COD_ROTA = ro.COD_ROTA)
                                    inner join TB_DISTRIBUICAO di on(di.COD_DISTRT = ro.COD_DISTRT and di.NUM_SETOR = ro.NUM_SETOR and di.COD_ROTA = ro.COD_ROTA)
                                    where di.SITUACAO_CARGA in({1}) 
                                          and ca.STATUS_EXEC in('0','2')
                                          and di.COD_FUNCN = {0}
                                    group by ro.COD_DISTRT, ro.NUM_SETOR, ro.COD_ROTA", CodFunc, sitCarga);

            return _rotaDAO.CurrentPersistenceObject.LoadData(sql);
        }

        public List<Rota> GetListRotaLiberada(int codFunc, bool parcial)
        {
            string sitCarga = string.Empty;

            if (parcial)
            {
                sitCarga = "'2'";// 2 = roteiro liberado
            }
            else
            {
                sitCarga = "'2','3'";// 2 = roteiro liberado, 3 = carregado
            }

            string sql = string.Format(@"Select ro.COD_DISTRT,ro.NUM_SETOR,ro.COD_ROTA,ro.DAT_DISTRB,ro.DAT_PREV,ro.DAT_EXPORT,ro.VERSAO,ro.USU_MOVIMENTACAO
                                       ,ro.DT_MOVIMENTACAO,ro.IP_MOVIMENTACAO
                                       from TB_rota ro
                                       inner join TB_DISTRIBUICAO di on(di.COD_DISTRT = ro.COD_DISTRT and di.NUM_SETOR = ro.NUM_SETOR and di.COD_ROTA = ro.COD_ROTA)
                                       inner join TB_FUNCIONARIO fu on(fu.COD_FUNCN = di.COD_FUNCN)
                                       where di.SITUACAO_CARGA in({1}) 
                                       and di.COD_FUNCN = {0}
                                       order by ro.COD_DISTRT, ro.NUM_SETOR, ro.COD_ROTA", codFunc, sitCarga);

            return _rotaDAO.CurrentPersistenceObject.LoadData(sql);            
        }

        //retorna rota finalizada
        public Rota GetRotasFinalizadas(Rota rota, int codFunc)
        {
            string sql = string.Format(@"select ro.* 
                                        from dbo.TB_ROTA ro
                                        inner join TB_DISTRIBUICAO di on (di.COD_DISTRT = ro.COD_DISTRT and di.NUM_SETOR = ro.NUM_SETOR and di.COD_ROTA = ro.COD_ROTA)
                                        where  
                                        di.COD_DISTRT = {0} 
                                        and di.NUM_SETOR = {1}
                                        and di.COD_ROTA = {2}
                                        and di.SITUACAO_CARGA = '5'
                                        and di.COD_FUNCN = {3}",rota.CodigoDistrito, rota.Setor, rota.CodigoRota, codFunc);

            return _rotaDAO.CurrentPersistenceObject.LoadOneData(sql);
        }
    }    
}
