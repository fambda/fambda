using System.Diagnostics.Contracts;
using static Fambda.F;

namespace Fambda
{
    /// <summary>
    /// Represents BoolType type.
    /// </summary>
    public static class BoolType
    {
        /// <summary>
        /// Converts the string representation of a logical value into <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="value">A string containing the value to convert.</param>
        /// <returns><see cref="Option{T}"/> with <see cref="OptionSome{T}"/> if <paramref name="value" /> is equivalent to <see cref="bool.TrueString"/>; otherwise, <see cref="OptionNone"/>.</returns>
        [Pure]
        public static Option<bool> Parse(string value)
        {
            if (bool.TryParse(value, out var parseResult))
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
