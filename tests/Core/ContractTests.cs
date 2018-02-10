using System;
using System.Collections.Generic;
using ImpruvIT.DataValidators.Xunit;
using Xunit;

namespace ImpruvIT.DataValidation.UnitTests
{
    public class ContractTests
    {
        [Fact]
        public void Requires_Argument_WithoutValueAndName_CreatesArgumentValueRequirement()
        {
            // Act
            var actual = Contract.Requires.Argument<object>(null, null);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(ArgumentValueExpectation<object>));
            actual.Value.Suppose().ToBeNull();
            actual.Name.Suppose().ToBeNull();
        }

        [Fact]
        public void Requires_Argument_WithValueAndName_CreatesArgumentValueRequirement()
        {
            // Arrange
            var arg = new object();
            var argName = "arg name";

            // Act
            var actual = Contract.Requires.Argument(arg, argName);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(ArgumentValueExpectation<object>));
            actual.Value.Suppose().ToBeEqualTo(arg);
            actual.Name.Suppose().ToBeEqualTo(argName);
        }

        [Fact]
        public void RequiresArgument_WithoutValueAndName_CreatesArgumentValueRequirement()
        {
            // Act
            var actual = Contract.RequiresArgument<object>(null, null);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(ArgumentValueExpectation<object>));
            actual.Value.Suppose().ToBeNull();
            actual.Name.Suppose().ToBeNull();
        }

        [Fact]
        public void RequiresArgument_WithValueAndName_CreatesArgumentValueRequirement()
        {
            // Arrange
            var arg = new object();
            var argName = "arg name";

            // Act
            var actual = Contract.RequiresArgument(arg, argName);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(ArgumentValueExpectation<object>));
            actual.Value.Suppose().ToBeEqualTo(arg);
            actual.Name.Suppose().ToBeEqualTo(argName);
        }

        [Fact]
        public void Ensures_ReturnValue_WithoutValueAndName_CreatesReturnValueExpectation()
        {
            // Act
            var actual = Contract.Ensures.ReturnValue<object>(null);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(ReturnValueExpectation<object>));
            actual.Value.Suppose().ToBeNull();
            actual.Name.Suppose().ToBeEqualTo(nameof(this.Ensures_ReturnValue_WithoutValueAndName_CreatesReturnValueExpectation));
        }

        [Fact]
        public void Ensures_ReturnValue_WithValueAndCustomName_CreatesReturnValueExpectation()
        {
            // Arrange
            var arg = new object();
            var methodName = "Custom method name";

            // Act
            var actual = Contract.Ensures.ReturnValue(arg, methodName);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(ReturnValueExpectation<object>));
            actual.Value.Suppose().ToBeEqualTo(arg);
            actual.Name.Suppose().ToBeEqualTo(methodName);
        }

        [Fact]
        public void EnsuresReturnValue_WithoutValueAndName_CreatesReturnValueExpectation()
        {
            // Act
            var actual = Contract.EnsuresReturnValue<object>(null);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(ReturnValueExpectation<object>));
            actual.Value.Suppose().ToBeNull();
            actual.Name.Suppose().ToBeEqualTo(nameof(this.EnsuresReturnValue_WithoutValueAndName_CreatesReturnValueExpectation));
        }

        [Fact]
        public void EnsuresReturnValue_WithValueAndName_CreatesReturnValueExpectation()
        {
            // Arrange
            var arg = new object();
            var methodName = "Custom method name";

            // Act
            var actual = Contract.EnsuresReturnValue(arg, methodName);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(ReturnValueExpectation<object>));
            actual.Value.Suppose().ToBeEqualTo(arg);
            actual.Name.Suppose().ToBeEqualTo(methodName);
        }
    }
}
