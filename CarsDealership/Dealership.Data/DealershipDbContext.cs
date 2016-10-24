using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Data
{
    public class DealershipDbContext : DbContext
    {
        public DealershipDbContext()
            : base("Dealership")
        {

        }

        public virtual IDbSet<ICar> Cars { get; set; }

        public virtual IDbSet<IDealer> Dealers { get; set; }

        public virtual IDbSet<IManufacturer> Manufacturers { get; set; }
    }
}
