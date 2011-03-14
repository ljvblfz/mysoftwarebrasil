namespace OnPlaceMovel.Source.Forms
{
    partial class FormBD
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
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnDesfazerCarga = new System.Windows.Forms.Button();
			this.btnTesteImpressao = new System.Windows.Forms.Button();
			this.btnCopiarBase = new System.Windows.Forms.Button();
			this.btnExecutarTeste = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCancelar
			// 
			this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.btnCancelar.Location = new System.Drawing.Point(65, 104);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(111, 28);
			this.btnCancelar.TabIndex = 7;
			this.btnCancelar.Text = "Sair";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnDesfazerCarga
			// 
			this.btnDesfazerCarga.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.btnDesfazerCarga.Location = new System.Drawing.Point(3, 58);
			this.btnDesfazerCarga.Name = "btnDesfazerCarga";
			this.btnDesfazerCarga.Size = new System.Drawing.Size(111, 28);
			this.btnDesfazerCarga.TabIndex = 4;
			this.btnDesfazerCarga.Text = "Desfazer Carga";
			this.btnDesfazerCarga.Click += new System.EventHandler(this.btnDesfazerCarga_Click);
			// 
			// btnTesteImpressao
			// 
			this.btnTesteImpressao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.btnTesteImpressao.Location = new System.Drawing.Point(126, 58);
			this.btnTesteImpressao.Name = "btnTesteImpressao";
			this.btnTesteImpressao.Size = new System.Drawing.Size(111, 28);
			this.btnTesteImpressao.TabIndex = 5;
			this.btnTesteImpressao.Text = "Teste Impressão";
			this.btnTesteImpressao.Click += new System.EventHandler(this.btnTesteImpressao_Click);
			// 
			// btnCopiarBase
			// 
			this.btnCopiarBase.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.btnCopiarBase.Location = new System.Drawing.Point(3, 12);
			this.btnCopiarBase.Name = "btnCopiarBase";
			this.btnCopiarBase.Size = new System.Drawing.Size(111, 28);
			this.btnCopiarBase.TabIndex = 0;
			this.btnCopiarBase.Text = "Copiar Base";
			this.btnCopiarBase.Click += new System.EventHandler(this.btnCopiarBase_Click);
			// 
			// btnExecutarTeste
			// 
			this.btnExecutarTeste.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.btnExecutarTeste.Location = new System.Drawing.Point(126, 12);
			this.btnExecutarTeste.Name = "btnExecutarTeste";
			this.btnExecutarTeste.Size = new System.Drawing.Size(111, 28);
			this.btnExecutarTeste.TabIndex = 6;
			this.btnExecutarTeste.Text = "Executar Teste";
			this.btnExecutarTeste.Click += new System.EventHandler(this.btnExecutarTeste_Click);
			// 
			// FormBD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.ControlBox = false;
			this.Controls.Add(this.btnExecutarTeste);
			this.Controls.Add(this.btnCopiarBase);
			this.Controls.Add(this.btnTesteImpressao);
			this.Controls.Add(this.btnDesfazerCarga);
			this.Controls.Add(this.btnCancelar);
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "FormBD";
			this.Text = "OnPlaceMovel - BD";
			this.Activated += new System.EventHandler(this.BD_Activated);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnDesfazerCarga;
        private System.Windows.Forms.Button btnTesteImpressao;
		private System.Windows.Forms.Button btnCopiarBase;
		private System.Windows.Forms.Button btnExecutarTeste;
    }
}