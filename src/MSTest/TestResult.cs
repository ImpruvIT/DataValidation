using System;
using System.Collections.Generic;

namespace ImpruvIT.DataValidation.MSTest
{
    public static class TestResult
    {
        public static IValidateValue<T> Suppose<T>(this T value, string name = null)
        {
            return new TestResultExpectation<T>(value, name);
        }
    }
}
