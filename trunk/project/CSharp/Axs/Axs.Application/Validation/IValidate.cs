using System.Collections.Generic;

namespace Axis.Application.Validate
{
    /// <summary>
    /// Provides the means to check if the validity of the current state of an <see langword="object"/>.
    /// </summary>
    /// <seealso cref="NotifyValidatableBase"/>
    /// <seealso cref="DataErrorInfoValidatableBase"/>
    /// <seealso cref="ValidatableBase"/>
    public interface IValidate
    {
        /// <summary>
        /// Gets a <see langword="bool"/> indicating if the current state is valid.
        /// </summary>
        bool IsValid { get; set; }

        /// <summary>
        /// Gets a <see see="{T}"/> of <see langword="string"/>s that contain all the error messages.
        /// </summary>
        string ErrorMessage { get;}
    }
}