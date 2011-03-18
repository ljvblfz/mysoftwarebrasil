namespace LTmobile.View
{
    partial class frmSincronizacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.nmSair2 = new System.Windows.Forms.MenuItem();
            this.mnSincInicial = new System.Windows.Forms.MenuItem();
            this.mnConfigurar = new System.Windows.Forms.MenuItem();
            this.mnSair = new System.Windows.Forms.MenuItem();
            this.txbSincronizacao = new System.Windows.Forms.TextBox();
            this.pgbSincronizacao = new System.Windows.Forms.ProgressBar();
            this.tlSincronizacao = new MobileTools.Controls.Title();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.nmSair2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Sincronizar";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // nmSair2
            // 
            this.nmSair2.MenuItems.Add(this.mnSincInicial);
            this.nmSair2.MenuItems.Add(this.mnConfigurar);
            this.nmSair2.MenuItems.Add(this.mnSair);
            this.nmSair2.Text = "Menu";
            this.nmSair2.Click += new System.EventHandler(this.nmSair2_Click);
            // 
            // mnSincInicial
            // 
            this.mnSincInicial.Text = "Sincronização Inicial";
            this.mnSincInicial.Click += new System.EventHandler(this.mnSincInicial_Click);
            // 
            // mnConfigurar
            // 
            this.mnConfigurar.Text = "Configurar";
            this.mnConfigurar.Click += new System.EventHandler(this.mnConfigurar_Click);
            // 
            // mnSair
            // 
            this.mnSair.Text = "Sair";
            this.mnSair.Click += new System.EventHandler(this.mnSair_Click);
            // 
            // txbSincronizacao
            // 
            this.txbSincronizacao.Location = new System.Drawing.Point(4, 35);
            this.txbSincronizacao.Multiline = true;
            this.txbSincronizacao.Name = "txbSincronizacao";
            this.txbSincronizacao.Size = new System.Drawing.Size(204, 95);
            this.txbSincronizacao.TabIndex = 17;
            // 
            // pgbSincronizacao
            // 
            this.pgbSincronizacao.Location = new System.Drawing.Point(4, 148);
            this.pgbSincronizacao.Name = "pgbSincronizacao";
            this.pgbSincronizacao.Size = new System.Drawing.Size(204, 22);
            // 
            // tlSincronizacao
            // 
            this.tlSincronizacao.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlSincronizacao.DistanceWordLine = 2;
            this.tlSincronizacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlSincronizacao.HeightLine = 10;
            this.tlSincronizacao.Location = new System.Drawing.Point(0, 0);
            this.tlSincronizacao.Name = "tlSincronizacao";
            this.tlSincronizacao.Size = new System.Drawing.Size(224, 28);
            this.tlSincronizacao.TabIndex = 16;
            this.tlSincronizacao.Text = "Sincronização";
            this.tlSincronizacao.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlSincronizacao.WidthInclination = 10;
            // 
            // frmSincronizacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.pgbSincronizacao);
            this.Controls.Add(this.txbSincronizacao);
            this.Controls.Add(this.tlSincronizacao);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmSincronizacao";
            this.Text = "frmSincronizacao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSincronizacao_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmSincronizacao_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSincronizacao_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlSincronizacao;
        private System.Windows.Forms.TextBox txbSincronizacao;
        private System.Windows.Forms.ProgressBar pgbSincronizacao;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem nmSair2;
        private System.Windows.Forms.MenuItem mnConfigurar;
        private System.Windows.Forms.MenuItem mnSair;
        private System.Windows.Forms.MenuItem mnSincInicial;
    }
}