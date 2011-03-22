namespace SPCadMobileSync
{
    partial class frmSincronizacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSincronizacao));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.cbxSincroInicial = new System.Windows.Forms.CheckBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemSincronizar = new System.Windows.Forms.MenuItem();
            this.menuItemSair = new System.Windows.Forms.MenuItem();
            this.uBtnCfgWebService = new MobileTools.Controls.UltraButton();
            this.title1 = new MobileTools.Controls.Title();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 280);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 14);
            // 
            // tbxLog
            // 
            this.tbxLog.Location = new System.Drawing.Point(3, 62);
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxLog.Size = new System.Drawing.Size(233, 211);
            this.tbxLog.TabIndex = 24;
            this.tbxLog.Text = " ";
            this.tbxLog.TextChanged += new System.EventHandler(this.tbxLog_TextChanged);
            // 
            // cbxSincroInicial
            // 
            this.cbxSincroInicial.Location = new System.Drawing.Point(3, 36);
            this.cbxSincroInicial.Name = "cbxSincroInicial";
            this.cbxSincroInicial.Size = new System.Drawing.Size(145, 20);
            this.cbxSincroInicial.TabIndex = 23;
            this.cbxSincroInicial.Text = "Sincronização Inicial.";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemSincronizar);
            this.mainMenu1.MenuItems.Add(this.menuItemSair);
            // 
            // menuItemSincronizar
            // 
            this.menuItemSincronizar.Text = "Sincronizar";
            this.menuItemSincronizar.Click += new System.EventHandler(this.menuItemSincronizar_Click);
            // 
            // menuItemSair
            // 
            this.menuItemSair.Text = "Sair";
            this.menuItemSair.Click += new System.EventHandler(this.menuItemSair_Click);
            // 
            // uBtnCfgWebService
            // 
            this.uBtnCfgWebService.BorderColor = System.Drawing.Color.Transparent;
            this.uBtnCfgWebService.ButtonColor = System.Drawing.Color.White;
            this.uBtnCfgWebService.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.uBtnCfgWebService.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("uBtnCfgWebService.ImageButton")));
            this.uBtnCfgWebService.ImageButtonView = true;
            this.uBtnCfgWebService.Location = new System.Drawing.Point(207, 34);
            this.uBtnCfgWebService.Name = "uBtnCfgWebService";
            this.uBtnCfgWebService.Radius = 8;
            this.uBtnCfgWebService.Size = new System.Drawing.Size(28, 24);
            this.uBtnCfgWebService.TabIndex = 25;
            this.uBtnCfgWebService.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.uBtnCfgWebService.TextColor = System.Drawing.SystemColors.WindowText;
            this.uBtnCfgWebService.TextColorClick = System.Drawing.Color.White;
            this.uBtnCfgWebService.Click += new System.EventHandler(this.uBtnCfgWebService_Click);
            // 
            // title1
            // 
            this.title1.ColorLine = System.Drawing.Color.OliveDrab;
            this.title1.DistanceWordLine = 2;
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title1.HeightLine = 10;
            this.title1.Location = new System.Drawing.Point(2, 2);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(237, 28);
            this.title1.TabIndex = 22;
            this.title1.Text = "Sincronização";
            this.title1.TextAlign = MobileTools.Controls.TypeTextAlign.Right;
            this.title1.TextColor = System.Drawing.SystemColors.WindowText;
            this.title1.WidthInclination = 10;
            // 
            // frmSincronizacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.uBtnCfgWebService);
            this.Controls.Add(this.tbxLog);
            this.Controls.Add(this.cbxSincroInicial);
            this.Controls.Add(this.title1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.Name = "frmSincronizacao";
            this.Text = "frmSincronizacao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private MobileTools.Controls.UltraButton uBtnCfgWebService;
        private System.Windows.Forms.TextBox tbxLog;
        private System.Windows.Forms.CheckBox cbxSincroInicial;
        private MobileTools.Controls.Title title1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemSincronizar;
        private System.Windows.Forms.MenuItem menuItemSair;
    }
}