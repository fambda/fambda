using System;

namespace Fambda.Concepts.Objects
{
    public class BikeWithEqualsOfTClassObject : IEquatable<BikeWithEqualsOfTClassObject>
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public BikeWithEqualsOfTClassObject(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public bool Equals(BikeWithEqualsOfTClassObject? other)
        {
            if (other is null) return false;
            return Brand == other.Brand &&
                   Model == other.Model;
        }
    }
}
