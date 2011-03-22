using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPCadDesktopData.Data.BFL.CustomException
{
    public class ValidateException : Exception
    {
        public string msg { get; set; }

        public ValidateException(string message, Exception innerException): base(message, innerException)
        {
        }

        public ValidateException(string message): base(message)
        {
        }
    }
}
