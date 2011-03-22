using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.Model;
using SPCadMobileData.Data.DAL;

namespace SPCadMobileData.Data.BFL
{
    public class FonteAlternativaFlow
    {
        private Dao<FonteAlternativa> _fonteAlternativaDAO = DaoFactory.getFonteAlternativa();

        #region CRUD

        public void Insert(FonteAlternativa fonteAlternativa)
        {
            try
            {
                _fonteAlternativaDAO.Insert(fonteAlternativa);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(FonteAlternativa fonteAlternativa)
        {
            try
            {
                _fonteAlternativaDAO.Delete(fonteAlternativa);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(FonteAlternativa fonteAlternativa)
        {
            try
            {
                _fonteAlternativaDAO.Update(fonteAlternativa);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        public void InsertOrUpdate(FonteAlternativa fonteAlternativa)
        {
            try
            {
                _fonteAlternativaDAO.InsertOrUpdate(fonteAlternativa);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void InsertOrUpdateSync(FonteAlternativa fonteAlternativa)
        {
            try
            {
                _fonteAlternativaDAO.InsertOrUpdateSync(fonteAlternativa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            }
        }

        /// <summary>
        ///  Metodo que retorna uma lista de dados da tabela fonte alternativa
        /// </summary>
        /// <returns>List<FonteAlternativa> lista da model fonte de alternativa</returns>
        public List<FonteAlternativa> getListFontAltern()
        {
            // Lista de retorno
            List<FonteAlternativa> listaResultado = new List<FonteAlternativa>();
            
            // Dados de não possuem fonte alternativa
            List<FonteAlternativa> listaNaoPossueFonte = _fonteAlternativaDAO.Select(new GDA.Sql.Query("Id = 'N'"));
            
            // Todas as fontes
            List<FonteAlternativa> listaTodos = _fonteAlternativaDAO.Select();
            
            // Vrifica se eles não estão vazios
            if (listaNaoPossueFonte != null && listaTodos != null)
            {
                // verifica se possui o não possuem fonte
                if (listaNaoPossueFonte.Count > 0)
                {
                    // insere o não possui fonte como primeiro
                    listaResultado.Add(listaNaoPossueFonte[0]);

                    // verifica se existe outrosdados e insere na lista de retorno
                    if (listaTodos.Count > 0)
                    {
                        List<FonteAlternativa> listaAUX = listaTodos.FindAll(item => item.Id != "N");
                        listaResultado.AddRange(listaAUX.ToArray());
                    }
                }
                else
                {
                    // Se não possuem todos os dados insere todos os dados ordenados
                    listaResultado = listaTodos.OrderBy(fontAlternativa => fontAlternativa.Id).ToList();
                }
            }
            return listaResultado.ToList();
        }

        public void DeleteAll()
        {
            _fonteAlternativaDAO.DeleteAll();
        }
    }
}
