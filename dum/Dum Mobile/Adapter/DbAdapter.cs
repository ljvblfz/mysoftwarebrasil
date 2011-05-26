using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
//using System.Data;
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
            int result = 0;
            System.Data.DataTable table = new System.Data.DataTable();
            DataSet genericDataSet = new DataSet();
            System.Data.DataSet dataSet = genericDataSet.GetDataSet(model);
            command.CommandText = String.Format("SELECT * FROM {0} where 1=0", model.GetType().Name);
            adapter = new SqlCeDataAdapter(command.CommandText, command.Connection.ConnectionString);
            new SqlCeCommandBuilder(adapter);
            adapter.Fill(table);
            return result;
        }
    }
}
