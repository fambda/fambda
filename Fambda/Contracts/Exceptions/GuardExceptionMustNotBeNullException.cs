using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    /// <summary>
    /// The exception that is thrown when Guard Exception is null.
    /// </summary>
    [Serializable]
    public class GuardExceptionMustNotBeNullException : GuardException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuardExceptionMustNotBeNullException"/> class.
        /// </summary>
        public GuardExceptionMustNotBeNullException() : base(ExceptionMessage.GuardExceptionMustNotBeNull) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardExceptionMustNotBeNullException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or System.Exception.HResult is zero (0).</exception>
        protected GuardExceptionMustNotBeNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
