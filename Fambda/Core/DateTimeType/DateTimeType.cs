using System;
using System.Diagnostics.Contracts;
using static Fambda.F;

namespace Fambda
{
    /// <summary>
    /// Represents DateTimeType type.
    /// </summary>
    public static class DateTimeType
    {
        /// <summary>
        /// Converts the string representation of a date and time into <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="s">A string containing a date and time to convert.</param>
        /// <returns><see cref="Option{T}"/> with <see cref="OptionSome{T}"/> if <paramref name="s" /> was converted successfully; otherwise, <see cref="OptionNone"/>.</returns>
        [Pure]
        public static Option<DateTime> Parse(string s)
            => DateTime.TryParse(s, out var parseResult) ? Some(parseResult) : None;

        /// <summary>
        /// Converts the string representation of a date and time by using culture-specific format information into <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="s">A string that contains a date and time to convert.</param>
        /// <param name="provider">An object that supplies culture-specific format information about <paramref name="s" />.</param>
        /// <returns><see cref="Option{T}"/> with <see cref="OptionSome{T}"/> if <paramref name="s" /> was converted successfully; otherwise, <see cref="OptionNone"/>.</returns>
        [Pure]
        public static Option<DateTime> Parse(string s, IFormatProvider provider)
        {
            try
            {
                var parseResult = DateTime.Parse(s, provider);
                return Some(parseResult);
            }
            catch
            {
                return None;
            }
        }
    }
}
