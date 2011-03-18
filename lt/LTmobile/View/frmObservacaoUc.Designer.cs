namespace LTmobile.View
{
    partial class frmObservacaoUc
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
            this.btnSalvar = new System.Windows.Forms.MenuItem();
            this.btnCancelar = new System.Windows.Forms.MenuItem();
            this.txbMedidorUc = new System.Windows.Forms.TextBox();
            this.lblMedidor = new System.Windows.Forms.Label();
            this.txbObservacao = new System.Windows.Forms.TextBox();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.txbEndereco = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.tlLeitura = new MobileTools.Controls.Title();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnSalvar);
            this.mainMenu1.MenuItems.Add(this.btnCancelar);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txbMedidorUc
            // 
            this.txbMedidorUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbMedidorUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMedidorUc.Location = new System.Drawing.Point(57, 75);
            this.txbMedidorUc.Name = "txbMedidorUc";
            this.txbMedidorUc.Size = new System.Drawing.Size(158, 19);
            this.txbMedidorUc.TabIndex = 55;
            this.txbMedidorUc.TabStop = false;
            // 
            // lblMedidor
            // 
            this.lblMedidor.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblMedidor.Location = new System.Drawing.Point(3, 75);
            this.lblMedidor.Name = "lblMedidor";
            this.lblMedidor.Size = new System.Drawing.Size(51, 14);
            this.lblMedidor.Text = "Medidor:";
            // 
            // txbObservacao
            // 
            this.txbObservacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txbObservacao.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbObservacao.Location = new System.Drawing.Point(3, 110);
            this.txbObservacao.MaxLength = 100;
            this.txbObservacao.Multiline = true;
            this.txbObservacao.Name = "txbObservacao";
            this.txbObservacao.Size = new System.Drawing.Size(213, 37);
            this.txbObservacao.TabIndex = 52;
            // 
            // lblObservacao
            // 
            this.lblObservacao.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblObservacao.Location = new System.Drawing.Point(2, 94);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(35, 21);
            this.lblObservacao.Text = "Obs.:";
            // 
            // txbEndereco
            // 
            this.txbEndereco.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbEndereco.Enabled = false;
            this.txbEndereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbEndereco.Location = new System.Drawing.Point(57, 33);
            this.txbEndereco.Multiline = true;
            this.txbEndereco.Name = "txbEndereco";
            this.txbEndereco.Size = new System.Drawing.Size(158, 35);
            this.txbEndereco.TabIndex = 54;
            this.txbEndereco.TabStop = false;
            // 
            // lblEndereco
            // 
            this.lblEndereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblEndereco.Location = new System.Drawing.Point(2, 33);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(49, 21);
            this.lblEndereco.Text = "End.:";
            // 
            // tlLeitura
            // 
            this.tlLeitura.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlLeitura.DistanceWordLine = 2;
            this.tlLeitura.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlLeitura.HeightLine = 10;
            this.tlLeitura.Location = new System.Drawing.Point(0, 1);
            this.tlLeitura.Name = "tlLeitura";
            this.tlLeitura.Size = new System.Drawing.Size(216, 28);
            this.tlLeitura.TabIndex = 53;
            this.tlLeitura.Text = "Observação";
            this.tlLeitura.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlLeitura.WidthInclination = 10;
            // 
            // frmObservacaoUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbMedidorUc);
            this.Controls.Add(this.lblMedidor);
            this.Controls.Add(this.txbObservacao);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.txbEndereco);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.tlLeitura);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmObservacaoUc";
            this.Text = "frmObservacaoUc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmObservacaoUc_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmObservacaoUc_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbMedidorUc;
        private System.Windows.Forms.Label lblMedidor;
        private System.Windows.Forms.TextBox txbObservacao;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.TextBox txbEndereco;
        private System.Windows.Forms.Label lblEndereco;
        private MobileTools.Controls.Title tlLeitura;
        private System.Windows.Forms.MenuItem btnSalvar;
        private System.Windows.Forms.MenuItem btnCancelar;
    }
}