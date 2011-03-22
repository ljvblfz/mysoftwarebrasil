namespace SPCadDesktop
{
    partial class frmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.matriculaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaCadastralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distribuiçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosExecutadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fonteAlternativaNãoCadastradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alteraçãoCadastralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.irregularidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ldDataBase = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matriculaToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.administraçãoToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(610, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // matriculaToolStripMenuItem
            // 
            this.matriculaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesquisaCadastralToolStripMenuItem,
            this.distribuiçãoToolStripMenuItem});
            this.matriculaToolStripMenuItem.Name = "matriculaToolStripMenuItem";
            this.matriculaToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.matriculaToolStripMenuItem.Text = "Matricula";
            // 
            // pesquisaCadastralToolStripMenuItem
            // 
            this.pesquisaCadastralToolStripMenuItem.Name = "pesquisaCadastralToolStripMenuItem";
            this.pesquisaCadastralToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.pesquisaCadastralToolStripMenuItem.Text = "Pesquisa Cadastral";
            this.pesquisaCadastralToolStripMenuItem.Click += new System.EventHandler(this.pesquisaCadastralToolStripMenuItem_Click);
            // 
            // distribuiçãoToolStripMenuItem
            // 
            this.distribuiçãoToolStripMenuItem.Name = "distribuiçãoToolStripMenuItem";
            this.distribuiçãoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.distribuiçãoToolStripMenuItem.Text = "Distribuição";
            this.distribuiçãoToolStripMenuItem.Click += new System.EventHandler(this.distribuiçãoToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosExecutadosToolStripMenuItem,
            this.fonteAlternativaNãoCadastradaToolStripMenuItem,
            this.alteraçãoCadastralToolStripMenuItem,
            this.irregularidadesToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // cadastrosExecutadosToolStripMenuItem
            // 
            this.cadastrosExecutadosToolStripMenuItem.Name = "cadastrosExecutadosToolStripMenuItem";
            this.cadastrosExecutadosToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.cadastrosExecutadosToolStripMenuItem.Text = "Cadastros Executados";
            this.cadastrosExecutadosToolStripMenuItem.Click += new System.EventHandler(this.cadastrosExecutadosToolStripMenuItem_Click);
            // 
            // fonteAlternativaNãoCadastradaToolStripMenuItem
            // 
            this.fonteAlternativaNãoCadastradaToolStripMenuItem.Name = "fonteAlternativaNãoCadastradaToolStripMenuItem";
            this.fonteAlternativaNãoCadastradaToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.fonteAlternativaNãoCadastradaToolStripMenuItem.Text = "Fonte Alternativa Não Cadastrada";
            this.fonteAlternativaNãoCadastradaToolStripMenuItem.Click += new System.EventHandler(this.fonteAlternativaNaoCadastradaToolStripMenuItem_Click);
            // 
            // alteraçãoCadastralToolStripMenuItem
            // 
            this.alteraçãoCadastralToolStripMenuItem.Name = "alteraçãoCadastralToolStripMenuItem";
            this.alteraçãoCadastralToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.alteraçãoCadastralToolStripMenuItem.Text = "Alteração Cadastral";
            this.alteraçãoCadastralToolStripMenuItem.Click += new System.EventHandler(this.alteracaoCadastralToolStripMenuItem_Click);
            // 
            // irregularidadesToolStripMenuItem
            // 
            this.irregularidadesToolStripMenuItem.Name = "irregularidadesToolStripMenuItem";
            this.irregularidadesToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.irregularidadesToolStripMenuItem.Text = "Irregularidades";
            this.irregularidadesToolStripMenuItem.Click += new System.EventHandler(this.irregularidadesToolStripMenuItem_Click);
            // 
            // administraçãoToolStripMenuItem
            // 
            this.administraçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importaçãoToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.administraçãoToolStripMenuItem.Name = "administraçãoToolStripMenuItem";
            this.administraçãoToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.administraçãoToolStripMenuItem.Text = "Administração";
            // 
            // importaçãoToolStripMenuItem
            // 
            this.importaçãoToolStripMenuItem.Name = "importaçãoToolStripMenuItem";
            this.importaçãoToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.importaçãoToolStripMenuItem.Text = "Importação";
            this.importaçãoToolStripMenuItem.Click += new System.EventHandler(this.importaçãoToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(586, 335);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::SPCadDesktop.Properties.Resources.copasa;
            this.pictureBox2.Location = new System.Drawing.Point(438, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 94);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // ldDataBase
            // 
            this.ldDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ldDataBase.AutoSize = true;
            this.ldDataBase.BackColor = System.Drawing.SystemColors.Control;
            this.ldDataBase.Location = new System.Drawing.Point(290, 368);
            this.ldDataBase.Name = "ldDataBase";
            this.ldDataBase.Size = new System.Drawing.Size(85, 13);
            this.ldDataBase.TabIndex = 3;
            this.ldDataBase.Text = "Conectado em : ";
            this.ldDataBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 386);
            this.Controls.Add(this.ldDataBase);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.ShowInTaskbar = false;
            this.Text = "SPCad - Sistema de Pesquisas Cadastrais Comerciais Dirigidas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem matriculaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem pesquisaCadastralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distribuiçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fonteAlternativaNãoCadastradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosExecutadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alteraçãoCadastralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem irregularidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.Label ldDataBase;
    }
}