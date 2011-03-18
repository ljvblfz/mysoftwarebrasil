namespace LTmobile.View
{
    partial class frmConfiguracao
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
            this.btnSalvar = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.txbWebService = new System.Windows.Forms.TextBox();
            this.lblWebService = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblIntervalo = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txbSenha = new System.Windows.Forms.TextBox();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.txbIntervalo = new System.Windows.Forms.TextBox();
            this.txbQuantidade = new System.Windows.Forms.TextBox();
            this.tlCofiguracao = new MobileTools.Controls.Title();
            this.chkLigarGps = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnSalvar);
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Sair";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // txbWebService
            // 
            this.txbWebService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txbWebService.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txbWebService.Location = new System.Drawing.Point(83, 30);
            this.txbWebService.Name = "txbWebService";
            this.txbWebService.Size = new System.Drawing.Size(137, 20);
            this.txbWebService.TabIndex = 0;
            // 
            // lblWebService
            // 
            this.lblWebService.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblWebService.Location = new System.Drawing.Point(4, 30);
            this.lblWebService.Name = "lblWebService";
            this.lblWebService.Size = new System.Drawing.Size(76, 22);
            this.lblWebService.Text = "WebService";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(3, 52);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(59, 22);
            this.lblUsuario.Text = "Usuário";
            // 
            // lblSenha
            // 
            this.lblSenha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblSenha.Location = new System.Drawing.Point(4, 75);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(59, 22);
            this.lblSenha.Text = "Senha";
            // 
            // lblIntervalo
            // 
            this.lblIntervalo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblIntervalo.Location = new System.Drawing.Point(4, 99);
            this.lblIntervalo.Name = "lblIntervalo";
            this.lblIntervalo.Size = new System.Drawing.Size(154, 22);
            this.lblIntervalo.Text = "Intervalo de Leitura";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuantidade.Location = new System.Drawing.Point(4, 122);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(154, 22);
            this.lblQuantidade.Text = "Qtd. Uc´s p/ Término";
            // 
            // txbSenha
            // 
            this.txbSenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txbSenha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txbSenha.Location = new System.Drawing.Point(83, 75);
            this.txbSenha.Name = "txbSenha";
            this.txbSenha.PasswordChar = '*';
            this.txbSenha.Size = new System.Drawing.Size(137, 20);
            this.txbSenha.TabIndex = 2;
            // 
            // txbUsuario
            // 
            this.txbUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txbUsuario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txbUsuario.Location = new System.Drawing.Point(83, 52);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(137, 20);
            this.txbUsuario.TabIndex = 1;
            // 
            // txbIntervalo
            // 
            this.txbIntervalo.BackColor = System.Drawing.SystemColors.Info;
            this.txbIntervalo.Font = new System.Drawing.Font("Segoe Condensed", 9F, System.Drawing.FontStyle.Regular);
            this.txbIntervalo.Location = new System.Drawing.Point(178, 99);
            this.txbIntervalo.Name = "txbIntervalo";
            this.txbIntervalo.Size = new System.Drawing.Size(42, 20);
            this.txbIntervalo.TabIndex = 3;
            this.txbIntervalo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbIntervalo_KeyPress);
            // 
            // txbQuantidade
            // 
            this.txbQuantidade.BackColor = System.Drawing.SystemColors.Info;
            this.txbQuantidade.Font = new System.Drawing.Font("Segoe Condensed", 9F, System.Drawing.FontStyle.Regular);
            this.txbQuantidade.Location = new System.Drawing.Point(178, 122);
            this.txbQuantidade.Name = "txbQuantidade";
            this.txbQuantidade.Size = new System.Drawing.Size(42, 20);
            this.txbQuantidade.TabIndex = 4;
            this.txbQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbQuantidade_KeyPress);
            // 
            // tlCofiguracao
            // 
            this.tlCofiguracao.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlCofiguracao.DistanceWordLine = 2;
            this.tlCofiguracao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlCofiguracao.HeightLine = 10;
            this.tlCofiguracao.Location = new System.Drawing.Point(0, 0);
            this.tlCofiguracao.Name = "tlCofiguracao";
            this.tlCofiguracao.Size = new System.Drawing.Size(224, 28);
            this.tlCofiguracao.TabIndex = 17;
            this.tlCofiguracao.Text = "Configuração - Sincronização/Gps";
            this.tlCofiguracao.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlCofiguracao.WidthInclination = 10;
            // 
            // chkLigarGps
            // 
            this.chkLigarGps.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.chkLigarGps.Location = new System.Drawing.Point(4, 140);
            this.chkLigarGps.Name = "chkLigarGps";
            this.chkLigarGps.Size = new System.Drawing.Size(172, 19);
            this.chkLigarGps.TabIndex = 5;
            this.chkLigarGps.Text = "Ligar Gps/Sincronização";
            // 
            // frmConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.chkLigarGps);
            this.Controls.Add(this.txbQuantidade);
            this.Controls.Add(this.txbIntervalo);
            this.Controls.Add(this.txbUsuario);
            this.Controls.Add(this.txbSenha);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblIntervalo);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblWebService);
            this.Controls.Add(this.txbWebService);
            this.Controls.Add(this.tlCofiguracao);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmConfiguracao";
            this.Text = "frmConfiguracao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmConfiguracao_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfiguracao_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlCofiguracao;
        private System.Windows.Forms.TextBox txbWebService;
        private System.Windows.Forms.Label lblWebService;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblIntervalo;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txbSenha;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.TextBox txbIntervalo;
        private System.Windows.Forms.TextBox txbQuantidade;
        private System.Windows.Forms.MenuItem btnSalvar;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.CheckBox chkLigarGps;
    }
}