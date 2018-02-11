﻿using System;
using System.Collections.Generic;

using Xunit;

namespace ImpruvIT.DataValidation.XUnit2.UnitTests
{
    public class TestResultTests
    {
        [Fact]
        public void Suppose_WithoutValue_CreatesTestResultExpectation()
        {
            // Act
            var actual = TestResult.Suppose<object>(null);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(TestResultExpectation<object>));
            actual.Value.Suppose().ToBeNull();
            actual.Name.Suppose().ToBeNull();
        }

        [Fact]
        public void Suppose_WithValue_CreatesTestResultExpectation()
        {
            // Arrange
            var arg = new object();

            // Act
            var actual = TestResult.Suppose<object>(arg);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(TestResultExpectation<object>));
            actual.Value.Suppose().ToBeSameAs(arg);
            actual.Name.Suppose().ToBeNull();
        }

        [Fact]
        public void Suppose_WithName_CreatesTestResultExpectationWithName()
        {
            // Arrange
            var value = new object();
            var valueName = "any name";

            // Act
            var actual = TestResult.Suppose<object>(value, valueName);

            // Assert
            actual.Suppose()
                .NotToBeNull()
                .ToBeInstanceOf(typeof(TestResultExpectation<object>));
            actual.Value.Suppose().ToBeSameAs(value);
            actual.Name.Suppose().ToBeEqualTo(valueName);
        }
    }
}
