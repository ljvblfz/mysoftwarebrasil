namespace LTmobile.View
{
    partial class frmVisualizarFoto
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
            this.mnMenu = new System.Windows.Forms.MenuItem();
            this.mnApagar = new System.Windows.Forms.MenuItem();
            this.mnVoltar = new System.Windows.Forms.MenuItem();
            this.pctFoto = new System.Windows.Forms.PictureBox();
            this.txbMedidorUc = new System.Windows.Forms.TextBox();
            this.lblMedidor = new System.Windows.Forms.Label();
            this.txbLegenda = new System.Windows.Forms.TextBox();
            this.lblLegenda = new System.Windows.Forms.Label();
            this.tlVusualizarFoto = new MobileTools.Controls.Title();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnSalvar);
            this.mainMenu1.MenuItems.Add(this.mnMenu);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // mnMenu
            // 
            this.mnMenu.MenuItems.Add(this.mnApagar);
            this.mnMenu.MenuItems.Add(this.mnVoltar);
            this.mnMenu.Text = "Menu";
            // 
            // mnApagar
            // 
            this.mnApagar.Text = "Apagar";
            this.mnApagar.Click += new System.EventHandler(this.mnApagar_Click);
            // 
            // mnVoltar
            // 
            this.mnVoltar.Text = "Voltar";
            this.mnVoltar.Click += new System.EventHandler(this.mnVoltar_Click);
            // 
            // pctFoto
            // 
            this.pctFoto.Location = new System.Drawing.Point(25, 31);
            this.pctFoto.Name = "pctFoto";
            this.pctFoto.Size = new System.Drawing.Size(175, 74);
            // 
            // txbMedidorUc
            // 
            this.txbMedidorUc.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbMedidorUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMedidorUc.Location = new System.Drawing.Point(82, 109);
            this.txbMedidorUc.Name = "txbMedidorUc";
            this.txbMedidorUc.Size = new System.Drawing.Size(138, 19);
            this.txbMedidorUc.TabIndex = 30;
            this.txbMedidorUc.TabStop = false;
            // 
            // lblMedidor
            // 
            this.lblMedidor.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblMedidor.Location = new System.Drawing.Point(3, 109);
            this.lblMedidor.Name = "lblMedidor";
            this.lblMedidor.Size = new System.Drawing.Size(76, 14);
            this.lblMedidor.Text = "Medidor / UC:";
            // 
            // txbLegenda
            // 
            this.txbLegenda.BackColor = System.Drawing.SystemColors.Info;
            this.txbLegenda.Location = new System.Drawing.Point(82, 131);
            this.txbLegenda.MaxLength = 50;
            this.txbLegenda.Name = "txbLegenda";
            this.txbLegenda.Size = new System.Drawing.Size(138, 22);
            this.txbLegenda.TabIndex = 29;
            // 
            // lblLegenda
            // 
            this.lblLegenda.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblLegenda.Location = new System.Drawing.Point(3, 131);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(75, 22);
            this.lblLegenda.Text = "Legenda:";
            // 
            // tlVusualizarFoto
            // 
            this.tlVusualizarFoto.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlVusualizarFoto.DistanceWordLine = 2;
            this.tlVusualizarFoto.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.tlVusualizarFoto.HeightLine = 10;
            this.tlVusualizarFoto.Location = new System.Drawing.Point(0, 0);
            this.tlVusualizarFoto.Name = "tlVusualizarFoto";
            this.tlVusualizarFoto.Size = new System.Drawing.Size(224, 28);
            this.tlVusualizarFoto.TabIndex = 28;
            this.tlVusualizarFoto.Text = "Editar Foto";
            this.tlVusualizarFoto.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlVusualizarFoto.WidthInclination = 10;
            // 
            // frmVisualizarFoto
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
            this.Controls.Add(this.tlVusualizarFoto);
            this.Menu = this.mainMenu1;
            this.Name = "frmVisualizarFoto";
            this.Text = "frmVisualizarFoto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVisualizarFoto_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmVisualizarFoto_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctFoto;
        private System.Windows.Forms.TextBox txbMedidorUc;
        private System.Windows.Forms.Label lblMedidor;
        private System.Windows.Forms.TextBox txbLegenda;
        private System.Windows.Forms.Label lblLegenda;
        private MobileTools.Controls.Title tlVusualizarFoto;
        private System.Windows.Forms.MenuItem btnSalvar;
        private System.Windows.Forms.MenuItem mnMenu;
        private System.Windows.Forms.MenuItem mnApagar;
        private System.Windows.Forms.MenuItem mnVoltar;
    }
}