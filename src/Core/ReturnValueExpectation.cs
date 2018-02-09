using System;
using System.Collections.Generic;

namespace ImpruvIT.DataValidation
{
    public class ReturnValueExpectation<T> : IValidateValue<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnValueExpectation{T}"/> class.
        /// </summary>
        /// <param name="value">The return value.</param>
        public ReturnValueExpectation(T value, string methodName)
        {
            this.Name = methodName;
            this.Type = typeof(T).Name;
            this.Value = value;
        }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public string Type { get; }

        /// <inheritdoc />
        public T Value { get; }

        /// <inheritdoc />
        public void HandleMissingValue(string message)
        {
            throw new InvalidOperationException($"The parameter '{this.Name}' was expected {message} but was not.");
        }

        /// <inheritdoc />
        public void HandleValueMismatch(string expectedValue, string actualValue, string message)
        {
            throw new InvalidOperationException($"The parameter '{this.Name}' was expected {message} but was not.");
        }


        /// <inheritdoc />
        public void HandleMissingValue(string expectedValue, string actualValue, string reason, params object[] reasonArgs)
        {
            expectedValue = expectedValue ?? "have value";
            actualValue = actualValue ?? MessageFormatter.FormatValue(this.Value);

            var message = MessageFormatter.Format(
                "The return value of method '{0}' shall {1}{2} but was {3}.",
                this.Name,
                expectedValue,
                MessageFormatter.FormatReason(reason, reasonArgs),
                actualValue);

            throw new InvalidOperationException(message);
        }

        /// <inheritdoc />
        public void HandleValueMismatch(string expectedValue, string actualValue, string reason, params object[] reasonArgs)
        {
            expectedValue = expectedValue ?? "match";
            actualValue = actualValue ?? MessageFormatter.FormatValue(this.Value);

            var message = MessageFormatter.Format(
                "The return value of method '{0}' shall {1}{2} but was {3}.",
                this.Name,
                expectedValue,
                MessageFormatter.FormatReason(reason, reasonArgs),
                actualValue);

            throw new InvalidOperationException(message);
        }
    }
}
