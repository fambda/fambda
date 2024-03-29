namespace Fambda.Concepts.Objects
{
    public class BikeWithHashCodeClassObject
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public BikeWithHashCodeClassObject(string brand, string model, int year)
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
    }
}
