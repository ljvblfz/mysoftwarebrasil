using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class VoltaNovoRegistroDAO : BaseDAO<VoltaNovoRegistro>
    {
        public List<VoltaNovoRegistro> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM volta_novo_registro
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
    }
}
