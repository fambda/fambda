using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fambda.Contracts;

namespace Fambda
{
    /// <summary>
    /// Represents Enumeration type.
    /// </summary>
    public abstract class Enumeration : Record<Enumeration>
    {
        public string Key { get; }

        protected Enumeration(string key)
        {
            Guard.On(key, Error.EnumerationKeyMustNotBeNull()).AgainstNull();
            Guard.On(key, Error.EnumerationKeyMustNotBeEmpty()).AgainstEmpty();
            Guard.On(key, Error.EnumerationKeyMustNotBeWhiteSpace()).AgainstWhiteSpace();
            Guard.On(key, Error.EnumerationKeyMustNotContainLeadingSpace()).AgainstLeadingSpace();
            Guard.On(key, Error.EnumerationKeyMustNotContainTrailingSpace()).AgainstTrailingSpace();

            Key = key;
        }

        public static IEnumerable<T> List<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public static Option<T> Get<T>(string key) where T : Enumeration
        {
            return List<T>().SingleOrDefault(s => string.Equals(s.Key, key, StringComparison.InvariantCultureIgnoreCase));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Key;
        }

        public override string ToString() => Key;
    }
}
