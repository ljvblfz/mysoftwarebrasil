namespace OnPlaceMovel.Source.Forms
{
    partial class FormProgresso
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
			this.lblMsg = new System.Windows.Forms.Label();
			this.pbProgresso = new System.Windows.Forms.ProgressBar();
			this.lblPercent = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblMsg
			// 
			this.lblMsg.Location = new System.Drawing.Point( 14, 91 );
			this.lblMsg.Name = "lblMsg";
			this.lblMsg.Size = new System.Drawing.Size( 215, 52 );
			this.lblMsg.Text = "msg";
			// 
			// pbProgresso
			// 
			this.pbProgresso.Location = new System.Drawing.Point( 14, 68 );
			this.pbProgresso.Name = "pbProgresso";
			this.pbProgresso.Size = new System.Drawing.Size( 215, 20 );
			// 
			// lblPercent
			// 
			this.lblPercent.Location = new System.Drawing.Point( 31, 45 );
			this.lblPercent.Name = "lblPercent";
			this.lblPercent.Size = new System.Drawing.Size( 178, 20 );
			this.lblPercent.Text = "%";
			this.lblPercent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Progresso
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 96F, 96F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size( 240, 268 );
			this.ControlBox = false;
			this.Controls.Add( this.pbProgresso );
			this.Controls.Add( this.lblMsg );
			this.Controls.Add( this.lblPercent );
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "Progresso";
			this.Text = "Progresso";
			this.Activated += new System.EventHandler( this.Progresso_Activated );
			this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ProgressBar pbProgresso;
        private System.Windows.Forms.Label lblPercent;
    }
}