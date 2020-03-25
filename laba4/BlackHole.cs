using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universe
{
    public class BlackHole: AstronomicalObject 
    {
        const double LightSpeed = 3;
        const double G = 3;

        public BlackHole()
        {

        }

        public BlackHole(string name, Point position, double mass): base(name, position, mass, GetRadius(mass))
        {

        }

        public static double GetRadius(double mass)
        {
            return 2 * G * mass / (LightSpeed * LightSpeed);
        }

        public static double GetMass(double radius)
        {
            return radius * LightSpeed * LightSpeed / (2 * G);
        }
    }
}
