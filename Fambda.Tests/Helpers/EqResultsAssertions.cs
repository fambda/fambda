using System;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Fambda.Tests.Helpers
{
    internal class EqResultsAssertions : ReferenceTypeAssertions<EqResults, EqResultsAssertions>
    {
        public EqResultsAssertions(EqResults instance)
        {
            Subject = instance;
        }

        protected override string Identifier => "EqResults";

        public AndConstraint<EqResultsAssertions> Pass(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.Success)
                .FailWith("Expected {context:EqResults} tests to pass, but found following failed tests:" + Environment.NewLine + string.Join(Environment.NewLine, Subject.Failures));

            return new AndConstraint<EqResultsAssertions>(this);
        }
    }
}
