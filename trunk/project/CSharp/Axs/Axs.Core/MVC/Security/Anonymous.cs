using System;

namespace Axis.Infrastructure.MVC.Security
{
    /// <summary>
    ///  Objeto de permissão a usuarios anomimos
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class AnonymousAttribute : Attribute { }
}