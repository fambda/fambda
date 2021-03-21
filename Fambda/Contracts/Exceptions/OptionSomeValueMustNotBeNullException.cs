using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    [Serializable]
    public class OptionSomeValueMustNotBeNullException : GuardException
    {
        public OptionSomeValueMustNotBeNullException() : base(ExceptionMessage.OptionSomeValueMustNotBeNull) { }

        protected OptionSomeValueMustNotBeNullException(SerializationInfo info, StreamingContext context): base(info, context) { }
    }
}
