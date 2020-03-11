using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Universe
{
    //главная последовательность
    public class Star : AstronomicalObject, IComplexObj
    {
        public int Temperature;
        public int PlanetsAmount
        {
            get
            {
                return planets.Count;
            }
        }
        private List<Planet> planets;

        public void CleanList()
        {
            planets.Clear();
        }

        public Star() : base()
        {
            planets = new List<Planet>();
            Temperature = 0;
        }

        public void Add(object planet)
        {
            planets.Add((Planet)planet);
        }
        public Star(string name, Point pos, double mass, double size,
            int temperature) : base(name, pos, mass, size)
        {
            planets = new List<Planet>();
            Temperature = temperature;
        }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= planets.Count)
                    throw new IndexOutOfRangeException();
                return planets[index];
            }
        }

        public bool Remove(Object obj)
        {
            return planets.Remove((Planet)obj);
        }
        public int Count
        {
            get
            {
                return planets.Count;
            }
        }

        public override void Draw(Graphics g, ViewInfo info)
        {
            DrawUniverse.DrawStar(this, info.camera, info.height, info.width, g);
        }
    }
}