namespace Fambda
{
    public static partial class F
    {
        public static Option<T> Some<T>(T value) => new OptionSome<T>(value);

        public static OptionNone None => OptionNone.Default;
    }
}
