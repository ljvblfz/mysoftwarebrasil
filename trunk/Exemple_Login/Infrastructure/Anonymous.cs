using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemple_Login.Infrastructure
{
    /// <summary>
    ///  Objeto de permissão a usuarios anomimos
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class Anonymous : Attribute { }
}
