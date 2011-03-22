namespace SPCadMobile.View
{
    partial class frmPesquisaOcorrencias : CustomForm
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaOcorrencias));
            this.lupa = new MobileTools.Controls.UltraButton();
            this.tbxDescricaoExibicao = new System.Windows.Forms.TextBox();
            this.bindingSourceOcorrencia = new System.Windows.Forms.BindingSource(this.components);
            this.lblDescricao2 = new System.Windows.Forms.Label();
            this.tbxDescricaoPesquisa = new System.Windows.Forms.TextBox();
            this.lblDescricao1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
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
            this.menuItem1.Text = "Selecionar";
            this.menuItem1.Click += new System.EventHandler(this.selecionarMenuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Click += new System.EventHandler(this.cancelarMenuItem_Click);
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
            this.panel.Controls.Add(this.tbxDescricaoExibicao);
            this.panel.Controls.Add(this.lblDescricao2);
            this.panel.Controls.Add(this.tbxDescricaoPesquisa);
            this.panel.Controls.Add(this.lblDescricao1);
            this.panel.Controls.Add(this.dataGrid1);
            this.panel.Size = new System.Drawing.Size(240, 259);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title.Text = "Pesquisa Ocorrencias";
            // 
            // lupa
            // 
            this.lupa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lupa.BorderColor = System.Drawing.Color.Transparent;
            this.lupa.ButtonColor = System.Drawing.Color.White;
            this.lupa.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.lupa.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("lupa.ImageButton")));
            this.lupa.ImageButtonView = true;
            this.lupa.Location = new System.Drawing.Point(214, 20);
            this.lupa.Name = "lupa";
            this.lupa.Radius = 8;
            this.lupa.Size = new System.Drawing.Size(23, 21);
            this.lupa.TabIndex = 152;
            this.lupa.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.lupa.TextColor = System.Drawing.SystemColors.WindowText;
            this.lupa.TextColorClick = System.Drawing.Color.White;
            this.lupa.Click += new System.EventHandler(this.lupaBox_Click);
            // 
            // tbxDescricaoExibicao
            // 
            this.tbxDescricaoExibicao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDescricaoExibicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceOcorrencia, "Descricao", true));
            this.tbxDescricaoExibicao.Location = new System.Drawing.Point(3, 210);
            this.tbxDescricaoExibicao.Multiline = true;
            this.tbxDescricaoExibicao.Name = "tbxDescricaoExibicao";
            this.tbxDescricaoExibicao.ReadOnly = true;
            this.tbxDescricaoExibicao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDescricaoExibicao.Size = new System.Drawing.Size(234, 46);
            this.tbxDescricaoExibicao.TabIndex = 151;
            // 
            // bindingSourceOcorrencia
            // 
            this.bindingSourceOcorrencia.DataSource = typeof(SPCadMobileData.Data.Model.Ocorrencia);
            // 
            // lblDescricao2
            // 
            this.lblDescricao2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescricao2.Location = new System.Drawing.Point(3, 195);
            this.lblDescricao2.Name = "lblDescricao2";
            this.lblDescricao2.Size = new System.Drawing.Size(100, 15);
            this.lblDescricao2.Text = "Descrição:";
            // 
            // tbxDescricaoPesquisa
            // 
            this.tbxDescricaoPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDescricaoPesquisa.Location = new System.Drawing.Point(3, 20);
            this.tbxDescricaoPesquisa.Name = "tbxDescricaoPesquisa";
            this.tbxDescricaoPesquisa.Size = new System.Drawing.Size(205, 21);
            this.tbxDescricaoPesquisa.TabIndex = 150;
            // 
            // lblDescricao1
            // 
            this.lblDescricao1.Location = new System.Drawing.Point(3, 3);
            this.lblDescricao1.Name = "lblDescricao1";
            this.lblDescricao1.Size = new System.Drawing.Size(68, 15);
            this.lblDescricao1.Text = "Descrição:";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.DataSource = this.bindingSourceOcorrencia;
            this.dataGrid1.Location = new System.Drawing.Point(3, 45);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(234, 147);
            this.dataGrid1.TabIndex = 149;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.MappingName = "Ocorrencia";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Cod.";
            this.dataGridTextBoxColumn1.MappingName = "Id";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridTextBoxColumn2.MappingName = "Descricao";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 160;
            // 
            // frmPesquisaOcorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPesquisaOcorrencias";
            this.Text = "Pesquisa Ocorrencias";
            this.Title = "Pesquisa Ocorrencias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOcorrencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.UltraButton lupa;
        private System.Windows.Forms.TextBox tbxDescricaoExibicao;
        private System.Windows.Forms.Label lblDescricao2;
        private System.Windows.Forms.TextBox tbxDescricaoPesquisa;
        private System.Windows.Forms.Label lblDescricao1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.BindingSource bindingSourceOcorrencia;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
    }
}