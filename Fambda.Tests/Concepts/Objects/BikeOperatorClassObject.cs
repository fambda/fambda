namespace Fambda.Concepts.Objects
{
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class BikeOperatorClassObject
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
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
