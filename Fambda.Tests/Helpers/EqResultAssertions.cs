using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Fambda.Tests.Helpers
{
    internal class EqResultAssertions : ReferenceTypeAssertions<EqResult, EqResultAssertions>
    {
        public EqResultAssertions(EqResult instance)
        {
            Subject = instance;
        }

        protected override string Identifier => "EqResult";

        public AndConstraint<EqResultAssertions> BeSuccess(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.IsSuccess)
                .FailWith("Expected {context:EqResult} to be success.");

            return new AndConstraint<EqResultAssertions>(this);
        }

        public AndConstraint<EqResultAssertions> BeFailure(string failureMessage)
        {
            Execute.Assertion
                .ForCondition(!Subject.IsSuccess && Subject.FailureMessage == failureMessage)
                .FailWith("Expected {context:EqResult} to be failure with {0}{reason}, but found {1} with {0}{reason}.", failureMessage, Subject.IsSuccess ? "success" : "failure");

            return new AndConstraint<EqResultAssertions>(this);
        }
    }
}
