namespace Fambda.Helpers
{
    internal struct EqResult
    {
        public bool IsSuccess { get; private set; }
        public string FailureMessage { get; private set; }

        private EqResult(bool isSuccess, string failureMessage)
        {
            IsSuccess = isSuccess;
            FailureMessage = failureMessage;
        }

        public static EqResult Success() => new(true, string.Empty);

        public static EqResult Failure(string message) => new(false, message);
    }
}
