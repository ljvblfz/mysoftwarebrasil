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
    public partial class CustomFormAba : Form
    {
        public CustomFormAba()
        {
            InitializeComponent();
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

        private void TecladoinputPanel_EnabledChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (TecladoinputPanel.Enabled)
                {
                    for (int i = 0; i < tabControl1.TabPages.Count; i++)
                    {
                        tabControl1.TabPages[i].AutoScroll = true;
                        tabControl1.TabPages[i].AutoScrollMargin = new Size(0, TecladoinputPanel.VisibleDesktop.Height - 130);
                    }
                }
                else
                {
                    for (int i = 0; i < tabControl1.TabPages.Count; i++)
                    {
                        tabControl1.TabPages[i].AutoScroll = false;
                        tabControl1.TabPages[i].AutoScrollMargin = new Size(0, 236);
                    }
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