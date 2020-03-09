using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;

namespace Universe
{
    public class Satellite : AstronomicalObject, IParticle
    {
        Planet MainPlanet;
        public AstronomicalObject MainObject
        {
            get
            {
                return MainPlanet;
            }
            set
            {
                MainPlanet = (Planet)value;
            }
        }
        public Satellite(string name, Point pos, double mass, double size,
            Planet planet) : base(name, pos, mass, size)
        {
            MainPlanet = planet;
            AddToParent();
        }

        public Satellite(): base()
        {
            
        }

        public void AddToParent()
        {
            MainPlanet.Add(this);
        }

        public void RemoveFromParent()
        {
            MainPlanet.Remove(this);
        }

        ~Satellite()
        {
            RemoveFromParent();
        }

        public override void Draw(Graphics g, ViewInfo info)
        {
           
        }

    }
}
