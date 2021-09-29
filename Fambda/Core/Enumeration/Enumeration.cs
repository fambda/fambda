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
        /// <summary>
        /// String-based <see cref="Enumeration"/> key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="key"></param>
        protected Enumeration(string key)
        {
            Guard.On(key, Error.EnumerationKeyMustNotBeNull()).AgainstNull();
            Guard.On(key, Error.EnumerationKeyMustNotBeEmpty()).AgainstEmpty();
            Guard.On(key, Error.EnumerationKeyMustNotBeWhiteSpace()).AgainstWhiteSpace();
            Guard.On(key, Error.EnumerationKeyMustNotContainLeadingSpace()).AgainstLeadingSpace();
            Guard.On(key, Error.EnumerationKeyMustNotContainTrailingSpace()).AgainstTrailingSpace();

            Key = key;
        }

        /// <summary>
        /// Equality components.
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Key;
        }

        /// <summary>
        /// Returns <see cref="IEnumerable{T}"/> on specified <see cref="Enumeration"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> List<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        /// <summary>
        /// Returns the <see cref="Option{T}"/> lookup result by key on specified <see cref="Enumeration"/>.
        /// </summary>
        /// <returns><see cref="OptionSome{T}"/> if key lookup was successfull; otherwise, <see cref="OptionNone"/>.</returns>
        public static Option<T> Get<T>(string key) where T : Enumeration
        {
            return List<T>().SingleOrDefault(s => string.Equals(s.Key, key, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="Enumeration"/> key.
        /// </summary>
        /// <returns>A string that represents the current <see cref="Enumeration"/> key.</returns>
        public override string ToString() => Key;
    }
}
