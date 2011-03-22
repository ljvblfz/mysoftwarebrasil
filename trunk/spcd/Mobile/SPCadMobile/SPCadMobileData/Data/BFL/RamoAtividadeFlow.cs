using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.Model;
using SPCadMobileData.Data.DAL;
using GDA;
using GDA.Sql;
using CommonHelpMobile;

namespace SPCadMobileData.Data.BFL
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

        public void InsertOrUpdateSync(RamoAtividade ramoAtividade)
        {
            try
            {
                _ramoAtividadeDAO.InsertOrUpdateSync(ramoAtividade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
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

        public RamoAtividade getRamoAtivById(int id)
        {
            if (id == null)
                return null;
            return new Query("Id = ?Id").Add("?Id", id).First<RamoAtividade>();
        }

        public List<RamoAtividade> getListRamoAtivByListId(string[] ids)
        {
            string lista = string.Join(", ", ids);
            return new Query(string.Format("Id in ({0})", lista)).ToList<RamoAtividade>();
        }

        public void DeleteAll()
        {
            _ramoAtividadeDAO.DeleteAll();
        }
    }
}
