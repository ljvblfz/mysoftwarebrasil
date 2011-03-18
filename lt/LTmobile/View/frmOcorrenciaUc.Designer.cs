namespace LTmobile.View
{
    partial class frmOcorrenciaUc
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
            this.btnAvancar = new System.Windows.Forms.MenuItem();
            this.mnMenu = new System.Windows.Forms.MenuItem();
            this.mnFotos = new System.Windows.Forms.MenuItem();
            this.mnOcorrencia = new System.Windows.Forms.MenuItem();
            this.mnPesquisar = new System.Windows.Forms.MenuItem();
            this.mnApagar = new System.Windows.Forms.MenuItem();
            this.mnCancelar = new System.Windows.Forms.MenuItem();
            this.tlOcorrencia = new MobileTools.Controls.Title();
            this.lblOcorrencia = new System.Windows.Forms.Label();
            this.txbCodOcorrencia = new System.Windows.Forms.TextBox();
            this.txbOcorrencia = new System.Windows.Forms.TextBox();
            this.lblComplemento = new System.Windows.Forms.Label();
            this.txbComplemento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbImpedimento = new System.Windows.Forms.TextBox();
            this.txbMedidorUc = new System.Windows.Forms.TextBox();
            this.lblMedidor = new System.Windows.Forms.Label();
            this.cmbObsPadrao = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnAvancar);
            this.mainMenu1.MenuItems.Add(this.mnMenu);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Text = "Avançar";
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
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
            this.mnOcorrencia.MenuItems.Add(this.mnPesquisar);
            this.mnOcorrencia.MenuItems.Add(this.mnApagar);
            this.mnOcorrencia.Text = "Ocorrência";
            // 
            // mnPesquisar
            // 
            this.mnPesquisar.Text = "Pesquisar";
            this.mnPesquisar.Click += new System.EventHandler(this.mnPesquisar_Click);
            // 
            // mnApagar
            // 
            this.mnApagar.Text = "Apagar";
            this.mnApagar.Click += new System.EventHandler(this.mnApagar_Click);
            // 
            // mnCancelar
            // 
            this.mnCancelar.Text = "Sair";
            this.mnCancelar.Click += new System.EventHandler(this.mnCancelar_Click);
            // 
            // tlOcorrencia
            // 
            this.tlOcorrencia.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlOcorrencia.DistanceWordLine = 2;
            this.tlOcorrencia.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlOcorrencia.HeightLine = 10;
            this.tlOcorrencia.Location = new System.Drawing.Point(0, 0);
            this.tlOcorrencia.Name = "tlOcorrencia";
            this.tlOcorrencia.Size = new System.Drawing.Size(216, 28);
            this.tlOcorrencia.TabIndex = 14;
            this.tlOcorrencia.Text = "Ocorrência UC";
            this.tlOcorrencia.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlOcorrencia.WidthInclination = 10;
            // 
            // lblOcorrencia
            // 
            this.lblOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblOcorrencia.Location = new System.Drawing.Point(1, 55);
            this.lblOcorrencia.Name = "lblOcorrencia";
            this.lblOcorrencia.Size = new System.Drawing.Size(56, 14);
            this.lblOcorrencia.Text = "Ocorr.1:";
            // 
            // txbCodOcorrencia
            // 
            this.txbCodOcorrencia.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txbCodOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbCodOcorrencia.Location = new System.Drawing.Point(57, 51);
            this.txbCodOcorrencia.MaxLength = 3;
            this.txbCodOcorrencia.Name = "txbCodOcorrencia";
            this.txbCodOcorrencia.Size = new System.Drawing.Size(22, 19);
            this.txbCodOcorrencia.TabIndex = 28;
            this.txbCodOcorrencia.TextChanged += new System.EventHandler(this.txbCodOcorrencia_TextChanged);
            this.txbCodOcorrencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.txbCodOcorrencia.LostFocus += new System.EventHandler(this.txbCodOcorrencia_LostFocus);
            // 
            // txbOcorrencia
            // 
            this.txbOcorrencia.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbOcorrencia.Enabled = false;
            this.txbOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbOcorrencia.Location = new System.Drawing.Point(2, 74);
            this.txbOcorrencia.Name = "txbOcorrencia";
            this.txbOcorrencia.Size = new System.Drawing.Size(223, 19);
            this.txbOcorrencia.TabIndex = 29;
            this.txbOcorrencia.TabStop = false;
            // 
            // lblComplemento
            // 
            this.lblComplemento.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblComplemento.Location = new System.Drawing.Point(1, 118);
            this.lblComplemento.Name = "lblComplemento";
            this.lblComplemento.Size = new System.Drawing.Size(89, 13);
            this.lblComplemento.Text = "Complemento:";
            // 
            // txbComplemento
            // 
            this.txbComplemento.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txbComplemento.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbComplemento.Location = new System.Drawing.Point(3, 134);
            this.txbComplemento.MaxLength = 32;
            this.txbComplemento.Multiline = true;
            this.txbComplemento.Name = "txbComplemento";
            this.txbComplemento.Size = new System.Drawing.Size(222, 24);
            this.txbComplemento.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(154, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.Text = "Imped.:";
            // 
            // txbImpedimento
            // 
            this.txbImpedimento.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbImpedimento.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbImpedimento.Location = new System.Drawing.Point(203, 51);
            this.txbImpedimento.MaxLength = 3;
            this.txbImpedimento.Name = "txbImpedimento";
            this.txbImpedimento.Size = new System.Drawing.Size(22, 19);
            this.txbImpedimento.TabIndex = 39;
            this.txbImpedimento.TabStop = false;
            // 
            // txbMedidorUc
            // 
            this.txbMedidorUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbMedidorUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMedidorUc.Location = new System.Drawing.Point(57, 29);
            this.txbMedidorUc.Name = "txbMedidorUc";
            this.txbMedidorUc.Size = new System.Drawing.Size(72, 19);
            this.txbMedidorUc.TabIndex = 42;
            this.txbMedidorUc.TabStop = false;
            // 
            // lblMedidor
            // 
            this.lblMedidor.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblMedidor.Location = new System.Drawing.Point(3, 29);
            this.lblMedidor.Name = "lblMedidor";
            this.lblMedidor.Size = new System.Drawing.Size(51, 14);
            this.lblMedidor.Text = "Medidor:";
            // 
            // cmbObsPadrao
            // 
            this.cmbObsPadrao.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cmbObsPadrao.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.cmbObsPadrao.Location = new System.Drawing.Point(2, 97);
            this.cmbObsPadrao.Name = "cmbObsPadrao";
            this.cmbObsPadrao.Size = new System.Drawing.Size(223, 19);
            this.cmbObsPadrao.TabIndex = 49;
            this.cmbObsPadrao.SelectedIndexChanged += new System.EventHandler(this.cmbObsPadrao_SelectedIndexChanged);
            // 
            // frmOcorrenciaUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.cmbObsPadrao);
            this.Controls.Add(this.txbMedidorUc);
            this.Controls.Add(this.lblMedidor);
            this.Controls.Add(this.txbImpedimento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbComplemento);
            this.Controls.Add(this.lblComplemento);
            this.Controls.Add(this.txbOcorrencia);
            this.Controls.Add(this.txbCodOcorrencia);
            this.Controls.Add(this.lblOcorrencia);
            this.Controls.Add(this.tlOcorrencia);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmOcorrenciaUc";
            this.Text = "frmOcorrenciaUc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOcorrenciaUc_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmOcorrenciaUc_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOcorrenciaUc_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlOcorrencia;
        private System.Windows.Forms.Label lblOcorrencia;
        private System.Windows.Forms.TextBox txbCodOcorrencia;
        private System.Windows.Forms.TextBox txbOcorrencia;
        private System.Windows.Forms.Label lblComplemento;
        private System.Windows.Forms.TextBox txbComplemento;
        private System.Windows.Forms.MenuItem btnAvancar;
        private System.Windows.Forms.MenuItem mnMenu;
        private System.Windows.Forms.MenuItem mnCancelar;
        private System.Windows.Forms.MenuItem mnOcorrencia;
        private System.Windows.Forms.MenuItem mnPesquisar;
        private System.Windows.Forms.MenuItem mnApagar;
        private System.Windows.Forms.MenuItem mnFotos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbImpedimento;
        private System.Windows.Forms.TextBox txbMedidorUc;
        private System.Windows.Forms.Label lblMedidor;
        private System.Windows.Forms.ComboBox cmbObsPadrao;
    }
}