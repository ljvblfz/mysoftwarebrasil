using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dum_Mobile
{

    [AttributeUsage(AttributeTargets.All)]
    public sealed class Primary : Attribute
    {
        private string primary;

        public Primary(string primary)
        {
            this.primary = primary;
        }

        public string PrimaryString
        {
            get { return primary; }
        }
    }
}
