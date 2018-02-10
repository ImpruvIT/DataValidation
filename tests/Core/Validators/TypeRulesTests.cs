using System;
using System.Collections.Generic;

using Xunit;

using ImpruvIT.DataValidators.Xunit;

namespace ImpruvIT.DataValidation.UnitTests
{
    public class TypeRulesTests : RulesTestsBase
    {
        [Fact]
        public void ToBeInstanceOf_Generic_WithParentType_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new TestingClass<int>());

            // Act
            var returnValue = validatorMock.Object.ToBeInstanceOf<TestingClass<int>, Parent<int>>(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeInstanceOf_Generic_WithSameType_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new TestingClass<int>());

            // Act
            var returnValue = validatorMock.Object.ToBeInstanceOf<TestingClass<int>, TestingClass<int>>(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeInstanceOf_Generic_WithImplementedInterface_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new TestingClass<int>());

            // Act
            var returnValue = validatorMock.Object.ToBeInstanceOf<TestingClass<int>, IComparable<int>>(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeInstanceOf_Generic_WithDerivedType_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new TestingClass<int>());

            // Act
            var returnValue = validatorMock.Object.ToBeInstanceOf<TestingClass<int>, Derived<int>>(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeInstanceOf_Generic_WithNotImplementedInterface_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new TestingClass<int>());

            // Act
            var returnValue = validatorMock.Object.ToBeInstanceOf<TestingClass<int>, IEnumerable<int>>(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeInstanceOf_WithParentType_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new TestingClass<int>());

            // Act
            var returnValue = validatorMock.Object.ToBeInstanceOf(typeof(Parent<int>), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeInstanceOf_WithSameType_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new TestingClass<int>());

            // Act
            var returnValue = validatorMock.Object.ToBeInstanceOf(typeof(TestingClass<int>), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeInstanceOf_WithImplementedInterface_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new TestingClass<int>());

            // Act
            var returnValue = validatorMock.Object.ToBeInstanceOf(typeof(IComparable<int>), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeInstanceOf_WithDerivedType_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new TestingClass<int>());

            // Act
            var returnValue = validatorMock.Object.ToBeInstanceOf(typeof(Derived<int>), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeInstanceOf_WithNotImplementedInterface_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(new TestingClass<int>());

            // Act
            var returnValue = validatorMock.Object.ToBeInstanceOf(typeof(IEnumerable<int>), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeAssignableTo_Generic_WithParentType_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(typeof(TestingClass<int>));

            // Act
            var returnValue = validatorMock.Object.ToBeAssignableTo<Parent<int>>(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeAssignableTo_Generic_WithSameType_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(typeof(TestingClass<int>));

            // Act
            var returnValue = validatorMock.Object.ToBeAssignableTo<TestingClass<int>>(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeAssignableTo_Generic_WithImplementedInterface_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(typeof(TestingClass<int>));

            // Act
            var returnValue = validatorMock.Object.ToBeAssignableTo<IComparable<int>>(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeAssignableTo_Generic_WithDerivedType_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(typeof(TestingClass<int>));

            // Act
            var returnValue = validatorMock.Object.ToBeAssignableTo<Derived<int>>(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeAssignableTo_Generic_WithNotImplementedInterface_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(typeof(TestingClass<int>));

            // Act
            var returnValue = validatorMock.Object.ToBeAssignableTo<IEnumerable<int>>(CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeAssignableTo_WithParentType_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(typeof(TestingClass<int>));

            // Act
            var returnValue = validatorMock.Object.ToBeAssignableTo(typeof(Parent<int>), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeAssignableTo_WithSameType_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(typeof(TestingClass<int>));

            // Act
            var returnValue = validatorMock.Object.ToBeAssignableTo(typeof(TestingClass<int>), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeAssignableTo_WithImplementedInterface_Succeeds()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(typeof(TestingClass<int>));

            // Act
            var returnValue = validatorMock.Object.ToBeAssignableTo(typeof(IComparable<int>), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchNotHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeAssignableTo_WithDerivedType_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(typeof(TestingClass<int>));

            // Act
            var returnValue = validatorMock.Object.ToBeAssignableTo(typeof(Derived<int>), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }

        [Fact]
        public void ToBeAssignableTo_WithNotImplementedInterface_ReportsValueMismatch()
        {
            // Arrange
            var validatorMock = this.CreateValidatorMock(typeof(TestingClass<int>));

            // Act
            var returnValue = validatorMock.Object.ToBeAssignableTo(typeof(IEnumerable<int>), CustomReason, CustomReasonArgs);

            // Assert
            VerifyMissingValueNotHandled(validatorMock);
            VerifyValueMismatchHandled(validatorMock);
            returnValue.Suppose().ToBeSameAs(validatorMock.Object);
        }


        public class Parent<T> { }

        public class TestingClass<T> : Parent<T>, IComparable<T>
        {
            public int CompareTo(T other) => 0;
        }

        public class Derived<T> : TestingClass<T> { }
    }
}
