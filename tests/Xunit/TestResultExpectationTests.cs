using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

using ImpruvIT.DataValidators.Xunit;
using Xunit.Sdk;

namespace ImpruvIT.DataValidation.Xunit.UnitTests
{
    public class TestResultExpectationTests
    {
        [Fact]
        public void Ctor_WithoutValueAndName_InitializesInstance()
        {
            // Act
            var actual = new TestResultExpectation<object>(null, null);

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
            var actual = new TestResultExpectation<object>(value, valueName);

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
            var expectedReasonArgs = new [] { 1, new object(), "haha" };

            var testee = this.CreateTestee();

            // Act
            Action action = () => testee.HandleMissingValue(expectedExpectedValue, expectedActualValue, expectedReason, expectedReasonArgs);

            // Assert
            var exception = Assert.Throws<AssertActualExpectedException>(action);

            exception.Expected.Suppose().ToBeEqualTo(expectedExpectedValue);
            exception.Actual.Suppose().ToBeEqualTo(expectedActualValue);
            Assert.Contains(FormatReason(expectedReason, expectedReasonArgs), exception.Message);
        }

        [Fact]
        public void HandleMissingValue_WithoutExpectedValue_FillsSubstitution()
        {
            // Arrange
            var expectedActualValue = "any actual value";
            var expectedReason = "any reason with args {0}, {1}, {2}";
            var expectedReasonArgs = new[] { 1, new object(), "haha" };

            var testee = this.CreateTestee();

            // Act
            Action action = () => testee.HandleMissingValue(null, expectedActualValue, expectedReason, expectedReasonArgs);

            // Assert
            var exception = Assert.Throws<AssertActualExpectedException>(action);

            Assert.False(string.IsNullOrWhiteSpace(exception.Expected));
            //exception.Expected.Suppose().NotToBeNull();
            exception.Actual.Suppose().ToBeEqualTo(expectedActualValue);
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
            var exception = Assert.Throws<AssertActualExpectedException>(action);

            exception.Expected.Suppose().ToBeEqualTo(expectedExpectedValue);
            exception.Actual.Suppose().ToBeEqualTo(expectedActualValue);
            Assert.Contains(FormatReason(expectedReason, expectedReasonArgs), exception.Message);
        }

        [Fact]
        public void HandleValueMismatch_WithoutExpectedValue_FillsSubstitution()
        {
            // Arrange
            var expectedActualValue = "any actual value";
            var expectedReason = "any reason with args {0}, {1}, {2}";
            var expectedReasonArgs = new[] { 1, new object(), "haha" };

            var testee = this.CreateTestee();

            // Act
            Action action = () => testee.HandleValueMismatch(null, expectedActualValue, expectedReason, expectedReasonArgs);

            // Assert
            var exception = Assert.Throws<AssertActualExpectedException>(action);

            Assert.False(string.IsNullOrWhiteSpace(exception.Expected));
            //exception.Expected.Suppose().NotToBeNull();
            exception.Actual.Suppose().ToBeEqualTo(expectedActualValue);
            Assert.Contains(FormatReason(expectedReason, expectedReasonArgs), exception.Message);
        }

        private TestResultExpectation<object> CreateTestee()
        {
            return new TestResultExpectation<object>(null, string.Empty);
        }

        private static string FormatReason(string reason, object[] reasonArgs)
        {
            return string.Format(CultureInfo.CurrentCulture, reason, reasonArgs);
        }
    }
}
