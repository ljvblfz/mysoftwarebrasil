using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MobileTools.Controls
{
    public class NumericTextBox : TextBox
    {
        #region Variáveis Locais

        private bool _isDecimal = false;
        private bool backSpace = false;
        private System.Globalization.CultureInfo _currentCultureInfo = System.Globalization.CultureInfo.CurrentCulture;
        private string _valueFormat;

        #endregion

        /// <summary>
        /// <see cref="CultureInfo"/> usado para formatar o número.
        /// </summary>
        public string CurrentCultureInfo
        {
            get 
            { 
                return _currentCultureInfo.Name; 
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    _currentCultureInfo = System.Globalization.CultureInfo.CurrentCulture;
                else
                    _currentCultureInfo = System.Globalization.CultureInfo.GetCultureInfo(value); 
            }
        }

        /// <summary>
        /// Formatação para o valor do campo.
        /// </summary>
        public string ValueFormat
        {
            get { return _valueFormat; }
            set { _valueFormat = value; }
        }

        /// <summary>
        /// Identifica se o campo aceita valores decimais.
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool IsDecimal
        {
            get { return _isDecimal; }
            set { _isDecimal = value; }
        }

        /// <summary>
        /// Valor do campo de texto.
        /// </summary>
        public decimal Value
        {
            get 
            {
                if (string.IsNullOrEmpty(Text))
                    return 0.0M;
                else
                    return decimal.Parse(Text, _currentCultureInfo); 
            }
            set 
            {
                if (string.IsNullOrEmpty(_valueFormat))
                    Text = value.ToString(_currentCultureInfo);
                else
                    Text = value.ToString(_valueFormat, _currentCultureInfo);   
            }
        }

        private void OnValidade()
        {
            decimal val = Value;
            Value = val;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            OnValidade();

            base.OnLostFocus(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (backSpace || Utils.IsNumber(e.KeyChar) || 
                (IsDecimal && _currentCultureInfo.NumberFormat.CurrencyDecimalSeparator[0] == e.KeyChar && 
                 (!string.IsNullOrEmpty(Text) && Text.IndexOf(_currentCultureInfo.NumberFormat.CurrencyDecimalSeparator, 0) < 0)))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Verifica se foi digita o backspace
            backSpace = (e.KeyCode == Keys.Back);
            
        }
    }
}
