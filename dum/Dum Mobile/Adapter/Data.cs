using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Dum_Mobile.Adapter
{
    public class Data
    {
        public string query { get; set; }

        public System.Data.DataTable GetDataTable(Object model, System.Data.DataTable table)
        {
            PropertyInfo[] prop = model.GetType().GetProperties();
            System.Data.DataRow row = table.NewRow();
            foreach (PropertyInfo item in prop)
            {
                object[] atrubutes = item.GetCustomAttributes(true);
                row[item.Name] = item.GetValue(model, null);
                table.PrimaryKey = new System.Data.DataColumn[] { table.Columns[item.Name] };
            }

            table.Rows.Add(row);

            return table;
        }

        public static Primary GetAttribute(Type t)
        {
            //Get instance of the attribute.  
            Primary primary = (Primary)Attribute.GetCustomAttribute(t, typeof(Primary));
            return primary;
        }
    }
}
