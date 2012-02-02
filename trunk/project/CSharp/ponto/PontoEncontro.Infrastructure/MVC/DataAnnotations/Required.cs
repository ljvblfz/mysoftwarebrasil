using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lms.API.Infrastructure.UI.DataAnnotations
{
    public class Required : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public Required() : base()
        {
        }
    }
}
