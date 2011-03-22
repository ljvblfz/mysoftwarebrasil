using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SPCadMobileSync.DataADO
{
    static class HelpData
    {
        public static string MaskAmerican(this DateTime? data)
        {
            string item = null;

            if (data != null)
            {
                DateTime novo = (DateTime)data;
                item = novo.ToString("yyyy/MM/dd");
            }
            
            return item;
        }
    }
}
