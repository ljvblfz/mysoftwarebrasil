namespace OnPlaceMovel.Source.Forms {
	partial class FormConfirmaSenha {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mainMenu;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.txtSenha = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(121, 48);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(88, 20);
			this.btnCancelar.TabIndex = 2;
			this.btnCancelar.Text = "Cancelar";
			// 
			// txtSenha
			// 
			this.txtSenha.Location = new System.Drawing.Point(22, 20);
			this.txtSenha.MaxLength = 40;
			this.txtSenha.Name = "txtSenha";
			this.txtSenha.PasswordChar = '*';
			this.txtSenha.Size = new System.Drawing.Size(187, 21);
			this.txtSenha.TabIndex = 0;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(22, 48);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(88, 20);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			// 
			// lblInfo
			// 
			this.lblInfo.Location = new System.Drawing.Point(17, 0);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(206, 14);
			this.lblInfo.Text = "Confirme a senha:";
			// 
			// FormConfirmaSenha
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.ControlBox = false;
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.txtSenha);
			this.Controls.Add(this.btnOk);
			this.KeyPreview = true;
			this.Menu = this.mainMenu;
			this.MinimizeBox = false;
			this.Name = "FormConfirmaSenha";
			this.Text = "OnPlaceMovel - Confirme senha";
			this.Activated += new System.EventHandler(this.FormSenhaAdm_Activated);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormSenhaAdm_Closing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TextBox txtSenha;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblInfo;
	}
}