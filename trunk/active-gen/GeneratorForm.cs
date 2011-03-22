using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using ActiveRecordGenerator.CodeGen;

namespace ActiveRecordGenerator
{
	public partial class GeneratorForm : Form
	{
		public string Server
		{
			get { return txtServer.Text; }
			set { if (value != null) txtServer.Text = value; }
		}

		public string Database
		{
			get { return txtDatabase.Text; }
			set { if (value != null) txtDatabase.Text = value; }
		}

		//TODO: add configuration and setter
		public string UserName 
		{
			get { return txtUserName.Text; }
		}

		//TODO: add configuration and setter
		public string Password
		{
			get { return txtPassword.Text; }
		}

		//TODO: add configuration and setter
		public bool IncludeFilter 
		{
			get { return chkIncludeFilter.Checked; }
		}

		//TODO: add configuration and setter
		public string FilterPrefix 
		{
			get { return txtFilterPrefix.Text; }
		}

		public string OutputDir
		{
			get 
			{
				return txtOutputDir.Text;
			}
			set
			{
				if (value != null) txtOutputDir.Text = value.EndsWith("\\") ? value : value + "\\"; 
			}
		}

		public string NameSpace
		{
			get 
			{
				string ns = txtNameSpace.Text.Trim();
				if (ns.Length == 0) ns = "Application";
				return ns;  
			}
			set 
			{
				if (value != null) txtNameSpace.Text = value; 
			}
		}

		public bool Partial 
		{
			get { return chkPartial.Checked; }
			set { chkPartial.Checked = value; }
		}

		public bool PropertyEvents
		{
			get { return chkPropChange.Checked; }
			set { chkPropChange.Checked = value; }
		}

		public bool Validation
		{
			get { return chkValidation.Checked; }
			set { chkValidation.Checked = value; }
		}

		public GeneratorForm()
		{
			InitializeComponent();
		}

		private void GeneratorForm_Load(object sender, EventArgs e)
		{
			// load templates
			string[] tFiles = Directory.GetFiles(@".\Templates\", "*.vm", SearchOption.TopDirectoryOnly);
			// strip off path information
			for (int i = 0; i < tFiles.Length; i++)
			{
				tFiles[i] = new FileInfo(tFiles[i]).Name;
			}
			chkLbTemplates.Items.AddRange(tFiles);
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				//TODO: Integrate a BackgroundWorker
				DbTableInfo[] dbTables = CodeGenFactory.GetTables(null, 
					Server, Database, UserName, Password, IncludeFilter, FilterPrefix);
				chkLbTables.Items.Clear();
				chkLbTables.Items.AddRange(dbTables);
				this.Cursor = Cursors.Default ;
			}
			catch (Exception ex)
			{
				this.Cursor = Cursors.Default;
				Debug.WriteLine(ex.Message);
				MessageBox.Show(ex.Message);
			}

		}

		private void btnTemplatesSelectAll_Click(object sender, EventArgs e)
		{
			// select all items in chkLbTemplates
			SetChecked(chkLbTemplates, true);
		}

		private void btnTemplatesSelectNone_Click(object sender, EventArgs e)
		{
			SetChecked(chkLbTemplates, false);
		}

		private void btnTablesSelectAll_Click(object sender, EventArgs e)
		{
			// select all items in chkLbTables
			SetChecked(chkLbTables, true);
		}

		private void btnTablesSelectNone_Click(object sender, EventArgs e)
		{
			//un-select all items in chkLbTables
			SetChecked(chkLbTables, false);
		}

		private void SetChecked(CheckedListBox clb, bool isChecked)
		{
			for (int i = 0; i < clb.Items.Count; i++)
			{
				clb.SetItemChecked(i, isChecked);
			}
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				// create an anonymous delegate
				FileExists fileExists = delegate(string p_OutputDir, string p_FileName, ref FileHandlingResult fhResult)
				{
					// "File " + fileName +" exists.  What should I do?" [Overwrite], [Rename], [Cancel]
					FileExistsForm fileExistsForm = new FileExistsForm();
					fileExistsForm.Directory = p_OutputDir;
					fileExistsForm.File = p_FileName;
					fileExistsForm.ShowDialog(this);
					fhResult = fileExistsForm.Result;
					fileExistsForm.Dispose();
				};

				ModelGenerator modelGen = new ModelGenerator(fileExists, NameSpace, chkPartial.Checked, chkPropChange.Checked, chkValidation.Checked);
				DbTableInfo table;
				string sTemplate;
				tsStatus.Text = "Generating ... ";
				int curPct = 0;
				tsProgressBar.Value = curPct;
				for (int i = 0; i < chkLbTables.Items.Count; i++)
				{
					curPct = (int)((100.0 * i) / chkLbTables.Items.Count);
					if (curPct >= tsProgressBar.Value + 5)
					{
						tsProgressBar.Value = curPct;
						this.Refresh();
					}
					if (chkLbTables.GetItemChecked(i))
					{
						table = (DbTableInfo)chkLbTables.Items[i];

						for (int j = 0; j < chkLbTemplates.Items.Count; j++)
						{
							if (chkLbTemplates.GetItemChecked(j))
							{
								sTemplate = (string)chkLbTemplates.Items[j];
								modelGen.GenerateClass(sTemplate, table, OutputDir);
								// cancel all
								if (modelGen.GetFileHandlingResult() == (FileHandlingResult.Cancel | FileHandlingResult.All))
								{
									tsProgressBar.Value = 0;
									goto loop_i;
								}
							}
						}
					}
				}
				loop_i:
				tsProgressBar.Value = 100;
				tsStatus.Text = "Code Generation Complete!";

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			finally 
			{
				this.Cursor = Cursors.Arrow;
			}

		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.FolderBrowserDialog dlg = new FolderBrowserDialog();

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				this.OutputDir = dlg.SelectedPath;
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}