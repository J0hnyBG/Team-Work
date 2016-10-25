using Cars.Models.Enums;

namespace Cars.Models.Contracts
{
    public interface ICar
    {
        int Id { get; set; }

        string Model { get; }

        ushort Year { get; }

        FuelType Fuel { get; }

        decimal Price { get; }

        int DealerId { get; }

        IDealer Dealer { get; }

        int ManufacturerId { get; }

        IManufacturer Manufacturer { get; }

        IPlatform CarPlatform { get; }
    }
}
