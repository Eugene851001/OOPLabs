using System;
using System.Collections.Generic;
using System.Text;
using Universe;

namespace UniverseGalaxy
{
    public class GalacticStar: Star, IParticle
    {
        Galaxy mainGalaxy;

        public AstronomicalObject MainObject
        {
            get
            {
                return mainGalaxy;
            }
            set
            {
                if (value is Galaxy)
                    mainGalaxy = (Galaxy)value;
                else
                    mainGalaxy = new Galaxy();
            }
        }

        public GalacticStar(string name, Point pos, double mass, double size, int temperature):
            base(name, pos, mass, size, temperature)
        {

        }

        public GalacticStar()
        {

        }

        public void AddToParent()
        {
            if(mainGalaxy != null)
                mainGalaxy.Add(this);
        }

        public void RemoveFromParent()
        {
            if (mainGalaxy != null)
                mainGalaxy.Remove(this);
        }
    }
}
