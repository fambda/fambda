using System;
using System.Runtime.Serialization;

namespace Fambda.Tests.DataTypes
{
    [Serializable]
    public class SomeException : Exception
    {
        public SomeException() : base() { }

        protected SomeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
