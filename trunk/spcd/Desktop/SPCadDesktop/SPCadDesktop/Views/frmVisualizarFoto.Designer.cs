namespace SPCadDesktop.Views
{
    partial class frmVisualizarFoto
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
            this.pictureFotoGrande = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFotoGrande)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureFotoGrande
            // 
            this.pictureFotoGrande.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.pictureFotoGrande.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pictureFotoGrande.Location = new System.Drawing.Point(0, 2);
            this.pictureFotoGrande.Name = "pictureFotoGrande";
            this.pictureFotoGrande.Size = new System.Drawing.Size(659, 426);
            this.pictureFotoGrande.TabIndex = 0;
            this.pictureFotoGrande.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(680, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Zom +";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(680, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Zom -";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmVisualizarFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(765, 464);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureFotoGrande);
            this.Name = "frmVisualizarFoto";
            this.Text = "frmVisualizarFoto";
            ((System.ComponentModel.ISupportInitialize)(this.pictureFotoGrande)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureFotoGrande;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}