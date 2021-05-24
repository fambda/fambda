using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    /// <summary>
    /// The exception that is thrown when Option.Match returns null.
    /// </summary>
    [Serializable]
    public class OptionMatchReturnMustNotBeNullException : GuardException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionMatchReturnMustNotBeNullException"/> class.
        /// </summary>
        public OptionMatchReturnMustNotBeNullException() : base(ExceptionMessage.OptionMatchReturnMustNotBeNull) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionMatchReturnMustNotBeNullException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or System.Exception.HResult is zero (0).</exception>
        protected OptionMatchReturnMustNotBeNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
