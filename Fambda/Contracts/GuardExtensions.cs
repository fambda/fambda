using Fambda.Extensions;

namespace Fambda.Contracts
{
    internal static class GuardAgainst
    {
        public static void AgainstNull<T>(this Guard<T> guard)
        {
            if (guard.Value == null)
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
