using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPCadDesktopData.Data.BFL.CustomException
{
    public class SenhaException : Exception
    {

        public SenhaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SenhaException(string message)
            : base(message)
        {
        }
    }
}
