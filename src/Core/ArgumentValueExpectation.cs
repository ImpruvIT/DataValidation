using System;
using System.Collections.Generic;

namespace ImpruvIT.DataValidation
{
    public class ArgumentValueExpectation<T> : IValidateValue<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentValueExpectation{T}"/> class.
        /// </summary>
        /// <param name="value">The argument value.</param>
        /// <param name="name">The argument name.</param>
        public ArgumentValueExpectation(T value, string name)
        {
            this.Name = name;
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
        public void HandleMissingValue(string expectedValue, string actualValue, string reason, params object[] reasonArgs)
        {
            expectedValue = expectedValue ?? "be specified";
            actualValue = actualValue ?? MessageFormatter.FormatValue(this.Value);

            var message = MessageFormatter.Format(
                "The parameter '{0}' value shall {1}{2} but was {3}.",
                this.Name,
                expectedValue,
                MessageFormatter.FormatReason(reason, reasonArgs),
                actualValue);

            throw new ArgumentNullException(this.Name, message);
        }

        /// <inheritdoc />
        public void HandleValueMismatch(string expectedValue, string actualValue, string reason, params object[] reasonArgs)
        {
            expectedValue = expectedValue ?? "match";
            actualValue = actualValue ?? MessageFormatter.FormatValue(this.Value);

            var message = MessageFormatter.Format(
                "The parameter '{0}' value shall {1}{2} but was {3}.",
                this.Name,
                expectedValue,
                MessageFormatter.FormatReason(reason, reasonArgs),
                actualValue);

            throw new ArgumentOutOfRangeException(this.Name, this.Value, message);
        }
    }
}
