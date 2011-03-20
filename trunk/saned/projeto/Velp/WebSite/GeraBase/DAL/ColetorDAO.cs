using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeraBase.Model;
using GDA;

namespace GeraBase.DAL
{
    public class ColetorDAO : BaseDAO<Coletor>
    {
        public bool CheckPdaExist(string idColetor)
        {
            Coletor teste = new Coletor();
            string sql = string.Format("select * from Coletor where id = '{0}'", idColetor);
            teste = CurrentPersistenceObject.LoadOneData(sql);

            if (teste == null)
            { 
                return false; 
            }
            else
            { 
                return true; 
            }
        }
    }
}
