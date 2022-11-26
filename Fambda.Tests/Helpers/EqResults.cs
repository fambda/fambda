namespace Fambda.Helpers
{
    internal struct EqResults
    {
        private readonly IEnumerable<EqResult> _eqResults;

        private EqResults(IEnumerable<EqResult> eqResults)
        {
            _eqResults = eqResults;
        }

        public static EqResults Create(IEnumerable<EqResult> eqResults) => new(eqResults);

        public bool Success => _eqResults.All(r => r.IsSuccess);

        public string[] Failures => _eqResults.Where(r => !r.IsSuccess).Select(r => r.FailureMessage).ToArray();
    }
}
