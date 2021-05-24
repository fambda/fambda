using System.Diagnostics.Contracts;

namespace Fambda.Extensions
{
    /// <summary>
    /// String extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified not null string is empty.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns>true if the specified string is not null and empty; otherwise, false.</returns>
        [Pure]
        public static bool IsEmpty(this string str)
            => str != null && str.Length == 0;

        /// <summary>
        /// Indicates whether the specified not null string consists only of white-space characters.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns>true if the specified string is not null and consists exclusively of white-space characters; otherwise, false.</returns>
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

        /// <summary>
        /// Indicates whether the specified not null, not empty string has leading spaces.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns>true if the specified string is not null, not empty and has leading spaces; otherwise, false.</returns>
        [Pure]
        public static bool HasLeadingSpace(this string str)
            => str != null && str.Length > 0 && char.IsWhiteSpace(str, 0);

        /// <summary>
        /// Indicates whether the specified not null, not empty string has trailing spaces.
        /// </summary>
        /// <param name="str">The string to test.</param>
        /// <returns>true if the specified string is not null, not empty and has trailing spaces; otherwise, false.</returns>
        [Pure]
        public static bool HasTrailingSpace(this string str)
            => str != null && str.Length > 0 && char.IsWhiteSpace(str, str.Length - 1);

    }
}
