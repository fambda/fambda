using System.Runtime.Serialization;

namespace Fambda.DataTypes
{
    [Serializable]
    public class AnotherException : Exception
    {
        public AnotherException() : base() { }

        public AnotherException(string message) : base(message) { }

        protected AnotherException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
