using System;
using System.Collections.Generic;

using ImpruvIT.DataValidation;

namespace ImpruvIT.DataValidators.Xunit
{
    public static class TestResult
    {
        public static IValidateValue<T> Suppose<T>(this T value, string name = null)
        {
            return new TestResultExpectation<T>(value, name);
        }
    }
}
