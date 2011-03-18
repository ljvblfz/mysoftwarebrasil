namespace LTmobile.View
{
    partial class frmCaixaEntrada
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
            this.mnLer = new System.Windows.Forms.MenuItem();
            this.mnMenu = new System.Windows.Forms.MenuItem();
            this.mnAtualizar = new System.Windows.Forms.MenuItem();
            this.mnExcluir = new System.Windows.Forms.MenuItem();
            this.mnVoltar = new System.Windows.Forms.MenuItem();
            this.tlCaixaEntrada = new MobileTools.Controls.Title();
            this.txbDescMsg = new System.Windows.Forms.TextBox();
            this.bsCaixaEntrada = new System.Windows.Forms.BindingSource(this.components);
            this.lblDescMesg = new System.Windows.Forms.Label();
            this.txbMedidorUc = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblAssunto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsCaixaEntrada)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnLer);
            this.mainMenu1.MenuItems.Add(this.mnMenu);
            // 
            // mnLer
            // 
            this.mnLer.Text = "";
            // 
            // mnMenu
            // 
            this.mnMenu.MenuItems.Add(this.mnAtualizar);
            this.mnMenu.MenuItems.Add(this.mnExcluir);
            this.mnMenu.MenuItems.Add(this.mnVoltar);
            this.mnMenu.Text = "Menu";
            // 
            // mnAtualizar
            // 
            this.mnAtualizar.Text = "Atualizar";
            this.mnAtualizar.Click += new System.EventHandler(this.mnAtualizar_Click);
            // 
            // mnExcluir
            // 
            this.mnExcluir.Text = "Excluir";
            this.mnExcluir.Click += new System.EventHandler(this.mnExcluir_Click);
            // 
            // mnVoltar
            // 
            this.mnVoltar.Text = "Voltar";
            this.mnVoltar.Click += new System.EventHandler(this.mnVoltar_Click);
            // 
            // tlCaixaEntrada
            // 
            this.tlCaixaEntrada.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlCaixaEntrada.DistanceWordLine = 2;
            this.tlCaixaEntrada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlCaixaEntrada.HeightLine = 10;
            this.tlCaixaEntrada.Location = new System.Drawing.Point(0, 0);
            this.tlCaixaEntrada.Name = "tlCaixaEntrada";
            this.tlCaixaEntrada.Size = new System.Drawing.Size(224, 28);
            this.tlCaixaEntrada.TabIndex = 15;
            this.tlCaixaEntrada.Text = "Caixa de Entrada";
            this.tlCaixaEntrada.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlCaixaEntrada.WidthInclination = 10;
            // 
            // txbDescMsg
            // 
            this.txbDescMsg.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbDescMsg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixaEntrada, "DESC_MSG", true));
            this.txbDescMsg.Location = new System.Drawing.Point(4, 93);
            this.txbDescMsg.Multiline = true;
            this.txbDescMsg.Name = "txbDescMsg";
            this.txbDescMsg.Size = new System.Drawing.Size(220, 61);
            this.txbDescMsg.TabIndex = 20;
            this.txbDescMsg.TabStop = false;
            // 
            // bsCaixaEntrada
            // 
            this.bsCaixaEntrada.DataSource = typeof(LTmobileData.Data.Model.CorreioEletronico);
            // 
            // lblDescMesg
            // 
            this.lblDescMesg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.lblDescMesg.Location = new System.Drawing.Point(0, 76);
            this.lblDescMesg.Name = "lblDescMesg";
            this.lblDescMesg.Size = new System.Drawing.Size(152, 14);
            this.lblDescMesg.Text = "Descrição da Mensagem";
            // 
            // txbMedidorUc
            // 
            this.txbMedidorUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbMedidorUc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixaEntrada, "DT_MSG", true));
            this.txbMedidorUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMedidorUc.Location = new System.Drawing.Point(61, 31);
            this.txbMedidorUc.Name = "txbMedidorUc";
            this.txbMedidorUc.Size = new System.Drawing.Size(163, 19);
            this.txbMedidorUc.TabIndex = 40;
            this.txbMedidorUc.TabStop = false;
            // 
            // lblData
            // 
            this.lblData.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblData.Location = new System.Drawing.Point(5, 36);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(51, 14);
            this.lblData.Text = "Data:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixaEntrada, "ASSUNTO", true));
            this.textBox1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(61, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 19);
            this.textBox1.TabIndex = 43;
            this.textBox1.TabStop = false;
            // 
            // lblAssunto
            // 
            this.lblAssunto.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblAssunto.Location = new System.Drawing.Point(5, 59);
            this.lblAssunto.Name = "lblAssunto";
            this.lblAssunto.Size = new System.Drawing.Size(53, 14);
            this.lblAssunto.Text = "Assunto:";
            // 
            // frmCaixaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblAssunto);
            this.Controls.Add(this.txbMedidorUc);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.txbDescMsg);
            this.Controls.Add(this.lblDescMesg);
            this.Controls.Add(this.tlCaixaEntrada);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmCaixaEntrada";
            this.Text = "frmCaixaEntrada";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmCaixaEntrada_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCaixaEntrada_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsCaixaEntrada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlCaixaEntrada;
        private System.Windows.Forms.TextBox txbDescMsg;
        private System.Windows.Forms.Label lblDescMesg;
        private System.Windows.Forms.BindingSource bsCaixaEntrada;
        private System.Windows.Forms.MenuItem mnLer;
        private System.Windows.Forms.MenuItem mnMenu;
        private System.Windows.Forms.MenuItem mnAtualizar;
        private System.Windows.Forms.MenuItem mnVoltar;
        private System.Windows.Forms.TextBox txbMedidorUc;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblAssunto;
        private System.Windows.Forms.MenuItem mnExcluir;
    }
}