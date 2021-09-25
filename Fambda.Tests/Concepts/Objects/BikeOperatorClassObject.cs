namespace Fambda.Tests.Concepts.Objects
{
    public class BikeOperatorClassObject
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public BikeOperatorClassObject(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public string GetBrandModel()
            => string.Format("{0} {1}", Brand, Model);

        public static bool operator ==(BikeOperatorClassObject lhs, BikeOperatorClassObject rhs)
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

        public static bool operator !=(BikeOperatorClassObject lhs, BikeOperatorClassObject rhs)
            => !(lhs == rhs);
    }
}
