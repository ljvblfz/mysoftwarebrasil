namespace LTmobile.View
{
    partial class frmPesquisarUc
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnPesquisar = new System.Windows.Forms.MenuItem();
            this.mnMenu = new System.Windows.Forms.MenuItem();
            this.mnSelecionar = new System.Windows.Forms.MenuItem();
            this.mnFechar = new System.Windows.Forms.MenuItem();
            this.tlPesquisarUc = new MobileTools.Controls.Title();
            this.cbMedidor = new System.Windows.Forms.CheckBox();
            this.cbUc = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbUc = new System.Windows.Forms.TextBox();
            this.bsPesquisar = new System.Windows.Forms.BindingSource(this.components);
            this.txbMedidor = new System.Windows.Forms.TextBox();
            this.txbEndereco = new System.Windows.Forms.TextBox();
            this.lblIndice = new System.Windows.Forms.Label();
            this.lblUc = new System.Windows.Forms.Label();
            this.lblMedidor = new System.Windows.Forms.Label();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.txbPesquisa = new System.Windows.Forms.TextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPesquisar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnPesquisar);
            this.mainMenu1.MenuItems.Add(this.mnMenu);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // mnMenu
            // 
            this.mnMenu.MenuItems.Add(this.mnSelecionar);
            this.mnMenu.MenuItems.Add(this.mnFechar);
            this.mnMenu.Text = "Menu";
            // 
            // mnSelecionar
            // 
            this.mnSelecionar.Text = "Selecionar";
            this.mnSelecionar.Click += new System.EventHandler(this.mnSelecionar_Click);
            // 
            // mnFechar
            // 
            this.mnFechar.Text = "Sair";
            this.mnFechar.Click += new System.EventHandler(this.mnFechar_Click);
            // 
            // tlPesquisarUc
            // 
            this.tlPesquisarUc.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlPesquisarUc.DistanceWordLine = 2;
            this.tlPesquisarUc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlPesquisarUc.HeightLine = 10;
            this.tlPesquisarUc.Location = new System.Drawing.Point(0, 0);
            this.tlPesquisarUc.Name = "tlPesquisarUc";
            this.tlPesquisarUc.Size = new System.Drawing.Size(224, 28);
            this.tlPesquisarUc.TabIndex = 14;
            this.tlPesquisarUc.Text = "Pesquisar UC";
            this.tlPesquisarUc.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlPesquisarUc.WidthInclination = 10;
            // 
            // cbMedidor
            // 
            this.cbMedidor.Checked = true;
            this.cbMedidor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMedidor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cbMedidor.Location = new System.Drawing.Point(4, 32);
            this.cbMedidor.Name = "cbMedidor";
            this.cbMedidor.Size = new System.Drawing.Size(76, 12);
            this.cbMedidor.TabIndex = 15;
            this.cbMedidor.Text = "Medidor";
            this.cbMedidor.Click += new System.EventHandler(this.cbMedidor_Click);
            // 
            // cbUc
            // 
            this.cbUc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.cbUc.Location = new System.Drawing.Point(86, 32);
            this.cbUc.Name = "cbUc";
            this.cbUc.Size = new System.Drawing.Size(76, 12);
            this.cbUc.TabIndex = 16;
            this.cbUc.Text = "UC";
            this.cbUc.Click += new System.EventHandler(this.cbUc_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbUc);
            this.panel1.Controls.Add(this.txbMedidor);
            this.panel1.Controls.Add(this.txbEndereco);
            this.panel1.Controls.Add(this.lblIndice);
            this.panel1.Controls.Add(this.lblUc);
            this.panel1.Controls.Add(this.lblMedidor);
            this.panel1.Controls.Add(this.lblEndereco);
            this.panel1.Location = new System.Drawing.Point(4, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 99);
            // 
            // txbUc
            // 
            this.txbUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbUc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPesquisar, "NUM_UC", true));
            this.txbUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbUc.Location = new System.Drawing.Point(61, 60);
            this.txbUc.Name = "txbUc";
            this.txbUc.Size = new System.Drawing.Size(52, 19);
            this.txbUc.TabIndex = 16;
            this.txbUc.TabStop = false;
            // 
            // bsPesquisar
            // 
            this.bsPesquisar.DataSource = typeof(LTmobileData.Data.Model.Leitura);
            // 
            // txbMedidor
            // 
            this.txbMedidor.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbMedidor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPesquisar, "MedidorTipoMed", true));
            this.txbMedidor.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMedidor.Location = new System.Drawing.Point(61, 36);
            this.txbMedidor.Name = "txbMedidor";
            this.txbMedidor.Size = new System.Drawing.Size(159, 19);
            this.txbMedidor.TabIndex = 15;
            this.txbMedidor.TabStop = false;
            // 
            // txbEndereco
            // 
            this.txbEndereco.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbEndereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPesquisar, "EnderecoComplemento", true));
            this.txbEndereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbEndereco.Location = new System.Drawing.Point(61, 5);
            this.txbEndereco.Multiline = true;
            this.txbEndereco.Name = "txbEndereco";
            this.txbEndereco.Size = new System.Drawing.Size(159, 27);
            this.txbEndereco.TabIndex = 14;
            this.txbEndereco.TabStop = false;
            // 
            // lblIndice
            // 
            this.lblIndice.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblIndice.Location = new System.Drawing.Point(126, 63);
            this.lblIndice.Name = "lblIndice";
            this.lblIndice.Size = new System.Drawing.Size(46, 14);
            this.lblIndice.Text = "Índice";
            // 
            // lblUc
            // 
            this.lblUc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblUc.Location = new System.Drawing.Point(6, 63);
            this.lblUc.Name = "lblUc";
            this.lblUc.Size = new System.Drawing.Size(46, 14);
            this.lblUc.Text = "UC:";
            // 
            // lblMedidor
            // 
            this.lblMedidor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblMedidor.Location = new System.Drawing.Point(6, 38);
            this.lblMedidor.Name = "lblMedidor";
            this.lblMedidor.Size = new System.Drawing.Size(58, 22);
            this.lblMedidor.Text = "Medidor:";
            // 
            // lblEndereco
            // 
            this.lblEndereco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblEndereco.Location = new System.Drawing.Point(6, 5);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(46, 22);
            this.lblEndereco.Text = "End.:";
            // 
            // txbPesquisa
            // 
            this.txbPesquisa.BackColor = System.Drawing.SystemColors.Info;
            this.txbPesquisa.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbPesquisa.Location = new System.Drawing.Point(65, 48);
            this.txbPesquisa.MaxLength = 10;
            this.txbPesquisa.Name = "txbPesquisa";
            this.txbPesquisa.Size = new System.Drawing.Size(159, 19);
            this.txbPesquisa.TabIndex = 19;
            this.txbPesquisa.TextChanged += new System.EventHandler(this.txbPesquisa_TextChanged);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.Location = new System.Drawing.Point(7, 48);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(54, 21);
            this.lblPesquisar.Text = "Pesq.:";
            // 
            // frmPesquisarUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbPesquisa);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbUc);
            this.Controls.Add(this.cbMedidor);
            this.Controls.Add(this.tlPesquisarUc);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmPesquisarUc";
            this.Text = "frmPesquisarUc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPesquisarUc_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmPesquisarUc_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPesquisarUc_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsPesquisar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlPesquisarUc;
        private System.Windows.Forms.CheckBox cbMedidor;
        private System.Windows.Forms.CheckBox cbUc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblIndice;
        private System.Windows.Forms.Label lblUc;
        private System.Windows.Forms.Label lblMedidor;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox txbUc;
        private System.Windows.Forms.TextBox txbMedidor;
        private System.Windows.Forms.TextBox txbEndereco;
        private System.Windows.Forms.MenuItem btnPesquisar;
        private System.Windows.Forms.MenuItem mnMenu;
        private System.Windows.Forms.MenuItem mnSelecionar;
        private System.Windows.Forms.MenuItem mnFechar;
        private System.Windows.Forms.TextBox txbPesquisa;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.BindingSource bsPesquisar;
    }
}