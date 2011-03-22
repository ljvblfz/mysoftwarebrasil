namespace SPCadMobile.View
{
    partial class frmSelecaoRota : CustomForm
    {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxRota = new System.Windows.Forms.ComboBox();
            this.cbxSetor = new System.Windows.Forms.ComboBox();
            this.cbxDistrito = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSetor = new System.Windows.Forms.Label();
            this.lblDistrito = new System.Windows.Forms.Label();
            this.mItemEstatistica = new System.Windows.Forms.MenuItem();
            this.mItemVoltar = new System.Windows.Forms.MenuItem();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Selecionar";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.mItemEstatistica);
            this.menuItem2.MenuItems.Add(this.mItemVoltar);
            this.menuItem2.Text = "Opções";
            // 
            // chkConfirmado
            // 
            this.chkConfirmado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // lblAlterado
            // 
            this.lblAlterado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cbxRota);
            this.panel.Controls.Add(this.cbxSetor);
            this.panel.Controls.Add(this.cbxDistrito);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.lblSetor);
            this.panel.Controls.Add(this.lblDistrito);
            this.panel.Size = new System.Drawing.Size(240, 259);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title.Text = "Seleção de Roteiro";
            // 
            // cbxRota
            // 
            this.cbxRota.BackColor = System.Drawing.SystemColors.Info;
            this.cbxRota.DisplayMember = "Description";
            this.cbxRota.Location = new System.Drawing.Point(70, 185);
            this.cbxRota.Name = "cbxRota";
            this.cbxRota.Size = new System.Drawing.Size(115, 22);
            this.cbxRota.TabIndex = 3;
            this.cbxRota.ValueMember = "Value";
            // 
            // cbxSetor
            // 
            this.cbxSetor.BackColor = System.Drawing.SystemColors.Info;
            this.cbxSetor.DisplayMember = "Description";
            this.cbxSetor.Location = new System.Drawing.Point(70, 119);
            this.cbxSetor.Name = "cbxSetor";
            this.cbxSetor.Size = new System.Drawing.Size(115, 22);
            this.cbxSetor.TabIndex = 2;
            this.cbxSetor.ValueMember = "Value";
            this.cbxSetor.SelectedValueChanged += new System.EventHandler(this.cbxSetor_SelectedValueChanged);
            // 
            // cbxDistrito
            // 
            this.cbxDistrito.BackColor = System.Drawing.SystemColors.Info;
            this.cbxDistrito.DisplayMember = "Description";
            this.cbxDistrito.Location = new System.Drawing.Point(70, 52);
            this.cbxDistrito.Name = "cbxDistrito";
            this.cbxDistrito.Size = new System.Drawing.Size(156, 22);
            this.cbxDistrito.TabIndex = 1;
            this.cbxDistrito.ValueMember = "Value";
            this.cbxDistrito.SelectedValueChanged += new System.EventHandler(this.cbxDistrito_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(14, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.Text = "Rota:";
            // 
            // lblSetor
            // 
            this.lblSetor.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lblSetor.Location = new System.Drawing.Point(14, 119);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(50, 20);
            this.lblSetor.Text = "Setor:";
            // 
            // lblDistrito
            // 
            this.lblDistrito.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lblDistrito.Location = new System.Drawing.Point(11, 52);
            this.lblDistrito.Name = "lblDistrito";
            this.lblDistrito.Size = new System.Drawing.Size(58, 20);
            this.lblDistrito.Text = "Distrito:";
            // 
            // mItemEstatistica
            // 
            this.mItemEstatistica.Text = "Estatística";
            this.mItemEstatistica.Click += new System.EventHandler(this.mItemEstatistica_Click);
            // 
            // mItemVoltar
            // 
            this.mItemVoltar.Text = "Voltar";
            this.mItemVoltar.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // frmSelecaoRota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSelecaoRota";
            this.Text = "frmSelecaoRota";
            this.Title = "Seleção de Roteiro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSelecaoRota_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxRota;
        private System.Windows.Forms.ComboBox cbxSetor;
        private System.Windows.Forms.ComboBox cbxDistrito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSetor;
        private System.Windows.Forms.Label lblDistrito;
        private System.Windows.Forms.MenuItem mItemEstatistica;
        private System.Windows.Forms.MenuItem mItemVoltar;

    }
}