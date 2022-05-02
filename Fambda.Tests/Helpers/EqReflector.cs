using System.Reflection;

namespace Fambda.Helpers
{
    internal static class EqReflector
    {
        public static MethodInfo? GetOperatorEquality<T>()
        {
            return GetOperator<T>("op_Equality");
        }

        public static MethodInfo? GetOperatorInequality<T>()
        {
            return GetOperator<T>("op_Inequality");
        }

        private static MethodInfo? GetOperator<T>(string methodName)
        {
            var bindingFlags = BindingFlags.Static | BindingFlags.Public;
            var result = typeof(T).GetMethod(methodName, bindingFlags);

            return result;
        }
    }
}
