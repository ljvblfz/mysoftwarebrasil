namespace OnPlaceMovel.Source.Forms {
    partial class FormError {
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
			this.lblTittle = new System.Windows.Forms.Label();
			this.lblMensagem = new System.Windows.Forms.Label();
			this.btnDetalhes = new System.Windows.Forms.Button();
			this.txtError = new System.Windows.Forms.TextBox();
			this.btnFechar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblTittle
			// 
			this.lblTittle.BackColor = System.Drawing.SystemColors.Control;
			this.lblTittle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
			this.lblTittle.Location = new System.Drawing.Point(0, 0);
			this.lblTittle.Name = "lblTittle";
			this.lblTittle.Size = new System.Drawing.Size(240, 20);
			this.lblTittle.Text = "Mensagem do sistema";
			// 
			// lblMensagem
			// 
			this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.lblMensagem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lblMensagem.Location = new System.Drawing.Point(0, 20);
			this.lblMensagem.Name = "lblMensagem";
			this.lblMensagem.Size = new System.Drawing.Size(240, 41);
			this.lblMensagem.Text = "Texto da mensagem";
			// 
			// btnDetalhes
			// 
			this.btnDetalhes.Location = new System.Drawing.Point(149, 64);
			this.btnDetalhes.Name = "btnDetalhes";
			this.btnDetalhes.Size = new System.Drawing.Size(88, 20);
			this.btnDetalhes.TabIndex = 2;
			this.btnDetalhes.Text = "Detalhes >>";
			this.btnDetalhes.Click += new System.EventHandler(this.btnDetalhes_Click);
			// 
			// txtError
			// 
			this.txtError.AcceptsReturn = true;
			this.txtError.Location = new System.Drawing.Point(3, 90);
			this.txtError.Multiline = true;
			this.txtError.Name = "txtError";
			this.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtError.Size = new System.Drawing.Size(237, 175);
			this.txtError.TabIndex = 3;
			this.txtError.Text = "Mensagem do erro";
			this.txtError.Visible = false;
			// 
			// btnFechar
			// 
			this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnFechar.Location = new System.Drawing.Point(88, 64);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(55, 20);
			this.btnFechar.TabIndex = 4;
			this.btnFechar.Text = "Fechar";
			// 
			// FormError
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.ControlBox = false;
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.txtError);
			this.Controls.Add(this.btnDetalhes);
			this.Controls.Add(this.lblMensagem);
			this.Controls.Add(this.lblTittle);
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "FormError";
			this.Text = "Error";
			this.Activated += new System.EventHandler(this.Error_Activated);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTittle;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnDetalhes;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Button btnFechar;
    }
}