using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    [Serializable]
    public class EnumerationKeyMustNotContainTrailingSpaceException : GuardException
    {
        public EnumerationKeyMustNotContainTrailingSpaceException() : base(ExceptionMessage.EnumerationKeyMustNotContainTrailingSpace) { }

        protected EnumerationKeyMustNotContainTrailingSpaceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
