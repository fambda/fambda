using System;
using System.Reflection;
using Fambda.Extensions;

namespace Fambda.Contracts
{
    /// <summary>
    /// Guard against.
    /// </summary>
    public static class GuardAgainst
    {
        /// <summary>
        /// Against the null.
        /// </summary>
        public static void AgainstNull<T>(this Guard<T?> guard)
        {
            var isReferenceType = !typeof(T).GetTypeInfo().IsValueType;
            var isNullableType = Nullable.GetUnderlyingType(typeof(T)) != null;

            var isNull = (isReferenceType && ReferenceEquals(guard.Value, null)) || (isNullableType && guard.Value!.Equals(default));
            if (isNull)
            {
                throw guard.GuardException;
            }
        }

        /// <summary>
        /// Against the empty.
        /// </summary>
        public static Guard<string> AgainstEmpty(this Guard<string> guard)
        {
            if (guard.Value != null && guard.Value.IsEmpty())
            {
                throw guard.GuardException;
            }

            return guard;
        }

        /// <summary>
        /// Against the white space.
        /// </summary>
        public static Guard<string> AgainstWhiteSpace(this Guard<string> guard)
        {
            if (guard.Value != null && guard.Value.IsWhiteSpace())
            {
                throw guard.GuardException;
            }

            return guard;
        }

        /// <summary>
        /// Against the leading space.
        /// </summary>
        public static Guard<string> AgainstLeadingSpace(this Guard<string> guard)
        {
            if (guard.Value != null && guard.Value.HasLeadingSpace())
            {
                throw guard.GuardException;
            }

            return guard;
        }

        /// <summary>
        /// Against the trailing space.
        /// </summary>
        public static Guard<string> AgainstTrailingSpace(this Guard<string> guard)
        {
            if (guard.Value != null && guard.Value.HasTrailingSpace())
            {
                throw guard.GuardException;
            }

            return guard;
        }
    }
}
