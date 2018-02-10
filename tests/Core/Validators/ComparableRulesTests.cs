using System;
using System.Collections.Generic;

using Moq;
using Xunit;

using ImpruvIT.DataValidators.Xunit;

namespace ImpruvIT.DataValidation.UnitTests
{
    public class ComparableRulesTests : RulesTestsBase
    {
        [Fact]
        public void ToBeNegative_WithPositiveValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(1));

            // Act
            var returnValue = validatorMock.Object.ToBeNegative(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeNegative_WithZeroValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeNegative(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeNegative_WithNegativeValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(-1));

            // Act
            var returnValue = validatorMock.Object.ToBeNegative(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBePositive_WithNegativeValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(-1));

            // Act
            var returnValue = validatorMock.Object.NotToBePositive(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBePositive_WithZeroValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.NotToBePositive(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBePositive_WithPositiveValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(1));

            // Act
            var returnValue = validatorMock.Object.NotToBePositive(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeNegative_WithPositiveValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(1));

            // Act
            var returnValue = validatorMock.Object.NotToBeNegative(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeNegative_WithZeroValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.NotToBeNegative(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeNegative_WithNegativeValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(-1));

            // Act
            var returnValue = validatorMock.Object.NotToBeNegative(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBePositive_WithNegativeValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(-1));

            // Act
            var returnValue = validatorMock.Object.ToBePositive(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBePositive_WithZeroValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBePositive(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBePositive_WithPositiveValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(1));

            // Act
            var returnValue = validatorMock.Object.ToBePositive(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreThan_WithBiggerValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new ComparableObject(1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreThan_WithEqualValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new ComparableObject(0), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreThan_WithSmallerValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new ComparableObject(-1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreThanComparer_WithBiggerValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new NonComparableObject(1), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreThanComparer_WithEqualValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new NonComparableObject(0), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreThanComparer_WithSmallerValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new NonComparableObject(-1), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreOrEqualThan_WithBiggerValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new ComparableObject(1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreOrEqualThan_WithEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new ComparableObject(0), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreOrEqualThan_WithSmallerValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new ComparableObject(-1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreOrEqualThanComparer_WithBiggerValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new NonComparableObject(1), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreOrEqualThanComparer_WithEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new NonComparableObject(0), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeMoreOrEqualThanComparer_WithSmallerValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeMoreThan(new NonComparableObject(-1), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessOrEqualThan_WithSmallerValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessOrEqualThan(new ComparableObject(-1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessOrEqualThan_WithEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessOrEqualThan(new ComparableObject(0), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessOrEqualThan_WithBiggerValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessOrEqualThan(new ComparableObject(1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessOrEqualThanComparer_WithSmallerValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessOrEqualThan(new NonComparableObject(-1), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessOrEqualThanComparer_WithEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessOrEqualThan(new NonComparableObject(0), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessOrEqualThanComparer_WithBiggerValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessOrEqualThan(new NonComparableObject(1), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessThan_WithSmallerValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessThan(new ComparableObject(-1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessThan_WithEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessThan(new ComparableObject(0), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessThan_WithBiggerValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new ComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessThan(new ComparableObject(1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessThanComparer_WithSmallerValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessThan(new NonComparableObject(-1), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessThanComparer_WithEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessThan(new NonComparableObject(0), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeLessThanComparer_WithBiggerValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonComparableObject(0));

            // Act
            var returnValue = validatorMock.Object.ToBeLessThan(new NonComparableObject(1), new NonComparableObjectComparer(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }
        
        public class ComparableObject : IComparable<ComparableObject>
        {
            public ComparableObject(int value)
            {
                this.Value = value;
            }

            public int Value { get; }

            public int CompareTo(ComparableObject other)
            {
                return this.Value - (other?.Value ?? 0);
            }
        }

        public class NonComparableObject
        {
            public NonComparableObject(int value)
            {
                this.Value = value;
            }

            public int Value { get; }
        }

        private class NonComparableObjectComparer : IComparer<NonComparableObject>
        {
            public int Compare(NonComparableObject x, NonComparableObject y)
            {
                return (x?.Value ?? 0) - (y?.Value ?? 0);
            }
        }
    }
}
