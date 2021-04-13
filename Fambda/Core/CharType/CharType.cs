using System.Diagnostics.Contracts;
using static Fambda.F;

namespace Fambda
{
    public static class CharType
    {
        /// <summary>
        /// Converts the string representation of a Unicode character into <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="s">A string containing a Unicode character to convert.</param>
        /// <returns><see cref="Option{T}"/> with <see cref="OptionSome{T}"/> if <paramref name="s" /> was converted successfully; otherwise, <see cref="OptionNone"/></returns>
        [Pure]
        public static Option<char> Parse(string s)
        {
            try
            {
                var parseResult = char.Parse(s);
                return Some(parseResult);
            }
            catch
            {
                return None;
            }
        }
    }
}
