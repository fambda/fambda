using System.Collections.Generic;
using Fambda.Contracts;

namespace Fambda.Tests.Helpers
{
    internal class EqChecker
    {
        internal EqResults Null<T>(T obj)
        {
            Guard.On(new object[] { obj }, Error.EachParamMustNotBeNull()).EachAgainstNull();

            var eqResults = EqResults.Create(new List<EqResult>()
            {
                EqComponent.ApplyEqualsToNull<T>(obj),
                EqComponent.ApplyEqualsOfTToNull<T>(obj),
                EqComponent.ApplyOperatorEqualityToNull<T>(obj),
                EqComponent.ApplyOperatorInequalityToNull<T>(obj)
            });

            return eqResults;
        }

        internal EqResults Equal<T>(T objA, T objB)
        {
            Guard.On(new object[] { objA, objB }, Error.EachParamMustNotBeNull()).EachAgainstNull();

            var eqResults = EqResults.Create(new List<EqResult>()
            {
                EqComponent.ApplyGetHashCodeOnEqualObjects<T>(objA, objB),
                EqComponent.ApplyEquals<T>(objA, objB, true),
                EqComponent.ApplyEqualsOfT<T>(objA, objB, true),
                EqComponent.ApplyOperatorEquality<T>(objA, objB, true),
                EqComponent.ApplyOperatorInequality<T>(objA, objB, false)
            });

            return eqResults;
        }

        internal EqResults Unequal<T>(T objA, T objB)
        {
            Guard.On(new object[] { objA, objB }, Error.EachParamMustNotBeNull()).EachAgainstNull();

            var eqResults = EqResults.Create(new List<EqResult>()
            {
                EqComponent.ApplyEqualsToNonNullOfOtherType<T>(objA),
                EqComponent.ApplyEquals<T>(objA, objB, false),
                EqComponent.ApplyEqualsOfT<T>(objA, objB, false),
                EqComponent.ApplyOperatorEquality<T>(objA, objB, false),
                EqComponent.ApplyOperatorInequality<T>(objA, objB, true)
            });

            return eqResults;
        }
    }
}
