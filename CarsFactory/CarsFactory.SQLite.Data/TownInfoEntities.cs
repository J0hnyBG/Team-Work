using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CarsFactory.SQLite.Data
{
    public partial class TownInfoEntities : DbContext
    {
        public TownInfoEntities()
            : base("name=TownInfoEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual IDbSet<TownInfo> TeamInfoes { get; set; }
    }
}
