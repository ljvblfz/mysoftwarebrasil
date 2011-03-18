namespace LTmobile.View
{
    partial class frmEditarFoto
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
            this.btnVisualizar = new System.Windows.Forms.MenuItem();
            this.mnMenu = new System.Windows.Forms.MenuItem();
            this.mnApagar = new System.Windows.Forms.MenuItem();
            this.mnVoltar = new System.Windows.Forms.MenuItem();
            this.tlEditarFoto = new MobileTools.Controls.Title();
            this.bsFoto = new System.Windows.Forms.BindingSource(this.components);
            this.grdFoto = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblLegenda = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnVisualizar);
            this.mainMenu1.MenuItems.Add(this.mnMenu);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // mnMenu
            // 
            this.mnMenu.MenuItems.Add(this.mnApagar);
            this.mnMenu.MenuItems.Add(this.mnVoltar);
            this.mnMenu.Text = "Menu";
            // 
            // mnApagar
            // 
            this.mnApagar.Text = "Apagar";
            this.mnApagar.Click += new System.EventHandler(this.mnApagar_Click);
            // 
            // mnVoltar
            // 
            this.mnVoltar.Text = "Voltar";
            this.mnVoltar.Click += new System.EventHandler(this.mnVoltar_Click);
            // 
            // tlEditarFoto
            // 
            this.tlEditarFoto.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlEditarFoto.DistanceWordLine = 2;
            this.tlEditarFoto.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlEditarFoto.HeightLine = 10;
            this.tlEditarFoto.Location = new System.Drawing.Point(0, 0);
            this.tlEditarFoto.Name = "tlEditarFoto";
            this.tlEditarFoto.Size = new System.Drawing.Size(224, 28);
            this.tlEditarFoto.TabIndex = 15;
            this.tlEditarFoto.Text = "Editar Foto";
            this.tlEditarFoto.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlEditarFoto.WidthInclination = 10;
            // 
            // bsFoto
            // 
            this.bsFoto.DataSource = typeof(LTmobileData.Data.Model.Fotos);
            // 
            // grdFoto
            // 
            this.grdFoto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdFoto.DataSource = this.bsFoto;
            this.grdFoto.Location = new System.Drawing.Point(0, 26);
            this.grdFoto.Name = "grdFoto";
            this.grdFoto.Size = new System.Drawing.Size(224, 98);
            this.grdFoto.TabIndex = 16;
            this.grdFoto.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.MappingName = "Fotos";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Seq.";
            this.dataGridTextBoxColumn1.MappingName = "NUM_SEQ_FOTO";
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Legenda";
            this.dataGridTextBoxColumn2.MappingName = "DESC_FOTO";
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // lblLegenda
            // 
            this.lblLegenda.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblLegenda.Location = new System.Drawing.Point(4, 131);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(67, 22);
            this.lblLegenda.Text = "Legenda:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFoto, "DESC_FOTO", true));
            this.textBox1.Location = new System.Drawing.Point(78, 131);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 22);
            this.textBox1.TabIndex = 18;
            this.textBox1.TabStop = false;
            // 
            // frmEditarFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblLegenda);
            this.Controls.Add(this.grdFoto);
            this.Controls.Add(this.tlEditarFoto);
            this.Menu = this.mainMenu1;
            this.Name = "frmEditarFoto";
            this.Text = "frmEditarFoto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEditarFoto_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEditarFoto_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.bsFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlEditarFoto;
        private System.Windows.Forms.DataGrid grdFoto;
        private System.Windows.Forms.Label lblLegenda;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource bsFoto;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.MenuItem btnVisualizar;
        private System.Windows.Forms.MenuItem mnMenu;
        private System.Windows.Forms.MenuItem mnApagar;
        private System.Windows.Forms.MenuItem mnVoltar;
    }
}