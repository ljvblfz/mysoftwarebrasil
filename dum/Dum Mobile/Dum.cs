using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dum_Mobile.Adapter;
using Dum_Mobile.Command;
using Dum_Mobile.Config;

namespace Dum_Mobile
{
    public class Dum
    {
        private IDbAdapter db { get; set; }

        public Dum()
        {
            //Configuration.conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbPortal"];
            Configuration.conectionString = "Data Source = E:\\PROJETO\\C#\\Dum Mobile\\TestProject1\\OnPlace.sdf; Max Buffer Size=1024; Persist Security Info=False;";
            //Configuration.conectionString = "Data Source = E:\\PROJETO\\C#\\Dum Mobile\\ConsoleApplication1\\OnPlace.sdf; Persist Security Info=False;";
            this.db = CeCommand.GetDbAdapter();
        }

        public int Insert(Object query)
        {
            return this.db.Insert(query);
        }
    }
}
