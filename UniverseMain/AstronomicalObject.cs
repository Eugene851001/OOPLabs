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
        public double X { get; set;} 
        public double Y { get; set;}
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    [XmlInclude(typeof(Satellite))]
    [XmlInclude(typeof(Planet))]
    [XmlInclude(typeof(Star))]
    [XmlInclude(typeof(BlackHole))]
    [XmlInclude(typeof(VariableStar))]
    public class AstronomicalObject
    {
        public string Name { get; set; }
        public Point Position { get; set; }
        public double Mass { get; set; }
        public bool IsDestroy { get; set;}
        public double Size { get; set; }

        public int uid { get; set; }

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
        

        public override string ToString()
        {
            return Name;
        }
    }
}
