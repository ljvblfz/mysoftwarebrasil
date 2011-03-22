using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.Model;
using SPCadMobileData.Data.DAL;
using CommonHelpMobile;
using GDA.Sql;

namespace SPCadMobileData.Data.BFL
{
    public class OcorrenciaFlow
    {
        private Dao<Ocorrencia> _ocorrenciaDAO = DaoFactory.getOcorrencia();

        #region CRUD

        public void Insert(Ocorrencia ocorrencia)
        {
            try
            {
                _ocorrenciaDAO.Insert(ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(Ocorrencia ocorrencia)
        {
            try
            {
                _ocorrenciaDAO.Delete(ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(Ocorrencia ocorrencia)
        {
            try
            {
                _ocorrenciaDAO.Update(ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void InsertOrUpdate(Ocorrencia ocorrencia)
        {
            try
            {
                _ocorrenciaDAO.InsertOrUpdate(ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        /// <summary>
        /// Retorna uma lista do tipo ItemCombo( Value = id, Description = Descricao)
        /// </summary>
        /// <returns></returns>
        public List<ItemCombo> getListOcorrencia()
        {
            List<Ocorrencia> ocorrencia;
            List<ItemCombo> lista = new List<ItemCombo>();

            ocorrencia = _ocorrenciaDAO.Select();

            //Construir 
            foreach (Ocorrencia oc in ocorrencia)
            {
                lista.Add(new ItemCombo(oc.Id, oc.Descricao));
            }

            return lista;
        }

        /// <summary>
        /// Retorna uma lista ocorrencia
        /// </summary>
        /// <returns></returns>
        public List<Ocorrencia> getListOcor()
        {
            return _ocorrenciaDAO.Select();
        }
        /// <summary>
        /// retorna uma lista no formato itemCombo(Value , Description ) fazendo a conversao do vetor ocorrencia(está em string).
        /// </summary>
        /// <returns></returns>
        public List<ItemCombo> ListOcorrencia(string vetorOcorrencia)
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            try
            {
                lst.Clear();

                List<ItemCombo> lstOcorrencia = getListOcorrencia();
                int p = 0;

                string[] vetOcor = vetorOcorrencia.Split(',');

                foreach (string oco in vetOcor)
                {
                    //lst.Insert(p, (lstOcorrencia.Find(delegate(ItemCombo item)
                    //{
                    //    return item.Value.ToString().PadLeft(3,'0') == oco;
                    //})));

                    ItemCombo item = lstOcorrencia.Where(po => po.Value.ToString().PadLeft(3, '0') == oco.PadLeft(3, '0')).First<ItemCombo>();
                    lst.Insert(p, item);
                    p++;
                }
            }
            catch (Exception)
            {
            }

            return lst;
        }


        public List<Ocorrencia> getOcorrenciaByParam(string descricao)
        {
            descricao = TrataString.CutAccent(descricao);

            string sql = string.Format(@"SELECT * FROM TB_OCORRENCIA WHERE 
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        lower(DES_OCORRC),'á','a'),'é','e'),
                                        'í','i'),'ó','o'),'ú','u'),'â','a'),'ê','e'),'î','i'),'ô','o'),'û','u'),'à',
                                        'a'),'è','e'),'ì','i'),'ò','o'),'ù','u'),'ä','a'),'ë','e'),'ï','i'),'ö','o'),
                                        'ü','u'),'ã','a'),'õ','o'),'ç','c'),'/',''),'-',''),'.',''),' ',''),'\','')
                                        LIKE '%{0}%' OR 
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        replace(replace(replace(replace(replace(replace(replace(replace(replace(
                                        lower(CAST(COD_OCORRC AS NVARCHAR(2))),'á','a'),'é','e'),
                                        'í','i'),'ó','o'),'ú','u'),'â','a'),'ê','e'),'î','i'),'ô','o'),'û','u'),'à',
                                        'a'),'è','e'),'ì','i'),'ò','o'),'ù','u'),'ä','a'),'ë','e'),'ï','i'),'ö','o'),
                                        'ü','u'),'ã','a'),'õ','o'),'ç','c'),'/',''),'-',''),'.',''),' ',''),'\','') = '{0}'", descricao);

            return _ocorrenciaDAO.CurrentPersistenceObject.LoadData(sql);
        }

        public List<Ocorrencia> getOcorrenciaByCadastro(Cadastro cad)
        {
            string sql = @"SELECT O.* FROM TB_OCORRENCIA O where O.COD_OCORRC in ({0})";

            List<Ocorrencia> lstOcorrencia;

            string vetorOcorrencia = cad.VetorOcorrencia.Trim();
            if (vetorOcorrencia.Trim() == "")
                vetorOcorrencia = "0";
            lstOcorrencia = _ocorrenciaDAO.CurrentPersistenceObject.LoadData(string.Format(sql, vetorOcorrencia));


            return lstOcorrencia;

        }

        public void DeleteAll()
        {
            _ocorrenciaDAO.DeleteAll();
        }

        public void InsertOrUpdateSync(Ocorrencia ocorrencia)
        {
            try
            {
                _ocorrenciaDAO.InsertOrUpdateSync(ocorrencia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
        }

        //verifica se a ocorrencia é do tipo impedimento
        public bool CheckOcorrcImp(string vetorOcorrencia)
        {
            bool state = false;

            string[] vetOcor = vetorOcorrencia.Split(',');
            string ocorrencias = "";

            foreach (string oco in vetOcor)
            {                
                ocorrencias += oco + ",";
            }
            ocorrencias = ocorrencias.Remove(ocorrencias.Length - 1, 1);

            string sql = string.Format("select * from tb_ocorrencia where FLG_IMPEDM = 1 and COD_OCORRC in ({0})", ocorrencias);

            List<Ocorrencia> lst = _ocorrenciaDAO.CurrentPersistenceObject.LoadData(sql);

            //se existir alguma ocorrencia com impedimento o valor é true se não é false.
            state = (lst.Count > 0);

            return state;
        }

        //verifica se a ocorrencia é do tipo impedimento
        public bool CheckOcorrcImp(int ocorrencia)
        {
            bool state = false;

            string sql = string.Format("select * from tb_ocorrencia where FLG_IMPEDM = 1 and COD_OCORRC = {0}", ocorrencia);

            Ocorrencia oco = _ocorrenciaDAO.CurrentPersistenceObject.LoadOneData(sql);

            //se a ocorrencia for de impedimento o valor é true se não é false.
            state = (oco != null && oco.ImpedimentoBool);

            return state;
        }
    }
}
