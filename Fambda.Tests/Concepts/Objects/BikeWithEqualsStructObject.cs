namespace Fambda.Tests.Concepts.Objects
{
    public struct BikeWithEqualsStructObject
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

        public override bool Equals(object obj)
        {
            return Brand == ((BikeWithEqualsStructObject)obj).Brand &&
                   Model == ((BikeWithEqualsStructObject)obj).Model;
        }
    }
}
