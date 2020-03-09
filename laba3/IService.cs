using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universe
{
    interface IService
    {
        void Add(AstronomicalObject obj);
        bool Remove(AstronomicalObject obj);

        void RemoveAll();
    }
}
