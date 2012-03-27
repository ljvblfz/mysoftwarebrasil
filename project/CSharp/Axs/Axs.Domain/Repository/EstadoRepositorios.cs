using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using NHibernate;
using System.Linq;
using NHibernate.Linq;


namespace Axis.Domain
{
    public class EstadoRepository : GenericRepository<Estado>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EstadoRepository()
            : base()
        {
        }

        public override IList<Estado> ListAll()
        {
            var list = Estado.List();
            return list;
        }
    }
}
