using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Abstract definition of an error. 
    /// </summary>
    public abstract record Error
    {
        /// <summary>
        /// Code that indicates what type of error occurred.
        /// </summary>
        public string Code { get; init; }

        /// <summary>
        /// Message that describes the error.
        /// </summary>
        public string? Message { get; init; }

        /// <summary>
        /// The exception
        /// </summary>
        protected Exception? _exception;

        /// <summary>
        /// If error contains an exception, then this will return `Some` exception, otherwise `None`
        /// </summary>
        [Pure]
        public Option<Exception> Exception =>
            _exception is not null
                ? F.Some(_exception)
                : F.None;


        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="Code">The code.</param>
        /// <param name="Message">The message.</param>
        protected Error(string Code, string? Message = null)
        {
            this.Code = Code;
            this.Message = Message;
        }

        /// <summary>
        /// Creates <see cref="Error"/> discriminated-union of <see cref="Unexpected"/> type.
        /// </summary>
        public static Error New(Exception exception)
            => new Unexpected(exception);

        /// <summary>
        /// Creates <see cref="Error"/> discriminated-union of <see cref="Expected"/> type.
        /// </summary>
        public static Error New(string code)
            => new Expected(code);

        /// <summary>
        /// Creates <see cref="Error"/> discriminated-union of <see cref="Expected"/> type.
        /// </summary>
        public static Error New(string code, string message)
            => new Expected(code, message);


        /// <summary>
        /// Represents unexpected exceptional technical error.
        /// </summary>
        /// <seealso cref="Fambda.Error" />
        /// <example>
        ///  An exception raised when database is down, or StackOverflowException, or OutOfMemoryException ... 
        /// </example>
        public record Unexpected : Error
        {
            /// <summary/>
            public Unexpected(Exception Exception) : base($"{Exception.HResult}", Exception.Message) =>
                _exception = Exception;

            /// <summary/>
            public Unexpected(Exception Exception, string Code, string? Message = null) : base(Code, Message) =>
                _exception = Exception;
        }

        /// <summary>
        /// Represents an expected error.
        /// </summary>
        /// <seealso cref="Fambda.Error" />
        /// <example>
        ///  Consider a wrong value in one of the inputs (json, query parameters, etc.)
        ///  such as required value is missing or some string is too short.
        /// </example>
        public record Expected : Error
        {
            /// <summary/>
            public Expected(string Code, string? Message = null) : base(Code, Message) { }
        }
    }
}
