using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Paulovich.Data.Generator
{
    public partial class Tables : Form
    {
        public Tables()
        {
            InitializeComponent();
        }

        private void Tables_Load(object sender, EventArgs e)
        {

            lstTables.DataSource = (new Command()).ExecuteQuery("SELECT table_name FROM information_schema.tables WHERE table_type = 'BASE TABLE' ORDER BY table_name", ReturnType.DataTable);
            lstTables.DisplayMember = "table_name";
            lstTables.ValueMember = "table_name";

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            foreach (var item in lstTables.CheckedItems)
            {

                string tableName = Convert.ToString(((System.Data.DataRowView)(item)).Row[0]);

                var childForm = new View(tableName);
                childForm.MdiParent = this.ParentForm;
                childForm.Text = Convert.ToString(tableName) + "*";
                childForm.Show();

            }

        }
    }
}
