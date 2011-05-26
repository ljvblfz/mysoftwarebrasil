using System;
using System.Data.SqlServerCe;

namespace Dum_Mobile.Adapter
{
    public interface IDbAdapter
    {
        SqlCeDataAdapter adapter { get; set; }
        SqlCeCommand command { get; set; }
        SqlCeConnection connetion { get; set; }
        SqlCeParameterCollection paraman { get; set; }
        
        int Insert(Object model);
        
        int Update(object model);

        int Delete(object model);
    }
}
