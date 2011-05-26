using System;
using System.Data.SqlServerCe;

namespace Dum_Mobile.Adapter
{
    public interface IDbAdapter
    {
        SqlCeDataAdapter adapter { get; set; }
        SqlCeCommand command { get; set; }
        SqlCeConnection connetion { get; set; }
        int Insert(Object model);
        SqlCeParameterCollection paraman { get; set; }
    }
}
