using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace ImpruvIT.DataValidation.UnitTests
{
    public abstract class RulesTestsBase
    {
        protected static readonly string CustomReason = "any reason";
        protected static readonly object[] CustomReasonArgs = { 1, null, "any value" };

        protected Mock<IValidateValue<T>> CreateValidatorMock<T>(T value, string name = "")
        {
            var expectationMock = new Mock<IValidateValue<T>>();
            expectationMock.Setup(x => x.Value).Returns(value);
            expectationMock.Setup(x => x.Name).Returns(name);
            return expectationMock;
        }

        protected static void VerifyMissingValueHandled<T>(Mock<IValidateValue<T>> mock)
        {
            mock.Verify(x => x.HandleMissingValue(It.IsAny<string>(), It.IsAny<string>(), CustomReason, CustomReasonArgs), Times.Once);
        }

        protected static void VerifyMissingValueNotHandled<T>(Mock<IValidateValue<T>> mock)
        {
            mock.Verify(x => x.HandleMissingValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        protected static void VerifyValueMismatchHandled<T>(Mock<IValidateValue<T>> mock)
        {
            mock.Verify(x => x.HandleValueMismatch(It.IsAny<string>(), It.IsAny<string>(), CustomReason, CustomReasonArgs), Times.Once);
        }

        protected static void VerifyValueMismatchNotHandled<T>(Mock<IValidateValue<T>> mock)
        {
            mock.Verify(x => x.HandleValueMismatch(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
