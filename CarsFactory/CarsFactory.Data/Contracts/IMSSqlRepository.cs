using CarsFactory.Models;
using System.Collections.Generic;

namespace CarsFactory.Data.Contracts
{
    public interface IMSSqlRepository
    {
        void ExtractTowns(ICollection<Town> towns, ICarsFactoryDbContext ctx);

        void ExtractPlatforms(ICollection<Platform> platforms, ICarsFactoryDbContext ctx);

        void ExtractEngines(ICollection<Engine> engines, ICarsFactoryDbContext ctx);

        void ExtractModels(ICollection<Model> models, ICarsFactoryDbContext ctx);

        void ExtractCars(ICollection<Car> cars, ICarsFactoryDbContext ctx);
    }
}
