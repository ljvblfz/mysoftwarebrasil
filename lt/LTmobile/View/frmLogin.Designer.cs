namespace LTmobile
{
    partial class frmLogin
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
            this.btnEntrar = new System.Windows.Forms.MenuItem();
            this.btnMenu = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnSincronizar = new System.Windows.Forms.MenuItem();
            this.mnSair = new System.Windows.Forms.MenuItem();
            this.lblVersao = new System.Windows.Forms.Label();
            this.txbSenha = new System.Windows.Forms.TextBox();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.tmHoraAtual = new System.Windows.Forms.Timer();
            this.txbHora = new System.Windows.Forms.TextBox();
            this.tlLogin = new MobileTools.Controls.Title();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnEntrar);
            this.mainMenu1.MenuItems.Add(this.btnMenu);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.MenuItems.Add(this.menuItem1);
            this.btnMenu.MenuItems.Add(this.mnSincronizar);
            this.btnMenu.MenuItems.Add(this.mnSair);
            this.btnMenu.Text = "Menu";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Atualizar Versão";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // mnSincronizar
            // 
            this.mnSincronizar.Text = "Sincronizar";
            this.mnSincronizar.Click += new System.EventHandler(this.mnSincronizar_Click);
            // 
            // mnSair
            // 
            this.mnSair.Text = "Fechar";
            this.mnSair.Click += new System.EventHandler(this.mnSair_Click);
            // 
            // lblVersao
            // 
            this.lblVersao.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblVersao.Location = new System.Drawing.Point(45, 133);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(124, 22);
            this.lblVersao.Text = "Versão";
            // 
            // txbSenha
            // 
            this.txbSenha.BackColor = System.Drawing.SystemColors.Info;
            this.txbSenha.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.txbSenha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbSenha.Location = new System.Drawing.Point(45, 103);
            this.txbSenha.MaxLength = 8;
            this.txbSenha.Name = "txbSenha";
            this.txbSenha.PasswordChar = '*';
            this.txbSenha.Size = new System.Drawing.Size(124, 22);
            this.txbSenha.TabIndex = 16;
            this.txbSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txbUsuario
            // 
            this.txbUsuario.BackColor = System.Drawing.SystemColors.Info;
            this.txbUsuario.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.txbUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbUsuario.Location = new System.Drawing.Point(45, 52);
            this.txbUsuario.MaxLength = 3;
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(124, 22);
            this.txbUsuario.TabIndex = 15;
            this.txbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lblSenha
            // 
            this.lblSenha.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSenha.Location = new System.Drawing.Point(45, 85);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(124, 22);
            this.lblSenha.Text = "Senha";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(45, 31);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(124, 22);
            this.lblUsuario.Text = "Usuário";
            // 
            // tmHoraAtual
            // 
            this.tmHoraAtual.Enabled = true;
            this.tmHoraAtual.Interval = 1000;
            this.tmHoraAtual.Tick += new System.EventHandler(this.tmHoraAtual_Tick);
            // 
            // txbHora
            // 
            this.txbHora.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txbHora.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txbHora.Location = new System.Drawing.Point(176, 30);
            this.txbHora.Name = "txbHora";
            this.txbHora.Size = new System.Drawing.Size(45, 22);
            this.txbHora.TabIndex = 19;
            this.txbHora.TabStop = false;
            // 
            // tlLogin
            // 
            this.tlLogin.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlLogin.DistanceWordLine = 2;
            this.tlLogin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlLogin.HeightLine = 10;
            this.tlLogin.Location = new System.Drawing.Point(0, 0);
            this.tlLogin.Name = "tlLogin";
            this.tlLogin.Size = new System.Drawing.Size(224, 28);
            this.tlLogin.TabIndex = 11;
            this.tlLogin.Text = "Login";
            this.tlLogin.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlLogin.WidthInclination = 10;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbHora);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.txbSenha);
            this.Controls.Add(this.txbUsuario);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.tlLogin);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmLogin";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlLogin;
        private System.Windows.Forms.MenuItem btnEntrar;
        private System.Windows.Forms.MenuItem btnMenu;
        private System.Windows.Forms.MenuItem mnSincronizar;
        private System.Windows.Forms.MenuItem mnSair;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.TextBox txbSenha;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Timer tmHoraAtual;
        private System.Windows.Forms.TextBox txbHora;
        private System.Windows.Forms.MenuItem menuItem1;

    }
}

