using System;
using System.Collections.Generic;

namespace ImpruvIT.DataValidation
{
    /// <summary>
    /// Denotes a value validator.
    /// </summary>
    /// <typeparam name="T">The type of validated value.</typeparam>
    /// <seealso cref="ImpruvIT.DataValidation.IDescribeValue{T}" />
    public interface IValidateValue<out T> : IDescribeValue<T>
    {
        /// <summary>
        /// Handles a missing value validation failure.
        /// </summary>
        /// <param name="expectedValue">The expected value description.</param>
        /// <param name="actualValue">The actual value description.</param>
        /// <param name="reason">The reason template.</param>
        /// <param name="reasonArgs">The reason template arguments.</param>
        void HandleMissingValue(string expectedValue = null, string actualValue = null, string reason = null, params object[] reasonArgs);


        /// <summary>
        /// Handles an expected value validation failure.
        /// </summary>
        /// <param name="expectedValue">The expected value description.</param>
        /// <param name="actualValue">The actual value description.</param>
        /// <param name="reason">The reason template.</param>
        /// <param name="reasonArgs">The reason template arguments.</param>
        void HandleValueMismatch(string expectedValue = null, string actualValue = null, string reason = null, params object[] reasonArgs);
    }
}
