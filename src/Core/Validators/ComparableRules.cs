using System;
using System.Collections.Generic;

namespace ImpruvIT.DataValidation
{
    public static class ComparableRules
    {
        public static IValidateValue<T> ToBeNegative<T>(this IValidateValue<T> param, string reason = null, params object[] reasonArgs)
            where T : IComparable<T>
        {
            if (param.Value.CompareTo(default(T)) >= 0)
                param.HandleValueMismatch("to be negative", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> NotToBePositive<T>(this IValidateValue<T> param, string reason = null, params object[] reasonArgs)
            where T : IComparable<T>
        {
            if (param.Value.CompareTo(default(T)) > 0)
                param.HandleValueMismatch("not be positive", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> NotToBeNegative<T>(this IValidateValue<T> param, string reason = null, params object[] reasonArgs)
            where T : IComparable<T>
        {
            if (param.Value.CompareTo(default(T)) < 0)
                param.HandleValueMismatch("not be negative", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBePositive<T>(this IValidateValue<T> param, string reason = null, params object[] reasonArgs)
            where T : IComparable<T>
        {
            if (param.Value.CompareTo(default(T)) <= 0)
                param.HandleValueMismatch("be positive", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeMoreThan<T>(this IValidateValue<T> param, T other, string reason = null, params object[] reasonArgs)
            where T : IComparable<T>
        {
            if (param.Value.CompareTo(other) <= 0)
                param.HandleValueMismatch($"be more than '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeMoreThan<T>(this IValidateValue<T> param, T other, IComparer<T> comparer, string reason = null, params object[] reasonArgs)
        {
            if (comparer.Compare(param.Value, other) <= 0)
                param.HandleValueMismatch($"be more than '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeMoreOrEqualThan<T>(this IValidateValue<T> param, T other, string reason = null, params object[] reasonArgs)
            where T : IComparable<T>
        {
            if (param.Value.CompareTo(other) < 0)
                param.HandleValueMismatch($"be more or equal than '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeMoreOrEqualThan<T>(this IValidateValue<T> param, T other, IComparer<T> comparer, string reason = null, params object[] reasonArgs)
        {
            if (comparer.Compare(param.Value, other) < 0)
                param.HandleValueMismatch($"be more or equal than '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeLessOrEqualThan<T>(this IValidateValue<T> param, T other, string reason = null, params object[] reasonArgs)
            where T : IComparable<T>
        {
            if (param.Value.CompareTo(other) > 0)
                param.HandleValueMismatch($"be less or equal to '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeLessOrEqualThan<T>(this IValidateValue<T> param, T other, IComparer<T> comparer, string reason = null, params object[] reasonArgs)
        {
            if (comparer.Compare(param.Value, other) > 0)
                param.HandleValueMismatch($"be less or equal to '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeLessThan<T>(this IValidateValue<T> param, T other, string reason = null, params object[] reasonArgs)
            where T : IComparable<T>
        {
            if (param.Value.CompareTo(other) >= 0)
                param.HandleValueMismatch($"be less than '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }

        public static IValidateValue<T> ToBeLessThan<T>(this IValidateValue<T> param, T other, IComparer<T> comparer, string reason = null, params object[] reasonArgs)
        {
            if (comparer.Compare(param.Value, other) >= 0)
                param.HandleValueMismatch($"be less than '{MessageFormatter.FormatValue(other)}'", null, reason, reasonArgs);

            return param;
        }
    }
}
