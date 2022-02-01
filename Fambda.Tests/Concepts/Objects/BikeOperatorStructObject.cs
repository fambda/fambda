namespace Fambda.Concepts.Objects
{
    public struct BikeOperatorStructObject
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public BikeOperatorStructObject(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public string GetBrandModel()
            => string.Format("{0} {1}", Brand, Model);

        public static bool operator ==(BikeOperatorStructObject lhs, BikeOperatorStructObject rhs)
        {
            return lhs.Brand == rhs.Brand && lhs.Model == rhs.Model;
        }

        public static bool operator !=(BikeOperatorStructObject lhs, BikeOperatorStructObject rhs)
                    => !(lhs == rhs);
    }
}
