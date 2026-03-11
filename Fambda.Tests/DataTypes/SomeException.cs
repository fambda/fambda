namespace Fambda.DataTypes;

public class SomeException : Exception
{
    public SomeException() : base() { }

    public SomeException(string message) : base(message) { }
}
