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

        public void ExtractTownsFromZip(List<Town> towns)
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
    }
}
