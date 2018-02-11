using System;
using System.Collections.Generic;

using Xunit;

using ImpruvIT.DataValidation.XUnit2;

namespace ImpruvIT.DataValidation.UnitTests
{
    public class EqualityRulesTests : RulesTestsBase
    {
        [Fact]
        public void ToHaveValue_WithRefNullValue_ReportsMissingValue()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<object>(null);

            // Act
            var returnValue = validatorMock.Object.ToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToHaveValue_WithValDefaultValue_ReportsMissingValue()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<int>(0);

            // Act
            var returnValue = validatorMock.Object.ToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToHaveValue_WithRefNonNullValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<object>(new object());

            // Act
            var returnValue = validatorMock.Object.ToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToHaveValue_WithValNonDefaultValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<int>(5);

            // Act
            var returnValue = validatorMock.Object.ToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToHaveValue_WithRefNullValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<object>(null);

            // Act
            var returnValue = validatorMock.Object.NotToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToHaveValue_WithValDefaultValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<int>(0);

            // Act
            var returnValue = validatorMock.Object.NotToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToHaveValue_WithRefNonNullValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<object>(new object());

            // Act
            var returnValue = validatorMock.Object.NotToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToHaveValue_WithValNonDefaultValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<int>(5);

            // Act
            var returnValue = validatorMock.Object.NotToHaveValue(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeNull_WithNonNullValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<object>(new object());

            // Act
            var returnValue = validatorMock.Object.ToBeNull(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeNull_WithNullValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<object>(null);

            // Act
            var returnValue = validatorMock.Object.ToBeNull(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeNull_WithNonNullValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<object>(new object());

            // Act
            var returnValue = validatorMock.Object.NotToBeNull(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeNull_WithNullValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock<object>(null);

            // Act
            var returnValue = validatorMock.Object.NotToBeNull(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeSameAs_WithDifferentObject_ReportsValueMismatch()
        {
            // Arrange
            var obj = new object();
            var validatorMock = this.CreateValidatorMock<object>(obj);

            // Act
            var returnValue = validatorMock.Object.ToBeSameAs(new object(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeSameAs_WithSameObject_Succeeds()
        {
            // Arrange
            var obj = new object();
            var validatorMock = this.CreateValidatorMock<object>(obj);

            // Act
            var returnValue = validatorMock.Object.ToBeSameAs(obj, CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeSameAs_WithDifferentObject_Succeeds()
        {
            // Arrange
            var obj = new object();
            var validatorMock = this.CreateValidatorMock<object>(obj);

            // Act
            var returnValue = validatorMock.Object.NotToBeSameAs(new object(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeSameAs_WithSameObject_ReportsValueMismatch()
        {
            // Arrange
            var obj = new object();
            var validatorMock = this.CreateValidatorMock<object>(obj);

            // Act
            var returnValue = validatorMock.Object.NotToBeSameAs(obj, CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualToObject_WithNotEqualObject_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new EquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo((object)new EquatableObject(2), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualToObject_WithNotEqualValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo((object)2, CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualToObject_WithEqualObject_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new EquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo((object)new EquatableObject(1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualToObject_WithEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo((object)1, CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualToObject_WithNonEqualObject_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new EquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo((object)new EquatableObject(2), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualToObject_WithNonEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo((object)2, CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualToObject_WithEqualObject_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new EquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo((object)new EquatableObject(1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualToObject_WithEqualValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo((object)1, CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualTo_WithNotEqualObject_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new EquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo(new EquatableObject(2), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualTo_WithNotEqualValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo(2, CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualTo_WithEqualObject_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new EquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo(new EquatableObject(1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualTo_WithEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo(1, CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualTo_WithNonEqualObject_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new EquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo(new EquatableObject(2), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualTo_WithNonEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo(2, CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualTo_WithEqualObject_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new EquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo(new EquatableObject(1), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualTo_WithEqualValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo(1, CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualToComparer_WithNotEqualObject_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonEquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo(new NonEquatableObject(2), new NonEquatableObjectComparator(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualToComparer_WithNotEqualValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo(2, new IntComparator(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualToComparer_WithEqualObject_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonEquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo(new NonEquatableObject(1), new NonEquatableObjectComparator(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeEqualToComparer_WithEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.ToBeEqualTo(1, new IntComparator(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualToComparer_WithNonEqualObject_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonEquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo(new NonEquatableObject(2), new NonEquatableObjectComparator(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualToComparer_WithNonEqualValue_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo(2, new IntComparator(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualToComparer_WithEqualObject_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new NonEquatableObject(1));

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo(new NonEquatableObject(1), new NonEquatableObjectComparator(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void NotToBeEqualToComparer_WithEqualValue_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(1);

            // Act
            var returnValue = validatorMock.Object.NotToBeEqualTo(1, new IntComparator(), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }
        
        public class EquatableObject
        {
            public EquatableObject(int value)
            {
                this.Value = value;
            }

            public int Value { get; }

            public override bool Equals(object obj)
            {
                return ((EquatableObject)obj).Value == this.Value;
            }

            public override int GetHashCode()
            {
                return this.Value;
            }
        }

        public class NonEquatableObject
        {
            public NonEquatableObject(int value)
            {
                this.Value = value;
            }

            public int Value { get; }
        }

        private class NonEquatableObjectComparator : IEqualityComparer<NonEquatableObject>
        {
            public bool Equals(NonEquatableObject x, NonEquatableObject y)
            {
                return x.Value == y.Value;
            }

            public int GetHashCode(NonEquatableObject obj)
            {
                return obj.Value;
            }
        }

        private class IntComparator : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                return x == y;
            }

            public int GetHashCode(int obj)
            {
                return obj;
            }
        }
    }
}
