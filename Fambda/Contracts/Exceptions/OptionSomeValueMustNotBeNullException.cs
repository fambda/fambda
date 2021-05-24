using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    /// <summary>
    /// The exception that is thrown when OptionSome Value is null.
    /// </summary>
    [Serializable]
    public class OptionSomeValueMustNotBeNullException : GuardException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionSomeValueMustNotBeNullException"/> class.
        /// </summary>
        public OptionSomeValueMustNotBeNullException() : base(ExceptionMessage.OptionSomeValueMustNotBeNull) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionSomeValueMustNotBeNullException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or System.Exception.HResult is zero (0).</exception>
        protected OptionSomeValueMustNotBeNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
