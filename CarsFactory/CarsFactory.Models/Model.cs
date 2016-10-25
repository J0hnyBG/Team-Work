using Cars.Models.Contracts;
using System;

namespace Cars.Models
{
    public class Model : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Year { get; set; }
    }
}
