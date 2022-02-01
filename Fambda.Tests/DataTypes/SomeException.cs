using System;
using System.Runtime.Serialization;

namespace Fambda.DataTypes
{
    [Serializable]
    public class SomeException : Exception
    {
        public SomeException() : base() { }

        public SomeException(string message) : base(message) { }

        protected SomeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
