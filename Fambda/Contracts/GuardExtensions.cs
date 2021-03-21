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
    }
}
