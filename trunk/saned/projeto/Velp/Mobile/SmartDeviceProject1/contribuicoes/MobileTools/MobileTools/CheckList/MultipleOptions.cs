using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MobileTools.CheckList
{
    /// <summary>
    /// Delegate acionado quando um opção é selecionada.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="item">Item selecionado.</param>
    public delegate void EventOption(object sender, ItemQuestion item);

    internal class MultipleOptions : Panel
    {
        #region Variáveis Locais

        private Question mainQuestion;

        public const int DefaultHeightCheckBox = 22;

        #endregion

        #region Eventos

        /// <summary>
        /// Evento acionado quando o item é selecionado
        /// </summary>
        public event EventOption ItemCheckStateChanged;

        #endregion

        #region Construtores

        public MultipleOptions(Question question)
        {
            mainQuestion = question;

            AutoScroll = true;
            BuildOptions();
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Constroi os controles.
        /// </summary>
        private void BuildOptions()
        {
            int i = 0, pos = 0;

            if (mainQuestion.SelectedItems.Count == 0) i = -1;

            foreach (ItemQuestion item in mainQuestion.ItemsMultipleOptions)
            {
                CheckBox chk = new CheckBox();
                chk.Font = new Font("Tahoma", 8, FontStyle.Regular);
                chk.Text = item.Description;
                chk.Tag = item;
                chk.Height = (int)(MultipleOptions.DefaultHeightCheckBox * (Screen.PrimaryScreen.Bounds.Height / 320.0f));
                chk.Width = (int)(Width * (Screen.PrimaryScreen.Bounds.Width / 240.0f)) - 16;

                // Posiciona o controle
                chk.Location = new System.Drawing.Point(2, pos);

                // Seleciona os itens
                if (i >= 0 && mainQuestion.SelectedItems[i].Equals(item))
                {
                    chk.Checked = true;

                    if (i == mainQuestion.SelectedItems.Count - 1)
                        i = -1;
                    else
                        i++;

                }

                Controls.Add(chk);

                pos += 1 + chk.Height;

            }

            if (i >= 0)
            {
                // Seleciona os itens que sobraram
                for (; i < mainQuestion.SelectedItems.Count; i++)
                {
                    foreach (Control ctrl in Controls)
                    {
                        if (((ItemQuestion)ctrl.Tag).Value == mainQuestion.SelectedItems[i])
                        {
                            ((CheckBox)ctrl).Checked = true;
                            continue;
                        }
                    }

                }
            }

            foreach (Control ctrl in Controls)
                ((CheckBox)ctrl).CheckStateChanged += new EventHandler(chk_CheckStateChanged);

        }

        private void chk_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            ItemQuestion item = (ItemQuestion)chk.Tag;

            if (chk.CheckState == CheckState.Checked)
            {
                if (ItemCheckStateChanged != null)
                    ItemCheckStateChanged(this, item);

                mainQuestion.SelectedItems.Add(item);
            }
            else
                mainQuestion.SelectedItems.Remove(item);
        }

        #endregion

        #region Métodos Protegidos

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.Controls == null) return;

            try
            {
                // Redimenciona todos os controles
                foreach (Control ctrl in Controls)
                    ctrl.Width = Width - 16;
            }
            catch
            {

            }

        }

        #endregion

    }
}
