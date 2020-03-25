using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universe
{
    interface IParticle
    {
        void AddToParent();
        void RemoveFromParent();

        AstronomicalObject MainObject
        {
            get;
            set;
        }
    }
}
