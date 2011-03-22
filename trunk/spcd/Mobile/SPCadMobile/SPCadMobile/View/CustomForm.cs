using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPCadMobile.View
{
    [System.Runtime.CompilerServices.CompilerGenerated()]
    public partial class CustomForm : Form
    {
        public CustomForm()
        {
            InitializeComponent();
            panel.Height = 259;
        }

        public string Title
        {
            get
            {
                return title.Text;
            }
            set
            {
                title.Text = value;
            }
        }

        protected virtual void TecladoinputPanel_EnabledChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (TecladoinputPanel.Enabled)
                {
                    panel.AutoScroll = true;
                    panel.Height = TecladoinputPanel.VisibleDesktop.Height - 10;
                }
                else
                {
                    panel.AutoScroll = false;
                    panel.Height = 259;

                }
            }
            catch (Exception)
            {
                TecladoinputPanel.Dispose();
            }
        }

        private void chkConfirmado_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkConfirmado.Checked)
                chkConfirmado.BackColor = Color.GreenYellow;
            else
                chkConfirmado.BackColor = Color.FromArgb(255, 128, 128);
        }

    }
}