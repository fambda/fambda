using System;

namespace Fambda.Concepts.Objects
{
    public class BikeClassObject : IEquatable<BikeClassObject>
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public BikeClassObject(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public string GetBrandModel()
            => string.Format("{0} {1}", Brand, Model);

        public override int GetHashCode()
        {
            return Brand.GetHashCode() + Model.GetHashCode();
        }

        public static bool operator ==(BikeClassObject lhs, BikeClassObject rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }
                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(BikeClassObject lhs, BikeClassObject rhs)
            => !(lhs == rhs);

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            return Brand == ((BikeClassObject)obj).Brand &&
                   Model == ((BikeClassObject)obj).Model;
        }


        public bool Equals(BikeClassObject? other)
            => other is not null && Brand == other.Brand && Model == other.Model;
    }
}
