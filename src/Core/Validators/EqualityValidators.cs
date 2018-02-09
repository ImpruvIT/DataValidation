using System;
using System.Collections.Generic;

namespace ImpruvIT.DataValidation
{
    public static class EqualityValidators
    {
        public static IValidateValue<T> ToHaveValue<T>(this IValidateValue<T> param, string reason, params object[] reasonArgs)
        {
            if (object.Equals(param.Value, default(T)))
                param.HandleMissingValue("be specified", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> NotToHaveValue<T>(this IValidateValue<T> param, string reason, params object[] reasonArgs)
        {
            if (!object.Equals(param.Value, default(T)))
                param.HandleValueMismatch("not be specified", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeNull<T>(this IValidateValue<T> param, string reason, params object[] reasonArgs)
            where T : class
        {
            if (!object.ReferenceEquals(param.Value, null))
                param.HandleMissingValue("be specified", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> NotToBeNull<T>(this IValidateValue<T> param, string reason, params object[] reasonArgs)
        {
            if (object.ReferenceEquals(param.Value, null))
                param.HandleValueMismatch("not be specified", null, reason, reasonArgs);

            return param;
        }
    }
}
