using System;
using System.Collections.Generic;

using Moq;
using Xunit;

namespace ImpruvIT.DataValidation.UnitTests
{
    public class EqualityRulesTests
    {
        private static readonly string CustomReason = "any reason";
        private static readonly object[] CustomReasonArgs = { 1, null, "any value" };

        [Fact]
        public void ToHaveValue_WithRefNullValue_ReportsMissingValue()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<object>(null);

            // Act
            var returnValue = validatorMock.Object.ToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            validatorMock.Verify(x => x.HandleMissingValue(It.IsAny<string>(), It.IsAny<string>(), CustomReason, CustomReasonArgs), Times.Once);
            Assert.Equal(validatorMock.Object, returnValue);
        }

        [Fact]
        public void ToHaveValue_WithValDefaultValue_ReportsMissingValue()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<int>(0);

            // Act
            var returnValue = validatorMock.Object.ToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            validatorMock.Verify(x => x.HandleMissingValue(It.IsAny<string>(), It.IsAny<string>(), CustomReason, CustomReasonArgs), Times.Once);
            Assert.Equal(validatorMock.Object, returnValue);
        }

        [Fact]
        public void ToHaveValue_WithRefNonNullValue_ReturnsItself()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<int>(0);

            // Act
            var returnValue = validatorMock.Object.ToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            validatorMock.Verify(x => x.HandleMissingValue(It.IsAny<string>(), It.IsAny<string>(), CustomReason, CustomReasonArgs), Times.Once);
            Assert.Equal(validatorMock.Object, returnValue);
        }

        private Mock<IValidateValue<T>> CreateValidatorMock<T>(T value, string name = "")
        {
            var expectationMock = new Mock<IValidateValue<T>>();
            expectationMock.Setup(x => x.Value).Returns(value);
            expectationMock.Setup(x => x.Name).Returns(name);
            return expectationMock;
        }
    }
}
