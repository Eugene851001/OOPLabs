using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLaba3
{
    interface ISerialize
    {
        void Serialize(object obj, string path);
        object Deserialize(string path);
    }
}
