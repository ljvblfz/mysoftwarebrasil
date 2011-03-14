namespace OnPlaceMovel.Source.Forms {
    partial class FormHistoricoConsumo {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.lbListaHistorico = new System.Windows.Forms.ListBox();
			this.lblHistorico = new System.Windows.Forms.Label();
			this.lblNumMatricula = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblMatricula = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbListaHistorico
			// 
			this.lbListaHistorico.Location = new System.Drawing.Point(15, 38);
			this.lbListaHistorico.Name = "lbListaHistorico";
			this.lbListaHistorico.Size = new System.Drawing.Size(212, 198);
			this.lbListaHistorico.TabIndex = 0;
			// 
			// lblHistorico
			// 
			this.lblHistorico.Location = new System.Drawing.Point(15, 20);
			this.lblHistorico.Name = "lblHistorico";
			this.lblHistorico.Size = new System.Drawing.Size(210, 18);
			this.lblHistorico.Text = "Histórico (Referência - Consumo)";
			// 
			// lblNumMatricula
			// 
			this.lblNumMatricula.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.lblNumMatricula.Location = new System.Drawing.Point(15, 2);
			this.lblNumMatricula.Name = "lblNumMatricula";
			this.lblNumMatricula.Size = new System.Drawing.Size(117, 13);
			this.lblNumMatricula.Text = "N° da Matrícula: ";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(15, 245);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 20);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			// 
			// lblMatricula
			// 
			this.lblMatricula.Location = new System.Drawing.Point(125, 2);
			this.lblMatricula.Name = "lblMatricula";
			this.lblMatricula.Size = new System.Drawing.Size(100, 13);
			this.lblMatricula.Text = "Sem Matricula";
			// 
			// FormHistoricoConsumo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.lblMatricula);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblNumMatricula);
			this.Controls.Add(this.lblHistorico);
			this.Controls.Add(this.lbListaHistorico);
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.Name = "FormHistoricoConsumo";
			this.Text = "OnPlaceMovel - Historico de Consumo";
			this.Activated += new System.EventHandler(this.FormHistoricoConsumo_Activated);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormHistoricoConsumo_KeyDown);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbListaHistorico;
        private System.Windows.Forms.Label lblHistorico;
        private System.Windows.Forms.Label lblNumMatricula;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMatricula;
    }
}