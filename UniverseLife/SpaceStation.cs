using System;
using System.Collections.Generic;
using System.Text;
using Universe;

namespace UniverseLife
{
    public class SpaceStation: Satellite
    {
        public string Country { get; set; }

        public SpaceStation(string country, string name, Point pos, double mass, 
            double size, Planet planet): base(name, pos, mass, size, planet)
        {
            Country = country;
        }

        public SpaceStation()
        {
            Country = "";
        }
    }
}
