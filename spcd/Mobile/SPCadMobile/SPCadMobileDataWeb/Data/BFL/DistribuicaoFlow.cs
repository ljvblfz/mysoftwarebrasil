using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPCadMobileDataWeb.Data.DAL;
using SPCadMobileDataWeb.Data.Model;

namespace SPCadMobileDataWeb.Data.BFL
{
    public class DistribuicaoFlow
    {
        private Dao<Distribuicao> _distribuicaoDAO = DaoFactory.getDistribuicao();

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

        /// <summary>
        /// Atualiza o campo situação carga para as rotas liberadas que foram baixadas 100%.
        /// </summary>
        /// <param name="rota"></param>
        /// <param name="funcionario"></param>
        public void UpdateSitCargaPDA(Rota rota, int funcionario, string situacao)
        {
            string sql = string.Format(@"UPDATE TB_DISTRIBUICAO 
                                       SET SITUACAO_CARGA = {4} 
                                       WHERE 
                                       (
                                            COD_DISTRT = {0} AND
                                            NUM_SETOR = {1} AND
                                            COD_ROTA = {2} AND 
                                            COD_FUNCN = {3}
                                        )", rota.CodigoDistrito, rota.Setor, rota.CodigoRota, funcionario, situacao);

            _distribuicaoDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }
    }
}
