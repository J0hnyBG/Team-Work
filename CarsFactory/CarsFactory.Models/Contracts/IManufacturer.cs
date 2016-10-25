using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models.Contracts
{
    public interface IManufacturer
    {
        int Id { get; }

        string Name { get; }

        ICollection<ICar> Cars { get; }
    }
}
