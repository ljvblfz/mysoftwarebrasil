namespace OnPlaceMovel.Source.Forms {
	partial class FormOcorrenciaNovo {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
            this.txtCodigoOcorrencia = new System.Windows.Forms.TextBox();
            this.cboxOcorrencias = new System.Windows.Forms.ComboBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.lstOcorrenciasCadastradas = new System.Windows.Forms.ListBox();
            this.lblInfoHidrometro = new System.Windows.Forms.Label();
            this.lblHidrometro = new System.Windows.Forms.Label();
            this.btnRemover = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblOcorrenciasCadastradas = new System.Windows.Forms.Label();
            this.lblOcorrencias = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCodigoOcorrencia
            // 
            this.txtCodigoOcorrencia.Enabled = false;
            this.txtCodigoOcorrencia.Location = new System.Drawing.Point(3, 33);
            this.txtCodigoOcorrencia.MaxLength = 2;
            this.txtCodigoOcorrencia.Name = "txtCodigoOcorrencia";
            this.txtCodigoOcorrencia.Size = new System.Drawing.Size(22, 21);
            this.txtCodigoOcorrencia.TabIndex = 0;
            this.txtCodigoOcorrencia.TextChanged += new System.EventHandler(this.txtCodigoOcorrencia_TextChanged);
            // 
            // cboxOcorrencias
            // 
            this.cboxOcorrencias.Location = new System.Drawing.Point(31, 32);
            this.cboxOcorrencias.Name = "cboxOcorrencias";
            this.cboxOcorrencias.Size = new System.Drawing.Size(206, 22);
            this.cboxOcorrencias.TabIndex = 1;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(139, 60);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(98, 27);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // lstOcorrenciasCadastradas
            // 
            this.lstOcorrenciasCadastradas.Location = new System.Drawing.Point(3, 109);
            this.lstOcorrenciasCadastradas.Name = "lstOcorrenciasCadastradas";
            this.lstOcorrenciasCadastradas.Size = new System.Drawing.Size(234, 114);
            this.lstOcorrenciasCadastradas.TabIndex = 3;
            // 
            // lblInfoHidrometro
            // 
            this.lblInfoHidrometro.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoHidrometro.Location = new System.Drawing.Point(3, 0);
            this.lblInfoHidrometro.Name = "lblInfoHidrometro";
            this.lblInfoHidrometro.Size = new System.Drawing.Size(80, 14);
            this.lblInfoHidrometro.Text = "Hidrometro:";
            // 
            // lblHidrometro
            // 
            this.lblHidrometro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHidrometro.Location = new System.Drawing.Point(79, 0);
            this.lblHidrometro.Name = "lblHidrometro";
            this.lblHidrometro.Size = new System.Drawing.Size(158, 13);
            this.lblHidrometro.Text = "9999999999";
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(3, 229);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(64, 29);
            this.btnRemover.TabIndex = 4;
            this.btnRemover.Text = "Remover";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(173, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 29);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(88, 229);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(64, 29);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblOcorrenciasCadastradas
            // 
            this.lblOcorrenciasCadastradas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblOcorrenciasCadastradas.Location = new System.Drawing.Point(3, 90);
            this.lblOcorrenciasCadastradas.Name = "lblOcorrenciasCadastradas";
            this.lblOcorrenciasCadastradas.Size = new System.Drawing.Size(234, 18);
            this.lblOcorrenciasCadastradas.Text = "Ocorrencias cadastradas:";
            // 
            // lblOcorrencias
            // 
            this.lblOcorrencias.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblOcorrencias.Location = new System.Drawing.Point(3, 16);
            this.lblOcorrencias.Name = "lblOcorrencias";
            this.lblOcorrencias.Size = new System.Drawing.Size(84, 12);
            this.lblOcorrencias.Text = "Ocorrências:";
            // 
            // FormOcorrenciaNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.lblOcorrencias);
            this.Controls.Add(this.lblOcorrenciasCadastradas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.lblHidrometro);
            this.Controls.Add(this.lblInfoHidrometro);
            this.Controls.Add(this.lstOcorrenciasCadastradas);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.cboxOcorrencias);
            this.Controls.Add(this.txtCodigoOcorrencia);
            this.KeyPreview = true;
            this.Menu = this.mainMenu;
            this.Name = "FormOcorrenciaNovo";
            this.Text = "OnPlace [Ocorrências]";
            this.Activated += new System.EventHandler(this.FormOcorrencia_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormOcorrenciaNovo_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormOcorrencia_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormOcorrenciaNovo_KeyDown);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtCodigoOcorrencia;
		private System.Windows.Forms.ComboBox cboxOcorrencias;
		private System.Windows.Forms.Button btnAdicionar;
		private System.Windows.Forms.ListBox lstOcorrenciasCadastradas;
		private System.Windows.Forms.Label lblInfoHidrometro;
		private System.Windows.Forms.Label lblHidrometro;
		private System.Windows.Forms.Button btnRemover;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label lblOcorrenciasCadastradas;
		private System.Windows.Forms.Label lblOcorrencias;
	}
}