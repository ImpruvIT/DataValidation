using System;
using System.Collections.Generic;

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
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<ArgumentValueExpectation<object>>(actual);
            Assert.Null(actual.Value);
            Assert.Null(actual.Name);
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
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<ArgumentValueExpectation<object>>(actual);
            Assert.Equal(arg, actual.Value);
            Assert.Equal(argName, actual.Name);
        }

        [Fact]
        public void RequiresArgument_WithoutValueAndName_CreatesArgumentValueRequirement()
        {
            // Act
            var actual = Contract.RequiresArgument<object>(null, null);

            // Assert
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<ArgumentValueExpectation<object>>(actual);
            Assert.Null(actual.Value);
            Assert.Null(actual.Name);
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
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<ArgumentValueExpectation<object>>(actual);
            Assert.Equal(arg, actual.Value);
            Assert.Equal(argName, actual.Name);
        }

        [Fact]
        public void Ensures_ReturnValue_WithoutValueAndName_CreatesReturnValueExpectation()
        {
            // Act
            var actual = Contract.Ensures.ReturnValue<object>(null);

            // Assert
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<ReturnValueExpectation<object>>(actual);
            Assert.Null(actual.Value);
            Assert.Equal(nameof(this.Ensures_ReturnValue_WithoutValueAndName_CreatesReturnValueExpectation), actual.Name);
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
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<ReturnValueExpectation<object>>(actual);
            Assert.Equal(arg, actual.Value);
            Assert.Equal(methodName, actual.Name);
        }

        [Fact]
        public void EnsuresReturnValue_WithoutValueAndName_CreatesReturnValueExpectation()
        {
            // Act
            var actual = Contract.EnsuresReturnValue<object>(null);

            // Assert
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<ReturnValueExpectation<object>>(actual);
            Assert.Null(actual.Value);
            Assert.Equal(nameof(this.EnsuresReturnValue_WithoutValueAndName_CreatesReturnValueExpectation), actual.Name);
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
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<ReturnValueExpectation<object>>(actual);
            Assert.Equal(arg, actual.Value);
            Assert.Equal(methodName, actual.Name);
        }
    }
}
