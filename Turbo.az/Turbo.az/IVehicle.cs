namespace structrecord
{
    public interface IVehicle
    {
        string Brand { get; }
        string Model { get; }
        decimal Price { get; }
        int Km { get; }
        string GetInfo();
        void Update(decimal price, int km);
    }
}
