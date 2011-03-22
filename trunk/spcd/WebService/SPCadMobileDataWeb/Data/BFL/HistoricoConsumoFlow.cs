using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileDataWeb.Data.Model;
using SPCadMobileDataWeb.Data.DAL;

namespace SPCadMobileDataWeb.Data.BFL
{
    public class HistoricoConsumoFlow
    {
        private Dao<HistoricoConsumo> _historicoConsumoDAO = DaoFactory.getHistoricoConsumo();

        #region CRUD

        public void Insert(HistoricoConsumo historicoConsumo)
        {
            try
            {
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
                _historicoConsumoDAO.Update(historicoConsumo);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion                

        /// <summary>
        /// Retorna lista de HistoricoConsumo
        /// </summary>
        /// <returns></returns>
        public List<HistoricoConsumo> GetList()
        {
            try
            {
                return _historicoConsumoDAO.Select();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public List<HistoricoConsumo> GetList(int funcionario, bool parcial, Rota rota)
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

            try
            {
                string sql = string.Format(@"Select hi.ID_HIST_CONSM,hi.ID_CADAST,hi.MES_REFER,hi.COD_OCORRC1,hi.COD_OCORRC2,hi.CRITR,hi.VOL_MEDDO
                                            ,hi.VERSAO,hi.USU_MOVIMENTACAO,hi.DT_MOVIMENTACAO,hi.IP_MOVIMENTACAO,hi.NUM_MATRIC, hi.LEITURA_FAT, hi.DAT_LEITURA_FAT
                                            from TB_HISTORICO_CONSUMO hi
                                            inner join dbo.TB_CADASTRO ca on (ca.ID_CADAST = hi.ID_CADAST)
                                            inner join TB_DISTRIBUICAO di on(di.COD_DISTRT = ca.COD_DISTRT and di.NUM_SETOR = ca.NUM_SETOR and di.COD_ROTA = ca.COD_ROTA)
                                            where 
                                            di.SITUACAO_CARGA in({1})
                                            and ca.STATUS_EXEC in('0','2')
                                            and di.COD_FUNCN = {0}
                                            and ca.COD_DISTRT = {2} 
                                            and ca.NUM_SETOR = {3}
                                            and ca.COD_ROTA = {4}
                                            order by ca.COD_DISTRT, ca.NUM_SETOR, ca.COD_ROTA", funcionario, sitCarga, rota.CodigoDistrito, rota.Setor, rota.CodigoRota);

                return _historicoConsumoDAO.CurrentPersistenceObject.LoadData(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void InsertOrUpdate(HistoricoConsumo item)
        {
            try
            {
                _historicoConsumoDAO.InsertOrUpdate(item);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }        
    }
}
