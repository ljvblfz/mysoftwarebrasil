using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPCadDesktopData.Data.DAL;
using SPCadDesktopData.Data.Model;
using CommonHelpDesktop;
using SPCadDesktopData.Data.BFL.CustomException;
using GDA;
using GDA.Sql;

namespace SPCadDesktopData.Data.BFL
{
    public class DistribuicaoFlow
    {
        private Dao<Distribuicao> _distribuicaoDAO = DaoFactory.getDistribuicao();

        #region BaseQuerys
        string baseQuery = @"select aux.COD_DISTRT,
                               aux.NUM_SETOR,
                               aux.COD_ROTA,
                               aux.QT_PS,
                               aux.QT_EXECUTADO,
                               (select COUNT(D.COD_FUNCN) from TB_DISTRIBUICAO D where aux.COD_DISTRT = D.COD_DISTRT and aux.NUM_SETOR = D.NUM_SETOR and aux.COD_ROTA = D.COD_ROTA ) as QT_DISTRIBUICAO
                          from VW_ROTA aux {0}";
        #endregion

        #region CRUD

        public void Insert(Distribuicao distribuicao)
        {
            try
            {
                _distribuicaoDAO.Insert(distribuicao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(Distribuicao distribuicao)
        {
            try
            {
                _distribuicaoDAO.Delete(distribuicao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(Distribuicao distribuicao)
        {
            try
            {
                _distribuicaoDAO.Update(distribuicao);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        #region Métodos de consulta

        public List<Distribuido> GetDistribuidoByFiltros(int? distrito, int? setor, int? rota, int? funcionario, DistribuicaoEnum? situacao)
        {
            string where = "";
            if (distrito.isNullorZero() && setor.isNullorZero() && rota.isNullorZero() &&
                funcionario.isNullorZero() && situacao == null)
            {
                throw new ValidateException("Nenhum campo de pesquisa foi informado.");
            }
            if (!distrito.isNullorZero())
            {
                where = " and aux.COD_DISTRT = " + distrito.ToString();
                if (!setor.isNullorZero())
                {
                    where = " and aux.NUM_SETOR = " + setor.ToString();
                    if (!rota.isNullorZero())
                    {
                        where = " and aux.COD_ROTA = " + rota.ToString();
                    }
                }
            }
            else
            {
                throw new ValidateException("Campo distrito deve ser informado na pesquisa.");
            }
            if (!funcionario.isNullorZero())
            {
                where = string.Format(@"and (aux.COD_DISTRT * 1000000 + aux.NUM_SETOR * 10000  + aux.COD_ROTA in 
                           (select d2.COD_DISTRT * 1000000 + d2.NUM_SETOR * 10000  + d2.COD_ROTA
                           from TB_DISTRIBUICAO d2 where d2.COD_FUNCN = {0}))", funcionario.ToString());
            }
            where = "where " + where.Remove(0,4);

            string sql = string.Format(baseQuery, where);

            PersistenceObject<Distribuido> currPersistObject = new PersistenceObject<Distribuido>(GDA.GDASettings.DefaultProviderConfiguration);

            List<Distribuido> distribuicao = currPersistObject.LoadData(sql);
            if (situacao != null)
            {
                switch (situacao)
                {
                    case DistribuicaoEnum.NaoDistribuido: distribuicao = distribuicao.Where(d => d.QtDistribuicao == 0).ToList();
                        break;
                    case DistribuicaoEnum.Pendente: distribuicao = distribuicao.Where(d => d.QtExecutado < d.QtPontoServico).ToList();
                        break;
                    case DistribuicaoEnum.Concluido: distribuicao = distribuicao.Where(d => d.QtPontoServico == d.QtExecutado).ToList();
                        break;
                }
            }
            return distribuicao;
        }

        public List<Distribuicao> GetDistribuicaoByDistritoSetorRota(int? distrito, int? setor, int? rota)
        {
            return new Query("Distrito = ?Distrito and Setor = ?Setor and Rota = ?Rota").Add("?Distrito",distrito).
                Add("?Setor", setor).Add("?Rota", rota).InnerJoin<Funcionario>().ToList<Distribuicao>();
        }


        #endregion
        
    }
}
