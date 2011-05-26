using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dum_Mobile.Adapter;
using Dum_Mobile.Config;

namespace Dum_Mobile.Command
{
    public class CeCommand 
    {
        public static IDbAdapter GetDbAdapter()
        {
            IDbAdapter db = new DbAdapter();
            db.command = new System.Data.SqlServerCe.SqlCeCommand();
            db.command.Connection = new System.Data.SqlServerCe.SqlCeConnection(Configuration.conectionString);
            return db;
        }
    }
}
