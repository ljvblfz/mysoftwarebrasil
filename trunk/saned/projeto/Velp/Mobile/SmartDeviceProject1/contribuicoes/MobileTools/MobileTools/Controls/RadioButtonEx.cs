using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MobileTools.Controls
{
    public class RadioButtonEx : RadioButton
    {
        #region Variáveis Locais

        private object _value;

        public object Value
        {
            get { return _value; }
            set 
            {
                object aux = _value;
                _value = value; 

                if (_value != value)
                    this.OnBindingContextChanged(EventArgs.Empty);
            }
        }

        #endregion
    }
}
