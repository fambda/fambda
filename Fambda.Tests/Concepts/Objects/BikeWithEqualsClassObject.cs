namespace Fambda.Concepts.Objects
{
    public class BikeWithEqualsClassObject
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

        public override bool Equals(object? obj)
        {
            return Brand == ((BikeWithEqualsClassObject)obj).Brand &&
                   Model == ((BikeWithEqualsClassObject)obj).Model;
        }
    }
}
