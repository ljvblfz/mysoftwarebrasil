using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlServerCe;
using Dum_Mobile.Config;

namespace Dum_Mobile.Adapter
{
    public class DbAdapter : IDbAdapter
    {
        public SqlCeConnection connetion { get; set; }
        public SqlCeCommand command { get; set; }
        public SqlCeDataAdapter adapter { get; set; }
        public SqlCeParameterCollection paraman { get; set; }

        public DbAdapter()
        {

        }

        public int Insert(Object model)
        {
            int result;
            DataTable table = new DataTable();

            command.CommandText = String.Format("SELECT * FROM {0} where 1=0", model.GetType().Name);
            adapter = new SqlCeDataAdapter(command);
            new SqlCeCommandBuilder(adapter);

            adapter.Fill(table);
            table = new Data().GetDataTable(model, table);
            result = adapter.Update(table);

            return result;
        }
    }
}
