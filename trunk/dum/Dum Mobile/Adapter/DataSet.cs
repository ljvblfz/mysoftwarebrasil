using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Dum_Mobile.Adapter
{
    public class DataSet
    {
        public string query { get; set; }
        private System.Data.DataSet dataSet { get; set; }
        public System.Data.DataSet GetDataSet(Object model)
        {
            this.dataSet = new System.Data.DataSet();
            this.dataSet.Tables.Add(this.loadDataSet(model));
            return this.dataSet;
        }

        private System.Data.DataTable loadDataSet(Object model)
        {
            //Criando a tabela
            System.Data.DataTable table = new System.Data.DataTable(model.GetType().Name);
            PropertyInfo[] prop = model.GetType().GetProperties();
            System.Data.DataRow row = table.NewRow();
            foreach (PropertyInfo item in prop)
            {
                table.Columns.Add(item.Name);
                row[item.Name] = item.GetValue(model, null);
            }

            table.Rows.Add(row);

            return table;
        }
    }
}
