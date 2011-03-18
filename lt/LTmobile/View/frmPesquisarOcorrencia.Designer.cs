namespace LTmobile.View
{
    partial class frmPesquisarOcorrencia
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
            this.mnSelecionar = new System.Windows.Forms.MenuItem();
            this.mnSair = new System.Windows.Forms.MenuItem();
            this.tlPesqOcorrencia = new MobileTools.Controls.Title();
            this.bsPesqOcorrencia = new System.Windows.Forms.BindingSource(this.components);
            this.grdPesqOcorrencia = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblOcorrencia = new System.Windows.Forms.Label();
            this.txbOcorrencia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsPesqOcorrencia)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnSelecionar);
            this.mainMenu1.MenuItems.Add(this.mnSair);
            // 
            // mnSelecionar
            // 
            this.mnSelecionar.Text = "Selecionar";
            this.mnSelecionar.Click += new System.EventHandler(this.mnSelecionar_Click);
            // 
            // mnSair
            // 
            this.mnSair.Text = "Sair";
            this.mnSair.Click += new System.EventHandler(this.mnSair_Click);
            // 
            // tlPesqOcorrencia
            // 
            this.tlPesqOcorrencia.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlPesqOcorrencia.DistanceWordLine = 2;
            this.tlPesqOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.tlPesqOcorrencia.HeightLine = 10;
            this.tlPesqOcorrencia.Location = new System.Drawing.Point(0, 0);
            this.tlPesqOcorrencia.Name = "tlPesqOcorrencia";
            this.tlPesqOcorrencia.Size = new System.Drawing.Size(216, 28);
            this.tlPesqOcorrencia.TabIndex = 15;
            this.tlPesqOcorrencia.Text = "Pesquisar Ocorrência";
            this.tlPesqOcorrencia.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlPesqOcorrencia.WidthInclination = 10;
            // 
            // bsPesqOcorrencia
            // 
            this.bsPesqOcorrencia.DataSource = typeof(LTmobileData.Data.Model.Ocorrencia);
            // 
            // grdPesqOcorrencia
            // 
            this.grdPesqOcorrencia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdPesqOcorrencia.DataSource = this.bsPesqOcorrencia;
            this.grdPesqOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.grdPesqOcorrencia.Location = new System.Drawing.Point(0, 30);
            this.grdPesqOcorrencia.Name = "grdPesqOcorrencia";
            this.grdPesqOcorrencia.SelectionForeColor = System.Drawing.SystemColors.Info;
            this.grdPesqOcorrencia.Size = new System.Drawing.Size(228, 80);
            this.grdPesqOcorrencia.TabIndex = 16;
            this.grdPesqOcorrencia.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.MappingName = "Ocorrencia";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Cod.";
            this.dataGridTextBoxColumn1.MappingName = "COD_IRREGL";
            this.dataGridTextBoxColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridTextBoxColumn2.MappingName = "DESC_IRREGL";
            this.dataGridTextBoxColumn2.Width = 149;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Imp.";
            this.dataGridTextBoxColumn3.MappingName = "FLAG_IMPEDIMENTO";
            this.dataGridTextBoxColumn3.Width = 25;
            // 
            // lblOcorrencia
            // 
            this.lblOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblOcorrencia.Location = new System.Drawing.Point(0, 112);
            this.lblOcorrencia.Name = "lblOcorrencia";
            this.lblOcorrencia.Size = new System.Drawing.Size(152, 14);
            this.lblOcorrencia.Text = "Ocorrência";
            // 
            // txbOcorrencia
            // 
            this.txbOcorrencia.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbOcorrencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPesqOcorrencia, "DESC_IRREGL", true));
            this.txbOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbOcorrencia.Location = new System.Drawing.Point(4, 126);
            this.txbOcorrencia.Multiline = true;
            this.txbOcorrencia.Name = "txbOcorrencia";
            this.txbOcorrencia.Size = new System.Drawing.Size(224, 29);
            this.txbOcorrencia.TabIndex = 18;
            this.txbOcorrencia.TabStop = false;
            // 
            // frmPesquisarOcorrencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbOcorrencia);
            this.Controls.Add(this.lblOcorrencia);
            this.Controls.Add(this.grdPesqOcorrencia);
            this.Controls.Add(this.tlPesqOcorrencia);
            this.Menu = this.mainMenu1;
            this.Name = "frmPesquisarOcorrencia";
            this.Text = "frmPesquisarOcorrencia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmPesquisarOcorrencia_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.bsPesqOcorrencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlPesqOcorrencia;
        private System.Windows.Forms.DataGrid grdPesqOcorrencia;
        private System.Windows.Forms.BindingSource bsPesqOcorrencia;
        private System.Windows.Forms.Label lblOcorrencia;
        private System.Windows.Forms.TextBox txbOcorrencia;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.MenuItem mnSelecionar;
        private System.Windows.Forms.MenuItem mnSair;
    }
}