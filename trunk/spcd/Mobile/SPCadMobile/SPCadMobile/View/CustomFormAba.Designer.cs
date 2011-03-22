namespace SPCadMobile.View
{
    partial class CustomFormAba
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
        public void InitializeComponent()
        {
            this.title1 = new MobileTools.Controls.Title();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.title = new MobileTools.Controls.Title();
            this.TecladoinputPanel = new Microsoft.WindowsCE.Forms.InputPanel();
            this.chkConfirmado = new System.Windows.Forms.CheckBox();
            this.lblAlterado = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.ColorLine = System.Drawing.Color.OliveDrab;
            this.title1.DistanceWordLine = 2;
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title1.HeightLine = 10;
            this.title1.Location = new System.Drawing.Point(0, 2);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(240, 28);
            this.title1.TabIndex = 24;
            this.title1.Text = "Dados Economias";
            this.title1.TextAlign = MobileTools.Controls.TypeTextAlign.Right;
            this.title1.TextColor = System.Drawing.SystemColors.WindowText;
            this.title1.WidthInclination = 10;
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.menuItem1);
            this.mainMenu.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Editar";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Voltar";
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.title.ColorLine = System.Drawing.Color.OliveDrab;
            this.title.DistanceWordLine = 2;
            this.title.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title.HeightLine = 10;
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(240, 28);
            this.title.TabIndex = 26;
            this.title.Text = "Titulo";
            this.title.TextAlign = MobileTools.Controls.TypeTextAlign.Right;
            this.title.TextColor = System.Drawing.SystemColors.WindowText;
            this.title.WidthInclination = 10;
            // 
            // TecladoinputPanel
            // 
            this.TecladoinputPanel.EnabledChanged += new System.EventHandler(this.TecladoinputPanel_EnabledChanged_1);
            // 
            // chkConfirmado
            // 
            this.chkConfirmado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkConfirmado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chkConfirmado.Location = new System.Drawing.Point(140, 1);
            this.chkConfirmado.Name = "chkConfirmado";
            this.chkConfirmado.Size = new System.Drawing.Size(90, 15);
            this.chkConfirmado.TabIndex = 29;
            this.chkConfirmado.Text = "Confirmado ";
            this.chkConfirmado.Visible = false;
            this.chkConfirmado.CheckStateChanged += new System.EventHandler(this.chkConfirmado_CheckStateChanged);
            // 
            // lblAlterado
            // 
            this.lblAlterado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlterado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblAlterado.ForeColor = System.Drawing.Color.Black;
            this.lblAlterado.Location = new System.Drawing.Point(140, 1);
            this.lblAlterado.Name = "lblAlterado";
            this.lblAlterado.Size = new System.Drawing.Size(90, 16);
            this.lblAlterado.Text = "Alterado";
            this.lblAlterado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblAlterado.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(239, 259);
            this.tabControl1.TabIndex = 31;
            // 
            // CustomFormAba
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblAlterado);
            this.Controls.Add(this.chkConfirmado);
            this.Controls.Add(this.title);
            this.Controls.Add(this.title1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu;
            this.Name = "CustomFormAba";
            this.Text = "Teste";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public MobileTools.Controls.Title title1;
        public System.Windows.Forms.MenuItem menuItem1;
        public System.Windows.Forms.MenuItem menuItem2;
        private MobileTools.Controls.Title title;
        public System.Windows.Forms.MainMenu mainMenu;
        private Microsoft.WindowsCE.Forms.InputPanel TecladoinputPanel;
        public System.Windows.Forms.CheckBox chkConfirmado;
        public System.Windows.Forms.Label lblAlterado;
        public System.Windows.Forms.TabControl tabControl1;

    }
}