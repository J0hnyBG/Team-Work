using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using CarsFactory.Models;
using System;
using System.Threading.Tasks;

namespace CarsFactory.Data.Contracts
{
    public interface ICarsFactoryDbContext : IDisposable
    {
        IDbSet<Car> Cars { get; set; }

        IDbSet<Dealer> Dealers { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<Model> Models { get; set; }

        IDbSet<Platform> Platforms { get; set; }

        IDbSet<Engine> Engines { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<Town> Towns { get; set; }

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
