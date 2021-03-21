using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    [Serializable]
    public class GuardException : Exception
    {
        public GuardException(string message) : base(message) { }

        protected GuardException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
