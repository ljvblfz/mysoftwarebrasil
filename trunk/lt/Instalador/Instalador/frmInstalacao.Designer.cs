namespace Instalador
{
    partial class frmInstalacao
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
            this.pbrArquivos = new System.Windows.Forms.ProgressBar();
            this.lblPergunta = new System.Windows.Forms.Label();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.lblDiretorio = new System.Windows.Forms.Label();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // pbrArquivos
            // 
            this.pbrArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrArquivos.Location = new System.Drawing.Point(18, 81);
            this.pbrArquivos.Name = "pbrArquivos";
            this.pbrArquivos.Size = new System.Drawing.Size(146, 10);
            // 
            // lblPergunta
            // 
            this.lblPergunta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPergunta.Location = new System.Drawing.Point(18, 3);
            this.lblPergunta.Name = "lblPergunta";
            this.lblPergunta.Size = new System.Drawing.Size(146, 37);
            this.lblPergunta.Text = "Deseja iniciar a cópia dos arquivos?";
            // 
            // lblProgresso
            // 
            this.lblProgresso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgresso.Location = new System.Drawing.Point(18, 94);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(146, 71);
            // 
            // lblDiretorio
            // 
            this.lblDiretorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiretorio.Location = new System.Drawing.Point(18, 40);
            this.lblDiretorio.Name = "lblDiretorio";
            this.lblDiretorio.Size = new System.Drawing.Size(146, 34);
            this.lblDiretorio.Text = "Diretório de destino:";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Iniciar";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Reiniciar";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // frmInstalacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.lblDiretorio);
            this.Controls.Add(this.lblProgresso);
            this.Controls.Add(this.lblPergunta);
            this.Controls.Add(this.pbrArquivos);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmInstalacao";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInstalacao_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbrArquivos;
        private System.Windows.Forms.Label lblPergunta;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.Label lblDiretorio;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;

    }
}