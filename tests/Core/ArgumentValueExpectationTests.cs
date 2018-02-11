using System;
using System.Collections.Generic;
using System.Globalization;

using Xunit;

using ImpruvIT.DataValidation.XUnit2;

namespace ImpruvIT.DataValidation.UnitTests
{
    public class ArgumentValueExpectationTests
    {
        private const string ParamName = "any param";

        [Fact]
        public void Ctor_WithoutValueAndName_InitializesInstance()
        {
            // Act
            var actual = new ArgumentValueExpectation<object>(null, null);

            // Assert
            actual.Value.Suppose().ToBeNull();
            actual.Name.Suppose().ToBeNull();
            actual.Type.Suppose().NotToBeNull();
        }

        [Fact]
        public void Ctor_WithValueAndName_InitializesInstance()
        {
            // Arrange
            var value = new object();
            var valueName = "any name";

            // Act
            var actual = new ArgumentValueExpectation<object>(value, valueName);

            // Assert
            actual.Value.Suppose().ToBeEqualTo(value);
            actual.Name.Suppose().ToBeEqualTo(valueName);
        }

        [Fact]
        public void HandleMissingValue_ThrowsAssertActualExpectedException()
        {
            // Arrange
            var expectedExpectedValue = "any expected value";
            var expectedActualValue = "any actual value";
            var expectedReason = "any reason with args {0}, {1}, {2}";
            var expectedReasonArgs = new[] { 1, new object(), "haha" };

            var testee = this.CreateTestee();

            // Act
            Action action = () => testee.HandleMissingValue(expectedExpectedValue, expectedActualValue, expectedReason, expectedReasonArgs);

            // Assert
            var exception = Assert.Throws<ArgumentNullException>(action);

            exception.ParamName.Suppose().ToBeEqualTo(ParamName);
            Assert.Contains(FormatReason(expectedReason, expectedReasonArgs), exception.Message);
        }

        [Fact]
        public void HandleValueMismatch_ThrowsAssertActualExpectedException()
        {
            // Arrange
            var expectedExpectedValue = "any expected value";
            var expectedActualValue = "any actual value";
            var expectedReason = "any reason with args {0}, {1}, {2}";
            var expectedReasonArgs = new[] { 1, new object(), "haha" };

            var testee = this.CreateTestee();

            // Act
            Action action = () => testee.HandleValueMismatch(expectedExpectedValue, expectedActualValue, expectedReason, expectedReasonArgs);

            // Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(action);

            exception.ParamName.Suppose().ToBeEqualTo(ParamName);
            exception.ActualValue.Suppose().ToBeSameAs(testee.Value);
            Assert.Contains(FormatReason(expectedReason, expectedReasonArgs), exception.Message);
        }

        private ArgumentValueExpectation<object> CreateTestee()
        {
            return new ArgumentValueExpectation<object>(new object(), ParamName);
        }

        private static string FormatReason(string reason, object[] reasonArgs)
        {
            return string.Format(CultureInfo.CurrentCulture, reason, reasonArgs);
        }
    }
}
