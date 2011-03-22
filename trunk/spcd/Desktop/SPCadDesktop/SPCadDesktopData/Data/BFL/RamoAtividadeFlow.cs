using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadDesktopData.Data.Model;
using SPCadDesktopData.Data.DAL;
using GDA;
using CommonHelpDesktop;
using GDA.Sql;

namespace SPCadDesktopData.Data.BFL
{
    public class RamoAtividadeFlow
    {
        private Dao<RamoAtividade> _ramoAtividadeDAO = DaoFactory.getRamoAtividade();

        #region CRUD

        public void Insert(RamoAtividade ramoAtividade)
        {
            try
            {
                _ramoAtividadeDAO.Insert(ramoAtividade);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(RamoAtividade ramoAtividade)
        {
            try
            {
                _ramoAtividadeDAO.Delete(ramoAtividade);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(RamoAtividade ramoAtividade)
        {
            try
            {
                _ramoAtividadeDAO.Update(ramoAtividade);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        public void InsertOrUpdate(RamoAtividade ramoAtividade)
        {
            try
            {
                _ramoAtividadeDAO.InsertOrUpdate(ramoAtividade);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public List<ItemCombo> getListRamoAtividade()
        {
            List<RamoAtividade> ramosAtividade;
            List<ItemCombo> lista = new List<ItemCombo>();

            ramosAtividade = _ramoAtividadeDAO.Select();

            //Construir 
            foreach (RamoAtividade ra in ramosAtividade)
            {
                lista.Add(new ItemCombo(ra.Id, ra.Descricao));
            }

            return lista;
        }

        /// <summary>
        /// Retorna o resultado de uma pesquisa.
        /// </summary>
        /// <param name="descricao"></param>
        /// <param name="ramo"></param>
        /// <returns></returns>
        public List<RamoAtividade> getRamoAtivByTipo(string descricao, string ramo)
        {
            descricao = TrataString.CutAccent(descricao);
            descricao = TrataString.RemoveCaracter(descricao);

            string sql = string.Format(@"SELECT * FROM TB_RAMO_ATIVIDADE WHERE 
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        lower(DES_RAMO_ATIVD),'á','a'),'é','e'),
                                        'í','i'),'ó','o'),'ú','u'),'â','a'),'ê','e'),'î','i'),'ô','o'),'û','u'),'à',
                                        'a'),'è','e'),'ì','i'),'ò','o'),'ù','u'),'ä','a'),'ë','e'),'ï','i'),'ö','o'),
                                        'ü','u'),'ã','a'),'õ','o'),'ç','c'),'/',''),'-',''),'.',''),' ',''),'\','')
                                        LIKE '%{0}%' AND TIP_RAMO_ATIVD = '{1}'", descricao, ramo);                                         
            
            return _ramoAtividadeDAO.CurrentPersistenceObject.LoadData(sql);
        }

        public void DeleteAll()
        {
            _ramoAtividadeDAO.DeleteAll();
        }

        public List<RamoAtividade> getListRamoAtivByListId(string[] ids)
        {
            string lista = string.Join(", ", ids);
            return new Query(string.Format("Id in ({0})", lista)).ToList<RamoAtividade>();
        }

        //retorna um objeto de ramo atividade pela descrição informada
        public RamoAtividade getRamoAtivByDesc(string descricao)
        {
            descricao = TrataString.CutAccent(descricao);
            descricao = TrataString.RemoveCaracter(descricao);

            string sql = string.Format(@"SELECT * FROM TB_RAMO_ATIVIDADE WHERE 
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        lower(DES_RAMO_ATIVD),'á','a'),'é','e'),
                                        'í','i'),'ó','o'),'ú','u'),'â','a'),'ê','e'),'î','i'),'ô','o'),'û','u'),'à',
                                        'a'),'è','e'),'ì','i'),'ò','o'),'ù','u'),'ä','a'),'ë','e'),'ï','i'),'ö','o'),
                                        'ü','u'),'ã','a'),'õ','o'),'ç','c'),'/',''),'-',''),'.',''),' ',''),'\','')
                                        LIKE '%{0}%'", descricao);                                         
            
            return _ramoAtividadeDAO.CurrentPersistenceObject.LoadOneData(sql);
        }

        //Metodo utilizado na importação para teste de coerencia de descrição e codigo do ramo atividade
        public int? getIdRamoAtivByDesc(string descricao)
        {
            //se a descriçao for nula ou vazia retorna null.
            if (string.IsNullOrEmpty(descricao))
            {
                return null;
            }

            //descricao = TrataString.CutAccent(descricao);
            //descricao = TrataString.RemoveCaracterNoBlank(descricao);

//            string sql = string.Format(@"SELECT * FROM TB_RAMO_ATIVIDADE WHERE 
//                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(
//                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(
//                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(
//                                        lower(DES_RAMO_ATIVD),'á','a'),'é','e'),
//                                        'í','i'),'ó','o'),'ú','u'),'â','a'),'ê','e'),'î','i'),'ô','o'),'û','u'),'à',
//                                        'a'),'è','e'),'ì','i'),'ò','o'),'ù','u'),'ä','a'),'ë','e'),'ï','i'),'ö','o'),
//                                        'ü','u'),'ã','a'),'õ','o'),'ç','c'),'/',''),'-',''),'.',''),' ',''),'\','') = '{0}'", descricao);

            string sql = string.Format(@"SELECT * FROM TB_RAMO_ATIVIDADE WHERE DES_RAMO_ATIVD = '{0}'", descricao);

            RamoAtividade ramo = _ramoAtividadeDAO.CurrentPersistenceObject.LoadOneData(sql);

            //se a descrição do ramo não for encontrada retorna zero.
            if (ramo == null)
            {
                return 0;
            }
            else
            {
                return ramo.Id;
            }
        }
            
    }
}
