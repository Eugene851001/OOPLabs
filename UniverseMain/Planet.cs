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
        public float Albedo { get; set; }
        Star MainStar { get; set; }
        public AstronomicalObject MainObject
        {
            get
            {
                return MainStar;
            }
            set
            {
                if (value is Star)
                    MainStar = value as Star;
                else
                    MainStar = new Star();
            }
        }
        protected List<AstronomicalObject> satellites;

        public Planet() : base()
        {
            satellites = new List<AstronomicalObject>();
            MainStar = new Star();
            MainStar.Name = "Unkmown";
            AddToParent();
        }
        public Planet(string name, Point pos, double mass,
            double size, Star star, float albedo = 0.5f) : base(name, pos, mass, size)
        {
            satellites = new List<AstronomicalObject>();
            MainStar = star;
            this.Albedo = albedo;
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
