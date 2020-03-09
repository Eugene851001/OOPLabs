using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universe
{
    interface IComplexObj
    {
        int Count { get; }
        void Add(object obj);
        object this[int index]
        {
            get;
        }
        bool Remove(object obj);
    }
}
