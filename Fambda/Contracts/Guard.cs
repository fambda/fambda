namespace Fambda.Contracts
{
    public static class Guard
    {
        public static Guard<T> On<T>(T value, GuardException guardException)
        {
            return new Guard<T>(value, guardException);
        }
    }
}
