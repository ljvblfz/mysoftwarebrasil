namespace LTmobile.View
{
    partial class frmCapturarFoto
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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnFechar = new System.Windows.Forms.MenuItem();
            this.tlFoto = new MobileTools.Controls.Title();
            this.lblLegenda = new System.Windows.Forms.Label();
            this.txbLegenda = new System.Windows.Forms.TextBox();
            this.txbMedidorUc = new System.Windows.Forms.TextBox();
            this.lblMedidor = new System.Windows.Forms.Label();
            this.pctFoto = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnSalvar);
            this.mainMenu1.MenuItems.Add(this.btnCancelar);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Text = "Capturar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.MenuItems.Add(this.menuItem1);
            this.btnCancelar.MenuItems.Add(this.mnFechar);
            this.btnCancelar.Text = "Menu";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Visualizar Fotos";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // mnFechar
            // 
            this.mnFechar.Text = "Sair";
            this.mnFechar.Click += new System.EventHandler(this.mnFechar_Click);
            // 
            // tlFoto
            // 
            this.tlFoto.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlFoto.DistanceWordLine = 2;
            this.tlFoto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlFoto.HeightLine = 10;
            this.tlFoto.Location = new System.Drawing.Point(0, 0);
            this.tlFoto.Name = "tlFoto";
            this.tlFoto.Size = new System.Drawing.Size(224, 28);
            this.tlFoto.TabIndex = 14;
            this.tlFoto.Text = "Foto";
            this.tlFoto.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlFoto.WidthInclination = 10;
            // 
            // lblLegenda
            // 
            this.lblLegenda.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblLegenda.Location = new System.Drawing.Point(4, 130);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(75, 22);
            this.lblLegenda.Text = "Legenda:";
            // 
            // txbLegenda
            // 
            this.txbLegenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txbLegenda.Location = new System.Drawing.Point(82, 130);
            this.txbLegenda.MaxLength = 50;
            this.txbLegenda.Name = "txbLegenda";
            this.txbLegenda.Size = new System.Drawing.Size(142, 22);
            this.txbLegenda.TabIndex = 22;
            // 
            // txbMedidorUc
            // 
            this.txbMedidorUc.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbMedidorUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMedidorUc.Location = new System.Drawing.Point(82, 108);
            this.txbMedidorUc.Name = "txbMedidorUc";
            this.txbMedidorUc.Size = new System.Drawing.Size(142, 19);
            this.txbMedidorUc.TabIndex = 24;
            this.txbMedidorUc.TabStop = false;
            // 
            // lblMedidor
            // 
            this.lblMedidor.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblMedidor.Location = new System.Drawing.Point(3, 108);
            this.lblMedidor.Name = "lblMedidor";
            this.lblMedidor.Size = new System.Drawing.Size(76, 14);
            this.lblMedidor.Text = "UC/Medidor:";
            // 
            // pctFoto
            // 
            this.pctFoto.BackColor = System.Drawing.SystemColors.Info;
            this.pctFoto.Location = new System.Drawing.Point(23, 29);
            this.pctFoto.Name = "pctFoto";
            this.pctFoto.Size = new System.Drawing.Size(172, 73);
            // 
            // frmCapturarFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.pctFoto);
            this.Controls.Add(this.txbMedidorUc);
            this.Controls.Add(this.lblMedidor);
            this.Controls.Add(this.txbLegenda);
            this.Controls.Add(this.lblLegenda);
            this.Controls.Add(this.tlFoto);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmCapturarFoto";
            this.Text = "frmCapturarFoto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCapturarFoto_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmCapturarFoto_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCapturarFoto_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlFoto;
        private System.Windows.Forms.Label lblLegenda;
        private System.Windows.Forms.TextBox txbLegenda;
        private System.Windows.Forms.MenuItem btnSalvar;
        private System.Windows.Forms.MenuItem btnCancelar;
        private System.Windows.Forms.TextBox txbMedidorUc;
        private System.Windows.Forms.Label lblMedidor;
        private System.Windows.Forms.PictureBox pctFoto;
        private System.Windows.Forms.MenuItem mnFechar;
        private System.Windows.Forms.MenuItem menuItem1;
    }
}