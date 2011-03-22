using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadDesktopData.Data.DAL;
using SPCadDesktopData.Data.Model;
using CommonHelpDesktop;
using SPCadDesktopData.Data.BFL.CustomException;

namespace SPCadDesktopData.Data.BFL
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

        public void InsertOrUpdate(Rota rota)
        {
            try
            {
                _rotaDAO.InsertOrUpdate(rota);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }


        /// <summary>
        /// Retorna lista de setores por distrito
        /// </summary>
        /// <param name="idDistrito"></param>
        /// <returns></returns>
        public List<ItemCombo> getListSetorByDistrito(int idDistrito)
        {
            List<ItemCombo> lst = new List<ItemCombo>();
            List<Rota> lstSetor;

            string sql = string.Format("SELECT DISTINCT COD_DISTRT, NUM_SETOR,0 COD_ROTA,null DAT_DISTRB, null DAT_PREV,null DAT_EXPORT FROM TB_ROTA WHERE COD_DISTRT = {0}", idDistrito);

            lstSetor = _rotaDAO.CurrentPersistenceObject.LoadData(sql);

            if (lstSetor.Count == 0) throw new Exception("Não há setores na base de dados.");

            lst.Add(new ItemCombo("S", "Selecione Setor"));

            foreach (Rota ro in lstSetor)
            {
                lst.Add(new ItemCombo(ro.Setor, ro.Setor));
            }

            return lst;
        }

        /// <summary>
        /// Retorna lista de rota por setor
        /// </summary>
        /// <param name="idSetor"></param>
        /// <returns></returns>
        public List<ItemCombo> getListRotaBySetor(int idSetor, int idDistrito)
        {
            List<ItemCombo> lst = new List<ItemCombo>();
            List<Rota> lstRota;

            string sql = string.Format("SELECT * FROM TB_ROTA WHERE NUM_SETOR = {0} AND COD_DISTRT = {1}", idSetor, idDistrito);

            lstRota = _rotaDAO.CurrentPersistenceObject.LoadData(sql);

            if (lstRota.Count == 0) throw new Exception("Não há rotas na base de dados.");

            lst.Add(new ItemCombo("S", "Selecione Rota"));

            foreach (Rota ro in lstRota)
            {
                lst.Add(new ItemCombo(ro.CodigoRota, ro.CodigoRota));
            }

            return lst;
        }

        public void DeleteAll()
        {
            _rotaDAO.DeleteAll();
        }

        public List<Rota> GetRotasQtdCad(int funcionario)
        {
            string sql = string.Format(@"select ro.COD_DISTRT, 
                                                ro.NUM_SETOR, 
                                                ro.COD_ROTA, 
                                                Count(ca.ID_CADAST)as QtdCad,
                                                null as DAT_DISTRB,
                                                null as DAT_PREV,
                                                null as DAT_EXPORT,
                                                null as USU_MOVIMENTACAO,
                                                null as DT_MOVIMENTACAO,
                                                null as IP_MOVIMENTACAO  
                                        from tb_rota ro 
                                        inner join TB_CADASTRO ca on(ca.COD_DISTRT = ro.COD_DISTRT and ca.NUM_SETOR = ro.NUM_SETOR and ca.COD_ROTA = ro.COD_ROTA)
                                        where ca.COD_FUNCN = {0}
                                        group by ro.COD_DISTRT, ro.NUM_SETOR, ro.COD_ROTA", funcionario);

            return _rotaDAO.CurrentPersistenceObject.LoadData(sql);
        }

        public List<Rota> GetRotasByFiltros(int? distrito, int? setor, int? rota, int? funcionario, DistribuicaoEnum? situacao)
        {
            string where = "";
            if (distrito.isNullorZero() && setor.isNullorZero() && rota.isNullorZero() &&
                funcionario.isNullorZero() && situacao == null)
            {
                throw new ValidateException("Nenhum campo de pesquisa foi informado.");
            }
            if (!distrito.isNullorZero())
            {
                where = " and ro.COD_DISTRT = " + distrito.ToString();
                if (!setor.isNullorZero())
                {
                    where = " and ro.NUM_SETOR = " + setor.ToString();
                    if (!rota.isNullorZero())
                    {
                        where = " and ro.COD_ROTA = " + rota.ToString();
                    }
                }
            }
            else
            {
                throw new ValidateException("Campo distrito deve ser informado na pesquisa.");
            }
            if (!funcionario.isNullorZero())
            {
                where = " and dst.COD_FUNCN = " + funcionario.ToString();
            }

            if (situacao != null && situacao == DistribuicaoEnum.NaoDistribuido)
            {
                where = " and (dst.COD_FUNCN = 0 or dst.COD_FUNCN is null)";
            }
            string sql = string.Format(@"select ro.COD_DISTRT, 
                                                ro.NUM_SETOR, 
                                                ro.COD_ROTA, 
                                                Count(ca.ID_CADAST)as QtdCad,        
                                                (select COUNT(caa.ID_CADAST) from TB_CADASTRO caa where  caa.STATUS_EXEC = 1 {0})as QtdCadExec,
                                                null as DAT_DISTRB,
                                                null as DAT_PREV,
                                                null as DAT_EXPORT,
                                                null as USU_MOVIMENTACAO,
                                                null as DT_MOVIMENTACAO,
                                                null as IP_MOVIMENTACAO  
                                        from tb_rota ro 
                                        inner join TB_CADASTRO ca on(ca.COD_DISTRT = ro.COD_DISTRT and ca.NUM_SETOR = ro.NUM_SETOR and ca.COD_ROTA = ro.COD_ROTA)
                                        left join TB_DISTRIBUICAO dst on (dst.COD_DISTRT = ro.COD_DISTRT and 
                                        dst.NUM_SETOR = ro.NUM_SETOR and dst.COD_ROTA = ro.COD_ROTA)

                                        where 1=1 {0}
                                        group by ro.COD_DISTRT, ro.NUM_SETOR, ro.COD_ROTA", where);

            List<Rota> distribuicao = _rotaDAO.CurrentPersistenceObject.LoadData(sql);
            if (situacao != null)
            {
                switch (situacao)
                {
                    case DistribuicaoEnum.NaoDistribuido: // caso anterior ao select no banco
                        break;
                    case DistribuicaoEnum.Pendente: distribuicao = distribuicao.Where(d => d.QtdCadExec < d.QtdCad).ToList();
                        break;
                    case DistribuicaoEnum.Concluido: distribuicao = distribuicao.Where(d => d.QtdCadExec == d.QtdCad).ToList();
                        break;
                }
            }
            return distribuicao;
        }

        public void DelRotaExecOrFinal(Rota rota)
        {
            string sql = string.Format(@"delete from TB_ROTA
                                        where COD_DISTRT = {0} and 
                                        NUM_SETOR = {1} and
                                        COD_ROTA = {2}", rota.CodigoDistrito, rota.Setor, rota.CodigoRota);

            _rotaDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }
    }
}
