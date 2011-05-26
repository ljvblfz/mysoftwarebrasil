using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dum_Mobile.Adapter;
using Dum_Mobile.Command;
using Dum_Mobile.Config;
using System.Data.SqlServerCe;

namespace Dum_Mobile
{
    public class Dum
    {
        private IDbAdapter db { get; set; }
        private string query { get; set; }

        public Dum()
        {
            //Configuration.conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbPortal"];
            Configuration.conectionString = "Data Source = E:\\PROJETO\\C#\\Dum Mobile\\TestProject1\\OnPlace.sdf; Max Buffer Size=1024; Persist Security Info=False;";
            //Configuration.conectionString = "Data Source = E:\\PROJETO\\C#\\Dum Mobile\\ConsoleApplication1\\OnPlace.sdf; Persist Security Info=False;";
            this.db = CeCommand.GetDbAdapter();
        }

        public int Insert(Object model)
        {
            return this.db.Insert(model);
        }

        public Dum Where(string column, object value)
        {
            SqlCeParameter param = new SqlCeParameter();
            param.ParameterName = "@" + column;
            param.Value = value;
            this.db.command.Parameters = new SqlCeParameterCollection { param };
            return this;
        }

        public int Update(Object model)
        {
            return 0;
        }
    }
}
