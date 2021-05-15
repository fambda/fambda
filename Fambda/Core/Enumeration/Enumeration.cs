using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Fambda.Contracts;

namespace Fambda.Core
{
    public abstract class Enumeration : IEquatable<Enumeration>
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

        [Pure]
        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }
            var sameType = GetType().Equals(obj.GetType());
            var sameKey = Key.Equals(otherValue.Key);
            return sameType && sameKey;
        }

        [Pure]
        public bool Equals(Enumeration other)
            => Key.Equals(other.Key);

        [Pure]
        public override int GetHashCode()
            => Key.GetHashCode();

        public override string ToString() => Key;
    }
}
