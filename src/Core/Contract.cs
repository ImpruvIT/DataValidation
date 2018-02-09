using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ImpruvIT.DataValidation
{
    public static class Contract
    {
        public static class Requires
        {
            public static IValidateValue<T> Argument<T>(T value, string name)
            {
                return new ArgumentValueExpectation<T>(value, name);
            }
        }

        public static IValidateValue<T> RequiresArgument<T>(T value, string name)
        {
            return Requires.Argument(value, name);
        }

        public static class Ensures
        {
            public static IValidateValue<T> ReturnValue<T>(T value, [CallerMemberName] string methodName = null)
            {
                return new ReturnValueExpectation<T>(value, methodName);
            }
        }

        public static IValidateValue<T> EnsuresReturnValue<T>(T value, [CallerMemberName] string methodName = null)
        {
            return Ensures.ReturnValue(value, methodName);
        }
    }
}
