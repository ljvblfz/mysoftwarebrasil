using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MobileTools.Controls
{
    public class SelectedValueEventArgs : EventArgs
    {
        private bool _handled = false;

        /// <summary>
        /// Valor que indica que o evneto foi handled.
        /// </summary>
        public bool Handled 
        {
            get { return _handled; }
            set { _handled = value; }
        }
    }

    public class RadioButtonGroup : Panel
    {
        #region Variáveis Locais

        private object _selectedValue;

        #endregion

        #region Eventos

        /// <summary>
        /// Evento acionado quando o valor selecionado é alterado.
        /// </summary>
        public event EventHandler SelectedValueChanged;

        #endregion

        #region Propriedades

        /// <summary>
        /// Representa o valor selecionado pelos radio buttons
        /// </summary>
        public object SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                // Verifica se o valor foi alterado
                if (_selectedValue != value)
                {
                    SelectedValueEventArgs args = new SelectedValueEventArgs();
                    OnSelectedValueChanged(args);

                    if (args.Handled) return;

                    _selectedValue = value;

                    // Atualiza os RadioButtons
                    UpdateRadioButtons();
                }               
            }
        }

        #endregion

        #region Métodos Protegidos

        /// <summary>
        /// Método acionado quando o valor selecionado é alterado.
        /// </summary>
        private void OnSelectedValueChanged(SelectedValueEventArgs args)
        {            
            if (SelectedValueChanged != null)
                SelectedValueChanged(this, args);
        }

        #endregion

        #region Métodos Privados

        protected override Control.ControlCollection CreateControlsInstance()
        {
            RadioButtonGroupControlCollection collection = new RadioButtonGroupControlCollection(this);
            collection.ControlAdded += new Action<Control>(collection_ControlAdded);

            return collection;
        }

        /// <summary>
        /// Método acionado quando um controle é adicionado no grupo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void collection_ControlAdded(Control e)
        {
            // Verifica se o controle adicionado é um radioButton
            if (e is RadioButton || e is RadioButtonEx)
                ((RadioButton)e).CheckedChanged += new EventHandler(RadioButtonGroup_CheckedChanged);
        }

        /// <summary>
        /// Método acionado quando algum RadioButton do grupo for selecionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonGroup_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null && rb.Checked)
            {
                // Define o valor que foi selecionado
                SelectedValue = rb.Tag;
            }
        }

        /// <summary>
        /// Atualiza a seleção dos radios buttons contidos no grupo.
        /// </summary>
        private void UpdateRadioButtons()
        {
            foreach (Control ctrl in Controls)
            {
                // Verifica se o controle é um RadionButton
                if (ctrl is RadioButton)
                {
                    // Verifica se no RadioButton a tag possui o valor do item selecionado
                    if ((ctrl.Tag == null && SelectedValue == null) ||
                        (ctrl.Tag != null && SelectedValue != null && ctrl.Tag.ToString() == SelectedValue.ToString()))
                    {
                        ((RadioButton)ctrl).Checked = true;
                    }
                    else if (((RadioButton)ctrl).Checked)
                        // Remove a seleção do RadioButton
                        ((RadioButton)ctrl).Checked = false;
                }
            }
        }

        #endregion

        #region Classes Internas

        private class RadioButtonGroupControlCollection : Control.ControlCollection
        {
            #region Eventos

            /// <summary>
            /// Evento acionado quando um controle é acionado na coleção.
            /// </summary>
            public event Action<Control> ControlAdded;

            #endregion

            #region Construtores

            public RadioButtonGroupControlCollection(Control owner)
                : base(owner)
            {

            }

            #endregion

            #region Métodos Sobreescritos

            public override void Add(Control value)
            {
                base.Add(value);

                if (ControlAdded != null)
                    ControlAdded(value);
            }

            #endregion
        }

        #endregion
    }
}
