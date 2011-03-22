namespace SPCadMobile.View
{
    partial class FrmListFoto
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
            this.editarMenuItem = new System.Windows.Forms.MenuItem();
            this.voltarMenuItem = new System.Windows.Forms.MenuItem();
            this.title1 = new MobileTools.Controls.Title();
            this.bindingSourceFotos = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.picBoxFoto = new System.Windows.Forms.PictureBox();
            this.tbxDescricaoFoto = new System.Windows.Forms.TextBox();
            this.btnNovaFoto = new System.Windows.Forms.Button();
            this.btnExcluirFoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFotos)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.editarMenuItem);
            this.mainMenu1.MenuItems.Add(this.voltarMenuItem);
            // 
            // editarMenuItem
            // 
            this.editarMenuItem.Text = "Editar";
            this.editarMenuItem.Click += new System.EventHandler(this.editarMenuItem_Click);
            // 
            // voltarMenuItem
            // 
            this.voltarMenuItem.Text = "Voltar";
            this.voltarMenuItem.Click += new System.EventHandler(this.voltarMenuItem_Click);
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
            this.title1.TabIndex = 8;
            this.title1.Text = "Fotos";
            this.title1.TextAlign = MobileTools.Controls.TypeTextAlign.Right;
            this.title1.TextColor = System.Drawing.SystemColors.WindowText;
            this.title1.WidthInclination = 10;
            // 
            // bindingSourceFotos
            // 
            this.bindingSourceFotos.DataSource = typeof(SPCadMobileData.Data.Model.Foto);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.DataSource = this.bindingSourceFotos;
            this.dataGrid1.HeaderBackColor = System.Drawing.Color.Wheat;
            this.dataGrid1.Location = new System.Drawing.Point(3, 37);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(234, 114);
            this.dataGrid1.TabIndex = 10;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.MappingName = "Foto";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Nº";
            this.dataGridTextBoxColumn1.MappingName = "sequencia";
            this.dataGridTextBoxColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "dd/MM/yy hh:mm";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Data";
            this.dataGridTextBoxColumn2.MappingName = "Data";
            this.dataGridTextBoxColumn2.NullText = "em manutenção";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // picBoxFoto
            // 
            this.picBoxFoto.BackColor = System.Drawing.Color.White;
            this.picBoxFoto.Location = new System.Drawing.Point(3, 207);
            this.picBoxFoto.Name = "picBoxFoto";
            this.picBoxFoto.Size = new System.Drawing.Size(119, 84);
            this.picBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tbxDescricaoFoto
            // 
            this.tbxDescricaoFoto.BackColor = System.Drawing.SystemColors.Info;
            this.tbxDescricaoFoto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceFotos, "descFoto", true));
            this.tbxDescricaoFoto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbxDescricaoFoto.Location = new System.Drawing.Point(3, 156);
            this.tbxDescricaoFoto.Multiline = true;
            this.tbxDescricaoFoto.Name = "tbxDescricaoFoto";
            this.tbxDescricaoFoto.ReadOnly = true;
            this.tbxDescricaoFoto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDescricaoFoto.Size = new System.Drawing.Size(234, 45);
            this.tbxDescricaoFoto.TabIndex = 12;
            // 
            // btnNovaFoto
            // 
            this.btnNovaFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNovaFoto.BackColor = System.Drawing.Color.White;
            this.btnNovaFoto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnNovaFoto.Location = new System.Drawing.Point(123, 207);
            this.btnNovaFoto.Name = "btnNovaFoto";
            this.btnNovaFoto.Size = new System.Drawing.Size(114, 20);
            this.btnNovaFoto.TabIndex = 13;
            this.btnNovaFoto.Text = "Nova";
            this.btnNovaFoto.Click += new System.EventHandler(this.btnNovaFoto_Click);
            // 
            // btnExcluirFoto
            // 
            this.btnExcluirFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcluirFoto.BackColor = System.Drawing.Color.White;
            this.btnExcluirFoto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnExcluirFoto.Location = new System.Drawing.Point(123, 233);
            this.btnExcluirFoto.Name = "btnExcluirFoto";
            this.btnExcluirFoto.Size = new System.Drawing.Size(114, 20);
            this.btnExcluirFoto.TabIndex = 13;
            this.btnExcluirFoto.Text = "Excluir";
            this.btnExcluirFoto.Click += new System.EventHandler(this.btnExcluirFoto_Click);
            // 
            // FrmListFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.btnExcluirFoto);
            this.Controls.Add(this.btnNovaFoto);
            this.Controls.Add(this.tbxDescricaoFoto);
            this.Controls.Add(this.picBoxFoto);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.title1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.Name = "FrmListFoto";
            this.Text = "Fotos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFotos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem editarMenuItem;
        private System.Windows.Forms.MenuItem voltarMenuItem;
        private MobileTools.Controls.Title title1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.PictureBox picBoxFoto;
        private System.Windows.Forms.TextBox tbxDescricaoFoto;
        private System.Windows.Forms.Button btnNovaFoto;
        private System.Windows.Forms.Button btnExcluirFoto;
        private System.Windows.Forms.BindingSource bindingSourceFotos;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
    }
}