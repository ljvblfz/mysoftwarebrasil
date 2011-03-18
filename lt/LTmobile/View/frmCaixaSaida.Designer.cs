namespace LTmobile.View
{
    partial class frmCaixaSaida
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
            this.btnOk = new System.Windows.Forms.MenuItem();
            this.mnMenu = new System.Windows.Forms.MenuItem();
            this.mnExcluir = new System.Windows.Forms.MenuItem();
            this.mnVoltar = new System.Windows.Forms.MenuItem();
            this.bsCaixaSaida = new System.Windows.Forms.BindingSource(this.components);
            this.lblDescMesg = new System.Windows.Forms.Label();
            this.txbDescMsg = new System.Windows.Forms.TextBox();
            this.tlCaixaSaida = new MobileTools.Controls.Title();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblAssunto = new System.Windows.Forms.Label();
            this.txbMedidorUc = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsCaixaSaida)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnOk);
            this.mainMenu1.MenuItems.Add(this.mnMenu);
            // 
            // btnOk
            // 
            this.btnOk.Text = "";
            // 
            // mnMenu
            // 
            this.mnMenu.MenuItems.Add(this.mnExcluir);
            this.mnMenu.MenuItems.Add(this.mnVoltar);
            this.mnMenu.Text = "Menu";
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
            // bsCaixaSaida
            // 
            this.bsCaixaSaida.DataSource = typeof(LTmobileData.Data.Model.CorreioEletronico);
            // 
            // lblDescMesg
            // 
            this.lblDescMesg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.lblDescMesg.Location = new System.Drawing.Point(0, 76);
            this.lblDescMesg.Name = "lblDescMesg";
            this.lblDescMesg.Size = new System.Drawing.Size(152, 17);
            this.lblDescMesg.Text = "Descrição da Mensagem";
            // 
            // txbDescMsg
            // 
            this.txbDescMsg.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbDescMsg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixaSaida, "DESC_MSG", true));
            this.txbDescMsg.Location = new System.Drawing.Point(4, 96);
            this.txbDescMsg.Multiline = true;
            this.txbDescMsg.Name = "txbDescMsg";
            this.txbDescMsg.Size = new System.Drawing.Size(220, 56);
            this.txbDescMsg.TabIndex = 17;
            this.txbDescMsg.TabStop = false;
            // 
            // tlCaixaSaida
            // 
            this.tlCaixaSaida.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlCaixaSaida.DistanceWordLine = 2;
            this.tlCaixaSaida.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlCaixaSaida.HeightLine = 10;
            this.tlCaixaSaida.Location = new System.Drawing.Point(0, 0);
            this.tlCaixaSaida.Name = "tlCaixaSaida";
            this.tlCaixaSaida.Size = new System.Drawing.Size(224, 28);
            this.tlCaixaSaida.TabIndex = 14;
            this.tlCaixaSaida.Text = "Caixa de Saída";
            this.tlCaixaSaida.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlCaixaSaida.WidthInclination = 10;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixaSaida, "ASSUNTO", true));
            this.textBox1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(61, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 19);
            this.textBox1.TabIndex = 47;
            this.textBox1.TabStop = false;
            // 
            // lblAssunto
            // 
            this.lblAssunto.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblAssunto.Location = new System.Drawing.Point(4, 58);
            this.lblAssunto.Name = "lblAssunto";
            this.lblAssunto.Size = new System.Drawing.Size(53, 14);
            this.lblAssunto.Text = "Assunto:";
            // 
            // txbMedidorUc
            // 
            this.txbMedidorUc.BackColor = System.Drawing.SystemColors.GrayText;
            this.txbMedidorUc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCaixaSaida, "DT_MSG", true));
            this.txbMedidorUc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbMedidorUc.Location = new System.Drawing.Point(61, 30);
            this.txbMedidorUc.Name = "txbMedidorUc";
            this.txbMedidorUc.Size = new System.Drawing.Size(163, 19);
            this.txbMedidorUc.TabIndex = 46;
            this.txbMedidorUc.TabStop = false;
            // 
            // lblData
            // 
            this.lblData.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblData.Location = new System.Drawing.Point(4, 35);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(51, 14);
            this.lblData.Text = "Data:";
            // 
            // frmCaixaSaida
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
            this.Controls.Add(this.tlCaixaSaida);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmCaixaSaida";
            this.Text = "frmCaixaSaida";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCaixaEntrada_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmCaixaSaida_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCaixaSaida_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsCaixaSaida)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlCaixaSaida;
        private System.Windows.Forms.Label lblDescMesg;
        private System.Windows.Forms.TextBox txbDescMsg;
        private System.Windows.Forms.MenuItem btnOk;
        private System.Windows.Forms.BindingSource bsCaixaSaida;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblAssunto;
        private System.Windows.Forms.TextBox txbMedidorUc;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.MenuItem mnMenu;
        private System.Windows.Forms.MenuItem mnExcluir;
        private System.Windows.Forms.MenuItem mnVoltar;
    }
}