using System;
using System.Collections.Generic;

using Xunit.Sdk;

using ImpruvIT.DataValidation;

namespace ImpruvIT.DataValidators.Xunit
{
    public class TestResultExpectation<T> : IValidateValue<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestResultExpectation{T}"/> class.
        /// </summary>
        /// <param name="value">The argument value.</param>
        /// <param name="name">The argument name.</param>
        public TestResultExpectation(T value, string name)
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
            this.HandleValueMismatch(expectedValue, actualValue, reason, reasonArgs);
        }

        /// <inheritdoc />
        public void HandleValueMismatch(string expectedValue, string actualValue, string reason, params object[] reasonArgs)
        {
            expectedValue = expectedValue ?? "match";
            actualValue = actualValue ?? MessageFormatter.FormatValue(this.Value);

            var message = MessageFormatter.Format(
                "The {0} value shall {1}{2} but was {3}.",
                this.Name == null ? "actual" : $"'{this.Name}'",
                expectedValue,
                MessageFormatter.FormatReason(reason, reasonArgs),
                actualValue);

            throw new AssertActualExpectedException(expectedValue, actualValue, message);
        }
    }
}
