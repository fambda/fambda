using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    [Serializable]
    public class GuardExceptionMustNotBeNullException : GuardException
    {
        public GuardExceptionMustNotBeNullException() : base(ExceptionMessage.GuardExceptionMustNotBeNull) { }

        protected GuardExceptionMustNotBeNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
