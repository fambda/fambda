using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    [Serializable]
    public class OptionValueMustNotBeNullException : GuardException
    {
        public OptionValueMustNotBeNullException() : base(ExceptionMessage.OptionValueMustNotBeNull) { }

        protected OptionValueMustNotBeNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
