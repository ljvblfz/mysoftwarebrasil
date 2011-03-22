using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadDesktopData.Data.DAL;
using SPCadDesktopData.Data.Model;
using GDA;
using GDA.Sql;
using CommonHelpDesktop;

namespace SPCadDesktopData.Data.BFL
{
    public class DistritoFlow
    {
        private Dao<Distrito> _distritoDAO = DaoFactory.getDistrito();

        #region CRUD
        
        public void Insert(Distrito distrito)
        {
            try
            {
                _distritoDAO.Insert(distrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(Distrito distrito)
        {
            try
            {
                _distritoDAO.Delete(distrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(Distrito distrito)
        {
            try
            {
                _distritoDAO.Update(distrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion           

        public void InsertOrUpdate(Distrito distrito)
        {
            try
            {
                _distritoDAO.InsertOrUpdate(distrito);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
            }
        }


        /// <summary>
        /// Recupera lista de Distritos
        /// </summary>
        /// <returns></returns>
        public List<ItemCombo> getListDistrito()
        {
            List<Distrito> dist;
            List<ItemCombo> lista = new List<ItemCombo>();
            
            dist = _distritoDAO.Select();            

            //A opção Oeste deve ser o primeiro item da lista
            for(int a = 0; a < dist.Count;a++)
            {
                string posicao = "";

                if (dist[a].NomeDistrito == "Oeste" && a == 0)
                {
                    break; 
                }
                if (dist[a].NomeDistrito == "Oeste" && a > 0)
                {
                    posicao = dist[a].NomeDistrito;
                    dist[a].NomeDistrito = dist[0].NomeDistrito;
                    dist[0].NomeDistrito = posicao;
                    break;
                }
            }

            lista.Add(new ItemCombo("S", "Selecione distrito"));

            //Constroi 
            foreach (Distrito dis in dist)
            {
                lista.Add(new ItemCombo(dis.Id, dis.NomeDistrito));
            }

            return lista;
        }

        public void DeleteAll()
        {
            _distritoDAO.DeleteAll();
        }
    }
}
