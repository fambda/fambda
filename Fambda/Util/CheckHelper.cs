using System.Diagnostics.Contracts;
using System.Reflection;

namespace Fambda
{
    /// <summary>
    /// Helper class for various checks.
    /// </summary>
    internal static class CheckHelper<T>
    {
        private static readonly bool _isReferenceType = !typeof(T).GetTypeInfo().IsValueType;
        private static readonly bool _isNullable = Nullable.GetUnderlyingType(typeof(T)) != null;

        [Pure]
        internal static bool IsNull(T value)
            => (_isReferenceType && ReferenceEquals(value, null)) || (_isNullable && value!.Equals(default));
    }
}
