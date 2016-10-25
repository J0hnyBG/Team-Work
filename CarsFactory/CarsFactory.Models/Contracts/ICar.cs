using Cars.Models.Enums;
using System;

namespace Cars.Models.Contracts
{
    public interface ICar
    {
        int Id { get; set; }

        DateTime Year { get; }

        decimal Price { get; }

        int DealerId { get; }

        IDealer Dealer { get; }

        int ManufacturerId { get; }

        IManufacturer Manufacturer { get; }

        int ModelId { get; set; }

        IModel Model { get; set; }

        int EngineId { get; set; }

        IEngine Engine { get; set; }

        int PlatformId { get; set; }

        IPlatform Platform { get; set; }
    }
}
