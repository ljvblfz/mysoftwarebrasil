namespace OnPlaceMovel.Source.Forms {
	partial class FormAgenteCarga {
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
			if ( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblCodigoAgente = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(126, 54);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 20);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(27, 27);
            this.txtUsuario.MaxLength = 40;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(187, 21);
            this.txtUsuario.TabIndex = 6;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // lblCodigoAgente
            // 
            this.lblCodigoAgente.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCodigoAgente.Location = new System.Drawing.Point(27, 9);
            this.lblCodigoAgente.Name = "lblCodigoAgente";
            this.lblCodigoAgente.Size = new System.Drawing.Size(88, 15);
            this.lblCodigoAgente.Text = "Código Agente";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(25, 54);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(88, 20);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            // 
            // FormAgenteCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblCodigoAgente);
            this.Controls.Add(this.btnOk);
            this.KeyPreview = true;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "FormAgenteCarga";
            this.Text = "FormAgenteCarga";
            this.Activated += new System.EventHandler(this.FormAgenteCarga_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAgenteCarga_KeyDown);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.Label lblCodigoAgente;
		private System.Windows.Forms.Button btnOk;
	}
}