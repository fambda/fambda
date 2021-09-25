using System;
using System.Diagnostics.CodeAnalysis;

namespace Fambda.Tests.Concepts.Objects
{
    public struct BikeWithEqualsOfTStructObject : IEquatable<BikeWithEqualsOfTStructObject>
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public BikeWithEqualsOfTStructObject(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public bool Equals([AllowNull] BikeWithEqualsOfTStructObject other)
        {
            return Brand == other.Brand &&
                   Model == other.Model;
        }
    }
}
