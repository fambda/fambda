using System;
using System.Reflection;

namespace Fambda.Helpers
{
    internal static class EqComponent
    {
        internal static EqResult ApplyGetHashCodeOnEqualObjects<T>(T objA, T objB)
        {
            return GetEqResult("GetHashCode", () =>
            {
                if (objA.GetHashCode() != objB.GetHashCode())
                {
                    return EqResult.Failure("GetHashCode of equal objects returned different values.");
                }
                return EqResult.Success();
            });
        }

        internal static EqResult ApplyEqualsToNonNullOfOtherType<T>(T obj)
        {
            return GetEqResult("Equals", () =>
            {
                if (obj.Equals(new object()))
                {
                    return EqResult.Failure("Equals returned 'true' on comparing with object of a different type.");
                }
                return EqResult.Success();
            });
        }

        internal static EqResult ApplyEqualsToNull<T>(T? obj)
        {
            if (typeof(T).IsClass)
            {
                return ApplyEquals<T>(obj, default(T), false);
            }
            return EqResult.Success();
        }

        internal static EqResult ApplyEqualsOfTToNull<T>(T? obj)
        {
            return ApplyEqualsToNull<T>(obj);
        }

        internal static EqResult ApplyEquals<T>(T? objA, T? objB, bool expectedEqualObjects)
        {
            return GetEqResult("Equals", () =>
            {
                var actualEqual = object.Equals(objA, objB);
                if (actualEqual != expectedEqualObjects)
                {
                    var message = string.Format("Equals returned '{0}' on expected {1}equal objects.",
                                            actualEqual.ToString().ToLower(),
                                            expectedEqualObjects ? "" : "non-");
                    return EqResult.Failure(message);
                }
                return EqResult.Success();
            });
        }

        internal static EqResult ApplyEqualsOfT<T>(T? objA, T objB, bool expectedEqualObjects)
        {
            if (objA is IEquatable<T>)
            {
                return ApplyEqualsOfTOnIEquatable<T>((IEquatable<T>)objA, objB, expectedEqualObjects);
            }
            return EqResult.Success();
        }

        internal static EqResult ApplyEqualsOfTOnIEquatable<T>(IEquatable<T> objA, T objB, bool expectedEqualObjects)
        {
            return GetEqResult("Typed Equals", () =>
            {
                var actualEqual = objA.Equals(objB);
                if (actualEqual != expectedEqualObjects)
                {
                    var message = string.Format("Typed Equals returned '{0}' on expected {1}equal objects.",
                                            actualEqual.ToString().ToLower(),
                                            expectedEqualObjects ? "" : "non-");
                    return EqResult.Failure(message);
                }
                return EqResult.Success();
            });
        }

        internal static EqResult ApplyOperatorEqualityToNull<T>(T? obj)
        {
            if (typeof(T).IsClass)
            {
                return ApplyOperatorEquality<T>(obj, default(T), false);
            }
            return EqResult.Success();
        }

        internal static EqResult ApplyOperatorEquality<T>(T? objA, T? objB, bool expectedEqualObjects)
        {
            var operatorEquality = EqReflector.GetOperatorEquality<T>();
            if (operatorEquality == null)
            {
                return EqResult.Failure("Type does not override equality operator.");
            }
            return ApplyOperatorEquality<T>(objA, objB, expectedEqualObjects, operatorEquality);
        }

        internal static EqResult ApplyOperatorEquality<T>(T? objA, T? objB, bool expectedEqualObjects, MethodInfo operatorEquality)
        {
            return GetEqResult("Operator ==", () =>
            {
                var actualEqual = (bool)operatorEquality.Invoke(null, new object[] { objA, objB });
                if (actualEqual != expectedEqualObjects)
                {
                    var message = string.Format("Equality operator returned '{0}' on expected {1}equal objects.",
                                            actualEqual.ToString().ToLower(),
                                            expectedEqualObjects ? "" : "non-");
                    return EqResult.Failure(message);
                }
                return EqResult.Success();
            });
        }

        internal static EqResult ApplyOperatorInequalityToNull<T>(T obj)
        {
            if (typeof(T).IsClass)
            {
                return ApplyOperatorInequality<T>(obj, default(T), true);
            }
            return EqResult.Success();
        }

        internal static EqResult ApplyOperatorInequality<T>(T objA, T? objB, bool expectedUnequalObjects)
        {
            var operatorInequality = EqReflector.GetOperatorInequality<T>();
            if (operatorInequality == null)
            {
                return EqResult.Failure("Type does not override inequality operator.");
            }
            return ApplyOperatorInequality<T>(objA, objB, expectedUnequalObjects, operatorInequality);
        }

        internal static EqResult ApplyOperatorInequality<T>(T objA, T? objB, bool expectedUnequalObjects, MethodInfo operatorInequality)
        {
            return GetEqResult("Operator !=", () =>
            {
                var actualUnequal = (bool)operatorInequality.Invoke(null, new object[] { objA, objB });
                if (actualUnequal != expectedUnequalObjects)
                {
                    var message = string.Format("Inequality operator returned '{0}' on expected {1}equal objects.",
                                            actualUnequal.ToString().ToLower(),
                                            expectedUnequalObjects ? "non-" : "");
                    return EqResult.Failure(message);
                }
                return EqResult.Success();
            });
        }

        private static EqResult GetEqResult(string funcName, Func<EqResult> func)
        {
            EqResult result;

            try
            {
                result = func();
            }
            catch (Exception exception)
            {
                var message = $"{funcName} threw {exception.GetType().Name}: {exception.Message}";
                result = EqResult.Failure(message);
            }

            return result;
        }
    }
}
