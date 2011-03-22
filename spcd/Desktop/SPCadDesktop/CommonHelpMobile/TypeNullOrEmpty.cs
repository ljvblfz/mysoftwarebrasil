using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;

namespace CommonHelpMobile
{
    public static class TypeNullOrEmpty
    {
        public static bool isEmpt(this int a)
        {
            bool result = (a == 0)? true : false;
            return result;
        }

        public static bool isEmpt(this long a)
        {
            bool result = (a == 0) ? true : false;
            return result;
        }

        public static bool isNullorZero(this int? a)
        {
            bool result = (a == null || a == 0) ? true : false;
            return result;
        }

        public static bool isNullorZero(this long? a)
        {
            bool result = (a == null || a == 0) ? true : false;
            return result;
        }
    }
}
