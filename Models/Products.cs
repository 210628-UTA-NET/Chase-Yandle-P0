using System;
using System.Collections.Generic;

namespace Models
{
    public class Games
    {
        public string gName { get; set; }
        public float gMSRP { get; set; }
        public string gSystem { get; set; }
        public int gAgeRating { get; set; }
        public DateTime gReleaseDate { get; set; }
    }
    public class Systems
    {
        public string sName { get; set; }
        public DateTime sReleaseDate { get; set; }
        public float sMSRP { get; set; }
        public List<string> _availSystems = new List<string>()
        {
            //Will move to BL/DL
            //Will change to call the list of systems from the product JSON file
            //When a system is added to the list of available products it will also be added to this list
            "Playstation 3",
            "Playstation 4",
            "Playstation 5",
            "Xbox 360",
            "Xbox One",
            "Xbox Series X",
            "Nintendo Switch",
            "Nintendo 3DS",
            "Nintendo Wii U"
        };

    }
}
