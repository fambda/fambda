using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    [Serializable]
    public class EnumerationKeyMustNotBeNullException : GuardException
    {
        public EnumerationKeyMustNotBeNullException() : base(ExceptionMessage.EnumerationKeyMustNotBeNull) { }

        protected EnumerationKeyMustNotBeNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
