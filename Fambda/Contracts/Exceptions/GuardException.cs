using System;
using System.Runtime.Serialization;

namespace Fambda.Contracts
{
    /// <summary>
    /// Represents guard errors.
    /// </summary>
    [Serializable]
    public class GuardException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuardException"/> class with a specified error..
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public GuardException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or System.Exception.HResult is zero (0).</exception>
        protected GuardException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
