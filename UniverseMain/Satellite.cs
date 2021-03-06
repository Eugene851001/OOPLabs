﻿using System;
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
                if (value is Planet)
                    MainPlanet = (Planet)value;
                else
                    MainPlanet = new Planet();
            }
        }
        public Satellite(string name, Point pos, double mass, double size,
            Planet planet) : base(name, pos, mass, size)
        {
            MainPlanet = planet;
            MainPlanet.Name = "Unknown";
            AddToParent();
        }

        public Satellite(): base()
        {
            MainPlanet = new Planet();
            MainPlanet.Name = "Unknown";
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
    }
}
