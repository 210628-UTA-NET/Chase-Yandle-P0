using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Game
    {
        public Game()
        {
            GamesOnSystems = new HashSet<GamesOnSystem>();
        }

        public string Name { get; set; }
        public int? AgeRating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<GamesOnSystem> GamesOnSystems { get; set; }
    }
}
