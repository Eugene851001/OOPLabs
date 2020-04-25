using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseEditor
{
    interface IStringSerialize
    {
        string SerializeString(object obj, Type[] types);
        object DeserializeString(string source, Type[] types);
    }
}
