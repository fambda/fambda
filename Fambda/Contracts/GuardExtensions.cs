using System;
using System.Reflection;
using Fambda.Extensions;

namespace Fambda.Contracts
{
    internal static class GuardAgainst
    {
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

        internal static Guard<string> AgainstEmpty(this Guard<string> guard)
        {
            if (guard.Value != null && guard.Value.IsEmpty())
            {
                throw guard.GuardException;
            }

            return guard;
        }

        internal static Guard<string> AgainstWhiteSpace(this Guard<string> guard)
        {
            if (guard.Value != null && guard.Value.IsWhiteSpace())
            {
                throw guard.GuardException;
            }

            return guard;
        }

        internal static Guard<string> AgainstLeadingSpace(this Guard<string> guard)
        {
            if (guard.Value != null && guard.Value.HasLeadingSpace())
            {
                throw guard.GuardException;
            }

            return guard;
        }

        internal static Guard<string> AgainstTrailingSpace(this Guard<string> guard)
        {
            if (guard.Value != null && guard.Value.HasTrailingSpace())
            {
                throw guard.GuardException;
            }

            return guard;
        }
    }
}
