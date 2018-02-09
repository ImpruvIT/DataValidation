using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ImpruvIT.DataValidation
{
    public static class MessageFormatter
    {
        public static string Format(string template, params object[] args)
        {
            return string.Format(CultureInfo.CurrentCulture, template, args.Select(MessageFormatter.FormatValue)).Trim();
        }

        public static string FormatValue(object value)
        {
            return value is null ? "<NULL>" : value.ToString();
        }

        public static string FormatReason(string reason, params object[] reasonArgs)
        {
            if (string.IsNullOrWhiteSpace(reason))
                return string.Empty;

            reason = string.Format(CultureInfo.CurrentCulture, reason, reasonArgs.Select(MessageFormatter.FormatValue)).Trim();
            if (reason.StartsWith("because"))
                return " " + reason;
            else
                return "because " + reason;
        }
    }
}
