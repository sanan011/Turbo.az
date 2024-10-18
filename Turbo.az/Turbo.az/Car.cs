namespace structrecord
{
    public class Car : IVehicle
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public decimal Price { get; private set; }
        public int Km { get; private set; }

        public Car(string brand, string model, decimal price, int km)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Km = km;
        }

        public string GetInfo() => $"{Brand} {Model}, Price: {Price}, Km: {Km}";

        public void Update(decimal price, int km)
        {
            Price = price;
            Km = km;
        }
    }
}
