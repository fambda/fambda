using System.Collections.Generic;

namespace Fambda.Helpers
{
    internal class Equable
    {
        internal EqResults Null<T>(T obj)
        {
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
