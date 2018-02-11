using System;
using System.Collections.Generic;

namespace ImpruvIT.DataValidation.XUnit2
{
    public static class TestResult
    {
        public static IValidateValue<T> Suppose<T>(this T value, string name = null)
        {
            return new TestResultExpectation<T>(value, name);
        }
    }
}
