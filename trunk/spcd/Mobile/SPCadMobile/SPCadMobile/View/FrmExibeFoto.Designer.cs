namespace SPCadMobile.View
{
    partial class FrmExibeFoto
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
            this.menuItemSalvar = new System.Windows.Forms.MenuItem();
            this.bindingSourceFoto = new System.Windows.Forms.BindingSource(this.components);
            this.inputPanelTeclado = new Microsoft.WindowsCE.Forms.InputPanel();
            this.panelImagem = new System.Windows.Forms.Panel();
            this.lblLegenda = new System.Windows.Forms.Label();
            this.tbxLegenda = new System.Windows.Forms.TextBox();
            this.picBoxFoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFoto)).BeginInit();
            this.panelImagem.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemSalvar);
            // 
            // menuItemSalvar
            // 
            this.menuItemSalvar.Text = "Salvar";
            this.menuItemSalvar.Click += new System.EventHandler(this.menuItemSalvar_Click);
            // 
            // bindingSourceFoto
            // 
            this.bindingSourceFoto.DataSource = typeof(SPCadMobileData.Data.Model.Foto);
            // 
            // inputPanelTeclado
            // 
            this.inputPanelTeclado.EnabledChanged += new System.EventHandler(this.inputPanelTeclado_EnabledChanged);
            // 
            // panelImagem
            // 
            this.panelImagem.Controls.Add(this.lblLegenda);
            this.panelImagem.Controls.Add(this.tbxLegenda);
            this.panelImagem.Controls.Add(this.picBoxFoto);
            this.panelImagem.Location = new System.Drawing.Point(0, 0);
            this.panelImagem.Name = "panelImagem";
            this.panelImagem.Size = new System.Drawing.Size(240, 294);
            // 
            // lblLegenda
            // 
            this.lblLegenda.Location = new System.Drawing.Point(90, 196);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(56, 20);
            this.lblLegenda.Text = "Legenda";
            // 
            // tbxLegenda
            // 
            this.tbxLegenda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLegenda.BackColor = System.Drawing.SystemColors.Info;
            this.tbxLegenda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceFoto, "descFoto", true));
            this.tbxLegenda.Location = new System.Drawing.Point(1, 223);
            this.tbxLegenda.MaxLength = 100;
            this.tbxLegenda.Multiline = true;
            this.tbxLegenda.Name = "tbxLegenda";
            this.tbxLegenda.Size = new System.Drawing.Size(234, 37);
            this.tbxLegenda.TabIndex = 5;
            // 
            // picBoxFoto
            // 
            this.picBoxFoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxFoto.Location = new System.Drawing.Point(3, 8);
            this.picBoxFoto.Name = "picBoxFoto";
            this.picBoxFoto.Size = new System.Drawing.Size(234, 176);
            this.picBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // FrmExibeFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScrollMargin = new System.Drawing.Size(0, 5);
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panelImagem);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.Name = "FrmExibeFoto";
            this.Text = "FrmExibeFoto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFoto)).EndInit();
            this.panelImagem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemSalvar;
        private System.Windows.Forms.BindingSource bindingSourceFoto;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanelTeclado;
        private System.Windows.Forms.Panel panelImagem;
        private System.Windows.Forms.Label lblLegenda;
        private System.Windows.Forms.TextBox tbxLegenda;
        private System.Windows.Forms.PictureBox picBoxFoto;
    }
}