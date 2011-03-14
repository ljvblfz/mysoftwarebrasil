namespace OnPlaceMovel.Source.Forms {
	partial class FormFormaEntrega {
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

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
			this.lstFormaEntrega = new System.Windows.Forms.ListBox();
			this.btnConfirma = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.SuspendLayout();
			// 
			// lstFormaEntrega
			// 
			this.lstFormaEntrega.Location = new System.Drawing.Point(3, 30);
			this.lstFormaEntrega.Name = "lstFormaEntrega";
			this.lstFormaEntrega.Size = new System.Drawing.Size(234, 198);
			this.lstFormaEntrega.TabIndex = 0;
			// 
			// btnConfirma
			// 
			this.btnConfirma.Location = new System.Drawing.Point(84, 234);
			this.btnConfirma.Name = "btnConfirma";
			this.btnConfirma.Size = new System.Drawing.Size(72, 31);
			this.btnConfirma.TabIndex = 2;
			this.btnConfirma.Text = "Confirma";
			this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.lblInfo.Location = new System.Drawing.Point(3, 0);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(237, 30);
			this.lblInfo.Text = "Selecione a forma de entrega na lista a baixo:";
			// 
			// FormFormaEntrega
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.ControlBox = false;
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.btnConfirma);
			this.Controls.Add(this.lstFormaEntrega);
			this.KeyPreview = true;
			this.Menu = this.mainMenu;
			this.MinimizeBox = false;
			this.Name = "FormFormaEntrega";
			this.Text = "OnPlaceMovel - Forma de entregua";
			this.Activated += new System.EventHandler(this.FormaEntrega_Activated);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFormaEntrega_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lstFormaEntrega;
		private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.MainMenu mainMenu;
	}
}