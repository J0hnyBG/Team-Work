using CarsFactory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace CarsFactory.Data
{
    /// <summary>
    /// Microsoft's SQL repository
    /// </summary>
    public class MSSqlRepository
    {
        public async Task CreateDb()
        {
            using (var ctx = new CarsFactoryDbContext())
            {
                //await ctx.Cars.ToListAsync();
                await ctx.SaveChangesAsync();
            }
        }

        // TODO: Create DtoObjects

        public void ExtractTownsFromZip(ICollection<Town> towns)
        {
            try
            {
                var ctx = new CarsFactoryDbContext();

                using (ctx)
                {
                    foreach (var town in towns)
                    {
                        if (!ctx.Towns.Any(t => t.Name == town.Name))
                        {
                            ctx.Towns.Add(town);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExtractPlatformsFromZip(ICollection<Platform> platforms)
        {
            try
            {
                var ctx = new CarsFactoryDbContext();

                using (ctx)
                {
                    foreach (var platform in platforms)
                    {
                        if (!ctx.Platforms.Any(p => p.Id == platform.Id))
                        {
                            ctx.Platforms.Add(platform);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExtractEnginesFromZip(ICollection<Engine> engines)
        {
            try
            {
                var ctx = new CarsFactoryDbContext();

                using (ctx)
                {
                    foreach (var engine in engines)
                    {
                        if (!ctx.Engines.Any(e => e.Id == engine.Id))
                        {
                            ctx.Engines.Add(engine);
                        }
                    }

                    ctx.SaveChanges();
                }

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
