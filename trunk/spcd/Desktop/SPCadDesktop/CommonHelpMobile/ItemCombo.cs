using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CommonHelpMobile
{
    public class ItemCombo
    {
        public object Value { get; set; }
        public object Description { get; set; }

        public ItemCombo(object value, object description)
        {
            this.Value = value;
            this.Description = description;
        }
    }
}
