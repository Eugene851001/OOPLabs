using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universe
{
    public class VariableStar: Star
    {
        public double AverageLuminosity;
        public double DeltaLuminosity;
        
        public VariableStar(string name, Point position, 
            double mass, double size, int temperature, double luminosity, double deltaLuminasity):
            base(name, position, mass, size, temperature)
        {

        }

        public VariableStar(): base()
        {
            AverageLuminosity = DeltaLuminosity = 0;
        }
    }
}
