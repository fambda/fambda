namespace Fambda.Concepts.Objects
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public struct BikeWithEqualsStructObject
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public BikeWithEqualsStructObject(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return Brand == ((BikeWithEqualsStructObject)obj).Brand &&
                   Model == ((BikeWithEqualsStructObject)obj).Model;
        }
    }
}
