using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    [Serializable]
    public class ExceptionalExceptionMustNotBeNullException : GuardException
    {
        public ExceptionalExceptionMustNotBeNullException() : base(ExceptionMessage.ExceptionalExceptionMustNotBeNull) { }

        protected ExceptionalExceptionMustNotBeNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
