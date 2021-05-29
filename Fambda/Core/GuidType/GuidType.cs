using System;
using System.Diagnostics.Contracts;
using static Fambda.F;

namespace Fambda
{
    /// <summary>
    /// Represents GuidType type.
    /// </summary>
    public static class GuidType
    {
        /// <summary>
        /// Converts the string representation of a <see cref="Guid"/> into <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns><see cref="Option{T}"/> with <see cref="OptionSome{T}"/> if <paramref name="input" /> was converted successfully; otherwise, <see cref="OptionNone"/></returns>
        [Pure]
        public static Option<Guid> Parse(string input)
        {
            if (Guid.TryParse(input, out var parseResult))
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