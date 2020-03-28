using System;
using System.Collections.Generic;
using Universe;

namespace UniverseGalaxy
{
    public class Galaxy: AstronomicalObject, IComplexObj
    {
        List<Star> stars = new List<Star>();

        public Galaxy()
        {

        }
        
        public void Add(object obj)
        {
            stars.Add((Star)obj);
        }

        public bool Remove(object obj)
        {
            return stars.Remove((Star)obj);
        }

        public int Count
        {
            get
            {
                return stars.Count;
            }
        }

        public object this[int index]
        {
            get
            {
                return stars[index];
            }
        }
    }
}
