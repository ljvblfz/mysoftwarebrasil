namespace LTmobile.View
{
    partial class frmLeitura
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
            this.btnConfirmar = new System.Windows.Forms.MenuItem();
            this.mnMenu = new System.Windows.Forms.MenuItem();
            this.mnFotos = new System.Windows.Forms.MenuItem();
            this.mnOcorrencia = new System.Windows.Forms.MenuItem();
            this.mnCancelar = new System.Windows.Forms.MenuItem();
            this.txbEndereco = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.tlLeitura = new MobileTools.Controls.Title();
            this.lblLeitura = new System.Windows.Forms.Label();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.txbLeitura = new System.Windows.Forms.TextBox();
            this.txbObservacao = new System.Windows.Forms.TextBox();
            this.txbUc = new System.Windows.Forms.TextBox();
            this.lblUc = new System.Windows.Forms.Label();
            this.txbMedidorUc = new System.Windows.Forms.TextBox();
            this.lblMedidor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnConfirmar);
            this.mainMenu1.MenuItems.Add(this.mnMenu);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // mnMenu
            // 
            this.mnMenu.MenuItems.Add(this.mnFotos);
            this.mnMenu.MenuItems.Add(this.mnOcorrencia);
            this.mnMenu.MenuItems.Add(this.mnCancelar);
            this.mnMenu.Text = "Menu";
            // 
            // mnFotos
            // 
            this.mnFotos.Text = "Fotos";
            this.mnFotos.Click += new System.EventHandler(this.mnFotos_Click);
            // 
            // mnOcorrencia
            // 
            this.mnOcorrencia.Text = "Ocorrência";
            this.mnOcorrencia.Click += new System.EventHandler(this.mnOcorrencia_Click);
            // 
            // mnCancelar
            // 
            this.mnCancelar.Text = "Cancelar";
            this.mnCancelar.Click += new System.EventHandler(this.mnCancelar_Click);
            // 
            // txbEndereco
            // 
            this.txbEndereco.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbEndereco.Enabled = false;
            this.txbEndereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbEndereco.Location = new System.Drawing.Point(34, 31);
            this.txbEndereco.Multiline = true;
            this.txbEndereco.Name = "txbEndereco";
            this.txbEndereco.Size = new System.Drawing.Size(182, 26);
            this.txbEndereco.TabIndex = 25;
            this.txbEndereco.TabStop = false;
            // 
            // lblEndereco
            // 
            this.lblEndereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblEndereco.Location = new System.Drawing.Point(2, 31);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(35, 21);
            this.lblEndereco.Text = "End.:";
            // 
            // tlLeitura
            // 
            this.tlLeitura.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlLeitura.DistanceWordLine = 2;
            this.tlLeitura.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlLeitura.HeightLine = 10;
            this.tlLeitura.Location = new System.Drawing.Point(0, 0);
            this.tlLeitura.Name = "tlLeitura";
            this.tlLeitura.Size = new System.Drawing.Size(216, 28);
            this.tlLeitura.TabIndex = 24;
            this.tlLeitura.Text = "Execução de Leitura";
            this.tlLeitura.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlLeitura.WidthInclination = 10;
            // 
            // lblLeitura
            // 
            this.lblLeitura.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblLeitura.Location = new System.Drawing.Point(2, 92);
            this.lblLeitura.Name = "lblLeitura";
            this.lblLeitura.Size = new System.Drawing.Size(51, 21);
            this.lblLeitura.Text = "Leitura:";
            // 
            // lblObservacao
            // 
            this.lblObservacao.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblObservacao.Location = new System.Drawing.Point(2, 111);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(35, 21);
            this.lblObservacao.Text = "Obs.:";
            // 
            // txbLeitura
            // 
            this.txbLeitura.BackColor = System.Drawing.SystemColors.Info;
            this.txbLeitura.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.txbLeitura.Location = new System.Drawing.Point(59, 89);
            this.txbLeitura.MaxLength = 6;
            this.txbLeitura.Name = "txbLeitura";
            this.txbLeitura.Size = new System.Drawing.Size(157, 23);
            this.txbLeitura.TabIndex = 0;
            this.txbLeitura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txbObservacao
            // 
            this.txbObservacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txbObservacao.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbObservacao.Location = new System.Drawing.Point(3, 127);
            this.txbObservacao.MaxLength = 100;
            this.txbObservacao.Multiline = true;
            this.txbObservacao.Name = "txbObservacao";
            this.txbObservacao.Size = new System.Drawing.Size(213, 26);
            this.txbObservacao.TabIndex = 1;
            // 
            // txbUc
            // 
            this.txbUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbUc.Location = new System.Drawing.Point(161, 61);
            this.txbUc.Name = "txbUc";
            this.txbUc.Size = new System.Drawing.Size(55, 19);
            this.txbUc.TabIndex = 47;
            this.txbUc.TabStop = false;
            // 
            // lblUc
            // 
            this.lblUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblUc.Location = new System.Drawing.Point(136, 61);
            this.lblUc.Name = "lblUc";
            this.lblUc.Size = new System.Drawing.Size(89, 14);
            this.lblUc.Text = "Uc:";
            // 
            // txbMedidorUc
            // 
            this.txbMedidorUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbMedidorUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMedidorUc.Location = new System.Drawing.Point(57, 60);
            this.txbMedidorUc.Name = "txbMedidorUc";
            this.txbMedidorUc.Size = new System.Drawing.Size(72, 19);
            this.txbMedidorUc.TabIndex = 46;
            this.txbMedidorUc.TabStop = false;
            // 
            // lblMedidor
            // 
            this.lblMedidor.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblMedidor.Location = new System.Drawing.Point(3, 60);
            this.lblMedidor.Name = "lblMedidor";
            this.lblMedidor.Size = new System.Drawing.Size(51, 14);
            this.lblMedidor.Text = "Medidor:";
            // 
            // frmLeitura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbUc);
            this.Controls.Add(this.lblUc);
            this.Controls.Add(this.txbMedidorUc);
            this.Controls.Add(this.lblMedidor);
            this.Controls.Add(this.txbObservacao);
            this.Controls.Add(this.txbLeitura);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.lblLeitura);
            this.Controls.Add(this.txbEndereco);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.tlLeitura);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmLeitura";
            this.Text = "frmLeitura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLeitura_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmLeitura_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLeitura_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbEndereco;
        private System.Windows.Forms.Label lblEndereco;
        private MobileTools.Controls.Title tlLeitura;
        private System.Windows.Forms.Label lblLeitura;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.TextBox txbLeitura;
        private System.Windows.Forms.MenuItem btnConfirmar;
        private System.Windows.Forms.MenuItem mnMenu;
        private System.Windows.Forms.MenuItem mnFotos;
        private System.Windows.Forms.MenuItem mnOcorrencia;
        private System.Windows.Forms.MenuItem mnCancelar;
        private System.Windows.Forms.TextBox txbObservacao;
        private System.Windows.Forms.TextBox txbUc;
        private System.Windows.Forms.Label lblUc;
        private System.Windows.Forms.TextBox txbMedidorUc;
        private System.Windows.Forms.Label lblMedidor;
    }
}