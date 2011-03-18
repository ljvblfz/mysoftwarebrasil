namespace LTmobile.View
{
    partial class frmFiltrarRota
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
            this.btnFiltrar = new System.Windows.Forms.MenuItem();
            this.btnCancelar = new System.Windows.Forms.MenuItem();
            this.lblRazao = new System.Windows.Forms.Label();
            this.lblRota = new System.Windows.Forms.Label();
            this.cmbRazao = new System.Windows.Forms.ComboBox();
            this.cmbRota = new System.Windows.Forms.ComboBox();
            this.lblServico = new System.Windows.Forms.Label();
            this.cmbServico = new System.Windows.Forms.ComboBox();
            this.tlFiltrarRota = new MobileTools.Controls.Title();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnFiltrar);
            this.mainMenu1.MenuItems.Add(this.btnCancelar);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Text = "Sair";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblRazao
            // 
            this.lblRazao.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblRazao.Location = new System.Drawing.Point(50, 72);
            this.lblRazao.Name = "lblRazao";
            this.lblRazao.Size = new System.Drawing.Size(152, 15);
            this.lblRazao.Text = "Etapa";
            // 
            // lblRota
            // 
            this.lblRota.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblRota.Location = new System.Drawing.Point(50, 116);
            this.lblRota.Name = "lblRota";
            this.lblRota.Size = new System.Drawing.Size(152, 14);
            this.lblRota.Text = "Rota/Livro";
            // 
            // cmbRazao
            // 
            this.cmbRazao.BackColor = System.Drawing.SystemColors.Info;
            this.cmbRazao.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.cmbRazao.Location = new System.Drawing.Point(50, 90);
            this.cmbRazao.Name = "cmbRazao";
            this.cmbRazao.Size = new System.Drawing.Size(148, 22);
            this.cmbRazao.TabIndex = 1;
            this.cmbRazao.SelectedIndexChanged += new System.EventHandler(this.cmbRazao_SelectedIndexChanged);
            // 
            // cmbRota
            // 
            this.cmbRota.BackColor = System.Drawing.SystemColors.Info;
            this.cmbRota.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.cmbRota.Location = new System.Drawing.Point(50, 133);
            this.cmbRota.Name = "cmbRota";
            this.cmbRota.Size = new System.Drawing.Size(146, 22);
            this.cmbRota.TabIndex = 2;
            // 
            // lblServico
            // 
            this.lblServico.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblServico.Location = new System.Drawing.Point(50, 27);
            this.lblServico.Name = "lblServico";
            this.lblServico.Size = new System.Drawing.Size(152, 16);
            this.lblServico.Text = "Serviço";
            // 
            // cmbServico
            // 
            this.cmbServico.BackColor = System.Drawing.SystemColors.Info;
            this.cmbServico.Location = new System.Drawing.Point(50, 46);
            this.cmbServico.Name = "cmbServico";
            this.cmbServico.TabIndex = 0;
            this.cmbServico.SelectedIndexChanged += new System.EventHandler(this.cmbServico_SelectedIndexChanged);
            // 
            // tlFiltrarRota
            // 
            this.tlFiltrarRota.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlFiltrarRota.DistanceWordLine = 2;
            this.tlFiltrarRota.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlFiltrarRota.HeightLine = 10;
            this.tlFiltrarRota.Location = new System.Drawing.Point(0, 0);
            this.tlFiltrarRota.Name = "tlFiltrarRota";
            this.tlFiltrarRota.Size = new System.Drawing.Size(224, 28);
            this.tlFiltrarRota.TabIndex = 12;
            this.tlFiltrarRota.Text = "Filtrar Rota";
            this.tlFiltrarRota.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlFiltrarRota.WidthInclination = 10;
            // 
            // frmFiltrarRota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.cmbServico);
            this.Controls.Add(this.lblServico);
            this.Controls.Add(this.cmbRota);
            this.Controls.Add(this.cmbRazao);
            this.Controls.Add(this.lblRota);
            this.Controls.Add(this.lblRazao);
            this.Controls.Add(this.tlFiltrarRota);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmFiltrarRota";
            this.Text = "frmFiltrarRota";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFiltrarRota_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmFiltrarRota_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFiltrarRota_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlFiltrarRota;
        private System.Windows.Forms.Label lblRazao;
        private System.Windows.Forms.Label lblRota;
        private System.Windows.Forms.MenuItem btnFiltrar;
        private System.Windows.Forms.MenuItem btnCancelar;
        private System.Windows.Forms.ComboBox cmbRazao;
        private System.Windows.Forms.ComboBox cmbRota;
        private System.Windows.Forms.Label lblServico;
        private System.Windows.Forms.ComboBox cmbServico;
    }
}