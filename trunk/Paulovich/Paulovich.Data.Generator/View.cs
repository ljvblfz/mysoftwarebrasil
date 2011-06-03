using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Paulovich.Data.Generator
{
    public partial class View : Form
    {

        public string TableName { get; set; }

        public string Code { 
            
            get {

                return txtCode.Text;

            }
 
        }

        public View(string tableName)
        {
            
            InitializeComponent();

            TableName = tableName;
            txtCode.Text = CodeGenerator.Generate(TableName, TableName, 0, true, true, true);

        }

        private void View_Load(object sender, EventArgs e)
        {

            txtCode.Text = CodeGenerator.Generate(TableName, TableName, 0, true, true, true);

        }

        public void Save(string fileName) {

            Text = Text.Substring(0, Text.Length - 1);

            var file = File.CreateText(fileName);
            file.Write(Code);
            file.Close();

        }

    }
}
