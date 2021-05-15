using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    [Serializable]
    public class EnumerationKeyMustNotBeEmptyException : GuardException
    {
        public EnumerationKeyMustNotBeEmptyException() : base(ExceptionMessage.EnumerationKeyMustNotBeEmpty) { }

        protected EnumerationKeyMustNotBeEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
