namespace SPCadMobileSync
{
    partial class FrmConfigSinc
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
            this.mItemConfirmar = new System.Windows.Forms.MenuItem();
            this.mItemVoltar = new System.Windows.Forms.MenuItem();
            this.title1 = new MobileTools.Controls.Title();
            this.lblWebService = new System.Windows.Forms.Label();
            this.lblUsuário = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.tbxWebService = new System.Windows.Forms.TextBox();
            this.tbxUsuario = new System.Windows.Forms.TextBox();
            this.tbxSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.tbxTmeOut = new System.Windows.Forms.TextBox();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mItemConfirmar);
            this.mainMenu1.MenuItems.Add(this.mItemVoltar);
            // 
            // mItemConfirmar
            // 
            this.mItemConfirmar.Text = "Confirmar";
            this.mItemConfirmar.Click += new System.EventHandler(this.mItemConfirmar_Click);
            // 
            // mItemVoltar
            // 
            this.mItemVoltar.Text = "Voltar";
            this.mItemVoltar.Click += new System.EventHandler(this.mItemVoltar_Click);
            // 
            // title1
            // 
            this.title1.ColorLine = System.Drawing.Color.OliveDrab;
            this.title1.DistanceWordLine = 2;
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title1.HeightLine = 10;
            this.title1.Location = new System.Drawing.Point(3, 3);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(234, 28);
            this.title1.TabIndex = 7;
            this.title1.Text = "Configuração WebService";
            this.title1.TextAlign = MobileTools.Controls.TypeTextAlign.Right;
            this.title1.TextColor = System.Drawing.SystemColors.WindowText;
            this.title1.WidthInclination = 10;
            // 
            // lblWebService
            // 
            this.lblWebService.Location = new System.Drawing.Point(3, 49);
            this.lblWebService.Name = "lblWebService";
            this.lblWebService.Size = new System.Drawing.Size(128, 20);
            this.lblWebService.Text = "WebService";
            // 
            // lblUsuário
            // 
            this.lblUsuário.Location = new System.Drawing.Point(3, 97);
            this.lblUsuário.Name = "lblUsuário";
            this.lblUsuário.Size = new System.Drawing.Size(100, 20);
            this.lblUsuário.Text = "Usuário";
            // 
            // lblSenha
            // 
            this.lblSenha.Location = new System.Drawing.Point(3, 145);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(100, 20);
            this.lblSenha.Text = "Senha";
            // 
            // tbxWebService
            // 
            this.tbxWebService.BackColor = System.Drawing.SystemColors.Info;
            this.tbxWebService.Location = new System.Drawing.Point(3, 70);
            this.tbxWebService.MaxLength = 300;
            this.tbxWebService.Name = "tbxWebService";
            this.tbxWebService.Size = new System.Drawing.Size(234, 21);
            this.tbxWebService.TabIndex = 13;
            // 
            // tbxUsuario
            // 
            this.tbxUsuario.BackColor = System.Drawing.SystemColors.Info;
            this.tbxUsuario.Location = new System.Drawing.Point(3, 118);
            this.tbxUsuario.MaxLength = 15;
            this.tbxUsuario.Name = "tbxUsuario";
            this.tbxUsuario.Size = new System.Drawing.Size(234, 21);
            this.tbxUsuario.TabIndex = 14;
            // 
            // tbxSenha
            // 
            this.tbxSenha.BackColor = System.Drawing.SystemColors.Info;
            this.tbxSenha.Location = new System.Drawing.Point(3, 166);
            this.tbxSenha.MaxLength = 256;
            this.tbxSenha.Name = "tbxSenha";
            this.tbxSenha.PasswordChar = '*';
            this.tbxSenha.Size = new System.Drawing.Size(234, 21);
            this.tbxSenha.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Serial PDA";
            // 
            // lblDevice
            // 
            this.lblDevice.BackColor = System.Drawing.SystemColors.Info;
            this.lblDevice.Location = new System.Drawing.Point(3, 266);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(234, 20);
            // 
            // tbxTmeOut
            // 
            this.tbxTmeOut.BackColor = System.Drawing.SystemColors.Info;
            this.tbxTmeOut.Location = new System.Drawing.Point(3, 214);
            this.tbxTmeOut.MaxLength = 3;
            this.tbxTmeOut.Name = "tbxTmeOut";
            this.tbxTmeOut.Size = new System.Drawing.Size(43, 21);
            this.tbxTmeOut.TabIndex = 20;
            this.tbxTmeOut.TextChanged += new System.EventHandler(this.tbxTmeOut_TextChanged);
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.Location = new System.Drawing.Point(3, 193);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(55, 20);
            this.lblTimeOut.Text = "TimeOut";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(47, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.Text = "Minuto(s)";
            // 
            // FrmConfigSinc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxTmeOut);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxSenha);
            this.Controls.Add(this.tbxUsuario);
            this.Controls.Add(this.tbxWebService);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblUsuário);
            this.Controls.Add(this.lblWebService);
            this.Controls.Add(this.title1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.Name = "FrmConfigSinc";
            this.Text = "FrmConfigSinc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mItemConfirmar;
        private System.Windows.Forms.MenuItem mItemVoltar;
        private MobileTools.Controls.Title title1;
        private System.Windows.Forms.Label lblWebService;
        private System.Windows.Forms.Label lblUsuário;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox tbxWebService;
        private System.Windows.Forms.TextBox tbxUsuario;
        private System.Windows.Forms.TextBox tbxSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.TextBox tbxTmeOut;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.Label label2;
    }
}