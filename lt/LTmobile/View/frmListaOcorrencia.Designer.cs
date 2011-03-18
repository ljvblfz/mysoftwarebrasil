namespace LTmobile.View
{
    partial class frmListaOcorrencia
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
            this.mnApagar = new System.Windows.Forms.MenuItem();
            this.mnCancelar = new System.Windows.Forms.MenuItem();
            this.tlListaOcorrencia = new MobileTools.Controls.Title();
            this.txbOcorrencia = new System.Windows.Forms.TextBox();
            this.bsListaOcorrencia = new System.Windows.Forms.BindingSource(this.components);
            this.lblOcorrencia = new System.Windows.Forms.Label();
            this.grdPesqOcorrencia = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsListaOcorrencia)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnApagar);
            this.mainMenu1.MenuItems.Add(this.mnCancelar);
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
            // tlListaOcorrencia
            // 
            this.tlListaOcorrencia.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlListaOcorrencia.DistanceWordLine = 2;
            this.tlListaOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.tlListaOcorrencia.HeightLine = 10;
            this.tlListaOcorrencia.Location = new System.Drawing.Point(0, 0);
            this.tlListaOcorrencia.Name = "tlListaOcorrencia";
            this.tlListaOcorrencia.Size = new System.Drawing.Size(216, 28);
            this.tlListaOcorrencia.TabIndex = 16;
            this.tlListaOcorrencia.Text = "Ocorrências Cadastradas";
            this.tlListaOcorrencia.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlListaOcorrencia.WidthInclination = 10;
            // 
            // txbOcorrencia
            // 
            this.txbOcorrencia.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbOcorrencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsListaOcorrencia, "DESC_IRREGL", true));
            this.txbOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbOcorrencia.Location = new System.Drawing.Point(4, 121);
            this.txbOcorrencia.Multiline = true;
            this.txbOcorrencia.Name = "txbOcorrencia";
            this.txbOcorrencia.Size = new System.Drawing.Size(224, 29);
            this.txbOcorrencia.TabIndex = 21;
            this.txbOcorrencia.TabStop = false;
            // 
            // bsListaOcorrencia
            // 
            this.bsListaOcorrencia.DataSource = typeof(LTmobileData.Data.Model.Ocorrencia);
            // 
            // lblOcorrencia
            // 
            this.lblOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblOcorrencia.Location = new System.Drawing.Point(0, 107);
            this.lblOcorrencia.Name = "lblOcorrencia";
            this.lblOcorrencia.Size = new System.Drawing.Size(152, 14);
            this.lblOcorrencia.Text = "Ocorrência";
            // 
            // grdPesqOcorrencia
            // 
            this.grdPesqOcorrencia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdPesqOcorrencia.DataSource = this.bsListaOcorrencia;
            this.grdPesqOcorrencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.grdPesqOcorrencia.Location = new System.Drawing.Point(0, 25);
            this.grdPesqOcorrencia.Name = "grdPesqOcorrencia";
            this.grdPesqOcorrencia.SelectionForeColor = System.Drawing.SystemColors.Info;
            this.grdPesqOcorrencia.Size = new System.Drawing.Size(228, 80);
            this.grdPesqOcorrencia.TabIndex = 20;
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
            this.dataGridTextBoxColumn2.HeaderText = "Ocorrência";
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
            // frmListaOcorrencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbOcorrencia);
            this.Controls.Add(this.lblOcorrencia);
            this.Controls.Add(this.grdPesqOcorrencia);
            this.Controls.Add(this.tlListaOcorrencia);
            this.Menu = this.mainMenu1;
            this.Name = "frmListaOcorrencia";
            this.Text = "frmListaOcorrencia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmListaOcorrencia_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.bsListaOcorrencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlListaOcorrencia;
        private System.Windows.Forms.TextBox txbOcorrencia;
        private System.Windows.Forms.Label lblOcorrencia;
        private System.Windows.Forms.BindingSource bsListaOcorrencia;
        private System.Windows.Forms.DataGrid grdPesqOcorrencia;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.MenuItem mnApagar;
        private System.Windows.Forms.MenuItem mnCancelar;
    }
}