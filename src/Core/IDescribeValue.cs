using System;
using System.Collections.Generic;

namespace ImpruvIT.DataValidation
{
    /// <summary>
    /// Denotes a value description.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public interface IDescribeValue<out T>
    {
        /// <summary>
        /// Gets the logical name of the value.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the logical type of the value.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        T Value { get; }
    }
}
