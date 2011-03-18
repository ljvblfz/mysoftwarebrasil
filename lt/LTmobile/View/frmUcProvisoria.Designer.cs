namespace LTmobile.View
{
    partial class frmUcProvisoria
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
            this.mnCancelar = new System.Windows.Forms.MenuItem();
            this.tlUcProvisoria = new MobileTools.Controls.Title();
            this.lblMedidor = new System.Windows.Forms.Label();
            this.lblLeitura = new System.Windows.Forms.Label();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMedidor = new System.Windows.Forms.TextBox();
            this.txbLeitura = new System.Windows.Forms.TextBox();
            this.cmbTipoMedicao = new System.Windows.Forms.ComboBox();
            this.txbObservacao = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnConfirmar);
            this.mainMenu1.MenuItems.Add(this.mnMenu);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Text = "Salvar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // mnMenu
            // 
            this.mnMenu.MenuItems.Add(this.mnFotos);
            this.mnMenu.MenuItems.Add(this.mnCancelar);
            this.mnMenu.Text = "Menu";
            // 
            // mnFotos
            // 
            this.mnFotos.Text = "Fotos";
            this.mnFotos.Click += new System.EventHandler(this.mnFotos_Click);
            // 
            // mnCancelar
            // 
            this.mnCancelar.Text = "Sair";
            this.mnCancelar.Click += new System.EventHandler(this.mnCancelar_Click);
            // 
            // tlUcProvisoria
            // 
            this.tlUcProvisoria.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlUcProvisoria.DistanceWordLine = 2;
            this.tlUcProvisoria.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlUcProvisoria.HeightLine = 10;
            this.tlUcProvisoria.Location = new System.Drawing.Point(0, 0);
            this.tlUcProvisoria.Name = "tlUcProvisoria";
            this.tlUcProvisoria.Size = new System.Drawing.Size(224, 28);
            this.tlUcProvisoria.TabIndex = 14;
            this.tlUcProvisoria.Text = "Uc Provisória";
            this.tlUcProvisoria.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlUcProvisoria.WidthInclination = 10;
            // 
            // lblMedidor
            // 
            this.lblMedidor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblMedidor.Location = new System.Drawing.Point(4, 33);
            this.lblMedidor.Name = "lblMedidor";
            this.lblMedidor.Size = new System.Drawing.Size(59, 22);
            this.lblMedidor.Text = "Medidor:";
            // 
            // lblLeitura
            // 
            this.lblLeitura.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblLeitura.Location = new System.Drawing.Point(4, 59);
            this.lblLeitura.Name = "lblLeitura";
            this.lblLeitura.Size = new System.Drawing.Size(56, 14);
            this.lblLeitura.Text = "Leitura:";
            // 
            // lblObservacao
            // 
            this.lblObservacao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblObservacao.Location = new System.Drawing.Point(4, 101);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(56, 15);
            this.lblObservacao.Text = "Obs.:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.Text = "Tipo Medição:";
            // 
            // txbMedidor
            // 
            this.txbMedidor.BackColor = System.Drawing.SystemColors.Info;
            this.txbMedidor.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.txbMedidor.Location = new System.Drawing.Point(61, 30);
            this.txbMedidor.MaxLength = 10;
            this.txbMedidor.Name = "txbMedidor";
            this.txbMedidor.Size = new System.Drawing.Size(152, 22);
            this.txbMedidor.TabIndex = 15;
            this.txbMedidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPressInvertido);
            // 
            // txbLeitura
            // 
            this.txbLeitura.BackColor = System.Drawing.SystemColors.Info;
            this.txbLeitura.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.txbLeitura.Location = new System.Drawing.Point(61, 56);
            this.txbLeitura.MaxLength = 6;
            this.txbLeitura.Name = "txbLeitura";
            this.txbLeitura.Size = new System.Drawing.Size(152, 22);
            this.txbLeitura.TabIndex = 16;
            this.txbLeitura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // cmbTipoMedicao
            // 
            this.cmbTipoMedicao.BackColor = System.Drawing.SystemColors.Info;
            this.cmbTipoMedicao.Items.Add("CON");
            this.cmbTipoMedicao.Items.Add("ERA");
            this.cmbTipoMedicao.Items.Add("CRT");
            this.cmbTipoMedicao.Location = new System.Drawing.Point(91, 82);
            this.cmbTipoMedicao.Name = "cmbTipoMedicao";
            this.cmbTipoMedicao.Size = new System.Drawing.Size(122, 22);
            this.cmbTipoMedicao.TabIndex = 17;
            // 
            // txbObservacao
            // 
            this.txbObservacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txbObservacao.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.txbObservacao.Location = new System.Drawing.Point(4, 119);
            this.txbObservacao.MaxLength = 100;
            this.txbObservacao.Multiline = true;
            this.txbObservacao.Name = "txbObservacao";
            this.txbObservacao.Size = new System.Drawing.Size(209, 28);
            this.txbObservacao.TabIndex = 18;
            // 
            // frmUcProvisoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbObservacao);
            this.Controls.Add(this.cmbTipoMedicao);
            this.Controls.Add(this.txbLeitura);
            this.Controls.Add(this.txbMedidor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.lblLeitura);
            this.Controls.Add(this.lblMedidor);
            this.Controls.Add(this.tlUcProvisoria);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmUcProvisoria";
            this.Text = "frmUcProvisoria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUcProvisoria_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmUcProvisoria_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUcProvisoria_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlUcProvisoria;
        private System.Windows.Forms.MenuItem btnConfirmar;
        private System.Windows.Forms.MenuItem mnMenu;
        private System.Windows.Forms.MenuItem mnFotos;
        private System.Windows.Forms.MenuItem mnCancelar;
        private System.Windows.Forms.Label lblMedidor;
        private System.Windows.Forms.Label lblLeitura;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMedidor;
        private System.Windows.Forms.TextBox txbLeitura;
        private System.Windows.Forms.ComboBox cmbTipoMedicao;
        private System.Windows.Forms.TextBox txbObservacao;
    }
}