using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Universe
{
    public class Planet : AstronomicalObject, IComplexObj, IParticle
    {
        public float albedo;
        Star MainStar;
        public AstronomicalObject MainObject
        {
            get
            {
                return MainStar;
            }
            set
            {
                MainStar = value as Star;
            }
        }
        private List<Satellite> satellites;

        public Planet() : base()
        {
            satellites = new List<Satellite>();
            MainStar = new Star();
            AddToParent();
        }
        public Planet(string name, Point pos, double mass,
            double size, Star star, float albedo = 0.5f) : base(name, pos, mass, size)
        {
            satellites = new List<Satellite>();
            MainStar = star;
            this.albedo = albedo;
            AddToParent();
        }

        public void Add(Object satellite)
        {
            satellites.Add((Satellite)satellite);
        }

        [System.Runtime.Serialization.OnSerializing()]
        public void ClearList()
        {
            satellites.Clear();
        }

        public void AddToParent()
        {
            MainStar.Add(this);
        }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= satellites.Count)
                    throw new IndexOutOfRangeException();
                return satellites[index];
            }
        }

        public int Count
        {
            get
            {
                return satellites.Count;
            }
        }

        public void RemoveFromParent()
        {
            MainStar.Remove(this);
        }

        public bool Remove(object obj)
        {
            return satellites.Remove((Satellite)obj);
        }

        ~Planet()
        {
            RemoveFromParent();
        }
    }
}
