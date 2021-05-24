using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using static Fambda.F;

namespace Fambda
{
    /// <summary>
    /// Represents DecimalType type.
    /// </summary>
    public static class DecimalType
    {
        /// <summary>
        /// Converts the string representation of a number into <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <returns><see cref="Option{T}"/> with <see cref="OptionSome{T}"/> if <paramref name="s" /> was converted successfully; otherwise, <see cref="OptionNone"/></returns>
        [Pure]
        public static Option<decimal> Parse(string s)
        {
            if (decimal.TryParse(s, out var parseResult))
            {
                return Some(parseResult);
            }
            else
            {
                return None;
            }
        }

        /// <summary>
        /// Converts the string representation of a number into <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="s">A string containing a number to convert. The string is interpreted using the style specified by <paramref name="style" />.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="System.Globalization.NumberStyles.Integer" />.</param>
        /// <returns><see cref="Option{T}"/> with <see cref="OptionSome{T}"/> if <paramref name="s" /> was converted successfully; otherwise, <see cref="OptionNone"/></returns>
        [Pure]
        public static Option<decimal> Parse(string s, NumberStyles style)
        {
            try
            {
                var parseResult = decimal.Parse(s, style);
                return Some(parseResult);
            }
            catch
            {
                return None;
            }
        }

        /// <summary>
        /// Converts the string representation of a number into <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
        /// <returns><see cref="Option{T}"/> with <see cref="OptionSome{T}"/> if <paramref name="s" /> was converted successfully; otherwise, <see cref="OptionNone"/></returns>
        [Pure]
        public static Option<decimal> Parse(string s, IFormatProvider provider)
        {
            try
            {
                var parseResult = decimal.Parse(s, provider);
                return Some(parseResult);
            }
            catch
            {
                return None;
            }
        }

        /// <summary>
        /// Converts the string representation of a number into <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="s">A string containing a number to convert. The string is interpreted using the style specified by <paramref name="style" />.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="System.Globalization.NumberStyles.Integer" />.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
        /// <returns><see cref="Option{T}"/> with <see cref="OptionSome{T}"/> if <paramref name="s" /> was converted successfully; otherwise, <see cref="OptionNone"/></returns>
        [Pure]
        public static Option<decimal> Parse(string s, NumberStyles style, IFormatProvider provider)
        {
            if (decimal.TryParse(s, style, provider, out var parseResult))
            {
                return Some(parseResult);
            }
            else
            {
                return None;
            }
        }
    }
}
