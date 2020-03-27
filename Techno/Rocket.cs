using System;
using Universe;

namespace Techno
{
    public class Rocket: Satellite
    {

        public int OilAmount { get;  set;}
        public Rocket(string name, Point pos, double mass, double size, Planet planet): 
            base(name, pos, mass, size, planet)
        {
            OilAmount = 100;
        }

        public Rocket() { }
    }
}
