using System.Collections.Generic;
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

        //public ICollection<DtoCarReport> GetCarReport()
        //{
        //    var ctx = new CarsFactoryDbContext();

        //    using (ctx)
        //    {
        //        var carReports = ctx.Cars.Select(t => new DtoCarReport
        //        {
        //            Id = t.Id,
        //            Name = t.Name,
        //            Owner = t.Owner.FirstName + " " + t.Owner.LastName,
        //            Coach = t.Coach.FirstName + " " + t.Coach.LastName,
        //            NumberOfPlayers = t.Players.Count,
        //            NumbersOfMatches = t.Matches.Count
        //        }).ToList();

        //        return carReports;
        //    }
        //}
    }
}
