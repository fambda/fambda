namespace Fambda.Tests.Concepts.Objects
{
    public class BikeDumbClassObject
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public BikeDumbClassObject(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public string GetBrandModel()
            => string.Format("{0} {1}", Brand, Model);
    }
}
