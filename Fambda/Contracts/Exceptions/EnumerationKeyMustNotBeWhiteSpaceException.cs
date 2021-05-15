using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    [Serializable]
    public class EnumerationKeyMustNotBeWhiteSpaceException : GuardException
    {
        public EnumerationKeyMustNotBeWhiteSpaceException() : base(ExceptionMessage.EnumerationKeyMustNotBeWhiteSpace) { }

        protected EnumerationKeyMustNotBeWhiteSpaceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
