using Cars.Models;
using Cars.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Data
{
    public class CarsFactoryDbContext : DbContext
    {
        public CarsFactoryDbContext()
            : base("CarsFactory")
        {

        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<Dealer> Dealers { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
    }
}
