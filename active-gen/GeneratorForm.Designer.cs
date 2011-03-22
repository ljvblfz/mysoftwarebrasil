namespace ActiveRecordGenerator
{
	partial class GeneratorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnConnect = new System.Windows.Forms.Button();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.chkLbTables = new System.Windows.Forms.CheckedListBox();
			this.btnTablesSelectAll = new System.Windows.Forms.Button();
			this.btnTablesSelectNone = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtOutputDir = new System.Windows.Forms.TextBox();
			this.chkPartial = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.chkPropChange = new System.Windows.Forms.CheckBox();
			this.txtNameSpace = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkValidation = new System.Windows.Forms.CheckBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.btnClose = new System.Windows.Forms.Button();
			this.chkLbTemplates = new System.Windows.Forms.CheckedListBox();
			this.btnTemplatesSelectNone = new System.Windows.Forms.Button();
			this.btnTemplatesSelectAll = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.txtFilterPrefix = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.chkIncludeFilter = new System.Windows.Forms.CheckBox();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(385, 12);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(73, 46);
			this.btnConnect.TabIndex = 7;
			this.btnConnect.Text = "Connect and Scan";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(100, 12);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(279, 20);
			this.txtServer.TabIndex = 1;
			// 
			// txtDatabase
			// 
			this.txtDatabase.Location = new System.Drawing.Point(100, 38);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(279, 20);
			this.txtDatabase.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(51, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Database";
			// 
			// chkLbTables
			// 
			this.chkLbTables.CheckOnClick = true;
			this.chkLbTables.FormattingEnabled = true;
			this.chkLbTables.Location = new System.Drawing.Point(467, 28);
			this.chkLbTables.Name = "chkLbTables";
			this.chkLbTables.Size = new System.Drawing.Size(214, 289);
			this.chkLbTables.Sorted = true;
			this.chkLbTables.TabIndex = 22;
			// 
			// btnTablesSelectAll
			// 
			this.btnTablesSelectAll.Location = new System.Drawing.Point(687, 28);
			this.btnTablesSelectAll.Name = "btnTablesSelectAll";
			this.btnTablesSelectAll.Size = new System.Drawing.Size(75, 23);
			this.btnTablesSelectAll.TabIndex = 25;
			this.btnTablesSelectAll.Text = "Select All";
			this.btnTablesSelectAll.UseVisualStyleBackColor = true;
			this.btnTablesSelectAll.Click += new System.EventHandler(this.btnTablesSelectAll_Click);
			// 
			// btnTablesSelectNone
			// 
			this.btnTablesSelectNone.Location = new System.Drawing.Point(687, 57);
			this.btnTablesSelectNone.Name = "btnTablesSelectNone";
			this.btnTablesSelectNone.Size = new System.Drawing.Size(75, 23);
			this.btnTablesSelectNone.TabIndex = 26;
			this.btnTablesSelectNone.Text = "Select None";
			this.btnTablesSelectNone.UseVisualStyleBackColor = true;
			this.btnTablesSelectNone.Click += new System.EventHandler(this.btnTablesSelectNone_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(687, 86);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnGenerate.TabIndex = 27;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(464, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Tables and Views";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Output Directory";
			// 
			// txtOutputDir
			// 
			this.txtOutputDir.Location = new System.Drawing.Point(101, 90);
			this.txtOutputDir.Name = "txtOutputDir";
			this.txtOutputDir.Size = new System.Drawing.Size(278, 20);
			this.txtOutputDir.TabIndex = 9;
			// 
			// chkPartial
			// 
			this.chkPartial.AutoSize = true;
			this.chkPartial.Checked = true;
			this.chkPartial.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPartial.Location = new System.Drawing.Point(100, 115);
			this.chkPartial.Name = "chkPartial";
			this.chkPartial.Size = new System.Drawing.Size(55, 17);
			this.chkPartial.TabIndex = 12;
			this.chkPartial.Text = "Partial";
			this.chkPartial.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 116);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Class Options";
			// 
			// chkPropChange
			// 
			this.chkPropChange.AutoSize = true;
			this.chkPropChange.Location = new System.Drawing.Point(161, 115);
			this.chkPropChange.Name = "chkPropChange";
			this.chkPropChange.Size = new System.Drawing.Size(98, 17);
			this.chkPropChange.TabIndex = 13;
			this.chkPropChange.Text = "PropertyEvents";
			this.chkPropChange.UseVisualStyleBackColor = true;
			// 
			// txtNameSpace
			// 
			this.txtNameSpace.Location = new System.Drawing.Point(101, 139);
			this.txtNameSpace.Name = "txtNameSpace";
			this.txtNameSpace.Size = new System.Drawing.Size(289, 20);
			this.txtNameSpace.TabIndex = 16;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(25, 142);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Namespace";
			// 
			// chkValidation
			// 
			this.chkValidation.AutoSize = true;
			this.chkValidation.Location = new System.Drawing.Point(265, 115);
			this.chkValidation.Name = "chkValidation";
			this.chkValidation.Size = new System.Drawing.Size(72, 17);
			this.chkValidation.TabIndex = 14;
			this.chkValidation.Text = "Validation";
			this.chkValidation.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus,
            this.tsProgressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 403);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(774, 22);
			this.statusStrip1.TabIndex = 29;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsStatus
			// 
			this.tsStatus.Name = "tsStatus";
			this.tsStatus.Size = new System.Drawing.Size(657, 17);
			this.tsStatus.Spring = true;
			// 
			// tsProgressBar
			// 
			this.tsProgressBar.Name = "tsProgressBar";
			this.tsProgressBar.Size = new System.Drawing.Size(100, 16);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(687, 115);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 28;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// chkLbTemplates
			// 
			this.chkLbTemplates.CheckOnClick = true;
			this.chkLbTemplates.FormattingEnabled = true;
			this.chkLbTemplates.Location = new System.Drawing.Point(16, 189);
			this.chkLbTemplates.Name = "chkLbTemplates";
			this.chkLbTemplates.Size = new System.Drawing.Size(295, 154);
			this.chkLbTemplates.Sorted = true;
			this.chkLbTemplates.TabIndex = 18;
			// 
			// btnTemplatesSelectNone
			// 
			this.btnTemplatesSelectNone.Location = new System.Drawing.Point(317, 218);
			this.btnTemplatesSelectNone.Name = "btnTemplatesSelectNone";
			this.btnTemplatesSelectNone.Size = new System.Drawing.Size(75, 23);
			this.btnTemplatesSelectNone.TabIndex = 20;
			this.btnTemplatesSelectNone.Text = "Select None";
			this.btnTemplatesSelectNone.UseVisualStyleBackColor = true;
			this.btnTemplatesSelectNone.Click += new System.EventHandler(this.btnTemplatesSelectNone_Click);
			// 
			// btnTemplatesSelectAll
			// 
			this.btnTemplatesSelectAll.Location = new System.Drawing.Point(317, 189);
			this.btnTemplatesSelectAll.Name = "btnTemplatesSelectAll";
			this.btnTemplatesSelectAll.Size = new System.Drawing.Size(75, 23);
			this.btnTemplatesSelectAll.TabIndex = 19;
			this.btnTemplatesSelectAll.Text = "Select All";
			this.btnTemplatesSelectAll.UseVisualStyleBackColor = true;
			this.btnTemplatesSelectAll.Click += new System.EventHandler(this.btnTemplatesSelectAll_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 170);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Templates";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(385, 90);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 10;
			this.btnBrowse.Text = "Browse ...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 67);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "User / Pass";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(101, 64);
			this.txtUserName.MaxLength = 60;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(136, 20);
			this.txtUserName.TabIndex = 5;
			this.toolTip1.SetToolTip(this.txtUserName, "Leave Username blank to use Windows integrated security");
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(243, 64);
			this.txtPassword.MaxLength = 60;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(136, 20);
			this.txtPassword.TabIndex = 6;
			// 
			// txtExclusionPrefix
			// 
			this.txtFilterPrefix.Location = new System.Drawing.Point(551, 348);
			this.txtFilterPrefix.Name = "txtExclusionPrefix";
			this.txtFilterPrefix.Size = new System.Drawing.Size(130, 20);
			this.txtFilterPrefix.TabIndex = 24;
			this.toolTip1.SetToolTip(this.txtFilterPrefix, "Any table starting with the specified prefix will be ignored");
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(464, 351);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(58, 13);
			this.label9.TabIndex = 23;
			this.label9.Text = "Filter Prefix";
			// 
			// chkIncludeFilter
			// 
			this.chkIncludeFilter.AutoSize = true;
			this.chkIncludeFilter.Location = new System.Drawing.Point(462, 328);
			this.chkIncludeFilter.Name = "chkIncludeFilter";
			this.chkIncludeFilter.Size = new System.Drawing.Size(86, 17);
			this.chkIncludeFilter.TabIndex = 30;
			this.chkIncludeFilter.Text = "Include Filter";
			this.toolTip1.SetToolTip(this.chkIncludeFilter, "Include or Exclude tables starting with the filter prefix");
			this.chkIncludeFilter.UseVisualStyleBackColor = true;
			// 
			// GeneratorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 425);
			this.Controls.Add(this.chkIncludeFilter);
			this.Controls.Add(this.txtFilterPrefix);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnTemplatesSelectNone);
			this.Controls.Add(this.btnTemplatesSelectAll);
			this.Controls.Add(this.chkLbTemplates);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.chkValidation);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtNameSpace);
			this.Controls.Add(this.chkPropChange);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.chkPartial);
			this.Controls.Add(this.txtOutputDir);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.btnTablesSelectNone);
			this.Controls.Add(this.btnTablesSelectAll);
			this.Controls.Add(this.chkLbTables);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtDatabase);
			this.Controls.Add(this.txtServer);
			this.Controls.Add(this.btnConnect);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "GeneratorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Active Record Class Generator";
			this.Load += new System.EventHandler(this.GeneratorForm_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckedListBox chkLbTables;
		private System.Windows.Forms.Button btnTablesSelectAll;
		private System.Windows.Forms.Button btnTablesSelectNone;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtOutputDir;
		private System.Windows.Forms.CheckBox chkPartial;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkPropChange;
		private System.Windows.Forms.TextBox txtNameSpace;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkValidation;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tsStatus;
		private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckedListBox chkLbTemplates;
		private System.Windows.Forms.Button btnTemplatesSelectNone;
		private System.Windows.Forms.Button btnTemplatesSelectAll;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtFilterPrefix;
		private System.Windows.Forms.CheckBox chkIncludeFilter;
	}
}

