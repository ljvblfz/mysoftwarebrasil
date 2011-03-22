namespace SPCadMobile.View
{
    partial class FrmPesquisaRamoAtividade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaRamoAtividade));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.selecionarMenuItem = new System.Windows.Forms.MenuItem();
            this.cancelarMenuItem = new System.Windows.Forms.MenuItem();
            this.bindingSourceRamoAtividade = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.title1 = new MobileTools.Controls.Title();
            this.cbxTipoAtividade = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descricaoAmostraTextBox = new System.Windows.Forms.TextBox();
            this.TbxdescricaoBusca = new System.Windows.Forms.TextBox();
            this.lbalPesquisa = new System.Windows.Forms.Label();
            this.lupaPictureBox = new MobileTools.Controls.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRamoAtividade)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.selecionarMenuItem);
            this.mainMenu1.MenuItems.Add(this.cancelarMenuItem);
            // 
            // selecionarMenuItem
            // 
            this.selecionarMenuItem.Text = "Selecionar";
            this.selecionarMenuItem.Click += new System.EventHandler(this.selecionarMenuItem_Click);
            // 
            // cancelarMenuItem
            // 
            this.cancelarMenuItem.Text = "Cancelar";
            this.cancelarMenuItem.Click += new System.EventHandler(this.cancelarMenuItem_Click);
            // 
            // bindingSourceRamoAtividade
            // 
            this.bindingSourceRamoAtividade.DataSource = typeof(SPCadMobileData.Data.Model.RamoAtividade);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.DataSource = this.bindingSourceRamoAtividade;
            this.dataGrid1.Location = new System.Drawing.Point(0, 84);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(240, 141);
            this.dataGrid1.TabIndex = 35;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            this.dataGrid1.Click += new System.EventHandler(this.lupaPictureBox_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.MappingName = "RamoAtividade";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Descrição";
            this.dataGridTextBoxColumn1.MappingName = "Descricao";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 210;
            // 
            // title1
            // 
            this.title1.ColorLine = System.Drawing.Color.OliveDrab;
            this.title1.DistanceWordLine = 2;
            this.title1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.title1.HeightLine = 10;
            this.title1.Location = new System.Drawing.Point(0, 3);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(200, 28);
            this.title1.TabIndex = 34;
            this.title1.Text = "Pesquisa Ramo Atividade";
            this.title1.TextAlign = MobileTools.Controls.TypeTextAlign.Right;
            this.title1.TextColor = System.Drawing.SystemColors.WindowText;
            this.title1.WidthInclination = 10;
            // 
            // cbxTipoAtividade
            // 
            this.cbxTipoAtividade.BackColor = System.Drawing.Color.White;
            this.cbxTipoAtividade.DisplayMember = "Description";
            this.cbxTipoAtividade.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbxTipoAtividade.Location = new System.Drawing.Point(121, 58);
            this.cbxTipoAtividade.Name = "cbxTipoAtividade";
            this.cbxTipoAtividade.Size = new System.Drawing.Size(86, 20);
            this.cbxTipoAtividade.TabIndex = 40;
            this.cbxTipoAtividade.ValueMember = "Value";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(121, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.Text = "Tipo Atividade";
            // 
            // descricaoAmostraTextBox
            // 
            this.descricaoAmostraTextBox.BackColor = System.Drawing.Color.White;
            this.descricaoAmostraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceRamoAtividade, "Descricao", true));
            this.descricaoAmostraTextBox.Location = new System.Drawing.Point(0, 231);
            this.descricaoAmostraTextBox.Multiline = true;
            this.descricaoAmostraTextBox.Name = "descricaoAmostraTextBox";
            this.descricaoAmostraTextBox.ReadOnly = true;
            this.descricaoAmostraTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descricaoAmostraTextBox.Size = new System.Drawing.Size(240, 60);
            this.descricaoAmostraTextBox.TabIndex = 36;
            // 
            // TbxdescricaoBusca
            // 
            this.TbxdescricaoBusca.BackColor = System.Drawing.Color.White;
            this.TbxdescricaoBusca.Location = new System.Drawing.Point(3, 57);
            this.TbxdescricaoBusca.MaxLength = 50;
            this.TbxdescricaoBusca.Name = "TbxdescricaoBusca";
            this.TbxdescricaoBusca.Size = new System.Drawing.Size(112, 21);
            this.TbxdescricaoBusca.TabIndex = 36;
            // 
            // lbalPesquisa
            // 
            this.lbalPesquisa.Location = new System.Drawing.Point(3, 40);
            this.lbalPesquisa.Name = "lbalPesquisa";
            this.lbalPesquisa.Size = new System.Drawing.Size(100, 14);
            this.lbalPesquisa.Text = "Pesquisa";
            // 
            // lupaPictureBox
            // 
            this.lupaPictureBox.BorderColor = System.Drawing.Color.Transparent;
            this.lupaPictureBox.ButtonColor = System.Drawing.Color.White;
            this.lupaPictureBox.ButtonColorClick = System.Drawing.SystemColors.GrayText;
            this.lupaPictureBox.ImageButton = ((System.Drawing.Bitmap)(resources.GetObject("lupaPictureBox.ImageButton")));
            this.lupaPictureBox.ImageButtonView = true;
            this.lupaPictureBox.Location = new System.Drawing.Point(210, 57);
            this.lupaPictureBox.Name = "lupaPictureBox";
            this.lupaPictureBox.Radius = 8;
            this.lupaPictureBox.Size = new System.Drawing.Size(19, 21);
            this.lupaPictureBox.TabIndex = 42;
            this.lupaPictureBox.TextAlign = MobileTools.Controls.TypeTextAlign.Center;
            this.lupaPictureBox.TextColor = System.Drawing.SystemColors.WindowText;
            this.lupaPictureBox.TextColorClick = System.Drawing.Color.White;
            this.lupaPictureBox.Click += new System.EventHandler(this.lupaPictureBox_Click);
            // 
            // FrmPesquisaRamoAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.lupaPictureBox);
            this.Controls.Add(this.lbalPesquisa);
            this.Controls.Add(this.cbxTipoAtividade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descricaoAmostraTextBox);
            this.Controls.Add(this.TbxdescricaoBusca);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.title1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.Name = "FrmPesquisaRamoAtividade";
            this.Text = "PesquisarAtividadeForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRamoAtividade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem selecionarMenuItem;
        private System.Windows.Forms.MenuItem cancelarMenuItem;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private MobileTools.Controls.Title title1;
        private System.Windows.Forms.ComboBox cbxTipoAtividade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descricaoAmostraTextBox;
        private System.Windows.Forms.BindingSource bindingSourceRamoAtividade;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.TextBox TbxdescricaoBusca;
        private System.Windows.Forms.Label lbalPesquisa;
        private MobileTools.Controls.UltraButton lupaPictureBox;
    }
}