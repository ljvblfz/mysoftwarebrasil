using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPCadDesktopData.Data.BFL.CustomException
{
    public class LoginException : Exception
    {

        public LoginException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public LoginException(string message)
            : base(message)
        {
        }
    }
}
