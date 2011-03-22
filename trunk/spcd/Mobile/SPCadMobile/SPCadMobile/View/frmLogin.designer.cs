namespace SPCadMobile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mItemEntrar = new System.Windows.Forms.MenuItem();
            this.mItemOpcoes = new System.Windows.Forms.MenuItem();
            this.mItemReceberEnviar = new System.Windows.Forms.MenuItem();
            this.mItemSair = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.tbxLogin = new System.Windows.Forms.TextBox();
            this.tbxSenha = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.title1 = new MobileTools.Controls.Title();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mItemEntrar);
            this.mainMenu1.MenuItems.Add(this.mItemOpcoes);
            // 
            // mItemEntrar
            // 
            this.mItemEntrar.Text = "Entrar";
            this.mItemEntrar.Click += new System.EventHandler(this.mItemEntrar_Click);
            // 
            // mItemOpcoes
            // 
            this.mItemOpcoes.MenuItems.Add(this.mItemReceberEnviar);
            this.mItemOpcoes.MenuItems.Add(this.mItemSair);
            this.mItemOpcoes.Text = "Opções";
            // 
            // mItemReceberEnviar
            // 
            this.mItemReceberEnviar.Text = "Receber / Enviar";
            this.mItemReceberEnviar.Click += new System.EventHandler(this.mItemReceberEnviar_Click);
            // 
            // mItemSair
            // 
            this.mItemSair.Text = "Sair";
            this.mItemSair.Click += new System.EventHandler(this.mItemSair_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(140, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(140, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblTitulo.Location = new System.Drawing.Point(3, 51);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(101, 67);
            this.lblTitulo.Text = "Sistema de Pesquisa Cadastral";
            // 
            // lblLogin
            // 
            this.lblLogin.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lblLogin.Location = new System.Drawing.Point(54, 124);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(100, 20);
            this.lblLogin.Text = "Login:";
            // 
            // lblSenha
            // 
            this.lblSenha.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lblSenha.Location = new System.Drawing.Point(54, 172);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(100, 20);
            this.lblSenha.Text = "Senha:";
            // 
            // tbxLogin
            // 
            this.tbxLogin.BackColor = System.Drawing.SystemColors.Info;
            this.tbxLogin.Location = new System.Drawing.Point(54, 144);
            this.tbxLogin.MaxLength = 10;
            this.tbxLogin.Name = "tbxLogin";
            this.tbxLogin.Size = new System.Drawing.Size(141, 21);
            this.tbxLogin.TabIndex = 1;
            // 
            // tbxSenha
            // 
            this.tbxSenha.BackColor = System.Drawing.SystemColors.Info;
            this.tbxSenha.Location = new System.Drawing.Point(54, 191);
            this.tbxSenha.MaxLength = 10;
            this.tbxSenha.Name = "tbxSenha";
            this.tbxSenha.PasswordChar = '*';
            this.tbxSenha.Size = new System.Drawing.Size(141, 21);
            this.tbxSenha.TabIndex = 2;
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(70, 257);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(170, 21);
            this.lblData.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblVersao
            // 
            this.lblVersao.Location = new System.Drawing.Point(140, 274);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(100, 20);
            this.lblVersao.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // title1
            // 
            this.title1.ColorLine = System.Drawing.Color.OliveDrab;
            this.title1.DistanceWordLine = 5;
            this.title1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.title1.HeightLine = 5;
            this.title1.Location = new System.Drawing.Point(0, 3);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(116, 47);
            this.title1.TabIndex = 0;
            this.title1.Text = "S.P.Cad";
            this.title1.TextAlign = MobileTools.Controls.TypeTextAlign.Right;
            this.title1.TextColor = System.Drawing.SystemColors.WindowText;
            this.title1.WidthInclination = 10;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.title1);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.tbxSenha);
            this.Controls.Add(this.tbxLogin);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox tbxLogin;
        private System.Windows.Forms.TextBox tbxSenha;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.MenuItem mItemEntrar;
        private MobileTools.Controls.Title title1;
        private System.Windows.Forms.MenuItem mItemOpcoes;
        private System.Windows.Forms.MenuItem mItemReceberEnviar;
        private System.Windows.Forms.MenuItem mItemSair;
    }
}