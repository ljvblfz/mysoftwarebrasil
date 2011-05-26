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
            this.db = CeCommand.GetDbAdapter();
        }

        public int Insert(Object model)
        {
            return this.db.Insert(model);
        }

        public int Update(Object model)
        {
            return this.db.Update(model);
        }

        public int Delete(Object model)
        {
            return this.db.Delete(model);
        }

        public static Primary GetAttribute(Type t)
        {
            //Get instance of the attribute.  
            Primary primary = (Primary)Attribute.GetCustomAttribute(t, typeof(Primary));
            return primary;     
        }
    }
}
