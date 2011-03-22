namespace SPCadMobile.View
{
    partial class frmRegistroOcorrencias
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroOcorrencias));
            this.ckbFoto = new System.Windows.Forms.CheckBox();
            this.btnFoto = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.tbxDescricao = new System.Windows.Forms.TextBox();
            this.bindingSourceOcorrencia = new System.Windows.Forms.BindingSource(this.components);
            this.lblDescricao = new System.Windows.Forms.Label();
            this.btnRemover = new System.Windows.Forms.Button();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.lblCod = new System.Windows.Forms.Label();
            this.dgOcorrencia = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lupa = new MobileTools.Controls.UltraButton();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOcorrencia)).BeginInit();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = " ";
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
            // panel
            // 
            this.panel.Controls.Add(this.lupa);
            this.panel.Controls.Add(this.ckbFoto);
            this.panel.Controls.Add(this.btnFoto);
            this.panel.Controls.Add(this.btnAdicionar);
            this.panel.Controls.Add(this.tbxDescricao);
            this.panel.Controls.Add(this.lblDescricao);
            this.panel.Controls.Add(this.btnRemover);
            this.panel.Controls.Add(this.tbxCodigo);
            this.panel.Controls.Add(this.lblCod);
            this.panel.Controls.Add(this.dgOcorrencia);
            this.panel.Size = new System.Drawing.Size(240, 259);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title.Text = "Registro de Ocorrências";
            // 
            // ckbFoto
            // 
            this.ckbFoto.Enabled = false;
            this.ckbFoto.Location = new System.Drawing.Point(86, 224);
            this.ckbFoto.Name = "ckbFoto";
            this.ckbFoto.Size = new System.Drawing.Size(19, 19);
            this.ckbFoto.TabIndex = 6;
            this.ckbFoto.Visible = false;
            // 
            // btnFoto
            // 
            this.btnFoto.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFoto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnFoto.Location = new System.Drawing.Point(3, 224);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(83, 20);
            this.btnFoto.TabIndex = 5;
            this.btnFoto.Text = "Fotos";
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAdicionar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnAdicionar.Location = new System.Drawing.Point(154, 198);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(83, 20);
            this.btnAdicionar.TabIndex = 4;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // tbxDescricao
            // 
            this.tbxDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDescricao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceOcorrencia, "Description", true));
            this.tbxDescricao.Location = new System.Drawing.Point(3, 154);
            this.tbxDescricao.MaxLength = 30;
            this.tbxDescricao.Multiline = true;
            this.tbxDescricao.Name = "tbxDescricao";
            this.tbxDescricao.ReadOnly = true;
            this.tbxDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDescricao.Size = new System.Drawing.Size(234, 37);
            this.tbxDescricao.TabIndex = 1;
            // 
            // bindingSourceOcorrencia
            // 
            this.bindingSourceOcorrencia.DataSource = typeof(CommonHelpMobile.ItemCombo);
            this.bindingSourceOcorrencia.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.bindingSource_BindingComplete);
            // 
            // lblDescricao
            // 
            this.lblDescricao.Location = new System.Drawing.Point(3, 139);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(100, 15);
            this.lblDescricao.Text = "Descrição:";
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemover.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRemover.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnRemover.Location = new System.Drawing.Point(154, 224);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(83, 20);
            this.btnRemover.TabIndex = 7;
            this.btnRemover.Text = "Remover";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.Location = new System.Drawing.Point(50, 197);
            this.tbxCodigo.MaxLength = 3;
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(53, 21);
            this.tbxCodigo.TabIndex = 2;
            this.tbxCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.campo_KeyPress);
            // 
            // lblCod
            // 
            this.lblCod.Location = new System.Drawing.Point(3, 200);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(46, 15);
            this.lblCod.Text = "Cod.:";
            // 
            // dgOcorrencia
            // 
            this.dgOcorrencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOcorrencia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgOcorrencia.DataSource = this.bindingSourceOcorrencia;
            this.dgOcorrencia.Location = new System.Drawing.Point(3, 3);
            this.dgOcorrencia.Name = "dgOcorrencia";
            this.dgOcorrencia.Size = new System.Drawing.Size(234, 133);
            this.dgOcorrencia.TabIndex = 153;
            this.dgOcorrencia.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.MappingName = "ItemCombo";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Cod.";
            this.dataGridTextBoxColumn1.MappingName = "Value";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridTextBoxColumn2.MappingName = "Description";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 165;
            // 
            // lupa
            // 
            this.lupa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lupa.BorderColor = System.Drawing.Color.Transparent;
            this.lupa.ButtonColor = System.Drawing.Color.White;
            this.lupa.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.lupa.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("lupa.ImageButton")));
            this.lupa.ImageButtonView = true;
            this.lupa.Location = new System.Drawing.Point(109, 197);
            this.lupa.Name = "lupa";
            this.lupa.Radius = 8;
            this.lupa.Size = new System.Drawing.Size(23, 21);
            this.lupa.TabIndex = 3;
            this.lupa.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.lupa.TextColor = System.Drawing.SystemColors.WindowText;
            this.lupa.TextColorClick = System.Drawing.Color.White;
            this.lupa.Click += new System.EventHandler(this.lupa_Click);
            // 
            // frmRegistroOcorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRegistroOcorrencias";
            this.Text = "Registro de Ocorrências";
            this.Title = "Registro de Ocorrências";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOcorrencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbFoto;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox tbxDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.DataGrid dgOcorrencia;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.BindingSource bindingSourceOcorrencia;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private MobileTools.Controls.UltraButton lupa;

    }
}