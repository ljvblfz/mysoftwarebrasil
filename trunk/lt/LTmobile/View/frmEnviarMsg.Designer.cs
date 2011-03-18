namespace LTmobile.View
{
    partial class frmEnviarMsg
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnEnviar = new System.Windows.Forms.MenuItem();
            this.btnCancelar = new System.Windows.Forms.MenuItem();
            this.tlEnviarMsg = new MobileTools.Controls.Title();
            this.lblAssunto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbAssunto = new System.Windows.Forms.TextBox();
            this.txbMensagem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnEnviar);
            this.mainMenu1.MenuItems.Add(this.btnCancelar);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Text = "Sair";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tlEnviarMsg
            // 
            this.tlEnviarMsg.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlEnviarMsg.DistanceWordLine = 2;
            this.tlEnviarMsg.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlEnviarMsg.HeightLine = 10;
            this.tlEnviarMsg.Location = new System.Drawing.Point(0, 0);
            this.tlEnviarMsg.Name = "tlEnviarMsg";
            this.tlEnviarMsg.Size = new System.Drawing.Size(224, 28);
            this.tlEnviarMsg.TabIndex = 16;
            this.tlEnviarMsg.Text = "Enviar Mensagem";
            this.tlEnviarMsg.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlEnviarMsg.WidthInclination = 10;
            // 
            // lblAssunto
            // 
            this.lblAssunto.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblAssunto.Location = new System.Drawing.Point(14, 35);
            this.lblAssunto.Name = "lblAssunto";
            this.lblAssunto.Size = new System.Drawing.Size(152, 22);
            this.lblAssunto.Text = "Assunto:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(14, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 22);
            this.label2.Text = "Mensagem:";
            // 
            // txbAssunto
            // 
            this.txbAssunto.BackColor = System.Drawing.SystemColors.Info;
            this.txbAssunto.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.txbAssunto.Location = new System.Drawing.Point(14, 60);
            this.txbAssunto.MaxLength = 40;
            this.txbAssunto.Name = "txbAssunto";
            this.txbAssunto.Size = new System.Drawing.Size(207, 22);
            this.txbAssunto.TabIndex = 20;
            // 
            // txbMensagem
            // 
            this.txbMensagem.BackColor = System.Drawing.SystemColors.Info;
            this.txbMensagem.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.txbMensagem.Location = new System.Drawing.Point(14, 110);
            this.txbMensagem.MaxLength = 100;
            this.txbMensagem.Multiline = true;
            this.txbMensagem.Name = "txbMensagem";
            this.txbMensagem.Size = new System.Drawing.Size(210, 42);
            this.txbMensagem.TabIndex = 21;
            // 
            // frmEnviarMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbMensagem);
            this.Controls.Add(this.txbAssunto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAssunto);
            this.Controls.Add(this.tlEnviarMsg);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmEnviarMsg";
            this.Text = "frmEnviarMsg";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEnviarMsg_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEnviarMsg_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlEnviarMsg;
        private System.Windows.Forms.Label lblAssunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbAssunto;
        private System.Windows.Forms.TextBox txbMensagem;
        private System.Windows.Forms.MenuItem btnEnviar;
        private System.Windows.Forms.MenuItem btnCancelar;
    }
}