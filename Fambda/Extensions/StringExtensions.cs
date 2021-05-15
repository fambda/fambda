using System.Diagnostics.Contracts;

namespace Fambda.Extensions
{
    public static class StringExtensions
    {
        [Pure]
        public static bool IsEmpty(this string str)
            => str != null && str.Length == 0;

        [Pure]
        public static bool IsWhiteSpace(this string str)
        {
            if (str != null)
            {
                for (var i = 0; i < str.Length; i++)
                {
                    if (!char.IsWhiteSpace(str[i])) return false;
                }
                return true;
            }
            return false;
        }

        [Pure]
        public static bool HasLeadingSpace(this string str)
            => str != null && str.Length > 0 && char.IsWhiteSpace(str, 0);

        [Pure]
        public static bool HasTrailingSpace(this string str)
            => str != null && str.Length > 0 && char.IsWhiteSpace(str, str.Length - 1);

    }
}
