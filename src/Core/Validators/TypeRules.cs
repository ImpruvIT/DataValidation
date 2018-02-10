using System;
using System.Collections.Generic;

namespace ImpruvIT.DataValidation
{
    public static class TypeRules
    {
#if NETSTANDARD2_0

        public static IValidateValue<TValue> ToBeInstanceOf<TValue, TType>(this IValidateValue<TValue> param, string reason = null, params object[] reasonArgs)
        {
            return param.ToBeInstanceOf(typeof(TType), reason, reasonArgs);
        }

        public static IValidateValue<TValue> ToBeInstanceOf<TValue>(this IValidateValue<TValue> param, Type targetType, string reason = null, params object[] reasonArgs)
        {
            if (!targetType.IsInstanceOfType(param.Value))
            {
                param.HandleValueMismatch(
                    $"be instance of \"{targetType.FullName}\"",
                    param.Value != null ? $"instance of \"{param.Value.GetType().FullName}\"" : null,
                    reason, 
                    reasonArgs);
            }

            return param;
        }

        public static IValidateValue<Type> ToBeAssignableTo<T>(this IValidateValue<Type> param, string reason = null, params object[] reasonArgs)
        {
            return param.ToBeAssignableTo(typeof(T), reason, reasonArgs);
        }

        public static IValidateValue<Type> ToBeAssignableTo(this IValidateValue<Type> param, Type type, string reason = null, params object[] reasonArgs)
        {
            if (!type.IsAssignableFrom(param.Value))
            {
                param.HandleValueMismatch(
                    $"be assignable to \"{type.FullName}\"", 
                    null, 
                    reason, 
                    reasonArgs);
            }

            return param;
        }

#endif // NETSTANDARD2_0
    }
}
