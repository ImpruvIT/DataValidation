using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImpruvIT.DataValidation.MSTest2.UnitTests
{
    [TestClass]
    public class TestResultExpectationTests
    {
        [TestMethod]
        public void Ctor_WithoutValueAndName_InitializesInstance()
        {
            // Act
            var actual = new TestResultExpectation<object>(null, null);

            // Assert
            actual.Value.Suppose().ToBeNull();
            actual.Name.Suppose().ToBeNull();
            actual.Type.Suppose().NotToBeNull();
        }

        [TestMethod]
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

        [TestMethod]
        public void HandleMissingValue_ThrowsAssertActualExpectedException()
        {
            // Arrange
            var expectedExpectedValue = "any expected value";
            var expectedActualValue = "any actual value";
            var expectedReason = "any reason with args {0}, {1}, {2}";
            var expectedReasonArgs = new[] {1, new object(), "haha"};

            var testee = this.CreateTestee();

            // Act
            Action action = () =>
                testee.HandleMissingValue(expectedExpectedValue, expectedActualValue, expectedReason,
                    expectedReasonArgs);

            // Assert
            var exception = AssertException<AssertFailedException>(action);

            Assert.IsTrue(exception.Message.Contains(expectedExpectedValue));
            Assert.IsTrue(exception.Message.Contains(expectedActualValue));
            Assert.IsTrue(exception.Message.Contains(FormatReason(expectedReason, expectedReasonArgs)));
        }

        [TestMethod]
        public void HandleValueMismatch_ThrowsAssertActualExpectedException()
        {
            // Arrange
            var expectedExpectedValue = "any expected value";
            var expectedActualValue = "any actual value";
            var expectedReason = "any reason with args {0}, {1}, {2}";
            var expectedReasonArgs = new[] {1, new object(), "haha"};

            var testee = this.CreateTestee();

            // Act
            Action action = () =>
                testee.HandleValueMismatch(expectedExpectedValue, expectedActualValue, expectedReason,
                    expectedReasonArgs);

            // Assert
            var exception = AssertException<AssertFailedException>(action);

            Assert.IsTrue(exception.Message.Contains(expectedExpectedValue));
            Assert.IsTrue(exception.Message.Contains(expectedActualValue));
            Assert.IsTrue(exception.Message.Contains(FormatReason(expectedReason, expectedReasonArgs)));
        }

        private TestResultExpectation<object> CreateTestee()
        {
            return new TestResultExpectation<object>(null, string.Empty);
        }

        private static string FormatReason(string reason, object[] reasonArgs)
        {
            return string.Format(CultureInfo.CurrentCulture, reason, reasonArgs);
        }

        private static T AssertException<T>(Action action)
            where T : Exception
        {
            try
            {
                action();
                throw new AssertFailedException(
                    $"An exception of type '{typeof(T).FullName}' was expected but was not thrown.");
            }
            catch (T ex)
            {
                return ex;
            }
            catch (Exception ex)
            {
                throw new AssertFailedException(
                    $"An exception of type '{typeof(T).FullName}' was expected but exception of type '{ex.GetType().FullName}' was thrown instead.");
            }
        }
    }
}
