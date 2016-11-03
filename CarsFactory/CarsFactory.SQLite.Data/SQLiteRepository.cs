using System.Collections.Generic;

using CarsFactory.DtoModels;
using System.Linq;

namespace CarsFactory.SQLite.Data
{
    public class SQLiteRepository
    {
        public IList<TownInfoDto> GetTownsData()
        {
            var ctx = new TownInfoEntities();

            var towns = ctx.TownInfoes.Select(t => new TownInfoDto()
            {
                Name = t.Name
            }).ToList();

            return towns;
        }
    }
}
