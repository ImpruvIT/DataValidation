using System;
using System.Collections.Generic;
using System.Globalization;
using ImpruvIT.DataValidators.Xunit;
using Xunit;
using Xunit.Sdk;

namespace ImpruvIT.DataValidation.UnitTests
{
    public class ReturnValueExpectationTests
    {
        private const string MethodName = "any param";

        [Fact]
        public void Ctor_WithoutValueAndName_InitializesInstance()
        {
            // Act
            var actual = new ReturnValueExpectation<object>(null, null);

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
            var methodName = "any name";

            // Act
            var actual = new ReturnValueExpectation<object>(value, methodName);

            // Assert
            actual.Value.Suppose().ToBeEqualTo(value);
            actual.Name.Suppose().ToBeEqualTo(methodName);
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
            var exception = Assert.Throws<InvalidOperationException>(action);

            Assert.Contains(expectedExpectedValue, exception.Message);
            Assert.Contains(expectedActualValue, exception.Message);
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
            var exception = Assert.Throws<InvalidOperationException>(action);

            Assert.Contains(expectedExpectedValue, exception.Message);
            Assert.Contains(expectedActualValue, exception.Message);
            Assert.Contains(FormatReason(expectedReason, expectedReasonArgs), exception.Message);
        }

        private ReturnValueExpectation<object> CreateTestee()
        {
            return new ReturnValueExpectation<object>(new object(), MethodName);
        }

        private static string FormatReason(string reason, object[] reasonArgs)
        {
            return string.Format(CultureInfo.CurrentCulture, reason, reasonArgs);
        }
    }
}
