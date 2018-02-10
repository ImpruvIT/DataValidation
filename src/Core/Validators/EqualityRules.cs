using System;
using System.Collections.Generic;

namespace ImpruvIT.DataValidation
{
    public static class EqualityRules
    {
        public static IValidateValue<T> ToHaveValue<T>(this IValidateValue<T> param, string reason = null, params object[] reasonArgs)
        {
            if (object.Equals(param.Value, default(T)))
                param.HandleMissingValue("be specified", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> NotToHaveValue<T>(this IValidateValue<T> param, string reason = null, params object[] reasonArgs)
        {
            if (!object.Equals(param.Value, default(T)))
                param.HandleValueMismatch("not be specified", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeNull<T>(this IValidateValue<T> param, string reason = null, params object[] reasonArgs)
            where T : class
        {
            if (!object.ReferenceEquals(param.Value, null))
                param.HandleValueMismatch("not be specified", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> NotToBeNull<T>(this IValidateValue<T> param, string reason = null, params object[] reasonArgs)
            where T : class
        {
            if (object.ReferenceEquals(param.Value, null))
                param.HandleMissingValue("be specified", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeSameAs<T>(this IValidateValue<T> param, object other, string reason = null, params object[] reasonArgs)
            where T : class
        {
            if (!object.ReferenceEquals(param.Value, other))
                param.HandleValueMismatch($"be same as '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> NotToBeSameAs<T>(this IValidateValue<T> param, object other, string reason = null, params object[] reasonArgs)
            where T : class
        {
            if (object.ReferenceEquals(param.Value, other))
                param.HandleValueMismatch($"be different than '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeEqualTo<T>(this IValidateValue<T> param, object other, string reason = null, params object[] reasonArgs)
        {
            if (!object.Equals(param.Value, other))
                param.HandleValueMismatch($"be equal to '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> NotToBeEqualTo<T>(this IValidateValue<T> param, object other, string reason = null, params object[] reasonArgs)
        {
            if (object.Equals(param.Value, other))
                param.HandleValueMismatch($"be equal to '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeEqualTo<T>(this IValidateValue<T> param, T other, string reason = null, params object[] reasonArgs)
        {
            return param.ToBeEqualTo(other, EqualityComparer<T>.Default, reason, reasonArgs);
        }

        public static IValidateValue<T> NotToBeEqualTo<T>(this IValidateValue<T> param, T other, string reason = null, params object[] reasonArgs)
        {
            return param.NotToBeEqualTo(other, EqualityComparer<T>.Default, reason, reasonArgs);
        }

        public static IValidateValue<T> ToBeEqualTo<T>(this IValidateValue<T> param, T other, IEqualityComparer<T> comparer, string reason = null, params object[] reasonArgs)
        {
            if (!comparer.Equals(param.Value, other))
                param.HandleValueMismatch($"be equal to '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> NotToBeEqualTo<T>(this IValidateValue<T> param, T other, IEqualityComparer<T> comparer, string reason = null, params object[] reasonArgs)
        {
            if (comparer.Equals(param.Value, other))
                param.HandleValueMismatch($"not be equal to '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }
    }
}
