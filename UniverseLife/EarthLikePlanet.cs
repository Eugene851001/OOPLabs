using System;
using Universe;
using System.Collections.Generic;


namespace UniverseLife
{
    public class EarthLikePlanet: Planet
    {
        private int population;
        public int Population
        {
            get
            {
                return population;
            }
            set
            {
                population = value;
            }
        }

        public string TestString { get; set; }

        public EarthLikePlanet(int population, string name, Point position, 
            double mass, double size, Star star): base(name, position, mass, size, star)
        {
            TestString = "test";
            this.population = population;
        }

        public EarthLikePlanet(): base()
        {
            TestString = "Test";
            population = 0;
        }
    }
}
