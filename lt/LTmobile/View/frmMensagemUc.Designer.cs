namespace LTmobile.View
{
    partial class frmMensagemUc
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
            this.btnOk = new System.Windows.Forms.MenuItem();
            this.mnMenu = new System.Windows.Forms.MenuItem();
            this.tlMensagemUc = new MobileTools.Controls.Title();
            this.lblUc = new System.Windows.Forms.Label();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.txbUc = new System.Windows.Forms.TextBox();
            this.bsMensagemUc = new System.Windows.Forms.BindingSource(this.components);
            this.txbMensagem = new System.Windows.Forms.TextBox();
            this.lblIndice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsMensagemUc)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnOk);
            this.mainMenu1.MenuItems.Add(this.mnMenu);
            // 
            // btnOk
            // 
            this.btnOk.Text = "Próximo";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // mnMenu
            // 
            this.mnMenu.Text = "Sair";
            this.mnMenu.Click += new System.EventHandler(this.mnMenu_Click);
            // 
            // tlMensagemUc
            // 
            this.tlMensagemUc.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlMensagemUc.DistanceWordLine = 2;
            this.tlMensagemUc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlMensagemUc.HeightLine = 10;
            this.tlMensagemUc.Location = new System.Drawing.Point(0, 0);
            this.tlMensagemUc.Name = "tlMensagemUc";
            this.tlMensagemUc.Size = new System.Drawing.Size(224, 28);
            this.tlMensagemUc.TabIndex = 14;
            this.tlMensagemUc.Text = "Atenção";
            this.tlMensagemUc.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlMensagemUc.WidthInclination = 10;
            // 
            // lblUc
            // 
            this.lblUc.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblUc.Location = new System.Drawing.Point(4, 35);
            this.lblUc.Name = "lblUc";
            this.lblUc.Size = new System.Drawing.Size(82, 22);
            this.lblUc.Text = "UC:";
            // 
            // lblMensagem
            // 
            this.lblMensagem.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblMensagem.Location = new System.Drawing.Point(4, 58);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(82, 22);
            this.lblMensagem.Text = "Mensagem";
            // 
            // txbUc
            // 
            this.txbUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbUc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMensagemUc, "NUM_UC", true));
            this.txbUc.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.txbUc.Location = new System.Drawing.Point(32, 33);
            this.txbUc.Name = "txbUc";
            this.txbUc.Size = new System.Drawing.Size(63, 22);
            this.txbUc.TabIndex = 18;
            this.txbUc.TabStop = false;
            // 
            // bsMensagemUc
            // 
            this.bsMensagemUc.DataSource = typeof(LTmobileData.Data.Model.mensagemUc);
            // 
            // txbMensagem
            // 
            this.txbMensagem.BackColor = System.Drawing.Color.Gold;
            this.txbMensagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMensagemUc, "DESC_MSG", true));
            this.txbMensagem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txbMensagem.Location = new System.Drawing.Point(4, 78);
            this.txbMensagem.Multiline = true;
            this.txbMensagem.Name = "txbMensagem";
            this.txbMensagem.Size = new System.Drawing.Size(218, 72);
            this.txbMensagem.TabIndex = 20;
            this.txbMensagem.TabStop = false;
            this.txbMensagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIndice
            // 
            this.lblIndice.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.lblIndice.Location = new System.Drawing.Point(179, 35);
            this.lblIndice.Name = "lblIndice";
            this.lblIndice.Size = new System.Drawing.Size(42, 22);
            this.lblIndice.Text = "Indice";
            // 
            // frmMensagemUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.lblIndice);
            this.Controls.Add(this.txbMensagem);
            this.Controls.Add(this.txbUc);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.lblUc);
            this.Controls.Add(this.tlMensagemUc);
            this.Menu = this.mainMenu1;
            this.Name = "frmMensagemUc";
            this.Text = "frmMensagemUc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMensagemUc_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.bsMensagemUc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlMensagemUc;
        private System.Windows.Forms.Label lblUc;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.TextBox txbUc;
        private System.Windows.Forms.TextBox txbMensagem;
        private System.Windows.Forms.MenuItem btnOk;
        private System.Windows.Forms.BindingSource bsMensagemUc;
        private System.Windows.Forms.MenuItem mnMenu;
        private System.Windows.Forms.Label lblIndice;
    }
}