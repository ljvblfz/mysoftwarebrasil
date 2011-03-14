using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class TabelaCargaONPDAO : BaseDAO<TabelaCargaONP>
    {
        public List<TabelaCargaONP> Lista()
        {
            List<TabelaCargaONP> listaTabelas = new List<TabelaCargaONP>();
            return listaTabelas;
        }

		public void Delete(TabelaCargaONP objTabelaCargaONP)
        {
            return;
        }

        public void Update(TabelaCargaONP objTabelaCargaONP)
        {
            return;
        }

    	public void Insert(TabelaCargaONP objTabelaCargaONP)
        {
            return;
        }
    }
}