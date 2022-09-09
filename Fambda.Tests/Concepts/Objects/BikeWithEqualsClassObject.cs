namespace Fambda.Concepts.Objects
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class BikeWithEqualsClassObject
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public BikeWithEqualsClassObject(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

#pragma warning disable CS0659
        public override bool Equals(object? obj)
#pragma warning restore CS0659
        {
            return Brand == ((BikeWithEqualsClassObject)obj!).Brand &&
                   Model == ((BikeWithEqualsClassObject)obj!).Model;
        }
    }
}
