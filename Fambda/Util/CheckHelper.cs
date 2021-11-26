using System;
using System.Reflection;

namespace Fambda
{
    /// <summary>
    /// Helper class for various checks.
    /// </summary>
    internal static class CheckHelper<T>
    {
        private static readonly bool _isReferenceType;
        private static readonly bool _isNullable;

        static CheckHelper()
        {
            _isReferenceType = !typeof(T).GetTypeInfo().IsValueType;
            _isNullable = Nullable.GetUnderlyingType(typeof(T)) != null;
        }

        internal static bool IsNull(T value) =>
            (_isReferenceType && ReferenceEquals(value, null)) || (_isNullable && value.Equals(default));
    }
}
