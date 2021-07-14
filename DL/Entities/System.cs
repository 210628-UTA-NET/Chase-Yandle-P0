using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class System
    {
        public System()
        {
            GamesOnSystems = new HashSet<GamesOnSystem>();
            Products = new HashSet<Product>();
            SystemsOwneds = new HashSet<SystemsOwned>();
        }

        public string Name { get; set; }
        public decimal? Msrp { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public virtual ICollection<GamesOnSystem> GamesOnSystems { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SystemsOwned> SystemsOwneds { get; set; }
    }
}
