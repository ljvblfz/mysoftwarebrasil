namespace OnPlaceMovel.Source.Forms
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblCodigoAgente = new System.Windows.Forms.Label();
			this.lblSenha = new System.Windows.Forms.Label();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.txtSenha = new System.Windows.Forms.TextBox();
			this.btnSair = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.lblRoteiro = new System.Windows.Forms.Label();
			this.lblRoteiroValor = new System.Windows.Forms.Label();
			this.lblVersaoValor = new System.Windows.Forms.Label();
			this.onpAgenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.lblVersao = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(24, 152);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(88, 20);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblCodigoAgente
			// 
			this.lblCodigoAgente.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.lblCodigoAgente.Location = new System.Drawing.Point(24, 63);
			this.lblCodigoAgente.Name = "lblCodigoAgente";
			this.lblCodigoAgente.Size = new System.Drawing.Size(88, 15);
			this.lblCodigoAgente.Text = "Código Agente";
			// 
			// lblSenha
			// 
			this.lblSenha.Location = new System.Drawing.Point(24, 107);
			this.lblSenha.Name = "lblSenha";
			this.lblSenha.Size = new System.Drawing.Size(40, 14);
			this.lblSenha.Text = "Senha";
			// 
			// txtUsuario
			// 
			this.txtUsuario.Location = new System.Drawing.Point(24, 81);
			this.txtUsuario.MaxLength = 40;
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(187, 21);
			this.txtUsuario.TabIndex = 0;
			// 
			// txtSenha
			// 
			this.txtSenha.Location = new System.Drawing.Point(24, 124);
			this.txtSenha.MaxLength = 40;
			this.txtSenha.Name = "txtSenha";
			this.txtSenha.PasswordChar = '*';
			this.txtSenha.Size = new System.Drawing.Size(187, 21);
			this.txtSenha.TabIndex = 1;
			// 
			// btnSair
			// 
			this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSair.Location = new System.Drawing.Point(123, 152);
			this.btnSair.Name = "btnSair";
			this.btnSair.Size = new System.Drawing.Size(88, 20);
			this.btnSair.TabIndex = 4;
			this.btnSair.Text = "Sair";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
			this.pictureBox.Location = new System.Drawing.Point(9, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(224, 36);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			// 
			// lblRoteiro
			// 
			this.lblRoteiro.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblRoteiro.Location = new System.Drawing.Point(9, 43);
			this.lblRoteiro.Name = "lblRoteiro";
			this.lblRoteiro.Size = new System.Drawing.Size(55, 15);
			this.lblRoteiro.Text = "Roteiro:";
			this.lblRoteiro.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblRoteiroValor
			// 
			this.lblRoteiroValor.Location = new System.Drawing.Point(64, 43);
			this.lblRoteiroValor.Name = "lblRoteiroValor";
			this.lblRoteiroValor.Size = new System.Drawing.Size(147, 15);
			this.lblRoteiroValor.Text = "Sem Roteiro";
			// 
			// lblVersaoValor
			// 
			this.lblVersaoValor.Location = new System.Drawing.Point(64, 176);
			this.lblVersaoValor.Name = "lblVersaoValor";
			this.lblVersaoValor.Size = new System.Drawing.Size(147, 15);
			this.lblVersaoValor.Text = "MUDAR NO CONFIGXML";
			// 
			// onpAgenteBindingSource
			// 
			this.onpAgenteBindingSource.DataSource = typeof(OnPlaceMovel.Source.Banco.OnpAgente);
			// 
			// lblVersao
			// 
			this.lblVersao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblVersao.Location = new System.Drawing.Point(9, 176);
			this.lblVersao.Name = "lblVersao";
			this.lblVersao.Size = new System.Drawing.Size(55, 15);
			this.lblVersao.Text = "Versão:";
			this.lblVersao.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// FormLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.ControlBox = false;
			this.Controls.Add(this.lblVersaoValor);
			this.Controls.Add(this.lblRoteiroValor);
			this.Controls.Add(this.lblVersao);
			this.Controls.Add(this.lblRoteiro);
			this.Controls.Add(this.btnSair);
			this.Controls.Add(this.txtSenha);
			this.Controls.Add(this.txtUsuario);
			this.Controls.Add(this.lblSenha);
			this.Controls.Add(this.lblCodigoAgente);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.pictureBox);
			this.KeyPreview = true;
			this.Menu = this.mainMenu;
			this.MinimizeBox = false;
			this.Name = "FormLogin";
			this.Text = "OnPlaceMovel - Login";
			this.Closed += new System.EventHandler(this.Login_Closed);
			this.Activated += new System.EventHandler(this.Login_Activated);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblCodigoAgente;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblRoteiro;
        private System.Windows.Forms.Label lblRoteiroValor;
        private System.Windows.Forms.Label lblVersaoValor;
		private System.Windows.Forms.BindingSource onpAgenteBindingSource;
        private System.Windows.Forms.Label lblVersao;


    }
}