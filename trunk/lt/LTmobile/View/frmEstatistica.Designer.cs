namespace LTmobile.View
{
    partial class frmEstatistica
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
            this.btnVoltar = new System.Windows.Forms.MenuItem();
            this.tlRotaLeitura = new MobileTools.Controls.Title();
            this.lblUc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbImpedimento = new System.Windows.Forms.TextBox();
            this.txbRepasse = new System.Windows.Forms.TextBox();
            this.txbVisitados = new System.Windows.Forms.TextBox();
            this.lblImpedimento = new System.Windows.Forms.Label();
            this.lblVisitados = new System.Windows.Forms.Label();
            this.lblRepasse = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblTempoDec = new System.Windows.Forms.Label();
            this.txbTempoDec = new System.Windows.Forms.TextBox();
            this.txbHora = new System.Windows.Forms.TextBox();
            this.tmHoraAtual = new System.Windows.Forms.Timer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.btnVoltar);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Text = "Sair";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // tlRotaLeitura
            // 
            this.tlRotaLeitura.ColorLine = System.Drawing.Color.OliveDrab;
            this.tlRotaLeitura.DistanceWordLine = 2;
            this.tlRotaLeitura.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tlRotaLeitura.HeightLine = 10;
            this.tlRotaLeitura.Location = new System.Drawing.Point(0, 0);
            this.tlRotaLeitura.Name = "tlRotaLeitura";
            this.tlRotaLeitura.Size = new System.Drawing.Size(224, 28);
            this.tlRotaLeitura.TabIndex = 14;
            this.tlRotaLeitura.Text = "Estatística";
            this.tlRotaLeitura.TextColor = System.Drawing.SystemColors.WindowText;
            this.tlRotaLeitura.WidthInclination = 10;
            // 
            // lblUc
            // 
            this.lblUc.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblUc.Location = new System.Drawing.Point(4, 30);
            this.lblUc.Name = "lblUc";
            this.lblUc.Size = new System.Drawing.Size(152, 22);
            this.lblUc.Text = "UC´s";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbImpedimento);
            this.panel1.Controls.Add(this.txbRepasse);
            this.panel1.Controls.Add(this.txbVisitados);
            this.panel1.Controls.Add(this.lblImpedimento);
            this.panel1.Controls.Add(this.lblVisitados);
            this.panel1.Location = new System.Drawing.Point(4, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 71);
            // 
            // txbImpedimento
            // 
            this.txbImpedimento.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbImpedimento.Location = new System.Drawing.Point(126, 47);
            this.txbImpedimento.Name = "txbImpedimento";
            this.txbImpedimento.Size = new System.Drawing.Size(94, 19);
            this.txbImpedimento.TabIndex = 6;
            this.txbImpedimento.TabStop = false;
            // 
            // txbRepasse
            // 
            this.txbRepasse.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbRepasse.Location = new System.Drawing.Point(126, 26);
            this.txbRepasse.Name = "txbRepasse";
            this.txbRepasse.Size = new System.Drawing.Size(94, 19);
            this.txbRepasse.TabIndex = 5;
            this.txbRepasse.TabStop = false;
            // 
            // txbVisitados
            // 
            this.txbVisitados.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbVisitados.Location = new System.Drawing.Point(126, 4);
            this.txbVisitados.Name = "txbVisitados";
            this.txbVisitados.Size = new System.Drawing.Size(94, 19);
            this.txbVisitados.TabIndex = 4;
            this.txbVisitados.TabStop = false;
            // 
            // lblImpedimento
            // 
            this.lblImpedimento.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblImpedimento.Location = new System.Drawing.Point(4, 51);
            this.lblImpedimento.Name = "lblImpedimento";
            this.lblImpedimento.Size = new System.Drawing.Size(103, 15);
            this.lblImpedimento.Text = "Impedimento:";
            // 
            // lblVisitados
            // 
            this.lblVisitados.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblVisitados.Location = new System.Drawing.Point(4, 4);
            this.lblVisitados.Name = "lblVisitados";
            this.lblVisitados.Size = new System.Drawing.Size(115, 15);
            this.lblVisitados.Text = "Visitados (1º Exec.):";
            // 
            // lblRepasse
            // 
            this.lblRepasse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblRepasse.Location = new System.Drawing.Point(8, 75);
            this.lblRepasse.Name = "lblRepasse";
            this.lblRepasse.Size = new System.Drawing.Size(103, 15);
            this.lblRepasse.Text = "Repasse:";
            // 
            // lblHora
            // 
            this.lblHora.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblHora.Location = new System.Drawing.Point(6, 124);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(103, 15);
            this.lblHora.Text = "Hora Atual:";
            // 
            // lblTempoDec
            // 
            this.lblTempoDec.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblTempoDec.Location = new System.Drawing.Point(6, 140);
            this.lblTempoDec.Name = "lblTempoDec";
            this.lblTempoDec.Size = new System.Drawing.Size(111, 15);
            this.lblTempoDec.Text = "Tempo Decorrido:";
            // 
            // txbTempoDec
            // 
            this.txbTempoDec.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbTempoDec.Location = new System.Drawing.Point(130, 141);
            this.txbTempoDec.Name = "txbTempoDec";
            this.txbTempoDec.Size = new System.Drawing.Size(94, 19);
            this.txbTempoDec.TabIndex = 8;
            this.txbTempoDec.TabStop = false;
            // 
            // txbHora
            // 
            this.txbHora.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.txbHora.Location = new System.Drawing.Point(130, 120);
            this.txbHora.Name = "txbHora";
            this.txbHora.Size = new System.Drawing.Size(94, 19);
            this.txbHora.TabIndex = 7;
            this.txbHora.TabStop = false;
            // 
            // tmHoraAtual
            // 
            this.tmHoraAtual.Enabled = true;
            this.tmHoraAtual.Interval = 1000;
            this.tmHoraAtual.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmEstatistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 173);
            this.Controls.Add(this.txbTempoDec);
            this.Controls.Add(this.txbHora);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblTempoDec);
            this.Controls.Add(this.lblRepasse);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblUc);
            this.Controls.Add(this.tlRotaLeitura);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmEstatistica";
            this.Text = "frmEstatistica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEstatistica_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEstatistica_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileTools.Controls.Title tlRotaLeitura;
        private System.Windows.Forms.Label lblUc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblImpedimento;
        private System.Windows.Forms.Label lblVisitados;
        private System.Windows.Forms.Label lblRepasse;
        private System.Windows.Forms.MenuItem btnVoltar;
        private System.Windows.Forms.TextBox txbVisitados;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblTempoDec;
        private System.Windows.Forms.TextBox txbImpedimento;
        private System.Windows.Forms.TextBox txbRepasse;
        private System.Windows.Forms.TextBox txbTempoDec;
        private System.Windows.Forms.TextBox txbHora;
        private System.Windows.Forms.Timer tmHoraAtual;
    }
}