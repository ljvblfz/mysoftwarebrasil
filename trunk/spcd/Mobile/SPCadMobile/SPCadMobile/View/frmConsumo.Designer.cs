namespace SPCadMobile.View
{
    partial class frmConsumo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.tabConsumo = new System.Windows.Forms.TabPage();
            this.tbxMedia = new System.Windows.Forms.TextBox();
            this.lblMedia = new System.Windows.Forms.Label();
            this.tbxCriterioApu = new System.Windows.Forms.TextBox();
            this.bsHistoricoConsumo = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDataInstall = new System.Windows.Forms.TextBox();
            this.lblDataInstall = new System.Windows.Forms.Label();
            this.tbxOcorr2 = new System.Windows.Forms.TextBox();
            this.lblOcorr2 = new System.Windows.Forms.Label();
            this.tbxOcorr1 = new System.Windows.Forms.TextBox();
            this.lblOcorr1 = new System.Windows.Forms.Label();
            this.dataGridConsumo = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.colMes = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colConsumo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colOcorr1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colOcorr2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colCA = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabInfConsumo = new System.Windows.Forms.TabPage();
            this.cbxExpectativaCons = new System.Windows.Forms.ComboBox();
            this.bindingSourceAuxCadConsum = new System.Windows.Forms.BindingSource(this.components);
            this.lblEspectativaCons = new System.Windows.Forms.Label();
            this.lblObsNaoconf = new System.Windows.Forms.Label();
            this.rbIncompatib = new MobileTools.Controls.RadioButtonGroup();
            this.radioButtonEx5 = new MobileTools.Controls.RadioButtonEx();
            this.radioButtonEx6 = new MobileTools.Controls.RadioButtonEx();
            this.lblIncompatib = new System.Windows.Forms.Label();
            this.tbxObsNaoConf = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabConsumo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsHistoricoConsumo)).BeginInit();
            this.tabInfConsumo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAuxCadConsum)).BeginInit();
            this.rbIncompatib.SuspendLayout();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            // 
            // menuItem1
            // 
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // chkConfirmado
            // 
            this.chkConfirmado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // lblAlterado
            // 
            this.lblAlterado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConsumo);
            this.tabControl1.Controls.Add(this.tabInfConsumo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Size = new System.Drawing.Size(239, 259);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.MappingName = "Grids";
            // 
            // tabConsumo
            // 
            this.tabConsumo.Controls.Add(this.tbxMedia);
            this.tabConsumo.Controls.Add(this.lblMedia);
            this.tabConsumo.Controls.Add(this.tbxCriterioApu);
            this.tabConsumo.Controls.Add(this.label1);
            this.tabConsumo.Controls.Add(this.tbxDataInstall);
            this.tabConsumo.Controls.Add(this.lblDataInstall);
            this.tabConsumo.Controls.Add(this.tbxOcorr2);
            this.tabConsumo.Controls.Add(this.lblOcorr2);
            this.tabConsumo.Controls.Add(this.tbxOcorr1);
            this.tabConsumo.Controls.Add(this.lblOcorr1);
            this.tabConsumo.Controls.Add(this.dataGridConsumo);
            this.tabConsumo.Location = new System.Drawing.Point(0, 0);
            this.tabConsumo.Name = "tabConsumo";
            this.tabConsumo.Size = new System.Drawing.Size(239, 236);
            this.tabConsumo.Text = "Consumo";
            // 
            // tbxMedia
            // 
            this.tbxMedia.Location = new System.Drawing.Point(52, 190);
            this.tbxMedia.Name = "tbxMedia";
            this.tbxMedia.ReadOnly = true;
            this.tbxMedia.Size = new System.Drawing.Size(183, 21);
            this.tbxMedia.TabIndex = 77;
            // 
            // lblMedia
            // 
            this.lblMedia.Location = new System.Drawing.Point(8, 191);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(42, 20);
            this.lblMedia.Text = "Média:";
            // 
            // tbxCriterioApu
            // 
            this.tbxCriterioApu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCriterioApu.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistoricoConsumo, "DescCriterio", true));
            this.tbxCriterioApu.Location = new System.Drawing.Point(52, 165);
            this.tbxCriterioApu.Name = "tbxCriterioApu";
            this.tbxCriterioApu.ReadOnly = true;
            this.tbxCriterioApu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxCriterioApu.Size = new System.Drawing.Size(183, 21);
            this.tbxCriterioApu.TabIndex = 3;
            // 
            // bsHistoricoConsumo
            // 
            this.bsHistoricoConsumo.DataSource = typeof(SPCadMobileData.Data.Model.HistoricoConsumo);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.Text = "C.A. :";
            // 
            // tbxDataInstall
            // 
            this.tbxDataInstall.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistoricoConsumo, "DataInstalacaoText", true));
            this.tbxDataInstall.Location = new System.Drawing.Point(106, 214);
            this.tbxDataInstall.Name = "tbxDataInstall";
            this.tbxDataInstall.ReadOnly = true;
            this.tbxDataInstall.Size = new System.Drawing.Size(88, 21);
            this.tbxDataInstall.TabIndex = 4;
            // 
            // lblDataInstall
            // 
            this.lblDataInstall.Location = new System.Drawing.Point(3, 214);
            this.lblDataInstall.Name = "lblDataInstall";
            this.lblDataInstall.Size = new System.Drawing.Size(97, 16);
            this.lblDataInstall.Text = "Data Instalação:";
            // 
            // tbxOcorr2
            // 
            this.tbxOcorr2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxOcorr2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistoricoConsumo, "DescOcorrencia2", true));
            this.tbxOcorr2.Location = new System.Drawing.Point(52, 142);
            this.tbxOcorr2.Name = "tbxOcorr2";
            this.tbxOcorr2.ReadOnly = true;
            this.tbxOcorr2.Size = new System.Drawing.Size(183, 21);
            this.tbxOcorr2.TabIndex = 2;
            // 
            // lblOcorr2
            // 
            this.lblOcorr2.Location = new System.Drawing.Point(3, 140);
            this.lblOcorr2.Name = "lblOcorr2";
            this.lblOcorr2.Size = new System.Drawing.Size(47, 16);
            this.lblOcorr2.Text = "Ocorr2:";
            // 
            // tbxOcorr1
            // 
            this.tbxOcorr1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxOcorr1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistoricoConsumo, "DescOcorrencia1", true));
            this.tbxOcorr1.Location = new System.Drawing.Point(52, 119);
            this.tbxOcorr1.Name = "tbxOcorr1";
            this.tbxOcorr1.ReadOnly = true;
            this.tbxOcorr1.Size = new System.Drawing.Size(183, 21);
            this.tbxOcorr1.TabIndex = 1;
            // 
            // lblOcorr1
            // 
            this.lblOcorr1.Location = new System.Drawing.Point(3, 119);
            this.lblOcorr1.Name = "lblOcorr1";
            this.lblOcorr1.Size = new System.Drawing.Size(47, 16);
            this.lblOcorr1.Text = "Ocorr1:";
            // 
            // dataGridConsumo
            // 
            this.dataGridConsumo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridConsumo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridConsumo.DataSource = this.bsHistoricoConsumo;
            this.dataGridConsumo.Location = new System.Drawing.Point(0, 3);
            this.dataGridConsumo.Name = "dataGridConsumo";
            this.dataGridConsumo.Size = new System.Drawing.Size(236, 113);
            this.dataGridConsumo.TabIndex = 75;
            this.dataGridConsumo.TableStyles.Add(this.dataGridTableStyle2);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.GridColumnStyles.Add(this.colMes);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.colConsumo);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.colOcorr1);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.colOcorr2);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.colCA);
            this.dataGridTableStyle2.MappingName = "HistoricoConsumo";
            // 
            // colMes
            // 
            this.colMes.Format = "MM/yyyy";
            this.colMes.FormatInfo = null;
            this.colMes.HeaderText = "Mês";
            this.colMes.MappingName = "MesReferencia";
            this.colMes.NullText = "";
            this.colMes.Width = 45;
            // 
            // colConsumo
            // 
            this.colConsumo.Format = "";
            this.colConsumo.FormatInfo = null;
            this.colConsumo.HeaderText = "Consumo";
            this.colConsumo.MappingName = "VolumeMedido";
            this.colConsumo.NullText = "";
            this.colConsumo.Width = 55;
            // 
            // colOcorr1
            // 
            this.colOcorr1.Format = "";
            this.colOcorr1.FormatInfo = null;
            this.colOcorr1.HeaderText = "Oc1";
            this.colOcorr1.MappingName = "Ocorrencia1";
            this.colOcorr1.NullText = "";
            this.colOcorr1.Width = 25;
            // 
            // colOcorr2
            // 
            this.colOcorr2.Format = "";
            this.colOcorr2.FormatInfo = null;
            this.colOcorr2.HeaderText = "Oc2";
            this.colOcorr2.MappingName = "Ocorrencia2";
            this.colOcorr2.NullText = "";
            this.colOcorr2.Width = 25;
            // 
            // colCA
            // 
            this.colCA.Format = "";
            this.colCA.FormatInfo = null;
            this.colCA.HeaderText = "C.A.";
            this.colCA.MappingName = "DescCriterio";
            this.colCA.NullText = "";
            this.colCA.Width = 60;
            // 
            // tabInfConsumo
            // 
            this.tabInfConsumo.Controls.Add(this.cbxExpectativaCons);
            this.tabInfConsumo.Controls.Add(this.lblEspectativaCons);
            this.tabInfConsumo.Controls.Add(this.lblObsNaoconf);
            this.tabInfConsumo.Controls.Add(this.rbIncompatib);
            this.tabInfConsumo.Controls.Add(this.lblIncompatib);
            this.tabInfConsumo.Controls.Add(this.tbxObsNaoConf);
            this.tabInfConsumo.Location = new System.Drawing.Point(0, 0);
            this.tabInfConsumo.Name = "tabInfConsumo";
            this.tabInfConsumo.Size = new System.Drawing.Size(232, 233);
            this.tabInfConsumo.Text = "Inf. Consumo";
            // 
            // cbxExpectativaCons
            // 
            this.cbxExpectativaCons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxExpectativaCons.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceAuxCadConsum, "ExpectativaConsu", true));
            this.cbxExpectativaCons.DisplayMember = "Description";
            this.cbxExpectativaCons.Location = new System.Drawing.Point(103, 12);
            this.cbxExpectativaCons.Name = "cbxExpectativaCons";
            this.cbxExpectativaCons.Size = new System.Drawing.Size(126, 22);
            this.cbxExpectativaCons.TabIndex = 1;
            this.cbxExpectativaCons.ValueMember = "Value";
            // 
            // bindingSourceAuxCadConsum
            // 
            this.bindingSourceAuxCadConsum.DataSource = typeof(SPCadMobileData.Data.Model.AuxConsCadast);
            // 
            // lblEspectativaCons
            // 
            this.lblEspectativaCons.Location = new System.Drawing.Point(2, 12);
            this.lblEspectativaCons.Name = "lblEspectativaCons";
            this.lblEspectativaCons.Size = new System.Drawing.Size(106, 20);
            this.lblEspectativaCons.Text = "Expectativa Cons.:";
            // 
            // lblObsNaoconf
            // 
            this.lblObsNaoconf.Location = new System.Drawing.Point(4, 74);
            this.lblObsNaoconf.Name = "lblObsNaoconf";
            this.lblObsNaoconf.Size = new System.Drawing.Size(199, 15);
            this.lblObsNaoconf.Text = "Observação de incompatibilidade:";
            // 
            // rbIncompatib
            // 
            this.rbIncompatib.Controls.Add(this.radioButtonEx5);
            this.rbIncompatib.Controls.Add(this.radioButtonEx6);
            this.rbIncompatib.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceAuxCadConsum, "Incompatibilidade", true));
            this.rbIncompatib.Location = new System.Drawing.Point(132, 40);
            this.rbIncompatib.Name = "rbIncompatib";
            this.rbIncompatib.SelectedValue = null;
            this.rbIncompatib.Size = new System.Drawing.Size(104, 23);
            this.rbIncompatib.Tag = "4";
            this.rbIncompatib.SelectedValueChanged += new System.EventHandler(this.rbIncompatib_SelectedValueChanged);
            // 
            // radioButtonEx5
            // 
            this.radioButtonEx5.Location = new System.Drawing.Point(52, 4);
            this.radioButtonEx5.Name = "radioButtonEx5";
            this.radioButtonEx5.Size = new System.Drawing.Size(43, 18);
            this.radioButtonEx5.TabIndex = 3;
            this.radioButtonEx5.Tag = "2";
            this.radioButtonEx5.Text = "Não";
            this.radioButtonEx5.Value = null;
            // 
            // radioButtonEx6
            // 
            this.radioButtonEx6.Location = new System.Drawing.Point(7, 4);
            this.radioButtonEx6.Name = "radioButtonEx6";
            this.radioButtonEx6.Size = new System.Drawing.Size(43, 18);
            this.radioButtonEx6.TabIndex = 2;
            this.radioButtonEx6.TabStop = false;
            this.radioButtonEx6.Tag = "1";
            this.radioButtonEx6.Text = "Sim";
            this.radioButtonEx6.Value = null;
            // 
            // lblIncompatib
            // 
            this.lblIncompatib.Location = new System.Drawing.Point(4, 45);
            this.lblIncompatib.Name = "lblIncompatib";
            this.lblIncompatib.Size = new System.Drawing.Size(118, 15);
            this.lblIncompatib.Text = "Incompatibilidade:";
            // 
            // tbxObsNaoConf
            // 
            this.tbxObsNaoConf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxObsNaoConf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAuxCadConsum, "ObsNaoConf", true));
            this.tbxObsNaoConf.Location = new System.Drawing.Point(4, 92);
            this.tbxObsNaoConf.MaxLength = 40;
            this.tbxObsNaoConf.Multiline = true;
            this.tbxObsNaoConf.Name = "tbxObsNaoConf";
            this.tbxObsNaoConf.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxObsNaoConf.Size = new System.Drawing.Size(225, 74);
            this.tbxObsNaoConf.TabIndex = 4;
            // 
            // frmConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmConsumo";
            this.Text = "Consumo";
            this.Title = "Consumo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabConsumo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsHistoricoConsumo)).EndInit();
            this.tabInfConsumo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAuxCadConsum)).EndInit();
            this.rbIncompatib.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabConsumo;
        private System.Windows.Forms.DataGrid dataGridConsumo;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.TextBox tbxDataInstall;
        private System.Windows.Forms.Label lblDataInstall;
        private System.Windows.Forms.TextBox tbxOcorr2;
        private System.Windows.Forms.Label lblOcorr2;
        private System.Windows.Forms.TextBox tbxOcorr1;
        private System.Windows.Forms.Label lblOcorr1;
        private System.Windows.Forms.TabPage tabInfConsumo;
        private MobileTools.Controls.RadioButtonGroup rbIncompatib;
        private MobileTools.Controls.RadioButtonEx radioButtonEx5;
        private MobileTools.Controls.RadioButtonEx radioButtonEx6;
        private System.Windows.Forms.Label lblIncompatib;
        private System.Windows.Forms.TextBox tbxObsNaoConf;
        private System.Windows.Forms.Label lblObsNaoconf;
        private System.Windows.Forms.BindingSource bsHistoricoConsumo;
        private System.Windows.Forms.DataGridTextBoxColumn colMes;
        private System.Windows.Forms.DataGridTextBoxColumn colConsumo;
        private System.Windows.Forms.DataGridTextBoxColumn colOcorr1;
        private System.Windows.Forms.DataGridTextBoxColumn colOcorr2;
        private System.Windows.Forms.DataGridTextBoxColumn colCA;
        private System.Windows.Forms.ComboBox cbxExpectativaCons;
        private System.Windows.Forms.Label lblEspectativaCons;
        private System.Windows.Forms.TextBox tbxCriterioApu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSourceAuxCadConsum;
        private System.Windows.Forms.TextBox tbxMedia;
        private System.Windows.Forms.Label lblMedia;
    }
}
