using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    [Serializable]
    public class EnumerationKeyMustNotContainLeadingSpaceException : GuardException
    {
        public EnumerationKeyMustNotContainLeadingSpaceException() : base(ExceptionMessage.EnumerationKeyMustNotContainLeadingSpace) { }

        protected EnumerationKeyMustNotContainLeadingSpaceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
