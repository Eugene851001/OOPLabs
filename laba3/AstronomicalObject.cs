using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;

namespace Universe
{

    public struct Point
    {
        public double X, Y;
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    [XmlInclude(typeof(Satellite))]
    [XmlInclude(typeof(Planet))]
    [XmlInclude(typeof(Star))]
    public class AstronomicalObject
    {
        public string Name;
        public Point Position;
        public double Mass;
        public bool IsDestroy;
        public double Size;
        public int uid;
        static int UidCounter = 0;
        public AstronomicalObject()
        {
            Name = "";
            Position = default(Point);
            Mass = default(double);
            IsDestroy = false;
            Size = 0;
            uid = UidCounter++;
        }
        public AstronomicalObject(string name, Point position, double mass, double size)
        {
            Name = name;
            Position = position;
            Mass = mass;
            Size = size;
            uid = UidCounter++;
        }

        public virtual void Draw(Graphics g, ViewInfo info)
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
